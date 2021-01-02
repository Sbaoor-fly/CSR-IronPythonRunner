using System;
using CSR;
using System.Threading;
using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using PFETApiTest;

namespace IronPythonRunner
{


    public class IronPythonRuntime
    {
        public static Dictionary<string, IntPtr> ptr = new Dictionary<string, IntPtr>();
        public static Dictionary<string, string> ShareDatas = new Dictionary<string, string>();//共享数据

        public class MCPYAPI
        {
            private MCCSAPI api { get; set; }
            public MCPYAPI(MCCSAPI api)
            {
                this.api = api;
            }     
            #region 原生API
            public void runcmd(string cmd)
            {
                api.runcmd(cmd);
            }
            public void logout(string msg)
            {
                api.logout(msg);
            }
            public string getOnLinePlayers()
            {
                return api.getOnLinePlayers();
            }
            public string getPlayerPermissionAndGametype(string uuid)
            {
                return  api.getPlayerPermissionAndGametype(uuid);
            }
            public string getPlayerAbilities(string uuid)
            {
                return api.getPlayerAbilities(uuid);
            }
            public string getPlayerAttributes(string uuid)
            {
                return api.getPlayerAttributes(uuid);
            }
            public string getPlayerEffects(string uuid)
            {
                return api.getPlayerEffects(uuid);
            }
            public int getscoreboard(string uuid, string name)
            {
                return api.getscoreboard(uuid, name);
            }
            public void addPlayerItem(string uuid, int id, short aux, byte count)
            {
                api.addPlayerItem(uuid, id, aux, count);
            }
            public void setCommandDescribe(string key, string descripition)
            {
                api.setCommandDescribe(key, descripition);
            }
            public void teleport(string uuid, float x, float y, float z, int did)
            {
                api.teleport(uuid, x, y, z, did);
            }
            public void setPlayerBossBart(string uuid, string title, float percent)
            {
                api.setPlayerBossBar(uuid, title, percent);
            }
            public void setPlayerSidebar(string uuid, string title, string list)
            {

                api.setPlayerSidebar(uuid, title, list);
            }
            public void setCommandDescribeEx(string key, string description, MCCSAPI.CommandPermissionLevel level, byte flag1, byte flag2)
            {
                api.setCommandDescribeEx(key, description, level, flag1, flag2);
            }
            public void setPlayerPermissionAndGametype(string uuid, string modes)
            {
                api.setPlayerPermissionAndGametype(uuid, modes);
            }
            public string getPlayerItems(string uuid)
            {
                return api.getPlayerItems(uuid);
            }
            public void disconnectClient(string uuid, string tips)
            {
                api.disconnectClient(uuid, tips);
            }
            public string getPlayerSelectedItem(string uuid)
            {
                return api.getPlayerSelectedItem(uuid);
            }
            public void transferserver(string uuid, string addr, int port)
            {
                api.transferserver(uuid, addr, port);
            }
            public void tellraw(string towho, string msg)
            {
                api.runcmd("tellraw " + towho + " {\"rawtext\":[{\"text\":\"" + msg + "\"}]}");
                //api.sendText(uuid, msg);
            }
            public void talkAs(string uuid, string msg)
            {
                api.talkAs(uuid, msg);
            }
            public string MCCSAPIVERSION()
            {
                return api.VERSION;
            }
            public uint sendSimpleForm(string uuid, string title, string contest, string buttons)
            {
                return api.sendSimpleForm(uuid, title, contest, buttons);
            }
            public void releaseForm(uint formid)
            {
                api.releaseForm(formid);
            }
            public void removePlayerBossBar(string uuid)
            {
                api.removePlayerBossBar(uuid);
            }
            public void removePlayerSidebar(string uuid)
            {
                api.removePlayerSidebar(uuid);
            }
            public uint sendCustomForm(string uuid, string json)
            {
                return api.sendCustomForm(uuid, json);
            }
            public uint sendModalForm(string uuid, string title, string contest, string button1, string button2)
            {
                return api.sendModalForm(uuid, title, contest, button1, button2);
            }
            public string getPlayerMaxAttributes(string uuid)
            {
                return api.getPlayerMaxAttributes(uuid);
            }
            public void setServerMotd(string motd ,bool isshow)
            {
                api.setServerMotd(motd, isshow);
            }
            public void reName(string uuid,string name)
            {
                api.reNameByUuid(uuid, name);
            }
            public void runcmdAs(string uuid,string command)
            {
                api.runcmdAs(uuid, command);
            }
            public string  selectPlayer(string uuid)
            {
                return api.selectPlayer(uuid);
            }
            public void sendText(string uuid,string text)
            {
                api.sendText(uuid, text);
            }
            public GUI.GUIBuilder creatGUI(string title)
            {
                return new GUI.GUIBuilder(api, title);
            }
            public CsPlayer creatPlayerObject(string uuid) 
            {
                try
                {
                    var pl = ptr[uuid];
                    return new CsPlayer(api, pl);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            public CsActor getActorFromUniqueid(ulong uniqueid)
            {
                return CsActor.getFromUniqueId(api, uniqueid);
            }
            public CsPlayer getPlayerFromUniqueid(ulong uniqueid)
            {
                return (CsPlayer)CsPlayer.getFromUniqueId(api, uniqueid);
            }
            public CsActor[] getFromAABB(int did,float x1,float y1,float z1, float x2, float y2, float z2) 
            {
                var temp = new List<CsActor>();
                var raw = CsActor.getsFromAABB(api, did, x1, y1, z2, x2, y2, z2);
                foreach (var i in raw)
                {
                    temp.Add((CsActor)i);
                }
                return temp.ToArray();
            }
            public CsPlayer convertActorToPlayer(CsActor ac)
            { 
                return (CsPlayer)ac;
            }
        #endregion
    }
        public class ToolFunc
        {
            #region 拓展函数
            public void WriteAllText(string path, string contenst)
            {
                File.WriteAllText(path, contenst);
            }
            public void AppendAllText(string path, string contenst)
            {
                File.AppendAllText(path, contenst);
            }
            public string[] ReadAllLine(string path)
            {
                return File.ReadAllLines(path);
            }
            public string ReadAllText(string path)
            {
                return File.ReadAllText(path);
            }
            public string WorkingPath()
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }

            public void WriteInfo(string pluginname, string msg)
            {
                Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss} ");
                Console.Write("INFO][");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(pluginname);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("] " + msg);
            }
            public void WriteWarn(string plname, string msg)
            {
                Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("WARN");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("][");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(plname);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("] " + msg);
            }
            public string ToMD5(string word)
            {
                string md5output = "";
                MD5 md5 = new MD5CryptoServiceProvider();//创建MD5对象（MD5类为抽象类不能被实例化）
                byte[] date = System.Text.Encoding.Default.GetBytes(word);//将字符串编码转换为一个字节序列
                byte[] date1 = md5.ComputeHash(date);//计算data字节数组的哈希值（加密）
                md5.Clear();//释放类资源
                for (int i = 0; i < date1.Length - 1; i++)//遍历加密后的数值到变量str2
                {

                    md5output += date1[i].ToString("X");//（X为大写时加密后的数值里的字母为大写，x为小写时加密后的数值里的字母为小写）
                }
                return md5output;
            }
            public string HttpPost(string Url, string postDataStr)
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                Stream myRequestStream = request.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }

