using System.Net.Sockets;
using System.Net;
using System.Text;
using WatsonWebserver;
using System.Diagnostics;
using XPlaneConnector;

namespace B738_System
{
    public class WebServer
    {
        public Server server;
        public static XPlaneConnector.XPlaneConnector connector;

        public static Dictionary<string, string> data = new Dictionary<string, string>();

        public WebServer()
        {
            server = new Server("127.0.0.1", 8420, false, DefaultRoute);

            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.POST, "/register/{moduleid}", RegisterModuleRoute);
            server.Routes.Parameter.Add(WatsonWebserver.HttpMethod.GET, "/CDU/{dataref}", GetCDUVariableRoute);

            server.Start();

            connector = new XPlaneConnector.XPlaneConnector();

            RegisterCDUDataXplane();

            connector.Start();
        }

        public void RegisterCDUDataXplane()
        {
            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line_entry", Frequency = 5, StringLenght = 1 }, 5, (element, value) =>
            {
                data["line_entry"] = value;
            });

            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                data["line00_l"] = value;
            });

            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_G", Frequency = 5, StringLenght = 1 }, 5, (element, value) =>
            {
                data["line00_g"] = value;
            });
        }

        static async Task GetCDUVariableRoute(HttpContext ctx)
        {
            var dataref = ctx.Request.Url.Parameters["dataref"];
            Debug.WriteLine("Returning CDU Variable " + data[dataref]);
            await ctx.Response.Send(data[dataref]);
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
