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
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1 && args[0] == "INSTALLER")
                {
                    try
                    {
                        Process.Start("explorer.exe", Application.ExecutablePath);
                    }
                    catch (Exception exx)
                    {
                    }

                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Starting Application: " + ex.ToString());
            }
        }
    }
}
