using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using KPU.Sources;
using KPU.Sources.Properties;

namespace KPU.Forms
{
    public partial class FilterDialog : MetroForm
    {
        public delegate void FilterEventDelegate(Channel channel, Filter[] filters);

        public FilterEventDelegate CallbackEvent { get; private set; }
        public Channel Channel { get; private set; }

        public Filter[] Filters
        {
            get
            {
                var list = new List<Filter>();
                foreach (DataGridViewRow row in this.filterTab_filterView.Rows)
                {
                    list.Add(row.Tag as Filter);
                }

                return list.ToArray();
            }
        }

        public FilterDialog(Channel channel, FilterEventDelegate callback)
        {
            InitializeComponent();

            this.Channel = channel;
            this.CallbackEvent = callback;
            this.filterTab_protocolComboBox.SelectedIndex = 0;

            this.filterTab_icon.TileImage = channel.image(new Size((int)(this.filterTab_icon.Width * 0.5), (int)(this.filterTab_icon.Height * 0.5)));
            this.filterTab_nameLabel.Text = string.Format("Process : {0}({1})", channel.Process.ProcessName, channel.Id);

            // Initialize decrypt tab
            this.UpdateDecryptTab();
        }

        private Filter Parse()
        {
            var filter = new Filter();


            if (this.filterTab_sourceIPCheckBox.Checked)
            {
                if (Regex.IsMatch(this.filterTab_sourceIPTextBox.Text, @"^\d{1,3}(\.\d{1,3}){3}$") == false || this.filterTab_sourceIPTextBox.Text.Split('.').SingleOrDefault(s => int.Parse(s) > 255) != null)
                    throw new FormatException("Source IP의 형식을 확인하세요");

                filter.SourceAddress = IPAddress.Parse(this.filterTab_sourceIPTextBox.Text);
            }

            if (this.filterTab_sourcePortCheckBox.Checked)
            {
                ushort temp = 0;
                if (ushort.TryParse(this.filterTab_sourcePortTextBox.Text, out temp) == true)
                    filter.SourcePort = temp;
                else
                    throw new StackOverflowException("Source port를 다시 입력하세요");
            }

            if (this.filterTab_destinationIPCheckBox.Checked)
            {
                if (Regex.IsMatch(this.filterTab_destinationIPTextBox.Text, @"^\d{1,3}(\.\d{1,3}){3}$") == false || this.filterTab_destinationIPTextBox.Text.Split('.').SingleOrDefault(s => int.Parse(s) > 255) != null)
                    throw new FormatException("Destination IP의 형식을 확인하세요");

                filter.DestinationAddress = IPAddress.Parse(this.filterTab_destinationIPTextBox.Text);
            }

            if (this.filterTab_destinationPortCheckBox.Checked)
            {
                ushort temp = 0;
                if (ushort.TryParse(this.filterTab_destinationPortTextBox.Text, out temp) == true)
                    filter.DestinationPort = temp;
                else
                    throw new OverflowException("Destination port를 다시 입력하세요");
            }

            if (this.filterTab_protocolCheckBox.Checked)
                filter.Protocol = (Protocol)Enum.Parse(typeof(Protocol), this.filterTab_protocolComboBox.Text);

            if (this.filterTab_minimumCheckBox.Checked)
            {
                uint temp = 0;
                if (uint.TryParse(this.filterTab_minimumTextBox.Text, out temp) == true)
                    filter.MininumLength = (int)temp;
                else
                    throw new OverflowException("Minimum length를 다시 입력하세요");
            }

            if (this.filterTab_maximumCheckBox.Checked)
            {
                uint temp = 0;
                if (uint.TryParse(this.filterTab_maximumTextBox.Text, out temp) == true)
                    filter.MaximumLength = (int)temp;
                else
                    throw new OverflowException("Maximum length를 다시 입력하세요");
            }

            if (this.filterTab_containBytesCheckBox.Checked)
            {
                var hexstrs = this.filterTab_containBytesTextBox.Text.Split(' ');
                var hexes = new byte[hexstrs.Length];
                for (var i = 0; i < hexstrs.Length; i++)
                {
                    if (hexstrs[i].Length != 2)
                        throw new Exception("Contain bytes의 형식이 잘못되었습니다. 다시 입력하세요.");

                    hexes[i] = Convert.ToByte(hexstrs[i], 16);
                }

                filter.SubBytes = hexes;
            }

            filter.OnlyValidChecksum = this.filterTab_validChecksumCheckBox.Checked;
            filter.OnlyAcceptAllicationLevel = this.filterTab_acceptAppLevelCheckBox.Checked;

            return filter;
        }

