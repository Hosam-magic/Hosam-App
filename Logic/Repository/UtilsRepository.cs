using Dapper;
using Hosam_App.Logic.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Repository
{
    public class UtilsRepository
    {
        public static string sqliteFolder = ConfigurationManager.AppSettings["SqliteDbFolder"];
        public static string sqliteDbFileName = ConfigurationManager.AppSettings["SqliteDbFileName"];
        public static string sqliteDbString = ConfigurationManager.AppSettings["SqliteDbString"];

        public static string sqliteFullString = sqliteDbString + sqliteFolder + sqliteDbFileName;


        public static int CheckTableExists(string tableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "SELECT count () FROM sqlite_master " +
                            " WHERE type='table' and name=@tableName ";

                return cnn.ExecuteScalar<Int32>(sql, new { tableName });
            }
        }

        public static void CreateTableIfNotExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "Create Table if not exists GameData " +
                             "(id TEXT(36), " +
                             "gameName TEXT(30), " +
                             "'path' TEXT(50), " +
                             "configId TEXT(36), " +
                             "driverId TEXT(36), " +
                             "lastRunTime TEXT(40), " +
                             "isRunning INTEGER(1))";

                cnn.Execute(sql);

                string sql2 = "Create Table if not exists MotionSetting " +
                             "(id TEXT(36) PRIMARY KEY NOT NULL, " +
                             "name TEXT(30) NOT NULL UNIQUE, " +
                             "gobalStrength INTEGER (20), " +
                             "xStrength INTEGER(20), " +
                             "yStrength INTEGER(20), " +
                             "zStrength INTEGER(20)," +
                             "delayTime INTEGER(20) ) ";
                           
                cnn.Execute(sql2);
                cnn.Close();
            }
        }

        public static void InsertGameDataIfNotExists(string gameName)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "Insert Into GameData ( id , gameName , configId) " +
                             "Select @id,@gameName,0 " +
                             "Where Not Exists " +
                             "(Select * From GameData " +
                             "Where gameName = @gameName )";

                string id = Guid.NewGuid().ToString();

                cnn.Execute(sql, new { id, gameName });
                cnn.Close();
            }
        }

        public static void InsertMotionSettingIfNotExists(MotionSetting baseMotionSetting)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();

                string sql = "Insert Into MotionSetting " +
                              "( id , name , gobalStrength , xStrength , yStrength , zStrength , delayTime) " +
                             "Select 0 , @name ,@gobalStrength , @xStrength , @yStrength , @zStrength , @delayTime " +
                             "Where Not Exists " +
                             "(Select * From MotionSetting " +
                             "Where id = 0 )";

                cnn.Execute(sql, new { baseMotionSetting.name,
                                       baseMotionSetting.gobalStrength,
                                       baseMotionSetting.xStrength,
                                       baseMotionSetting.yStrength,
                                       baseMotionSetting.zStrength,
                                       baseMotionSetting.delayTime });

                cnn.Close();
            }
        }
    }
}
