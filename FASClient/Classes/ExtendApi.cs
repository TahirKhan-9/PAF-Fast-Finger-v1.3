using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FASClient
{
    class ExtendApi
    {
        [DllImport("FasExtend.dll")]
        public static extern int FasInitialize(string Fas, int PortNumber);
        [DllImport("FasExtend.dll")]
        public static extern int FasInitializeWithPassword(string Fas, int PortNumber, string Password);
        [DllImport("FasExtend.dll")]
        public static extern int FasTerminate();
        [DllImport("FasExtend.dll")]
        public static extern int FasSetFac(bool bFlag, byte FacID, string FacIP, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasSetGroup(bool bFlag, byte GroupID, string GroupName, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasAddFpUser( bool bSorC, byte FacID, int nTmlSize, byte[] pTemplate, string UserName,
                                             string UserID, byte GroupID, byte FingerID, byte UserType, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasDeleteUser(bool bSorC, byte FacID, string UserID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasChangeUserType(byte FacID, string UserID, byte UserType, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasSendUserFromFasToFac(byte FacID, string UserID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasIdentifyUser(string UserID, uint dwSize, byte[] pSample, byte[] RetID);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetFacRALToFas(byte FacID, bool bDelete, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetRALSize(short year, byte month, byte day, byte hour, byte minute, byte second, ref int nLength);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetRALData(byte[] buffer, bool bDelete);
        [DllImport("FasExtend.dll")]
        public static extern int FasDeleteRAL(bool bSorC, byte FacID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasSecurityLevel(bool bFlag, bool bSorC, byte FacID, ref byte SecurityLevel, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasAddDenialSetting(byte FacID, bool bFlag, byte GroupID, string UserID, 
									          byte month1, byte day1, byte weekday1, byte hour1, byte minute1,
                                              byte month2, byte day2, byte weekday2, byte hour2, byte minute2, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasEditDenialSetting(byte FacID, byte Action, byte Level, byte GroupID, string UserID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetSizeOfUserList(byte FacID, ref int nLength, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetUserList(byte[] buffer);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetFacUserToFas(byte FacID, byte GroupID, byte FingerID, string UserID, byte UserType, byte Delete, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetFasFpUserTemplate(string UserID, byte FingerID, ref int nTmlSize, byte[] pTemplate);
        [DllImport("FasExtend.dll")]
        public static extern int FasUnlockFac(byte FacID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasInitFac(byte FacID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasSyncTimeFac(byte FacID, byte byGetOrSetPeriod, ref byte byPeriodHour, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasAddPOU( bool bSorC, byte FacID, string UserName, string UserID,
                                    byte GroupID, string PIN, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasGetFacRALToFasByDayPeriods( byte FacID, short year1, byte month1, byte day1,
                                                short year2, byte month2, byte day2, bool bCheckDuplicate, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasDeleteRALByDayPeriods( bool bSorC, byte FacID, short year1, byte month1, byte day1,
                                                short year2, byte month2, byte day2, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasSetFS30Settings(byte Flag, byte FacID, byte SetType, byte Weekday, byte SetNumber,
                                     ref byte hour1, ref byte minute1, ref byte hour2, ref byte minute2, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasTurnOffFS30Alarm(byte FacID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasAddFS25UserFromFile( bool bSorC, byte FacID, string FileName, string UserName,
                                     string UserID, byte GroupID, bool bNewFacDefinition);
        [DllImport("FasExtend.dll")]
        public static extern int FasReloadPermission();
    }
    }