        private string[] FilterToCells(Filter filter)
        {
            return new string[] { string.Format("{0}:{1}", filter.SourceAddress != null ? filter.SourceAddress.ToString() : "None", filter.SourcePort != -1 ? filter.SourcePort.ToString() : "None"),
                                  string.Format("{0}:{1}", filter.DestinationAddress != null ? filter.DestinationAddress.ToString() : "None", filter.DestinationPort != -1 ? filter.DestinationPort.ToString() : "None"),
                                  string.Format("{0}~{1}", filter.MininumLength != -1 ? filter.MininumLength.ToString() : "None", filter.MaximumLength != -1 ? filter.MaximumLength.ToString() : "None"),
                                  filter.Protocol != Protocol.Unknown ? filter.Protocol.ToString() : "None",
                                  filter.SubBytes != null ? BitConverter.ToString(filter.SubBytes).Replace("-", " ") : "None",
                                  filter.OnlyValidChecksum ? "Only valid" : "None",
                                  filter.OnlyAcceptAllicationLevel ? "Application Level" : "None"};
        }

        private void AddFilter(Filter filter)
        {
            var index = this.filterTab_filterView.Rows.Add(this.FilterToCells(filter));
            this.filterTab_filterView.Rows[index].Tag = filter;
        }

        private bool Exists(Filter filter)
        {
            return this.Filters.Where(f => f.Equals(filter)).Count() != 0;
        }

        private void UpdateDecryptTab()
        {
            if (this.Channel.PythonScriptPath != null)
            {
                this.decryptTab_descLabel.Text = string.Format(Resources.DECRYPT_APPLIED_DESCRIPTION, Path.GetFileName(this.Channel.PythonScriptPath));
                this.decryptTab_scriptTextBox.Text = File.ReadAllText(this.Channel.PythonScriptPath);
                this.decryptTab_pathTextBox.Text = this.Channel.PythonScriptPath;
            }
            else
            {
                this.decryptTab_descLabel.Text = string.Empty;
                this.decryptTab_scriptTextBox.Text = string.Empty;
                this.decryptTab_pathTextBox.Text = string.Empty;
            }
        }

        private void sourceIPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_sourceIPTextBox.Enabled = this.filterTab_sourceIPCheckBox.Checked;
        }

