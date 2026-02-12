namespace LocalNetworkFileShare
{
    partial class MainOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainOptions));
            vScrollBar1 = new VScrollBar();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            checkBox5 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label2 = new Label();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label1 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // vScrollBar1
            // 
            vScrollBar1.Cursor = Cursors.NoMoveVert;
            vScrollBar1.Location = new Point(1104, -1);
            vScrollBar1.Maximum = 20;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(28, 942);
            vScrollBar1.TabIndex = 0;
            vScrollBar1.ValueChanged += vScrollBar1_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBox5);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 15);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1076, 1030);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(699, 871);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(141, 55);
            button3.TabIndex = 16;
            button3.Text = "browse";
            button3.UseVisualStyleBackColor = true;
            button3.MouseClick += button3_MouseClick;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(9, 945);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(231, 72);
            button2.TabIndex = 15;
            button2.Text = "Upload";
            button2.UseVisualStyleBackColor = true;
            button2.MouseClick += button2_MouseClick;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(9, 878);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(683, 30);
            textBox2.TabIndex = 14;
            textBox2.Text = "Path to file";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(0, 795);
            label5.Name = "label5";
            label5.Size = new Size(327, 48);
            label5.TabIndex = 13;
            label5.Text = "Upload options file";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(9, 699);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(572, 35);
            textBox1.TabIndex = 12;
            textBox1.Text = "Device name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(3, 624);
            label4.Name = "label4";
            label4.Size = new Size(866, 25);
            label4.TabIndex = 11;
            label4.Text = "* - device name is name, which will be  showed on server control panel. This option is unnecessary.";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(-9, 545);
            label3.Name = "label3";
            label3.Size = new Size(240, 48);
            label3.TabIndex = 10;
            label3.Text = "Device name*";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Cursor = Cursors.Hand;
            checkBox5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox5.Location = new Point(43, 468);
            checkBox5.Margin = new Padding(3, 4, 3, 4);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(207, 33);
            checkBox5.TabIndex = 9;
            checkBox5.Text = "中文 (chineese)";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            checkBox5.MouseClick += checkBox5_MouseClick;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Cursor = Cursors.Hand;
            checkBox3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox3.Location = new Point(43, 392);
            checkBox3.Margin = new Padding(3, 4, 3, 4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(230, 33);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "Deutsch (german)";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            checkBox3.MouseClick += checkBox3_MouseClick;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Cursor = Cursors.Hand;
            checkBox2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox2.Location = new Point(43, 322);
            checkBox2.Margin = new Padding(3, 4, 3, 4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(231, 33);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Русский (russian)";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox2.MouseClick += checkBox2_MouseClick;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox1.Location = new Point(43, 251);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(119, 33);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "English";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1.MouseClick += checkBox1_MouseClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(0, 162);
            label2.Name = "label2";
            label2.Size = new Size(179, 48);
            label2.TabIndex = 4;
            label2.Text = "Language";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Cursor = Cursors.Hand;
            radioButton3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Location = new Point(322, 94);
            radioButton3.Margin = new Padding(3, 4, 3, 4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(105, 33);
            radioButton3.TabIndex = 3;
            radioButton3.Text = "Win98";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.Visible = false;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Location = new Point(186, 94);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(90, 33);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "Light";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton1.Location = new Point(43, 94);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(88, 33);
            radioButton1.TabIndex = 1;
            radioButton1.Text = "Dark";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 14);
            label1.Name = "label1";
            label1.Size = new Size(137, 48);
            label1.TabIndex = 0;
            label1.Text = "Theme ";
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(843, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(232, 86);
            button1.TabIndex = 4;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_MouseClick;
            // 
            // MainOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 911);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(vScrollBar1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainOptions";
            Text = "Options";
            Load += MainOptions_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}