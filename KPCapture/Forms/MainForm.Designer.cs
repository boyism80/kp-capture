namespace KPU.Forms
{
    partial class KPUMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KPUMainForm));
            this.tab_detail = new System.Windows.Forms.TabPage();
            this.detailTab_bottom = new MetroFramework.Controls.MetroPanel();
            this.detailTab_splitter = new System.Windows.Forms.SplitContainer();
            this.channel_packet_viewer = new MetroFramework.Controls.MetroGrid();
            this.packetView_idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_dst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_bytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetView_dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hexboxSpliter = new System.Windows.Forms.SplitContainer();
            this.channel_base_hexbox = new Be.Windows.Forms.HexBox();
            this.channel_decrypt_hexbox = new Be.Windows.Forms.HexBox();
            this.detailTab_top = new MetroFramework.Controls.MetroPanel();
            this.channel_filter_label = new MetroFramework.Controls.MetroLabel();
            this.channel_capture_label = new MetroFramework.Controls.MetroLabel();
            this.channel_transmission_label = new MetroFramework.Controls.MetroLabel();
            this.channel_name_label = new MetroFramework.Controls.MetroLabel();
            this.channel_icon_viewer = new MetroFramework.Controls.MetroTile();
            this.tab_home = new System.Windows.Forms.TabPage();
            this.channel_viewer = new MetroFramework.Controls.MetroPanel();
            this.home_bottom_panel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.host_list = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.button_fix_host = new MetroFramework.Controls.MetroButton();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.button_add_channel = new MetroFramework.Controls.MetroButton();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.button_exit = new MetroFramework.Controls.MetroButton();
            this.TabController = new MetroFramework.Controls.MetroTabControl();
            this.packetContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.showDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyChannelContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.addChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_detail.SuspendLayout();
            this.detailTab_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailTab_splitter)).BeginInit();
            this.detailTab_splitter.Panel1.SuspendLayout();
            this.detailTab_splitter.Panel2.SuspendLayout();
            this.detailTab_splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channel_packet_viewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hexboxSpliter)).BeginInit();
            this.hexboxSpliter.Panel1.SuspendLayout();
            this.hexboxSpliter.Panel2.SuspendLayout();
            this.hexboxSpliter.SuspendLayout();
            this.detailTab_top.SuspendLayout();
            this.tab_home.SuspendLayout();
            this.home_bottom_panel.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.TabController.SuspendLayout();
            this.packetContextMenu.SuspendLayout();
            this.channelContextMenu.SuspendLayout();
            this.emptyChannelContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_detail
            // 
            this.tab_detail.Controls.Add(this.detailTab_bottom);
            this.tab_detail.Controls.Add(this.detailTab_top);
            this.tab_detail.Location = new System.Drawing.Point(4, 38);
            this.tab_detail.Name = "tab_detail";
            this.tab_detail.Size = new System.Drawing.Size(976, 462);
            this.tab_detail.TabIndex = 1;
            this.tab_detail.Text = "Detail";
            // 
            // detailTab_bottom
            // 
            this.detailTab_bottom.Controls.Add(this.detailTab_splitter);
            this.detailTab_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTab_bottom.HorizontalScrollbarBarColor = true;
            this.detailTab_bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.detailTab_bottom.HorizontalScrollbarSize = 3;
            this.detailTab_bottom.Location = new System.Drawing.Point(0, 109);
            this.detailTab_bottom.Name = "detailTab_bottom";
            this.detailTab_bottom.Padding = new System.Windows.Forms.Padding(3);
            this.detailTab_bottom.Size = new System.Drawing.Size(976, 353);
            this.detailTab_bottom.TabIndex = 1;
            this.detailTab_bottom.VerticalScrollbarBarColor = true;
            this.detailTab_bottom.VerticalScrollbarHighlightOnWheel = false;
            this.detailTab_bottom.VerticalScrollbarSize = 10;
            // 
            // detailTab_splitter
            // 
            this.detailTab_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTab_splitter.Location = new System.Drawing.Point(3, 3);
            this.detailTab_splitter.Name = "detailTab_splitter";
            // 
            // detailTab_splitter.Panel1
            // 
            this.detailTab_splitter.Panel1.Controls.Add(this.channel_packet_viewer);
            this.detailTab_splitter.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // detailTab_splitter.Panel2
            // 
            this.detailTab_splitter.Panel2.Controls.Add(this.hexboxSpliter);
            this.detailTab_splitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.detailTab_splitter.Size = new System.Drawing.Size(970, 347);
            this.detailTab_splitter.SplitterDistance = 570;
            this.detailTab_splitter.TabIndex = 0;
            // 
            // channel_packet_viewer
            // 
            this.channel_packet_viewer.AllowUserToAddRows = false;
            this.channel_packet_viewer.AllowUserToResizeRows = false;
            this.channel_packet_viewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.channel_packet_viewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.channel_packet_viewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.channel_packet_viewer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.channel_packet_viewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.channel_packet_viewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.channel_packet_viewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channel_packet_viewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packetView_idx,
            this.packetView_src,
            this.packetView_dst,
            this.packetView_bytes,
            this.packetView_size,
            this.packetView_protocol,
            this.packetView_dateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.channel_packet_viewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.channel_packet_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel_packet_viewer.EnableHeadersVisualStyles = false;
            this.channel_packet_viewer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.channel_packet_viewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.channel_packet_viewer.Location = new System.Drawing.Point(3, 3);
            this.channel_packet_viewer.Name = "channel_packet_viewer";
            this.channel_packet_viewer.ReadOnly = true;
            this.channel_packet_viewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.channel_packet_viewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.channel_packet_viewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.channel_packet_viewer.RowTemplate.Height = 23;
            this.channel_packet_viewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.channel_packet_viewer.Size = new System.Drawing.Size(564, 341);
            this.channel_packet_viewer.TabIndex = 0;
            this.channel_packet_viewer.SelectionChanged += new System.EventHandler(this.OnSelectedPacketChanged);
            this.channel_packet_viewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.channel_packet_viewer_MouseClick);
            this.channel_packet_viewer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.channel_packet_viewer_CellContentDoubleClick);
            // 
            // packetView_idx
            // 
            this.packetView_idx.HeaderText = "INDEX";
            this.packetView_idx.Name = "packetView_idx";
            this.packetView_idx.ReadOnly = true;
            // 
            // packetView_src
            // 
            this.packetView_src.HeaderText = "SOURCE";
            this.packetView_src.Name = "packetView_src";
            this.packetView_src.ReadOnly = true;
            // 
            // packetView_dst
            // 
            this.packetView_dst.HeaderText = "DESTINATION";
            this.packetView_dst.Name = "packetView_dst";
            this.packetView_dst.ReadOnly = true;
            // 
            // packetView_bytes
            // 
            this.packetView_bytes.HeaderText = "DATA";
            this.packetView_bytes.Name = "packetView_bytes";
            this.packetView_bytes.ReadOnly = true;
            // 
            // packetView_size
            // 
            this.packetView_size.HeaderText = "SIZE";
            this.packetView_size.Name = "packetView_size";
            this.packetView_size.ReadOnly = true;
            // 
            // packetView_protocol
            // 
            this.packetView_protocol.HeaderText = "PROTOCOL";
            this.packetView_protocol.Name = "packetView_protocol";
            this.packetView_protocol.ReadOnly = true;
            // 
            // packetView_dateTime
            // 
            this.packetView_dateTime.HeaderText = "TIMESTAMP";
            this.packetView_dateTime.Name = "packetView_dateTime";
            this.packetView_dateTime.ReadOnly = true;
            // 
            // hexboxSpliter
            // 
            this.hexboxSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexboxSpliter.Location = new System.Drawing.Point(3, 3);
            this.hexboxSpliter.Name = "hexboxSpliter";
            this.hexboxSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // hexboxSpliter.Panel1
            // 
            this.hexboxSpliter.Panel1.Controls.Add(this.channel_base_hexbox);
            // 
            // hexboxSpliter.Panel2
            // 
            this.hexboxSpliter.Panel2.Controls.Add(this.channel_decrypt_hexbox);
            this.hexboxSpliter.Size = new System.Drawing.Size(390, 341);
            this.hexboxSpliter.SplitterDistance = 161;
            this.hexboxSpliter.SplitterWidth = 3;
            this.hexboxSpliter.TabIndex = 0;
            // 
            // channel_base_hexbox
            // 
            this.channel_base_hexbox.ColumnInfoVisible = true;
            this.channel_base_hexbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel_base_hexbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channel_base_hexbox.LineInfoVisible = true;
            this.channel_base_hexbox.Location = new System.Drawing.Point(0, 0);
            this.channel_base_hexbox.Name = "channel_base_hexbox";
            this.channel_base_hexbox.Padding = new System.Windows.Forms.Padding(3);
            this.channel_base_hexbox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.channel_base_hexbox.Size = new System.Drawing.Size(390, 161);
            this.channel_base_hexbox.StringViewVisible = true;
            this.channel_base_hexbox.TabIndex = 1;
            this.channel_base_hexbox.UseFixedBytesPerLine = true;
            this.channel_base_hexbox.VScrollBarVisible = true;
            // 
            // channel_decrypt_hexbox
            // 
            this.channel_decrypt_hexbox.ColumnInfoVisible = true;
            this.channel_decrypt_hexbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel_decrypt_hexbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channel_decrypt_hexbox.LineInfoVisible = true;
            this.channel_decrypt_hexbox.Location = new System.Drawing.Point(0, 0);
            this.channel_decrypt_hexbox.Name = "channel_decrypt_hexbox";
            this.channel_decrypt_hexbox.Padding = new System.Windows.Forms.Padding(3);
            this.channel_decrypt_hexbox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.channel_decrypt_hexbox.Size = new System.Drawing.Size(390, 177);
            this.channel_decrypt_hexbox.StringViewVisible = true;
            this.channel_decrypt_hexbox.TabIndex = 2;
            this.channel_decrypt_hexbox.UseFixedBytesPerLine = true;
            this.channel_decrypt_hexbox.VScrollBarVisible = true;
            // 
            // detailTab_top
            // 
            this.detailTab_top.Controls.Add(this.channel_filter_label);
            this.detailTab_top.Controls.Add(this.channel_capture_label);
            this.detailTab_top.Controls.Add(this.channel_transmission_label);
            this.detailTab_top.Controls.Add(this.channel_name_label);
            this.detailTab_top.Controls.Add(this.channel_icon_viewer);
            this.detailTab_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailTab_top.HorizontalScrollbarBarColor = true;
            this.detailTab_top.HorizontalScrollbarHighlightOnWheel = false;
            this.detailTab_top.HorizontalScrollbarSize = 3;
            this.detailTab_top.Location = new System.Drawing.Point(0, 0);
            this.detailTab_top.Name = "detailTab_top";
            this.detailTab_top.Size = new System.Drawing.Size(976, 109);
            this.detailTab_top.TabIndex = 0;
            this.detailTab_top.VerticalScrollbarBarColor = true;
            this.detailTab_top.VerticalScrollbarHighlightOnWheel = false;
            this.detailTab_top.VerticalScrollbarSize = 10;
            // 
            // channel_filter_label
            // 
            this.channel_filter_label.AutoSize = true;
            this.channel_filter_label.Location = new System.Drawing.Point(109, 83);
            this.channel_filter_label.Name = "channel_filter_label";
            this.channel_filter_label.Size = new System.Drawing.Size(71, 19);
            this.channel_filter_label.TabIndex = 4;
            this.channel_filter_label.Text = "Use filter : ";
            // 
            // channel_capture_label
            // 
            this.channel_capture_label.AutoSize = true;
            this.channel_capture_label.Location = new System.Drawing.Point(109, 61);
            this.channel_capture_label.Name = "channel_capture_label";
            this.channel_capture_label.Size = new System.Drawing.Size(49, 19);
            this.channel_capture_label.TabIndex = 3;
            this.channel_capture_label.Text = "State : ";
            // 
            // channel_transmission_label
            // 
            this.channel_transmission_label.AutoSize = true;
            this.channel_transmission_label.Location = new System.Drawing.Point(109, 41);
            this.channel_transmission_label.Name = "channel_transmission_label";
            this.channel_transmission_label.Size = new System.Drawing.Size(92, 19);
            this.channel_transmission_label.TabIndex = 2;
            this.channel_transmission_label.Text = "Transmission : ";
            // 
            // channel_name_label
            // 
            this.channel_name_label.AutoSize = true;
            this.channel_name_label.Location = new System.Drawing.Point(109, 3);
            this.channel_name_label.Name = "channel_name_label";
            this.channel_name_label.Size = new System.Drawing.Size(120, 19);
            this.channel_name_label.TabIndex = 1;
            this.channel_name_label.Text = "Process Name(pid)";
            // 
            // channel_icon_viewer
            // 
            this.channel_icon_viewer.ActiveControl = null;
            this.channel_icon_viewer.BackColor = System.Drawing.Color.Transparent;
            this.channel_icon_viewer.ForeColor = System.Drawing.Color.Transparent;
            this.channel_icon_viewer.Location = new System.Drawing.Point(3, 7);
            this.channel_icon_viewer.Name = "channel_icon_viewer";
            this.channel_icon_viewer.Size = new System.Drawing.Size(100, 93);
            this.channel_icon_viewer.TabIndex = 0;
            this.channel_icon_viewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.channel_icon_viewer.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.channel_icon_viewer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.channel_icon_viewer.UseCustomBackColor = true;
            this.channel_icon_viewer.UseCustomForeColor = true;
            this.channel_icon_viewer.UseSelectable = true;
            this.channel_icon_viewer.UseTileImage = true;
            this.channel_icon_viewer.Click += new System.EventHandler(this.detailTab_icon_Click);
            // 
            // tab_home
            // 
            this.tab_home.Controls.Add(this.channel_viewer);
            this.tab_home.Controls.Add(this.home_bottom_panel);
            this.tab_home.Location = new System.Drawing.Point(4, 38);
            this.tab_home.Name = "tab_home";
            this.tab_home.Size = new System.Drawing.Size(976, 463);
            this.tab_home.TabIndex = 0;
            this.tab_home.Text = "Home";
            // 
            // channel_viewer
            // 
            this.channel_viewer.AutoScroll = true;
            this.channel_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel_viewer.HorizontalScrollbar = true;
            this.channel_viewer.HorizontalScrollbarBarColor = true;
            this.channel_viewer.HorizontalScrollbarHighlightOnWheel = false;
            this.channel_viewer.HorizontalScrollbarSize = 3;
            this.channel_viewer.Location = new System.Drawing.Point(0, 0);
            this.channel_viewer.Name = "channel_viewer";
            this.channel_viewer.Padding = new System.Windows.Forms.Padding(5);
            this.channel_viewer.Size = new System.Drawing.Size(976, 418);
            this.channel_viewer.TabIndex = 0;
            this.channel_viewer.VerticalScrollbar = true;
            this.channel_viewer.VerticalScrollbarBarColor = true;
            this.channel_viewer.VerticalScrollbarHighlightOnWheel = false;
            this.channel_viewer.VerticalScrollbarSize = 10;
            this.channel_viewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.channel_viewer_MouseClick);
            // 
            // home_bottom_panel
            // 
            this.home_bottom_panel.Controls.Add(this.metroPanel1);
            this.home_bottom_panel.Controls.Add(this.metroPanel4);
            this.home_bottom_panel.Controls.Add(this.metroPanel2);
            this.home_bottom_panel.Controls.Add(this.metroPanel3);
            this.home_bottom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.home_bottom_panel.HorizontalScrollbarBarColor = true;
            this.home_bottom_panel.HorizontalScrollbarHighlightOnWheel = false;
            this.home_bottom_panel.HorizontalScrollbarSize = 3;
            this.home_bottom_panel.Location = new System.Drawing.Point(0, 418);
            this.home_bottom_panel.Name = "home_bottom_panel";
            this.home_bottom_panel.Size = new System.Drawing.Size(976, 45);
            this.home_bottom_panel.TabIndex = 1;
            this.home_bottom_panel.VerticalScrollbarBarColor = true;
            this.home_bottom_panel.VerticalScrollbarHighlightOnWheel = false;
            this.home_bottom_panel.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoSize = true;
            this.metroPanel1.Controls.Add(this.host_list);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 3;
            this.metroPanel1.Location = new System.Drawing.Point(498, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.metroPanel1.Size = new System.Drawing.Size(195, 45);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // host_list
            // 
            this.host_list.FormattingEnabled = true;
            this.host_list.ItemHeight = 23;
            this.host_list.Location = new System.Drawing.Point(3, 5);
            this.host_list.Name = "host_list";
            this.host_list.Size = new System.Drawing.Size(184, 29);
            this.host_list.TabIndex = 0;
            this.host_list.UseSelectable = true;
            // 
            // metroPanel4
            // 
            this.metroPanel4.AutoSize = true;
            this.metroPanel4.Controls.Add(this.button_fix_host);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 3;
            this.metroPanel4.Location = new System.Drawing.Point(693, 0);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.metroPanel4.Size = new System.Drawing.Size(111, 45);
            this.metroPanel4.TabIndex = 3;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // button_fix_host
            // 
            this.button_fix_host.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.button_fix_host.Location = new System.Drawing.Point(3, 6);
            this.button_fix_host.Name = "button_fix_host";
            this.button_fix_host.Size = new System.Drawing.Size(100, 25);
            this.button_fix_host.TabIndex = 0;
            this.button_fix_host.Text = "APPLY HOST";
            this.button_fix_host.UseSelectable = true;
            this.button_fix_host.Click += new System.EventHandler(this.button_fix_host_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoSize = true;
            this.metroPanel2.Controls.Add(this.button_add_channel);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 3;
            this.metroPanel2.Location = new System.Drawing.Point(804, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.metroPanel2.Size = new System.Drawing.Size(86, 45);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // button_add_channel
            // 
            this.button_add_channel.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.button_add_channel.Location = new System.Drawing.Point(3, 6);
            this.button_add_channel.Name = "button_add_channel";
            this.button_add_channel.Size = new System.Drawing.Size(75, 25);
            this.button_add_channel.TabIndex = 0;
            this.button_add_channel.Text = "ADD";
            this.button_add_channel.UseSelectable = true;
            this.button_add_channel.Click += new System.EventHandler(this.OnClick_BtnAddChannel);
            // 
            // metroPanel3
            // 
            this.metroPanel3.AutoSize = true;
            this.metroPanel3.Controls.Add(this.button_exit);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 3;
            this.metroPanel3.Location = new System.Drawing.Point(890, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.metroPanel3.Size = new System.Drawing.Size(86, 45);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // button_exit
            // 
            this.button_exit.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.button_exit.Location = new System.Drawing.Point(3, 6);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 25);
            this.button_exit.TabIndex = 0;
            this.button_exit.Text = "EXIT";
            this.button_exit.UseSelectable = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // TabController
            // 
            this.TabController.Controls.Add(this.tab_home);
            this.TabController.Controls.Add(this.tab_detail);
            this.TabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabController.Location = new System.Drawing.Point(20, 65);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(984, 505);
            this.TabController.TabIndex = 0;
            this.TabController.UseSelectable = true;
            this.TabController.SelectedIndexChanged += new System.EventHandler(this.OnTabcontrolChanged);
            // 
            // packetContextMenu
            // 
            this.packetContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailToolStripMenuItem});
            this.packetContextMenu.Name = "packetContextMenu";
            this.packetContextMenu.Size = new System.Drawing.Size(138, 26);
            // 
            // showDetailToolStripMenuItem
            // 
            this.showDetailToolStripMenuItem.Name = "showDetailToolStripMenuItem";
            this.showDetailToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.showDetailToolStripMenuItem.Text = "Show detail";
            this.showDetailToolStripMenuItem.Click += new System.EventHandler(this.showDetailToolStripMenuItem_Click);
            // 
            // channelContextMenu
            // 
            this.channelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.detailToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.channelContextMenu.Name = "channelContextMenu";
            this.channelContextMenu.Size = new System.Drawing.Size(109, 92);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.detailToolStripMenuItem.Text = "Detail";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.detailToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // emptyChannelContextMenu
            // 
            this.emptyChannelContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChannelToolStripMenuItem});
            this.emptyChannelContextMenu.Name = "emptyChannelContextMenu";
            this.emptyChannelContextMenu.Size = new System.Drawing.Size(143, 26);
            // 
            // addChannelToolStripMenuItem
            // 
            this.addChannelToolStripMenuItem.Name = "addChannelToolStripMenuItem";
            this.addChannelToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addChannelToolStripMenuItem.Text = "Add channel";
            this.addChannelToolStripMenuItem.Click += new System.EventHandler(this.addChannelToolStripMenuItem_Click);
            // 
            // KPUMainForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(170, 15, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(1024, 591);
            this.Controls.Add(this.TabController);
            this.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 520);
            this.Name = "KPUMainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 65, 20, 21);
            this.Text = "KPCAPTURE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.tab_detail.ResumeLayout(false);
            this.detailTab_bottom.ResumeLayout(false);
            this.detailTab_splitter.Panel1.ResumeLayout(false);
            this.detailTab_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailTab_splitter)).EndInit();
            this.detailTab_splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channel_packet_viewer)).EndInit();
            this.hexboxSpliter.Panel1.ResumeLayout(false);
            this.hexboxSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hexboxSpliter)).EndInit();
            this.hexboxSpliter.ResumeLayout(false);
            this.detailTab_top.ResumeLayout(false);
            this.detailTab_top.PerformLayout();
            this.tab_home.ResumeLayout(false);
            this.home_bottom_panel.ResumeLayout(false);
            this.home_bottom_panel.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.TabController.ResumeLayout(false);
            this.packetContextMenu.ResumeLayout(false);
            this.channelContextMenu.ResumeLayout(false);
            this.emptyChannelContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tab_detail;
        private MetroFramework.Controls.MetroPanel detailTab_bottom;
        private System.Windows.Forms.SplitContainer detailTab_splitter;
        private MetroFramework.Controls.MetroGrid channel_packet_viewer;
        private MetroFramework.Controls.MetroPanel detailTab_top;
        private MetroFramework.Controls.MetroLabel channel_filter_label;
        private MetroFramework.Controls.MetroLabel channel_capture_label;
        private MetroFramework.Controls.MetroLabel channel_transmission_label;
        private MetroFramework.Controls.MetroLabel channel_name_label;
        private MetroFramework.Controls.MetroTile channel_icon_viewer;
        private System.Windows.Forms.TabPage tab_home;
        private MetroFramework.Controls.MetroPanel channel_viewer;
        private MetroFramework.Controls.MetroPanel home_bottom_panel;
        private MetroFramework.Controls.MetroButton button_add_channel;
        private MetroFramework.Controls.MetroButton button_exit;
        private MetroFramework.Controls.MetroTabControl TabController;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_dateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_bytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_dst;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetView_idx;
        private MetroFramework.Controls.MetroContextMenu packetContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showDetailToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu channelContextMenu;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu emptyChannelContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addChannelToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.SplitContainer hexboxSpliter;
        private Be.Windows.Forms.HexBox channel_base_hexbox;
        private Be.Windows.Forms.HexBox channel_decrypt_hexbox;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox host_list;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroButton button_fix_host;
    }
}

