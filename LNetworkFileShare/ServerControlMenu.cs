using LNetworkFileShare;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Nrbf;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace LocalNetworkFileShare
{
    public partial class ServerControlMenu : Form
    {
        public delegate void ServerMenuClassDel();
        Graphics panelGraphs;
        Pen defPen = new Pen(Color.White, 2);
        List<Point> points = new List<Point>();
        List<ConnectedDevice> devices = new List<ConnectedDevice>();
        List<CommitData> CommitsList = new List<CommitData>();
        List<Socket> listeners = new List<Socket>();
        Thread thread0;
        Socket MainListener;
        CancellationTokenSource cancThread0 = new CancellationTokenSource();
        int ConnectionsNum = 0;
        int serverWeight = 0;
        string autoSavingPath = "";
        bool autoSaving = false;
        bool isServerPaused = false;
        public bool IsClassExist = true;

        public ServerControlMenu()
        {
            InitializeComponent();
            panelGraphs = panel2.CreateGraphics();
            richTextBox2.Parent = panel1;
            //FileInfo finfo = new FileInfo("");
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
                                label8.ForeColor = Color.Black;
                                label9.ForeColor = Color.Black;
                                label10.ForeColor = Color.Black;
                                label7.ForeColor = Color.Black;
                                label6.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label2.ForeColor = Color.Black;
                                label1.ForeColor = Color.Black;
                                label11.ForeColor = Color.White;
                                button6.BackColor = SystemColors.Window;
                                button6.ForeColor = Color.Black;
                                button5.BackColor = SystemColors.Window;
                                button5.ForeColor = Color.Black;
                                button7.ForeColor = Color.Black;
                                button7.BackColor = SystemColors.Window;
                                button5.ForeColor = Color.Black;
                                button5.BackColor = SystemColors.Window;
                                button4.ForeColor = Color.Black;
                                button4.BackColor = SystemColors.Window;
                                button3.ForeColor = Color.Black;
                                button3.BackColor = SystemColors.Window;
                                button2.ForeColor = Color.Black;
                                button2.BackColor = SystemColors.Window;
                                button1.ForeColor = Color.Black;
                                button1.BackColor = SystemColors.Window;
                                textBox1.ForeColor = Color.Black;
                                textBox1.BackColor = SystemColors.Window;
                                richTextBox1.ForeColor = Color.Black;
                                richTextBox1.BackColor = SystemColors.Window;
                                panel1.BackColor = Color.White;
                                panel2.BackColor = Color.White;
                                panel3.BackColor = Color.White;
                                panel4.BackColor = Color.LightCoral;
                                panel5.BackColor = Color.White;
                                panel6.BackColor = Color.White;
                                checkBox1.ForeColor = Color.Black;
                                checkBox2.ForeColor = Color.Black;
                                checkBox3.ForeColor = Color.White;
                                this.BackColor = SystemColors.Control;
                                button8.ForeColor = Color.Black;
                                button8.BackColor = Color.White;
                                defPen = new Pen(Color.Black, 2);
                                label12.ForeColor = Color.Black;
                                break;
                            case "1":
                                label8.ForeColor = Color.White;
                                label9.ForeColor = Color.White;
                                label10.ForeColor = Color.White;
                                label7.ForeColor = Color.White;
                                label6.ForeColor = Color.White;
                                label5.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                label3.ForeColor = Color.White;
                                label2.ForeColor = Color.White;
                                label11.ForeColor = Color.White;
                                label1.ForeColor = Color.White;
                                button6.BackColor = Color.FromArgb(54, 54, 54);
                                button6.ForeColor = Color.White;
                                button5.BackColor = Color.FromArgb(54, 54, 54);
                                button5.ForeColor = Color.White;
                                button7.ForeColor = Color.White;
                                button7.BackColor = Color.FromArgb(54, 54, 54);
                                button5.ForeColor = Color.White;
                                button5.BackColor = Color.FromArgb(54, 54, 54);
                                button4.ForeColor = Color.White;
                                button4.BackColor = Color.FromArgb(54, 54, 54);
                                button3.ForeColor = Color.White;
                                button3.BackColor = Color.FromArgb(54, 54, 54);
                                button2.ForeColor = Color.White;
                                button2.BackColor = Color.FromArgb(54, 54, 54);
                                button1.ForeColor = Color.White;
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                textBox1.ForeColor = Color.White;
                                textBox1.BackColor = Color.FromArgb(54, 54, 54);
                                richTextBox1.ForeColor = Color.White;
                                richTextBox1.BackColor = Color.FromArgb(44, 44, 44);
                                panel1.BackColor = Color.FromArgb(44, 44, 44);
                                panel2.BackColor = Color.FromArgb(44, 44, 44);
                                panel3.BackColor = Color.FromArgb(44, 44, 44);
                                panel4.BackColor = Color.Maroon;
                                panel5.BackColor = Color.FromArgb(44, 44, 44);
                                panel6.BackColor = Color.FromArgb(44, 44, 44);
                                checkBox1.ForeColor = Color.White;
                                checkBox2.ForeColor = Color.White;
                                checkBox3.ForeColor = Color.White;
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                button8.ForeColor = Color.White;
                                button8.BackColor = Color.FromArgb(54, 54, 54);
                                defPen = new Pen(Color.White, 2);
                                label12.ForeColor = Color.White;
                                break;
                            case "2":

                                break;
                        }
                        richTextBox2.BackColor = richTextBox2.Parent.BackColor;
                        richTextBox2.ForeColor = button1.ForeColor;
                        label13.ForeColor = label1.ForeColor;
                    }
                    else if (words[0] == "UIText_language")
                    {
                        switch (words[1])
                        {
                            case "0":
                                label1.Text = "Connected devices:";
                                label2.Text = "Connections:";
                                label6.Text = "Security";
                                label7.Text = "Storage info";
                                label8.Text = "IP: ";
                                label9.Text = "Port: ";
                                label10.Text = "Console";
                                label11.Text = "Dangerous zone";
                                button1.Text = "Clear";
                                button2.Text = "Save";
                                button3.Text = "Delete all connections";
                                button4.Text = "Pause server";
                                button5.Text = "Start";
                                button6.Text = "Server options";
                                button7.Text = "Send";
                                checkBox1.Text = "Auto-saving";
                                checkBox2.Text = "Anti-DDoS system";
                                checkBox3.Text = "Enable";
                                checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button8.Text = "Clear";
                                break;
                            case "1":
                                label1.Text = "Подключённые устройства:";
                                label2.Text = "Подключённые сокеты:";
                                label6.Text = "Безопасность";
                                label7.Text = "Информация о хранилище";
                                label8.Text = "IP: ";
                                label9.Text = "Port: ";
                                label10.Text = "Консоль";
                                label11.Text = "Опасная зона";
                                button1.Text = "Очистить";
                                button2.Text = "Сохранить";
                                button3.Text = "Разорвать все подключения";
                                button4.Text = "Временно остановить работу сервера";
                                button5.Text = "Начать";
                                button6.Text = "Настройки сервера";
                                button7.Text = "Отправить";
                                checkBox1.Text = "Авто-сохранение";
                                checkBox2.Text = "Анти-DDoS система";
                                checkBox3.Text = "Включить";
                                checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button8.Text = "Очистить";
                                break;
                            case "2":
                                label1.Text = "Verbundene Geräte:";
                                label2.Text = "Netzwerkverbindungen:";
                                label6.Text = "Sicherheit";
                                label7.Text = "Lagerinfo";
                                label8.Text = "IP: ";
                                label9.Text = "Port: ";
                                label10.Text = "Konsole";
                                label11.Text = "Gefährliche Zone";
                                button1.Text = "Klar";
                                button2.Text = "Speichern";
                                button3.Text = "Alle Verbindungen löschen";
                                button4.Text = "Server pausieren";
                                button5.Text = "Beginnen";
                                button6.Text = "Serveroptionen";
                                button7.Text = "Senden";
                                checkBox1.Text = "Automatisches Speichern";
                                checkBox2.Text = "Anti-DDoS system";
                                checkBox3.Text = "Aktivieren";
                                checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button8.Text = "Klar";
                                break;
                            case "3":
                                label1.Text = "连接设备:";
                                label2.Text = "联系:";
                                label6.Text = "保安";
                                label7.Text = "储存资料";
                                label8.Text = "IP: ";
                                label9.Text = "Port: ";
                                label10.Text = "控制台";
                                label11.Text = "危险地带";
                                button1.Text = "清楚";
                                button2.Text = "储蓄";
                                button3.Text = "删除所有连接";
                                button4.Text = "暂停服务器";
                                button5.Text = "开始";
                                button6.Text = "服务器选项";
                                button7.Text = "发送";
                                checkBox1.Text = "自动储蓄";
                                checkBox2.Text = "DDoS系统";
                                checkBox3.Text = "启用";
                                checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button8.Text = "清楚";
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
                        // textBox1.Text = res;
                    }
                }
            }
            catch (Exception exc)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", ""); // creating file
                SetCurrentOptions(); // restarting function
            }
        }
        private void ServerControlMenu_Load(object sender, EventArgs e)
        {
            SetCurrentOptions();
            label13.Text = $"Server weight:\n {serverWeight} bytes";
        }

        protected internal async Task MainListening()
        {
            string Settings = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
            string[] nLspl = Settings.Split("\n");
            ServerInfo serverinfo = new ServerInfo();
            for (int ind = 0; ind < nLspl.Length; ind++)
            {
                string[] wrdSpl = nLspl[ind].Split(" ");
                if (wrdSpl[0] == "Server_port")
                {
                    serverinfo.Port = Convert.ToInt32(wrdSpl[1]);
                }
                else if (wrdSpl[0] == "Server_type")
                {
                    serverinfo.type = Convert.ToUInt32(wrdSpl[1]);
                }
                else if (wrdSpl[0] == "Server_encoding")
                {
                    serverinfo.Encoding = Convert.ToUInt32((wrdSpl[1]));
                }
                else if (wrdSpl[0] == "Server_password")
                {
                    string res = "";
                    for (int i = 0; i < wrdSpl.Length; i++)
                    {
                        if (i != 0)
                        {
                            res += wrdSpl[i] + " ";
                        }
                    }
                    serverinfo.Password = res;
                }
                else if (wrdSpl[0] == "Server_name")
                {
                    string res = "";
                    for (int i = 0; i < wrdSpl.Length; i++)
                    {
                        if (i != 0)
                        {
                            res += wrdSpl[i] + " ";
                        }
                    }
                    serverinfo.ServerName = res;
                }
            }

            IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress addr = entry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            IPEndPoint endP = new IPEndPoint(addr, serverinfo.Port);
            MainListener = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            MainListener.Bind(endP);
            MainListener.Listen(serverinfo.Port);
            StartAllThreads();
            label8.Text = "IP: " + addr.ToString();
            label9.Text = "Port: " + endP.Port;
            while (true)
            {
                var handler = await MainListener.AcceptAsync();
                if (isServerPaused)
                { handler.Close(); }
                else
                {
                    ConnectionsNum++;
                    label12.Text = ConnectionsNum.ToString();
                    byte[] buffer = new byte[2048];
                    int received = await handler.ReceiveAsync(buffer, 0);
                    string responce = Encoding.UTF8.GetString(buffer, 0, received);
                    string[] DoublePointSplitted = responce.Split(":");
                    switch (DoublePointSplitted[0])
                    {
                        case "ADTSL":
                            if (serverinfo.type == 0)
                            {
                                byte[] buffr = Encoding.UTF8.GetBytes(serverinfo.ServerName);
                                await handler.SendAsync(buffr, 0);
                                DateTime timeA = DateTime.Now;
                                richTextBox1.Text += $"{timeA.Hour}h:{timeA.Minute}m:{timeA.Second}s >> ADTSL request received => accept;\n";
                            }
                            else
                            {
                                byte[] buffr = Encoding.UTF8.GetBytes("SIP"); // server is private
                                await handler.SendAsync(buffr, 0);
                                DateTime timeS = DateTime.Now;
                                richTextBox1.Text += $"{timeS.Hour}h:{timeS.Minute}m:{timeS.Second}s >> ADTSL request received => denied;\n";
                            }
                            break;
                        case "CNUPu":
                            ConnectedDevice device = new ConnectedDevice();
                            device.DeviceName = DoublePointSplitted[1];
                            IPEndPoint remoteEndPoint = (IPEndPoint)handler.RemoteEndPoint;
                            IPAddress deviceAddr = remoteEndPoint.Address;
                            device.IpAddress = deviceAddr.ToString();
                            devices.Add(device);
                            refreshDevicesList();
                            DateTime time = DateTime.Now;
                            richTextBox1.Text += $"{time.Hour}h:{time.Minute}m:{time.Second}s >> Connected new user: {device.DeviceName};\n";
                            byte[] buffrS = Encoding.UTF8.GetBytes("AG"); // access granted
                            await handler.SendAsync(buffrS, 0);
                            ConnectionsNum++;
                            label12.Text = ConnectionsNum.ToString();
                            break;
                        case "CNUPr":
                            if (DoublePointSplitted[2].Replace(" ", "") == serverinfo.Password.Replace(" ", ""))
                            {
                                ConnectedDevice deviceS = new ConnectedDevice();
                                deviceS.DeviceName = DoublePointSplitted[1];
                                IPEndPoint remoteEndPointS = (IPEndPoint)handler.RemoteEndPoint;
                                IPAddress deviceAddrS = remoteEndPointS.Address;
                                deviceS.IpAddress = deviceAddrS.ToString();
                                devices.Add(deviceS);
                                refreshDevicesList();
                                DateTime timeD = DateTime.Now;
                                richTextBox1.Text += $"{timeD.Hour}h:{timeD.Minute}m:{timeD.Second}s >> Connected new user: {deviceS.DeviceName};\n";
                                byte[] buffrT = Encoding.UTF8.GetBytes("AG"); // access granted
                                await handler.SendAsync(buffrT, 0);
                                ConnectionsNum++;
                                label12.Text = ConnectionsNum.ToString();
                            }
                            else
                            {
                                byte[] buffrT = Encoding.UTF8.GetBytes("AD"); // access denied
                                await handler.SendAsync(buffrT, 0);
                            }
                            break;
                        case "GCSI":
                            byte[] buffrF = Encoding.UTF8.GetBytes($"SCSI:{serverinfo.ServerName}:{serverinfo.Encoding}:{serverinfo.type}");
                            DateTime timeG = DateTime.Now;
                            richTextBox1.Text += $"{timeG.Hour}h:{timeG.Minute}m:{timeG.Second}s >> Information about server requested => accept;\n";
                            await handler.SendAsync(buffrF, 0);
                            break;
                        case "UFTS":
                            byte[] ansBuff = Encoding.UTF8.GetBytes("RD");
                            await handler.SendAsync(ansBuff, 0);
                            byte[] buffRec = new byte[Convert.ToInt32(DoublePointSplitted[1])];
                            for (int count = 0; count <= Convert.ToInt32(DoublePointSplitted[2]); count++)
                            {
                                await handler.ReceiveAsync(buffRec, 0);
                            }
                            CommitData data = new CommitData();
                            data.CommitID = CommitsList.Count.ToString();
                            data.bytesInFile = buffRec.Length;
                            data.CommitName = DoublePointSplitted[4];
                            data.pathToFileInServer = AppDomain.CurrentDomain.BaseDirectory + $@"\ServerData\Commit{data.CommitID}.{DoublePointSplitted[3]}";
                            CommitsList.Add(data);
                            serverWeight += data.bytesInFile;
                            label13.Text = $"Server weight:\n {serverWeight} bytes";
                            DateTime timeH = DateTime.Now;
                            richTextBox1.Text += $"{timeH.Hour}h:{timeH.Minute}m:{timeH.Second}s >> User uploaded file to server ({serverWeight.ToString()} bytes);\n";
                            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\ServerData\"))
                            {
                                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\ServerData\");
                                File.WriteAllBytes(data.pathToFileInServer, buffRec);
                            }
                            else
                            {
                                File.WriteAllBytes(data.pathToFileInServer, buffRec);
                            }
                            ansBuff = new byte[0];
                            buffRec = new byte[0];
                            /*      for (int index = 0;index < devices.Count;index++)
                                  {

                                  }*/
                            break;
                        case "GFFS":
                            byte[] FileBuffer = File.ReadAllBytes(CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer);
                            string[] spl = CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer.Split(".");
                            byte[] bufferF = Encoding.UTF8.GetBytes($"GFFS:{FileBuffer.Length}:15:{spl[2]}");
                            await handler.SendAsync(bufferF, 0);
                            await handler.SendAsync(FileBuffer, 0);
                            DateTime timeI = DateTime.Now;
                            richTextBox1.Text += $"{timeI.Hour}h:{timeI.Minute}m:{timeI.Second}s >> User downloaded file from server ({FileBuffer.Length} bytes);\n";
                            break;
                        case "GACI":
                            string ids = "";
                            for (int ind = 0; ind < CommitsList.Count; ind++)
                            {
                                if (CommitsList[ind].Status)
                                {
                                    ids += CommitsList[ind].CommitID + " ";
                                }
                            }
                            byte[] buffrFo = Encoding.UTF8.GetBytes($"GACI:{ids}");
                            await handler.SendAsync(buffrFo, 0);
                            DateTime timeJ = DateTime.Now;
                            richTextBox1.Text += $"{timeJ.Hour}h:{timeJ.Minute}m:{timeJ.Second}s >> User requested commit ids list => accept;\n";
                            break;
                        case "SCP":
                            CommitData CData = CommitsList[Convert.ToInt32(DoublePointSplitted[1])];
                            byte[] buffrFi = Encoding.UTF8.GetBytes($"SCP:{CData.CommitName}:{CData.bytesInFile}");
                            await handler.SendAsync(buffrFi, 0);
                            DateTime timeK = DateTime.Now;
                            richTextBox1.Text += $"{timeK.Hour}h:{timeK.Minute}m:{timeK.Second}s >> commit data sent (commit id - {DoublePointSplitted[1]});\n";
                            break;
                        case "DD":
                            ConnectedDevice device1 = new ConnectedDevice();
                            try
                            {
                                foreach (ConnectedDevice dev in devices)
                                {
                                    if (dev.IpAddress == DoublePointSplitted[1])
                                    {
                                        devices.Remove(dev);
                                        device1 = dev;
                                    }
                                }
                                refreshDevicesList();
                                richTextBox2.Refresh();
                                ConnectionsNum--;
                                DateTime timeL = DateTime.Now;
                                richTextBox1.Text += $"{timeL.Hour}h:{timeL.Minute}m:{timeL.Second}s >> disconnected user: IP - {device1.IpAddress}, Device name - {device1.DeviceName};\n";
                            }
                            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ richTextBox2.Text += " "; ConnectionsNum--; DateTime timeL = DateTime.Now; richTextBox1.Text += $"{timeL.Hour}h:{timeL.Minute}m:{timeL.Second}s >> disconnected user: IP - {device1.IpAddress}, Device name - {device1.DeviceName};\n"; }
                            break;
                        case "FD":

                            break;
                        case "ASL":
                            listeners.Add(handler);
                            break;
                    }
                    ConnectionsNum--;
                    label12.Text = ConnectionsNum.ToString();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void refreshDevicesList()
        {
            richTextBox2.Text = "";
            for (int ind = 0; ind < devices.Count; ind++)
            {
                richTextBox2.Text += devices[ind].DeviceName + "\n";
            }
        }
        public void UpdateAnalyticsPanel()
        {
            panel2.Refresh();
            if (points.Count == 0)
            {
                points.Add(new Point(430, 170));
            }
            points.Add(new Point(430, 170 - ConnectionsNum));
            Point[] pointArray = new Point[points.Count];
            for (int ind = 0; ind < points.Count; ind++)
            {
                pointArray[ind] = new Point(points[ind].X - 5, points[ind].Y);
                points[ind] = pointArray[ind];
            }
            if (points[points.Count - 1].Y > points[points.Count - 2].Y)
            {
                Pen defPenS = new Pen(Color.Red, 3);
                panelGraphs.DrawLines(defPenS, pointArray);
            }
            else if (points[points.Count - 1].Y < points[points.Count - 2].Y)
            {
                Pen defPenS = new Pen(Color.Green, 3);
                panelGraphs.DrawLines(defPenS, pointArray);
            }
            else
            {
                panelGraphs.DrawLines(defPen, pointArray);
            }


        }
        static void AnalyticsUpdateController(ServerControlMenu currentClass)
        {
            while (currentClass.IsClassExist)
            {
                try
                {
                    if (!currentClass.cancThread0.IsCancellationRequested)
                    {
                        Thread.Sleep(500);
                        currentClass.Invoke(currentClass.UpdateAnalyticsPanel, new object[] { });
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        private void StartAllThreads()
        {
            ThreadStart thread0Starter = new ThreadStart(delegate { AnalyticsUpdateController(this); });
            thread0 = new Thread(thread0Starter);
            thread0.IsBackground = true;
            thread0.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            MainListening();
            button5.Visible = false;
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            ServerOptions options = new ServerOptions();
            options.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime timeG = DateTime.Now;
            richTextBox1.Text += $"{timeG.Hour}h:{timeG.Minute}m:{timeG.Second}s >> Server started;\n";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //   asd-=2;
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            points.Clear();
        }

        private void ServerControlMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClassExist = false;
            cancThread0.Cancel();
            try
            {
                string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\ServerData\");
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\ServerData\");
            }
            catch (Exception) { }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            refreshDevicesList();
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Sorry, console isn't working at this moment.", ":(");
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            string path = Interaction.InputBox("Full file name:", "Saving");
            File.WriteAllText(path, richTextBox1.Text);
        }

        private void richTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Here is one bug with connected\ndevices at this moment, so I'll fix it.\n(In next patch)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //  MessageBox.Show("This logger isn't completely done :(", "info");
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                autoSavingPath = Interaction.InputBox("Full file name:", "Creating save file");
                if (autoSavingPath != "")
                {
                    autoSaving = true;
                }
                else
                {
                    autoSaving = false;
                    checkBox1.Checked = false;
                }
            }
            else
            {
                autoSavingPath = "";
                autoSaving = false;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (autoSaving)
            {
                try
                {
                    File.WriteAllText(autoSavingPath, richTextBox1.Text); // if file path is wrong - it will catch exception
                }
                catch (Exception) { }

            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked)
            {
                if (!isServerPaused)
                {
                    isServerPaused = true;
                    // ConnectionsNum -= devices.Count;
                    button4.BackColor = Color.OrangeRed;
                    DateTime timeL = DateTime.Now;
                    richTextBox1.Text += $"{timeL.Hour}h:{timeL.Minute}m:{timeL.Second}s >> Server paused;\n";

                }
                else
                {
                    isServerPaused = false;
                    //  ConnectionsNum += devices.Count;
                    button4.BackColor = panel3.BackColor;
                    DateTime timeL = DateTime.Now;
                    richTextBox1.Text += $"{timeL.Hour}h:{timeL.Minute}m:{timeL.Second}s >> Server started;\n";

                }
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked)
            {
               DeleteAllConnections();
                DateTime timeL = DateTime.Now;
                richTextBox1.Text += $"{timeL.Hour}h:{timeL.Minute}m:{timeL.Second}s >>  All connections have been deleted;\n";
            }
        }
        private async Task DeleteAllConnections()
        {
            byte[] buffer = Encoding.UTF8.GetBytes("DD");
            for (int ind = 0; ind < listeners.Count; ind++)
            {
                await listeners[ind].SendAsync(buffer,0);
            }
        }
    }
    class ServerInfo
    {
        public string ServerName = "";
        public string ServerIP = "";
        public int Port = 0;
        public uint Encoding = 0;
        public uint type = 0;
        public string Password = "";
    }
    class ConnectedDevice
    {
        public string DeviceName = "";
        public string IpAddress = "";
    }
    class NetworkFuncs 
    {
        [DllImport("netapi32.dll", EntryPoint = "NetServerEnum")]
        public static extern NERR NetServerEnum([MarshalAs(UnmanagedType.LPWStr)] string ServerName, int Level, out IntPtr BufPtr, int PrefMaxLen, ref int EntriesRead, ref int TotalEntries,SV_101_TYPES ServerType, [MarshalAs(UnmanagedType.LPWStr)]string Domain, int ResumeHandle);

        [DllImport("netapi32.dll", EntryPoint = "NetApiBufferFree")]
        public static extern NERR NetApiBufferFree(IntPtr Buffer);
       
        [StructLayout(LayoutKind.Sequential)]
        public struct SERVER_INFO_101
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint sv101_platform_id;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string sv101_name;
            [MarshalAs(UnmanagedType.U4)]
            public uint sv101_version_major;
            [MarshalAs(UnmanagedType.U4)]
            public uint sv101_version_minor;
            [MarshalAs(UnmanagedType.U4)]
            public uint sv101_type;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string sv101_comment;
        }
        public enum NERR
        {
            NERR_Success = 0,
            ERROR_ACCESS_DENIED = 5,
            ERROR_NOT_ENOUGH_MEMORY = 8,
            ERROR_BAD_NETPATH = 53,
            ERROR_NETWORK_BUSY = 54,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_INVALID_LEVEL = 124,
            ERROR_MORE_DATA = 234,
            ERROR_EXTENDED_ERROR = 1208,
            ERROR_NO_NETWORK = 1222,
            ERROR_INVALID_HANDLE_STATE = 1609,
            ERROR_NO_BROWSER_SERVERS_FOUND = 6118,
        }

        [Flags]
        public enum SV_101_TYPES : uint
        {
            SV_TYPE_WORKSTATION = 0x00000001,
            SV_TYPE_SERVER = 0x00000002,
            SV_TYPE_SQLSERVER = 0x00000004,
            SV_TYPE_DOMAIN_CTRL = 0x00000008,
            SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,
            SV_TYPE_TIME_SOURCE = 0x00000020,
            SV_TYPE_AFP = 0x00000040,
            SV_TYPE_NOVELL = 0x00000080,
            SV_TYPE_DOMAIN_MEMBER = 0x00000100,
            SV_TYPE_PRINTQ_SERVER = 0x00000200,
            SV_TYPE_DIALIN_SERVER = 0x00000400,
            SV_TYPE_XENIX_SERVER = 0x00000800,
            SV_TYPE_SERVER_UNIX = SV_TYPE_XENIX_SERVER,
            SV_TYPE_NT = 0x00001000,
            SV_TYPE_WFW = 0x00002000,
            SV_TYPE_SERVER_MFPN = 0x00004000,
            SV_TYPE_SERVER_NT = 0x00008000,
            SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
            SV_TYPE_BACKUP_BROWSER = 0x00020000,
            SV_TYPE_MASTER_BROWSER = 0x00040000,
            SV_TYPE_DOMAIN_MASTER = 0x00080000,
            SV_TYPE_SERVER_OSF = 0x00100000,
            SV_TYPE_SERVER_VMS = 0x00200000,
            SV_TYPE_WINDOWS = 0x00400000,
            SV_TYPE_DFS = 0x00800000,
            SV_TYPE_CLUSTER_NT = 0x01000000,
            SV_TYPE_TERMINALSERVER = 0x02000000,
            SV_TYPE_CLUSTER_VS_NT = 0x04000000,
            SV_TYPE_DCE = 0x10000000,
            SV_TYPE_ALTERNATE_XPORT = 0x20000000,
            SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,
            SV_TYPE_DOMAIN_ENUM = 0x80000000,
            SV_TYPE_ALL = 0xFFFFFFFF,
        }

        public static List<string> GetServerList(SV_101_TYPES type)  // testing
        {
            SERVER_INFO_101 si;
            IntPtr pInfo = IntPtr.Zero;
            int etriesread = 0;
            int totalentries = 0;
            List<string> srvrs = new List<string>();
            try
            {
                NERR err = NetServerEnum(null, 101, out pInfo, -1, ref etriesread, ref totalentries, SV_101_TYPES.SV_TYPE_ALL, null, 0);
                if ((err == NERR.NERR_Success || err == NERR.ERROR_MORE_DATA) && pInfo != IntPtr.Zero)
                {
                    int ptr = pInfo.ToInt32();
                    for (int i = 0; i < etriesread; i++)
                    {
                        si = (SERVER_INFO_101)Marshal.PtrToStructure(new IntPtr(ptr), typeof(SERVER_INFO_101));
                        srvrs.Add(si.sv101_name.ToString());

                        ptr += Marshal.SizeOf(si);
                    }
                }
            }
            catch (Exception exc) { MessageBox.Show($"Error {exc.Message}"); }
            finally
            { 
                if (pInfo != IntPtr.Zero) NetApiBufferFree(pInfo);
            }
            return srvrs;
        }
        public static string[] GetLocalIPaddrs()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            List<string> ips = new List<string>();
            foreach (var ip in host.AddressList)
            { 
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ips.Add(ip.ToString());
                }
            }
            return ips.ToArray();
        }
    }
    class CommitData
    {
        public string CommitID = "";
        public string CommitName = "";
        public int bytesInFile = 0;
        public string pathToFileInServer = "";
        public bool Status = true;
    }
}

/*
-Def:

ADTSL = add server to servers list;
CNU Pu/Pr = connect new user Public/Private;
G/S CSI = get/set current server info;
UFTS = upload files to server;
GFFS = get files from server;
SCP = send commit package;
GACI = get all commit ids;
FD = file delete;
DD = disconnect device;
ALS = add listener socket;

-Packages:
ADTSL построение: ADTSL:[Server name];
CNUPu построение: CNUPu:[Device name];
CNUPr построение: CNUPr:[Device name]:[Password];
GCSI построение: GCSI:[Server name]:[Encoding]:[Type];
SCSI построение: SCSI:[Server name]:[Encoding]:[Type];
UFTS построение: UFTS:[Encoding]:[buffer packets numb]:[file type]:[Commit name];
GFFS построение: GFFS:[Encoding]:[buffer packets numb]:[file type]; getter: GFFS:[commit id];
SCP построение: SCP:[commit name]:[file weight in bytes];getter: SCP:[commit id]
GACI построение: GACI:[commit ids list(spl by ' ')];
FD построение: FD:[commit id];
DD построение: DD:[ip];
ALS построение: ALS;
 */


