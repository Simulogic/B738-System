using Microsoft.FlightSimulator.SimConnect;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace B738_System.MSFS
{
    public class MSFSFlightData : SimFlightData
    {
        #region PMDG Data
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct NG3Data
        {
            #region Aft Overhead
            #region ADIRU
            public byte IRS_DisplaySelector; // Positions 0..4

            [MarshalAs(UnmanagedType.I1)]
            public bool IRS_SysDisplay_R;   // false: L,   true: R

            [MarshalAs(UnmanagedType.I1)]
            public bool IRS_annunGPS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] IRS_annunALIGN;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] IRS_annunON_DC;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] IRS_annunFAULT;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] IRS_annunFAIL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] IRS_ModeSelector; // 0: OFF  1: ALIGN  2: NAV  3: ATT

            [MarshalAs(UnmanagedType.I1)]
            public bool IRS_Aligned; // at least one IRU is aligned

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public char[] IRS_DisplayLeft; // Left display string, zero terminated

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] IRS_DisplayRight; // Right display string, zero terminated 

            [MarshalAs(UnmanagedType.I1)]
            public bool IRS_DisplayShowsDots; // True if the degrees and decimal dot symbols are shown on the IRS display
            #endregion

            #region AFS
            [MarshalAs(UnmanagedType.I1)]
            public bool AFS_AutothrottleServosConnected; // True if the autothrottle system is driving the thrust levers

            [MarshalAs(UnmanagedType.I1)]
            public bool AFS_ControlsPitch; // The autoflight system is actively controlling pitch

            [MarshalAs(UnmanagedType.I1)]
            public bool AFS_ControlsRoll; // The autoflight system is actively controlling roll
            #endregion

            #region PSEU
            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunPSEU;
            #endregion

            #region Service Interphone
            [MarshalAs(UnmanagedType.I1)]
            public bool COMM_ServiceInterphoneSw;
            #endregion

            #region Lights
            public byte LTS_DomeWhiteSw; // 0: DIM  1: OFF  2: BRIGHT
            #endregion

            #region Engine
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_EECSwitch;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_annunREVERSER;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_annunENGINE_CONTROL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_annunALTN;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_StartValve; // true: valve open
            #endregion

            #region Oxygen
            public byte OXY_Needle; // Position 0...240

            [MarshalAs(UnmanagedType.I1)]
            public bool OXY_SwNormal; // true: NORMAL  false: ON

            [MarshalAs(UnmanagedType.I1)]
            public bool OXY_annunPASS_OXY_ON;
            #endregion

            #region Gear
            [MarshalAs(UnmanagedType.I1)]
            public bool GEAR_annunOvhdLEFT;

            [MarshalAs(UnmanagedType.I1)]
            public bool GEAR_annunOvhdNOSE;

            [MarshalAs(UnmanagedType.I1)]
            public bool GEAR_annunOvhdRIGHT;
            #endregion

            #region Flight Recorder
            [MarshalAs(UnmanagedType.I1)]
            public bool FLTREC_SwNormal; // true: NORMAL  false: TEST

            [MarshalAs(UnmanagedType.I1)]
            public bool FLTREC_annunOFF;

            [MarshalAs(UnmanagedType.I1)]
            public bool CVR_annunTEST; // CVR TEST indicator
            #endregion
            #endregion

            #region Fwd Overhead
            #region Flight Controls
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FCTL_FltControl_Sw; // 0: STBY/RUD  1: OFF  2: ON

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FCTL_Spoiler_Sw; // true: ON  false: OFF

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_YawDamper_Sw;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_AltnFlaps_Sw_ARM; // true: ARM  false: OFF

            public byte FCTL_AltnFlaps_Control_Sw; // 0: UP  1: OFF  2: DOWN

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FCTL_annunFC_LOW_PRESSURE;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunYAW_DAMPER;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunLOW_QUANTITY;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunLOW_PRESSURE;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunLOW_STBY_RUD_ON;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunFEEL_DIFF_PRESS;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunSPEED_TRIM_FAIL;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunMACH_TRIM_FAIL;

            [MarshalAs(UnmanagedType.I1)]
            public bool FCTL_annunAUTO_SLAT_FAIL;
            #endregion

            #region Navigation/Displays
            public byte NAVDIS_VHFNavSelector; // 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2

            public byte NAVDIS_IRSSelector; // 0: BOTH ON L  1: NORMAL  2: BOTH ON R

            public byte NAVDIS_FMCSelector; // 0: BOTH ON L  1: NORMAL  2: BOTH ON R

            public byte NAVDIS_SourceSelector; // 0: ALL ON 1   1: AUTO    2: ALL ON 2

            public byte NAVDIS_ControlPaneSelector; // 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2

            public uint ADF_StandbyFrequency; // Standby frequency multiplied by 10
            #endregion

            #region Fuel
            public float FUEL_FuelTempNeedle;

            [MarshalAs(UnmanagedType.I1)]
            public bool FUEL_CrossFeedSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_PumpFwdSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_PumpAftSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_PumpCtrSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_AuxFwd;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_AuxAft;

            [MarshalAs(UnmanagedType.I1)]
            public bool FUEL_FWDBleed;

            [MarshalAs(UnmanagedType.I1)]
            public bool FUEL_AFTBleed;

            [MarshalAs(UnmanagedType.I1)]
            public bool FUEL_GNDXfr;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunENG_VALVE_CLOSED; // 0: Closed  1: Open  2: In transit (bright)

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunSPAR_VALVE_CLOSED; // 0: Closed  1: Open  2: In transit (bright)

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunFILTER_BYPASS;

            [MarshalAs(UnmanagedType.I1)]
            public bool FUEL_annunXFEED_VALVE_OPEN; // 0: Closed  1: Open  2: In transit (dim)

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunLOWPRESS_Fwd;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunLOWPRESS_Aft;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FUEL_annunLOWPRESS_Ctr;

            public float FUEL_QtyCenter; // LBS

            public float FUEL_QtyLeft; // LBS

            public float FUEL_QtyRight; // LBS
            #endregion

            #region Electrical
            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunBAT_DISCHARGE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunTR_UNIT;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunELEC;

            public byte ELEC_DCMeterSelector; // 0: STBY PWR  1: BAT BUS ... 7: TEST

            public byte ELEC_ACMeterSelector; // 0: STBY PWR  1: GND PWR ... 6: TEST

            public byte ELEC_BatSelector; // 0: OFF  1: BAT  2: ON

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_CabUtilSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_IFEPassSeatSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_annunDRIVE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunSTANDBY_POWER_OFF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_IDGDisconnectSw;

            public byte ELEC_StandbyPowerSelector; // 0: BAT  1: OFF  2: AUTO

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunGRD_POWER_AVAILABLE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_GrdPwrSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_BusTransSw_AUTO;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_GenSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_APUGenSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_annunTRANSFER_BUS_OFF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_annunSOURCE_OFF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ELEC_annunGEN_BUS_OFF;

            [MarshalAs(UnmanagedType.I1)]
            public bool ELEC_annunAPU_GEN_OFF_BUS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public char[] ELEC_MeterDisplayTop; // Top line of the display: 3 groups of 4 digits (or symbols) + terminating zero 

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public char[] ELEC_MeterDisplayBottom; // Bottom line of the display
                                                   // 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ELEC_BusPowered; // True if the corresponding bus is powered:
                                          // DC HOT BATT			0	
                                          // DC HOT BATT SWITCHED	1	
                                          // DC BATT BUS			2	
                                          // DC STANDBY BUS		3	
                                          // DC BUS 1				4	
                                          // DC BUS 2				5	
                                          // DC GROUND SVC		6
                                          // AC TRANSFER 1		7
                                          // AC TRANSFER 2		8
                                          // AC GROUND SVC 1		9
                                          // AC GROUND SVC 2		10
                                          // AC MAIN 1			11
                                          // AC MAIN 2			12
                                          // AC GALLEY 1			13
                                          // AC GALLEY 2			14
                                          // AC STANDBY			15
            #endregion

            #region APU
            public float APU_EGTNeedle;

            [MarshalAs(UnmanagedType.I1)]
            public bool APU_annunMAINT;

            [MarshalAs(UnmanagedType.I1)]
            public bool APU_annunLOW_OIL_PRESSURE;

            [MarshalAs(UnmanagedType.I1)]
            public bool APU_annunFAULT;

            [MarshalAs(UnmanagedType.I1)]
            public bool APU_annunOVERSPEED;
            #endregion

            #region Wipers
            public byte OH_WiperLSelector; // 0: PARK  1: INT  2: LOW  3:HIGH

            public byte OH_WiperRSelector; // 0: PARK  1: INT  2: LOW  3:HIGH
            #endregion

            #region Center Overhead control & indicators
            public byte LTS_CircuitBreakerKnob; // Position 0...150

            public byte LTS_OvereadPanelKnob; // Position 0...150

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_EquipCoolingSupplyNORM;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_EquipCoolingExhaustNORM;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunEquipCoolingSupplyOFF;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunEquipCoolingExhaustOFF;

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_annunEmerNOT_ARMED;

            public byte LTS_EmerExitSelector; // 0: OFF  1: ARMED  2: ON			

            public byte COMM_NoSmokingSelector; // 0: OFF  1: AUTO   2: ON

            public byte COMM_FastenBeltsSelector; // 0: OFF  1: AUTO   2: ON

            [MarshalAs(UnmanagedType.I1)]
            public bool COMM_annunCALL;

            [MarshalAs(UnmanagedType.I1)]
            public bool COMM_annunPA_IN_USE;
            #endregion

            #region Anti-ice
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ICE_annunOVERHEAT;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ICE_annunON;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ICE_WindowHeatSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunCAPT_PITOT;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunL_ELEV_PITOT;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunL_ALPHA_VANE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunL_TEMP_PROBE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunFO_PITOT;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunR_ELEV_PITOT;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunR_ALPHA_VANE;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_annunAUX_PITOT;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ICE_ProbeHeatSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ICE_annunVALVE_OPEN;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ICE_annunCOWL_ANTI_ICE;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ICE_annunCOWL_VALVE_OPEN;

            [MarshalAs(UnmanagedType.I1)]
            public bool ICE_WingAntiIceSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ICE_EngAntiIceSw;

            public int ICE_WindowHeatTestSw; // 0: OVHT  1: Neutral  2: PWR TEST
            #endregion

            #region Hydraulics
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HYD_annunLOW_PRESS_eng;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HYD_annunLOW_PRESS_elec;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HYD_annunOVERHEAT_elec;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HYD_PumpSw_eng;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HYD_PumpSw_elec;
            #endregion

            #region Air Systems
            public byte AIR_TempSourceSelector; // Positions 0..6

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_TrimAirSwitch;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] AIR_annunZoneTemp;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunDualBleed;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunRamDoorL;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunRamDoorR;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_RecircFanSwitch;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_PackSwitch; // 0=OFF  1=AUTO  2=HIGH

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_BleedAirSwitch;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_APUBleedAirSwitch;

            public byte AIR_IsolationValveSwitch; // 0=CLOSE  1=AUTO  2=OPEN

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_annunPackTripOff;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_annunWingBodyOverheat;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AIR_annunBleedTripOff;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunAUTO_FAIL;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunOFFSCHED_DESCENT;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunALTN;

            [MarshalAs(UnmanagedType.I1)]
            public bool AIR_annunMANUAL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public float[] AIR_DuctPress; // PSI

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public float[] AIR_DuctPressNeedle; // Value - PSI

            public float AIR_CabinAltNeedle; // Value - ft

            public float AIR_CabinDPNeedle; // Value - PSI

            public float AIR_CabinVSNeedle; // Value - ft/min

            public float AIR_CabinValveNeedle; // Value - 0 (closed) .. 1 (open)

            public float AIR_TemperatureNeedle; // Value - degrees C

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public char[] AIR_DisplayFltAlt; // Pressurization system FLT ALT window, zero terminated, can be blank or show dashes or show test pattern

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public char[] AIR_DisplayLandAlt; // Pressurization system LAND ALT window, zero terminated, can be blank or show dashes or show test pattern
            #endregion

            #region Doors
            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunFWD_ENTRY;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunFWD_SERVICE;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunAIRSTAIR;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunLEFT_FWD_OVERWING;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunRIGHT_FWD_OVERWING;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunFWD_CARGO;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunEQUIP;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunLEFT_AFT_OVERWING;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunRIGHT_AFT_OVERWING;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunAFT_CARGO;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunAFT_ENTRY;

            [MarshalAs(UnmanagedType.I1)]
            public bool DOOR_annunAFT_SERVICE;

            public uint AIR_FltAltWindow;// WARNING obsolete - use AIR_DisplayFltAlt instead

            public uint AIR_LandAltWindow; // WARNING obsolete - use AIR_DisplayLandAlt instead

            public uint AIR_OutflowValveSwitch; // 0=CLOSE  1=NEUTRAL  2=OPEN

            public uint AIR_PressurizationModeSelector; // 0=AUTO  1=ALTN  2=MAN
            #endregion

            #region Bottom Overhead
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_LandingLtRetractableSw; // 0: RETRACT  1: EXTEND  2: ON

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_LandingLtFixedSw;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_RunwayTurnoffSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_TaxiSw;

            public byte APU_Selector; // 0: OFF  1: ON  2: START

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ENG_StartSelector; // 0: GRD  1: OFF  2: CONT  3: FLT

            public byte ENG_IgnitionSelector; // 0: IGN L  1: BOTH  2: IGN R

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_LogoSw;

            public byte LTS_PositionSw; // 0: STEADY  1: OFF  2: STROBE&STEADY

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_AntiCollisionSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_WingSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool LTS_WheelWellSw;
            #endregion
            #endregion

            #region Glareshield
            #region Warnings
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] WARN_annunFIRE_WARN;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] WARN_annunMASTER_CAUTION;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunFLT_CONT;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunIRS;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunFUEL;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunELEC;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunAPU;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunOVHT_DET;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunANTI_ICE;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunHYD;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunDOORS;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunENG;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunOVERHEAD;

            [MarshalAs(UnmanagedType.I1)]
            public bool WARN_annunAIR_COND;
            #endregion

            #region EFIS
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_MinsSelBARO;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_BaroSelHPA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_VORADFSel1; // 0: VOR  1: OFF  2: ADF

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_VORADFSel2; // 0: VOR  1: OFF  2: ADF

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_ModeSel; // 0: APP  1: VOR  2: MAP  3: PLAn

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] EFIS_RangeSel; // 0: 5 ... 7: 640
            #endregion

            #region MCP
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public ushort[] MCP_Course;

            public float MCP_IASMach; // Mach if < 10.0

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_IASBlank;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_IASOverspeedFlash;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_IASUnderspeedFlash;

            public ushort MCP_Heading;

            public ushort MCP_Altitude;

            public short MCP_VertSpeed;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_VertSpeedBlank;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MCP_FDSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_ATArmSw;

            public byte MCP_BankLimitSel; // 0: 10 ... 4: 30

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_DisengageBar;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public int[] MCP_annunFD;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunATArm;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunN1;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunSPEED;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunVNAV;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunLVL_CHG;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunHDG_SEL;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunLNAV;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunVOR_LOC;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunAPP;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunALT_HOLD;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunVS;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunCMD_A;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunCWS_A;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunCMD_B;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_annunCWS_B;

            [MarshalAs(UnmanagedType.I1)]
            public bool MCP_indication_powered;
            #endregion
            #endregion

            #region MIP
            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_NoseWheelSteeringSwNORM;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunBELOW_GS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_MainPanelDUSel; // 0: OUTBD PFD ... 4 MFD for Capt; reverse sequence for FO

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_LowerDUSel; // 0: ENG PRI ... 2 ND for Capt; reverse sequence for FO

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunAP; // Red color. See MAIN_annunAP_Amber for amber color (added to the bottom of the struct)

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunAP_Amber; // Amber color

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunAT; // Red color. See MAIN_annunAT_Amber for amber color (added to the bottom of the struct)

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunAT_Amber; // Amber color

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_annunFMC;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MAIN_DisengageTestSelector; // 0: 1  1: OFF  2: 2

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunSPEEDBRAKE_ARMED;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunSPEEDBRAKE_DO_NOT_ARM;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunSPEEDBRAKE_EXTENDED;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunSTAB_OUT_OF_TRIM;

            public byte MAIN_LightsSelector; // 0: TEST  1: BRT  2: DIM

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_RMISelector1_VOR;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_RMISelector2_VOR;

            public byte MAIN_N1SetSelector; // 0: 2  1: 1  2: AUTO  3: BOTH

            public byte MAIN_SpdRefSelector; // 0: SET  1: AUTO  2: V1  3: VR  4: WT  5: VREF  6: Bug 

            public byte MAIN_FuelFlowSelector; // 0: RESET  1: RATE  2: USED

            public byte MAIN_AutobrakeSelector; // 0: RTO  1: OFF ... 5: MAX

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunANTI_SKID_INOP;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunAUTO_BRAKE_DISARM;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunLE_FLAPS_TRANSIT;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunLE_FLAPS_EXT;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public float[] MAIN_TEFlapsNeedle;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] MAIN_annunGEAR_transit;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] MAIN_annunGEAR_locked;

            public byte MAIN_GearLever; // 0: UP  1: OFF  2: DOWN

            public float MAIN_BrakePressNeedle;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunCABIN_ALTITUDE;

            [MarshalAs(UnmanagedType.I1)]
            public bool MAIN_annunTAKEOFF_CONFIG;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_AIII;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_NO_AIII;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_FLARE;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_RO;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_RO_CTN;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_RO_ARM;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_TO;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_TO_CTN;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_APCH;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_TO_WARN;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_Bar;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annun_FAIL;
            #endregion

            #region Knee Panels
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_MainPanelKnob;

            public byte LTS_BackgroundKnob;

            public byte LTS_AFDSFloodKnob;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_OutbdDUBrtKnob;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_InbdDUBrtKnob;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LTS_InbdDUMapBrtKnob;

            public byte LTS_UpperDUBrtKnob;

            public byte LTS_LowerDUBrtKnob;

            public byte LTS_LowerDUMapBrtKnob;

            [MarshalAs(UnmanagedType.I1)]
            public bool GPWS_annunINOP;

            [MarshalAs(UnmanagedType.I1)]
            public bool GPWS_FlapInhibitSw_NORM;

            [MarshalAs(UnmanagedType.I1)]
            public bool GPWS_GearInhibitSw_NORM;

            [MarshalAs(UnmanagedType.I1)]
            public bool GPWS_TerrInhibitSw_NORM;
            #endregion

            #region Control Stand
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_annunEXEC;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_annunCALL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_annunFAIL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_annunMSG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_annunOFST;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CDU_BrtKnob;

            public byte COMM_Attend_PressCount; // incremented with each button press
             
            public byte COMM_GrdCall_PressCount; // incremented with each button press

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] COMM_SelectedMic; // array: 0=capt, 1=F/O, 2=observer.
                                            // values: 0=VHF1  1=VHF2  2=VHF3  3=HF1  4=HF2  5=FLT  6=SVC  7=PA

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public uint[] COMM_ReceiverSwitches; // Bit flags for selector receivers (see ACP_SEL_RECV_VHF1 etc): [0]=Capt, [1]=FO, [2]=Overhead

            [MarshalAs(UnmanagedType.I1)]
            public bool TRIM_StabTrimMainElecSw_NORMAL;

            [MarshalAs(UnmanagedType.I1)]
            public bool TRIM_StabTrimAutoPilotSw_NORMAL;

            [MarshalAs(UnmanagedType.I1)]
            public bool PED_annunParkingBrake;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FIRE_OvhtDetSw; // 0: A  1: NORMAL  2: B

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FIRE_annunENG_OVERHEAT;

            public byte FIRE_DetTestSw; // 0: FAULT/INOP  1: neutral  2: OVHT/FIRE

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FIRE_HandlePos; // 0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FIRE_HandleIlluminated;

            [MarshalAs(UnmanagedType.I1)]
            public bool FIRE_annunWHEEL_WELL;

            [MarshalAs(UnmanagedType.I1)]
            public bool FIRE_annunFAULT;

            [MarshalAs(UnmanagedType.I1)]
            public bool FIRE_annunAPU_DET_INOP;

            [MarshalAs(UnmanagedType.I1)]
            public bool FIRE_annunAPU_BOTTLE_DISCHARGE;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FIRE_annunBOTTLE_DISCHARGE;

            public byte FIRE_ExtinguisherTestSw; // 0: 1  1: neutral  2: 2

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FIRE_annunExtinguisherTest; // Left, Right, APU

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CARGO_annunExtTest; // Fwd, Aft

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CARGO_DetSelect; // 0: A  1: ORM  2: B

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] CARGO_ArmedSw;

            [MarshalAs(UnmanagedType.I1)]
            public bool CARGO_annunFWD;

            [MarshalAs(UnmanagedType.I1)]
            public bool CARGO_annunAFT;

            [MarshalAs(UnmanagedType.I1)]
            public bool CARGO_annunDETECTOR_FAULT;

            [MarshalAs(UnmanagedType.I1)]
            public bool CARGO_annunDISCH;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annunRWY;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annunGS;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annunFAULT;

            [MarshalAs(UnmanagedType.I1)]
            public bool HGS_annunCLR;

            [MarshalAs(UnmanagedType.I1)]
            public bool XPDR_XpndrSelector_2; // false: 1  true: 2

            [MarshalAs(UnmanagedType.I1)]
            public bool XPDR_AltSourceSel_2; // false: 1  true: 2

            public byte XPDR_ModeSel; // 0: STBY  1: ALT RPTG OFF ... 4: TA/RA

            [MarshalAs(UnmanagedType.I1)]
            public bool XPDR_annunFAIL;

            public byte LTS_PedFloodKnob;

            public byte LTS_PedPanelKnob;

            [MarshalAs(UnmanagedType.I1)]
            public bool TRIM_StabTrimSw_NORMAL;

            [MarshalAs(UnmanagedType.I1)]
            public bool PED_annunLOCK_FAIL;

            [MarshalAs(UnmanagedType.I1)]
            public bool PED_annunAUTO_UNLK;

            public byte PED_FltDkDoorSel; // 0: UNLKD  1 AUTO pushed in  2: AUTO  3: DENY
            #endregion

            #region FMS
            public byte FMC_TakeoffFlaps;

            public byte FMC_V1;

            public byte FMC_VR;

            public byte FMC_V2;

            public byte FMC_LandingFlaps;

            public byte FMC_LandingVREF;

            public ushort FMC_CruiseAlt;

            public short FMC_LandingAltitude;

            public ushort FMC_TransitionAlt;

            public ushort FMC_TransitionLevel;

            [MarshalAs(UnmanagedType.I1)]
            public bool FMC_PerfInputComplete;

            public float FMC_DistanceToTOD;

            public float FMC_DistanceToDest;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
            public char[] FMC_flightNumber;
            #endregion

            /*#region Generic data
            public ushort AircraftModel;

            [MarshalAs(UnmanagedType.I1)]
            public bool WeightInKg;

            [MarshalAs(UnmanagedType.I1)]
            public bool GPWS_V1CallEnabled;

            [MarshalAs(UnmanagedType.I1)]
            public bool GroundConnAvailable;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            public byte[] reserved;
            #endregion*/
        }
        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ISFDData
        {
            public double heading;
            public double pitch;
            public double bankangle;
            public int IAS;
            public int pressurealt;
            public int NAV1LocDeflection;
            public float NAV1GSDeflection;
            public float KohlsmanSettingMB;
            public int stbyAppMode;
        }

        private enum DATA_DEFINITIONS
        {
            PMDG_NG3_CDU_0_ID = 0x4E473335,
            PMDG_NG3_CDU_1_ID = 0x4E473336,
            PMDG_NG3_CDU_0_DEFINITION = 0x4E473338,
            PMDG_NG3_CDU_1_DEFINITION = 0x4E473339,
            PMDG_NG3_DATA_ID = 0x4E473331,
            PMDG_NG3_DATA_DEFINITION = 0x4E473332,
            ISFD_DATA_DEFINITION = 0x5E470000
        }

        private enum DATA_REQUESTS : byte
        {
            CDU_REQUEST = 28,
            CDU2_REQUEST = 29,
            DATA_REQUEST = 30,
            ISFD_DATA_REQUEST = 31,
            SYSTEM_FLIGHT_PLAN = 32
        }

        private NG3Data _ng3Data;
        private ISFDData _isfdData;

        public MSFSFlightData() : base()
        {
            _ng3Data = new NG3Data();
            _isfdData = new ISFDData();
        }

        public override void RegisterData(object simConnection)
        {
            if (simConnection is MSFSConnector msfs)
            {
                msfs.SimConnect.MapClientDataNameToID("PMDG_NG3_Data", DATA_DEFINITIONS.PMDG_NG3_DATA_ID);
                msfs.SimConnect.AddToClientDataDefinition(DATA_DEFINITIONS.PMDG_NG3_DATA_DEFINITION, 0, (uint)Marshal.SizeOf<NG3Data>(), 0, 0);
                msfs.SimConnect.RegisterStruct<SIMCONNECT_RECV_CLIENT_DATA, NG3Data>(DATA_DEFINITIONS.PMDG_NG3_DATA_DEFINITION);
                msfs.SimConnect.RequestClientData(DATA_DEFINITIONS.PMDG_NG3_DATA_ID, DATA_REQUESTS.DATA_REQUEST, DATA_DEFINITIONS.PMDG_NG3_DATA_DEFINITION,
                    SIMCONNECT_CLIENT_DATA_PERIOD.VISUAL_FRAME, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0);

                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "PLANE HEADING DEGREES MAGNETIC", "Radians",
                    SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "ATTITUDE INDICATOR PITCH DEGREES", "Radians",
                    SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "ATTITUDE INDICATOR BANK DEGREES", "Radians",
                    SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "AIRSPEED INDICATED", "Knots",
                    SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "PRESSURE ALTITUDE", "Meters",
                    SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "HSI CDI NEEDLE", "Number",
                    SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "NAV GLIDE SLOPE ERROR", "Degrees",
                    SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                msfs.SimConnect.AddToDataDefinition(DATA_DEFINITIONS.ISFD_DATA_DEFINITION, "KOHLSMAN SETTING MB:1", "Millibars",
                    SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                msfs.SimConnect.RegisterDataDefineStruct<ISFDData>(DATA_DEFINITIONS.ISFD_DATA_DEFINITION);
                msfs.SimConnect.RequestDataOnSimObject(DATA_REQUESTS.ISFD_DATA_REQUEST, DATA_DEFINITIONS.ISFD_DATA_DEFINITION,
                    SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SIM_FRAME, SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT, 0, 0, 0);

                msfs.SimConnect.RequestSystemState(DATA_REQUESTS.SYSTEM_FLIGHT_PLAN, "FlightPlan");
            }
        }

        public override bool ProcessData(object data)
        {
            if (data is RecvSimDataArgs e)
            {
                if (e.data is SIMCONNECT_RECV_CLIENT_DATA clientData)
                {
                    if (clientData.dwRequestID == (uint)DATA_REQUESTS.DATA_REQUEST)
                    {
                        _ng3Data = (NG3Data)clientData.dwData[0];
                    }
                    return true;
                }
            }
            return false;
        }

        public override bool ProcessUserData(object data)
        {
            if (data is RecvSimDataArgs e)
            {
                if (e.data is SIMCONNECT_RECV_SIMOBJECT_DATA clientData)
                {
                    if (clientData.dwRequestID == (uint)DATA_REQUESTS.ISFD_DATA_REQUEST)
                    {
                        _isfdData = (ISFDData)clientData.dwData[0];
                    }
                    return true;
                }
            }
            return false;
        }

        public override bool ProcessSystemState(object data)
        {
            if (data is RecvSimDataArgs e)
            {
                if (e.data is SIMCONNECT_RECV_SYSTEM_STATE clientData)
                {
                    if(clientData.dwRequestID == (uint)DATA_REQUESTS.SYSTEM_FLIGHT_PLAN)
                    {
                        Debug.WriteLine(clientData.szString);
                    }

                    return true;
                }
            }

            return false;
        }

        public ISFDData GetISFDData()
        {
            return _isfdData;
        }

        public override void Disconnect()
        {

        }
    }
}
