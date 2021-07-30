using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hosam_App.Logic.Entity;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;

namespace Hosam_App.Logic.Service
{
    class DataReaderService
    {
        static MemoryMappedFile sendCommandMmf ;  
        

        public static ActionResult Start(GameData startGame)
        {
            try
            {
                bool a = IsDataReaderRunning();
                if (IsDataReaderRunning())
                {
                    return new ActionResult(false, SoftLogicErr.alreadyStart.GetCode(), SoftLogicErr.alreadyStart.GetMsg());
                }
                //開啟副程式
                Process.Start(@"F:\workspace\racing-seat\GameDataReader(64)\GameDataReader(64)\bin\x64\Debug\GameDataReader(64).exe");


                //傳送起動遊戲與座椅設定
                string uuid = Guid.NewGuid().ToString();
                MmfCommand mmfCommand = new MmfCommand
                {
                    mmfId = uuid,
                    command = "start",
                    gameName = startGame.gameName,
                    motionSetting = startGame.motionSetting

                };

                Thread.Sleep(500);
                SendMsg(mmfCommand);

                return ReadMmfActionResult(uuid);
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name+  "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult Adjust(MotionSetting newSetting)
        {
            try
            {
                if (!IsDataReaderRunning())
                {
                    return new ActionResult(false, SoftLogicErr.notRunning.GetCode(), SoftLogicErr.notRunning.GetMsg());
                }

                //傳送新的設定
                string uuid = Guid.NewGuid().ToString();
                MmfCommand mmfCommand = new MmfCommand
                {
                    mmfId = uuid,
                    command = "adjust",
                    motionSetting = newSetting
                };
                SendMsg(mmfCommand);

                return ReadMmfActionResult(uuid);
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult GetPhsycalData()
        {
            try
            {
                if (!IsDataReaderRunning())
                {
                    return new ActionResult(false, SoftLogicErr.notRunning.GetCode(), SoftLogicErr.notRunning.GetMsg());
                }

                ActionResult result = ReadMmfActionResult();

                if (!result.scucess)
                {
                    return result;
                }

                //因經過序列化裡面的 PhsycalData 已轉變成 string 特質，利用反序列化在做一次轉換

                result.data = JsonConvert.DeserializeObject<PhsycalData>(result.data.ToString());

                return result;
            }
            catch (Exception e)
            {
                int line = (new StackTrace(e, true)).GetFrame(0).GetFileLineNumber();
                Console.WriteLine("err at "+line);
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name + "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult Stop()
        {
            try
            {
                Console.WriteLine("stop");
                //傳送停止訊息
                string uuid = Guid.NewGuid().ToString();
                MmfCommand mmfCommand = new MmfCommand
                {
                    mmfId = uuid,
                    command = "stop"
                };
                SendMsg(mmfCommand);

                return ReadMmfActionResult(uuid);
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static void SendMsg(MmfCommand mmfCommand)
        {
            if (sendCommandMmf == null)
            {
                sendCommandMmf = MemoryMappedFile.CreateOrOpen("CommandMsg", 256);
            }

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
        }

        static bool IsDataReaderRunning()
        {
            string dataReaderName = "GameDataReader(64)";

            List<Process> processlist = Process.GetProcesses().ToList();
            foreach (Process p in processlist)
            {
                //找尋副程式名稱的執行程序
                if (p.ProcessName == dataReaderName) 
                {
                    return true;
                }
            }

            //沒有找到
            return false;
        }

        static ActionResult ReadMmfActionResult(string mmfId)
        {

            DateTime start = DateTime.Now;

            //如果超過6秒判斷為沒回應
            while (DateTime.Now.Subtract(start).Seconds < 6)
            {
                try
                {

                    MemoryMappedFile MmfActionResult = MemoryMappedFile.OpenExisting("MmfActionResult");
                    
                    using (MemoryMappedViewStream stream = MmfActionResult.CreateViewStream(0, 0))
                    {
                        using (var br = new BinaryReader(stream))
                        {
                            //先讀取長度，再讀取内容
                            var len = br.ReadInt32();
                            var word = Encoding.UTF8.GetString(br.ReadBytes(len), 0, len);
                            string jsonMmfActionResult = word.ToString();
                            MmfActionResult result = JsonConvert.DeserializeObject<MmfActionResult>(jsonMmfActionResult);
                            //確認是否讀取到指定訊息
                            if (result.mmfId == mmfId)
                            {
                                return result.actionResult;
                            }

                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (Exception e)
                {
                    
                    LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name + "\r\n" + e.GetType() + "\r\n" + e.Message);
                    return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
                }

            }

            return new ActionResult(false, SoftLogicErr.noResponse.GetCode(), SoftLogicErr.noResponse.GetMsg());
        }

        //沒有判斷 mmfId 用於接收高更新率的物理數據
        static ActionResult ReadMmfActionResult()
        {

            DateTime start = DateTime.Now;

            //如果超過6秒判斷為沒回應
            while (DateTime.Now.Subtract(start).Seconds < 6)
            {
                try
                {

                    MemoryMappedFile MmfActionResult  = MemoryMappedFile.OpenExisting("MmfActionResult");
                  
                    using (MemoryMappedViewStream stream = MmfActionResult.CreateViewStream(0, 0))
                    {
                        using (var br = new BinaryReader(stream))
                        {
                            //先讀取長度，再讀取内容
                            var len = br.ReadInt32();
                            var word = Encoding.UTF8.GetString(br.ReadBytes(len), 0, len);
                            string jsonMmfActionResult = word.ToString();
                            MmfActionResult result = JsonConvert.DeserializeObject<MmfActionResult>(jsonMmfActionResult);

                            return result.actionResult;
                            

                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (Exception e)
                {

                    LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name + "\r\n" + e.GetType() + "\r\n" + e.Message);
                    return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
                }

            }

            return new ActionResult(false, SoftLogicErr.noResponse.GetCode(), SoftLogicErr.noResponse.GetMsg());
        }
    }
}
