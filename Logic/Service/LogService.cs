using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Service
{
    class LogService
    {
        //Log目錄
        static string logPath = ConfigurationManager.AppSettings["LogFolder"] + DateTime.Now.ToString("yyyy-MM");
        public static void WriteLog(string msg)
        {
            //檔案名稱 使用現在日期
            String logFileName = DateTime.Now.ToString("yyyy-MM-dd")+".txt";

            //Log檔內的時間 使用現在時間
            String nowTime = DateTime.Now.ToString();

            if (!Directory.Exists(logPath))
            {
                //建立資料夾
                Directory.CreateDirectory(logPath);
            }

            if (!File.Exists(logPath + "/" + logFileName))
            {
                //建立檔案
                File.Create(logPath + "/" + logFileName).Close();
            }
            using (StreamWriter sw = File.AppendText(logPath + "/" + logFileName))
            {
                //WriteLine為換行 
                sw.Write(nowTime + "---->");
                sw.WriteLine(msg);
                sw.WriteLine("");
            }
        }
    }
}
