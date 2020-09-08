using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace compiler_app
{
    class extensionRegister
    {

        public extensionRegister() {
        }
     

        //--------------------------------------------- EXTENSION ----------------------------------------------------- //
        public void registerExtension()
        {
            RegistryKey key1 = Registry.CurrentUser.OpenSubKey("Software", true);
            key1.CreateSubKey("Classes");
            key1 = key1.OpenSubKey("Classes", true);

            key1.CreateSubKey(".gt");
            key1 = key1.OpenSubKey(".gt", true);
            key1.SetValue("", "compilerSimulator.gt");

            key1.Close();
            ////////////////////////////////////////
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Software", true);
            key2.CreateSubKey("Classes");
            key2 = key2.OpenSubKey("Classes", true);

            key2.CreateSubKey("compilerSimulator.gt");
            key2 = key2.OpenSubKey("compilerSimulator.gt", true);
            key2.SetValue("", "Archive from Compiler Simulator");

            key2.CreateSubKey("DefaultIcon");
            key2 = key2.OpenSubKey("DefaultIcon", true);
            key2.SetValue("", Application.StartupPath + "\\Icon\\icon.ico");

            key2.Close();
            ////////////////////////////////////////
            RegistryKey key3 = Registry.CurrentUser.OpenSubKey("Software", true);
            key3.CreateSubKey("Classes");
            key3 = key3.OpenSubKey("Classes", true);

            key3.CreateSubKey("compilerSimulator.gt");
            key3 = key3.OpenSubKey("compilerSimulator.gt", true);
            key3.SetValue("", "Archive from Compiler Simulator");

            key3.CreateSubKey("shell");
            key3 = key3.OpenSubKey("shell", true);

            key3.CreateSubKey("open");
            key3 = key3.OpenSubKey("open", true);

            key3.CreateSubKey("command");
            key3 = key3.OpenSubKey("command", true);
            key3.SetValue("", "\"" + Application.StartupPath + "\\compiler-app.exe\" \"%1\"");

            key3.Close();
        }
    }
}
