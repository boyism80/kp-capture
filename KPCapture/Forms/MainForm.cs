using Be.Windows.Forms;
using KPU.Sources;
using KPU_Packet_Capturer.Sources;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace KPU.Forms
{
    public partial class KPUMainForm : MetroForm, IReceiveEvent
    {
        // This variable means the minimum number of items for which all items in the channel's packet viewer will be deleted. 
        // It is required because of the cost of removing the entire packet data.
        private static int                  MINIMUM_CLEAR_NETWORK_PACKET_COUNT = 100;

        // This variable is the base instance of network raw packet sniffing.
        // Main form adds this variable and adds itself to the listener to receive the captured packets in the 'OnReceive' method.
        private NetworkPacketReceiver       _network_packet_receiver;

        // This variable is a thread variable used to smoothly add captured packets to the UI.
        // It solves the problem of constantly and quickly adding data to the channel_packet_viewer, a DataGridView type.
        private Thread                      _update_thread;

        // This variable is a thread variable to detect the terminating process.
        // It detects that the target process being captured is terminated and informs the user and deletes the process from the added channel pool.
        private Thread                      _detect_exit_thread;

        // This variable is related to '_update_thread'. 
        // It is used to stop the addition of captured packet data to the UI.
        private volatile bool               _suspend_flag;

        // This variable is related to the '_detect_exit_thread' variable.
        // It is used to safely terminate threads to detect process termination.
        private volatile bool               _exit_detect_flag;

        // This variable is a table that manages processes registered by the user. 
        // Channel : A process that is captured.
        private ChannelPool                 _channel_pool;
        public ChannelPool ChannelPool { get { return this._channel_pool; } private set { this._channel_pool = value; } }

        // This variable means that the packet is being captured to the host selected by the user. 
        // If you change this value, the status of several UIs on the main tab will change.
        public bool EnabledReceive
        {
            get
            {
                if (this._network_packet_receiver == null)
                    return false;

                return this._network_packet_receiver.Running;
            }

            set
            {
                if (value)
                {
                    if (this._network_packet_receiver != null)
                        this._network_packet_receiver.close();

                    this._network_packet_receiver = new NetworkPacketReceiver(this.host_list.Text, this);
                    this.host_list.Enabled = false;
                    this.button_fix_host.Text = "STOP CAPTURE";
                }
                else
                {
                    if (this._network_packet_receiver != null)
                        this._network_packet_receiver.close();

                    this._network_packet_receiver = null;
                    this.host_list.Enabled = true;
                    this.button_fix_host.Text = "APPLY";
                }
            }
        }

        public KPUMainForm()
        {
            this.ChannelPool            = new ChannelPool();

            this._detect_exit_thread    = new Thread(this.OnDetectedExitProcessThreadRoutine);
            this._detect_exit_thread.Start();

            InitializeComponent();
        }

        private void update_channel(Channel channel)
        {
            if (channel == null)
                return;

            // 1. Update channel row
            this.ChannelPool.GetItem(channel.Id).Update();

            // 2. Create thread for update 'detail' page tab
            var isCurrentChannel        = (channel == this.TabController.TabPages["tab_detail"].Tag as Channel);
            var isThreadIdle            = (this._update_thread == null || this._update_thread.IsAlive == false);
            if (isCurrentChannel && isThreadIdle)
            {
                this._update_thread = new Thread(this.OnUpdatePacketsThreadRoutine);
                this._update_thread.Start();
            }
        }

        private void init_detail_tab(Channel channel)
        {
            var prev                        = this.TabController.TabPages["tab_detail"].Tag as Channel;
            if (prev != channel)
            {
                // 일단 여기서 하고있는 thread update를 중지한다.
                if (this._update_thread != null)
                {
                    this._suspend_flag       = true;
                    this._update_thread.Join();
                    this._suspend_flag       = false;
                    this._update_thread = null;
                }

                // 그 다음 초기화한다.
                this.channel_packet_viewer.Rows.Clear();
                this.channel_base_hexbox.ByteProvider = null;

                // 새로운 채널을 설정한다.
                this.TabController.TabPages["tab_detail"].Tag = channel;
            }
        }

        #region invoke methods
        private void append_network_packet_ui(NetworkPacket packet)
        {
            this.channel_packet_viewer.Invoke(new MethodInvoker(delegate () 
                                                                {
                                                                    var hexstr = BitConverter.ToString(packet.BaseHeader.Bytes, 0, (int)packet.BaseHeader.Length).Replace("-", " ");

                                                                    var index = this.channel_packet_viewer.Rows.Add(0,
                                                                                                                   packet.SourceAddress.ToString() + ":" + packet.SourcePort,
                                                                                                                   packet.DestinationAddress.ToString() + ":" + packet.DestinationPort,
                                                                                                                   hexstr,
                                                                                                                   packet.BaseHeader.Length,
                                                                                                                   packet.IPHeader.ProtocolType,
                                                                                                                   packet.Timestamp);

                                                                    this.channel_packet_viewer.Rows[index].Tag = packet;
                                                                }));
        }

        private void delete_network_packet_ui(DataGridViewRow row)
        {
            this.channel_packet_viewer.Invoke(new MethodInvoker(delegate () 
                                                                {
                                                                    this.channel_packet_viewer.Rows.Remove(row);
                                                                }));
        }

        private void clear_packets()
        {
            this.channel_packet_viewer.Invoke(new MethodInvoker(delegate ()
                                                                {
                                                                    this.channel_packet_viewer.Rows.Clear();
                                                                }));
        }

        public void update_channel_ui(Channel channel)
        {
            this.channel_transmission_label.Invoke(new MethodInvoker(delegate () 
                                                                    {
                                                                        this.channel_transmission_label.Text = string.Format("Translate state : {0}/{1} packets", channel.FilteredNetworkPacket.Length, channel.NetworkPackets.Length);
                                                                    }));

            this.channel_filter_label.Invoke(new MethodInvoker(delegate ()
                                                               {
                                                                   this.channel_filter_label.Text = string.Format("Use filter : {0}", channel.Filters.Length != 0 ? "Yes" : "No");
                                                               }));

            this.channel_packet_viewer.Invoke(new MethodInvoker(delegate ()
                                                                {
                                                                    var rows = this.channel_packet_viewer.Rows;
                                                                    if (rows.Count == 0)
                                                                        return;

                                                                    var last = rows[rows.Count - 1];
                                                                    if ((int)last.Cells[0].Value == last.Index + 1)
                                                                        return;

                                                                    foreach (DataGridViewRow row in this.channel_packet_viewer.Rows)
                                                                        row.Cells[0].Value = row.Index + 1;
                                                                }));
        }
        #endregion

        #region Callback method of thread routine
        private bool clear_invalid_rows(Channel channel, List<NetworkPacket> network_packetse)
        {
            var invalid_view_rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.channel_packet_viewer.Rows)
            {
                if (this._suspend_flag == true)
                    return false;

                var alive_packets = row.Tag as NetworkPacket;
                if (network_packetse.Where(p => p == alive_packets).Count() == 0)
                    invalid_view_rows.Add(row);
            }

            if (invalid_view_rows.Count > MINIMUM_CLEAR_NETWORK_PACKET_COUNT)
            {
                this.clear_packets();
            }
            else
            {
                foreach (var row in invalid_view_rows)
                {
                    if (this._suspend_flag == true)
                        return false;

                    this.delete_network_packet_ui(row);
                    this.update_channel_ui(channel);
                }
            }

            return true;
        }

        private bool append_new_packets(Channel channel, List<NetworkPacket> network_packets)
        {
            var not_appended_packets = new List<NetworkPacket>();
            foreach (var network_packet in network_packets)
            {
                if (this._suspend_flag == true)
                    return false;

                var exist = false;
                foreach (DataGridViewRow row in this.channel_packet_viewer.Rows)
                {
                    var appended_packet = row.Tag as NetworkPacket;

                    if (appended_packet != network_packet)
                        continue;

                    exist = true;
                    break;
                }

                if (!exist)
                    not_appended_packets.Add(network_packet);
            }

            foreach (var not_appended_packet in not_appended_packets)
            {
                if (this._suspend_flag == true)
                    return false;

                this.append_network_packet_ui(not_appended_packet);
                this.update_channel_ui(channel);
            }

            return true;
        }

        private void OnUpdatePacketsThreadRoutine()
        {
            var channel                 = this.TabController.TabPages["tab_detail"].Tag as Channel;
            if (channel == null)
                return;

            lock (channel)
            {
                var result_packetse = channel.FilteredNetworkPacket.ToList();

                // Remove packets
                if (this.clear_invalid_rows(channel, result_packetse) == false)
                    return;


                // Add packets
                if (this.append_new_packets(channel, result_packetse) == false)
                    return;

                // Reset detail page tab
                this.update_channel_ui(channel);
            }
        }

        private void OnDetectedExitProcessThreadRoutine()
        {
            while (!_exit_detect_flag)
            {
                var processes           = Process.GetProcesses();
                var channelExits        = new List<Channel>();
                foreach (Channel channel in this.ChannelPool)
                {
                    if (processes.Where(p => p.Id == channel.Id).Count() == 0)
                        channelExits.Add(channel);
                }

                foreach (var channelExit in channelExits)
                {
                    MetroMessageBox.Show(this, string.Format("Termination of {0}({1}) is detected.", channelExit.Process.ProcessName, channelExit.Id), "Detected");
                    this.ChannelPool.Remove(channelExit.Id);
                }

                Thread.Sleep(100);
            }
        }
        #endregion

        #region Callback method of changed channel state
        public void OnChannelAdded(Channel channel)
        {
            //var createdRow = this.ChannelTable.Add(channel, this.homeTab_ChannelItems, OnClick_ChannelButton);
            //createdRow.MouseClick += this.homeTab_ChannelItems_MouseClick;
            //createdRow.BringToFront();
        }

        public delegate void OnChannelRemovedDelegate(Channel channel);
        public void OnChannelRemoved(Channel channel)
        {
            //var ChannelItem = this.ChannelTable[channel.Id];
            //if (this.ChannelItems.InvokeRequired)
            //{
            //    this.ChannelItems.Invoke(new OnChannelRemovedDelegate(OnChannelRemoved), channel);
            //}
            //else
            //{
            //    lock (ChannelItem.Channel)
            //    {
            //        this.ChannelItems.Controls.Remove(ChannelItem);
            //    }
            //}
        }
        #endregion

        #region Callback method of winform control

        private void OnLoad(object sender, EventArgs e)
        {
            var hostentry               = Dns.GetHostEntry(Dns.GetHostName());
            if (hostentry.AddressList.Length > 0)
            {
                this.host_list.DataSource = hostentry.AddressList
                                                   .Where(ipa => ipa.AddressFamily == AddressFamily.InterNetwork)
                                                   .Select(ip => ip.ToString()).ToList();
            }

            this.TabController.SelectedTab = this.TabController.TabPages["tab_home"];
        }

        private void OnClick_BtnAddChannel(object sender, EventArgs e)
        {
            var dialog = new ChannelViewForm(this.ChannelPool, ChannelViewForm.Type.Exclude);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (Channel channel in dialog.Result)
                {
                    var item      = this.ChannelPool.Add(channel, OnClick_ChannelButton);
                    item.MouseClick += this.channel_element_MouseClick;
                    this.channel_viewer.Controls.Add(item);
                    item.BringToFront();
                }
            }
        }

        public void OnClick_ChannelButton(ChannelItem sender, ChannelItem.ChannelButtonType type)
        {
            switch (type)
            {
                case ChannelItem.ChannelButtonType.Run:
                    sender.Run();
                    break;

                case ChannelItem.ChannelButtonType.Pause:
                    sender.Pause();
                    break;

                case ChannelItem.ChannelButtonType.Detail:
                    this.init_detail_tab(sender.Channel);
                    this.TabController.SelectedTab = this.TabController.TabPages["tab_detail"];
                    break;

                case ChannelItem.ChannelButtonType.Filter:
                    new FilterDialog(sender.Channel, this.OnReceiveFilters).ShowDialog(this);
                    break;

                case ChannelItem.ChannelButtonType.Delete:
                    this.ChannelPool.Remove(sender.Channel.Id);
                    break;
            }
        }

        private void OnTabcontrolChanged(object sender, EventArgs e)
        {
            switch (this.TabController.SelectedTab.Name)
            {
                case "HOME":
                    foreach (Channel ch in this.ChannelPool)
                        this.update_channel(ch);
                    break;

                case "tab_detail":
                    var channel             = this.TabController.TabPages["tab_detail"].Tag as Channel;
                    if (channel == null || this.ChannelPool.Contains(channel.Id) == false)
                    {
                        this.init_detail_tab(null);

                        this.channel_icon_viewer.TileImage = null;
                        this.channel_name_label.Text = "Channel name : None";
                        this.channel_transmission_label.Text = "Translate state : None";
                        this.channel_capture_label.Text = "Captureing : None";
                        this.channel_filter_label.Text = "Filter : None";
                    }
                    else
                    {
                        // Set icon of channel
                        this.channel_icon_viewer.TileImage = channel.image(new Size((int)(this.channel_icon_viewer.Width * 0.5f),
                                                                               (int)(this.channel_icon_viewer.Height * 0.5f)));

                        // Set label text
                        this.channel_name_label.Text = string.Format("Channel name : {0}({1})", channel.Process.ProcessName, channel.Id);
                        this.channel_capture_label.Text = string.Format("Captureing : {0}", channel.Running ? "Yes" : "No");
                        this.update_channel_ui(channel);

                        this.OnSelectedPacketChanged(this.channel_packet_viewer, EventArgs.Empty);

                        this.update_channel(channel);
                    }
                    break;
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (this._network_packet_receiver != null)
                this._network_packet_receiver.close();

            if (this._detect_exit_thread != null && this._detect_exit_thread.IsAlive)
                this._exit_detect_flag = true;

            if (this._update_thread != null && this._update_thread.IsAlive)
                this._suspend_flag = true;
        }

        private void channel_packet_viewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var selectedIndex           = this.channel_packet_viewer.HitTest(e.X, e.Y).RowIndex;
            if (selectedIndex >= 0)
            {
                this.channel_packet_viewer.ClearSelection();
                this.channel_packet_viewer.Rows[selectedIndex].Selected = true;

                this.packetContextMenu.Tag = this.channel_packet_viewer.Rows[selectedIndex].Tag;
                this.packetContextMenu.Show(this.channel_packet_viewer, new Point(e.X, e.Y));
            }
        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var packet                  = this.packetContextMenu.Tag as NetworkPacket;
            var dialog                  = new PacketViewForm(packet);
            dialog.ShowDialog(this);
        }

        private void channel_packet_viewer_CellContentDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedIndex = this.channel_packet_viewer.HitTest(e.X, e.Y).RowIndex;
            if (selectedIndex < 0)
                return;

            var packet                  = this.channel_packet_viewer.Rows[selectedIndex].Tag as NetworkPacket;
            var dialog                  = new PacketViewForm(packet);
            dialog.ShowDialog(this);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel                 = this.channelContextMenu.Tag as Channel;
            var ChannelItem              = this.ChannelPool.GetItem(channel.Id);
            this.OnClick_ChannelButton(ChannelItem, channel.Running ? ChannelItem.ChannelButtonType.Pause : ChannelItem.ChannelButtonType.Run);
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel                 = this.channelContextMenu.Tag as Channel;
            var ChannelItem              = this.ChannelPool.GetItem(channel.Id);
            this.OnClick_ChannelButton(ChannelItem, ChannelItem.ChannelButtonType.Detail);
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel                 = this.channelContextMenu.Tag as Channel;
            var ChannelItem              = this.ChannelPool.GetItem(channel.Id);

            this.OnClick_ChannelButton(ChannelItem, ChannelItem.ChannelButtonType.Filter);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var channel                 = this.channelContextMenu.Tag as Channel;
            var ChannelItem              = this.ChannelPool.GetItem(channel.Id);

            this.OnClick_ChannelButton(ChannelItem, ChannelItem.ChannelButtonType.Delete);
        }

        private void channel_element_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var item                     = sender as ChannelItem;
            var channel                 = item.Channel;
            this.channelContextMenu.Tag = channel;
            if (channel.Running)
                this.channelContextMenu.Items[0].Text = "Pause";
            else
                this.channelContextMenu.Items[0].Text = "Run";

            this.channelContextMenu.Show(item.Background, e.X, e.Y);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnClick_BtnAddChannel(this.button_add_channel, EventArgs.Empty);
        }

        private void channel_viewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            this.emptyChannelContextMenu.Show(this.channel_viewer, e.X, e.Y);
        }

        private void detailTab_icon_Click(object sender, EventArgs e)
        {
            var dialog                  = new ChannelViewForm(this.ChannelPool, ChannelViewForm.Type.Choice);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                var channel             = dialog.Result[0];
                OnClick_ChannelButton(this.ChannelPool.GetItem(channel.Id), ChannelItem.ChannelButtonType.Detail);
                OnTabcontrolChanged(this.TabController, EventArgs.Empty);
            }
        }

        private void OnSelectedPacketChanged(object sender, EventArgs e)
        {
            if (this.channel_packet_viewer.SelectedRows.Count == 0)
                return;

            var selection               = this.channel_packet_viewer.SelectedRows[0].Tag as NetworkPacket;
            if (selection == null)
                return;

            this.channel_base_hexbox.ByteProvider = new DynamicByteProvider(selection.BaseHeader.Bytes);


            // Set decrypted bytes
            var channel                 = this.TabController.TabPages["tab_detail"].Tag as Channel;
            var decrypted = channel.decrypted_bytes(selection);
            if (decrypted != null)
                this.channel_decrypt_hexbox.ByteProvider = new DynamicByteProvider(decrypted);
        }

        private void OnReceiveFilters(Channel channel, Filter[] filters)
        {
            lock (channel)
            {
                channel.set_filter(filters);

                this.update_channel_ui(channel);
            }
        }

        private void button_fix_host_Click(object sender, EventArgs e)
        {
            this.EnabledReceive = !this.EnabledReceive;
            if(this.EnabledReceive)
                MetroMessageBox.Show(this, "Success to apply capture host : " + this.host_list.Text, "Success!!");
        }

        public void OnReceive(NetworkPacket network_packet)
        {
            if (network_packet.Protocol == Protocol.TCP)
            {
                foreach (var pid in TCPTableEx.FindProcessId(network_packet))
                {
                    if (this.ChannelPool.Contains((int)pid) == false)
                        continue;


                    var channel = this.ChannelPool[(int)pid];
                    lock (channel)
                    {
                        if (channel.add_packet(network_packet) == true)
                            this.update_channel(channel);
                    }
                }
            }
            else
            {
                foreach (var pid in UDPTableEx.FindProcessId(network_packet))
                {
                    if (this.ChannelPool.Contains((int)pid) == false)
                        continue;

                    var channel = this.ChannelPool[(int)pid];
                    lock (channel)
                    {
                        if (channel.add_packet(network_packet) == true)
                            this.update_channel(channel);
                    }
                }
            }
        }

        public void OnError(string message)
        {
            
        }
        #endregion
    }
}