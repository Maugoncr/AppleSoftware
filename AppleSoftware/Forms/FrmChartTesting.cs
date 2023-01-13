using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleSoftware.Forms
{
    public partial class FrmChartTesting : Form
    {

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmChartTesting()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmChartTesting_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            cboxPort.Items.AddRange(puertos);
            cboxPort.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;

            try
            {
                serialPort1.PortName = cboxPort.Text;
                serialPort1.Open();
                timer1.Start();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (serialPort1.IsOpen)
            //    {
            //        serialPort1.DiscardOutBuffer();
            //        serialPort1.Write(txtSend.Text+"\r");

            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message); ;
            //}

            ReadData(">+0022.9+9999.9+9999.9+9999.9+9999.9+9999.9+9999.9+9999.9+9999.9+9999.9");
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    txtReceive.Text = serialPort1.ReadExisting();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmChartTesting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // dos lineas llegan, serial config cambia chiller a tc's 
        
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (!string.IsNullOrEmpty(serialPort1.ReadExisting()))
                    {
                        ReadData(serialPort1.ReadExisting());
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
           
        }
        string TC1 = "";
        string TC2 = "";
        string TC3 = "";
        string TC4 = "";
        string TC5 = "";
        string TC6 = "";
        string TC7 = "";
        string TC8 = "";
        string TC9 = "";
        string TC10 = "";
        double TC1Num = 0;
        double TC2Num = 0;
        double TC3Num = 0;
        double TC4Num = 0;
        double TC5Num = 0;
        double TC6Num = 0;
        double TC7Num = 0;
        double TC8Num = 0;
        double TC9Num = 0;
        double TC10Num = 0;


        private void ReadData(string data)
        {
            // Paso 1 Quitar cualquier espacio
            string tcs = data.Trim();
            //Paso 2 quitar el >+ inicial
            tcs = tcs.Substring(2);
            //Paso 3 separar por +
            string[] TC = tcs.Split('+');

            //Paso 4 asignar cada TC
            if (TC.Length == 10)
            {
                TC1 = TC[0];
                TC2 = TC[1];
                TC3 = TC[2];
                TC4 = TC[3];
                TC5 = TC[4];
                TC6 = TC[5];
                TC7 = TC[6];
                TC8 = TC[7];
                TC9 = TC[8];
                TC10 = TC[9];
            }

            // Paso 5 reasignar valores

            TC1 = TC1.Substring(2);
            TC2 = TC2.Substring(2);
            TC3 = TC3.Substring(2);
            TC4 = TC4.Substring(2);
            TC5 = TC5.Substring(2);
            TC6 = TC6.Substring(2);
            TC7 = TC7.Substring(2);
            TC8 = TC8.Substring(2);
            TC9 = TC9.Substring(2);
            TC10 = TC10.Substring(2);
            
            // Paso 6 Separar a las con numeros a las con C°

            TC1Num = Convert.ToDouble(TC1);
            TC2Num = Convert.ToDouble(TC2);
            TC3Num = Convert.ToDouble(TC3);
            TC4Num = Convert.ToDouble(TC4);
            TC5Num = Convert.ToDouble(TC5);
            TC6Num = Convert.ToDouble(TC6);
            TC7Num = Convert.ToDouble(TC7);
            TC8Num = Convert.ToDouble(TC8);
            TC9Num = Convert.ToDouble(TC9);
            TC10Num = Convert.ToDouble(TC10);

            // Paso Final
            TC1 = TC1 + " C°";
            TC2 = TC2 + " C°";
            TC3 = TC3 + " C°";
            TC4 = TC4 + " C°";
            TC5 = TC5 + " C°";
            TC6 = TC6 + " C°";
            TC7 = TC7 + " C°";
            TC8 = TC8 + " C°";
            TC9 = TC9 + " C°";
            TC10 = TC10 + " C°";

            //TODO GRAFICAR.

            txtReceive.Text = TC1 + " \n"+ TC2 + " \n" + TC3;

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    txtReceive.Text += serialPort1.ReadExisting();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static byte calculateLRC(byte[] bytes)
        {
            byte LRC = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return LRC;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static String decimalHexadecimal(int numero)
        {
            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };
            String hexadecimal = "";
            const int DIVISOR = 16;
            long resto = 0;
            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                resto = i % DIVISOR;
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;

                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;
        }
        public static int hexadecimalDecimal(String hexadecimal)
        {
            int numero = 0;
            const int DIVISOR = 16;
            for (int i = 0, j = hexadecimal.Length - 1; i < hexadecimal.Length; i++, j--)
            {
                if (hexadecimal[i] >= '0' && hexadecimal[i] <= '9')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32(hexadecimal[i] + "");
                }
                else if (hexadecimal[i] >= 'A' && hexadecimal[i] <= 'F')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32((hexadecimal[i] - 'A' + 10) + "");
                }
                else
                {
                    return -1;
                }
            }
            return numero;
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Cycle()
        {
            serialPort1.DiscardOutBuffer();
                txtSend.Text = "#03";
                serialPort1.Write(txtSend.Text + "\r");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cycle();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            Application.Exit();

        }

        private void FrmChartTesting_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
