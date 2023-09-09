using System.Net.Sockets;
using System.Net;
using System.Text;
using WatsonWebserver;
using System.Diagnostics;
using XPlaneConnector;
using B738_System.XPlane;
using Newtonsoft.Json;
using B738_System.MSFS;

namespace B738_System
{
    public class WebServer
    {
        public Server server;
        public static ISimConnector simConnection;
        public static ICDUData cduData;

        public WebServer()
        {
            server = new Server("127.0.0.1", 8420, false, DefaultRoute);

            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.POST, "/register/{moduleid}", RegisterModuleRoute);
            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.GET, "/CDU/{index}", GetCDUDataRoute);

            server.Start();

            // Find a way to either detect the sim or set the sim
            if(true) // MSFS
            {
                simConnection = new MSSimConnector();
                cduData = new MSCDUData();
                
            }
            else // XPLANE
            {
                simConnection = new XPSimConnector();
                cduData = new XPCDUData();
            }

            cduData.RegisterData(simConnection.Connection);

            simConnection.Connect();
            simConnection.RegisterData();

        }

        static async Task GetCDUDataRoute(HttpContext ctx)
        {
            var index = ctx.Request.Url.Parameters["index"];
            string jsonString = JsonConvert.SerializeObject(cduData.GetData(Convert.ToUInt32(index)));
            //Debug.WriteLine("Returning CDU Data " + jsonString);
            await ctx.Response.Send(jsonString); 
        }

        static async Task RegisterModuleRoute(HttpContext ctx)
        {
            var moduleid = ctx.Request.Url.Parameters["moduleid"];
            Debug.WriteLine("Registering Module with ID " + moduleid);
            await ctx.Response.Send(moduleid);
        }

        static async Task DefaultRoute(HttpContext ctx)
        {
            //Debug.WriteLine("This route has not been implemented yet");
            await ctx.Response.Send("This route has not been implemented yet");
        }
    }
}
