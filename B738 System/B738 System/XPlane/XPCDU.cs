using System.Collections.Generic;
using XPlane;

namespace B738_System.XPlane
{
    internal class XPCDU : CDUData
    {
        #region Data
        private Dictionary<uint, CDUCellData[,]> _cduData = new Dictionary<uint, CDUCellData[,]>();
        #endregion

        #region Constructor
        public XPCDU()
        {
            _cduData.Add(0, new CDUCellData[Columns, Rows]);
            _cduData.Add(1, new CDUCellData[Columns, Rows]);
        }
        #endregion

        #region Public API
        public override CDUCellData[,] GetData(uint index)
        {
            return _cduData[index];
        }

        public override void RegisterData(object simConnection)
        {
            #region Data Subscriptions
            if (simConnection is XPConnector xp)
            {
                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Title
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDUTitle" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Title
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDUTitle" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_S", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Page Index
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDUPageIndex" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line00_S", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Page Index
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDUPageIndex" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line01_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 1
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine1" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line01_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 1
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine1" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line01_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 1 Data 
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine1Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line01_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 1 Data 
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine1Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line02_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 2
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine2" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line02_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 2
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine2" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line02_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 2 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine2Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line02_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 2 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine2Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line03_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 3
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine3" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line03_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 3
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine3" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line03_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 3 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine3Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line03_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 3 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine3Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line04_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 4
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine4" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line04_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 4
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine4" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line04_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 4 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine4Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line04_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 4 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine4Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line05_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 5
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine5" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line05_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 5
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine5" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line05_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 5 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine5Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line05_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 5 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine5Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line06_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 6
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine6" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line06_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 6
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine6" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line06_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Line 6 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDULine6Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line06_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Line 6 Data
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDULine6Data" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line_entry", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Left CDU Entry Line
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "LeftCDUEntryLine" });
                });

                xp.Connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line_entry", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
                {
                    // Right CDU Entry Line
                    xp.OnRecvSimData(new RecvSimDataArgs { data = value, dataid = "RightCDUEntryLine" });
                });
            }
            #endregion
        }

        public override bool ProcessData(object data)
        {
            if(data is RecvSimDataArgs e)
            {
                if(e.data is string dataString && e.dataid != string.Empty)
                {
                    switch(e.dataid)
                    {
                        #region Data Processing
                        case "LeftCDUTitle":
                            {
                                SetLine(cdu: 0, line: 0, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDUTitle":
                            {
                                SetLine(cdu: 1, line: 0, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDUPageIndex":
                            {
                                SetLine(cdu: 0, line: 0, dataString, CDUCellColor.White, CDUCellFlags.SmallFont, true);
                                break;
                            }

                        case "RightCDUPageIndex":
                            {
                                SetLine(cdu: 1, line: 0, dataString, CDUCellColor.White, CDUCellFlags.SmallFont, true);
                                break;
                            }

                        case "LeftCDULine1":
                            {
                                SetLine(cdu: 0, line: 1, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine1":
                            {
                                SetLine(cdu: 1, line: 1, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine1Data":
                            {
                                SetLine(cdu: 0, line: 2, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine1Data":
                            {
                                SetLine(cdu: 1, line: 2, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDULine2":
                            {
                                SetLine(cdu: 0, line: 3, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine2":
                            {
                                SetLine(cdu: 1, line: 3, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine2Data":
                            {
                                SetLine(cdu: 0, line: 4, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine2Data":
                            {
                                SetLine(cdu: 1, line: 4, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDULine3":
                            {
                                SetLine(cdu: 0, line: 5, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine3":
                            {
                                SetLine(cdu: 1, line: 5, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine3Data":
                            {
                                SetLine(cdu: 0, line: 6, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine3Data":
                            {
                                SetLine(cdu: 1, line: 6, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDULine4":
                            {
                                SetLine(cdu: 0, line: 7, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine4":
                            {
                                SetLine(cdu: 1, line: 7, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine4Data":
                            {
                                SetLine(cdu: 0, line: 8, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine4Data":
                            {
                                SetLine(cdu: 1, line: 8, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDULine5":
                            {
                                SetLine(cdu: 0, line: 9, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine5":
                            {
                                SetLine(cdu: 1, line: 9, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine5Data":
                            {
                                SetLine(cdu: 0, line: 10, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine5Data":
                            {
                                SetLine(cdu: 1, line: 10, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDULine6":
                            {
                                SetLine(cdu: 0, line: 11, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "RightCDULine6":
                            {
                                SetLine(cdu: 1, line: 11, dataString, CDUCellColor.White, CDUCellFlags.SmallFont);
                                break;
                            }

                        case "LeftCDULine6Data":
                            {
                                SetLine(cdu: 0, line: 12, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDULine6Data":
                            {
                                SetLine(cdu: 1, line: 12, dataString, CDUCellColor.White);
                                break;
                            }

                        case "LeftCDUEntryLine":
                            {
                                SetLine(cdu: 0, line: 13, dataString, CDUCellColor.White);
                                break;
                            }

                        case "RightCDUEntryLine":
                            {
                                SetLine(cdu: 1, line: 13, dataString, CDUCellColor.White);
                                break;
                            }
                        #endregion

                        default:
                            break;
                    }
                    return true;
                }
            }

            return false;
        }

        public override void Disconnect()
        {
            _cduData.Clear();
        }
        #endregion

        #region Private API
        public void SetLine(uint cdu, int line, string data, CDUCellColor color, CDUCellFlags flags = 0, bool skipSpace = false)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (skipSpace && data[i] == ' ') continue;

                _cduData[cdu][i, line].S = data[i];
                _cduData[cdu][i, line].F = (int)flags;
                _cduData[cdu][i, line].C = (int)color;
            }
        }
        #endregion

    }
}
