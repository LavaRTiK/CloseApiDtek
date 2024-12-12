using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace Svitlo.Component
{
    public class AutoStartUp
    {
        public void CreateShortcut()
        {
            string systemStartUp = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(systemStartUp, "Svitlo.lnk");
            string iconPath = "molnia.ico";
            string targetPath = Application.ExecutablePath;
            string workingDirictory = Path.GetDirectoryName(targetPath); 
            WshShell wshShell = new WshShell();
            IWshShortcut shortcut = wshShell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = workingDirictory;
            shortcut.IconLocation = Path.Combine(Path.GetDirectoryName(targetPath),iconPath);
            shortcut.Save();
        }
        public void DeleteShortcut()
        {
            System.IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup),"Svitlo.lnk"));
        }
        public void SwitchShortcut()
        {
            if (CheckShortcut())
            {
                DeleteShortcut();
            }
            else
            {
                CreateShortcut();
            }
        }
        public bool CheckShortcut()
        {
            if (System.IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Svitlo.lnk"))){
                return true;
            }
            {
                return false;
            }
        }
    }
}
