using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;

//auth
//using KeyAuth;

//my files
using recoil_helper;
using recoil_data;
using dev_help;
using rust_recoil_script;

namespace rust_recoil_script
{
    class Program
    {

        #region random
        private static Random random = new Random();
        public static string random_string(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Title = random_string(10);
            Console.ForegroundColor = ConsoleColor.Red;

            if (av_check())
            {
                MessageBox.Show("THIS TOOL USES METHODS FOR PROTECTION THAT CAUSE RED FLAGS (DISABLE ANTIVIRUS)");
                //Environment.Exit(0);
            }
            if (security())
            {
                MessageBox.Show("DO NOT USE TOOLS KNOWN FOR REVERSE ENGINEERING (FOR PUNISHMENT YOU WILL NOW BE RAIDED BY THE FBI)");
                Process.Start("www.fbi.gov");
                Environment.Exit(0);
            }
            else
            {
                file_exists_check();

                Console.WriteLine("dev options [y/n]: ");
                string debug_option = Console.ReadLine();

                Console.WriteLine("Loading GUI... ");

               // System.Threading.Thread thread = new System.Threading.Thread(show_form);
                //thread.Start();

                while (true)
                {
                    if (security())
                    {
                        MessageBox.Show("DO NOT USE TOOLS KNOWN FOR REVERSE ENGINEERING (FOR PUNISHMENT YOU WILL NOW BE RAIDED BY THE FBI)");
                        Process.Start("www.google.com");
                    }

                    if (debug_option == "y")
                    {
                        string pos_debug = cursor_pos.get_cur_pos().ToString();
                        Console.WriteLine(pos_debug);
                        if (check buttons)
                            File.WriteAllText("debug.txt", File.ReadAllText("debug.txt") + pos_debug);
                    }

                    double sleep = (recoil.get_current_weapon_delay() / recoil.get_smooth()) * recoil.get_current_attachment()[1];
                    recoil_do(recoil.get_current_weapon_table().Length, sleep);
                }
            }
        }

        public static void recoil_do(int shots, double sleep)
        {
            if (check buttons)
            {
                try
                {
                    for (int q = 0; q < shots; q++)
                    {
                        double x_recoil = ((recoil.get_current_weapon_table()[q, 0] / 2) / recoil.get_sense()) * recoil.get_current_attachment()[0] * recoil.scope();
                        double y_recoil = ((recoil.get_current_weapon_table()[q, 1] / 2) / recoil.get_sense()) * recoil.get_current_attachment()[0] * recoil.scope();

                        for (int qq = 0; qq < recoil.get_smooth(); qq++) //repeats for smooth times
                        {
                            int move_x = Convert.ToInt32(x_recoil / recoil.get_smooth());
                            int move_y = Convert.ToInt32(y_recoil / recoil.get_smooth());
                            move_do(move_x, move_y);
                            System.Threading.Thread.Sleep(Convert.ToInt32(sleep));
                        }
                    }
                }catch{}
            }
        }

        public static void move_do(int relx, int rely)
        {
            mouse_event(0x0001, relx, rely, 0, 0);
        }

        public static void file_exists_check()
        {
            if (!File.Exists("attachments.ini"))
                File.Create("attachments.ini");
            if (!File.Exists("scope.ini"))
                File.Create("scope.ini");
            if (!File.Exists("sense.ini"))
                File.Create("sense.ini");
            if (!File.Exists("smooth.ini"))
                File.Create("smooth.ini");
            if (!File.Exists("weapon.ini"))
                File.Create("weapon.ini");
        }

        public static bool av_check()
        {
            if (Process.GetProcessesByName("navapsvc").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("mcshield").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("ashServ").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("avgemc").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("msmpeng").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("mbam").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("mbamtray").FirstOrDefault() != null)
                return true;

            return false;
        }

        public static bool security()
        {
            if (Process.GetProcessesByName("cheatengine-x86_64").FirstOrDefault() != null)
                return true;
            else if (Process.GetProcessesByName("dnSpy").FirstOrDefault() != null)
                return true;

            return false;
        }
        
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        [DllImport("USER32.dll")]
        static extern short GetKeyState(int nVirtKey);
    }
}
