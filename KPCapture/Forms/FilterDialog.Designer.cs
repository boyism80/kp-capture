namespace KPU.Forms
{
    partial class FilterDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterDialog));
            this.MainForm_TabControl = new MetroFramework.Controls.MetroTabControl();
            this.FILTER = new System.Windows.Forms.TabPage();
            this.filterTab_top = new MetroFramework.Controls.MetroPanel();
            this.filterTab_nameLabel = new MetroFramework.Controls.MetroLabel();
            this.filterTab_icon = new MetroFramework.Controls.MetroTile();
            this.filterTab_content = new MetroFramework.Controls.MetroPanel();
            this.filterTab_splitter = new System.Windows.Forms.SplitContainer();
            this.filterTab_wrapView = new MetroFramework.Controls.MetroPanel();
            this.filterTab_filterView = new MetroFramework.Controls.MetroGrid();
            this.filterView_sourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterView_destinationIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterView_sizeRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterView_protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterView_containBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterview_checksum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterview_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterTab_bottom = new MetroFramework.Controls.MetroPanel();
            this.filterTab_setting = new MetroFramework.Controls.MetroPanel();
            this.filterTab_settingPanel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_acceptAppLevelCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.filterTab_validChecksumCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_sourcePortTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_sourceIPTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_sourcePortCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.filterTab_sourceIPCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_destinationPortTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_destinationIPTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_destinationPortCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.filterTab_destinationIPCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_maximumTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_minimumTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_maximumCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.filterTab_minimumCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_protocolComboBox = new MetroFramework.Controls.MetroComboBox();
            this.filterTab_protocolCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.filterTab_convertHexLabel = new MetroFramework.Controls.MetroLabel();
            this.filterTab_convertToHexTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_containBytesTextBox = new MetroFramework.Controls.MetroTextBox();
            this.filterTab_convertToHexButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_containBytesCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.filterTab_modifyButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_cancelButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_OKButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_deleteButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_applyButton = new MetroFramework.Controls.MetroButton();
            this.filterTab_addButton = new MetroFramework.Controls.MetroButton();
            this.DECRYPT = new System.Windows.Forms.TabPage();
            this.decryptTab_content = new MetroFramework.Controls.MetroPanel();
            this.decryptTab_splitter = new System.Windows.Forms.SplitContainer();
            this.decryptTab_scriptLoad = new MetroFramework.Controls.MetroPanel();
            this.decryptTab_applyButton = new MetroFramework.Controls.MetroButton();
            this.decryptTab_clearButton = new MetroFramework.Controls.MetroButton();
            this.decryptTab_browseButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.decryptTab_pathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.decryptTab_scriptView = new MetroFramework.Controls.MetroPanel();
            this.decryptTab_scriptTextBox = new MetroFramework.Controls.MetroTextBox();
            this.decryptTab_head = new MetroFramework.Controls.MetroPanel();
            this.decryptTab_descLabel = new MetroFramework.Controls.MetroLabel();
            this.decryptTab_nameLabel = new MetroFramework.Controls.MetroLabel();
            this.decryptTab_iconPython = new MetroFramework.Controls.MetroTile();
            this.MainForm_TabControl.SuspendLayout();
            this.FILTER.SuspendLayout();
            this.filterTab_top.SuspendLayout();
            this.filterTab_content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterTab_splitter)).BeginInit();
            this.filterTab_splitter.Panel1.SuspendLayout();
            this.filterTab_splitter.Panel2.SuspendLayout();
            this.filterTab_splitter.SuspendLayout();
            this.filterTab_wrapView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterTab_filterView)).BeginInit();
            this.filterTab_bottom.SuspendLayout();
            this.filterTab_setting.SuspendLayout();
            this.filterTab_settingPanel.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel6.SuspendLayout();
            this.DECRYPT.SuspendLayout();
            this.decryptTab_content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decryptTab_splitter)).BeginInit();
            this.decryptTab_splitter.Panel1.SuspendLayout();
            this.decryptTab_splitter.Panel2.SuspendLayout();
            this.decryptTab_splitter.SuspendLayout();
            this.decryptTab_scriptLoad.SuspendLayout();
            this.decryptTab_scriptView.SuspendLayout();
            this.decryptTab_head.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm_TabControl
            // 
            this.MainForm_TabControl.Controls.Add(this.FILTER);
            this.MainForm_TabControl.Controls.Add(this.DECRYPT);
            this.MainForm_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainForm_TabControl.Location = new System.Drawing.Point(20, 65);
            this.MainForm_TabControl.Name = "MainForm_TabControl";
            this.MainForm_TabControl.SelectedIndex = 0;
            this.MainForm_TabControl.Size = new System.Drawing.Size(631, 852);
            this.MainForm_TabControl.TabIndex = 1;
            this.MainForm_TabControl.UseSelectable = true;
            // 
            // FILTER
            // 
            this.FILTER.Controls.Add(this.filterTab_top);
            this.FILTER.Controls.Add(this.filterTab_content);
            this.FILTER.Location = new System.Drawing.Point(4, 38);
            this.FILTER.Name = "FILTER";
            this.FILTER.Size = new System.Drawing.Size(623, 810);
            this.FILTER.TabIndex = 0;
            this.FILTER.Text = "Filter";
            // 
            // filterTab_top
            // 
            this.filterTab_top.AutoScroll = true;
            this.filterTab_top.Controls.Add(this.filterTab_nameLabel);
            this.filterTab_top.Controls.Add(this.filterTab_icon);
            this.filterTab_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_top.HorizontalScrollbar = true;
            this.filterTab_top.HorizontalScrollbarBarColor = true;
            this.filterTab_top.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_top.HorizontalScrollbarSize = 3;
            this.filterTab_top.Location = new System.Drawing.Point(0, 0);
            this.filterTab_top.Name = "filterTab_top";
            this.filterTab_top.Padding = new System.Windows.Forms.Padding(5, 7, 20, 7);
            this.filterTab_top.Size = new System.Drawing.Size(623, 114);
            this.filterTab_top.TabIndex = 0;
            this.filterTab_top.VerticalScrollbar = true;
            this.filterTab_top.VerticalScrollbarBarColor = true;
            this.filterTab_top.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_top.VerticalScrollbarSize = 10;
            // 
            // filterTab_nameLabel
            // 
            this.filterTab_nameLabel.AutoSize = true;
            this.filterTab_nameLabel.Location = new System.Drawing.Point(102, 10);
            this.filterTab_nameLabel.Name = "filterTab_nameLabel";
            this.filterTab_nameLabel.Size = new System.Drawing.Size(93, 19);
            this.filterTab_nameLabel.TabIndex = 5;
            this.filterTab_nameLabel.Text = "Process Name";
            // 
            // filterTab_icon
            // 
            this.filterTab_icon.ActiveControl = null;
            this.filterTab_icon.BackColor = System.Drawing.Color.Transparent;
            this.filterTab_icon.ForeColor = System.Drawing.Color.Transparent;
            this.filterTab_icon.Location = new System.Drawing.Point(8, 10);
            this.filterTab_icon.Name = "filterTab_icon";
            this.filterTab_icon.Size = new System.Drawing.Size(88, 95);
            this.filterTab_icon.TabIndex = 4;
            this.filterTab_icon.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.filterTab_icon.UseCustomBackColor = true;
            this.filterTab_icon.UseCustomForeColor = true;
            this.filterTab_icon.UseSelectable = true;
            this.filterTab_icon.UseTileImage = true;
            // 
            // filterTab_content
            // 
            this.filterTab_content.Controls.Add(this.filterTab_splitter);
            this.filterTab_content.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterTab_content.HorizontalScrollbarBarColor = true;
            this.filterTab_content.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_content.HorizontalScrollbarSize = 3;
            this.filterTab_content.Location = new System.Drawing.Point(0, 114);
            this.filterTab_content.Name = "filterTab_content";
            this.filterTab_content.Size = new System.Drawing.Size(623, 696);
            this.filterTab_content.TabIndex = 1;
            this.filterTab_content.VerticalScrollbarBarColor = true;
            this.filterTab_content.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_content.VerticalScrollbarSize = 10;
            // 
            // filterTab_splitter
            // 
            this.filterTab_splitter.BackColor = System.Drawing.Color.White;
            this.filterTab_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_splitter.Location = new System.Drawing.Point(0, 0);
            this.filterTab_splitter.Name = "filterTab_splitter";
            this.filterTab_splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // filterTab_splitter.Panel1
            // 
            this.filterTab_splitter.Panel1.BackColor = System.Drawing.Color.White;
            this.filterTab_splitter.Panel1.Controls.Add(this.filterTab_wrapView);
            this.filterTab_splitter.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // filterTab_splitter.Panel2
            // 
            this.filterTab_splitter.Panel2.BackColor = System.Drawing.Color.White;
            this.filterTab_splitter.Panel2.Controls.Add(this.filterTab_bottom);
            this.filterTab_splitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.filterTab_splitter.Size = new System.Drawing.Size(623, 696);
            this.filterTab_splitter.SplitterDistance = 255;
            this.filterTab_splitter.TabIndex = 2;
            // 
            // filterTab_wrapView
            // 
            this.filterTab_wrapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterTab_wrapView.Controls.Add(this.filterTab_filterView);
            this.filterTab_wrapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_wrapView.HorizontalScrollbarBarColor = true;
            this.filterTab_wrapView.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_wrapView.HorizontalScrollbarSize = 11;
            this.filterTab_wrapView.Location = new System.Drawing.Point(3, 3);
            this.filterTab_wrapView.Name = "filterTab_wrapView";
            this.filterTab_wrapView.Size = new System.Drawing.Size(617, 249);
            this.filterTab_wrapView.TabIndex = 0;
            this.filterTab_wrapView.VerticalScrollbarBarColor = true;
            this.filterTab_wrapView.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_wrapView.VerticalScrollbarSize = 10;
            // 
            // filterTab_filterView
            // 
            this.filterTab_filterView.AllowUserToAddRows = false;
            this.filterTab_filterView.AllowUserToResizeRows = false;
            this.filterTab_filterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filterTab_filterView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filterTab_filterView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filterTab_filterView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filterTab_filterView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filterTab_filterView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.filterTab_filterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filterView_sourceIP,
            this.filterView_destinationIP,
            this.filterView_sizeRange,
            this.filterView_protocol,
            this.filterView_containBytes,
            this.filterview_checksum,
            this.filterview_level});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filterTab_filterView.DefaultCellStyle = dataGridViewCellStyle5;
            this.filterTab_filterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_filterView.EnableHeadersVisualStyles = false;
            this.filterTab_filterView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filterTab_filterView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filterTab_filterView.Location = new System.Drawing.Point(0, 0);
            this.filterTab_filterView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterTab_filterView.Name = "filterTab_filterView";
            this.filterTab_filterView.ReadOnly = true;
            this.filterTab_filterView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filterTab_filterView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.filterTab_filterView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filterTab_filterView.RowTemplate.Height = 27;
            this.filterTab_filterView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filterTab_filterView.Size = new System.Drawing.Size(615, 247);
            this.filterTab_filterView.TabIndex = 6;
            this.filterTab_filterView.SelectionChanged += new System.EventHandler(this.metroFilterGridView_SelectionChanged);
            // 
            // filterView_sourceIP
            // 
            this.filterView_sourceIP.HeaderText = "Source";
            this.filterView_sourceIP.Name = "filterView_sourceIP";
            this.filterView_sourceIP.ReadOnly = true;
            // 
            // filterView_destinationIP
            // 
            this.filterView_destinationIP.HeaderText = "Destination";
            this.filterView_destinationIP.Name = "filterView_destinationIP";
            this.filterView_destinationIP.ReadOnly = true;
            // 
            // filterView_sizeRange
            // 
            this.filterView_sizeRange.HeaderText = "Size range";
            this.filterView_sizeRange.Name = "filterView_sizeRange";
            this.filterView_sizeRange.ReadOnly = true;
            // 
            // filterView_protocol
            // 
            this.filterView_protocol.HeaderText = "Protocol";
            this.filterView_protocol.Name = "filterView_protocol";
            this.filterView_protocol.ReadOnly = true;
            // 
            // filterView_containBytes
            // 
            this.filterView_containBytes.HeaderText = "Contain bytes";
            this.filterView_containBytes.Name = "filterView_containBytes";
            this.filterView_containBytes.ReadOnly = true;
            // 
            // filterview_checksum
            // 
            this.filterview_checksum.HeaderText = "Checksum";
            this.filterview_checksum.Name = "filterview_checksum";
            this.filterview_checksum.ReadOnly = true;
            // 
            // filterview_level
            // 
            this.filterview_level.HeaderText = "Level";
            this.filterview_level.Name = "filterview_level";
            this.filterview_level.ReadOnly = true;
            // 
            // filterTab_bottom
            // 
            this.filterTab_bottom.Controls.Add(this.filterTab_setting);
            this.filterTab_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_bottom.HorizontalScrollbarBarColor = true;
            this.filterTab_bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_bottom.HorizontalScrollbarSize = 11;
            this.filterTab_bottom.Location = new System.Drawing.Point(3, 3);
            this.filterTab_bottom.Name = "filterTab_bottom";
            this.filterTab_bottom.Size = new System.Drawing.Size(617, 431);
            this.filterTab_bottom.TabIndex = 21;
            this.filterTab_bottom.VerticalScrollbarBarColor = true;
            this.filterTab_bottom.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_bottom.VerticalScrollbarSize = 10;
            // 
            // filterTab_setting
            // 
            this.filterTab_setting.AutoScroll = true;
            this.filterTab_setting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterTab_setting.Controls.Add(this.filterTab_settingPanel);
            this.filterTab_setting.Controls.Add(this.filterTab_modifyButton);
            this.filterTab_setting.Controls.Add(this.filterTab_cancelButton);
            this.filterTab_setting.Controls.Add(this.filterTab_OKButton);
            this.filterTab_setting.Controls.Add(this.filterTab_deleteButton);
            this.filterTab_setting.Controls.Add(this.filterTab_applyButton);
            this.filterTab_setting.Controls.Add(this.filterTab_addButton);
            this.filterTab_setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTab_setting.HorizontalScrollbar = true;
            this.filterTab_setting.HorizontalScrollbarBarColor = true;
            this.filterTab_setting.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_setting.HorizontalScrollbarSize = 9;
            this.filterTab_setting.Location = new System.Drawing.Point(0, 0);
            this.filterTab_setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterTab_setting.Name = "filterTab_setting";
            this.filterTab_setting.Padding = new System.Windows.Forms.Padding(3, 17, 3, 26);
            this.filterTab_setting.Size = new System.Drawing.Size(617, 431);
            this.filterTab_setting.TabIndex = 22;
            this.filterTab_setting.VerticalScrollbar = true;
            this.filterTab_setting.VerticalScrollbarBarColor = true;
            this.filterTab_setting.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_setting.VerticalScrollbarSize = 9;
            // 
            // filterTab_settingPanel
            // 
            this.filterTab_settingPanel.AutoScroll = true;
            this.filterTab_settingPanel.Controls.Add(this.metroPanel2);
            this.filterTab_settingPanel.Controls.Add(this.metroPanel1);
            this.filterTab_settingPanel.Controls.Add(this.metroPanel5);
            this.filterTab_settingPanel.Controls.Add(this.metroPanel3);
            this.filterTab_settingPanel.Controls.Add(this.metroPanel4);
            this.filterTab_settingPanel.Controls.Add(this.metroPanel6);
            this.filterTab_settingPanel.HorizontalScrollbar = true;
            this.filterTab_settingPanel.HorizontalScrollbarBarColor = true;
            this.filterTab_settingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.filterTab_settingPanel.HorizontalScrollbarSize = 11;
            this.filterTab_settingPanel.Location = new System.Drawing.Point(6, 21);
            this.filterTab_settingPanel.Name = "filterTab_settingPanel";
            this.filterTab_settingPanel.Size = new System.Drawing.Size(603, 336);
            this.filterTab_settingPanel.TabIndex = 14;
            this.filterTab_settingPanel.VerticalScrollbar = true;
            this.filterTab_settingPanel.VerticalScrollbarBarColor = true;
            this.filterTab_settingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.filterTab_settingPanel.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoSize = true;
            this.metroPanel2.Controls.Add(this.filterTab_acceptAppLevelCheckBox);
            this.metroPanel2.Controls.Add(this.filterTab_validChecksumCheckBox);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 11;
            this.metroPanel2.Location = new System.Drawing.Point(0, 308);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Padding = new System.Windows.Forms.Padding(0, 9, 0, 9);
            this.metroPanel2.Size = new System.Drawing.Size(586, 39);
            this.metroPanel2.TabIndex = 8;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // filterTab_acceptAppLevelCheckBox
            // 
            this.filterTab_acceptAppLevelCheckBox.AutoSize = true;
            this.filterTab_acceptAppLevelCheckBox.Location = new System.Drawing.Point(142, 12);
            this.filterTab_acceptAppLevelCheckBox.Name = "filterTab_acceptAppLevelCheckBox";
            this.filterTab_acceptAppLevelCheckBox.Size = new System.Drawing.Size(175, 15);
            this.filterTab_acceptAppLevelCheckBox.TabIndex = 2;
            this.filterTab_acceptAppLevelCheckBox.Text = "Only accept application level";
            this.filterTab_acceptAppLevelCheckBox.UseSelectable = true;
            // 
            // filterTab_validChecksumCheckBox
            // 
            this.filterTab_validChecksumCheckBox.AutoSize = true;
            this.filterTab_validChecksumCheckBox.Location = new System.Drawing.Point(3, 12);
            this.filterTab_validChecksumCheckBox.Name = "filterTab_validChecksumCheckBox";
            this.filterTab_validChecksumCheckBox.Size = new System.Drawing.Size(133, 15);
            this.filterTab_validChecksumCheckBox.TabIndex = 2;
            this.filterTab_validChecksumCheckBox.Text = "Only valid checksum";
            this.filterTab_validChecksumCheckBox.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.filterTab_sourcePortTextBox);
            this.metroPanel1.Controls.Add(this.filterTab_sourceIPTextBox);
            this.metroPanel1.Controls.Add(this.filterTab_sourcePortCheckBox);
            this.metroPanel1.Controls.Add(this.filterTab_sourceIPCheckBox);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 11;
            this.metroPanel1.Location = new System.Drawing.Point(0, 255);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(586, 53);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // filterTab_sourcePortTextBox
            // 
            // 
            // 
            // 
            this.filterTab_sourcePortTextBox.CustomButton.Image = null;
            this.filterTab_sourcePortTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_sourcePortTextBox.CustomButton.Name = "";
            this.filterTab_sourcePortTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_sourcePortTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_sourcePortTextBox.CustomButton.TabIndex = 1;
            this.filterTab_sourcePortTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_sourcePortTextBox.CustomButton.UseSelectable = true;
            this.filterTab_sourcePortTextBox.CustomButton.Visible = false;
            this.filterTab_sourcePortTextBox.Enabled = false;
            this.filterTab_sourcePortTextBox.Lines = new string[0];
            this.filterTab_sourcePortTextBox.Location = new System.Drawing.Point(419, 15);
            this.filterTab_sourcePortTextBox.MaxLength = 32767;
            this.filterTab_sourcePortTextBox.Name = "filterTab_sourcePortTextBox";
            this.filterTab_sourcePortTextBox.PasswordChar = '\0';
            this.filterTab_sourcePortTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_sourcePortTextBox.SelectedText = "";
            this.filterTab_sourcePortTextBox.SelectionLength = 0;
            this.filterTab_sourcePortTextBox.SelectionStart = 0;
            this.filterTab_sourcePortTextBox.ShortcutsEnabled = true;
            this.filterTab_sourcePortTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_sourcePortTextBox.TabIndex = 3;
            this.filterTab_sourcePortTextBox.UseSelectable = true;
            this.filterTab_sourcePortTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_sourcePortTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_sourceIPTextBox
            // 
            // 
            // 
            // 
            this.filterTab_sourceIPTextBox.CustomButton.Image = null;
            this.filterTab_sourceIPTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_sourceIPTextBox.CustomButton.Name = "";
            this.filterTab_sourceIPTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_sourceIPTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_sourceIPTextBox.CustomButton.TabIndex = 1;
            this.filterTab_sourceIPTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_sourceIPTextBox.CustomButton.UseSelectable = true;
            this.filterTab_sourceIPTextBox.CustomButton.Visible = false;
            this.filterTab_sourceIPTextBox.Enabled = false;
            this.filterTab_sourceIPTextBox.Lines = new string[0];
            this.filterTab_sourceIPTextBox.Location = new System.Drawing.Point(146, 15);
            this.filterTab_sourceIPTextBox.MaxLength = 32767;
            this.filterTab_sourceIPTextBox.Name = "filterTab_sourceIPTextBox";
            this.filterTab_sourceIPTextBox.PasswordChar = '\0';
            this.filterTab_sourceIPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_sourceIPTextBox.SelectedText = "";
            this.filterTab_sourceIPTextBox.SelectionLength = 0;
            this.filterTab_sourceIPTextBox.SelectionStart = 0;
            this.filterTab_sourceIPTextBox.ShortcutsEnabled = true;
            this.filterTab_sourceIPTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_sourceIPTextBox.TabIndex = 3;
            this.filterTab_sourceIPTextBox.UseSelectable = true;
            this.filterTab_sourceIPTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_sourceIPTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_sourcePortCheckBox
            // 
            this.filterTab_sourcePortCheckBox.AutoSize = true;
            this.filterTab_sourcePortCheckBox.Location = new System.Drawing.Point(276, 20);
            this.filterTab_sourcePortCheckBox.Name = "filterTab_sourcePortCheckBox";
            this.filterTab_sourcePortCheckBox.Size = new System.Drawing.Size(84, 15);
            this.filterTab_sourcePortCheckBox.TabIndex = 2;
            this.filterTab_sourcePortCheckBox.Text = "Source port";
            this.filterTab_sourcePortCheckBox.UseSelectable = true;
            this.filterTab_sourcePortCheckBox.CheckedChanged += new System.EventHandler(this.sourcePortCheckBox_CheckedChanged);
            // 
            // filterTab_sourceIPCheckBox
            // 
            this.filterTab_sourceIPCheckBox.AutoSize = true;
            this.filterTab_sourceIPCheckBox.Location = new System.Drawing.Point(3, 20);
            this.filterTab_sourceIPCheckBox.Name = "filterTab_sourceIPCheckBox";
            this.filterTab_sourceIPCheckBox.Size = new System.Drawing.Size(102, 15);
            this.filterTab_sourceIPCheckBox.TabIndex = 2;
            this.filterTab_sourceIPCheckBox.Text = "Source address";
            this.filterTab_sourceIPCheckBox.UseSelectable = true;
            this.filterTab_sourceIPCheckBox.CheckedChanged += new System.EventHandler(this.sourceIPCheckBox_CheckedChanged);
            // 
            // metroPanel5
            // 
            this.metroPanel5.Controls.Add(this.filterTab_destinationPortTextBox);
            this.metroPanel5.Controls.Add(this.filterTab_destinationIPTextBox);
            this.metroPanel5.Controls.Add(this.filterTab_destinationPortCheckBox);
            this.metroPanel5.Controls.Add(this.filterTab_destinationIPCheckBox);
            this.metroPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 11;
            this.metroPanel5.Location = new System.Drawing.Point(0, 202);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(586, 53);
            this.metroPanel5.TabIndex = 4;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // filterTab_destinationPortTextBox
            // 
            // 
            // 
            // 
            this.filterTab_destinationPortTextBox.CustomButton.Image = null;
            this.filterTab_destinationPortTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_destinationPortTextBox.CustomButton.Name = "";
            this.filterTab_destinationPortTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_destinationPortTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_destinationPortTextBox.CustomButton.TabIndex = 1;
            this.filterTab_destinationPortTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_destinationPortTextBox.CustomButton.UseSelectable = true;
            this.filterTab_destinationPortTextBox.CustomButton.Visible = false;
            this.filterTab_destinationPortTextBox.Enabled = false;
            this.filterTab_destinationPortTextBox.Lines = new string[0];
            this.filterTab_destinationPortTextBox.Location = new System.Drawing.Point(419, 15);
            this.filterTab_destinationPortTextBox.MaxLength = 32767;
            this.filterTab_destinationPortTextBox.Name = "filterTab_destinationPortTextBox";
            this.filterTab_destinationPortTextBox.PasswordChar = '\0';
            this.filterTab_destinationPortTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_destinationPortTextBox.SelectedText = "";
            this.filterTab_destinationPortTextBox.SelectionLength = 0;
            this.filterTab_destinationPortTextBox.SelectionStart = 0;
            this.filterTab_destinationPortTextBox.ShortcutsEnabled = true;
            this.filterTab_destinationPortTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_destinationPortTextBox.TabIndex = 3;
            this.filterTab_destinationPortTextBox.UseSelectable = true;
            this.filterTab_destinationPortTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_destinationPortTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_destinationIPTextBox
            // 
            // 
            // 
            // 
            this.filterTab_destinationIPTextBox.CustomButton.Image = null;
            this.filterTab_destinationIPTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_destinationIPTextBox.CustomButton.Name = "";
            this.filterTab_destinationIPTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_destinationIPTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_destinationIPTextBox.CustomButton.TabIndex = 1;
            this.filterTab_destinationIPTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_destinationIPTextBox.CustomButton.UseSelectable = true;
            this.filterTab_destinationIPTextBox.CustomButton.Visible = false;
            this.filterTab_destinationIPTextBox.Enabled = false;
            this.filterTab_destinationIPTextBox.Lines = new string[0];
            this.filterTab_destinationIPTextBox.Location = new System.Drawing.Point(146, 15);
            this.filterTab_destinationIPTextBox.MaxLength = 32767;
            this.filterTab_destinationIPTextBox.Name = "filterTab_destinationIPTextBox";
            this.filterTab_destinationIPTextBox.PasswordChar = '\0';
            this.filterTab_destinationIPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_destinationIPTextBox.SelectedText = "";
            this.filterTab_destinationIPTextBox.SelectionLength = 0;
            this.filterTab_destinationIPTextBox.SelectionStart = 0;
            this.filterTab_destinationIPTextBox.ShortcutsEnabled = true;
            this.filterTab_destinationIPTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_destinationIPTextBox.TabIndex = 3;
            this.filterTab_destinationIPTextBox.UseSelectable = true;
            this.filterTab_destinationIPTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_destinationIPTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_destinationPortCheckBox
            // 
            this.filterTab_destinationPortCheckBox.AutoSize = true;
            this.filterTab_destinationPortCheckBox.Location = new System.Drawing.Point(276, 20);
            this.filterTab_destinationPortCheckBox.Name = "filterTab_destinationPortCheckBox";
            this.filterTab_destinationPortCheckBox.Size = new System.Drawing.Size(108, 15);
            this.filterTab_destinationPortCheckBox.TabIndex = 2;
            this.filterTab_destinationPortCheckBox.Text = "Destination port";
            this.filterTab_destinationPortCheckBox.UseSelectable = true;
            this.filterTab_destinationPortCheckBox.CheckedChanged += new System.EventHandler(this.destinationPortCheckBox_CheckedChanged);
            // 
            // filterTab_destinationIPCheckBox
            // 
            this.filterTab_destinationIPCheckBox.AutoSize = true;
            this.filterTab_destinationIPCheckBox.Location = new System.Drawing.Point(3, 20);
            this.filterTab_destinationIPCheckBox.Name = "filterTab_destinationIPCheckBox";
            this.filterTab_destinationIPCheckBox.Size = new System.Drawing.Size(126, 15);
            this.filterTab_destinationIPCheckBox.TabIndex = 2;
            this.filterTab_destinationIPCheckBox.Text = "Destination address";
            this.filterTab_destinationIPCheckBox.UseSelectable = true;
            this.filterTab_destinationIPCheckBox.CheckedChanged += new System.EventHandler(this.destinationIPCheckBox_CheckedChanged);
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.filterTab_maximumTextBox);
            this.metroPanel3.Controls.Add(this.filterTab_minimumTextBox);
            this.metroPanel3.Controls.Add(this.filterTab_maximumCheckBox);
            this.metroPanel3.Controls.Add(this.filterTab_minimumCheckBox);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 11;
            this.metroPanel3.Location = new System.Drawing.Point(0, 149);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(586, 53);
            this.metroPanel3.TabIndex = 5;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // filterTab_maximumTextBox
            // 
            // 
            // 
            // 
            this.filterTab_maximumTextBox.CustomButton.Image = null;
            this.filterTab_maximumTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_maximumTextBox.CustomButton.Name = "";
            this.filterTab_maximumTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_maximumTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_maximumTextBox.CustomButton.TabIndex = 1;
            this.filterTab_maximumTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_maximumTextBox.CustomButton.UseSelectable = true;
            this.filterTab_maximumTextBox.CustomButton.Visible = false;
            this.filterTab_maximumTextBox.Enabled = false;
            this.filterTab_maximumTextBox.Lines = new string[0];
            this.filterTab_maximumTextBox.Location = new System.Drawing.Point(419, 15);
            this.filterTab_maximumTextBox.MaxLength = 32767;
            this.filterTab_maximumTextBox.Name = "filterTab_maximumTextBox";
            this.filterTab_maximumTextBox.PasswordChar = '\0';
            this.filterTab_maximumTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_maximumTextBox.SelectedText = "";
            this.filterTab_maximumTextBox.SelectionLength = 0;
            this.filterTab_maximumTextBox.SelectionStart = 0;
            this.filterTab_maximumTextBox.ShortcutsEnabled = true;
            this.filterTab_maximumTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_maximumTextBox.TabIndex = 3;
            this.filterTab_maximumTextBox.UseSelectable = true;
            this.filterTab_maximumTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_maximumTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_minimumTextBox
            // 
            // 
            // 
            // 
            this.filterTab_minimumTextBox.CustomButton.Image = null;
            this.filterTab_minimumTextBox.CustomButton.Location = new System.Drawing.Point(66, 1);
            this.filterTab_minimumTextBox.CustomButton.Name = "";
            this.filterTab_minimumTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_minimumTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_minimumTextBox.CustomButton.TabIndex = 1;
            this.filterTab_minimumTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_minimumTextBox.CustomButton.UseSelectable = true;
            this.filterTab_minimumTextBox.CustomButton.Visible = false;
            this.filterTab_minimumTextBox.Enabled = false;
            this.filterTab_minimumTextBox.Lines = new string[0];
            this.filterTab_minimumTextBox.Location = new System.Drawing.Point(146, 15);
            this.filterTab_minimumTextBox.MaxLength = 32767;
            this.filterTab_minimumTextBox.Name = "filterTab_minimumTextBox";
            this.filterTab_minimumTextBox.PasswordChar = '\0';
            this.filterTab_minimumTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_minimumTextBox.SelectedText = "";
            this.filterTab_minimumTextBox.SelectionLength = 0;
            this.filterTab_minimumTextBox.SelectionStart = 0;
            this.filterTab_minimumTextBox.ShortcutsEnabled = true;
            this.filterTab_minimumTextBox.Size = new System.Drawing.Size(90, 25);
            this.filterTab_minimumTextBox.TabIndex = 3;
            this.filterTab_minimumTextBox.UseSelectable = true;
            this.filterTab_minimumTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_minimumTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_maximumCheckBox
            // 
            this.filterTab_maximumCheckBox.AutoSize = true;
            this.filterTab_maximumCheckBox.Location = new System.Drawing.Point(276, 20);
            this.filterTab_maximumCheckBox.Name = "filterTab_maximumCheckBox";
            this.filterTab_maximumCheckBox.Size = new System.Drawing.Size(114, 15);
            this.filterTab_maximumCheckBox.TabIndex = 2;
            this.filterTab_maximumCheckBox.Text = "Maximum length";
            this.filterTab_maximumCheckBox.UseSelectable = true;
            this.filterTab_maximumCheckBox.CheckedChanged += new System.EventHandler(this.maximumCheckBox_CheckedChanged);
            // 
            // filterTab_minimumCheckBox
            // 
            this.filterTab_minimumCheckBox.AutoSize = true;
            this.filterTab_minimumCheckBox.Location = new System.Drawing.Point(3, 20);
            this.filterTab_minimumCheckBox.Name = "filterTab_minimumCheckBox";
            this.filterTab_minimumCheckBox.Size = new System.Drawing.Size(113, 15);
            this.filterTab_minimumCheckBox.TabIndex = 2;
            this.filterTab_minimumCheckBox.Text = "Minimum length";
            this.filterTab_minimumCheckBox.UseSelectable = true;
            this.filterTab_minimumCheckBox.CheckedChanged += new System.EventHandler(this.minimumCheckBox_CheckedChanged);
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.filterTab_protocolComboBox);
            this.metroPanel4.Controls.Add(this.filterTab_protocolCheckBox);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 11;
            this.metroPanel4.Location = new System.Drawing.Point(0, 96);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(586, 53);
            this.metroPanel4.TabIndex = 6;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // filterTab_protocolComboBox
            // 
            this.filterTab_protocolComboBox.Enabled = false;
            this.filterTab_protocolComboBox.FormattingEnabled = true;
            this.filterTab_protocolComboBox.ItemHeight = 23;
            this.filterTab_protocolComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.filterTab_protocolComboBox.Location = new System.Drawing.Point(146, 12);
            this.filterTab_protocolComboBox.Name = "filterTab_protocolComboBox";
            this.filterTab_protocolComboBox.Size = new System.Drawing.Size(90, 29);
            this.filterTab_protocolComboBox.TabIndex = 3;
            this.filterTab_protocolComboBox.UseSelectable = true;
            // 
            // filterTab_protocolCheckBox
            // 
            this.filterTab_protocolCheckBox.AutoSize = true;
            this.filterTab_protocolCheckBox.Location = new System.Drawing.Point(3, 20);
            this.filterTab_protocolCheckBox.Name = "filterTab_protocolCheckBox";
            this.filterTab_protocolCheckBox.Size = new System.Drawing.Size(68, 15);
            this.filterTab_protocolCheckBox.TabIndex = 2;
            this.filterTab_protocolCheckBox.Text = "Protocol";
            this.filterTab_protocolCheckBox.UseSelectable = true;
            this.filterTab_protocolCheckBox.CheckedChanged += new System.EventHandler(this.protocolCheckBox_CheckedChanged);
            // 
            // metroPanel6
            // 
            this.metroPanel6.Controls.Add(this.filterTab_convertHexLabel);
            this.metroPanel6.Controls.Add(this.filterTab_convertToHexTextBox);
            this.metroPanel6.Controls.Add(this.filterTab_containBytesTextBox);
            this.metroPanel6.Controls.Add(this.filterTab_convertToHexButton);
            this.metroPanel6.Controls.Add(this.filterTab_containBytesCheckBox);
            this.metroPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 11;
            this.metroPanel6.Location = new System.Drawing.Point(0, 0);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(586, 96);
            this.metroPanel6.TabIndex = 7;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // filterTab_convertHexLabel
            // 
            this.filterTab_convertHexLabel.AutoSize = true;
            this.filterTab_convertHexLabel.Enabled = false;
            this.filterTab_convertHexLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.filterTab_convertHexLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.filterTab_convertHexLabel.Location = new System.Drawing.Point(20, 51);
            this.filterTab_convertHexLabel.Name = "filterTab_convertHexLabel";
            this.filterTab_convertHexLabel.Size = new System.Drawing.Size(96, 15);
            this.filterTab_convertHexLabel.TabIndex = 5;
            this.filterTab_convertHexLabel.Text = "Convert to string";
            // 
            // filterTab_convertToHexTextBox
            // 
            // 
            // 
            // 
            this.filterTab_convertToHexTextBox.CustomButton.Image = null;
            this.filterTab_convertToHexTextBox.CustomButton.Location = new System.Drawing.Point(243, 1);
            this.filterTab_convertToHexTextBox.CustomButton.Name = "";
            this.filterTab_convertToHexTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_convertToHexTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_convertToHexTextBox.CustomButton.TabIndex = 1;
            this.filterTab_convertToHexTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_convertToHexTextBox.CustomButton.UseSelectable = true;
            this.filterTab_convertToHexTextBox.CustomButton.Visible = false;
            this.filterTab_convertToHexTextBox.Enabled = false;
            this.filterTab_convertToHexTextBox.Lines = new string[0];
            this.filterTab_convertToHexTextBox.Location = new System.Drawing.Point(146, 47);
            this.filterTab_convertToHexTextBox.MaxLength = 32767;
            this.filterTab_convertToHexTextBox.Name = "filterTab_convertToHexTextBox";
            this.filterTab_convertToHexTextBox.PasswordChar = '\0';
            this.filterTab_convertToHexTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_convertToHexTextBox.SelectedText = "";
            this.filterTab_convertToHexTextBox.SelectionLength = 0;
            this.filterTab_convertToHexTextBox.SelectionStart = 0;
            this.filterTab_convertToHexTextBox.ShortcutsEnabled = true;
            this.filterTab_convertToHexTextBox.Size = new System.Drawing.Size(267, 25);
            this.filterTab_convertToHexTextBox.TabIndex = 3;
            this.filterTab_convertToHexTextBox.UseSelectable = true;
            this.filterTab_convertToHexTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_convertToHexTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_containBytesTextBox
            // 
            // 
            // 
            // 
            this.filterTab_containBytesTextBox.CustomButton.Image = null;
            this.filterTab_containBytesTextBox.CustomButton.Location = new System.Drawing.Point(339, 1);
            this.filterTab_containBytesTextBox.CustomButton.Name = "";
            this.filterTab_containBytesTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.filterTab_containBytesTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.filterTab_containBytesTextBox.CustomButton.TabIndex = 1;
            this.filterTab_containBytesTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.filterTab_containBytesTextBox.CustomButton.UseSelectable = true;
            this.filterTab_containBytesTextBox.CustomButton.Visible = false;
            this.filterTab_containBytesTextBox.Enabled = false;
            this.filterTab_containBytesTextBox.Lines = new string[0];
            this.filterTab_containBytesTextBox.Location = new System.Drawing.Point(146, 15);
            this.filterTab_containBytesTextBox.MaxLength = 32767;
            this.filterTab_containBytesTextBox.Name = "filterTab_containBytesTextBox";
            this.filterTab_containBytesTextBox.PasswordChar = '\0';
            this.filterTab_containBytesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterTab_containBytesTextBox.SelectedText = "";
            this.filterTab_containBytesTextBox.SelectionLength = 0;
            this.filterTab_containBytesTextBox.SelectionStart = 0;
            this.filterTab_containBytesTextBox.ShortcutsEnabled = true;
            this.filterTab_containBytesTextBox.Size = new System.Drawing.Size(363, 25);
            this.filterTab_containBytesTextBox.TabIndex = 3;
            this.filterTab_containBytesTextBox.UseSelectable = true;
            this.filterTab_containBytesTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.filterTab_containBytesTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // filterTab_convertToHexButton
            // 
            this.filterTab_convertToHexButton.Enabled = false;
            this.filterTab_convertToHexButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_convertToHexButton.Location = new System.Drawing.Point(419, 47);
            this.filterTab_convertToHexButton.Name = "filterTab_convertToHexButton";
            this.filterTab_convertToHexButton.Size = new System.Drawing.Size(90, 25);
            this.filterTab_convertToHexButton.TabIndex = 4;
            this.filterTab_convertToHexButton.Text = "Convert";
            this.filterTab_convertToHexButton.UseSelectable = true;
            this.filterTab_convertToHexButton.Click += new System.EventHandler(this.convertHexButton_Click);
            // 
            // filterTab_containBytesCheckBox
            // 
            this.filterTab_containBytesCheckBox.AutoSize = true;
            this.filterTab_containBytesCheckBox.Location = new System.Drawing.Point(3, 20);
            this.filterTab_containBytesCheckBox.Name = "filterTab_containBytesCheckBox";
            this.filterTab_containBytesCheckBox.Size = new System.Drawing.Size(96, 15);
            this.filterTab_containBytesCheckBox.TabIndex = 2;
            this.filterTab_containBytesCheckBox.Text = "Contain bytes";
            this.filterTab_containBytesCheckBox.UseSelectable = true;
            this.filterTab_containBytesCheckBox.CheckedChanged += new System.EventHandler(this.containBytesCheckBox_CheckedChanged);
            // 
            // filterTab_modifyButton
            // 
            this.filterTab_modifyButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_modifyButton.Location = new System.Drawing.Point(453, 363);
            this.filterTab_modifyButton.Name = "filterTab_modifyButton";
            this.filterTab_modifyButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_modifyButton.TabIndex = 13;
            this.filterTab_modifyButton.Text = "Modify";
            this.filterTab_modifyButton.UseSelectable = true;
            this.filterTab_modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // filterTab_cancelButton
            // 
            this.filterTab_cancelButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_cancelButton.Location = new System.Drawing.Point(453, 394);
            this.filterTab_cancelButton.Name = "filterTab_cancelButton";
            this.filterTab_cancelButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_cancelButton.TabIndex = 8;
            this.filterTab_cancelButton.Text = "Close";
            this.filterTab_cancelButton.UseSelectable = true;
            this.filterTab_cancelButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // filterTab_OKButton
            // 
            this.filterTab_OKButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_OKButton.Location = new System.Drawing.Point(372, 394);
            this.filterTab_OKButton.Name = "filterTab_OKButton";
            this.filterTab_OKButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_OKButton.TabIndex = 9;
            this.filterTab_OKButton.Text = "OK";
            this.filterTab_OKButton.UseSelectable = true;
            this.filterTab_OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // filterTab_deleteButton
            // 
            this.filterTab_deleteButton.Enabled = false;
            this.filterTab_deleteButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_deleteButton.Location = new System.Drawing.Point(534, 363);
            this.filterTab_deleteButton.Name = "filterTab_deleteButton";
            this.filterTab_deleteButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_deleteButton.TabIndex = 10;
            this.filterTab_deleteButton.Text = "Delete";
            this.filterTab_deleteButton.UseSelectable = true;
            this.filterTab_deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // filterTab_applyButton
            // 
            this.filterTab_applyButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_applyButton.Location = new System.Drawing.Point(534, 394);
            this.filterTab_applyButton.Name = "filterTab_applyButton";
            this.filterTab_applyButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_applyButton.TabIndex = 12;
            this.filterTab_applyButton.Text = "Apply";
            this.filterTab_applyButton.UseSelectable = true;
            this.filterTab_applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // filterTab_addButton
            // 
            this.filterTab_addButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.filterTab_addButton.Location = new System.Drawing.Point(372, 363);
            this.filterTab_addButton.Name = "filterTab_addButton";
            this.filterTab_addButton.Size = new System.Drawing.Size(75, 25);
            this.filterTab_addButton.TabIndex = 11;
            this.filterTab_addButton.Text = "Add";
            this.filterTab_addButton.UseSelectable = true;
            this.filterTab_addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // DECRYPT
            // 
            this.DECRYPT.Controls.Add(this.decryptTab_content);
            this.DECRYPT.Controls.Add(this.decryptTab_head);
            this.DECRYPT.Location = new System.Drawing.Point(4, 38);
            this.DECRYPT.Name = "DECRYPT";
            this.DECRYPT.Size = new System.Drawing.Size(623, 811);
            this.DECRYPT.TabIndex = 1;
            this.DECRYPT.Text = "Decrypt";
            // 
            // decryptTab_content
            // 
            this.decryptTab_content.Controls.Add(this.decryptTab_splitter);
            this.decryptTab_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decryptTab_content.HorizontalScrollbarBarColor = true;
            this.decryptTab_content.HorizontalScrollbarHighlightOnWheel = false;
            this.decryptTab_content.HorizontalScrollbarSize = 3;
            this.decryptTab_content.Location = new System.Drawing.Point(0, 106);
            this.decryptTab_content.Name = "decryptTab_content";
            this.decryptTab_content.Padding = new System.Windows.Forms.Padding(3);
            this.decryptTab_content.Size = new System.Drawing.Size(623, 705);
            this.decryptTab_content.TabIndex = 1;
            this.decryptTab_content.VerticalScrollbarBarColor = true;
            this.decryptTab_content.VerticalScrollbarHighlightOnWheel = false;
            this.decryptTab_content.VerticalScrollbarSize = 10;
            // 
            // decryptTab_splitter
            // 
            this.decryptTab_splitter.BackColor = System.Drawing.Color.White;
            this.decryptTab_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decryptTab_splitter.Location = new System.Drawing.Point(3, 3);
            this.decryptTab_splitter.Name = "decryptTab_splitter";
            this.decryptTab_splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // decryptTab_splitter.Panel1
            // 
            this.decryptTab_splitter.Panel1.Controls.Add(this.decryptTab_scriptLoad);
            this.decryptTab_splitter.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // decryptTab_splitter.Panel2
            // 
            this.decryptTab_splitter.Panel2.Controls.Add(this.decryptTab_scriptView);
            this.decryptTab_splitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.decryptTab_splitter.Size = new System.Drawing.Size(617, 699);
            this.decryptTab_splitter.SplitterDistance = 113;
            this.decryptTab_splitter.TabIndex = 0;
            // 
            // decryptTab_scriptLoad
            // 
            this.decryptTab_scriptLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decryptTab_scriptLoad.Controls.Add(this.decryptTab_applyButton);
            this.decryptTab_scriptLoad.Controls.Add(this.decryptTab_clearButton);
            this.decryptTab_scriptLoad.Controls.Add(this.decryptTab_browseButton);
            this.decryptTab_scriptLoad.Controls.Add(this.metroLabel1);
            this.decryptTab_scriptLoad.Controls.Add(this.decryptTab_pathTextBox);
            this.decryptTab_scriptLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decryptTab_scriptLoad.HorizontalScrollbarBarColor = true;
            this.decryptTab_scriptLoad.HorizontalScrollbarHighlightOnWheel = false;
            this.decryptTab_scriptLoad.HorizontalScrollbarSize = 11;
            this.decryptTab_scriptLoad.Location = new System.Drawing.Point(3, 3);
            this.decryptTab_scriptLoad.Name = "decryptTab_scriptLoad";
            this.decryptTab_scriptLoad.Padding = new System.Windows.Forms.Padding(3);
            this.decryptTab_scriptLoad.Size = new System.Drawing.Size(611, 107);
            this.decryptTab_scriptLoad.TabIndex = 0;
            this.decryptTab_scriptLoad.VerticalScrollbarBarColor = true;
            this.decryptTab_scriptLoad.VerticalScrollbarHighlightOnWheel = false;
            this.decryptTab_scriptLoad.VerticalScrollbarSize = 10;
            // 
            // decryptTab_applyButton
            // 
            this.decryptTab_applyButton.Location = new System.Drawing.Point(447, 38);
            this.decryptTab_applyButton.Name = "decryptTab_applyButton";
            this.decryptTab_applyButton.Size = new System.Drawing.Size(75, 25);
            this.decryptTab_applyButton.TabIndex = 4;
            this.decryptTab_applyButton.Text = "Apply";
            this.decryptTab_applyButton.UseSelectable = true;
            this.decryptTab_applyButton.Click += new System.EventHandler(this.applyPythonButton_Click);
            // 
            // decryptTab_clearButton
            // 
            this.decryptTab_clearButton.Location = new System.Drawing.Point(528, 38);
            this.decryptTab_clearButton.Name = "decryptTab_clearButton";
            this.decryptTab_clearButton.Size = new System.Drawing.Size(75, 25);
            this.decryptTab_clearButton.TabIndex = 4;
            this.decryptTab_clearButton.Text = "Clear";
            this.decryptTab_clearButton.UseSelectable = true;
            this.decryptTab_clearButton.Click += new System.EventHandler(this.decryptTab_clearButton_Click);
            // 
            // decryptTab_browseButton
            // 
            this.decryptTab_browseButton.Location = new System.Drawing.Point(528, 7);
            this.decryptTab_browseButton.Name = "decryptTab_browseButton";
            this.decryptTab_browseButton.Size = new System.Drawing.Size(75, 25);
            this.decryptTab_browseButton.TabIndex = 4;
            this.decryptTab_browseButton.Text = "Browse";
            this.decryptTab_browseButton.UseSelectable = true;
            this.decryptTab_browseButton.Click += new System.EventHandler(this.browsePythonButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(6, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(114, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Python script path";
            // 
            // decryptTab_pathTextBox
            // 
            // 
            // 
            // 
            this.decryptTab_pathTextBox.CustomButton.Image = null;
            this.decryptTab_pathTextBox.CustomButton.Location = new System.Drawing.Point(337, 1);
            this.decryptTab_pathTextBox.CustomButton.Name = "";
            this.decryptTab_pathTextBox.CustomButton.Size = new System.Drawing.Size(23, 25);
            this.decryptTab_pathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.decryptTab_pathTextBox.CustomButton.TabIndex = 1;
            this.decryptTab_pathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.decryptTab_pathTextBox.CustomButton.UseSelectable = true;
            this.decryptTab_pathTextBox.CustomButton.Visible = false;
            this.decryptTab_pathTextBox.Lines = new string[0];
            this.decryptTab_pathTextBox.Location = new System.Drawing.Point(161, 7);
            this.decryptTab_pathTextBox.MaxLength = 32767;
            this.decryptTab_pathTextBox.Name = "decryptTab_pathTextBox";
            this.decryptTab_pathTextBox.PasswordChar = '\0';
            this.decryptTab_pathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.decryptTab_pathTextBox.SelectedText = "";
            this.decryptTab_pathTextBox.SelectionLength = 0;
            this.decryptTab_pathTextBox.SelectionStart = 0;
            this.decryptTab_pathTextBox.ShortcutsEnabled = true;
            this.decryptTab_pathTextBox.Size = new System.Drawing.Size(361, 25);
            this.decryptTab_pathTextBox.TabIndex = 2;
            this.decryptTab_pathTextBox.UseSelectable = true;
            this.decryptTab_pathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.decryptTab_pathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // decryptTab_scriptView
            // 
            this.decryptTab_scriptView.Controls.Add(this.decryptTab_scriptTextBox);
            this.decryptTab_scriptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decryptTab_scriptView.HorizontalScrollbarBarColor = true;
            this.decryptTab_scriptView.HorizontalScrollbarHighlightOnWheel = false;
            this.decryptTab_scriptView.HorizontalScrollbarSize = 11;
            this.decryptTab_scriptView.Location = new System.Drawing.Point(3, 3);
            this.decryptTab_scriptView.Name = "decryptTab_scriptView";
            this.decryptTab_scriptView.Size = new System.Drawing.Size(611, 576);
            this.decryptTab_scriptView.TabIndex = 0;
            this.decryptTab_scriptView.VerticalScrollbarBarColor = true;
            this.decryptTab_scriptView.VerticalScrollbarHighlightOnWheel = false;
            this.decryptTab_scriptView.VerticalScrollbarSize = 10;
            // 
            // decryptTab_scriptTextBox
            // 
            // 
            // 
            // 
            this.decryptTab_scriptTextBox.CustomButton.Image = null;
            this.decryptTab_scriptTextBox.CustomButton.Location = new System.Drawing.Point(37, 2);
            this.decryptTab_scriptTextBox.CustomButton.Name = "";
            this.decryptTab_scriptTextBox.CustomButton.Size = new System.Drawing.Size(571, 571);
            this.decryptTab_scriptTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.decryptTab_scriptTextBox.CustomButton.TabIndex = 1;
            this.decryptTab_scriptTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.decryptTab_scriptTextBox.CustomButton.UseSelectable = true;
            this.decryptTab_scriptTextBox.CustomButton.Visible = false;
            this.decryptTab_scriptTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decryptTab_scriptTextBox.Lines = new string[0];
            this.decryptTab_scriptTextBox.Location = new System.Drawing.Point(0, 0);
            this.decryptTab_scriptTextBox.MaxLength = 32767;
            this.decryptTab_scriptTextBox.Multiline = true;
            this.decryptTab_scriptTextBox.Name = "decryptTab_scriptTextBox";
            this.decryptTab_scriptTextBox.PasswordChar = '\0';
            this.decryptTab_scriptTextBox.ReadOnly = true;
            this.decryptTab_scriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.decryptTab_scriptTextBox.SelectedText = "";
            this.decryptTab_scriptTextBox.SelectionLength = 0;
            this.decryptTab_scriptTextBox.SelectionStart = 0;
            this.decryptTab_scriptTextBox.ShortcutsEnabled = true;
            this.decryptTab_scriptTextBox.Size = new System.Drawing.Size(611, 576);
            this.decryptTab_scriptTextBox.TabIndex = 2;
            this.decryptTab_scriptTextBox.UseSelectable = true;
            this.decryptTab_scriptTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.decryptTab_scriptTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // decryptTab_head
            // 
            this.decryptTab_head.Controls.Add(this.decryptTab_descLabel);
            this.decryptTab_head.Controls.Add(this.decryptTab_nameLabel);
            this.decryptTab_head.Controls.Add(this.decryptTab_iconPython);
            this.decryptTab_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.decryptTab_head.HorizontalScrollbarBarColor = true;
            this.decryptTab_head.HorizontalScrollbarHighlightOnWheel = false;
            this.decryptTab_head.HorizontalScrollbarSize = 3;
            this.decryptTab_head.Location = new System.Drawing.Point(0, 0);
            this.decryptTab_head.Name = "decryptTab_head";
            this.decryptTab_head.Padding = new System.Windows.Forms.Padding(3, 3, 3, 16);
            this.decryptTab_head.Size = new System.Drawing.Size(623, 106);
            this.decryptTab_head.TabIndex = 0;
            this.decryptTab_head.VerticalScrollbarBarColor = true;
            this.decryptTab_head.VerticalScrollbarHighlightOnWheel = false;
            this.decryptTab_head.VerticalScrollbarSize = 10;
            // 
            // decryptTab_descLabel
            // 
            this.decryptTab_descLabel.AutoSize = true;
            this.decryptTab_descLabel.Location = new System.Drawing.Point(147, 53);
            this.decryptTab_descLabel.Name = "decryptTab_descLabel";
            this.decryptTab_descLabel.Size = new System.Drawing.Size(0, 0);
            this.decryptTab_descLabel.TabIndex = 2;
            // 
            // decryptTab_nameLabel
            // 
            this.decryptTab_nameLabel.AutoSize = true;
            this.decryptTab_nameLabel.Location = new System.Drawing.Point(147, 12);
            this.decryptTab_nameLabel.Name = "decryptTab_nameLabel";
            this.decryptTab_nameLabel.Size = new System.Drawing.Size(151, 19);
            this.decryptTab_nameLabel.TabIndex = 1;
            this.decryptTab_nameLabel.Text = "Python decryption script";
            // 
            // decryptTab_iconPython
            // 
            this.decryptTab_iconPython.ActiveControl = null;
            this.decryptTab_iconPython.AutoSize = true;
            this.decryptTab_iconPython.BackColor = System.Drawing.Color.Transparent;
            this.decryptTab_iconPython.ForeColor = System.Drawing.Color.Black;
            this.decryptTab_iconPython.Location = new System.Drawing.Point(13, 12);
            this.decryptTab_iconPython.Name = "decryptTab_iconPython";
            this.decryptTab_iconPython.Size = new System.Drawing.Size(64, 69);
            this.decryptTab_iconPython.TabIndex = 0;
            this.decryptTab_iconPython.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.decryptTab_iconPython.TileImage = ((System.Drawing.Image)(resources.GetObject("decryptTab_iconPython.TileImage")));
            this.decryptTab_iconPython.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.decryptTab_iconPython.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.decryptTab_iconPython.UseCustomBackColor = true;
            this.decryptTab_iconPython.UseCustomForeColor = true;
            this.decryptTab_iconPython.UseSelectable = true;
            this.decryptTab_iconPython.UseTileImage = true;
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 939);
            this.Controls.Add(this.MainForm_TabControl);
            this.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.Name = "FilterDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 65, 20, 22);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.OnLoad);
            this.MainForm_TabControl.ResumeLayout(false);
            this.FILTER.ResumeLayout(false);
            this.filterTab_top.ResumeLayout(false);
            this.filterTab_top.PerformLayout();
            this.filterTab_content.ResumeLayout(false);
            this.filterTab_splitter.Panel1.ResumeLayout(false);
            this.filterTab_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterTab_splitter)).EndInit();
            this.filterTab_splitter.ResumeLayout(false);
            this.filterTab_wrapView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterTab_filterView)).EndInit();
            this.filterTab_bottom.ResumeLayout(false);
            this.filterTab_setting.ResumeLayout(false);
            this.filterTab_settingPanel.ResumeLayout(false);
            this.filterTab_settingPanel.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel5.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.metroPanel6.ResumeLayout(false);
            this.metroPanel6.PerformLayout();
            this.DECRYPT.ResumeLayout(false);
            this.decryptTab_content.ResumeLayout(false);
            this.decryptTab_splitter.Panel1.ResumeLayout(false);
            this.decryptTab_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.decryptTab_splitter)).EndInit();
            this.decryptTab_splitter.ResumeLayout(false);
            this.decryptTab_scriptLoad.ResumeLayout(false);
            this.decryptTab_scriptLoad.PerformLayout();
            this.decryptTab_scriptView.ResumeLayout(false);
            this.decryptTab_head.ResumeLayout(false);
            this.decryptTab_head.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl MainForm_TabControl;
        private System.Windows.Forms.TabPage FILTER;
        private System.Windows.Forms.TabPage DECRYPT;
        private MetroFramework.Controls.MetroPanel decryptTab_head;
        private MetroFramework.Controls.MetroLabel decryptTab_nameLabel;
        private MetroFramework.Controls.MetroTile decryptTab_iconPython;
        private MetroFramework.Controls.MetroPanel filterTab_content;
        private System.Windows.Forms.SplitContainer filterTab_splitter;
        private MetroFramework.Controls.MetroPanel filterTab_wrapView;
        private MetroFramework.Controls.MetroGrid filterTab_filterView;
        private MetroFramework.Controls.MetroPanel filterTab_bottom;
        private MetroFramework.Controls.MetroPanel filterTab_top;
        private MetroFramework.Controls.MetroLabel filterTab_nameLabel;
        private MetroFramework.Controls.MetroTile filterTab_icon;
        private MetroFramework.Controls.MetroPanel decryptTab_content;
        private System.Windows.Forms.SplitContainer decryptTab_splitter;
        private MetroFramework.Controls.MetroPanel decryptTab_scriptView;
        private MetroFramework.Controls.MetroTextBox decryptTab_scriptTextBox;
        private MetroFramework.Controls.MetroPanel decryptTab_scriptLoad;
        private MetroFramework.Controls.MetroButton decryptTab_applyButton;
        private MetroFramework.Controls.MetroButton decryptTab_clearButton;
        private MetroFramework.Controls.MetroButton decryptTab_browseButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox decryptTab_pathTextBox;
        private MetroFramework.Controls.MetroLabel decryptTab_descLabel;
        private MetroFramework.Controls.MetroPanel filterTab_setting;
        private MetroFramework.Controls.MetroButton filterTab_cancelButton;
        private MetroFramework.Controls.MetroButton filterTab_OKButton;
        private MetroFramework.Controls.MetroButton filterTab_deleteButton;
        private MetroFramework.Controls.MetroButton filterTab_applyButton;
        private MetroFramework.Controls.MetroButton filterTab_addButton;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroLabel filterTab_convertHexLabel;
        private MetroFramework.Controls.MetroTextBox filterTab_convertToHexTextBox;
        private MetroFramework.Controls.MetroTextBox filterTab_containBytesTextBox;
        private MetroFramework.Controls.MetroButton filterTab_convertToHexButton;
        private MetroFramework.Controls.MetroCheckBox filterTab_containBytesCheckBox;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroComboBox filterTab_protocolComboBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_protocolCheckBox;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroTextBox filterTab_maximumTextBox;
        private MetroFramework.Controls.MetroTextBox filterTab_minimumTextBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_maximumCheckBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_minimumCheckBox;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroTextBox filterTab_destinationPortTextBox;
        private MetroFramework.Controls.MetroTextBox filterTab_destinationIPTextBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_destinationPortCheckBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_destinationIPCheckBox;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox filterTab_sourcePortTextBox;
        private MetroFramework.Controls.MetroTextBox filterTab_sourceIPTextBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_sourcePortCheckBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_sourceIPCheckBox;
        private MetroFramework.Controls.MetroButton filterTab_modifyButton;
        private MetroFramework.Controls.MetroPanel filterTab_settingPanel;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroCheckBox filterTab_acceptAppLevelCheckBox;
        private MetroFramework.Controls.MetroCheckBox filterTab_validChecksumCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterview_checksum;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterview_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterView_containBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterView_protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterView_sizeRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterView_destinationIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterView_sourceIP;
    }
}