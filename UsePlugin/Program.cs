using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsePlugin
{
    class Program
    { 
        static object InvokeAssemblyWithArgumant(string Path, string MethodName, object[] argumantToMethod, object[] ArgumantsToContructor = null)
        {
            object ret = null;
            System.Reflection.Assembly myDllAssembly =
            System.Reflection.Assembly.LoadFile(Path);
            if (ArgumantsToContructor == null)
            {
                foreach (Type item in myDllAssembly.GetTypes())
                {
                    ret = item.GetMethod(MethodName).Invoke(Activator.CreateInstance(item), argumantToMethod);
                }
            }
            else
            {
                foreach (Type item in myDllAssembly.GetTypes())
                {
                     ret = item.GetMethod(MethodName).Invoke(Activator.CreateInstance(item, ArgumantsToContructor), argumantToMethod);
                }
            }
            return ret;
        }

        static object InvokeAssemblyWithoutArgumant(string Path, string MethodName, object[] ArgumantsToContructor = null)
        {
            object ret = null;
            System.Reflection.Assembly myDllAssembly =
            System.Reflection.Assembly.LoadFile(Path);
            if (ArgumantsToContructor == null)
            {
                foreach (Type item in myDllAssembly.GetTypes())
                {
                    ret = item.GetMethod(MethodName).Invoke(Activator.CreateInstance(item), null);
                }
            }
            else
            {
                foreach (Type item in myDllAssembly.GetTypes())
                {
                    ret = item.GetMethod(MethodName).Invoke(Activator.CreateInstance(item, ArgumantsToContructor), null);
                }
            }
            return ret;
        }
        static void Main(string[] args)
        {       
            
            //dll path (Plugin Path)
            string PathToPlugin = Environment.CurrentDirectory + "\\Plugin.dll"; // it's extension can be anything !
            // you can also load assembly from a base64 string.
            InvokeAssemblyWithArgumant(PathToPlugin, "MyPluginFunction1",new object[] { 1, 2 }, new object[] { "Sample Arg to constructor" });
            InvokeAssemblyWithoutArgumant(PathToPlugin, "MyPluginFunction2", new object[] { "Sample Arg to constructor" });

        }
    }
}
