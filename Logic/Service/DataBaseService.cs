using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Repository;

namespace Hosam_App.Logic.Service
{
    public class DataBaseService
    {
        public static string sqliteFolder = ConfigurationManager.AppSettings["SqliteDbFolder"];
        public static string sqliteDbFileName = ConfigurationManager.AppSettings["SqliteDbFileName"];
        public static string sqliteFullPath = sqliteFolder + sqliteDbFileName;

        public static ActionResult CheckDataComplete()
        {
            try
            {
                //檢查 db 資料夾是否存在
                if (!Directory.Exists(sqliteFolder))
                {
                    Directory.CreateDirectory(sqliteFolder);
                }

                //檢查是否有Table，沒有則建立
                UtilsRepository.CreateTableIfNotExists();

                //檢查基礎資料是否存在
                string[] supposeGameArray = new string[] { "AssettoCorsa", "eurotrucks2" };

                foreach (string supposeGame in supposeGameArray)
                {
                    UtilsRepository.InsertBaseDataIfNotExists(supposeGame);
                }

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }

        }


    }
}
