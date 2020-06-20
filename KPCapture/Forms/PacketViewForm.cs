using KPU.Sources;
using MetroFramework.Forms;

namespace KPU.Forms
{
    public partial class PacketViewForm : MetroForm
    {
        public PacketViewForm(Packet packet)
        {
            InitializeComponent();
            var headerIP = packet.IPHeader;
            this.basicview.Rows.Add("version", headerIP.Version);
            this.basicview.Rows.Add("header length", headerIP.HeaderLength);
            this.basicview.Rows.Add("differential services", headerIP.DifferentialServices);
            this.basicview.Rows.Add("fragmentation offset", headerIP.FragmentationOffset);
            this.basicview.Rows.Add("time to live", headerIP.TTL);
            this.basicview.Rows.Add("protocol", headerIP.ProtocolType);
            this.basicview.Rows.Add("checksum", headerIP.Checksum);
            this.basicview.Rows.Add("source address", headerIP.SourceAddress);
            this.basicview.Rows.Add("destination address", headerIP.DestinationAddress);
            this.basicview.Rows.Add("total length", headerIP.TotalLength);
            this.basicview.Rows.Add("identification", headerIP.Identification);
            this.basicview.Rows.Add("bytes length", headerIP.Length);

            if (packet.Protocol == Protocol.TCP)
            {
                var headerTCP = packet.BaseHeader as TCPHeader;
                extendLabel.Text = "TCP HEADER";

                this.extendview.Rows.Add("source port", headerTCP.SourcePort);
                this.extendview.Rows.Add("destination port", headerTCP.DestinationPort);
                this.extendview.Rows.Add("sequence number", headerTCP.SequenceNumber);
                this.extendview.Rows.Add("acknowledgement number", headerTCP.AcknowledgementNumber);
                this.extendview.Rows.Add("header length", headerTCP.HeaderLength);
                this.extendview.Rows.Add("urgen pointer", headerTCP.UrgentPointer);
                this.extendview.Rows.Add("flags", headerTCP.Flags);
                this.extendview.Rows.Add("checksum", headerTCP.Checksum);
            }
            else
            {
                var headerUDP = packet.BaseHeader as UDPHeader;
                extendLabel.Text = "UDP HEADER";
                this.extendview.Rows.Add("source port", headerUDP.SourcePort);
                this.extendview.Rows.Add("destination port", headerUDP.DestinationPort);
                this.extendview.Rows.Add("checksum", headerUDP.Checksum);
            }
        }
    }
}
