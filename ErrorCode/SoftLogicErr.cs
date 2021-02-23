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

        //全局變數相關錯誤
        public static readonly SoftLogicErr alreadyStart = new SoftLogicErr("0101020", "you already start");
        public static readonly SoftLogicErr needStart = new SoftLogicErr("0101021", "Gobal Variable list is null , you need to start first");
        public static readonly SoftLogicErr dataNotFound = new SoftLogicErr("0101022", "this data can't find in Gobal Variable");


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
