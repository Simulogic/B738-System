using B738_System.MSFS;
using Newtonsoft.Json;
using RestSharp;
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
            Connect();
        }

        private void ConnectMSFS_Button(object sender, EventArgs e)
        {
            simConnection = new MSFSConnector();
            simConnection.SetHandle(this.Handle);
            simConnection.Connect();

            cduData = new MSFSCDU();
            cduData.RegisterData(simConnection);

            simConnection.RecvSimData += SimConnection_RecvSimData;

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
            if(cduData.ProcessData(e.data))
            {
                // Send to modules
                UpdateCDUModule();
            }
        }

        #region TODO MOVE TO DATA HANDLER
        private async void UpdateCDUModule()
        {
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
                new KeyValuePair<string, string>("data", leftCDUData)
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
