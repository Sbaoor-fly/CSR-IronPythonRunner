using System;
using CSR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Reflection.Emit;
using System.IO;

namespace IronPythonRunner
{
    public class Class1
    {
        public static void WriteLine(string msg, ConsoleColor forecolor = ConsoleColor.Cyan, ConsoleColor backcolor = ConsoleColor.Black)
        {
            Console.ForegroundColor = forecolor;
            Console.BackgroundColor = backcolor;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public class PyFunc
        {
            private MCCSAPI api { get; set; }
            public PyFunc(MCCSAPI api)
            {
                this.api = api;
            }
            public void runcmd(string cmd)
            {
                api.runcmd(cmd);
            }
            public void logout(string msg)
            {
                api.logout(msg);
            }
            public void getOnLinePlayers()
            {
                api.getOnLinePlayers();
            }
        }
            public static void Dracoup(MCCSAPI api)
        { 
            String path = "./ipy";
            DirectoryInfo Allfolder = new DirectoryInfo(path);
            foreach (FileInfo file in Allfolder.GetFiles("*.net.py"))
            {
                try
                {
                    Console.WriteLine("[IPyR] Load\\" + file.Name);
                    ScriptEngine pyEngine = Python.CreateEngine();
                    // 读取脚本文件
                    dynamic py = pyEngine.ExecuteFile(file.FullName);
                    // 调用Python函数
                    py.SetVariable("MCPYAPI", new PyFunc(api));
                    string main = py.load_plugin();
                    WriteLine(file.Name + " Load Successful");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to load "+file.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            api.addBeforeActListener(EventKey.onLoadName, x =>
            {
                 var a = BaseEvent.getFrom(x) as LoadNameEvent;

                 DirectoryInfo folder = new DirectoryInfo(path);

                 foreach (FileInfo file in folder.GetFiles("*.net.py"))
                 {
                     try
                     {
                         Console.WriteLine("["+file.Name+"]开始处理事件");
                         ScriptEngine pyEngine = Python.CreateEngine();
                         dynamic py = pyEngine.ExecuteFile(file.FullName);
                         py.SetVariable("MCPYAPI", new PyFunc(api));
                         string list = "{\'playername\':\'"+a.playername+"\',\'uuid\':\'"+a.uuid+"\',\'xuid\':\'"+a.xuid+"\'}";
                         //string list = "[" + b + "," + c + "," + d + "]";
                         bool re = py.load_name(list);
                        return re;
                     }
                     catch
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("[" + file.Name + "]事件处理失败");
                         Console.ForegroundColor = ConsoleColor.Gray;
                     }
                 }
                 return true;
            });
            api.addBeforeActListener(EventKey.onServerCmd, x =>
             {
                 var a = BaseEvent.getFrom(x) as ServerCmdEvent;
                 DirectoryInfo folder = new DirectoryInfo(path);

                 foreach (FileInfo file in folder.GetFiles("*.net.py"))
                 {
                     try
                     {
                         Console.WriteLine("[" + file.Name + "]开始处理事件");
                         ScriptEngine pyEngine = Python.CreateEngine();
                         dynamic py = pyEngine.ExecuteFile(file.FullName);
                         py.SetVariable("MCPYAPI", new PyFunc(api));
                         string list = "{\'cmd\':\'" + a.cmd + "\'}";
                         bool re = py.server_command(list);
                         return re;
                     }
                     catch
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("[" + file.Name + "]事件处理失败");
                         Console.ForegroundColor = ConsoleColor.Gray;
                     }
                 }
                 return true;
             });
            api.addBeforeActListener(EventKey.onAttack, x =>
            {
                var a = BaseEvent.getFrom(x) as AttackEvent;
                DirectoryInfo folder = new DirectoryInfo(path);

                foreach (FileInfo file in folder.GetFiles("*.net.py"))
                {
                    try
                    {
                        Console.WriteLine("[" + file.Name + "]开始处理事件");
                        ScriptEngine pyEngine = Python.CreateEngine();
                        dynamic py = pyEngine.ExecuteFile(file.FullName);
                        py.SetVariable("MCPYAPI", new PyFunc(api));
                        string list = "{\'actorname\':\'" + a.actorname + "\',\'dimensionid\':\'" + a.dimensionid + "\',\'playername\':\'" + a.playername + "\',\'XYZ\':\'[" + Convert.ToInt32(a.XYZ.x) + ","+ Convert.ToInt32(a.XYZ.y)+","+ Convert.ToInt32(a.XYZ.z)+"]\'}";
                        bool re = py.attack(list);
                        return re;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[" + file.Name + "]事件处理失败");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                return true;
            });
        }
    }
}
namespace CSR
{
    partial class Plugin
    {

        public static void onStart(MCCSAPI api)
        {
            // TODO 此接口为必要实现
            IronPythonRunner.Class1.Dracoup(api);
            Console.WriteLine("[IronPythonRunner]加载成功！");
        }
    }
}