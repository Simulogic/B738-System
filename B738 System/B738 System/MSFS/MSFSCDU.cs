using Microsoft.FlightSimulator.SimConnect;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace B738_System.MSFS
{
    public class MSFSCDU : CDUData
    {
        #region Enums
        private enum DATA_DEFINITIONS
        {
            PMDG_NG3_CDU_0_ID = 0x4E473335,
            PMDG_NG3_CDU_1_ID = 0x4E473336,
            PMDG_NG3_CDU_0_DEFINITION = 0x4E473338,
            PMDG_NG3_CDU_1_DEFINITION = 0x4E473339,
            PMDG_NG3_DATA_ID = 0x4E473331,
            PMDG_NG3_DATA_DEFINITION = 0x4E473332
        }

        private enum DATA_REQUESTS : byte
        {
            CDU_REQUEST = 28,
            CDU2_REQUEST = 29,
            DATA_REQUEST
        }
        #endregion

        #region Data
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

        private Dictionary<uint, CDUCellData[,]> _cduData = new Dictionary<uint, CDUCellData[,]>();

        private bool _enableDebugPrinting = false;
        #endregion


        #region Constructor
        public MSFSCDU() : base()
        {
            _cduData.Add(0, new CDUCellData[Columns, Rows]);
            _cduData.Add(1, new CDUCellData[Columns, Rows]);
        }
        #endregion

        #region Public API
        public override CDUCellData[,] GetData(uint index)
        {
            if(_cduData.ContainsKey(index)) return _cduData[index];

            Debug.WriteLine("Shouldn't happen, break!");
            return null;
        }

        public override void RegisterData(object simConnection)
        {
            if (simConnection is MSFSConnector msfs)
            {
                msfs.SimConnect.MapClientDataNameToID("PMDG_NG3_CDU_0", DATA_DEFINITIONS.PMDG_NG3_CDU_0_ID);
                msfs.SimConnect.AddToClientDataDefinition(DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION, 0, (uint)Marshal.SizeOf<PMDG_CDU_SCREEN>(), 0, 0);
                msfs.SimConnect.RegisterStruct<SIMCONNECT_RECV_CLIENT_DATA, PMDG_CDU_SCREEN>(DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION);
                msfs.SimConnect.RequestClientData(DATA_DEFINITIONS.PMDG_NG3_CDU_0_ID, DATA_REQUESTS.CDU_REQUEST, DATA_DEFINITIONS.PMDG_NG3_CDU_0_DEFINITION,
                    SIMCONNECT_CLIENT_DATA_PERIOD.VISUAL_FRAME, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);

                msfs.SimConnect.MapClientDataNameToID("PMDG_NG3_CDU_1", DATA_DEFINITIONS.PMDG_NG3_CDU_1_ID);
                msfs.SimConnect.AddToClientDataDefinition(DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION, 0, (uint)Marshal.SizeOf<PMDG_CDU_SCREEN>(), 0, 0);
                msfs.SimConnect.RegisterStruct<SIMCONNECT_RECV_CLIENT_DATA, PMDG_CDU_SCREEN>(DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION);
                msfs.SimConnect.RequestClientData(DATA_DEFINITIONS.PMDG_NG3_CDU_1_ID, DATA_REQUESTS.CDU2_REQUEST, DATA_DEFINITIONS.PMDG_NG3_CDU_1_DEFINITION,
                    SIMCONNECT_CLIENT_DATA_PERIOD.VISUAL_FRAME, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);
            }
        }

        public override bool ProcessData(object data)
        {
            if (data is RecvSimDataArgs e)
            {
                if (e.data is SIMCONNECT_RECV_CLIENT_DATA clientData)
                {
                    if (clientData.dwRequestID == (uint)DATA_REQUESTS.CDU_REQUEST)
                    {
                        PMDG_CDU_SCREEN screen = (PMDG_CDU_SCREEN)clientData.dwData[0];
                        for (int i = 0; i < Columns; i++)
                        {
                            for (int j = 0; j < Rows; j++)
                            {
                                _cduData[0][i, j].S = screen.cduCols[i].cduRows[j].Symbol;
                                _cduData[0][i, j].C = screen.cduCols[i].cduRows[j].Color;
                                _cduData[0][i, j].F = screen.cduCols[i].cduRows[j].Flags;
                            }
                        }

                        if (_enableDebugPrinting)
                        {
                            string debugtext = "";
                            for (int i = 0; i < Rows; i++)
                            {
                                for (int j = 0; j < Columns; j++)
                                {
                                    debugtext += _cduData[0][j, i].S.ToString();
                                }
                                debugtext += "\n";
                            }

                            Debug.Print(debugtext);
                        }

                        return true;
                    }

                    if (clientData.dwRequestID == (uint)DATA_REQUESTS.CDU2_REQUEST)
                    {
                        PMDG_CDU_SCREEN screen = (PMDG_CDU_SCREEN)clientData.dwData[0];
                        for (int i = 0; i < Columns; i++)
                        {
                            for (int j = 0; j < Rows; j++)
                            {
                                _cduData[1][i, j].S = screen.cduCols[i].cduRows[j].Symbol;
                                _cduData[1][i, j].C = screen.cduCols[i].cduRows[j].Color;
                                _cduData[1][i, j].F = screen.cduCols[i].cduRows[j].Flags;
                            }
                        }

                        if (_enableDebugPrinting)
                        {
                            string debugtext = "";
                            for (int i = 0; i < Rows; i++)
                            {
                                for (int j = 0; j < Columns; j++)
                                {
                                    debugtext += _cduData[1][j, i].S.ToString();
                                }
                                debugtext += "\n";
                            }

                            Debug.Print(debugtext);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public override void Disconnect()
        {
            _cduData.Clear();
        }
        #endregion
    }
}
