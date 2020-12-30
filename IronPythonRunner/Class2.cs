using System;
using CSR;
using IronPython.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using System.Reflection.Emit;
using System.CodeDom;

namespace IronPythonRunner
{
    public class Class1
    {
        public static void Dracoup(MCCSAPI api)
        {
            var test = Python.CreateEngine();
            try
            {
                var py = test.CreateScriptSourceFromFile("./py/be.py");
                var scope = test.CreateScope();
                scope.SetVariable("test", "sucess");
                scope.SetVariable("MCPYAPI", new PyFunc(api));
                py.Execute(scope);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
        }
    }
}