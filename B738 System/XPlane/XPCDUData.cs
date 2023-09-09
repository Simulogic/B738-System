using XPlaneConnector;

namespace B738_System.XPlane
{
    public class XPCDUData : ICDUData
    {
        public static ICDUData.CDUCellData[,] _CDUData = new ICDUData.CDUCellData[ICDUData.Columns, ICDUData.Rows];
        public static ICDUData.CDUCellData[,] _CDUData1 = new ICDUData.CDUCellData[ICDUData.Columns, ICDUData.Rows];

        public ICDUData.CDUCellData[,] GetData(uint index)
        {
            if (index == 0)
                return _CDUData;
            else
                return _CDUData1;
        }

        public void RegisterData(object simconnection)
        {
            XPlaneConnector.XPlaneConnector connector = simconnection as XPlaneConnector.XPlaneConnector;

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Title
                for(int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 0].S = ' ';
                    else
                        _CDUData[i, 0].S = value[i];

                    _CDUData[i, 0].F = 0;
                    _CDUData[i, 0].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line00_S", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Page Index
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ') continue;

                    _CDUData[i, 0].S = value[i];
                    _CDUData[i, 0].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 0].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line01_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 1
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 1].S = ' ';
                    else
                        _CDUData[i, 1].S = value[i];
                    _CDUData[i, 1].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 1].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line01_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 1 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 2].S = ' ';
                    else
                        _CDUData[i, 2].S = value[i];
                    _CDUData[i, 2].F = 0;
                    _CDUData[i, 2].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line02_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 2
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 3].S = ' ';
                    else
                        _CDUData[i, 3].S = value[i];
                    _CDUData[i, 3].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 3].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line02_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 2 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 4].S = ' ';
                    else
                        _CDUData[i, 4].S = value[i];
                    _CDUData[i, 4].F = 0;
                    _CDUData[i, 4].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line03_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 3
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 5].S = ' ';
                    else
                        _CDUData[i, 5].S = value[i];
                    _CDUData[i, 5].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 5].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line03_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 3 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 6].S = ' ';
                    else
                        _CDUData[i, 6].S = value[i];
                    _CDUData[i, 6].F = 0;
                    _CDUData[i, 6].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line04_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 4
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 7].S = ' ';
                    else
                        _CDUData[i, 7].S = value[i];
                    _CDUData[i, 7].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 7].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line04_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 4 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 8].S = ' ';
                    else
                        _CDUData[i, 8].S = value[i];
                    _CDUData[i, 8].F = 0;
                    _CDUData[i, 8].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line05_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 5
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 9].S = ' ';
                    else
                        _CDUData[i, 9].S = value[i];
                    _CDUData[i, 9].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 9].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line05_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 5 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 10].S = ' ';
                    else
                        _CDUData[i, 10].S = value[i];
                    _CDUData[i, 10].F = 0;
                    _CDUData[i, 10].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line06_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 6
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 11].S = ' ';
                    else
                        _CDUData[i, 11].S = value[i];
                    _CDUData[i, 11].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData[i, 11].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line06_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 6 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 12].S = ' ';
                    else
                        _CDUData[i, 12].S = value[i];
                    _CDUData[i, 12].F = 0;
                    _CDUData[i, 12].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc1/Line_entry", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Entry Line
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData[i, 13].S = ' ';
                    else
                        _CDUData[i, 13].S = value[i];
                    _CDUData[i, 13].F = 0;
                    _CDUData[i, 13].C = (int)ICDUData.CDUCellColor.White;
                }

                /*string debugtext = "";
                for(int i = 0; i < ICDUData.Rows; i++)
                {
                    for(int j = 0; j < ICDUData.Columns; j++)
                    {
                        debugtext += _CDUData[j, i].S.ToString();
                    }
                    debugtext += "\n";
                }

                Debug.Print(debugtext);*/
            });


            // FO CDU

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line00_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Title
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 0].S = ' ';
                    else
                        _CDUData1[i, 0].S = value[i];

                    _CDUData1[i, 0].F = 0;
                    _CDUData1[i, 0].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line00_S", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Page Index
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ') continue;

                    _CDUData1[i, 0].S = value[i];
                    _CDUData1[i, 0].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 0].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line01_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 1
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 1].S = ' ';
                    else
                        _CDUData1[i, 1].S = value[i];
                    _CDUData1[i, 1].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 1].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line01_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 1 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 2].S = ' ';
                    else
                        _CDUData1[i, 2].S = value[i];
                    _CDUData1[i, 2].F = 0;
                    _CDUData1[i, 2].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line02_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 2
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 3].S = ' ';
                    else
                        _CDUData1[i, 3].S = value[i];
                    _CDUData1[i, 3].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 3].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line02_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 2 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 4].S = ' ';
                    else
                        _CDUData1[i, 4].S = value[i];
                    _CDUData1[i, 4].F = 0;
                    _CDUData1[i, 4].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line03_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 3
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 5].S = ' ';
                    else
                        _CDUData1[i, 5].S = value[i];
                    _CDUData1[i, 5].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 5].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line03_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 3 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 6].S = ' ';
                    else
                        _CDUData1[i, 6].S = value[i];
                    _CDUData1[i, 6].F = 0;
                    _CDUData1[i, 6].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line04_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 4
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 7].S = ' ';
                    else
                        _CDUData1[i, 7].S = value[i];
                    _CDUData1[i, 7].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 7].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line04_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 4 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 8].S = ' ';
                    else
                        _CDUData1[i, 8].S = value[i];
                    _CDUData1[i, 8].F = 0;
                    _CDUData1[i, 8].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line05_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 5
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 9].S = ' ';
                    else
                        _CDUData1[i, 9].S = value[i];
                    _CDUData1[i, 9].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 9].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line05_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 5 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 10].S = ' ';
                    else
                        _CDUData1[i, 10].S = value[i];
                    _CDUData1[i, 10].F = 0;
                    _CDUData1[i, 10].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line06_X", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 6
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 11].S = ' ';
                    else
                        _CDUData1[i, 11].S = value[i];
                    _CDUData1[i, 11].F = (int)ICDUData.CDUCellFlags.SmallFont;
                    _CDUData1[i, 11].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line06_L", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Line 6 Data
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 12].S = ' ';
                    else
                        _CDUData1[i, 12].S = value[i];
                    _CDUData1[i, 12].F = 0;
                    _CDUData1[i, 12].C = (int)ICDUData.CDUCellColor.White;
                }
            });

            connector.SubscribeString(new StringDataRefElement() { DataRef = "laminar/B738/fmc2/Line_entry", Frequency = 5, StringLenght = 24 }, 5, (element, value) =>
            {
                // Entry Line
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '°')
                        _CDUData1[i, 13].S = ' ';
                    else
                        _CDUData1[i, 13].S = value[i];
                    _CDUData1[i, 13].F = 0;
                    _CDUData1[i, 13].C = (int)ICDUData.CDUCellColor.White;
                }

                /*string debugtext = "";
                for(int i = 0; i < ICDUData.Rows; i++)
                {
                    for(int j = 0; j < ICDUData.Columns; j++)
                    {
                        debugtext += _CDUData[j, i].S.ToString();
                    }
                    debugtext += "\n";
                }

                Debug.Print(debugtext);*/
            });
        }
    }
}
