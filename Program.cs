using System;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WingetUpgradeNotification.Properties;

namespace MyTrayIconApp
{
    class Program
    {
        static NotifyIcon notifyIcon;

        static void Main(string[] args)
        {
            int available_upgrades = 0;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "winget";
            startInfo.Arguments = "upgrade";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                Match match = Regex.Match(output, @"\d+\s+upgrades\s+available");
                if (match.Success)
                {
                    int count = int.Parse(match.Value.TrimEnd(" upgrades available".ToCharArray()));
                    available_upgrades = count;
                }

                process.WaitForExit();
            }

            if (available_upgrades != 0)
            {
                // Create the NotifyIcon
                notifyIcon = new NotifyIcon();
                notifyIcon.Icon = Resources.downloads;
                notifyIcon.Text = $"{available_upgrades} pending upgrades";
                notifyIcon.Visible = true;

                // Handle events (e.g., double click, right click, balloon tip)
                notifyIcon.MouseClick += NotifyIcon_MouseClick;

                // Main application loop or other logic
                Application.Run();

            }
        } 

        private static void NotifyIcon_MouseClick(object sender, EventArgs e)
        {
            //exit application on right click, upgrade all on left click
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            else if (me.Button == MouseButtons.Left)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "winget";
                startInfo.Arguments = "upgrade --all";
                startInfo.UseShellExecute = true;
                startInfo.RedirectStandardOutput = false;
                startInfo.RedirectStandardError = false;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    process.Start();

                    process.WaitForExit();
                }

                Application.Exit();
            }

        }
    }
}