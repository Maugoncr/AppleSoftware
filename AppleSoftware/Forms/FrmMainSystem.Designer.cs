namespace AppleSoftware.Forms
{
    partial class FrmMainSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainSystem));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnON = new FontAwesome.Sharp.IconButton();
            this.cbSelect = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.led1 = new System.Windows.Forms.PictureBox();
            this.led2 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.TrackbarTemp = new XComponent.SliderBar.MACTrackBar();
            this.txtSetTemp1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkOnlyOne = new System.Windows.Forms.CheckBox();
            this.checkByRanges = new System.Windows.Forms.CheckBox();
            this.lbSetTemp2 = new System.Windows.Forms.Label();
            this.txtSetTemp2 = new System.Windows.Forms.TextBox();
            this.checkTemp1 = new System.Windows.Forms.CheckBox();
            this.checkTemp2 = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1262, 42);
            this.panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 30;
            this.btnClose.Location = new System.Drawing.Point(1221, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnON
            // 
            this.btnON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnON.FlatAppearance.BorderSize = 0;
            this.btnON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnON.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnON.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnON.IconColor = System.Drawing.Color.White;
            this.btnON.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnON.IconSize = 35;
            this.btnON.Location = new System.Drawing.Point(52, 159);
            this.btnON.Name = "btnON";
            this.btnON.Size = new System.Drawing.Size(59, 34);
            this.btnON.TabIndex = 0;
            this.btnON.UseVisualStyleBackColor = false;
            this.btnON.Click += new System.EventHandler(this.btnON_Click);
            // 
            // cbSelect
            // 
            this.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelect.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelect.FormattingEnabled = true;
            this.cbSelect.Location = new System.Drawing.Point(30, 67);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(300, 32);
            this.cbSelect.TabIndex = 7;
            this.cbSelect.SelectionChangeCommitted += new System.EventHandler(this.cbSelect_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(30, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 150);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(127, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 150);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(30, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(102, 5);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(30, 280);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(102, 5);
            this.panel4.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Location = new System.Drawing.Point(245, 130);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 80);
            this.panel5.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Location = new System.Drawing.Point(422, 130);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 80);
            this.panel7.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel9.Location = new System.Drawing.Point(245, 130);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(182, 5);
            this.panel9.TabIndex = 15;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel10.Location = new System.Drawing.Point(245, 205);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(182, 5);
            this.panel10.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel11.Location = new System.Drawing.Point(245, 314);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(182, 5);
            this.panel11.TabIndex = 20;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel12.Location = new System.Drawing.Point(245, 239);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(182, 5);
            this.panel12.TabIndex = 19;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel13.Location = new System.Drawing.Point(422, 239);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(5, 80);
            this.panel13.TabIndex = 18;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel14.Location = new System.Drawing.Point(245, 239);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(5, 80);
            this.panel14.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cooling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Heating";
            // 
            // led1
            // 
            this.led1.Image = global::AppleSoftware.Properties.Resources.led_off;
            this.led1.Location = new System.Drawing.Point(368, 147);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(38, 37);
            this.led1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.led1.TabIndex = 23;
            this.led1.TabStop = false;
            // 
            // led2
            // 
            this.led2.Image = global::AppleSoftware.Properties.Resources.led_off;
            this.led2.Location = new System.Drawing.Point(368, 255);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(38, 37);
            this.led2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.led2.TabIndex = 24;
            this.led2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel6.Location = new System.Drawing.Point(0, 540);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1262, 3);
            this.panel6.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(48, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 23);
            this.label11.TabIndex = 34;
            this.label11.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(58, 236);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(44, 23);
            this.lbStatus.TabIndex = 35;
            this.lbStatus.Text = "OFF";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(26, 565);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 24);
            this.label13.TabIndex = 36;
            this.label13.Text = "Station 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(26, 593);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 22);
            this.label14.TabIndex = 37;
            this.label14.Text = "TC 1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(30, 618);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(109, 33);
            this.textBox1.TabIndex = 38;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(182, 618);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(109, 33);
            this.textBox2.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(178, 593);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 22);
            this.label15.TabIndex = 40;
            this.label15.Text = "TC 2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(178, 565);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 24);
            this.label16.TabIndex = 39;
            this.label16.Text = "Station 2";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(331, 618);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(109, 33);
            this.textBox3.TabIndex = 44;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(327, 593);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 22);
            this.label17.TabIndex = 43;
            this.label17.Text = "TC 3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(327, 565);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 24);
            this.label18.TabIndex = 42;
            this.label18.Text = "Station 3";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(485, 618);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(109, 33);
            this.textBox4.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(481, 593);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 22);
            this.label19.TabIndex = 46;
            this.label19.Text = "TC 4";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(481, 565);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 24);
            this.label20.TabIndex = 45;
            this.label20.Text = "Station 4";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(632, 618);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(109, 33);
            this.textBox5.TabIndex = 50;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(628, 593);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 22);
            this.label21.TabIndex = 49;
            this.label21.Text = "TC 5";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(628, 565);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 24);
            this.label22.TabIndex = 48;
            this.label22.Text = "Station 5";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(794, 618);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(109, 33);
            this.textBox6.TabIndex = 53;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(790, 593);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 22);
            this.label23.TabIndex = 52;
            this.label23.Text = "TC 6";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(790, 565);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 24);
            this.label24.TabIndex = 51;
            this.label24.Text = "Station 6";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(948, 618);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(109, 33);
            this.textBox7.TabIndex = 56;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(944, 593);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 22);
            this.label25.TabIndex = 55;
            this.label25.Text = "TC 7";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(944, 565);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 24);
            this.label26.TabIndex = 54;
            this.label26.Text = "Station 7";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(1109, 618);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(109, 33);
            this.textBox8.TabIndex = 59;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(1105, 593);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 22);
            this.label27.TabIndex = 58;
            this.label27.Text = "TC 8";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(1105, 565);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 24);
            this.label28.TabIndex = 57;
            this.label28.Text = "Station 8";
            // 
            // TrackbarTemp
            // 
            this.TrackbarTemp.BackColor = System.Drawing.Color.Transparent;
            this.TrackbarTemp.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.TrackbarTemp.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackbarTemp.ForeColor = System.Drawing.Color.Black;
            this.TrackbarTemp.IndentHeight = 6;
            this.TrackbarTemp.Location = new System.Drawing.Point(159, 117);
            this.TrackbarTemp.Maximum = 100;
            this.TrackbarTemp.Minimum = 0;
            this.TrackbarTemp.Name = "TrackbarTemp";
            this.TrackbarTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackbarTemp.Size = new System.Drawing.Size(56, 202);
            this.TrackbarTemp.TabIndex = 60;
            this.TrackbarTemp.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.TrackbarTemp.TickFrequency = 10;
            this.TrackbarTemp.TickHeight = 2;
            this.TrackbarTemp.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TrackbarTemp.TrackerSize = new System.Drawing.Size(15, 15);
            this.TrackbarTemp.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.TrackbarTemp.TrackLineHeight = 2;
            this.TrackbarTemp.TrackLineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.TrackbarTemp.Value = 0;
            this.TrackbarTemp.Scroll += new System.EventHandler(this.TrackbarTemp_Scroll);
            // 
            // txtSetTemp1
            // 
            this.txtSetTemp1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTemp1.Location = new System.Drawing.Point(30, 357);
            this.txtSetTemp1.Name = "txtSetTemp1";
            this.txtSetTemp1.Size = new System.Drawing.Size(185, 27);
            this.txtSetTemp1.TabIndex = 61;
            this.txtSetTemp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetTemp1.TextChanged += new System.EventHandler(this.txtSetTemp1_TextChanged);
            this.txtSetTemp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSetTemp1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Set Temperature:";
            // 
            // checkOnlyOne
            // 
            this.checkOnlyOne.AutoSize = true;
            this.checkOnlyOne.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOnlyOne.Location = new System.Drawing.Point(276, 330);
            this.checkOnlyOne.Name = "checkOnlyOne";
            this.checkOnlyOne.Size = new System.Drawing.Size(98, 25);
            this.checkOnlyOne.TabIndex = 63;
            this.checkOnlyOne.Text = "Only one";
            this.checkOnlyOne.UseVisualStyleBackColor = true;
            this.checkOnlyOne.CheckedChanged += new System.EventHandler(this.checkOnlyOne_CheckedChanged);
            // 
            // checkByRanges
            // 
            this.checkByRanges.AutoSize = true;
            this.checkByRanges.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByRanges.Location = new System.Drawing.Point(276, 361);
            this.checkByRanges.Name = "checkByRanges";
            this.checkByRanges.Size = new System.Drawing.Size(108, 25);
            this.checkByRanges.TabIndex = 64;
            this.checkByRanges.Text = "By Ranges";
            this.checkByRanges.UseVisualStyleBackColor = true;
            this.checkByRanges.CheckedChanged += new System.EventHandler(this.checkByRanges_CheckedChanged);
            // 
            // lbSetTemp2
            // 
            this.lbSetTemp2.AutoSize = true;
            this.lbSetTemp2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetTemp2.ForeColor = System.Drawing.Color.Black;
            this.lbSetTemp2.Location = new System.Drawing.Point(26, 400);
            this.lbSetTemp2.Name = "lbSetTemp2";
            this.lbSetTemp2.Size = new System.Drawing.Size(158, 19);
            this.lbSetTemp2.TabIndex = 66;
            this.lbSetTemp2.Text = "Set Temperature 2:";
            // 
            // txtSetTemp2
            // 
            this.txtSetTemp2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTemp2.Location = new System.Drawing.Point(30, 427);
            this.txtSetTemp2.Name = "txtSetTemp2";
            this.txtSetTemp2.Size = new System.Drawing.Size(185, 27);
            this.txtSetTemp2.TabIndex = 65;
            this.txtSetTemp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetTemp2.TextChanged += new System.EventHandler(this.txtSetTemp2_TextChanged);
            this.txtSetTemp2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSetTemp2_KeyPress);
            // 
            // checkTemp1
            // 
            this.checkTemp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTemp1.Location = new System.Drawing.Point(222, 361);
            this.checkTemp1.Name = "checkTemp1";
            this.checkTemp1.Size = new System.Drawing.Size(18, 25);
            this.checkTemp1.TabIndex = 67;
            this.checkTemp1.UseVisualStyleBackColor = true;
            this.checkTemp1.CheckedChanged += new System.EventHandler(this.checkTemp1_CheckedChanged);
            // 
            // checkTemp2
            // 
            this.checkTemp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTemp2.Location = new System.Drawing.Point(221, 429);
            this.checkTemp2.Name = "checkTemp2";
            this.checkTemp2.Size = new System.Drawing.Size(18, 25);
            this.checkTemp2.TabIndex = 68;
            this.checkTemp2.UseVisualStyleBackColor = true;
            this.checkTemp2.CheckedChanged += new System.EventHandler(this.checkTemp2_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnLimpiar.IconColor = System.Drawing.Color.White;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 35;
            this.btnLimpiar.Location = new System.Drawing.Point(1208, 500);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(42, 34);
            this.btnLimpiar.TabIndex = 69;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmMainSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 696);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.checkTemp2);
            this.Controls.Add(this.checkTemp1);
            this.Controls.Add(this.lbSetTemp2);
            this.Controls.Add(this.txtSetTemp2);
            this.Controls.Add(this.checkByRanges);
            this.Controls.Add(this.checkOnlyOne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSetTemp1);
            this.Controls.Add(this.TrackbarTemp);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbSelect);
            this.Controls.Add(this.btnON);
            this.Controls.Add(this.panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMainSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainSystem";
            this.Load += new System.EventHandler(this.FrmMainSystem_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnON;
        private System.Windows.Forms.ComboBox cbSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox led1;
        private System.Windows.Forms.PictureBox led2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private XComponent.SliderBar.MACTrackBar TrackbarTemp;
        private System.Windows.Forms.TextBox txtSetTemp1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkOnlyOne;
        private System.Windows.Forms.CheckBox checkByRanges;
        private System.Windows.Forms.Label lbSetTemp2;
        private System.Windows.Forms.TextBox txtSetTemp2;
        private System.Windows.Forms.CheckBox checkTemp1;
        private System.Windows.Forms.CheckBox checkTemp2;
        private FontAwesome.Sharp.IconButton btnLimpiar;
    }
}