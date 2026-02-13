using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using LNetworkFileShare;
using System.Net;

namespace LocalNetworkFileShare
{
    public partial class MainMenu : Form
    {
        public event Action UpdateStyleDel;
        public int isProgramClosing = 0;
        public MainMenu()
        {
            InitializeComponent();
            button1.Parent = panel1;
            button2.Parent = panel1;
            button3.Parent = panel1;
            SetCurrentOptions();
            label3.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version}";
        }
        public void SetCurrentOptions() // Updating UI style
        {
            try
            {
                string mainConfigFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg"); // can throw exception
                string[] linesSpl = mainConfigFile.Split('\n');
                int index = 0;
                foreach (string line in linesSpl)
                {
                    string[] words = line.Split(' ');

                    if (words[0] == "Theme_UIstyle")
                    {
                        switch (words[1])
                        {
                            case "0":
                                panel1.BackColor = Color.FromArgb(224, 224, 224);
                                button1.BackColor = Color.White;
                                button1.ForeColor = Color.Black;
                                button2.BackColor = Color.White;
                                button2.ForeColor = Color.Black;
                                button3.BackColor = Color.White;
                                button3.ForeColor = Color.Black;
                                label1.ForeColor = Color.Black;
                                this.BackColor = SystemColors.Control;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                break;
                            case "1":
                                panel1.BackColor = Color.FromArgb(44, 44, 44);
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                button2.BackColor = Color.FromArgb(54, 54, 54);
                                button3.BackColor = Color.FromArgb(54, 54, 54);
                                button1.ForeColor = Color.White;
                                button2.ForeColor = Color.White;
                                button3.ForeColor = Color.White;
                                label1.ForeColor = Color.White;
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                label3.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                break;
                            case "2":
                                break;
                        }
                    }
                    if (words[0] == "UIText_language")
                    {
                        switch (words[1])
                        {
                            case "0":
                                button1.Text = "Connect to server";
                                button2.Text = "Create new server";
                                button3.Text = "Options";
                                label1.Text = "Local network file sharer";
                                button1.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Main menu";
                                break;
                            case "1":
                                button1.Text = "Подключиться к серверу";
                                button2.Text = "Создать новый сервер";
                                button3.Text = "Настройки";
                                label1.Text = "Файлообменник по \nлокальной сети";
                                button1.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Главное меню";
                                break;
                            case "2":
                                button1.Text = "Verbindung zum Server herstellen";
                                button2.Text = "Neuen Server erstellen";
                                button3.Text = "Option";
                                label1.Text = "Dateifreigabe im \nlokalen Netzwerk";
                                button1.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Hauptmenü";
                                break;
                            case "3":
                                button1.Text = "连接到服务器";
                                button2.Text = "创建新服务器";
                                button3.Text = "选项";
                                label1.Text = "本地网络文件共享";
                                button1.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "主菜单";
                                break;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", ""); // creating file
                SetCurrentOptions(); // restarting method 
            }
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }
    
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            isProgramClosing = 2;
            this.Close();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            isProgramClosing = 1;
            this.Close();
        }
        public void UpdateStyleTrg() // trigger for start updating UI style
        {
            UpdateStyleDel?.Invoke();
        }
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            MainOptions opts = new MainOptions();
            opts.parentCl = this;
            opts.Show();

        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            MITLicense licenseForm = new MITLicense();
            licenseForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            ReadmeForm form = new ReadmeForm(); 
            form.Show();
        }
    }
}
