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

        public static readonly SoftLogicErr unexceptErr = new SoftLogicErr("0101001", "unexcept err plz check log");
        public static readonly SoftLogicErr alreadyStart = new SoftLogicErr("0101002", "you already start");
        public static readonly SoftLogicErr needStart = new SoftLogicErr("0101003", "data list is null , you need to start first");

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
