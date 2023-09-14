using System;
using XPlane;

namespace B738_System.XPlane
{
    public class XPConnector : SimConnection
    {
        // Xplane Connector
        private XPlaneConnector _connector;

        private bool _connecterConnected = false;
        private bool _connected = false;

        public override bool IsConnected => _connected;
        public override bool IsConnectorConnected => _connecterConnected;

        public XPlaneConnector Connector { get { return _connector; } }

        public override void Connect()
        {
            if(!IsConnectorConnected)
            {
                _connector = new XPlaneConnector();
                _connector.Start();
            }
        }

        public override void Disconnect()
        {
            _connector?.Stop();
            _connector = null;

            if (_connecterConnected || _connected)
            {
                _connecterConnected = false;
                _connected = false;
            }
        }

        public override void SetHandle(IntPtr handle)
        {
            // Not needed in XP
        }

        public override void OnRecvSimData(RecvSimDataArgs e)
        {
            base.OnRecvSimData(e);
        }

        public override void OnRecvSimUserData(RecvSimDataArgs e)
        {
            base.OnRecvSimUserData(e);
        }

        public override void OnRecvSimSystemData(RecvSimDataArgs e)
        {
            base.OnRecvSimSystemData(e);
        }
    }
}
