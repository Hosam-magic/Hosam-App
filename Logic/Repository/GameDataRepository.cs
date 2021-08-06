using Dapper;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Gobal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;


namespace Hosam_App.Logic.Repository
{
    class GameDataRepository
    {
        public static string sqliteFolder = ConfigurationManager.AppSettings["SqliteDbFolder"];
        public static string sqliteDbFileName = ConfigurationManager.AppSettings["SqliteDbFileName"];
        public static string sqliteDbString = ConfigurationManager.AppSettings["SqliteDbString"];
        public static string sqliteFullString = sqliteDbString + sqliteFolder + sqliteDbFileName;

        //如果傳進來的 id 是 null ，就回傳所有資料
        public static List<GameData> GetGameData(string id, int orederBy)
        {
            
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "select * from GameData gd " +
                             "Left Join MotionSetting ms on gd.configId = ms.id " +
                             "where (@id is null or gd.id = @id) " +
                             "Order By " +
                             "Case When @orederBy = 0 then gameName End , " +
                             "Case When @orederBy = 1 then lastRunTime End DESC ";
                List<GameData> data = cnn.Query<GameData, MotionSetting, GameData>(sql, (gd, ms) => { gd.motionSetting = ms; return gd; }, new { id , orederBy }).ToList();
                cnn.Close();

                return data;
            }
        }

        public static List<GameData> GetGameDataByPath(string path)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "select * from GameData " +
                             "where path = @path";

                List<GameData> data = cnn.Query<GameData>(sql, new { path }).ToList();
                cnn.Close();
                return data;
                
            }
        }

        public static void ResetAllRunningStatus()
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "Update GameData " +
                             "Set isRunning = null";

                cnn.Execute(sql);
                cnn.Close();
            }
        }

        public static void UpdateGameStatus(GameData gameData)
        {

            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "UPDATE GameData " +
                             "SET isRunning = @isRunning , path = @path , lastRunTime = @lastRunTime " +
                             "where id=@id ";


                cnn.Execute(sql, new { gameData.id, gameData.isRunning, gameData.path, gameData.lastRunTime });
                cnn.Close();
            }

        }

        public static void UpdateGameConfigId(GameData gameData)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                cnn.Open();
                string sql = "UPDATE GameData " +
                             "SET configId = @configId " +
                             "where id=@id ";


                cnn.Execute(sql, new { gameData.id, gameData.configId });

                cnn.Close();
            }
        }
    }
}
