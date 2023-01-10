namespace AppleSoftware.Forms
{
    partial class FrmChartTesting
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
            this.components = new System.ComponentModel.Container();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.cboxPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cadena1 = new System.Windows.Forms.TextBox();
            this.convertida = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(155, 83);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(371, 137);
            this.txtSend.TabIndex = 1;
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(155, 255);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(371, 128);
            this.txtReceive.TabIndex = 2;
            // 
            // cboxPort
            // 
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Location = new System.Drawing.Point(155, 56);
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.Size = new System.Drawing.Size(176, 21);
            this.cboxPort.TabIndex = 3;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(351, 53);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(451, 54);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(451, 226);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(451, 389);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 7;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cadena1
            // 
            this.cadena1.Location = new System.Drawing.Point(576, 57);
            this.cadena1.Name = "cadena1";
            this.cadena1.Size = new System.Drawing.Size(181, 20);
            this.cadena1.TabIndex = 8;
            // 
            // convertida
            // 
            this.convertida.Location = new System.Drawing.Point(576, 96);
            this.convertida.Name = "convertida";
            this.convertida.Size = new System.Drawing.Size(181, 20);
            this.convertida.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmChartTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.convertida);
            this.Controls.Add(this.cadena1);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboxPort);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtSend);
            this.Name = "FrmChartTesting";
            this.Text = "FrmChartTesting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChartTesting_FormClosing);
            this.Load += new System.EventHandler(this.FrmChartTesting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.ComboBox cboxPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnReceive;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox cadena1;
        private System.Windows.Forms.TextBox convertida;
        private System.Windows.Forms.Button button1;
    }
}