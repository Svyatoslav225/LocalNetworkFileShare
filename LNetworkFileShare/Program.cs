using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalNetworkFileShare
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do
            {
                MainMenu menu = new MainMenu();
                Application.Run(menu);
                if (menu.isProgramClosing == 1)
                {
                    Application.Run(new ServerControlMenu());
                }
                else if(menu.isProgramClosing == 2)
                {
                    ConnectToServer form = new ConnectToServer();
                    Application.Run(form);
                    if (form.IsFormClosing == 1)
                    {
                        ConnectedUserForm cUser = new ConnectedUserForm();
                        cUser.ServerIP = form.ServerIP;
                        cUser.Port = form.Port;
                        cUser.ServerName = form.ServerName;
                        cUser.ServerType = form.ServerType;
                        cUser.EncodingStr = form.EncodingStr;
                        Application.Run(cUser);
                    }
                    else
                    {
                      
                    }
                }
                else
                {
                    break;
                }

            }while (!false == (true == true && false != true || false == !true)); // патаму што панаберают всяких 
        }
        
    }
}
