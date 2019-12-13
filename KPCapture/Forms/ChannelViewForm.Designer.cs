namespace KPU.Forms
{
    partial class ChannelViewForm
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
            this.top = new MetroFramework.Controls.MetroPanel();
            this.bottom = new MetroFramework.Controls.MetroPanel();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.addButton = new MetroFramework.Controls.MetroButton();
            this.channelListView = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.top.SuspendLayout();
            this.bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Controls.Add(this.bottom);
            this.top.Controls.Add(this.channelListView);
            this.top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top.HorizontalScrollbarBarColor = true;
            this.top.HorizontalScrollbarHighlightOnWheel = false;
            this.top.HorizontalScrollbarSize = 11;
            this.top.Location = new System.Drawing.Point(20, 65);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(628, 433);
            this.top.TabIndex = 1;
            this.top.VerticalScrollbarBarColor = true;
            this.top.VerticalScrollbarHighlightOnWheel = false;
            this.top.VerticalScrollbarSize = 10;
            // 
            // bottom
            // 
            this.bottom.Controls.Add(this.cancelButton);
            this.bottom.Controls.Add(this.addButton);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottom.HorizontalScrollbarBarColor = true;
            this.bottom.HorizontalScrollbarHighlightOnWheel = false;
            this.bottom.HorizontalScrollbarSize = 11;
            this.bottom.Location = new System.Drawing.Point(0, 375);
            this.bottom.Name = "bottom";
            this.bottom.Padding = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.bottom.Size = new System.Drawing.Size(628, 51);
            this.bottom.TabIndex = 3;
            this.bottom.VerticalScrollbarBarColor = true;
            this.bottom.VerticalScrollbarHighlightOnWheel = false;
            this.bottom.VerticalScrollbarSize = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.cancelButton.Location = new System.Drawing.Point(309, 14);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.addButton.Location = new System.Drawing.Point(228, 14);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "ADD";
            this.addButton.UseSelectable = true;
            this.addButton.Click += new System.EventHandler(this.AddChannel);
            // 
            // channelListView
            // 
            this.channelListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.channelListView.HideSelection = false;
            this.channelListView.LargeImageList = this.iconList;
            this.channelListView.Location = new System.Drawing.Point(0, 0);
            this.channelListView.Name = "channelListView";
            this.channelListView.Size = new System.Drawing.Size(628, 375);
            this.channelListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.channelListView.TabIndex = 0;
            this.channelListView.UseCompatibleStateImageBehavior = false;
            this.channelListView.SelectedIndexChanged += new System.EventHandler(this.ChangedSelection);
            this.channelListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);
            // 
            // iconList
            // 
            this.iconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList.ImageSize = new System.Drawing.Size(32, 32);
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChannelViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 520);
            this.Controls.Add(this.top);
            this.Font = new System.Drawing.Font("NEXON Football Gothic L", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.Name = "ChannelViewForm";
            this.Padding = new System.Windows.Forms.Padding(20, 65, 20, 22);
            this.ShowInTaskbar = false;
            this.Text = "Select Running Process";
            this.top.ResumeLayout(false);
            this.bottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel top;
        private System.Windows.Forms.ListView channelListView;
        private System.Windows.Forms.ImageList iconList;
        private MetroFramework.Controls.MetroButton addButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroPanel bottom;
    }
}