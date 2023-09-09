using Microsoft.FlightSimulator.SimConnect;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace B738_System.MSFS
{
    public class MSCDUData : ICDUData
    {
        enum DATA_DEFINITIONS
        {
            PMDG_NG3_CDU_0_ID = 0x4E473335,
            PMDG_NG3_CDU_1_ID = 0x4E473336,
            PMDG_NG3_CDU_0_DEFINITION = 0x4E473338,
            PMDG_NG3_CDU_1_DEFINITION = 0x4E473339,
            PMDG_NG3_DATA_ID = 0x4E473331,
            PMDG_NG3_DATA_DEFINITION = 0x4E473332
        }

        enum DATA_REQUESTS : byte
        {
            CDU_REQUEST = 28,
            CDU2_REQUEST = 28,
            DATA_REQUEST
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct PMDG_CDU_CELL
        {
            public char Symbol;
            public char Color;
            public char Flags;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct PMDG_CDU_SCREEN
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
            public CDUROWS[] cduCols;

            [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
            public struct CDUROWS
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
                public PMDG_CDU_CELL[] cduRows;
            }

            [MarshalAs(UnmanagedType.I1)]
            public bool Powered;	// true if the CDU is powered
        }

        private static ICDUData.CDUCellData[,] _CDUData = new ICDUData.CDUCellData[ICDUData.Columns, ICDUData.Rows];
        private static ICDUData.CDUCellData[,] _CDUData1 = new ICDUData.CDUCellData[ICDUData.Columns, ICDUData.Rows];

        public void RegisterData(object simconnection)
        {
            SimConnect simconnect = simconnection as SimConnect;

            simconnect.MapClientDataNameToID("PMDG_NG3_CDU_0", DATA_DEFINITIONS.PMDG_NG3_CDU_0_ID);
            simconnect.AddToClientDataDefinition(DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION, 0, (uint)Marshal.SizeOf<PMDG_CDU_SCREEN>(), 0, 0);
            simconnect.RegisterStruct<SIMCONNECT_RECV_CLIENT_DATA, PMDG_CDU_SCREEN>(DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION);
            simconnect.RequestClientData(DATA_DEFINITIONS.PMDG_NG3_CDU_0_ID, DATA_REQUESTS.CDU_REQUEST, DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION,
                SIMCONNECT_CLIENT_DATA_PERIOD.VISUAL_FRAME, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);

            simconnect.MapClientDataNameToID("PMDG_NG3_CDU_1", DATA_DEFINITIONS.PMDG_NG3_CDU_1_ID);
            simconnect.AddToClientDataDefinition(DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION, 0, (uint)Marshal.SizeOf<PMDG_CDU_SCREEN>(), 0, 0);
            simconnect.RegisterStruct<SIMCONNECT_RECV_CLIENT_DATA, PMDG_CDU_SCREEN>(DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION);
            simconnect.RequestClientData(DATA_DEFINITIONS.PMDG_NG3_CDU_1_ID, DATA_REQUESTS.CDU2_REQUEST, DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION,
                SIMCONNECT_CLIENT_DATA_PERIOD.VISUAL_FRAME, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);

            simconnect.OnRecvClientData += Simconnect_OnRecvClientData;

        }

        private static void Simconnect_OnRecvClientData(SimConnect sender, SIMCONNECT_RECV_CLIENT_DATA data)
        {
            if (data.dwRequestID == (uint)DATA_REQUESTS.CDU_REQUEST)
            {
                PMDG_CDU_SCREEN screen = (PMDG_CDU_SCREEN)data.dwData[0];
                for (int i = 0; i < ICDUData.Columns; i++)
                {
                    for (int j = 0; j < ICDUData.Rows; j++)
                    {
                        _CDUData[i, j].S = screen.cduCols[i].cduRows[j].Symbol;
                        _CDUData[i, j].C = screen.cduCols[i].cduRows[j].Color;
                        _CDUData[i, j].F = screen.cduCols[i].cduRows[j].Flags;
                    }
                }

                /*string debugtext = "";
                for (int i = 0; i < ICDUData.Rows; i++)
                {
                    for (int j = 0; j < ICDUData.Columns; j++)
                    {
                        debugtext += _CDUData[j, i].S.ToString();
                    }
                    debugtext += "\n";
                }

                Debug.Print(debugtext);*/
            }

            if (data.dwRequestID == (uint)DATA_REQUESTS.CDU2_REQUEST)
            {
                PMDG_CDU_SCREEN screen = (PMDG_CDU_SCREEN)data.dwData[0];
                for (int i = 0; i < ICDUData.Columns; i++)
                {
                    for (int j = 0; j < ICDUData.Rows; j++)
                    {
                        _CDUData1[i, j].S = screen.cduCols[i].cduRows[j].Symbol;
                        _CDUData1[i, j].C = screen.cduCols[i].cduRows[j].Color;
                        _CDUData1[i, j].F = screen.cduCols[i].cduRows[j].Flags;
                    }
                }

                /*string debugtext = "";
                for (int i = 0; i < ICDUData.Rows; i++)
                {
                    for (int j = 0; j < ICDUData.Columns; j++)
                    {
                        debugtext += _CDUData1[j, i].S.ToString();
                    }
                    debugtext += "\n";
                }

                Debug.Print(debugtext);*/
            }
        }

        public ICDUData.CDUCellData[,] GetData(uint index)
        {
            if (index == 0)
                return _CDUData;
            else
                return _CDUData1;
        }
    }
}
