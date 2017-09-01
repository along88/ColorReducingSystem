namespace WindowsFormsApp1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.automateBtn = new System.Windows.Forms.Button();
            this.pointListBox = new System.Windows.Forms.ListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ColorsListBox = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FiltersListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 454);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Lime;
            this.pictureBox2.Location = new System.Drawing.Point(224, 14);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(466, 412);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Lime;
            this.pictureBox3.Location = new System.Drawing.Point(135, 392);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(466, 412);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.WaitOnLoad = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(511, 115);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(356, 353);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.debugCheckBox);
            this.panel1.Controls.Add(this.automateBtn);
            this.panel1.Controls.Add(this.pointListBox);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.ColorsListBox);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.FiltersListBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(679, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 482);
            this.panel1.TabIndex = 21;
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Checked = true;
            this.debugCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.debugCheckBox.Location = new System.Drawing.Point(111, 427);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(58, 17);
            this.debugCheckBox.TabIndex = 22;
            this.debugCheckBox.Text = "Debug";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckStateChanged += new System.EventHandler(this.debugCheckBox_CheckStateChanged);
            // 
            // automateBtn
            // 
            this.automateBtn.Location = new System.Drawing.Point(166, 12);
            this.automateBtn.Name = "automateBtn";
            this.automateBtn.Size = new System.Drawing.Size(60, 21);
            this.automateBtn.TabIndex = 30;
            this.automateBtn.Text = "Automate";
            this.automateBtn.UseVisualStyleBackColor = true;
            this.automateBtn.Click += new System.EventHandler(this.automateBtn_Click);
            // 
            // pointListBox
            // 
            this.pointListBox.FormattingEnabled = true;
            this.pointListBox.Location = new System.Drawing.Point(15, 287);
            this.pointListBox.Margin = new System.Windows.Forms.Padding(2);
            this.pointListBox.Name = "pointListBox";
            this.pointListBox.Size = new System.Drawing.Size(81, 186);
            this.pointListBox.TabIndex = 29;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(111, 392);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 30);
            this.button10.TabIndex = 27;
            this.button10.Text = "Measure";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Measurer_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(111, 271);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 19);
            this.button9.TabIndex = 26;
            this.button9.Text = "Blob";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.BlobSeperator_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(111, 339);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 19);
            this.button8.TabIndex = 25;
            this.button8.Text = "Reload";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(111, 316);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 19);
            this.button7.TabIndex = 24;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 293);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(53, 20);
            this.textBox2.TabIndex = 23;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(111, 293);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 19);
            this.button6.TabIndex = 22;
            this.button6.Text = "Rotate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.RotateImage_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(111, 248);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 19);
            this.button5.TabIndex = 21;
            this.button5.Text = "MagicWand";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.MagicWand_Click);
            // 
            // ColorsListBox
            // 
            this.ColorsListBox.FormattingEnabled = true;
            this.ColorsListBox.Location = new System.Drawing.Point(15, 150);
            this.ColorsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.ColorsListBox.Name = "ColorsListBox";
            this.ColorsListBox.Size = new System.Drawing.Size(81, 108);
            this.ColorsListBox.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(111, 131);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 19);
            this.button4.TabIndex = 10;
            this.button4.Text = "GetColor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.GetColors_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(111, 160);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 19);
            this.button3.TabIndex = 9;
            this.button3.Text = "Filter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ColorFilter_Click);
            // 
            // FiltersListBox
            // 
            this.FiltersListBox.FormattingEnabled = true;
            this.FiltersListBox.Location = new System.Drawing.Point(15, 14);
            this.FiltersListBox.Margin = new System.Windows.Forms.Padding(2);
            this.FiltersListBox.Name = "FiltersListBox";
            this.FiltersListBox.Size = new System.Drawing.Size(81, 108);
            this.FiltersListBox.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 52);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "16";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 51);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reduce";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ReduceColors_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(908, 482);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox pointListBox;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox ColorsListBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox FiltersListBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button automateBtn;
        private System.Windows.Forms.CheckBox debugCheckBox;
    }
}

