using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace B738_System.MSFS
{
    public class MSSimConnector : ISimConnector
    {
        internal static Dictionary<string, string> _simData = new Dictionary<string, string>();

        public Dictionary<string, string> SimData { get => _simData; }
        private SimConnect _simconnect = null;

        public object Connection => _simconnect;

        private Thread _receiveDataThread;
        private CancellationTokenSource tokenSource = new();

        public void Connect()
        {
            try
            {
                _simconnect = new SimConnect("B738 System Data", 0, 0, null, 0);
                _simconnect.OnRecvOpen += Simconnect_OnRecvOpen;
                _simconnect.OnRecvQuit += Simconnect_OnRecvQuit;
            }
            catch (COMException e)
            {
                Debug.Print(e.ToString());
            }
        }

        private void Simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            tokenSource.Cancel();
            _receiveDataThread.Join();
            tokenSource.Dispose();
        }

        private void Simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Debug.Print("simconnect open");
        }

        public void Disconnect()
        {

        }

        public void RegisterData()
        {
            _receiveDataThread = new(() => ReceiveData(tokenSource.Token));
            _receiveDataThread.Start();
        }

        private void ReceiveData(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _simconnect.ReceiveMessage();
            }
        }
    }
}
