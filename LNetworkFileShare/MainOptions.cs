using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LocalNetworkFileShare
{
    public partial class MainOptions : Form
    {
        private const int StPosY = 12; // start position Y
        public MainMenu parentCl;
        public MainOptions()
        {
            InitializeComponent();
            radioButton1.Parent = panel1;
            radioButton2.Parent = panel1;
            radioButton3.Parent = panel1;
            checkBox1.Parent = panel1;
            checkBox2.Parent = panel1;
            checkBox3.Parent = panel1;
            checkBox5.Parent = panel1;
            label3.Parent = panel1;
            label4.Parent = panel1;
            textBox1.Parent = panel1;
            label5.Parent = panel1;
            textBox2.Parent = panel1;
            button2.Parent = panel1;
            button3.Parent = panel1;
            SetCurrentOptions(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
        }

        private void SetCurrentOptions(string path)
        {
            try
            {
                string mainConfigFile = File.ReadAllText(path); // if file doesn't exists will throw exception
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
                                radioButton2.Checked = true;
                                panel1.BackColor = SystemColors.Control;
                                button1.BackColor = Color.White;
                                button1.ForeColor = Color.Black;
                                label1.ForeColor = Color.Black;
                                radioButton1.ForeColor = Color.Black;
                                radioButton2.ForeColor = Color.Black;
                                radioButton3.ForeColor = Color.Black;
                                this.BackColor = SystemColors.Control;
                                label2.ForeColor = Color.Black;
                                checkBox1.ForeColor = Color.Black;
                                checkBox2.ForeColor = Color.Black;
                                checkBox3.ForeColor = Color.Black;
                                checkBox5.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                button2.BackColor = Color.White;
                                button2.ForeColor = Color.Black;
                                button3.BackColor = Color.White;
                                button3.ForeColor = Color.Black;
                                textBox1.BackColor = SystemColors.Window;
                                textBox2.BackColor = SystemColors.Window;
                                textBox1.ForeColor = Color.Black;
                                textBox2.ForeColor = Color.Black;
                                break;
                            case "1":
                                radioButton1.Checked = true;
                                panel1.BackColor = Color.FromArgb(34, 34, 34);
                                button1.BackColor = Color.FromArgb(54, 54, 54);
                                button1.ForeColor = Color.White;
                                label1.ForeColor = Color.White;
                                radioButton1.ForeColor = Color.White;
                                radioButton2.ForeColor = Color.White;
                                radioButton3.ForeColor = Color.White;
                                this.BackColor = Color.FromArgb(34, 34, 34);
                                label2.ForeColor = Color.White;
                                checkBox1.ForeColor = Color.White;
                                checkBox2.ForeColor = Color.White;
                                checkBox3.ForeColor = Color.White;
                                checkBox5.ForeColor = Color.White;
                                label3.ForeColor = Color.White;
                                label4.ForeColor = Color.White;
                                label5.ForeColor = Color.White;
                                button2.BackColor = Color.FromArgb(54, 54, 54);
                                button2.ForeColor = Color.White;
                                textBox1.BackColor = Color.FromArgb(54, 54, 54);
                                textBox2.BackColor = Color.FromArgb(54, 54, 54);
                                textBox1.ForeColor = Color.White;
                                textBox2.ForeColor = Color.White;
                                button3.BackColor = Color.FromArgb(54, 54, 54);
                                button3.ForeColor = Color.White;
                                break;
                            case "2":
                                radioButton3.Checked = true;
                                break;
                        }
                    }
                    else if (words[0] == "UIText_language")
                    {
                        switch (words[1])
                        {
                            case "0":
                                checkBox1.Checked = true;
                                checkBox1.Text = "English";
                                checkBox2.Text = "Русский (Russian)";
                                checkBox3.Text = "Deutsch (German)";
                                checkBox5.Text = "中文 (Chineese)";
                                label1.Text = "Theme";
                                label2.Text = "Language";
                                radioButton1.Text = "Dark";
                                radioButton2.Text = "Light";
                                radioButton3.Text = "Win98";
                                button1.Text = "Save";
                                button1.Font = new Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Options";
                                label3.Text = "Device name*";
                                label4.Text = "* - device name is name, which will be  showed on server control panel. This option is unnecessary.";
                                label5.Text = "Upload options file";
                                button2.Text = "Upload";
                                textBox2.Text = "Path to file";
                                this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button3.Text = "browse";
                                break;
                            case "1":
                                checkBox2.Checked = true;
                                checkBox1.Text = "English (Английский)";
                                checkBox2.Text = "Русский";
                                checkBox3.Text = "Deutsch (Немецкий)";
                                checkBox5.Text = "中文 (Китайский)";
                                label1.Text = "Тема";
                                label2.Text = "Язык";
                                radioButton1.Text = "Тёмная";
                                radioButton2.Text = "Светлая";
                                radioButton3.Text = "Вин98";
                                button1.Text = "Сохранить";
                                button1.Font = new Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Настройки";
                                label3.Text = "Имя устройства*";
                                label4.Text = "* - имя устройства - это имя, которое будет показываться на панели контроля сервера.\nЭта опция необязательна.";
                                label5.Text = "Загрузить файл настроек";
                                button2.Text = "Загрузить";
                                textBox2.Text = "Путь к файлу";
                                this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button3.Text = "обзор";
                                break;
                            case "2":
                                checkBox3.Checked = true;
                                checkBox1.Text = "English (Englisch)";
                                checkBox2.Text = "Русский (Russisch)";
                                checkBox3.Text = "Deutsch";
                                checkBox5.Text = "中文 (Chinesisch)";
                                label1.Text = "Thema";
                                label2.Text = "Sprachlich";
                                radioButton1.Text = "Dunkel";
                                radioButton2.Text = "Licht";
                                radioButton3.Text = "win98";
                                button1.Text = "Speichern";
                                button1.Font = new Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "Option";
                                label3.Text = "Gerätenamen*";
                                label4.Text = "* - gerätename ist der Name, der auf dem Bedienfeld des Servers angezeigt wird. \nDiese Option ist nicht erforderlich.";
                                label5.Text = "Datei mit den Upload-Optionen";
                                button2.Text = "Laden";
                                textBox2.Text = "Pfad zur Datei";
                                this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button3.Text = "durchsuchen";
                                break;
                            case "3":
                                checkBox5.Checked = true;
                                checkBox1.Text = "English (英语)";
                                checkBox2.Text = "Русский (俄语)";
                                checkBox3.Text = "Deutsch (德语)";
                                checkBox5.Text = "中文";
                                label1.Text = "主题";
                                label2.Text = "语言";
                                radioButton1.Text = "黑暗";
                                radioButton2.Text = "光";
                                radioButton3.Text = "win98";
                                button1.Text = "储蓄";
                                button1.Font = new Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                this.Text = "选项";
                                label3.Text = "设备名称*";
                                label4.Text = "* - 设备名称是名称，将显示在服务器控制面板上。 此选项是不必要的。";
                                label5.Text = "上传选项文件";
                                button2.Text = "上载";
                                textBox2.Text = "文件路径";
                                this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                button3.Text = "浏览";
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
                        textBox1.Text = res;
                    }
                }
            }
            catch (Exception exc)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", ""); // creating file
                SetCurrentOptions(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg"); // restarting function
            }
        }
        private void UpdateOptionsFile()
        {
            string resFile = "";

            resFile += "Theme_UIstyle ";
            if (radioButton1.Checked == true)
            {
                resFile += "1";
            }
            else if (radioButton2.Checked == true)
            {
                resFile += "0";
            }
            else if (radioButton3.Checked == true)
            {
                resFile += "2";
            }
            resFile += "\n";
            resFile += "UIText_language ";
            if (checkBox1.Checked == true)
            {
                resFile += "0";
            }
            else if (checkBox2.Checked == true)
            {
                resFile += "1";
            }
            else if (checkBox3.Checked == true)
            {
                resFile += "2";
            }
            else if (checkBox5.Checked == true)
            {
                resFile += "3";
            }
            resFile += "\n";
            resFile += $"Device_name {textBox1.Text}\n";

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg", resFile);
        }
        private void MainOptions_Load(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(8, StPosY - (vScrollBar1.Value * 7)); // scrolling
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Text = "Saving ...";
            UpdateOptionsFile();
            SetCurrentOptions(AppDomain.CurrentDomain.BaseDirectory + @"\mainConfig.cfg");
            parentCl.UpdateStyleDel += parentCl.SetCurrentOptions;
            parentCl.UpdateStyleTrg();
            button1.Text = "Save";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox5_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox1.Checked = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            SetCurrentOptions(textBox2.Text);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.cfg|";
            dialog.ShowDialog();
            textBox2.Text = dialog.FileName;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
