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
                        richTextBox3.BackColor = richTextBox1.BackColor;
                        richTextBox3.ForeColor = richTextBox1.ForeColor;
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
                            if (serverinfo.Encoding == 0) {
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
                                byte[] UpdBuffr = Encoding.UTF8.GetBytes("UPD");
                                try
                                {
                                    for (int ind = 0; ind < listeners.Count; ind++)
                                    {
                                        await listeners[ind].SendAsync(UpdBuffr, 0);
                                    }
                                }
                                catch (Exception) { }

                                ansBuff = new byte[0];
                                buffRec = new byte[0];
                            }else if (serverinfo.Encoding == 1)
                            {
                                byte[] ansBuff = Encoding.UTF8.GetBytes("RD");
                                byte[] KeyBuffer = new byte[1024];
                                int countk = await handler.ReceiveAsync(KeyBuffer,0);
                                string Key = Encoding.UTF8.GetString(KeyBuffer,0,countk);
                                byte[] buffRecB = new byte[Convert.ToInt32(DoublePointSplitted[1])];
                                await handler.SendAsync(ansBuff, 0);
                                for (int count = 0; count <= Convert.ToInt32(DoublePointSplitted[2]); count++)
                                {
                                    await handler.ReceiveAsync(buffRecB, 0);
                                }
                                byte[] buffRec = new byte[0];
                                try
                                {
                                    EncryptedFile fEnc = new EncryptedFile() { fileBuffer = buffRecB, Key = Key };
                                    buffRec = TEAv2.BufferToFile(fEnc);
                                    fEnc = null;
                                }
                                catch (Exception) { }
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
                                byte[] UpdBuffr = Encoding.UTF8.GetBytes("UPD");
                                try
                                {
                                    for (int ind = 0; ind < listeners.Count; ind++)
                                    {
                                        await listeners[ind].SendAsync(UpdBuffr, 0);
                                    }
                                }
                                catch (Exception) { }

                                ansBuff = new byte[0];
                                buffRec = new byte[0];
                            }
                            /*      for (int index = 0;index < devices.Count;index++)
                                  {

                                  }*/
                            break;
                        case "GFFS":
                            try
                            {
                                if (serverinfo.Encoding == 0) {
                                    byte[] FileBuffer = File.ReadAllBytes(CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer);
                                    string[] spl = CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer.Split(".");
                                    byte[] bufferF = Encoding.UTF8.GetBytes($"GFFS:{FileBuffer.Length}:15:{spl[2]}");
                                    await handler.SendAsync(bufferF, 0);
                                    await handler.SendAsync(FileBuffer, 0);
                                    DateTime timeI = DateTime.Now;
                                    richTextBox1.Text += $"{timeI.Hour}h:{timeI.Minute}m:{timeI.Second}s >> User downloaded file from server ({FileBuffer.Length} bytes);\n";
                                    FileBuffer = new byte[0];
                                }
                                else if (serverinfo.Encoding == 1)
                                {
                                    byte[] FileBuffer = File.ReadAllBytes(CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer);
                                    EncryptedFile encF = TEAv2.FileToBuffer(FileBuffer);
                                    string[] spl = CommitsList[Convert.ToInt32(DoublePointSplitted[1])].pathToFileInServer.Split(".");
                                    byte[] bufferF = Encoding.UTF8.GetBytes($"GFFS:{encF.fileBuffer.Length}:15:{spl[2]}");
                                    await handler.SendAsync(bufferF, 0);
                                    byte[] keyBuff = Encoding.UTF8.GetBytes(encF.Key);
                                    Thread.Sleep(10);
                                    await handler.SendAsync(keyBuff,0);
                                    await handler.SendAsync(encF.fileBuffer, 0);
                                    DateTime timeI = DateTime.Now;
                                    FileBuffer = new byte[0];
                                    richTextBox1.Text += $"{timeI.Hour}h:{timeI.Minute}m:{timeI.Second}s >> User downloaded file from server ({encF.fileBuffer.Length} bytes);\n";
                                    encF = null;
                                }  
                            }catch (Exception) { }
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
        string ConsoleText = "";
        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Sorry, console isn't working at this moment.", ":(");
            string[] textSpl = textBox1.Text.Split(" ");
            ConsoleText += $"{textBox1.Text}\n";
            switch (textSpl[0])
            {
                case "help":
                    ConsoleText += "Commands:\n - disconn_dev [device IP] // disconnect device\n - del_comm '[commit name]' // delete commit\n - dev_info '[device name]' // device information\n - dis_comms // disable all commits\n - en_comms // enable all commits\n - tot_mem_cln // total memory clean\n";
                    break;
                case "disconn_dev":
                    DisconnectDevice(textSpl[1]);
                    break;
                case "del_comm":
                    string[] splD = textBox1.Text.Split("'");

                    DeleteCommit(splD[1]);
                    ConsoleText += $"Commit {splD[1]} was deleted;\n";
                    break;
                case "dev_info":
                    string[] splDd = textBox1.Text.Split("'");
                    int DeviceIndex = 0;
                    for (int indx = 0;indx < devices.Count;indx++)
                    {
                        if (devices[indx].DeviceName == splDd[1])
                        {
                            DeviceIndex = indx;
                        }
                    }
                    ConsoleText += $"Information about '{splDd[1]}':\n IP: {devices[DeviceIndex].IpAddress};\n Device name: {devices[DeviceIndex].DeviceName};\n";
                    break;
                case "dis_comms":
                    ChangeCommitsStatus(false);
                    ConsoleText += $"All commits were disabled\n";
                    break;
                case "en_comms":
                    ChangeCommitsStatus(true);
                    ConsoleText += $"All commits were enabled\n";
                    break;
                case "tot_mem_cln":
                    points.Clear();
                    richTextBox1.Text = "Cleared;";
                    // in the future i'll add more 
                    ConsoleText += $"Memory was cleaned\n";
                    break;
            }
            richTextBox3.Text = ConsoleText;
        }
        private async Task ChangeCommitsStatus(bool status)
        {
            try
            {
                int index = 0;
                foreach (CommitData comm in CommitsList)
                {
                    CommitsList[index].Status = status;
                    byte[] UpdBuffr = Encoding.UTF8.GetBytes("UPD");
                    try
                    {
                        for (int ind = 0; ind < listeners.Count; ind++)
                        {
                            await listeners[ind].SendAsync(UpdBuffr, 0);
                        }
                    }
                    catch (Exception) { }
                    index++;
                }
            }
            catch (Exception) { }
        }
        private async Task DeleteCommit(string commitName)
        {
            try
            {
                int index = 0;
                foreach (CommitData comm in CommitsList)
                {
                    if (comm.CommitName == commitName)
                    {
                        CommitsList[index].Status = false;
                        File.Delete(comm.pathToFileInServer);
                        byte[] UpdBuffr = Encoding.UTF8.GetBytes("UPD");
                        try
                        {
                            for (int ind = 0; ind < listeners.Count; ind++)
                            {
                                await listeners[ind].SendAsync(UpdBuffr, 0);
                            }
                        }
                        catch (Exception) { }
                    }
                    index++;
                }
            }
            catch (Exception) { }
        }
        private async Task DisconnectDevice(string IP)
        {
            try
            {
                foreach (Socket sock in listeners)
                {
                    IPEndPoint remoteIp = (IPEndPoint)sock.RemoteEndPoint;
                    IPAddress addr = remoteIp.Address;
                    if (addr.ToString() == IP)
                    {
                        byte[] buffr = Encoding.UTF8.GetBytes("DD");
                        await sock.SendAsync(buffr, 0);
                        ConsoleText += $"IP {IP} was disconnected;\n";
                        break;
                    }
                }
            }
            catch (Exception) { ConsoleText += $"Error, IP {IP} doesn't exists;\n"; }
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
                await listeners[ind].SendAsync(buffer, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
    class TEAv2
    {
        public static EncryptedText EncryptTEAv2s1(string textToEncrypt) // version of TEA with randomized split symbols
        {
            EncryptedText Result = new EncryptedText();
            string[] symbols = new string[] {
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","#","@","%","$","|","*","!","/","^",
                "1","2","3","4","5","6","7","8","9","0"
            };
            string[] keyArr = new string[22];
            string readyKeyStr = "";
            for (int ind = 0; ind < 22; ind++) // creating Key
            {
                bool DoWhile = true;
                string symb = "";
                while (DoWhile)
                {
                    bool Error = false;
                    Random random = new Random();
                    symb = symbols[random.Next(0, symbols.Length)];
                    for (int ind2 = 0; ind2 < 22; ind2++)
                    {
                        if (keyArr[ind2] == symb)
                        {
                            Error = true;
                            break;
                        }
                    }
                    if (!Error)
                    {
                        DoWhile = false;
                    }
                }
                //keyArr[ind] = symb;
                keyArr[ind] = symb;
                Result.Key += symb; // writing key into string from result class
            }
            readyKeyStr = Result.Key;
            char[] symbolsArray = textToEncrypt.ToCharArray();
            string[] SymbolList = new string[] {
                    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v",
                    "w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
                    "S","T","U","V","W","X","Y","Z","1","2","3","4","5","6","7","8","9","0",".",",","!",":",
                    "?","#","@","*","-","=","+","/","а","б","в","г","д","е","ё","ж","з","и","й","к","л","м",
                    "н","о","п","р","с","т","у","ф","х","ц","ш","щ","ъ","ы","ь","э","ю","я","А","Б","В","Г",
                    "Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ш","Щ",
                    "Ъ","Ы","Ь","Э","Ю","Я"," ","\n"
                };
            int index = 0;
            foreach (char symb in symbolsArray)
            {
                int indexInSList = 0;
                for (int indOfSymb = 0; indOfSymb < SymbolList.Length; indOfSymb++)
                {
                    if (symb.ToString() == SymbolList[indOfSymb])
                    {
                        indexInSList = indOfSymb;
                    }
                }
                indexInSList++;
                string BinaryNum = Convert.ToString(indexInSList, 2);
                char[] splittedBinaryNum = BinaryNum.ToCharArray();
                string NumInSymbols = "";
                for (int indexOfNum = 0; indexOfNum < splittedBinaryNum.Length; indexOfNum++)
                {
                    switch (splittedBinaryNum[indexOfNum])
                    {
                        case '0':
                            switch (indexOfNum)
                            {
                                case 0:
                                    NumInSymbols += keyArr[0] + keyArr[20];
                                    break;
                                case 1:
                                    NumInSymbols += keyArr[1] + keyArr[20];
                                    break;
                                case 2:
                                    NumInSymbols += keyArr[2] + keyArr[20];
                                    break;
                                case 3:
                                    NumInSymbols += keyArr[3] + keyArr[20];
                                    break;
                                case 4:
                                    NumInSymbols += keyArr[4] + keyArr[20];
                                    break;
                                case 5:
                                    NumInSymbols += keyArr[5] + keyArr[20];
                                    break;
                                case 6:
                                    NumInSymbols += keyArr[6] + keyArr[20];
                                    break;
                                case 7:
                                    NumInSymbols += keyArr[7] + keyArr[20];
                                    break;
                                case 8:
                                    NumInSymbols += keyArr[8] + keyArr[20];
                                    break;
                                case 9:
                                    NumInSymbols += keyArr[9] + keyArr[20];
                                    break;
                            }
                            break;
                        case '1':
                            switch (indexOfNum)
                            {
                                case 0:
                                    NumInSymbols += keyArr[10] + keyArr[20];
                                    break;
                                case 1:
                                    NumInSymbols += keyArr[11] + keyArr[20];
                                    break;
                                case 2:
                                    NumInSymbols += keyArr[12] + keyArr[20];
                                    break;
                                case 3:
                                    NumInSymbols += keyArr[13] + keyArr[20];
                                    break;
                                case 4:
                                    NumInSymbols += keyArr[14] + keyArr[20];
                                    break;
                                case 5:
                                    NumInSymbols += keyArr[15] + keyArr[20];
                                    break;
                                case 6:
                                    NumInSymbols += keyArr[16] + keyArr[20];
                                    break;
                                case 7:
                                    NumInSymbols += keyArr[17] + keyArr[20];
                                    break;
                                case 8:
                                    NumInSymbols += keyArr[18] + keyArr[20];
                                    break;
                                case 9:
                                    NumInSymbols += keyArr[19] + keyArr[20];
                                    break;
                            }
                            break;
                    }
                }
                Result.Encrypted += NumInSymbols + keyArr[21];
            }
            return Result;
        }

        public static string DecrtyptTEAv2s1(EncryptedText encryptedText)
        {
            string Result = "";
            char[] keySymbolsChr = encryptedText.Key.ToCharArray();
            string[] keySymbols = new string[22];
            for (int index = 0; index < 22; index++)
            {
                keySymbols[index] = keySymbolsChr[index].ToString();
            }
            string[] symbols = encryptedText.Encrypted.Split(keySymbols[21]);
            foreach (string symb in symbols)
            {
                if (symb != null && symb != "" && symb != " ")
                {
                    string[] numsInLetters = symb.Split(keySymbols[20]);
                    List<string> indexes = new List<string>();
                    string[] SymbolList = new string[] {
                    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v",
                    "w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
                    "S","T","U","V","W","X","Y","Z","1","2","3","4","5","6","7","8","9","0",".",",","!",":",
                    "?","#","@","*","-","=","+","/","а","б","в","г","д","е","ё","ж","з","и","й","к","л","м",
                    "н","о","п","р","с","т","у","ф","х","ц","ш","щ","ъ","ы","ь","э","ю","я","А","Б","В","Г",
                    "Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ш","Щ",
                    "Ъ","Ы","Ь","Э","Ю","Я"," ","\n"
                };
                    string binaryIndexStr = "";
                    string[] binaryIndexChr = new string[10];
                    for (int indx = 0; indx < numsInLetters.Length; indx++)
                    {
                        if (numsInLetters[indx] != "" && numsInLetters[indx] != " " && numsInLetters[indx] != null)
                        {
                            /* switch (numsInLetters[indx])
                             {
                                 case :

                                     break;
                             }*/
                            if (numsInLetters[indx] == keySymbols[0])
                            {
                                binaryIndexChr[0] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[1])
                            {
                                binaryIndexChr[1] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[2])
                            {
                                binaryIndexChr[2] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[3])
                            {
                                binaryIndexChr[3] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[4])
                            {
                                binaryIndexChr[4] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[5])
                            {
                                binaryIndexChr[5] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[6])
                            {
                                binaryIndexChr[6] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[7])
                            {
                                binaryIndexChr[7] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[8])
                            {
                                binaryIndexChr[8] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[9])
                            {
                                binaryIndexChr[9] = "0";
                            }
                            else if (numsInLetters[indx] == keySymbols[10])
                            {
                                binaryIndexChr[0] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[11])
                            {
                                binaryIndexChr[1] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[12])
                            {
                                binaryIndexChr[2] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[13])
                            {
                                binaryIndexChr[3] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[14])
                            {
                                binaryIndexChr[4] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[15])
                            {
                                binaryIndexChr[5] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[16])
                            {
                                binaryIndexChr[6] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[17])
                            {
                                binaryIndexChr[7] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[18])
                            {
                                binaryIndexChr[8] = "1";
                            }
                            else if (numsInLetters[indx] == keySymbols[19])
                            {
                                binaryIndexChr[9] = "1";
                            }
                        }
                    }
                    binaryIndexStr = "";
                    foreach (string chr in binaryIndexChr)
                    {
                        if (chr != null && chr != " ")
                        {
                            binaryIndexStr += chr.ToString();
                        }
                    }
                    long DecIndex = Convert.ToInt64(binaryIndexStr, 2);
                    DecIndex--;
                    Result += SymbolList[DecIndex];
                }
            }
            return Result;
        }
        public static EncryptedFile FileToBuffer(byte[] file)
        {
            string fileStr = "";
            for (int ind = 0;ind < file.Length;ind++)
            {
                fileStr += file[ind].ToString() + " ";
            }
             EncryptedFile fileEnc = new EncryptedFile();
            EncryptedText text = TEAv2.EncryptTEAv2s1(fileStr);
            fileEnc.Key = text.Key;
            fileEnc.fileBuffer = Encoding.UTF8.GetBytes(text.Encrypted);
            return fileEnc;
        }
        public static byte[] BufferToFile(EncryptedFile file)
        {
            EncryptedText Fileintext = new EncryptedText() { Key = file.Key,Encrypted = Encoding.UTF8.GetString(file.fileBuffer)};
            string text = TEAv2.DecrtyptTEAv2s1(Fileintext);
            string[] textSpl = text.Split(" ");
            byte[] fileInbytes = new byte[textSpl.Length-1];
            for (int ind = 0; ind < textSpl.Length;ind++)
            {
                if(textSpl[ind] != "")
                {
                    fileInbytes[ind] = Convert.ToByte(textSpl[ind]);
                }
            }
            return fileInbytes;
        }
    }
    class EncryptedFile
    {
        public byte[] fileBuffer;
        public string Key = "";
    }
    class EncryptedText
    {
        protected internal string Encrypted = "";
        protected internal string Key = "";
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


