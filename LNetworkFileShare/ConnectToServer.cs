using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace LocalNetworkFileShare
{
    public partial class ConnectToServer : Form
    {
        public int IsFormClosing = 0;
        int StPosY = 3;

        public string ServerIP = "";
        public int Port = 0;
        public string ServerName = "";
        public string ServerType = "";
        public string EncodingStr = "";

        public delegate void UpdateUserListDel(string[] ServerNames, string[] IPs, int[] Ports);
        public ConnectToServer()
        {
            InitializeComponent();
            //     panel2.Parent = panel1;
            SetCurrentOptions();
            //     vScrollBar1.Visible = false;
        }

        private void SetCurrentOptions()
        {
            try
            {
                string mainConfigFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
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
                                this.BackColor = SystemColors.Control;
                                //  label1.ForeColor = Color.Black;
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                label6.ForeColor = Color.Black;
                                label7.ForeColor = Color.Black;
                                label8.ForeColor = Color.Black;
                                //  panel1.BackColor = Color.White;
                                //  panel2.BackColor = Color.White;
                                textBox1.BackColor = Color.White;
                                textBox2.BackColor = Color.White;
                                textBox3.BackColor = Color.White;
                                textBox4.BackColor = Color.White;
                                textBox1.ForeColor = Color.Black;
                                textBox2.ForeColor = Color.Black;
                                textBox3.ForeColor = Color.Black;
                                textBox4.ForeColor = Color.Black;
                                button1.BackColor = Color.White;
                                button2.BackColor = Color.White;
                                button1.ForeColor = Color.Black;
                                button2.ForeColor = Color.Black;
                                panel3.BackColor = Color.White;
                                break;
                            case "1":
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                // label1.ForeColor = Color.White;
                                label2.ForeColor = Color.White;
                                label3.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                label5.ForeColor = Color.White;
                                label6.ForeColor = Color.White;
                                label7.ForeColor = Color.White;
                                label8.ForeColor = Color.White;
                                //  panel1.BackColor = Color.FromArgb(44, 44, 44);
                                //  panel2.BackColor = Color.FromArgb(44, 44, 44);
                                textBox1.BackColor = Color.FromArgb(44, 44, 44);
                                textBox2.BackColor = Color.FromArgb(44, 44, 44);
                                textBox3.BackColor = Color.FromArgb(44, 44, 44);
                                textBox4.BackColor = Color.FromArgb(44, 44, 44);
                                textBox1.ForeColor = Color.White;
                                textBox2.ForeColor = Color.White;
                                textBox3.ForeColor = Color.White;
                                textBox4.ForeColor = Color.White;
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                button2.BackColor = Color.FromArgb(54, 54, 54);
                                button1.ForeColor = Color.White;
                                button2.ForeColor = Color.White;
                                panel3.BackColor = Color.FromArgb(44, 44, 44);
                                break;
                            case "2":

                                break;
                        }
                    }
                    else if (words[0] == "UIText_language")
                    {
                        switch (words[1])
                        {
                            case "0":
                                // label1.Text = "Public servers";
                                label2.Text = "Connect to server";
                                label3.Text = "Server IP:";
                                label4.Text = "Port:";
                                label5.Text = "Password:";
                                label6.Text = "Device name";
                                label7.Text = "Your current device name:\n";
                                label8.Text = "Change your device name:";
                                button1.Text = "Connect";
                                button2.Text = "Change";
                                break;
                            case "1":
                                // label1.Text = "Публичные сервера";
                                label2.Text = "Подключиться к серверу";
                                label3.Text = "IP сервера:";
                                label4.Text = "Порт:";
                                label5.Text = "Пароль:";
                                label6.Text = "Имя устройства";
                                label7.Text = "Текущее имя твоего устройства:\n";
                                label8.Text = "Поменять имя устройства:";
                                button1.Text = "Подключиться";
                                button2.Text = "Поменять";
                                break;
                            case "2":
                                // label1.Text = "Öffentliche Server";
                                label2.Text = "Verbindung zum Server herstellen";
                                label3.Text = "Server IP:";
                                label4.Text = "Port:";
                                label5.Text = "Passwort:";
                                label6.Text = "Gerätenamen";
                                label7.Text = "Ihr aktueller Gerätename:\n";
                                label8.Text = "Ändern Sie Ihren Gerätenamen:";
                                button1.Text = "Verbinden";
                                button2.Text = "Ändern";
                                break;
                            case "3":
                                //   label1.Text = "公共服务器";
                                label2.Text = "连接到服务器";
                                label3.Text = "服务器 IP:";
                                label4.Text = "港口:";
                                label5.Text = "密码:";
                                label6.Text = "设备名称";
                                label7.Text = "您当前的设备名称:\n";
                                label8.Text = "更改设备名称:";
                                button1.Text = "连接";
                                button2.Text = "改变";
                                break;
                        }
                    }
                    else if (words[0] == "Device_name")
                    {
                        string[] spl = line.Split(' ');
                        string res = "";
                        for (int i = 0; i < spl.Length; i++)
                        {
                            if (i != 0)
                            {
                                res += spl[i] + " ";
                            }
                        }
                        label7.Text += res;
                    }
                }
            }
            catch (Exception exc)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", ""); // creating file
                SetCurrentOptions(); // restarting function
            }
        }
        private void ConnectToServer_Load(object sender, EventArgs e)
        {

        }
        public void SumbitChanges(string[] ServerNames, string[] IPs, int[] Ports)
        {
            for (int ind = 0; ind < ServerNames.Length; ind++)
            {
                MessageBox.Show($"{ServerNames[ind]}\n{IPs[ind]}\n{Ports[ind]}");
            }
        }
        private void UpdatePublicServersList()
        {
            ThreadStart updateThreadSt = new ThreadStart(async delegate { await UpdatePSlistThread(this); });
            Thread updateThread = new Thread(updateThreadSt);
            updateThread.Start();
        }
        static async Task UpdatePSlistThread(ConnectToServer currentClass)
        {
            string[] ips = NetworkFuncs.GetLocalIPaddrs();
            List<string> ServerNames = new List<string>();
            List<string> IPs = new List<string>();
            List<int> Ports = new List<int>();
            for (int ind = 0; ind < ips.Length; ind++)
            {
                IPAddress addr = IPAddress.Parse(ips[ind]);
                for (int port = 0; port <= 65535; port++)
                {
                    IPEndPoint point = new IPEndPoint(addr, port);
                    using (Socket sock = new Socket(point.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                    {
                        try
                        {
                            byte[] buffer = Encoding.UTF8.GetBytes("ADTSL");
                            await sock.SendAsync(buffer, 0);
                            byte[] bufferRec = new byte[4096];
                            int received = await sock.ReceiveAsync(bufferRec);
                            string Text = Encoding.UTF8.GetString(bufferRec, 0, received);
                            ServerNames.Add(Text);
                            IPs.Add(IPs[ind]);
                            Ports.Add(port);
                        }
                        catch (Exception) { }
                    }
                }
            }
            currentClass.Invoke(new UpdateUserListDel(currentClass.SumbitChanges), new object[] { ServerNames.ToArray(), IPs.ToArray(), Ports.ToArray() });
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel1_Move(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            /*  if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
              {
                  int step = e.OldValue - e.NewValue;
                  panel2.Location = new Point(8, StPosY - (step * 7));
              }*/
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            //  panel2.Location = new Point(8, StPosY - (vScrollBar1.Value * 7));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private async Task ConnectToServ()
        {
            try
            {
                IPAddress addr = IPAddress.Parse(textBox1.Text);
                IPEndPoint EndP = new IPEndPoint(addr, Convert.ToInt32(textBox2.Text));
                string responcs = "";
                using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {
                    await sock.ConnectAsync(EndP);
                    byte[] buffer0 = Encoding.UTF8.GetBytes("GCSI");
                    await sock.SendAsync(buffer0, 0);
                    byte[] buffer1 = new byte[1024];
                    int count = await sock.ReceiveAsync(buffer1,0);
                    responcs = Encoding.UTF8.GetString(buffer1,0,count);
                }
                string textInFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
                string[] spl1 = textInFile.Split('\n');
                string[] spl2 = spl1[2].Split(" ");
                string res = "";
                for (int i = 0; i < spl2.Length; i++)
                {
                    if (i != 0)
                    {
                        res += spl2[i] + " ";
                    }
                }
                using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {
                    await sock.ConnectAsync(EndP);
                    string[] spl = responcs.Split(":");
                    if (spl[3] == "0")
                    {
                        ServerType = "Public";
                        ServerName = spl[1];
                        Port = Convert.ToInt32(textBox2.Text);
                        ServerIP = textBox1.Text;
                          if (spl[2] == "0")
                        {
                            EncodingStr = "UTF-8";
                        }
                        else
                        {
                            EncodingStr = "TEA-v2";
                        }

                        byte[] bufferPub = Encoding.UTF8.GetBytes($"CNUPu:{res}"); 
                        await sock.SendAsync(bufferPub, 0);
                        byte[] bufferRec2 = new byte[1024];
                        int count2 = await sock.ReceiveAsync(bufferRec2, 0);
                        string responce2 = Encoding.UTF8.GetString(bufferRec2, 0, count2);
                        if (responce2 == "AG")
                        {
                            IsFormClosing = 1;
                            this.Close();
                        }
                    }
                    else if (spl[3] == "1") // server is private
                    {
                        ServerType = "Private";
                        ServerName = spl[1];
                        Port = Convert.ToInt32(textBox2.Text);
                        ServerIP = textBox1.Text;
                        if (spl[2] == "0")
                        {
                            EncodingStr = "UTF-8";
                        }
                        else
                        {
                            EncodingStr = "TEA-v2";
                        }

                        byte[] bufferPriv = Encoding.UTF8.GetBytes($"CNUPr:{res}:{textBox3.Text}");
                        await sock.SendAsync(bufferPriv, 0);
                        byte[] bufferRec2 = new byte[1024];
                        int count2 = await sock.ReceiveAsync(bufferRec2, 0);
                        string responce2 = Encoding.UTF8.GetString(bufferRec2, 0, count2);
                        if (responce2 == "AG")
                        {
                            IsFormClosing = 1;
                            this.Close();
                        }
                    }
                }
             
            }
            catch (Exception)
            {

            }
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            ConnectToServ();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
            string[] spl1 = text.Split('\n');
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", $"{spl1[0]}\n{spl1[1]}\nDevice_name {textBox4.Text}\n{spl1[3]}\n{spl1[4]}\n{spl1[5]}\n{spl1[6]}\n{spl1[7]}");
            SetCurrentOptions();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdatePublicServersList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
