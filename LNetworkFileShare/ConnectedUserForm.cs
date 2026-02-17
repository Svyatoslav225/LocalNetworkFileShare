using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalNetworkFileShare
{
    public partial class ConnectedUserForm : Form
    {
        public string ServerIP = "";
        public int Port = 0;
        public string ServerName = "";
        public string ServerType = "";
        public string EncodingStr = "";
        Socket MainListener;
        List<CommitData> commits = new List<CommitData>();
      //  List<CommitCard> commitsVisual = new List<CommitCard>();
        public ConnectedUserForm()
        {
            InitializeComponent();
            SetCurrentOptions();
            DateTime timeG = DateTime.Now;
            richTextBox1.Text += $"{timeG.Hour}h:{timeG.Minute}m:{timeG.Second}s >> Connected;\n";
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
                                label1.ForeColor = Color.Black;
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                label6.ForeColor = Color.Black;
                                label7.ForeColor = Color.Black;
                                label8.ForeColor = Color.Black;
                                label9.ForeColor = Color.Black;
                                panel1.BackColor = Color.White;
                                panel2.BackColor = Color.White;
                                richTextBox1.BackColor = Color.White;
                                richTextBox1.ForeColor = Color.Black;
                                button1.BackColor = Color.White;
                                button1.ForeColor = Color.Black;
                                button2.ForeColor = Color.Black;
                                button2.BackColor = Color.White;
                                button3.BackColor = Color.Salmon;
                                button3.ForeColor = Color.Black;
                                textBox1.BackColor = Color.White;
                                textBox1.ForeColor = Color.Black;
                                textBox2.ForeColor = textBox1.ForeColor;
                                textBox2.BackColor = textBox1.BackColor;
                                button6.BackColor = button1.BackColor;
                                button6.ForeColor = button1.ForeColor;
                                this.BackColor = SystemColors.Control;
                                break;
                            case "1":
                                label1.ForeColor = Color.White;
                                label2.ForeColor = Color.White;
                                label3.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                label5.ForeColor = Color.White;
                                label6.ForeColor = Color.White;
                                label7.ForeColor = Color.White;
                                label8.ForeColor = Color.White;
                                label9.ForeColor = Color.White;
                                panel1.BackColor = Color.FromArgb(44, 44, 44);
                                panel2.BackColor = Color.FromArgb(44, 44, 44);
                                richTextBox1.BackColor = Color.FromArgb(44, 44, 44);
                                richTextBox1.ForeColor = Color.White;
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                button1.ForeColor = Color.White;
                                button2.ForeColor = Color.White;
                                button2.BackColor = Color.FromArgb(54, 54, 54);
                                button3.BackColor = Color.Maroon;
                                button3.ForeColor = Color.White;
                                textBox1.BackColor = Color.FromArgb(44, 44, 44);
                                textBox1.ForeColor = Color.White;
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                textBox2.ForeColor = textBox1.ForeColor;
                                textBox2.BackColor = textBox1.BackColor;
                                button6.BackColor = button1.BackColor;
                                button6.ForeColor = button1.ForeColor;
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
                                label1.Text = "About server";
                                label2.Text = "Server name: ";
                                label3.Text = "Server IP: ";
                                label4.Text = "Current port: ";
                                label5.Text = "Server type: ";
                                label6.Text = "Encoding: ";
                                label7.Text = "Upload file";
                                label8.Text = "System log:";
                                label9.Text = "Your device name:\n";
                                button2.Text = "View";
                                button1.Text = "Upload";
                                button3.Text = "Leave";
                                break;
                            case "1":
                                label1.Text = "О сервере";
                                label2.Text = "Имя сервера: ";
                                label3.Text = "IP сервера: ";
                                label4.Text = "Текущий порт: ";
                                label5.Text = "Тип сервера: ";
                                label6.Text = "Кодировка: ";
                                label7.Text = "Загрузить файл";
                                label8.Text = "Системный лог:";
                                label9.Text = "Имя этого устройсва:\n";
                                button2.Text = "Обзор";
                                button1.Text = "Загрузить";
                                button3.Text = "Выйти";
                                break;
                            case "2":
                                label1.Text = "Über den Server";
                                label2.Text = "Servernamen: ";
                                label3.Text = "Server IP: ";
                                label4.Text = "Aktueller Hafen: ";
                                label5.Text = "Servertyp: ";
                                label6.Text = "Encoding: ";
                                label7.Text = "Datei hochladen";
                                label8.Text = "Systemprotokoll:";
                                label9.Text = "Ihr Gerätename:\n";
                                button2.Text = "Blick";
                                button1.Text = "Laden";
                                button3.Text = "Verlassen";
                                break;
                            case "3":
                                label1.Text = "关于服务器";
                                label2.Text = "服务器名称: ";
                                label3.Text = "服务器IP: ";
                                label4.Text = "当前端口: ";
                                label5.Text = "服务器类型: ";
                                label6.Text = "编码: ";
                                label7.Text = "上传文件";
                                label8.Text = "系统日志:";
                                label9.Text = "您的设备名称:\n";
                                button2.Text = "查看";
                                button1.Text = "上载";
                                button3.Text = "离开";
                                break;
                        }
                    }
                    if (words[0] == "Device_name")
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
                        label9.Text += res;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task UpdateCommitsList()
        {
            IPAddress addr = IPAddress.Parse(ServerIP);
            string[] splSp = new string[0];
            try
            {
                using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {

                    await sock.ConnectAsync(addr, Port);
                    byte[] request = Encoding.UTF8.GetBytes("GACI");
                    await sock.SendAsync(request, 0);
                    byte[] buffer = new byte[4096];
                    int count = await sock.ReceiveAsync(buffer, 0);
                    string received = Encoding.UTF8.GetString(buffer, 0, count);
                    string[] splD = received.Split(":");
                    splSp = splD[1].Split(" ");
                    commits.Clear();
                    sock.Close();
                }

            }
            catch (Exception) { }
            for (int ind = 0; ind < splSp.Length; ind++)
            {
                if (splSp[ind] != "")
                {
                    try
                    {
                        using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                        {
                            await sock.ConnectAsync(addr, Port);
                            byte[] buffr = Encoding.UTF8.GetBytes($"SCP:{splSp[ind]}");
                            await sock.SendAsync(buffr, 0);
                            byte[] buffRecS = new byte[2048];
                            int countS = await sock.ReceiveAsync(buffRecS, 0);
                            string rec = Encoding.UTF8.GetString(buffRecS, 0, countS);
                            string[] splDo = rec.Split(":");
                            CommitData cd = new CommitData() { CommitID = splSp[ind], CommitName = splDo[1], bytesInFile = Convert.ToInt32(splDo[2]) };
                            commits.Add(cd);
                            sock.Close();
                        }
                    }
                    catch (Exception) { }
                }
            }
            panel4.Controls.Clear();
            int counter = 0;
            int PosY = 10;
            for (int ind = 0; ind < commits.Count; ind++)
            {
                if (counter == 2)
                {
                    CommitCard card = new CommitCard(new Point(490, PosY), panel4, commits[ind].CommitName, commits[ind].bytesInFile.ToString() + " bytes") { CommitId = commits[ind].CommitID, ServerIP = ServerIP, Port = Port, encoding = EncodingStr };
                    PosY += 150;
                    counter = 0;
                }
                else if (counter == 0)
                {
                    CommitCard card = new CommitCard(new Point(10, PosY), panel4, commits[ind].CommitName, commits[ind].bytesInFile.ToString() + " bytes") { CommitId = commits[ind].CommitID, ServerIP = ServerIP, Port = Port, encoding = EncodingStr };
                    counter++;
                }
                else if (counter == 1)
                {
                    CommitCard card = new CommitCard(new Point(250, PosY), panel4, commits[ind].CommitName, commits[ind].bytesInFile.ToString() + " bytes") { CommitId = commits[ind].CommitID, ServerIP = ServerIP, Port = Port, encoding = EncodingStr };
                    counter++;
                }

            }
            panel4.Height = PosY + 300;
        }
        /*   private void StartThreads()
           {
               //ThreadStart mainListener = new ThreadStart(async delegate { await ListenToServer(); });
           }*/

        private async Task ListenToServer()
        {
            IPAddress addr = IPAddress.Parse(ServerIP);
            IPEndPoint EndP = new IPEndPoint(addr, Port);
            MainListener = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            await MainListener.ConnectAsync(EndP);

            byte[] buffReq = Encoding.UTF8.GetBytes("ASL");
            await MainListener.SendAsync(buffReq, 0);
            while (true)
            {
                byte[] bufferRec = new byte[4096];
                int count = await MainListener.ReceiveAsync(bufferRec, 0);
                string received = Encoding.UTF8.GetString(bufferRec, 0, count);
                switch (received)
                {
                    case "UPD":
                        this.Invoke( new Action(() => UpdateCommitsList()));   
                        break;
                    case "DD":

                        this.Close();
                        break;
                }
            }
        }

        private void ConnectedUserForm_Load(object sender, EventArgs e)
        {
            label2.Text += ServerName;
            label3.Text += ServerIP;
            label4.Text += Port.ToString();
            label5.Text += ServerType;
            label6.Text += EncodingStr;
            UpdateCommitsList();
            Task tsk = Task.Run(() => ListenToServer());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private async Task UploadFileToServer()
        {
            IPAddress addr = IPAddress.Parse(ServerIP);
            using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                if (EncodingStr == "UTF-8") {
                    try
                    {
                        await sock.ConnectAsync(addr, Port);
                        byte[] buffer = File.ReadAllBytes(textBox1.Text);
                        string[] fSpl = textBox1.Text.Split(".");
                        byte[] buff = Encoding.UTF8.GetBytes($"UFTS:{buffer.Length}:15:{fSpl[1]}:{textBox2.Text}");
                        await sock.SendAsync(buff, 0);
                        byte[] buffRec = new byte[512];
                        int count = await sock.ReceiveAsync(buffRec, 0);
                        string txtRec = Encoding.UTF8.GetString(buffRec, 0, count);
                        if (txtRec == "RD")
                        {
                            await sock.SendAsync(buffer, 0);
                        }
                        buffer = new byte[0];
                        sock.Close();
                    }
                    catch (Exception) { MessageBox.Show("File uploading exception", "Error", MessageBoxButtons.OK); }
                }else if (EncodingStr == "TEA-v2")
                {
                    try
                    {
                        await sock.ConnectAsync(addr, Port);
                        byte[] bufferF = File.ReadAllBytes(textBox1.Text);
                        EncryptedFile buffer = TEAv2.FileToBuffer(bufferF);
                        string[] fSpl = textBox1.Text.Split(".");
                        byte[] buff = Encoding.UTF8.GetBytes($"UFTS:{buffer.fileBuffer.Length}:15:{fSpl[1]}:{textBox2.Text}");
                        await sock.SendAsync(buff, 0);
                        byte[] KeyBuff = Encoding.UTF8.GetBytes(buffer.Key);
                        await sock.SendAsync(KeyBuff,0);
                        byte[] buffRec = new byte[512];
                        int count = await sock.ReceiveAsync(buffRec, 0);
                        string txtRec = Encoding.UTF8.GetString(buffRec, 0, count);
                        if (txtRec == "RD")
                        {
                            await sock.SendAsync(buffer.fileBuffer, 0);
                        }
                        buffer = null;
                        sock.Close();
                    }
                    catch (Exception) { }
                }         
            }
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            UploadFileToServer();
            DateTime timeG = DateTime.Now;
            richTextBox1.Text += $"{timeG.Hour}h:{timeG.Minute}m:{timeG.Second}s >> File was uploaded to server;\n";
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                textBox1.Text = dialog.FileName;
            }
        }
        private async Task disconn() // disconnect
        {
            IPAddress addr = IPAddress.Parse(ServerIP);
            using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress address = entry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                await sock.ConnectAsync(addr, Port);
                byte[] buffer = Encoding.UTF8.GetBytes($"DD:{address}");
                await sock.SendAsync(buffer, 0);
                sock.Close();
            }
        }
        private void ConnectedUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconn();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        int locY = 3;
        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            locY -= 20;
            panel4.Location = new Point(3, locY);
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            locY += 20;
            panel4.Location = new Point(3, locY);
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateCommitsList();
            DateTime timeG = DateTime.Now;
            richTextBox1.Text += $"{timeG.Hour}h:{timeG.Minute}m:{timeG.Second}s >> Commits list updated;\n";
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("This logger isn't completely done :(", "info");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    class CommitCard
    {
        public string CommitId = "";
        public string ServerIP = "";
        public int Port = 0;
        public string encoding = "";
        public CommitCard(Point Location,Control par, string CommitName, string Weight)
        {
            Panel backGround = new Panel() { Parent = par,BackColor = Color.White,Location = Location,Size = new Size(210,100)};
            Label name = new Label() { Text = CommitName,ForeColor = Color.Black,Parent = backGround, Location = new Point(10,10),Size = new Size(180,20)};
            Label weight = new Label() { Text = Weight, ForeColor = Color.Black,Parent = backGround, Location = new Point(10, 30), Size = new Size(180,20)};
            name.Click += new EventHandler(Click);
            name.Cursor = Cursors.Hand;
            backGround.Show();
            name.Show();
            weight.Show();
        }
        private void Click(object sender,EventArgs e)
        {
            clickFunc();
        }
        private async Task clickFunc()
        {
            string path = Interaction.InputBox("Path to save:", "Saving");
            try
            {
                if (path != "") {
                    IPAddress addr = IPAddress.Parse(ServerIP);
                    using (Socket sock = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                    {
                        await sock.ConnectAsync(addr, Port);
                        byte[] buffer1 = Encoding.UTF8.GetBytes($"GFFS:{CommitId}");
                        await sock.SendAsync(buffer1, 0);
                        byte[] buffer2 = new byte[1024];
                        int count = await sock.ReceiveAsync(buffer2, 0);
                        string rec1 = Encoding.UTF8.GetString(buffer2, 0, count);
                        string[] recSpl = rec1.Split(":");
                        byte[] bufferRec = new byte[Convert.ToInt32(recSpl[1])];
                        if (encoding == "UTF-8") {
                            try
                            {
                                for (int counts = 0; counts <= Convert.ToInt32(recSpl[2]); counts++)
                                {
                                    int countT = await sock.ReceiveAsync(bufferRec, 0);
                                    sock.Close();
                                }
                            }
                            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }
                        } else if (encoding == "TEA-v2")
                        {

                            byte[] KeyBuff = new byte[1024];
                            int countS = await sock.ReceiveAsync(KeyBuff, 0);
                            string keyStr = Encoding.UTF8.GetString(KeyBuff, 0, countS);
                            try
                            {
                                for (int counts = 0; counts <= Convert.ToInt32(recSpl[2]); counts++)
                                {
                                    int countT = await sock.ReceiveAsync(bufferRec, 0);
                                    sock.Close();
                                }
                            }
                            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }
                            try
                            {
                                EncryptedFile file = new EncryptedFile() { Key = keyStr, fileBuffer = bufferRec };
                                bufferRec = TEAv2.BufferToFile(file);
                                file = null;
                            } catch (Exception) { }
                        }
                        File.WriteAllBytes($"{path}.{recSpl[3]}", bufferRec);
                        bufferRec = new byte[0];
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
