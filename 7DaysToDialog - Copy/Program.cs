using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7DaysToDialog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //String strUpdateURL = "https://pastebin.com/raw/9auBiFn7";
            String strUpdateURL = "https://raw.githubusercontent.com/SphereII/Tools/master/7DaysToDialogInstaller/AutoUpdate.xml";
          //  AutoUpdater.ReportErrors = true;
            AutoUpdater.Start(strUpdateURL);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new frmMain());
        }
    }
}
