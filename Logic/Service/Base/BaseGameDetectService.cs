using Dapper;
using Hosam_App.Logic.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Hosam_App.Logic.Service.Base
{
    class BaseGameDetectService
    {
        public static string sqliteDbPath = ConfigurationManager.AppSettings["SqliteDbPath"];

        public static List<GameData> GetAllGameData()
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteDbPath))
            {
                string sql = "select * from GameData";
                return cnn.Query<GameData>(sql).ToList();
            }
        }

        public static List<GameData> GetGameDataByName(string gameName)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteDbPath))
            {
                string sql = "select * from GameData" +
                             "where gameName = @gameName";
                return cnn.Query<GameData>(sql , new { gameName}).ToList();
            }
        }

        public static List<GameData> GetGameDataByPath(string path)
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteDbPath))
            {
                string sql = "select * from GameData" +
                             "where path = @path";
                return cnn.Query<GameData>(sql, new { path }).ToList();
            }
        }

        public static void UpdateGameDataByGameName (GameData gameData )
        {
            using (IDbConnection cnn = new SQLiteConnection(sqliteDbPath))
            {
                string sql = "UPDATE GameData " +
                             "SET isRunning = @isRunning , path = @path , lastRunTime = @lastRunTime " +
                             "where gameName=@gameName ";

               
                 cnn.Execute(sql, new { gameData.gameName, gameData.isRunning, gameData.path, gameData.lastRunTime });
            }
        }
    }
}
