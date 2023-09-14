using B738_System.MSFS;
using B738_System.XPlane;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;

namespace B738_System
{
    public partial class MainForm : Form
    {
        public SimConnection simConnection;
        public CDUData cduData;
        public SimFlightData simFlightData;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == MSFSConnector.WM_USER_SIMCONNECT)
            {
                ((MSFSConnector)simConnection).ReceiveSimConnectMessage();
            }

            base.WndProc(ref m);
        }

        private void ConnectXP_Button(object sender, EventArgs e)
        {
            simConnection = new XPConnector();
            simConnection.Connect();

            cduData = new XPCDU();
            cduData.RegisterData(simConnection);

            simConnection.RecvSimData += SimConnection_RecvSimData;
            simConnection.RecvSimUserData += SimConnection_RecvSimUserData;

            Connect();
        }

        private void ConnectMSFS_Button(object sender, EventArgs e)
        {
            simConnection = new MSFSConnector();
            simConnection.SetHandle(this.Handle);
            simConnection.Connect();

            cduData = new MSFSCDU();
            cduData.RegisterData(simConnection);

            simFlightData = new MSFSFlightData();
            simFlightData.RegisterData(simConnection);

            simConnection.RecvSimData += SimConnection_RecvSimData;
            simConnection.RecvSimUserData += SimConnection_RecvSimUserData;
            simConnection.RecvSimSystemData += SimConnection_RecvSimSystemData;


            Connect();
        }

        private void Connect()
        {
            XPConnectButton.Visible = false;
            MSFSConnectButton.Visible = false;
            DisconnectButton.Visible = true;
        }

        private void SimConnection_RecvSimData(object sender, RecvSimDataArgs e)
        {
            if(cduData.ProcessData(e))
            {
                // Send to modules
                UpdateCDUModule();
            }

            if(simFlightData.ProcessData(e))
            {
                // Send to modules
            }
        }

        private void SimConnection_RecvSimUserData(object sender, RecvSimDataArgs e)
        {
            if (simFlightData.ProcessUserData(e))
            {
                // Send to modules
                UpdateISFDModule();
            }
        }

        private void SimConnection_RecvSimSystemData(object sender, RecvSimDataArgs e)
        {
            if (simFlightData.ProcessSystemState(e))
            {
                // Send to modules
            }
        }

        #region TODO MOVE TO DATA HANDLER
        private async void UpdateISFDModule()
        {
            if (simFlightData is MSFSFlightData msfsData)
            {
                string isfdData = JsonConvert.SerializeObject(msfsData.GetISFDData());

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8430/update/isfd/");
                var collection = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("data", isfdData)
                };
                var content = new FormUrlEncodedContent(collection);
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async void UpdateCDUModule()
        {
            return;

            string leftCDUData = JsonConvert.SerializeObject(cduData.GetData(0));
            string rightCDUData = JsonConvert.SerializeObject(cduData.GetData(1));

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8430/update/cdu/left");
            var collection = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("data", leftCDUData)
            };
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Debug.WriteLine(await response.Content.ReadAsStringAsync());

            request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8430/update/cdu/right");
            collection = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("data", rightCDUData)
            };
            content = new FormUrlEncodedContent(collection);
            request.Content = content;
            response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Debug.WriteLine(await response.Content.ReadAsStringAsync());
        }
        #endregion

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            cduData = null;
            simConnection.Disconnect();

            XPConnectButton.Visible = true;
            MSFSConnectButton.Visible = true;

            DisconnectButton.Visible = false;
        }
    }
}
