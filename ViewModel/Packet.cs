using KPCapture.ViewModel;

namespace KPCapture.Model.Protocol
{
    public partial class Packet
    {
        public class ViewModel : BaseViewModel
        {
            public Packet Data { get; private set; }

            public ViewModel(Packet packet)
            {
                this.Data = packet;
            }
        }
    }
}
