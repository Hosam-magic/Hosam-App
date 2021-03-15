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

        //資料庫相關錯誤
        public static readonly SoftLogicErr dbException = new SoftLogicErr("0101020", "DB unexcept err");
        public static readonly SoftLogicErr nameAlreadyExist = new SoftLogicErr("0101021", "this name already in DB");
        public static readonly SoftLogicErr dataNotFound = new SoftLogicErr("0101022", "DB can't find this data");


        private SoftLogicErr(string errorCode, string errorMsg)
        {

            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
        }

        public string getMsg()
        {
            return errorMsg;
        }

        public string getCode()
        {
            return errorCode;
        }
    }
}
