using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FASClient
{
    public enum ErrorCode : int
    {
        ERR_SUCCESS = 0,
        ERR_EMPTY_BASE = 1000,
        ERR_UNKNOWN_USER = 1001,
        ERR_CRC_ERROR = 1005,
        ERR_USER_SUSPENDED = 1016,
        ERR_USER_DENIED = 1030,
        ERR_INVALID_PWD = 1044,
        ERR_PWD_RETRIES_OVERLOAD = 1045,
        ERR_RECV_TIMEOUT = 2001,
        ERR_USER_ID_EXIST = 2002,
        ERR_USER_ID_NOT_EXIST = 2003,
        ERR_GROUP_ID_EXIST = 2004,
        ERR_GROUP_ID_NOT_EXIST = 2005,
        ERR_FAC_ID_EXIST = 2006,
        ERR_FAC_ID_NOT_EXIST = 2007,
        ERR_FAC_RAL_IS_EMPTY = 2008,
        ERR_RAL_IS_EMPTY = 2009,
        ERR_RAL_SIZE_NOT_DEFINE = 2010,
        ERR_INTERNAL_ERROR = 2011,
        ERR_CONNECT_TO_FAC_TIMEOUT = 2012,
        ERR_RECV_FROM_FAC_TIMEOUT = 2013,
        ERR_NO_MEMORY = 2014,
        ERR_LENGTH_IS_ZERO = 2015,
        ERR_DATA_NOT_ALIGNED = 2016,
        ERR_WINSOCK_ERROR = 2017,
        ERR_NO_USER_TEMPLATE = 2018,
        ERR_FAC_ACCESS_DENIED = 2019,
        ERR_INVALID_PARAM = 2020,
        ERR_FILE_NOT_EXIST = 2021,
        ERR_OPEN_FILE_ERROR = 2022,
        ERR_NO_FINGER_TEMPLATE = 2023,
        ERR_USERLIST_SIZE_NOT_DEFINE = 2030
    }
    class ExtendErr
    {
        public static string GetErrorMessage(int code)
        {
            string msg;

            switch (code)
            {
                case (int)ErrorCode.ERR_SUCCESS:
                    msg = "Requested Operation Done Successfully ...";
                    break;
                case (int)ErrorCode.ERR_CRC_ERROR:
                    msg = "Checksum error!";
                    break;
                case (int)ErrorCode.ERR_EMPTY_BASE:
                    msg = "No User Found in the Server";
                    break;
                case (int)ErrorCode.ERR_UNKNOWN_USER:
                    msg = "User unknown!";
                    break;
                case (int)ErrorCode.ERR_USER_SUSPENDED:
                    msg = "User is suspended!";
                    break;
                case (int)ErrorCode.ERR_USER_DENIED:
                    msg = "User is denied!";
                    break;
                case (int)ErrorCode.ERR_RECV_TIMEOUT:
                    msg = "Timeout Occured while Receiving Data from Server";
                    break;
                case (int)ErrorCode.ERR_USER_ID_EXIST:
                    msg = "User Already Exist";
                    break;
                case (int)ErrorCode.ERR_USER_ID_NOT_EXIST:
                    msg = "User ID does not exist!";
                    break;
                case (int)ErrorCode.ERR_GROUP_ID_EXIST:
                    msg = "Group Already Exist";
                    break;
                case (int)ErrorCode.ERR_GROUP_ID_NOT_EXIST:
                    msg = "Group ID does not exist!";
                    break;
                case (int)ErrorCode.ERR_FAC_ID_EXIST:
                    msg = "Device Already Exist";
                    break;
                case (int)ErrorCode.ERR_FAC_ID_NOT_EXIST:
                    msg = "Device Not Exist in Server";
                    break;
                case (int)ErrorCode.ERR_FAC_RAL_IS_EMPTY:
                    msg = "FAC RAL is empty!";
                    break;
                case (int)ErrorCode.ERR_RAL_IS_EMPTY:
                    msg = "FAS RAL is empty!";
                    break;
                case (int)ErrorCode.ERR_RAL_SIZE_NOT_DEFINE:
                    msg = "Unknown RAL data size!";
                    break;
                case (int)ErrorCode.ERR_INTERNAL_ERROR:
                    msg = "Internal Error Occured";
                    break;
                case (int)ErrorCode.ERR_CONNECT_TO_FAC_TIMEOUT:
                    msg = "Timeout Occured while Connecting to Device";
                    break;
                case (int)ErrorCode.ERR_RECV_FROM_FAC_TIMEOUT:
                    msg = "Timeout Occured while Receiving Data From Device";
                    break;
                case (int)ErrorCode.ERR_INVALID_PARAM:
                    msg = "Input parameter is invalid!";
                    break;
                case (int)ErrorCode.ERR_FILE_NOT_EXIST:
                    msg = "File name does not exist!";
                    break;
                case (int)ErrorCode.ERR_OPEN_FILE_ERROR:
                    msg = "Could not open file!";
                    break;
                case (int)ErrorCode.ERR_NO_MEMORY:
                    msg = "NoT Enough Memory!";
                    break;
                case (int)ErrorCode.ERR_LENGTH_IS_ZERO:
                    msg = "Data length is zero!";
                    break;
                case (int)ErrorCode.ERR_DATA_NOT_ALIGNED:
                    msg = "Data is not aligned!";
                    break;
                case (int)ErrorCode.ERR_WINSOCK_ERROR:
                    msg = "WinSock error!";
                    break;
                case (int)ErrorCode.ERR_NO_USER_TEMPLATE:
                    msg = "User template is empty!";
                    break;
                case (int)ErrorCode.ERR_FAC_ACCESS_DENIED:
                    msg = "Access is denied by remote FAS!";
                    break;
                case (int)ErrorCode.ERR_NO_FINGER_TEMPLATE:
                    msg = "There is not such fingerprint template!";
                    break;
                case (int)ErrorCode.ERR_USERLIST_SIZE_NOT_DEFINE:
                    msg = "The size of user list is unknown!";
                    break;
                case (int)ErrorCode.ERR_INVALID_PWD:
                    msg = "Invalid Admin Password!";
                    break;
                case (int)ErrorCode.ERR_PWD_RETRIES_OVERLOAD:
                    msg = "Invalid Admin Password, and the retries over 5 times, you need to restart the FAS service!";
                    break;
                default:
                    msg = "Unknown Result!";
                    break;
            }
            return msg;
        }
    }
}
