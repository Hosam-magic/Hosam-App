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
    class GameDataRepository
    {
        public static string sqliteFolder = ConfigurationManager.AppSettings["SqliteDbFolder"];
        public static string sqliteDbFileName = ConfigurationManager.AppSettings["SqliteDbFileName"];
        public static string sqliteDbString = ConfigurationManager.AppSettings["SqliteDbString"];
        public static string sqliteFullString = sqliteDbString + sqliteFolder + sqliteDbFileName;

        //如果傳進來的 gmaeName 是 null ，就回傳所有資料
        public static List<GameData> GetGameData(string gameName)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "select * from GameData " +
                            "where (@gameName is null or gameName=@gameName)";
                return cnn.Query<GameData>(sql,new { gameName}).ToList();
            }
        }

        public static List<GameData> GetGameDataByPath(string path)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "select * from GameData " +
                             "where path = @path";
                return cnn.Query<GameData>(sql, new { path }).ToList();
            }
        }

        public static void UpdateGameData(GameData gameData)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteFullString))
            {
                string sql = "UPDATE GameData " +
                             "SET isRunning = @isRunning , path = @path , lastRunTime = @lastRunTime " +
                             "where gameName=@gameName ";


                cnn.Execute(sql, new { gameData.gameName, gameData.isRunning, gameData.path, gameData.lastRunTime });
            }
        }
    }
}
