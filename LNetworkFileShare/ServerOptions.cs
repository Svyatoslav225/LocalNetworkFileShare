using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LNetworkFileShare
{
    public partial class ServerOptions : Form
    {
        public ServerOptions()
        {
            InitializeComponent();
            SetCurrentOptions();
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
                                label5.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label2.ForeColor = Color.Black;
                                label1.ForeColor = Color.Black;
                                button1.ForeColor = Color.Black;
                                button1.BackColor = SystemColors.Window;
                                textBox1.ForeColor = Color.Black;
                                textBox1.BackColor = SystemColors.Window;
                                textBox2.ForeColor = Color.Black;
                                textBox2.BackColor = SystemColors.Window;
                                textBox3.ForeColor = Color.Black;
                                textBox3.BackColor = SystemColors.Window;
                                checkBox1.ForeColor = Color.Black;
                                checkBox2.ForeColor = Color.Black;
                                checkBox3.ForeColor = Color.Black;
                                checkBox4.ForeColor = Color.Black;
                                this.BackColor = SystemColors.Control;
                                break;
                            case "1":
                                label5.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                label3.ForeColor = Color.White;
                                label2.ForeColor = Color.White;
                                label1.ForeColor = Color.White;
                                button1.ForeColor = Color.White;
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                textBox1.ForeColor = Color.White;
                                textBox1.BackColor = Color.FromArgb(54, 54, 54);
                                textBox2.ForeColor = Color.White;
                                textBox2.BackColor = Color.FromArgb(54, 54, 54);
                                textBox3.ForeColor = Color.White;
                                textBox3.BackColor = Color.FromArgb(54, 54, 54);
                                checkBox1.ForeColor = Color.White;
                                checkBox2.ForeColor = Color.White;
                                checkBox3.ForeColor = Color.White;
                                checkBox4.ForeColor = Color.White;
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                break;
                        }
                    }
                    if (words[0] == "UIText_language")
                    {
                        switch (words[1])
                        {
                            case "0":
                                label1.Text = "Port";
                                label2.Text = "Server type";
                                label3.Text = "Encoding";
                                label4.Text = "Password (if server is private)";
                                label5.Text = "Server name";
                                checkBox1.Text = "Public";
                                checkBox2.Text = "Private";
                                checkBox3.Text = "UTF-8";
                                checkBox4.Text = "TEA-v2";
                                button1.Text = "Save";
                                break;
                            case "1":
                                label1.Text = "Порт";
                                label2.Text = "Тип сервера";
                                label3.Text = "Кодировка";
                                label4.Text = "Пароль (если сервер приватный)";
                                label5.Text = "Имя сервера";
                                checkBox1.Text = "Публичный";
                                checkBox2.Text = "Приватный";
                                checkBox3.Text = "UTF-8";
                                checkBox4.Text = "TEA-v2";
                                button1.Text = "Сохранить";
                                break;
                            case "2":
                                label1.Text = "Port";
                                label2.Text = "Servertyp";
                                label3.Text = "Encoding";
                                label4.Text = "Passwort (wenn der Server privat ist)";
                                label5.Text = "Servernamen";
                                checkBox1.Text = "Öffentlich";
                                checkBox2.Text = "Privat";
                                checkBox3.Text = "UTF-8";
                                checkBox4.Text = "TEA-v2";
                                button1.Text = "Speichern";
                                break;
                            case "3":
                                label1.Text = "港口";
                                label2.Text = "服务器类型";
                                label3.Text = "编码";
                                label4.Text = "密码（如果服务器是私有的）";
                                label5.Text = "服务器名称";
                                checkBox1.Text = "公众人士";
                                checkBox2.Text = "私人";
                                checkBox3.Text = "UTF-8";
                                checkBox4.Text = "TEA-v2";
                                button1.Text = "储蓄";
                                break;
                        }
                    }
                    if (words[0] == "Server_port")
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
                        textBox1.Text = res;
                    }
                    if (words[0] == "Server_type")
                    {
                        if (words[1] == "0")
                        {
                            checkBox1.Checked = true;
                        }
                        else if (words[1] == "1")
                        {
                            checkBox2.Checked = true;
                        }
                       
                    }
                    if (words[0] == "Server_encoding")
                    {
                        if (words[1] == "0")
                        {
                            checkBox3.Checked = true;
                        }
                        else if (words[1] == "1")
                        {
                            checkBox4.Checked = true;
                        }
                    }
                    if (words[0] == "Server_password")
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
                        textBox2.Text = res;
                    }
                    if (words[0] == "Server_name")
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
                        textBox3.Text = res;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void SaveOptions()
        {
            try
            {
                string PrevFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
                string[] splttd = PrevFile.Split('\n');
                string res = "";
                for (int i = 0; i <= 2; i++)
                {
                    res += splttd[i] + "\n";
                }
                if (Convert.ToInt32(textBox1.Text) > 65535 || Convert.ToInt32(textBox1.Text) < 0)
                {
                    MessageBox.Show("Incorrect port", "Error");
                    return;
                }
                res += $"Server_port {textBox1.Text}\n";
                res += "Server_type ";
                if (checkBox1.Checked)
                {
                    res += "0\n";
                }
                else if (checkBox2.Checked)
                {
                    res += "1\n";
                }
                res += "Server_encoding ";
                if (checkBox3.Checked)
                {
                    res += "0\n";
                }
                else if (checkBox4.Checked)
                {
                    res += "1\n";
                }
                res += $"Server_password {textBox2.Text}\n";
                res += $"Server_name {textBox3.Text}\n";
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", res);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(),"Error"); };
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Checked = true;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = true;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            SaveOptions();
        }
    }
}
