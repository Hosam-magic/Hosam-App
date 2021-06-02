using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.DTO
{
    public class ActionResult
    {
        public bool scucess;
        public string errorCode;
        public string erroroMsg;
        public object data;

        public ActionResult()
        {}

        public ActionResult(bool scucess)
        {
            this.scucess = scucess;
        }

        public ActionResult(bool scucess, object data)
        {
            this.scucess = scucess;
            this.data = data;
        }

        public ActionResult(bool scucess, string errorCode, string erroroMsg)
        {
            this.scucess = scucess;
            this.errorCode = errorCode;
            this.erroroMsg = erroroMsg;
        }

    }
}
