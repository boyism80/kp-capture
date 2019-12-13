using MetroFramework.Forms;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using KPU.Sources;

namespace KPU.Forms
{
    public partial class ChannelViewForm : MetroForm
    {
        public enum Type
        {
            Exclude, Choice,
        }

        public Channel[] Result { get; set; } 

        public ChannelViewForm(ChannelPool table, Type type)
        {
            InitializeComponent();

            if (type == Type.Exclude)
            {
                foreach (var p in Process.GetProcesses().Where(p => table.Contains(p.Id) == false))
                {
                    try
                    {
                        // Extract icon and add in image list
                        var icon        = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                        this.iconList.Images.Add(icon);

                        var item        = new ListViewItem(string.Format("{0}({1})", p.ProcessName, p.Id), this.iconList.Images.Count - 1);
                        item.Tag        = new Channel(p);


                        // Disable if process is already added
                        this.channelListView.Items.Add(item);
                    }
                    catch (Exception /*e*/)
                    {
                        //Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                foreach (Channel channel in table)
                {
                    try
                    {
                        // Extract icon and add in image list
                        var icon        = Icon.ExtractAssociatedIcon(channel.Process.MainModule.FileName);
                        this.iconList.Images.Add(icon);

                        var item        = new ListViewItem(string.Format("{0}({1})", channel.Process.ProcessName, channel.Id), this.iconList.Images.Count - 1);
                        item.Tag        = channel;


                        // Disable if process is already added
                        this.channelListView.Items.Add(item);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void AddChannel(object sender, EventArgs e)
        {
            var count                   = this.channelListView.SelectedItems.Count;
            if (count == 0)
                return;

            this.Result                 = new Channel[count];
            for (var i = 0; i < count; i++)
                this.Result[i]          = this.channelListView.SelectedItems[i].Tag as Channel;

            this.DialogResult           = DialogResult.OK;
            this.Close();
        }

        private void ChangedSelection(object sender, EventArgs e)
        {
            this.addButton.Enabled      = this.channelListView.SelectedItems.Count != 0;
        }

        private new void DoubleClick(object sender, MouseEventArgs e)
        {
            this.AddChannel(sender, EventArgs.Empty);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult           = DialogResult.Cancel;
            this.Close();
        }
    }
}
