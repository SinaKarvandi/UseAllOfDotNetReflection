using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public class Class1
    {
        public Class1(string Arg1)
        {
            //Make program ready for first usage
            System.Windows.Forms.MessageBox.Show("Constructor Invoked !" + Arg1);

        }
        public static string MyPluginFunction1(int a, int b)
        {
            System.Windows.Forms.MessageBox.Show("I'm here in MyPluginFunction.(Args:" + a + "-" + b + ")");
            // Do what to want to do as a plugin
            return "Successful";
        }

        public static string MyPluginFunction2()
        {
            System.Windows.Forms.MessageBox.Show("I'm here in MyPluginFunction (without arg).");
            // Do what to want to do as a plugin
            return "Successful";
        }
    }
}
