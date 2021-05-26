using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hosam_App.Logic.Gobal;
using AssettoCorsaSharedMemory;
using Hosam_App.Logic.Entity;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Threading;

namespace Hosam_App.Logic.Service
{
    class GameDriverService
    {
        //static readonly MemoryMappedFile gameDataMmf = MemoryMappedFile.OpenExisting("GameData");

        static bool isSidePorjectStart = false;

        public static ActionResult Start(GameData startGame)
        {
            try
            {
                if (isSidePorjectStart)
                {
                    return new ActionResult(false, SoftLogicErr.alreadyStart.getCode(), SoftLogicErr.alreadyStart.getMsg());
                }
                //開啟副程式
                Process.Start(@"C:\Users\johnny\source\repos\GameDataReader(64)\GameDataReader(64)\bin\x64\Debug\GameDataReader(64).exe");
                isSidePorjectStart = true;

                //將啟動資料透過mmf傳輸，發送後釋放mmf
                MmfCommand mmfCommand = new MmfCommand
                {
                    id = Guid.NewGuid().ToString(),
                    command = "start",
                    gameName = startGame.gameName,
                    motionSetting = startGame.motionSetting

                };
                SendMsg(mmfCommand);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult Stop()
        {
            try
            {
                MmfCommand mmfCommand = new MmfCommand
                {
                    id = Guid.NewGuid().ToString(),
                    command = "stop"
                };
                SendMsg(mmfCommand);
                isSidePorjectStart = false;
                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        static void SendMsg(MmfCommand mmfCommand)
        {
            MemoryMappedFile sendCommandMmf = MemoryMappedFile.CreateOrOpen("CommandMsg", 1024);
            string jsonCommand = new JavaScriptSerializer().Serialize(mmfCommand);
            using (var stream = sendCommandMmf.CreateViewStream())
            {
                byte[] msg = Encoding.UTF8.GetBytes(jsonCommand);
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    bw.Write(msg.Length); //先寫Length
                    bw.Write(msg); //再寫byte[]
                }
            }

            //先 delay 在釋放，避免副程式來不及讀取
        }

        static ActionResult ReadActonResult()
        {
            int tryTime = 0;
            MemoryMappedFile actionResultMmf = null;
            //嘗試讀取
            while (tryTime < 30)
            {
                try
                {
                   actionResultMmf = MemoryMappedFile.OpenExisting("ActionResult");
                    break;
                }
                catch (FileNotFoundException)
                {
                    tryTime++;
                    if (tryTime > 30)
                    {
                        return new ActionResult(false, SoftLogicErr.noResponse.getCode(), SoftLogicErr.noResponse.getMsg());
                    }
                }
            }
            using (MemoryMappedViewStream stream = actionResultMmf.CreateViewStream(0, 0))
            {
                using (var br = new BinaryReader(stream))
                {
                    //先讀取長度，再讀取内容
                    var len = br.ReadInt32();
                    var word = Encoding.UTF8.GetString(br.ReadBytes(len), 0, len);
                    string jsonActionResult = word.ToString();
                    return JsonConvert.DeserializeObject<ActionResult>(jsonActionResult);
                }
            }



        }
    }
}
