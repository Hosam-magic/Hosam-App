

using Dapper;
using Hosam_App.Logic.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Hosam_App.Logic.Repository
{
    class MotionSettingRepository
    {
        public static string sqliteFolder = ConfigurationManager.AppSettings["SqliteDbFolder"];
        public static string sqliteDbFileName = ConfigurationManager.AppSettings["SqliteDbFileName"];
        public static string sqliteDbString = ConfigurationManager.AppSettings["SqliteDbString"];
        public static string sqliteFullString = sqliteDbString+sqliteFolder + sqliteDbFileName;

        //儲存設定，並自動產生id
        public static void SaveSetting(MotionSetting motionSetting)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "INSERT into MotionSetting " +
                             "(id ,name , gobalStrength ,xStrength , yStrength , zStrength ) " +
                             "values (@id ,@name ,@gobalStrength ,@xStrength ,@yStrength ,@zStrength) ";

                //強制使用產生的 uuid 當做 id
                motionSetting.id = Guid.NewGuid().ToString();

                cnn.Execute(sql, new
                {
                    motionSetting.id,
                    motionSetting.name,
                    motionSetting.gobalStrength,
                    motionSetting.xStrength,
                    motionSetting.yStrength,
                    motionSetting.zStrength
                });
            }
        }

        //依照 id 找尋設定，如果 id 是 null 則回傳全部
        public static List<MotionSetting> GetSetting( string id )
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "select * from MotionSetting mt " +
                             "where (@id is null or id = @id) ";
                            
                return cnn.Query<MotionSetting>(sql , new{ id }).ToList();
            }
        }

        //依照 id 更新設定
        public static void UpdateSetting(MotionSetting motionSetting)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "UPDATE MotionSetting " +
                             "SET name = @name , gobalStrength = @gobalStrength , xStrength = @xStrength , yStrength = @yStrength , zStrength = @zStrength" +
                             "where id=@id ";

                cnn.Execute(sql, new
                {
                    motionSetting.id,
                    motionSetting.name,
                    motionSetting.gobalStrength,
                    motionSetting.xStrength,
                    motionSetting.yStrength,
                    motionSetting.zStrength
                });
            }
        }

        //依照 id 刪除設定
        public static void DeleteSetting(MotionSetting motionSetting)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "DELETE FROM MotionSetting " +
                             "where id=@id ";

                cnn.Execute(sql, new{motionSetting.id,});
            }
        }
    }
}
