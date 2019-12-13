using KPU.Sources;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace KPU.Forms
{
    public partial class ChannelItem : UserControl
    {
        public enum ChannelButtonType
        {
            Run, Pause, Detail, Filter, Delete,
        }

        public delegate void ChannelButtonClickEvent(ChannelItem sender, ChannelButtonType type);

        private ChannelButtonClickEvent _buttonClickEvent;
        public ChannelButtonClickEvent ButtonClickEvent
        {
            get
            {
                return this._buttonClickEvent;
            }
            set
            {
                this._buttonClickEvent = value;
            }
        }

        private Channel _channel;
        public Channel Channel
        {
            get
            {
                return this._channel;
            }
            set
            {
                this._channel = value;
                if(this._channel == null)
                    return;

                this.icon.Image = this._channel.image(this.icon.Size);
                this.processNameLabel.Text = string.Format("{0}({1})", this._channel.Process.ProcessName, this._channel.Id);
            }
        }

        public MetroPanel Background
        {
            get
            {
                return this.background;
            }
        }

        public ChannelItem()
        {
            InitializeComponent();
        }

        public ChannelItem(Channel channel) : this()
        {
            this.Channel = channel;
        }

        public static implicit operator Channel(ChannelItem item)
        {
            return item.Channel;
        }

        public void Run()
        {
            this.Channel.Running = true;
            this.buttonRun.Text = "Pause";
        }

        public void Pause()
        {
            this.Channel.Running = false;
            this.buttonRun.Text = "Run";
        }

        public new void Update()
        {
            this.transmissionLabel.Invoke(new MethodInvoker(delegate ()
            {
                this.transmissionLabel.Text = string.Format("Transmission : {0}/{1} packets", this.Channel.FilteredNetworkPacket.Length, this.Channel.NetworkPackets.Length);
            }));
        }

        private void buttonRun_Click(object sender, System.EventArgs e)
        {
            this.Channel.Running = !this.Channel.Running;
            if(this.Channel.Running)
                this.buttonRun.Text = "Pause";
            else
                this.buttonRun.Text = "Run";
        }

        private void buttonView_Click(object sender, System.EventArgs e)
        {
            if(this._buttonClickEvent != null)
                this._buttonClickEvent.Invoke(this, ChannelButtonType.Detail);
        }

        private void buttonFilter_Click(object sender, System.EventArgs e)
        {
            if(this._buttonClickEvent != null)
                this._buttonClickEvent.Invoke(this, ChannelButtonType.Filter);
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            if(this._buttonClickEvent != null)
                this._buttonClickEvent.Invoke(this, ChannelButtonType.Delete);
        }
    }
}
