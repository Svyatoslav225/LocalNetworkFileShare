namespace LocalNetworkFileShare
{
    partial class ConnectedUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectedUserForm));
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            textBox2 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label7 = new Label();
            richTextBox1 = new RichTextBox();
            label8 = new Label();
            button3 = new Button();
            label9 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 15);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(607, 380);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(13, 318);
            label6.Name = "label6";
            label6.Size = new Size(109, 26);
            label6.TabIndex = 5;
            label6.Text = "Encoding:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(13, 258);
            label5.Name = "label5";
            label5.Size = new Size(129, 26);
            label5.TabIndex = 4;
            label5.Text = "Server type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(13, 192);
            label4.Name = "label4";
            label4.Size = new Size(133, 26);
            label4.TabIndex = 3;
            label4.Text = "Current port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(13, 131);
            label3.Name = "label3";
            label3.Size = new Size(109, 26);
            label3.TabIndex = 2;
            label3.Text = "Server IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(13, 66);
            label2.Name = "label2";
            label2.Size = new Size(156, 29);
            label2.TabIndex = 1;
            label2.Text = "Server name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 35);
            label1.TabIndex = 0;
            label1.Text = "About server";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(627, 15);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(921, 1004);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(915, 998);
            panel4.TabIndex = 0;
            panel4.Paint += panel4_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(627, 1028);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(921, 175);
            panel3.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(449, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(303, 31);
            textBox2.TabIndex = 4;
            textBox2.Text = "Commit name";
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(760, 60);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(148, 48);
            button2.TabIndex = 3;
            button2.Text = "view";
            button2.UseVisualStyleBackColor = true;
            button2.MouseClick += button2_MouseClick;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(0, 108);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(191, 64);
            button1.TabIndex = 2;
            button1.Text = "upload";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseClick += button1_MouseClick;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(3, 60);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(749, 32);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(136, 35);
            label7.TabIndex = 0;
            label7.Text = "Upload file";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(13, 629);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(588, 569);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            richTextBox1.MouseClick += richTextBox1_MouseClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(8, 581);
            label8.Name = "label8";
            label8.Size = new Size(127, 26);
            label8.TabIndex = 4;
            label8.Text = "System log:";
            // 
            // button3
            // 
            button3.BackColor = Color.Salmon;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(13, 452);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(213, 81);
            button3.TabIndex = 5;
            button3.Text = "Leave";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseClick += button3_MouseClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Cursor = Cursors.Help;
            label9.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(233, 464);
            label9.Name = "label9";
            label9.Size = new Size(195, 26);
            label9.TabIndex = 6;
            label9.Text = "Your device name:\r\n";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(564, 402);
            button4.Name = "button4";
            button4.Size = new Size(56, 52);
            button4.TabIndex = 7;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = true;
            button4.MouseClick += button4_MouseClick;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button5.Location = new Point(564, 460);
            button5.Name = "button5";
            button5.Size = new Size(56, 52);
            button5.TabIndex = 8;
            button5.Text = "+";
            button5.UseVisualStyleBackColor = true;
            button5.MouseClick += button5_MouseClick;
            // 
            // button6
            // 
            button6.Location = new Point(508, 518);
            button6.Name = "button6";
            button6.Size = new Size(112, 45);
            button6.TabIndex = 9;
            button6.Text = "Update";
            button6.UseVisualStyleBackColor = true;
            button6.MouseClick += button6_MouseClick;
            // 
            // ConnectedUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1561, 1218);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label9);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(richTextBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1583, 1274);
            Name = "ConnectedUserForm";
            Text = "Panel";
            FormClosing += ConnectedUserForm_FormClosing;
            Load += ConnectedUserForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private TextBox textBox2;
        private Panel panel4;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}