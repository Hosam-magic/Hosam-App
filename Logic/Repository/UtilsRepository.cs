using Dapper;
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
                             "strength INTEGER (20), " +
                             "smooth INTEGER(20), " +
                             "amplitude INTEGER(20)) ";

                cnn.Execute(sql2);
            }
        }
    }
}
