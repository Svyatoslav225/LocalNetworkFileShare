namespace LNetworkFileShare
{
    partial class ServerOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerOptions));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(857, 12);
            button1.Name = "button1";
            button1.Size = new Size(209, 68);
            button1.TabIndex = 0;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(71, 39);
            label1.TabIndex = 1;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(168, 39);
            label2.TabIndex = 2;
            label2.Text = "Server type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 275);
            label3.Name = "label3";
            label3.Size = new Size(138, 39);
            label3.TabIndex = 3;
            label3.Text = "Encoding";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 384);
            label4.Name = "label4";
            label4.Size = new Size(406, 39);
            label4.TabIndex = 4;
            label4.Text = "Password (if server is private)";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(12, 494);
            label5.Name = "label5";
            label5.Size = new Size(184, 39);
            label5.TabIndex = 5;
            label5.Text = "Server name";
            label5.Click += label5_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(12, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 37);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(12, 437);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(406, 37);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox3.Location = new Point(12, 556);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(406, 37);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox1.Location = new Point(12, 204);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 36);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Public";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox2.Location = new Point(174, 204);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(112, 36);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Private";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox3.Location = new Point(12, 333);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(104, 36);
            checkBox3.TabIndex = 11;
            checkBox3.Text = "UTF-8";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox4.Location = new Point(136, 333);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(115, 36);
            checkBox4.TabIndex = 12;
            checkBox4.Text = "TEA-v2";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.Visible = false;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // ServerOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 940);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ServerOptions";
            Text = "ServerOptions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
    }
}