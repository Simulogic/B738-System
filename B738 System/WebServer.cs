using System.Net.Sockets;
using System.Net;
using System.Text;
using WatsonWebserver;
using System.Diagnostics;
using XPlaneConnector;
using B738_System.XPlane;

namespace B738_System
{
    public class WebServer
    {
        public Server server;
        public static ISimConnector simConnection;

        public WebServer()
        {
            server = new Server("127.0.0.1", 8420, false, DefaultRoute);

            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.POST, "/register/{moduleid}", RegisterModuleRoute);
            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.GET, "/CDU/{dataref}", GetCDUVariableRoute);

            server.Start();

            // Find a way to either detect the sim or set the sim
            if(true) // Xplane
            {
                simConnection = new XPSimConnector();
                simConnection.Connect();
                simConnection.RegisterData();
            }
            else // MSFS
            {

            }

        }

        static async Task GetCDUVariableRoute(HttpContext ctx)
        {
            var dataref = ctx.Request.Url.Parameters["dataref"];
            Debug.WriteLine("Returning CDU Variable " + simConnection.SimData[dataref]);
            await ctx.Response.Send(simConnection.SimData[dataref]); 
        }

        static async Task RegisterModuleRoute(HttpContext ctx)
        {
            var moduleid = ctx.Request.Url.Parameters["moduleid"];
            Debug.WriteLine("Registering Module with ID " + moduleid);
            await ctx.Response.Send(moduleid);
        }

        static async Task DefaultRoute(HttpContext ctx)
        {
            Debug.WriteLine("This route has not been implemented yet");
            await ctx.Response.Send("This route has not been implemented yet");
        }
    }
}
