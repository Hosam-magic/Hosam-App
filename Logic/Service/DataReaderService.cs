﻿using Hosam_App.ErrorCode;
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
using System.Reflection;

namespace Hosam_App.Logic.Service
{
    class DataReaderService
    {
        //static readonly MemoryMappedFile gameDataMmf = MemoryMappedFile.OpenExisting("GameData");

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
                MmfCommand mmfCommand = new MmfCommand
                {
                    id = Guid.NewGuid().ToString(),
                    command = "adjust",
                    motionSetting = newSetting
                };
                SendMsg(mmfCommand);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult Stop()
        {
            try
            {
                //傳送停止訊息
                MmfCommand mmfCommand = new MmfCommand
                {
                    id = Guid.NewGuid().ToString(),
                    command = "stop"
                };
                SendMsg(mmfCommand);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);

                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
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

    }
}
