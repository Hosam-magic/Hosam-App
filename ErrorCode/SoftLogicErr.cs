using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.ErrorCode
{
    class SoftLogicErr
    {
        private readonly string errorCode;
        private readonly string errorMsg;

        //通用錯誤
        public static readonly SoftLogicErr unexceptErr = new SoftLogicErr("0101001", "unexcept err plz check log");
        public static readonly SoftLogicErr pathNotFound = new SoftLogicErr("0101002", "system can't not found in this path");
        public static readonly SoftLogicErr detactMultipleGame = new SoftLogicErr("0101003", "detact multiple game running");

        //資料庫相關錯誤
        public static readonly SoftLogicErr dbException = new SoftLogicErr("0101020", "DB unexcept err");
        public static readonly SoftLogicErr dbNotFound = new SoftLogicErr("0101021", "can't find db file , need initialize");
        public static readonly SoftLogicErr nameAlreadyExist = new SoftLogicErr("0101022", "this name already in DB");
        public static readonly SoftLogicErr dataNotFound = new SoftLogicErr("0101023", "DB can't find this data");

        //副程式相關錯誤
        public static readonly SoftLogicErr alreadyStart = new SoftLogicErr("0101050", "sideproject already start");
        public static readonly SoftLogicErr notRunning = new SoftLogicErr("0101051", "sideproject isn't running");
        public static readonly SoftLogicErr noResponse = new SoftLogicErr("0101052", "sideproject no response");

        private SoftLogicErr(string errorCode, string errorMsg)
        {

            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
        }

        public string GetMsg()
        {
            return errorMsg;
        }

        public string GetCode()
        {
            return errorCode;
        }
    }
}
