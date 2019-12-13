namespace KPU.Forms
{
    partial class PacketViewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketViewForm));
            this.contentsPanel = new MetroFramework.Controls.MetroPanel();
            this.extendPanel = new MetroFramework.Controls.MetroPanel();
            this.extendview = new MetroFramework.Controls.MetroGrid();
            this.extendview_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extendview_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extendLabel = new MetroFramework.Controls.MetroLabel();
            this.basicheadPanel = new MetroFramework.Controls.MetroPanel();
            this.basicview = new MetroFramework.Controls.MetroGrid();
            this.basicview_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basicview_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basicheadLabel = new MetroFramework.Controls.MetroLabel();
            this.contentsPanel.SuspendLayout();
            this.extendPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extendview)).BeginInit();
            this.basicheadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basicview)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.AutoScroll = true;
            this.contentsPanel.Controls.Add(this.extendPanel);
            this.contentsPanel.Controls.Add(this.basicheadPanel);
            this.contentsPanel.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.contentsPanel.HorizontalScrollbar = true;
            this.contentsPanel.HorizontalScrollbarBarColor = true;
            this.contentsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contentsPanel.HorizontalScrollbarSize = 11;
            this.contentsPanel.Location = new System.Drawing.Point(23, 68);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(754, 557);
            this.contentsPanel.TabIndex = 0;
            this.contentsPanel.VerticalScrollbar = true;
            this.contentsPanel.VerticalScrollbarBarColor = true;
            this.contentsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contentsPanel.VerticalScrollbarSize = 10;
            // 
            // extendPanel
            // 
            this.extendPanel.AutoSize = true;
            this.extendPanel.Controls.Add(this.extendview);
            this.extendPanel.Controls.Add(this.extendLabel);
            this.extendPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendPanel.HorizontalScrollbarBarColor = true;
            this.extendPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.extendPanel.HorizontalScrollbarSize = 11;
            this.extendPanel.Location = new System.Drawing.Point(0, 330);
            this.extendPanel.Name = "extendPanel";
            this.extendPanel.Padding = new System.Windows.Forms.Padding(0, 22, 0, 0);
            this.extendPanel.Size = new System.Drawing.Size(739, 287);
            this.extendPanel.TabIndex = 3;
            this.extendPanel.VerticalScrollbarBarColor = true;
            this.extendPanel.VerticalScrollbarHighlightOnWheel = false;
            this.extendPanel.VerticalScrollbarSize = 9;
            // 
            // extendview
            // 
            this.extendview.AllowUserToAddRows = false;
            this.extendview.AllowUserToDeleteRows = false;
            this.extendview.AllowUserToResizeRows = false;
            this.extendview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.extendview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.extendview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.extendview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extendview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.extendview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.extendview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.extendview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extendview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.extendview_name,
            this.extendview_value});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.extendview.DefaultCellStyle = dataGridViewCellStyle2;
            this.extendview.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendview.EnableHeadersVisualStyles = false;
            this.extendview.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.extendview.Location = new System.Drawing.Point(0, 49);
            this.extendview.Name = "extendview";
            this.extendview.ReadOnly = true;
            this.extendview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.extendview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.extendview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.extendview.RowTemplate.Height = 23;
            this.extendview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.extendview.Size = new System.Drawing.Size(739, 238);
            this.extendview.TabIndex = 3;
            // 
            // extendview_name
            // 
            this.extendview_name.HeaderText = "NAME";
            this.extendview_name.Name = "extendview_name";
            this.extendview_name.ReadOnly = true;
            // 
            // extendview_value
            // 
            this.extendview_value.HeaderText = "VALUE";
            this.extendview_value.Name = "extendview_value";
            this.extendview_value.ReadOnly = true;
            // 
            // extendLabel
            // 
            this.extendLabel.AutoSize = true;
            this.extendLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.extendLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.extendLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.extendLabel.Location = new System.Drawing.Point(0, 22);
            this.extendLabel.Name = "extendLabel";
            this.extendLabel.Size = new System.Drawing.Size(140, 25);
            this.extendLabel.TabIndex = 2;
            this.extendLabel.Text = "EXTEND LABEL";
            this.extendLabel.UseCustomForeColor = true;
            // 
            // basicheadPanel
            // 
            this.basicheadPanel.AutoSize = true;
            this.basicheadPanel.Controls.Add(this.basicview);
            this.basicheadPanel.Controls.Add(this.basicheadLabel);
            this.basicheadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.basicheadPanel.HorizontalScrollbarBarColor = true;
            this.basicheadPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.basicheadPanel.HorizontalScrollbarSize = 11;
            this.basicheadPanel.Location = new System.Drawing.Point(0, 0);
            this.basicheadPanel.Name = "basicheadPanel";
            this.basicheadPanel.Size = new System.Drawing.Size(739, 330);
            this.basicheadPanel.TabIndex = 2;
            this.basicheadPanel.VerticalScrollbarBarColor = true;
            this.basicheadPanel.VerticalScrollbarHighlightOnWheel = false;
            this.basicheadPanel.VerticalScrollbarSize = 10;
            // 
            // basicview
            // 
            this.basicview.AllowUserToAddRows = false;
            this.basicview.AllowUserToDeleteRows = false;
            this.basicview.AllowUserToResizeRows = false;
            this.basicview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.basicview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.basicview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.basicview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.basicview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.basicview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.basicview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.basicview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.basicview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.basicview_name,
            this.basicview_value});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.basicview.DefaultCellStyle = dataGridViewCellStyle5;
            this.basicview.Dock = System.Windows.Forms.DockStyle.Top;
            this.basicview.EnableHeadersVisualStyles = false;
            this.basicview.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.basicview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.basicview.Location = new System.Drawing.Point(0, 27);
            this.basicview.Name = "basicview";
            this.basicview.ReadOnly = true;
            this.basicview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.basicview.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.basicview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.basicview.RowTemplate.Height = 23;
            this.basicview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.basicview.Size = new System.Drawing.Size(739, 303);
            this.basicview.TabIndex = 3;
            // 
            // basicview_name
            // 
            this.basicview_name.HeaderText = "NAME";
            this.basicview_name.Name = "basicview_name";
            this.basicview_name.ReadOnly = true;
            // 
            // basicview_value
            // 
            this.basicview_value.HeaderText = "VALUE";
            this.basicview_value.Name = "basicview_value";
            this.basicview_value.ReadOnly = true;
            // 
            // basicheadLabel
            // 
            this.basicheadLabel.AutoSize = true;
            this.basicheadLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.basicheadLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.basicheadLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.basicheadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.basicheadLabel.Location = new System.Drawing.Point(0, 0);
            this.basicheadLabel.Name = "basicheadLabel";
            this.basicheadLabel.Size = new System.Drawing.Size(106, 25);
            this.basicheadLabel.TabIndex = 2;
            this.basicheadLabel.Text = "IP HEADER";
            this.basicheadLabel.UseCustomForeColor = true;
            // 
            // PacketViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.contentsPanel);
            this.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PacketViewForm";
            this.Padding = new System.Windows.Forms.Padding(20, 65, 20, 22);
            this.Resizable = false;
            this.Text = "PACKET VIEW";
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.extendPanel.ResumeLayout(false);
            this.extendPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extendview)).EndInit();
            this.basicheadPanel.ResumeLayout(false);
            this.basicheadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basicview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel contentsPanel;
        private MetroFramework.Controls.MetroPanel basicheadPanel;
        private MetroFramework.Controls.MetroLabel basicheadLabel;
        private MetroFramework.Controls.MetroGrid basicview;
        private System.Windows.Forms.DataGridViewTextBoxColumn basicview_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn basicview_value;
        private MetroFramework.Controls.MetroPanel extendPanel;
        private MetroFramework.Controls.MetroLabel extendLabel;
        private MetroFramework.Controls.MetroGrid extendview;
        private System.Windows.Forms.DataGridViewTextBoxColumn extendview_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn extendview_value;
    }
}