            public string HttpGet(string Url, string postDataStr)
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            /// <summary>
            /// Http下载文件
            /// </summary>
            public static void  HttpDownloadFile(string url, string path)
            {
                Task.Run(() =>
                {
                    //WebClient W = new WebClient();
                    //W.DownloadFileTaskAsync(url, path);
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //发送请求并获取相应回应数据
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //直到request.GetResponse()程序才开始向目标网页发送Post请求
                    Stream responseStream = response.GetResponseStream();
                    //创建本地文件写入流
                    Stream stream = new FileStream(path, FileMode.Create);
                    byte[] bArr = new byte[1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        stream.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }
                    stream.Close();
                    responseStream.Close();
                });
            }
            public void CreateDir(string path)
            {
                Directory.CreateDirectory(path);
            }
            public bool IfFile(string path)
            {
                return File.Exists(path);
            }
            public bool IfDir(string path)
            {
                return Directory.Exists(path);
            }
            public int ShareData(string key, string value)
            {
                if (!ShareDatas.ContainsKey(key))
                {
                    ShareDatas.Add(key, value);
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public string GetShareData(string key)
            {
                if (ShareDatas.ContainsKey(key))
                {
                    return ShareDatas[key];
                }
                else
                {
                    return "1";
                }
            }
            public int ChangeShareData(string key, string value)
            {
                if (ShareDatas.ContainsKey(key))
                {
                    ShareDatas[key] = value;
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public int RemoveShareData(string key)
            {
                if (ShareDatas.ContainsKey(key))
                {
                    ShareDatas.Remove(key);
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            #endregion
        }
        public class PFessAPI
        {
            #region  PFessAPI
            public bool AddMoney(string name,uint value)
            {
                return PFApiLite.AddMoney(name, value);
            }
            public bool RemoveMoney(string name,uint value)
            {
                return PFApiLite.RemoveMoney(name, value);
            }
            public int GetMoney(string name)
            {
                return PFApiLite.GetMoney(name);
            }
            public string  GetUUID(string name)
            {
                return PFApiLite.GetUUID(name);
            }
            public bool HasOpPermission(string name)
            {
                return PFApiLite.HasOpPermission(name);
            }
            public void ExecuteCmdAs(string name,string cmd)
            {
                PFApiLite.ExecuteCmdAs(name, cmd);
            }
            public void ExecuteCmd(string  cmd)
            {
                PFApiLite.ExecuteCmd(cmd);
            }
            public void AddCommandDescribe(string key,string desc)
            {
                PFApiLite.AddCommandDescribe(key, desc);
            }
            public void DelCommandDescribe(string key)
            {
                PFApiLite.DelCommandDescribe(key);
            }
            public void SendActionbar(string name, string msg)
            {
                PFApiLite.SendActionbar(name, msg);
            }
            public void FeedbackTellraw(string name,string msg)
            {
                PFApiLite.FeedbackTellraw(name, msg);
            }
            #endregion
        }
        public static bool TRY(Action act)
        {
            try
            {
                act.Invoke();
                return true;
            }
            catch (Exception e)
            {
                if (!e.Message.StartsWith("“Microsoft.Scripting.Hosting.ScriptScope”") && e.Message.IndexOf("无法将 null 转换为“bool") == -1)
                {
                    //Console.Write("[IPYR] ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[IPYR] "+e.Message);
                    Console.ForegroundColor= ConsoleColor.White;
                }
                    
                return false;
            }
        }
        public static void CallPyFunc(List<dynamic> Func, Action<dynamic> act)
        {
            foreach (var fun in Func)
            {
                TRY(() =>
                {
                    act(fun);
                });
            }
        }
        static string CsGetUuid(List<IntPtr> pls, string pln, MCCSAPI api)
        {
            foreach (IntPtr pl in pls)
            {
                CsPlayer cpl = new CsPlayer(api, pl);
                if (cpl.getName() == pln)
                {
                    return cpl.Uuid;
                }
            }
            return string.Empty;
        }
        public static void RunIronPython(MCCSAPI api)
        {
            List<IntPtr> uuid = new List<IntPtr>();
            const String path = "./ipy";
            bool pfapi = false;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Console.WriteLine("[IPYR] IronPython插件运行平台开始装载。");
            if (File.Exists("./csr/PFEssentials.csr.dll"))
            {
                Console.WriteLine("[IPYR] 找到PFessentials,加载PFessAPI");
                pfapi = true;
            }
            var PyFun = new List<dynamic>();
            DirectoryInfo Allfolder = new DirectoryInfo(path);
            foreach (FileInfo file in Allfolder.GetFiles("*.net.py"))
            {
                try
                {
                    Console.WriteLine("[IPYR] Load\\" + file.Name);
                    ScriptEngine pyEngine = Python.CreateEngine();// 读取脚本文件
                    var Libpath = pyEngine.GetSearchPaths();
                    List<string> LST = new List<string>(Libpath.Count)
                    {
                        "C:\\Program Files\\IronPython 2.7\\Lib",
                        ".\\IronPython27.zip"
                    };
                    pyEngine.SetSearchPaths(LST.ToArray());
                    dynamic py = pyEngine.ExecuteFile(file.FullName);// 调用Python函数
                    py.SetVariable("mc", new MCPYAPI(api));
                    py.SetVariable("tool", new ToolFunc());
                    if(pfapi)
                        py.SetVariable("pfapi", new PFessAPI());
                    var main = py.load_plugin();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(file.Name + " Load Successful");
                    Console.ForegroundColor = ConsoleColor.White;
                    PyFun.Add(py);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Failed to load " + file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            #region 监听器
            api.addBeforeActListener(EventKey.onLoadName, x =>
            {
                var a = BaseEvent.getFrom(x) as LoadNameEvent;
                uuid.Add(a.playerPtr);
                ptr.Add(a.uuid, a.playerPtr);
                CallPyFunc(PyFun, func =>
                {
                    CsPlayer p = new CsPlayer(api, a.playerPtr);
                    string list = "{\'playername\':\'" + a.playername + "\',\'uuid\':\'" + a.uuid + "\',\'xuid\':\'" + a.xuid + "\',\'IPport\':\'" + p.IpPort + "\'}";
                    //string[] list = { a.playername, a.uuid, a.xuid };
                    var re = func.load_name(list);
                });
                return true;
            });
            api.addBeforeActListener(EventKey.onPlayerLeft, x =>
            {
                var a = BaseEvent.getFrom(x) as PlayerLeftEvent;
                uuid.Remove(a.playerPtr);
                ptr.Remove(a.uuid);
                CallPyFunc(PyFun, func =>
                {
                    string list = "{\'playername\':\'" + a.playername + "\',\'uuid\':\'" + a.uuid + "\',\'xuid\':\'" + a.xuid + "\'}";
                    var re = func.player_left(list);
                });
                return true;
            });
            api.addBeforeActListener(EventKey.onServerCmd, x =>
            {
                var a = BaseEvent.getFrom(x) as ServerCmdEvent;
                if (a.cmd.StartsWith("ipy "))
                {
                    string[] sArray = a.cmd.Split(new char[1] { ' ' });
                    if (sArray[1] == "info")
                    {
                        string msg = "窗体关闭，控制台已恢复";
                        MessageBox.Show("感谢使用IronPythonRunner\n作者:Sbaoor", "IronPythonRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss} ");
                        Console.Write("INFO][");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("IPYR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("] " + msg);
                    }
                    if (sArray[1] == "list")
                    {
                        DirectoryInfo folder = new DirectoryInfo(path);
                        int total = 0;
                        Console.WriteLine("[IPYR]读取插件列表");
                        foreach (FileInfo file in Allfolder.GetFiles("*.net.py"))
                        {
                            Console.WriteLine(" - " + file.Name);
                            total += 1;
                        }
                        Console.WriteLine($"[IPYR]共加载了{total}个ipy插件");
                    }
                    if (sArray[1] == "reload")
                    {
                        PyFun.Clear();
                        ShareDatas.Clear();
                        DirectoryInfo folder = new DirectoryInfo(path);
                        foreach (FileInfo file in folder.GetFiles("*.net.py"))
                        {
                            try
                            {
                                Console.WriteLine("[IPYR] Load\\" + file.Name);
                                ScriptEngine pyEngine = Python.CreateEngine();// 读取脚本文件
                                var Libpath = pyEngine.GetSearchPaths();
                                List<string> LST = new List<string>(Libpath.Count)
                                {
                                    "C:\\Program Files\\IronPython 2.7\\Lib",
                                    ".\\IronPython27.zip"
                                };
                                pyEngine.SetSearchPaths(LST.ToArray());
                                dynamic py = pyEngine.ExecuteFile(file.FullName);// 调用Python函数
                                py.SetVariable("mc", new MCPYAPI(api));
                                py.SetVariable("tool", new ToolFunc());
                                if (pfapi)
                                    py.SetVariable("pfapi", new PFessAPI());
                                var main = py.load_plugin();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(file.Name + " Load Successful");
                                Console.ForegroundColor = ConsoleColor.White;
                                PyFun.Add(py);
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Failed to load " + file.Name);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        Console.WriteLine("[IPYR] 重载成功！");
                    }
                    return false;
                }
                else
                {
                    var re = true;
                    CallPyFunc(PyFun, func =>
                    {
                        string list = $"{{\'cmd\':{a.cmd }}}";
                        re = func.server_command(list);
                    });
                    return re;

                }

            });
            api.addBeforeActListener(EventKey.onEquippedArmor, x =>
            {
                var a = BaseEvent.getFrom(x) as EquippedArmorEvent;
                CallPyFunc(PyFun, func =>
                {
                    string list = "{\'playername\':\'" + a.playername + "\',\'itemid\':\'" + a.itemid + "\',\'itemname\':\'" + a.itemname + "\',\'itemcount\':\'" + a.itemcount + "\',\'itemaux\':\'" + a.itemaux + "\',\'slot\':\'" + a.slot + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "]}";
                    var re = func.equippedarm(list);
                });
                return true;
            });
            api.addBeforeActListener(EventKey.onAttack, x =>
            {
                var a = BaseEvent.getFrom(x) as AttackEvent;
                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    string list = "{\'actorname\':\'" + a.actorname + "\',\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "]}";
                    re = func.attack(list);
                });
                return re;

            });
            api.addBeforeActListener(EventKey.onInputText, x =>
            {
                var a = BaseEvent.getFrom(x) as InputTextEvent;
                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    string list = "{\'msg\':\'" + a.msg + "\',\'dimensionid\':\'" + a.dimensionid + "\',\'uuid\':\'" + CsGetUuid(uuid, a.playername, api) + "\',\'playername\':\'" + a.playername + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "]}";
                    re = func.inputtext(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onDestroyBlock, x =>
            {
                var a = BaseEvent.getFrom(x) as DestroyBlockEvent;
                var re = true;
                string list = "{\'blockid\':\'" + a.blockid + "\',\'uuid\':\'" + CsGetUuid(uuid, a.playername, api) + "\',\'position\':[" + Convert.ToInt32(a.position.x) + "," + Convert.ToInt32(a.position.y) + "," + Convert.ToInt32(a.position.z) + "],\'blockname\':\'" + a.blockname + "\',\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "]}";

                CallPyFunc(PyFun, func =>
                {
                    re = func.destroyblock(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onMobDie, x =>
            {
                var a = BaseEvent.getFrom(x) as MobDieEvent;
                var re = true;
                string list = "{\'mobname\':\'" + a.mobname + "\',\'mobtype\':\'" + a.mobtype + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "],\'srcname\':\'" + a.srcname + "\',\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\'}";

                CallPyFunc(PyFun, func =>
                {
                    re = func.mobdie(list);

                });
                return true;
            });
            api.addBeforeActListener(EventKey.onRespawn, x =>
            {
                var a = BaseEvent.getFrom(x) as RespawnEvent;
                string list = "{\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "],\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\',\'uuid\':\'" + CsGetUuid(uuid, a.playername, api) + "\'}";

                CallPyFunc(PyFun, func =>
                {
                    var re = func.respawn(list);
                });
                return true;
            });
            api.addBeforeActListener(EventKey.onInputCommand, x =>
            {
                var a = BaseEvent.getFrom(x) as InputCommandEvent;
                var re = true;
                string list = "{\'cmd\':\'" + a.cmd + "\',\'XYZ\':[" + Convert.ToInt32(a.XYZ.x) + "," + Convert.ToInt32(a.XYZ.y) + "," + Convert.ToInt32(a.XYZ.z) + "],\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\',\'uuid\':\'" + CsGetUuid(uuid, a.playername, api) + "\'}";

                CallPyFunc(PyFun, func =>
                {
                    re = func.inputcommand(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onFormSelect, x =>
            {
                var a = BaseEvent.getFrom(x) as FormSelectEvent;
                string list = $"{{\'playername\':\'{a.playername}\',\'selected\':{a.selected},\'uuid\':\'{a.uuid}\',\'formid\':\'{a.formid}\'}}";
                CallPyFunc(PyFun, func =>
                {
                    var re = func.formselect(list);
                });

                return true;
            });
            api.addBeforeActListener(EventKey.onUseItem, x =>
            {
                var a = BaseEvent.getFrom(x) as UseItemEvent;
                string list = $"{{\'playername\':\'{a.playername}\',\'itemid\':\'{a.itemid}\',\'itemaux\':\'{a.itemaux}\',\'itemname\':\'{a.itemname}\',\'XYZ\':[{a.XYZ.x},{a.XYZ.y},{a.XYZ.z}],\'postion\':[{a.position.x},{a.position.y},{a.position.z}],\'blockname\':\'{a.blockname}\',\'blockid\':\'{a.blockid}\'}}";

                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.useitem(list);
                });
                return re;

            });
            api.addBeforeActListener(EventKey.onPlacedBlock, x =>
            {
                var a = BaseEvent.getFrom(x) as PlacedBlockEvent;
                string list = $"{{\'playername\':\'{a.playername}\',\'blockid\':\'{a.blockid}\',\'blockname\':\'{a.blockname}\',\'XYZ\':[{a.XYZ.x},{a.XYZ.y},{a.XYZ.z}],\'postion\':[{a.position.x},{a.position.y},{a.position.z}],\'dimensionid\':\'{a.dimensionid}\'}}";

                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.placeblock(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onLevelExplode, x =>
            {
                var a = BaseEvent.getFrom(x) as LevelExplodeEvent;
                string list = $"{{\'explodepower\':\'{a.explodepower}\',\'blockid\':\'{a.blockid}\',\'blockname\':\'{a.blockname}\',\'entity\':\'{a.entity}\',\'entityid\':\'{a.entityid}\',\'dimensionid\':\'{a.dimensionid}\',\'postion\':[{a.position.x},{a.position.y},{a.position.z}]}}";

                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.levelexplode(list);
                });
                return re;

            });
            api.addBeforeActListener(EventKey.onNpcCmd, x =>
            {
                var a = BaseEvent.getFrom(x) as NpcCmdEvent;
                string list = $"{{\'npcname\':\'{a.npcname}\',\'actionid\':\'{a.actionid}\',\'actions\':\'{a.actions}\',\'dimensionid\':\'{a.dimensionid}\',\'entity\':\'{a.entity}\',\'entityid\':\'{a.entityid}\',\'postion\':[{a.position.x},{a.position.y},{a.position.z}]}}";

                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.npccmd(list);
                });
                return re;

            });
            api.addBeforeActListener(EventKey.onBlockCmd, x =>
            {
                var a = BaseEvent.getFrom(x) as BlockCmdEvent;
                string list = $"{{\'cmd\':\'{a.cmd}\',\'dimensionid\':\'{a.dimensionid}\',\'postion\':[{a.position.x},{a.position.y},{a.position.z}],\'type\':\'{a.type}\',\'tickdelay\':\'{a.tickdelay}\'}}";

                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.blockcmd(list);
                });
                return re;

            });
            api.addBeforeActListener(EventKey.onPistonPush, x =>
            {
                var a = BaseEvent.getFrom(x) as PistonPushEvent;
                var re = true;
                string list = $"{{\'targetposition\':[{a.targetposition.x},{a.targetposition.y},{a.targetposition.z}],\'blockid\':\'{a.blockid}\',\'blockname\':\'{ a.blockname }\',\'dimensionid\':\'{ a.dimensionid }\',\'targetblockid\':\'{a.targetblockid}\',\'targetblockname\':\'{a.targetblockname}}}";
                CallPyFunc(PyFun, func =>
                {
                    re = func.pistonpush(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onStartOpenChest, x =>
            {
                var a = BaseEvent.getFrom(x) as StartOpenChestEvent;
                string list = $"{{\'playername\':\'{a.playername}\',\'blockid\':\'{a.blockid}\',\'blockname\':\'{a.blockname}\',\'XYZ\':[{a.XYZ.x},{a.XYZ.y},{a.XYZ.z}],\'postion\':[{a.position.x},{a.position.y},{a.position.z}],\'dimensionid\':\'{a.dimensionid}\'}}";
                var re = true;
                CallPyFunc(PyFun, func =>
                {
                    re = func.openchest(list);
                });
                return re;
            });
            api.addBeforeActListener(EventKey.onStopOpenChest, x =>
             {
                 var a = BaseEvent.getFrom(x) as StopOpenChestEvent;
                 string list = $"{{\'playername\':\'{a.playername}\',\'blockid\':\'{a.blockid}\',\'blockname\':\'{a.blockname}\',\'XYZ\':[{a.XYZ.x},{a.XYZ.y},{a.XYZ.z}],\'postion\':[{a.position.x},{a.position.y},{a.position.z}],\'dimensionid\':\'{a.dimensionid}\'}}";
                 CallPyFunc(PyFun, func =>
                 {
                     var re = func.closechest(list);
                 });
                 return true;
             });

            #endregion 


        }
    }
}
namespace CSR
{
    partial class Plugin
    {

        public static void onStart(MCCSAPI api)
        {
            csapi.api = api;
            // TODO 此接口为必要实现
            IronPythonRunner.IronPythonRuntime.RunIronPython(api);
            Console.WriteLine("[IronPythonRunner] 加载完成！");
        }
    }
    public class csapi 
    {
        public static MCCSAPI api;
    }
}
