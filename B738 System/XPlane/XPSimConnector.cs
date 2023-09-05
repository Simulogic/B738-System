using XPlaneConnector;

namespace B738_System.XPlane
{
    public class XPSimConnector : ISimConnector
    {
        private XPlaneConnector.XPlaneConnector _connector;
        internal static Dictionary<string, string> _simData = new Dictionary<string, string>();

        public Dictionary<string, string> SimData { get => _simData; }

        public void Connect()
        {
            _connector = new XPlaneConnector.XPlaneConnector();
            _connector.Start();
        }

        public void Disconnect()
        {
            _connector.Stop();
        }

        public void RegisterData()
        {
            XPCDUData.RegisterData(_connector);
        }
    }
}