        private void sourcePortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_sourcePortTextBox.Enabled = this.filterTab_sourcePortCheckBox.Checked;
        }

        private void destinationIPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_destinationIPTextBox.Enabled = this.filterTab_destinationIPCheckBox.Checked;
        }

        private void destinationPortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_destinationPortTextBox.Enabled = this.filterTab_destinationPortCheckBox.Checked;
        }

        private void protocolCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_protocolComboBox.Enabled = this.filterTab_protocolCheckBox.Checked;
        }

        private void minimumCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_minimumTextBox.Enabled = this.filterTab_minimumCheckBox.Checked;
        }

        private void maximumCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_maximumTextBox.Enabled = this.filterTab_maximumCheckBox.Checked;
        }

        private void containBytesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.filterTab_containBytesTextBox.Enabled = this.filterTab_containBytesCheckBox.Checked;
            this.filterTab_convertHexLabel.Enabled = this.filterTab_containBytesCheckBox.Checked;
            this.filterTab_convertToHexTextBox.Enabled = this.filterTab_containBytesCheckBox.Checked;
            this.filterTab_convertToHexButton.Enabled = this.filterTab_containBytesCheckBox.Checked;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = this.Parse();

                if (this.Exists(filter))
                    throw new Exception("필터를 추가할 수 없습니다. 추가하려는 필터가 이미 존재합니다.");

                this.AddFilter(filter);
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            foreach (var filter in this.Channel.Filters)
                this.AddFilter(filter);
        }

        private void convertHexButton_Click(object sender, EventArgs e)
        {
            var bytes = Encoding.UTF8.GetBytes(this.filterTab_convertToHexTextBox.Text);
            this.filterTab_containBytesTextBox.Text = BitConverter.ToString(bytes).Replace("-", " ");
            this.filterTab_convertToHexTextBox.Text = string.Empty;
        }

        private void metroFilterGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.filterTab_deleteButton.Enabled = (this.filterTab_filterView.SelectedRows.Count != 0);
            this.filterTab_modifyButton.Enabled = (this.filterTab_filterView.SelectedRows.Count != 0);

            if (this.filterTab_filterView.SelectedRows.Count != 0)
            {
                var filter = this.filterTab_filterView.SelectedRows[0].Tag as Filter;
                if (filter == null)
                    return;

                this.filterTab_sourceIPCheckBox.Checked = filter.SourceAddress != null;
                this.filterTab_sourceIPTextBox.Text = this.filterTab_sourceIPCheckBox.Checked ? filter.SourceAddress.ToString() : string.Empty;

                this.filterTab_sourcePortCheckBox.Checked = filter.SourcePort != -1;
                this.filterTab_sourcePortTextBox.Text = this.filterTab_sourcePortCheckBox.Checked ? filter.SourcePort.ToString() : string.Empty;

                this.filterTab_destinationIPCheckBox.Checked = filter.DestinationAddress != null;
                this.filterTab_destinationIPTextBox.Text = this.filterTab_destinationIPCheckBox.Checked ? filter.DestinationAddress.ToString() : string.Empty;

                this.filterTab_destinationPortCheckBox.Checked = filter.DestinationPort != -1;
                this.filterTab_destinationPortTextBox.Text = this.filterTab_destinationPortCheckBox.Checked ? filter.DestinationPort.ToString() : string.Empty;

                this.filterTab_minimumCheckBox.Checked = filter.MininumLength != -1;
                this.filterTab_minimumTextBox.Text = this.filterTab_minimumCheckBox.Checked ? filter.MininumLength.ToString() : string.Empty;

                this.filterTab_maximumCheckBox.Checked = filter.MaximumLength != -1;
                this.filterTab_maximumTextBox.Text = this.filterTab_maximumCheckBox.Checked ? filter.MaximumLength.ToString() : string.Empty;

                this.filterTab_protocolCheckBox.Checked = filter.Protocol != Protocol.Unknown;
                this.filterTab_protocolComboBox.SelectedText = this.filterTab_protocolCheckBox.Checked ? filter.Protocol.ToString() : string.Empty;

                this.filterTab_containBytesCheckBox.Checked = filter.SubBytes != null;
                this.filterTab_containBytesTextBox.Text = this.filterTab_containBytesCheckBox.Checked ? BitConverter.ToString(filter.SubBytes).Replace("-", " ") : string.Empty;

                this.filterTab_validChecksumCheckBox.Checked = filter.OnlyValidChecksum;
                this.filterTab_acceptAppLevelCheckBox.Checked = filter.OnlyAcceptAllicationLevel;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.filterTab_filterView.SelectedRows)
                this.filterTab_filterView.Rows.Remove(row);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (this.CallbackEvent != null)
                this.CallbackEvent(this.Channel, this.Filters);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (this.CallbackEvent != null)
                this.CallbackEvent(this.Channel, this.Filters);

            this.Close();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.filterTab_filterView.SelectedRows.Count == 0)
                    return;

                var selectedRow = this.filterTab_filterView.SelectedRows[0];
                var currentFilter = this.Parse();

                if (this.Exists(currentFilter))
                    throw new Exception("필터를 추가할 수 없습ㄴ다. 추가하려는 필터가 이미 존재합니다.");

                selectedRow.SetValues(this.FilterToCells(currentFilter));
                selectedRow.Tag = currentFilter;
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message);
            }
        }

        private void browsePythonButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select python script";
            dialog.Multiselect = false;
            dialog.DefaultExt = "py";
            dialog.Filter = "Python script file (*.py)|*.py";

            if (dialog.ShowDialog() == DialogResult.OK)
                this.decryptTab_pathTextBox.Text = dialog.FileName;
        }

        private void applyPythonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(this.decryptTab_pathTextBox.Text) == false)
                    throw new FileNotFoundException();

                var path = this.decryptTab_pathTextBox.Text;
                this.decryptTab_scriptTextBox.Text = File.ReadAllText(path);
                this.Channel.PythonScriptPath = path;

                this.UpdateDecryptTab();

                MetroMessageBox.Show(this, string.Format("'{0}' script has been applied successfully.", Path.GetFileName(path)), "Success");
            }
            catch (FileNotFoundException exc)
            {
                MetroMessageBox.Show(this, string.Format(Resources.NOT_FOUND_SCRIPT, exc.FileName), Resources.ERROR);
            }
            catch (System.MissingMemberException)
            {
                MetroMessageBox.Show(this, Resources.NOT_FOUND_DECRYPT_ROUTINE, Resources.ERROR);
            }
            catch (Microsoft.Scripting.SyntaxErrorException exc)
            {
                this.decryptTab_scriptTextBox.Select(exc.RawSpan.Start.Index, exc.RawSpan.Length);

                MetroMessageBox.Show(this, exc.Message + "\r\n" + 
                                    string.Format("File path : {0}\r\n", exc.SourcePath) + 
                                    string.Format(Resources.SYNTAX_ERROR, exc.Line, exc.Column, exc.ErrorCode), Resources.ERROR);
                this.decryptTab_scriptTextBox.Focus();
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message, Resources.ERROR);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void decryptTab_clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Channel.PythonScriptPath == null)
                    throw new Exception("There is no script file applied.");

                this.Channel.PythonScriptPath = null;
                this.UpdateDecryptTab();
                MetroMessageBox.Show(this, "Release successfully.", "Success");
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message, Resources.ERROR);
            }
        }
    }
}