using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlaneConnector;

namespace B738_System.XPlane
{
    public class XPCDUData
    {
        public static void RegisterData(XPlaneConnector.XPlaneConnector connector)
        {
            XPSimConnector._simData.Add("line_entry", "");
            XPSimConnector._simData.Add("line00_l", "");
            XPSimConnector._simData.Add("line00_g", "");
            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line_entry", Frequency = 5, StringLenght = 1 }, 5, (element, value) =>
            {
                XPSimConnector._simData["line_entry"] = value;
            });

            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                XPSimConnector._simData["line00_l"] = value;
            });

            connector.Subscribe(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_G", Frequency = 5, StringLenght = 1 }, 5, (element, value) =>
            {
                XPSimConnector._simData["line00_g"] = value;
            });
        }
    }
}
