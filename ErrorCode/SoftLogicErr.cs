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
