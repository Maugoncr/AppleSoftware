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
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Application = System.Windows.Forms.Application;

namespace AppleSoftware.Forms
{
    public partial class FrmMainSystem : Form
    {
        public int CualTemperatura;
        public static string FormatCadena = "Ninguno";
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public FrmMainSystem()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            EstilizacionInicial();
        }

        private void EstilizacionInicial()
        {
            txtTC1.BackColor = Color.White; txtTC2.BackColor = Color.White; 
            txtTC3.BackColor = Color.White; txtTC4.BackColor = Color.White;
            txtTC5.BackColor = Color.White; txtTC6.BackColor= Color.White;
            txtTC7.BackColor = Color.White; txtTC8.BackColor = Color.White;
            txtActualSetPoint.BackColor = Color.White;
            txtActualTempTCGeneral.BackColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            Application.Exit();
        }

        private void FrmMainSystem_Load(object sender, EventArgs e)
        {
            TimerHoraFecha.Start();
            CargarCombo();
            LimpiarArranque();
            //checkByRanges.Checked = true;

            if (cbCOMSelect.Items.Count > 0)
            {
                cbCOMSelect.SelectedIndex = 0;
                btnConnect.Enabled = true;
            }


        }

        private void CargarCombo()
        {
            // --  0
            cbSelect.Items.Add("Heating");
            // -- 1
            cbSelect.Items.Add("Cooling");
        }

        private void ResetearChart() 
        {

            chart1.Series["TC-1"].Points.Clear();
            chart1.Series["TC-2"].Points.Clear();
            chart1.Series["TC-3"].Points.Clear();
            chart1.Series["TC-4"].Points.Clear();
            chart1.Series["TC-5"].Points.Clear();
            chart1.Series["TC-6"].Points.Clear();
            chart1.Series["TC-7"].Points.Clear();
            chart1.Series["TC-8"].Points.Clear();

            ChartArea CA = chart1.ChartAreas[0];
            CA.CursorX.AutoScroll = true;

            i = false;

        }

        private void LimpiarArranque()
        {
            cbSelect.SelectedIndex = -1;
            checkOnlyOne.Checked = true;
            checkTemp1.Checked = true;
            checkByRanges.Checked = false;
            CualTemperatura = 1;
            FormatCadena = "Ninguno";
            ChillerRangeOff();
            HeaterRangeOff();

            // CONECTAR COM
            BtnRefreshCOM.Visible = true;
            btnConnect.Enabled = false;

            cbCOMSelect.Enabled = true;
            string[] ports = SerialPort.GetPortNames();
            cbCOMSelect.Items.Clear();
            cbCOMSelect.Items.AddRange(ports);

            SetConfigSerialPortForTCS();
            BanderaRespuestaParaTCS = false;

            // about chart

            chart1.Series["TC-1"].Points.Clear();
            chart1.Series["TC-1"].Color = Color.Red;
            chart1.Series["TC-1"].BorderWidth = 3;
            chart1.Series["TC-2"].Points.Clear();
            chart1.Series["TC-2"].Color = Color.Blue;
            chart1.Series["TC-2"].BorderWidth = 3;
            chart1.Series["TC-3"].Points.Clear();
            chart1.Series["TC-3"].Color = Color.Yellow;
            chart1.Series["TC-3"].BorderWidth = 3;
            chart1.Series["TC-4"].Points.Clear();
            chart1.Series["TC-4"].Color = Color.Orange;
            chart1.Series["TC-4"].BorderWidth = 3;
            chart1.Series["TC-5"].Points.Clear();
            chart1.Series["TC-5"].Color = Color.Brown;
            chart1.Series["TC-5"].BorderWidth = 3;
            chart1.Series["TC-6"].Points.Clear();
            chart1.Series["TC-6"].Color = Color.SkyBlue;
            chart1.Series["TC-6"].BorderWidth = 3;
            chart1.Series["TC-7"].Points.Clear();
            chart1.Series["TC-7"].Color = Color.Purple;
            chart1.Series["TC-7"].BorderWidth = 3;
            chart1.Series["TC-8"].Points.Clear();
            chart1.Series["TC-8"].Color = Color.Green;
            chart1.Series["TC-8"].BorderWidth = 3;

            ChartArea CA = chart1.ChartAreas[0];
            CA.CursorX.AutoScroll = true;

            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;

            // Limpiar datos Tc's
            txtActualTempTCGeneral.Clear();
            txtTC1.Clear();
            txtTC2.Clear();
            txtTC3.Clear();
            txtTC4.Clear();
            txtTC5.Clear();
            txtTC6.Clear();
            txtTC7.Clear();
            txtTC8.Clear();

             TC1S = "";
             TC2S = "";
             TC3S = "";
             TC4S = "";
             TC5S = "";
             TC6S = "";
             TC7S = "";
             TC8S = "";
             TC9S = "";
             TC10S = "";
             TC1Num = 0;
             TC2Num = 0;
             TC3Num = 0;
             TC4Num = 0;
             TC5Num = 0;
             TC6Num = 0;
             TC7Num = 0;
             TC8Num = 0;
             TC9Num = 0;
             TC10Num = 0;


            i = false;

            // Desactivar todo hasta que eliga cooling o heating

            btnON.Enabled = false;
            TrackbarTemp.Enabled = false;
            txtSetTemp1.Enabled = false;
            checkOnlyOne.Enabled = false;
            checkByRanges.Enabled = false;
            btnSetTemp.Enabled = false;
            btnAddMin.Enabled = false;
            btnAddMin2.Enabled = false;
            btnAddSeg.Enabled = false;
            btnAddSeg2.Enabled = false;
            btnReset.Enabled = false;
            btnReset2.Enabled = false;


            txtSetTemp1.Clear();
            txtActualSetPoint.Clear();
            txtSetTemp2.Clear();

            SelectTittle.Text = "Not selected";
            lbStatus.Text = "-----";
            lbStatus.ForeColor = Color.Red;

            //Desactivar hasta tener la conexion

            cbSelect.Enabled = false;

            TrackbarTemp.Value = 0;
          

            btnON.BackColor = Color.FromArgb(64, 64, 64);

          

            panel5.BackColor = Color.FromArgb(64, 64, 64);
           

            panel1.BackColor = Color.FromArgb(64, 64,64);
            panel2.BackColor = Color.FromArgb(64, 64, 64);
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel4.BackColor = Color.FromArgb(64, 64, 64);

         

            led1.Image.Dispose();
            led2.Image.Dispose();

            led1.Image = Properties.Resources.led_off;
            led2.Image = Properties.Resources.led_off;

        }




        private void checkOnlyOne_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOnlyOne.Checked == true)
            {
                txtSetTemp2.Visible = false;
                txtSetTemp2.Clear();
                checkTemp2.Visible = false;
                checkTemp2.Checked = false;
                lbSetTemp2.Visible = false;


                checkByRanges.Checked = false;
                checkOnlyOne.Enabled = false;
                checkByRanges.Enabled = true;

                checkTemp1.Checked = true;
                checkTemp1.Enabled = false;
                lbC2.Visible = false;

            }
        }

        private void cbSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSelect.SelectedIndex >= 0)
            {
                btnON.Enabled = true;
                TrackbarTemp.Enabled = true;
                txtSetTemp1.Enabled = true;
                btnSetTemp.Enabled = true;
                //checkOnlyOne.Enabled = true;
                checkByRanges.Enabled = true;
                lbStatus.Text = "OFF";

                btnON.BackColor = Color.FromArgb(0, 143, 57);

                // Cooling
                if (cbSelect.SelectedIndex == 1)
                {
                    txtActualSetPoint.Clear();
                    FormatCadena = "Chiller";
                    ChillerRangeOn();
                    HeaterRangeOff();
                    SelectTittle.Text = "Cooling";
                    txtSetTemp1.Text = "5";
                   

                    led1.Image.Dispose();
                    led2.Image.Dispose();
                    led1.Image = Properties.Resources.led_on_green;
                    led2.Image = Properties.Resources.led_off;

                    panel1.BackColor = Color.FromArgb(24, 130, 198);
                    panel2.BackColor = Color.FromArgb(24, 130, 198);
                    panel3.BackColor = Color.FromArgb(24, 130, 198);
                    panel4.BackColor = Color.FromArgb(24, 130, 198);

                    btnAddMin.Enabled = false;
                    btnAddMin2.Enabled = true;
                    btnAddSeg.Enabled = false;
                    btnAddSeg2.Enabled = true;
                    btnReset.Enabled = false;
                    btnReset2.Enabled = true;



                }
                // Heating
                else if (cbSelect.SelectedIndex == 0)
                {
                    txtActualSetPoint.Clear();
                    FormatCadena = "Heater";
                    ChillerRangeOff();
                    HeaterRangeOn();
                    
                    SelectTittle.Text = "Heating";
                    txtSetTemp1.Text = "25";

                    led1.Image.Dispose();
                    led2.Image.Dispose();
                    led2.Image = Properties.Resources.led_on_green;
                    led1.Image = Properties.Resources.led_off;


                    panel1.BackColor = Color.FromArgb(183, 43, 41);
                    panel2.BackColor = Color.FromArgb(183, 43, 41);
                    panel3.BackColor = Color.FromArgb(183, 43, 41);
                    panel4.BackColor = Color.FromArgb(183, 43, 41);

                    btnAddMin.Enabled = true;
                    btnAddMin2.Enabled = false;
                    btnAddSeg.Enabled = true;
                    btnAddSeg2.Enabled = false;
                    btnReset.Enabled = true;
                    btnReset2.Enabled = false;
                }

            }
        }

        private void TrackbarTemp_Scroll(object sender, EventArgs e)
        {
            if (CualTemperatura == 1)
            {
                txtSetTemp1.Text = TrackbarTemp.Value.ToString();
            }
            if (CualTemperatura == 2)
            {
                txtSetTemp2.Text = TrackbarTemp.Value.ToString();
            }
          
        }

        private void checkByRanges_CheckedChanged(object sender, EventArgs e)
        {
            if (checkByRanges.Checked == true)
            {
                txtSetTemp2.Visible = true;
                txtSetTemp2.Clear();
                checkTemp2.Visible = true;
                checkTemp2.Checked = false;
                lbSetTemp2.Visible = true;
                lbC2.Visible = true;

                checkByRanges.Enabled = false;
                checkOnlyOne.Checked = false;
                checkOnlyOne.Enabled = true;
                cbSelect.Focus();
            }
        }

        private void checkTemp2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTemp2.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtSetTemp2.Text.Trim()))
                {
                    TrackbarTemp.Value = Convert.ToInt32(txtSetTemp2.Text.Trim());
                }
                checkTemp2.Enabled = false;
                checkTemp1.Enabled = true;
                checkTemp1.Checked = false;
                txtSetTemp1.Enabled = false;
                txtSetTemp2.Enabled = true;

                CualTemperatura = 2;
            }
        }

        private void checkTemp1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTemp1.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                {
                    TrackbarTemp.Value = Convert.ToInt32(txtSetTemp1.Text.Trim());
                }
                checkTemp1.Enabled = false;
                checkTemp2.Enabled = true;
                checkTemp2.Checked = false;
                txtSetTemp2.Enabled = false;
                txtSetTemp1.Enabled = true;       

                CualTemperatura = 1;
            }
        }

        private void txtSetTemp1_TextChanged(object sender, EventArgs e)
        {

            if (FormatCadena == "Chiller")
            {
                if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                {
                    int validate = Convert.ToInt32(txtSetTemp1.Text.Trim());
                    if (validate >= 5 && validate <= 40)
                    {
                        TrackbarTemp.Value = Convert.ToInt32(txtSetTemp1.Text.Trim());
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Out of range\nRange from 𝟱C° to 𝟰𝟬C°", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSetTemp1.Clear();
                        TrackbarTemp.Value = 5;
                        return;
                    }
                }
            }
            else if (FormatCadena == "Heater")
            {
                if (txtSetTemp1.Text.Length > 1)
                {
                    if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                    {
                        int validate = Convert.ToInt32(txtSetTemp1.Text.Trim());
                        if (validate >= 25 && validate <= 85)
                        {
                            TrackbarTemp.Value = Convert.ToInt32(txtSetTemp1.Text.Trim());
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Out of range\nRange from 𝟮𝟱C° to 𝟴𝟱C°", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtSetTemp1.Clear();
                            TrackbarTemp.Value = 25;
                            return;
                        }
                    }
                }

            }


           
            
        }

       
        private void ChillerRangeOn()
        {
                Chiller1.Visible = true;
                Chiller2.Visible = true;
                Chiller3.Visible = true;
                Chiller4Label.Visible = true;
                Chiller4Label.Text = "R\na\nn\ng\ne\n\nC\nh\ni\nl\nl\ne\nr";
        }  

        private void HeaterRangeOn()
        {
                Heat1.Visible = true;
                Heat2.Visible = true;
                Heat3.Visible = true;
                Heat4Label.Visible = true;
                Heat4Label.Text = "R\na\nn\ng\ne\n\nH\ne\na\nt\ne\nr";
        }
        private void ChillerRangeOff()
        {
            Chiller1.Visible = false;
            Chiller2.Visible = false;
            Chiller3.Visible = false;
            Chiller4Label.Visible = false;
        }  

        private void HeaterRangeOff()
        {
            Heat1.Visible = false;
            Heat2.Visible = false;
            Heat3.Visible = false;
            Heat4Label.Visible = false;
        }

        private void txtSetTemp2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSetTemp2.Text.Trim()))
            {
                if (Convert.ToInt32(txtSetTemp2.Text.Trim()) > 100)
                {
                    System.Windows.Forms.MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSetTemp2.Clear();
                    TrackbarTemp.Value = 0;
                    return;
                }
                TrackbarTemp.Value = Convert.ToInt32(txtSetTemp2.Text.Trim());
            }
        }

        private void txtSetTemp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                System.Windows.Forms.MessageBox.Show("Only numbers are allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSetTemp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                System.Windows.Forms.MessageBox.Show("Only numbers are allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void EncenderHeaterFromSetTemp()
        {
            btnClose.Enabled = false;
            btnConnect.Enabled = false;
            lbStatus.Text = "ON";
            lbStatus.ForeColor = Color.FromArgb(0, 143, 57);
            cbSelect.Enabled = false;
            TrackbarTemp.Enabled = false;
            txtSetTemp1.Enabled = false;
            txtSetTemp2.Enabled = false;
            checkOnlyOne.Enabled = false;
            checkByRanges.Enabled = false;
            checkTemp1.Enabled = false;
            checkTemp2.Enabled = false;
            btnON.BackColor = Color.FromArgb(183, 43, 41);
        }

        private void SendSetTempHeaterAndTurnItOn()
        {
            switch (txtSetTemp1.Text)
            {
                case "1":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes1 = { 4, 6, 33, 3, 0, 10, 243, 164 };
                    serialPort1.Write(bytes1, 0, bytes1.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    //Check ☻

                    break;
                case "2":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes2 = { 4, 6, 33, 3, 0, 20, 115, 172 };
                    serialPort1.Write(bytes2, 0, bytes2.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();

                    break;
                case "3":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes3 = { 4, 6, 33, 3, 0, 30, 243, 171 };
                    serialPort1.Write(bytes3, 0, bytes3.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "4":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes4 = { 4, 6, 33, 3, 0, 200, 114, 53 };
                    serialPort1.Write(bytes4, 0, bytes4.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "5":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes5 = { 4, 6, 33, 3, 0, 50, 242, 118 };
                    serialPort1.Write(bytes5, 0, bytes5.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "6":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes6 = { 4, 6, 33, 3, 0, 60, 115, 178 };
                    serialPort1.Write(bytes6, 0, bytes6.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "7":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes7 = { 4, 6, 33, 3, 0, 70, 242, 81 };
                    serialPort1.Write(bytes7, 0, bytes7.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "8":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes8 = { 4, 6, 33, 3, 0, 80, 115, 159 };
                    serialPort1.Write(bytes8, 0, bytes8.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "9":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes9 = { 4, 6, 33, 3, 0, 90, 243, 152 };
                    serialPort1.Write(bytes9, 0, bytes9.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "10":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes10 = { 4, 6, 33, 3, 0, 100, 114, 72 };
                    serialPort1.Write(bytes10, 0, bytes10.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "11":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes11 = { 4, 6, 33, 3, 0, 110, 242, 79 };
                    serialPort1.Write(bytes11, 0, bytes11.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "12":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes12 = { 4, 6, 33, 3, 0, 120, 115, 129 };
                    serialPort1.Write(bytes12, 0, bytes12.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "13":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes13 = { 4, 6, 33, 3, 0, 130, 243, 194 };
                    serialPort1.Write(bytes13, 0, bytes13.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "14":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes14 = { 4, 6, 33, 3, 0, 140, 114, 6 };
                    serialPort1.Write(bytes14, 0, bytes14.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "15":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes15 = { 4, 6, 33, 3, 0, 150, 243, 205 };
                    serialPort1.Write(bytes15, 0, bytes15.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "16":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes16 = { 4, 6, 33, 3, 0, 160, 115, 219 };
                    serialPort1.Write(bytes16, 0, bytes16.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "17":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes17 = { 4, 6, 33, 3, 0, 170, 243, 220 };
                    serialPort1.Write(bytes17, 0, bytes17.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "18":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes18 = { 4, 6, 33, 3, 0, 180, 115, 212 };
                    serialPort1.Write(bytes18, 0, bytes18.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "19":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes19 = { 4, 6, 33, 3, 0, 190, 243, 211 };
                    serialPort1.Write(bytes19, 0, bytes19.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "20":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes20 = { 4, 6, 33, 3, 0, 200, 114, 53 };
                    serialPort1.Write(bytes20, 0, bytes20.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "21":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes21 = { 4, 6, 33, 3, 0, 210, 243, 254 };
                    serialPort1.Write(bytes21, 0, bytes21.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "22":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes22 = { 4, 6, 33, 3, 0, 220, 114, 58 };
                    serialPort1.Write(bytes22, 0, bytes22.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "23":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes23 = { 4, 6, 33, 3, 0, 230, 242, 41 };
                    serialPort1.Write(bytes23, 0, bytes23.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "24":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes24 = { 4, 6, 33, 3, 0, 240, 115, 231 };
                    serialPort1.Write(bytes24, 0, bytes24.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "25":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes25 = { 4, 6, 33, 3, 0, 250, 243, 224 };
                    serialPort1.Write(bytes25, 0, bytes25.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "26":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes26 = { 4, 6, 33, 3, 1, 4, 115, 240 };
                    serialPort1.Write(bytes26, 0, bytes26.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "27":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes27 = { 4, 6, 33, 3, 1, 14, 243, 247 };
                    serialPort1.Write(bytes27, 0, bytes27.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "28":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes28 = { 4, 6, 33, 3, 1, 24, 114, 57 };
                    serialPort1.Write(bytes28, 0, bytes28.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "29":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes29 = { 4, 6, 33, 3, 1, 34, 242, 42 };
                    serialPort1.Write(bytes29, 0, bytes29.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "30":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes30 = { 4, 6, 33, 3, 1, 44, 115, 238 };
                    serialPort1.Write(bytes30, 0, bytes30.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "31":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes31 = { 4, 6, 33, 3, 1, 54, 242, 37 };
                    serialPort1.Write(bytes31, 0, bytes31.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "32":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes32 = { 4, 6, 33, 3, 1, 64, 115, 195 };
                    serialPort1.Write(bytes32, 0, bytes32.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "33":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes33 = { 4, 6, 33, 3, 1, 74, 243, 196 };
                    serialPort1.Write(bytes33, 0, bytes33.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "34":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes34 = { 4, 6, 33, 3, 1, 84, 115, 204 };
                    serialPort1.Write(bytes34, 0, bytes34.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "35":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes35 = { 4, 6, 33, 3, 1, 94, 243, 203 };
                    serialPort1.Write(bytes35, 0, bytes35.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "36":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes36 = { 4, 6, 33, 3, 1, 104, 115, 221 };
                    serialPort1.Write(bytes36, 0, bytes36.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "37":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes37 = { 4, 6, 33, 3, 1, 114, 242, 22 };
                    serialPort1.Write(bytes37, 0, bytes37.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "38":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes38 = { 4, 6, 33, 3, 1, 124, 115, 210 };
                    serialPort1.Write(bytes38, 0, bytes38.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "39":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes39 = { 4, 6, 33, 3, 1, 134, 243, 145 };
                    serialPort1.Write(bytes39, 0, bytes39.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "40":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes40 = { 4, 6, 33, 3, 1, 144, 114, 95 };
                    serialPort1.Write(bytes40, 0, bytes40.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "41":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes41 = { 4, 6, 33, 3, 1, 154, 242, 88 };
                    serialPort1.Write(bytes41, 0, bytes41.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "42":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes42 = { 4, 6, 33, 3, 1, 164, 115, 136 };
                    serialPort1.Write(bytes42, 0, bytes42.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "43":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes43 = { 4, 6, 33, 3, 1, 174, 243, 143 };
                    serialPort1.Write(bytes43, 0, bytes43.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "44":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes44 = { 4, 6, 33, 3, 1, 184, 114, 65 };
                    serialPort1.Write(bytes44, 0, bytes44.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "45":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes45 = { 4, 6, 33, 3, 1, 194, 243, 162 };
                    serialPort1.Write(bytes45, 0, bytes45.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "46":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes46 = { 4, 6, 33, 3, 1, 204, 114, 102 };
                    serialPort1.Write(bytes46, 0, bytes46.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "47":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes47 = { 4, 6, 33, 3, 1, 214, 243, 173 };
                    serialPort1.Write(bytes47, 0, bytes47.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "48":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes48 = { 4, 6, 33, 3, 1, 224, 115, 187 };
                    serialPort1.Write(bytes48, 0, bytes48.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "49":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes49 = { 4, 6, 33, 3, 1, 234, 243, 188 };
                    serialPort1.Write(bytes49, 0, bytes49.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "50":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes50 = { 4, 6, 33, 3, 1, 244, 115, 180 };
                    serialPort1.Write(bytes50, 0, bytes50.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "51":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes51 = { 4, 6, 33, 3, 1, 254, 243, 179 };
                    serialPort1.Write(bytes51, 0, bytes51.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "52":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes52 = { 4, 6, 33, 3, 2, 8, 115, 5 };
                    serialPort1.Write(bytes52, 0, bytes52.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "53":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes53 = { 4, 6, 33, 3, 2, 18, 242, 206 };
                    serialPort1.Write(bytes53, 0, bytes53.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "54":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes54 = { 4, 6, 33, 3, 2, 28, 115, 10 };
                    serialPort1.Write(bytes54, 0, bytes54.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "55":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes55 = { 4, 6, 33, 3, 2, 38, 243, 25 };
                    serialPort1.Write(bytes55, 0, bytes55.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "56":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes56 = { 4, 6, 33, 3, 2, 48, 114, 215 };
                    serialPort1.Write(bytes56, 0, bytes56.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "57":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes57 = { 4, 6, 33, 3, 2, 58, 242, 208 };
                    serialPort1.Write(bytes57, 0, bytes57.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "58":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes58 = { 4, 6, 33, 3, 2, 68, 114, 240 };
                    serialPort1.Write(bytes58, 0, bytes58.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "59":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes59 = { 4, 6, 33, 3, 2, 78, 242, 247 };
                    serialPort1.Write(bytes59, 0, bytes59.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "60":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes60 = { 4, 6, 33, 3, 2, 88, 115, 57 };
                    serialPort1.Write(bytes60, 0, bytes60.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "61":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes61 = { 4, 6, 33, 3, 2, 98, 243, 42 };
                    serialPort1.Write(bytes61, 0, bytes61.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "62":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes62 = { 4, 6, 33, 3, 2, 108, 114, 238 };
                    serialPort1.Write(bytes62, 0, bytes62.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "63":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes63 = { 4, 6, 33, 3, 2, 118, 243, 37 };
                    serialPort1.Write(bytes63, 0, bytes63.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "64":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes64 = { 4, 6, 33, 3, 2, 128, 115, 99 };
                    serialPort1.Write(bytes64, 0, bytes64.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "65":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes65 = { 4, 6, 33, 3, 2, 138, 243, 100 };
                    serialPort1.Write(bytes65, 0, bytes65.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "66":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes66 = { 4, 6, 33, 3, 2, 148, 115, 108 };
                    serialPort1.Write(bytes66, 0, bytes66.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "67":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes67 = { 4, 6, 33, 3, 2, 158, 243, 107 };
                    serialPort1.Write(bytes67, 0, bytes67.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "68":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes68 = { 4, 6, 33, 3, 2, 168, 115, 125 };
                    serialPort1.Write(bytes68, 0, bytes68.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "69":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes69 = { 4, 6, 33, 3, 2, 178, 242, 182 };
                    serialPort1.Write(bytes69, 0, bytes69.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "70":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes70 = { 4, 6, 33, 3, 2, 188, 115, 114 };
                    serialPort1.Write(bytes70, 0, bytes70.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "71":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes71 = { 4, 6, 33, 3, 2, 198, 242, 145 };
                    serialPort1.Write(bytes71, 0, bytes71.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "72":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes72 = { 4, 6, 33, 3, 2, 208, 115, 95 };
                    serialPort1.Write(bytes72, 0, bytes72.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "73":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes73 = { 4, 6, 33, 3, 2, 218, 243, 88 };
                    serialPort1.Write(bytes73, 0, bytes73.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "74":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes74 = { 4, 6, 33, 3, 2, 228, 114, 136 };
                    serialPort1.Write(bytes74, 0, bytes74.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "75":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes75 = { 4, 6, 33, 3, 2, 238, 242, 143 };
                    serialPort1.Write(bytes75, 0, bytes75.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "76":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes76 = { 4, 6, 33, 3, 2, 248, 115, 65 };
                    serialPort1.Write(bytes76, 0, bytes76.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "77":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes77 = { 4, 6, 33, 3, 3, 2, 242, 146 };
                    serialPort1.Write(bytes77, 0, bytes77.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "78":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes78 = { 4, 6, 33, 3, 3, 12, 115, 86 };
                    serialPort1.Write(bytes78, 0, bytes78.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "79":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes79 = { 4, 6, 33, 3, 3, 22, 242, 157 };
                    serialPort1.Write(bytes79, 0, bytes79.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "80":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes80 = { 4, 6, 33, 3, 3, 32, 114, 139 };
                    serialPort1.Write(bytes80, 0, bytes80.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "81":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes81 = { 4, 6, 33, 3, 3, 42, 242, 140 };
                    serialPort1.Write(bytes81, 0, bytes81.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "82":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes82 = { 4, 6, 33, 3, 3, 52, 114, 132 };
                    serialPort1.Write(bytes82, 0, bytes82.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "83":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes83 = { 4, 6, 33, 3, 3, 62, 242, 131 };
                    serialPort1.Write(bytes83, 0, bytes83.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "84":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes84 = { 4, 6, 33, 3, 3, 72, 115, 101 };
                    serialPort1.Write(bytes84, 0, bytes84.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "85":
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    //TODO Cambiar las cadenas
                    byte[] bytes85 = { 4, 6, 33, 3, 3, 82, 242, 174 };
                    serialPort1.Write(bytes85, 0, bytes85.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                    // Check ☻

                    break;
                case "86":

                    break;
                case "87":

                    break;
                case "88":

                    break;
                case "89":

                    break;
                case "90":

                    break;
                case "91":

                    break;
                case "92":

                    break;
                case "93":

                    break;
                case "94":

                    break;
                case "95":

                    break;
                case "96":

                    break;
                case "97":

                    break;
                case "98":

                    break;
                case "99":

                    break;
                case "100":

                    break;

            }
        }

        private void EncenderSistemaEstetica()
        {

            btnClose.Enabled = false;
            btnConnect.Enabled = false;
            lbStatus.Text = "ON";
            lbStatus.ForeColor = Color.FromArgb(0, 143, 57);
            cbSelect.Enabled = false;
            TrackbarTemp.Enabled = false;
            txtSetTemp1.Enabled = false;
            txtSetTemp2.Enabled = false;
            checkOnlyOne.Enabled = false;
            checkByRanges.Enabled = false;
            checkTemp1.Enabled = false;
            checkTemp2.Enabled = false;
            btnSetTemp.Enabled = false;
            btnON.BackColor = Color.FromArgb(183, 43, 41);
            //Temporizador.Start();
            //Comando iniciar Chiller

            //Prende la VERDE
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Write("#020001" + "\r");
            BanderaRespuestaParaTCS = false;

            picGREEN.Image.Dispose();
            picRED.Image.Dispose();
            picYELLOW.Image.Dispose();

            picGREEN.Image = Properties.Resources.tc8on;
            picYELLOW.Image = Properties.Resources.tc3off;
            picRED.Image = Properties.Resources.tc1off;

        }
        
        private void btnON_Click(object sender, EventArgs e)
        {

            if (lbStatus.Text == "OFF" && ValidadEncender())
            {

                if (FormatCadena == "Chiller")
                {
                    if (serialPort1.IsOpen)
                    {
                        if (TC5Num <= 55)
                        {
                            if (!string.IsNullOrEmpty(txtActualSetPoint.Text))
                            {
                                EncenderSistemaEstetica();
                                SetConfigSerialPortForChiller();
                                Thread.Sleep(1000);
                                serialPort1.DiscardOutBuffer();
                                serialPort1.WriteLine(":0106000C0001EC" + Environment.NewLine);
                                BanderaRespuestaParaTCS = false;
                                Thread.Sleep(1000);
                                SetConfigSerialPortForTCS();
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("You must set a temperature before.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSetTemp1.Clear();
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Please wait a few minutes until the temperature is below 𝟱𝟱C°.\r\nLet's take care of the integrity of the equipment, thank you!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        
                    }
                   
                }

                if (FormatCadena == "Heater")
                {
                    if (!string.IsNullOrEmpty(txtSetTemp1.Text))
                    {
                        if (txtSetTemp1.Text.Length == 2)
                        {
                            if (serialPort1.IsOpen)
                            {
                                EncenderSistemaEstetica();
                                SendSetTempHeaterAndTurnItOn();
                                txtActualSetPoint.Text = txtSetTemp1.Text + " C°";
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Out of range\nRange from 𝟮𝟱C° to 𝟴𝟱C°", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtSetTemp1.Clear();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("You must set a temperature before.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSetTemp1.Clear();
                    }
                }


            }
            else if (lbStatus.Text == "ON")
            {
                btnClose.Enabled = true;
                btnConnect.Enabled = true;
                lbStatus.Text = "OFF";
                lbStatus.ForeColor = Color.FromArgb(183, 43, 41);
                cbSelect.Enabled = true;
                TrackbarTemp.Enabled = true;
                txtSetTemp1.Enabled = true;
                txtSetTemp2.Enabled = true;
                checkOnlyOne.Enabled = true;
                checkByRanges.Enabled = true;
                checkTemp1.Enabled = true;
                checkTemp2.Enabled = true;
                btnSetTemp.Enabled = true;
                btnON.BackColor = Color.FromArgb(0, 143, 57);
                Temporizador.Stop();
                txtActualSetPoint.Clear();

                picGREEN.Image.Dispose();
                picRED.Image.Dispose();
                picYELLOW.Image.Dispose();

                picGREEN.Image = Properties.Resources.tc8off;
                picYELLOW.Image = Properties.Resources.tc3off;
                picRED.Image = Properties.Resources.tc1on;

                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Write("#020004" + "\r");
                BanderaRespuestaParaTCS = false;

                //Apagar Chiller

                if (FormatCadena == "Chiller")
                {
                    SetConfigSerialPortForChiller();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    serialPort1.WriteLine(":0106000C0000ED"+Environment.NewLine);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                }

                if (FormatCadena == "Heater")
                {
                    if (serialPort1.IsOpen)
                    {
                        SetConfigSerialPortForHeater();
                        Thread.Sleep(1000);
                        serialPort1.DiscardOutBuffer();
                        byte[] bytes = { 4, 6, 33, 3, 0, 0, 115, 163 };
                        serialPort1.Write(bytes,0,bytes.Length);
                        BanderaRespuestaParaTCS = false;
                        Thread.Sleep(1000);
                        SetConfigSerialPortForTCS();
                    }
                }

            }
        }

        public bool ValidadEncender()
        {
            bool R = false;

            if (checkOnlyOne.Checked)
            {
                if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                {
                    R = true;
                    return R;
                }
            }

            if (checkByRanges.Checked)
            {
                if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()) && !string.IsNullOrEmpty(txtSetTemp2.Text.Trim()))
                {
                    if (Convert.ToInt32(txtSetTemp1.Text.Trim()) > Convert.ToInt32(txtSetTemp2.Text.Trim()))
                    {
                        R = true;
                        return R;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Wrong ranges", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return R;
                    }
                   
                }
            }
            System.Windows.Forms.MessageBox.Show("There are empty spaces", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return R;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarArranque();
            checkByRanges.Checked = true;
        }

        private void TimerHoraFecha_Tick(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dddd, MM/dd/yyyy");
            lbHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbFecha.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fecha);
        }

        private bool reconocerCOM(string COM)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    return false;
                }
                // Remember Baud Rate
                serialPort1.PortName = COM;
                serialPort1.Open();

                //string validarData = serialPort1.ReadExisting();

                //if (validarData == null || validarData == "")
                //{
                //    serialPort1.Close();

                //    MessageBox.Show("Data is not being received correctly. The program will not start until this is fixed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);


                //    return false;
                //}

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.IconChar == FontAwesome.Sharp.IconChar.ToggleOff)
            {
                if (reconocerCOM(cbCOMSelect.SelectedItem.ToString()))
                {
                    TimerEMOActive.Stop();

                    cbSelect.Enabled = true;
                    cbCOMSelect.Enabled = false;
                    btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    lbConnectedStatus.Text = "Connected";
                    BtnRefreshCOM.Visible = false;

                    lbConnectedStatus.ForeColor = Color.FromArgb(0, 143, 57);

                    // cCHANGER
                    TimerDataTCS.Start();
                    ResetearChart();
                    timerForTC.Start();

                    PicTC1.Image.Dispose();
                    PicTC1.Image = Properties.Resources.tc1on;
                    PicTC2.Image.Dispose();
                    PicTC2.Image = Properties.Resources.tc2on;
                    PicTC3.Image.Dispose();
                    PicTC3.Image = Properties.Resources.tc3on;
                    PicTC4.Image.Dispose();
                    PicTC4.Image = Properties.Resources.tc4on;
                    PicTC5.Image.Dispose();
                    PicTC5.Image = Properties.Resources.tc5on;
                    PicTC6.Image.Dispose();
                    PicTC6.Image = Properties.Resources.tc6on;
                    PicTC7.Image.Dispose();
                    PicTC7.Image = Properties.Resources.tc7on;
                    PicTC8.Image.Dispose();
                    PicTC8.Image = Properties.Resources.tc8on;

                    picGREEN.Image.Dispose();
                    picGREEN.Image = Properties.Resources.tc8on;
                    picRED.Image.Dispose();
                    picRED.Image = Properties.Resources.tc1off;

                    // Poner led ROJO ON cuando no hay ningun proceso en movimiento.
                    // ROJO ON
                    //YELLOW OFF
                    // GREEN OFF

                    picGREEN.Image.Dispose();
                    picRED.Image.Dispose();
                    picYELLOW.Image.Dispose();

                    picGREEN.Image = Properties.Resources.tc8off;
                    picYELLOW.Image = Properties.Resources.tc3off;
                    picRED.Image = Properties.Resources.tc1on;

                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Write("#020004" + "\r");
                    BanderaRespuestaParaTCS = false;
                }

            }
            else if (btnConnect.IconChar == FontAwesome.Sharp.IconChar.ToggleOn)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Write("#020000" + "\r");
                    BanderaRespuestaParaTCS = false;
                    serialPort1.Close();
                }

                picGREEN.Image.Dispose();
                picRED.Image.Dispose();
                picYELLOW.Image.Dispose();

                picGREEN.Image = Properties.Resources.tc8off;
                picYELLOW.Image = Properties.Resources.tc3off;
                picRED.Image = Properties.Resources.tc1off;

                LimpiarArranque();
                btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                lbConnectedStatus.Text = "Disconnected";
                BtnRefreshCOM.Visible = true;
                lbConnectedStatus.ForeColor = Color.Red;

                TimerDataTCS.Stop();
                timerForTC.Stop();
                ResetearChart();

                PicTC1.Image.Dispose();
                PicTC1.Image = Properties.Resources.tc1off;
                PicTC2.Image.Dispose();
                PicTC2.Image = Properties.Resources.tc2off;
                PicTC3.Image.Dispose();
                PicTC3.Image = Properties.Resources.tc3off;
                PicTC4.Image.Dispose();
                PicTC4.Image = Properties.Resources.tc4off;
                PicTC5.Image.Dispose();
                PicTC5.Image = Properties.Resources.tc5off;
                PicTC6.Image.Dispose();
                PicTC6.Image = Properties.Resources.tc6off;
                PicTC7.Image.Dispose();
                PicTC7.Image = Properties.Resources.tc7off;
                PicTC8.Image.Dispose();
                PicTC8.Image = Properties.Resources.tc8off;
            }

        }

        double tiempo = 0;
        private void timerForTC_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo + 100;
            double temp = tiempo / 1000;

            chart1.Series["TC-1"].Points.AddXY(temp.ToString(),TC8Num.ToString());
            chart1.Series["TC-2"].Points.AddXY(temp.ToString(),TC7Num.ToString());
            chart1.Series["TC-3"].Points.AddXY(temp.ToString(),TC6Num.ToString());
            chart1.Series["TC-4"].Points.AddXY(temp.ToString(),TC5Num.ToString());
            chart1.Series["TC-5"].Points.AddXY(temp.ToString(),TC4Num.ToString());
            chart1.Series["TC-6"].Points.AddXY(temp.ToString(),TC3Num.ToString());
            chart1.Series["TC-7"].Points.AddXY(temp.ToString(),TC2Num.ToString());
            chart1.Series["TC-8"].Points.AddXY(temp.ToString(),TC1Num.ToString());

            chart1.ChartAreas[0].RecalculateAxesScale();

            GraficarDatosTxt();

        }

        // Variables para el temporizador

        int minutos = 0;
        int segundos = 0; 
        int minutos2 = 0;
        int segundos2 = 0;

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTemporizador.Text = "00:00";
            minutos = 0;
            segundos = 0;
        }

        //Temporizador
        private void timerTempo_Tick(object sender, EventArgs e)
        {
            if (minutos != 0 || segundos != 0)
            {
                if (segundos != 0)
                {
                            segundos--;
                            if (segundos < 10)
                            {
                                if (minutos < 10)
                                {
                                    txtTemporizador.Text = "0" + minutos.ToString() + ":0" + segundos.ToString();
                                }
                                else
                                {
                                    txtTemporizador.Text = minutos.ToString() + ":0" + segundos.ToString();
                                }
                            }
                            else
                            {
                                if (minutos < 10)
                                {
                                    txtTemporizador.Text = "0" + minutos.ToString() + ":" + segundos.ToString();
                                }
                                else
                                {
                                    txtTemporizador.Text = minutos.ToString() + ":" + segundos.ToString();
                                }
                            }
                }
                else
                {
                    if (minutos!=0)
                    {
                        minutos--;
                        segundos = 59;
                        if (minutos < 10)
                        {
                            if (segundos < 10)
                            {
                                txtTemporizador.Text = "0" + minutos.ToString() + ":0" + segundos.ToString();
                            }
                            else
                            {
                                txtTemporizador.Text = "0" + minutos.ToString() + ":" + segundos.ToString();
                            }
                        }
                        else
                        {
                            if (segundos < 10)
                            {
                                txtTemporizador.Text = minutos.ToString() + ":0" + segundos.ToString();
                            }
                            else
                            {
                                txtTemporizador.Text = minutos.ToString() + ":" + segundos.ToString();
                            }
                        }
                        
                    }
                }
            }


            if (minutos2 != 0 || segundos2 != 0)
            {
                if (segundos2 != 0)
                {
                    segundos2--;
                    if (segundos2 < 10)
                    {
                        if (minutos2 < 10)
                        {
                            txtTemporizador2.Text = "0" + minutos2.ToString() + ":0" + segundos2.ToString();
                        }
                        else
                        {
                            txtTemporizador2.Text = minutos2.ToString() + ":0" + segundos2.ToString();
                        }
                    }
                    else
                    {
                        if (minutos2 < 10)
                        {
                            txtTemporizador2.Text = "0" + minutos2.ToString() + ":" + segundos2.ToString();
                        }
                        else
                        {
                            txtTemporizador2.Text = minutos2.ToString() + ":" + segundos2.ToString();
                        }
                    }
                }
                else
                {
                    if (minutos2 != 0)
                    {
                        minutos2--;
                        segundos2 = 59;
                        if (minutos2 < 10)
                        {
                            if (segundos2 < 10)
                            {
                                txtTemporizador2.Text = "0" + minutos2.ToString() + ":0" + segundos2.ToString();
                            }
                            else
                            {
                                txtTemporizador2.Text = "0" + minutos2.ToString() + ":" + segundos2.ToString();
                            }
                        }
                        else
                        {
                            if (segundos2 < 10)
                            {
                                txtTemporizador2.Text = minutos2.ToString() + ":0" + segundos2.ToString();
                            }
                            else
                            {
                                txtTemporizador2.Text = minutos2.ToString() + ":" + segundos2.ToString();
                            }
                        }

                    }
                }
            }

        }

        private void btnAddMin2_Click(object sender, EventArgs e)
        {
            if (minutos2 < 59)
            {
                minutos2++;
                if (minutos2 < 10)
                {
                    if (segundos2 < 10)
                    {
                        txtTemporizador2.Text = "0" + minutos2.ToString() + ":0" + segundos2.ToString();
                    }
                    else
                    {
                        txtTemporizador2.Text = "0" + minutos2.ToString() + ":" + segundos2.ToString();
                    }
                }
                else
                {
                    if (segundos2 < 10)
                    {
                        txtTemporizador2.Text = minutos2.ToString() + ":0" + segundos2.ToString();
                    }
                    else
                    {
                        txtTemporizador2.Text = minutos2.ToString() + ":" + segundos2.ToString();
                    }
                }
            }
        }

        private void btnAddSeg2_Click(object sender, EventArgs e)
        {
            if (segundos2 < 59)
            {
                segundos2++;
                if (segundos2 < 10)
                {
                    if (minutos2 < 10)
                    {
                        txtTemporizador2.Text = "0" + minutos2.ToString() + ":0" + segundos2.ToString();
                    }
                    else
                    {
                        txtTemporizador2.Text = minutos2.ToString() + ":0" + segundos2.ToString();
                    }
                }
                else
                {
                    if (minutos2 < 10)
                    {
                        txtTemporizador2.Text = "0" + minutos2.ToString() + ":" + segundos2.ToString();
                    }
                    else
                    {
                        txtTemporizador2.Text = minutos2.ToString() + ":" + segundos2.ToString();
                    }
                }
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            txtTemporizador2.Text = "00:00";
            minutos2 = 0;
            segundos2 = 0;
        }

        private void btnEMO_Click(object sender, EventArgs e)
        {
            // APAGAR HEATER Y CHILLER.
            if (FormatCadena == "Chiller")
            {
                SetConfigSerialPortForChiller();
                Thread.Sleep(1000);
                serialPort1.DiscardOutBuffer();
                serialPort1.WriteLine(":0106000C0000ED" + Environment.NewLine);
                BanderaRespuestaParaTCS = false;
                Thread.Sleep(1000);
                SetConfigSerialPortForTCS();
            }

            if (FormatCadena == "Heater")
            {
                if (serialPort1.IsOpen)
                {
                    SetConfigSerialPortForHeater();
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    byte[] bytes = { 4, 6, 33, 3, 0, 0, 115, 163 };
                    serialPort1.Write(bytes, 0, bytes.Length);
                    BanderaRespuestaParaTCS = false;
                    Thread.Sleep(1000);
                    SetConfigSerialPortForTCS();
                }
            }

            if (serialPort1.IsOpen)
            {
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Write("#020007" + "\r");
                BanderaRespuestaParaTCS = false;

                serialPort1.Close();
            }
            LimpiarArranque();
            btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            lbConnectedStatus.Text = "Disconnected";
            BtnRefreshCOM.Visible = true;
            lbConnectedStatus.ForeColor = Color.Red;

            TimerDataTCS.Stop();
            timerForTC.Stop();
            ResetearChart();

            PicTC1.Image.Dispose();
            PicTC1.Image = Properties.Resources.tc1off;
            PicTC2.Image.Dispose();
            PicTC2.Image = Properties.Resources.tc2off;
            PicTC3.Image.Dispose();
            PicTC3.Image = Properties.Resources.tc3off;
            PicTC4.Image.Dispose();
            PicTC4.Image = Properties.Resources.tc4off;
            PicTC5.Image.Dispose();
            PicTC5.Image = Properties.Resources.tc5off;
            PicTC6.Image.Dispose();
            PicTC6.Image = Properties.Resources.tc6off;
            PicTC7.Image.Dispose();
            PicTC7.Image = Properties.Resources.tc7off;
            PicTC8.Image.Dispose();
            PicTC8.Image = Properties.Resources.tc8off;

            // PRENDER Y APAGAR LOS 3.
            // REAL DEJA ENCENDIDO LOS 3.
            TimerEMOActive.Start();

        }

        private void btnSetTemp_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                switch (FormatCadena)
                {
                    case "Chiller":
                        if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                        {
                            SetConfigSerialPortForChiller();
                            Thread.Sleep(1000);
                            SetTemperatureChiller(txtSetTemp1.Text);
                            Thread.Sleep(1000);
                            SetConfigSerialPortForTCS();
                            txtActualSetPoint.Text = txtSetTemp1.Text + " C°";
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("SetPoint must not be Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "Heater":

                        if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
                        {
                            if (Convert.ToInt32(txtSetTemp1.Text)>= 25 && Convert.ToInt32(txtSetTemp1.Text) <= 85)
                            {
                                serialPort1.DiscardInBuffer();
                                serialPort1.DiscardOutBuffer();
                                serialPort1.Write("#020001" + "\r");
                                BanderaRespuestaParaTCS = false;

                                picGREEN.Image.Dispose();
                                picRED.Image.Dispose();
                                picYELLOW.Image.Dispose();

                                picGREEN.Image = Properties.Resources.tc8on;
                                picYELLOW.Image = Properties.Resources.tc3off;
                                picRED.Image = Properties.Resources.tc1off;

                                SendSetTempHeaterAndTurnItOn();
                                txtActualSetPoint.Text = txtSetTemp1.Text + " C°";
                                EncenderHeaterFromSetTemp();
                                btnSetTemp.Enabled = false;
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Out of range\nRange from 𝟮𝟱C° to 𝟴𝟱C°", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSetTemp1.Clear();
                                TrackbarTemp.Value = 25;
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("SetPoint must not be Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "Ninguno":
                        
                        break;
                }
            }
            
        }
        private void SetConfigSerialPortForHeater()
        {
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.Even;
        }

        private void SetConfigSerialPortForChiller()
        {
            serialPort1.DataBits = 7;
            serialPort1.Parity = Parity.Even;
        }

        private void SetConfigSerialPortForTCS()
        {
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
        
        }

        private void SetTemperatureChiller(string TemperatureToSet)
        {
            int ConsTemp = 18;
            string Temperatura = TemperatureToSet;
            Temperatura += "0";
            Temperatura = decimalHexadecimal(Convert.ToInt32(Temperatura));

            if (Temperatura.Length == 3)
            {
                string newTempPlus0 = "0" + Temperatura;
                Temperatura = newTempPlus0;
            }
            else if (Temperatura.Length == 2)
            {
                string newTempPlus0 = "00" + Temperatura;
                Temperatura = newTempPlus0;
            }

            string TemperaturaComand = Temperatura;

            string Temp1par = Temperatura.Substring(0, 2);
            string Temp2par = Temperatura.Substring(2, 2);

            int Temp1 = hexadecimalDecimal(Temp1par);
            int Temp2 = hexadecimalDecimal(Temp2par);

            Temperatura = (Temp1 + Temp2 + ConsTemp).ToString();

            Temperatura = (255 - Convert.ToInt32(Temperatura) + 1).ToString();

            Temperatura = decimalHexadecimal(Convert.ToInt32(Temperatura));

            string ComandoFinal = ":0106000B" + TemperaturaComand + Temperatura;


            serialPort1.DiscardOutBuffer();
            serialPort1.WriteLine(ComandoFinal + Environment.NewLine);
            BanderaRespuestaParaTCS = false;
        }

        
        private void btnAddSeg_Click(object sender, EventArgs e)
        {
            if (segundos < 59)
            {
                segundos++;
                if (segundos < 10)
                {
                    if (minutos < 10)
                    {
                        txtTemporizador.Text = "0" + minutos.ToString() + ":0" + segundos.ToString();
                    }
                    else
                    {
                        txtTemporizador.Text = minutos.ToString() + ":0" + segundos.ToString();
                    }
                }
                else
                {
                    if (minutos < 10)
                    {
                        txtTemporizador.Text = "0" + minutos.ToString() + ":" + segundos.ToString();
                    }
                    else
                    {
                        txtTemporizador.Text = minutos.ToString() + ":" + segundos.ToString();
                    }
                }
            }
        }

        private void btnAddMin_Click(object sender, EventArgs e)
        {
            if (minutos<59)
            {
                minutos++;
                if (minutos < 10)
                {
                    if (segundos < 10)
                    {
                        txtTemporizador.Text = "0" + minutos.ToString() + ":0" + segundos.ToString();
                    }
                    else
                    {
                        txtTemporizador.Text = "0" + minutos.ToString() + ":" + segundos.ToString();
                    }
                }
                else
                {
                    if (segundos < 10)
                    {
                        txtTemporizador.Text = minutos.ToString() + ":0" + segundos.ToString();
                    }
                    else
                    {
                        txtTemporizador.Text = minutos.ToString() + ":" + segundos.ToString();
                    }
                }
            }
        }




        private void btnEMO_DoubleClick(object sender, EventArgs e)
        {
            LimpiarArranque();
            checkByRanges.Checked = true;
        }

        private void cbCOMSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCOMSelect.SelectedIndex >= 0)
            {
                btnConnect.Enabled = true;
            }
        }

        bool BanderaRespuestaParaTCS = false;
        Boolean i = false;

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (i == false)
                {
                    tiempo = 0;
                    i = true;
                }

                    if (BanderaRespuestaParaTCS)
                    {
                        try
                        {
                            Thread.Sleep(2000);
                            string DataIn = serialPort1.ReadExisting();
                            if (DataIn != null && DataIn != String.Empty)
                            {
                                ReadData(DataIn);
                                serialPort1.DiscardInBuffer();
                            }
                        }
                        catch (Exception)
                        {
                           
                        }
                    }
                
            }
           
          

        }
        

        // Metodos para conversiones hexa a decimal y viceversa

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

        string TC1S = "";
        string TC2S = "";
        string TC3S = "";
        string TC4S = "";
        string TC5S = "";
        string TC6S = "";
        string TC7S = "";
        string TC8S = "";
        string TC9S = "";
        string TC10S = "";
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

        private void TimerDataTCS_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                Cycle();
            }
        }

        private void Cycle()
        {
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Write("#03" + "\r");
            BanderaRespuestaParaTCS = true;
        }


        private void ReadData(string data)
        {
            if (data!= null && data != string.Empty)
            {
                // Paso 1 Quitar cualquier espacio
                string tcs = data.Trim();
                if (tcs.Length == 71)
                {
                    tcs = tcs.Replace("\r", string.Empty);
                    //Paso 2 quitar el >+ inicial
                    tcs = tcs.Substring(2);
                    //Paso 3 separar por +
                    string[] TC = tcs.Split('+');

                    //Paso 4 asignar cada TC
                    if (TC.Length == 10)
                    {
                        TC1S = TC[0];
                        TC2S = TC[1];
                        TC3S = TC[2];
                        TC4S = TC[3];
                        TC5S = TC[4];
                        TC6S = TC[5];
                        TC7S = TC[6];
                        TC8S = TC[7];
                        TC9S = TC[8];
                        TC10S = TC[9];
                    }

                    // Paso 5 reasignar valores

                    TC1S = TC1S.Substring(2);
                    TC2S = TC2S.Substring(2);
                    TC3S = TC3S.Substring(2);
                    TC4S = TC4S.Substring(2);
                    TC5S = TC5S.Substring(2);
                    TC6S = TC6S.Substring(2);
                    TC7S = TC7S.Substring(2);
                    TC8S = TC8S.Substring(2);
                    TC9S = TC9S.Substring(2);
                    TC10S = TC10S.Substring(2);

                    // Paso 6 Separar a las con numeros a las con C°

                    TC1Num = Convert.ToDouble(TC1S);
                    TC2Num = Convert.ToDouble(TC2S);
                    TC3Num = Convert.ToDouble(TC3S);
                    TC4Num = Convert.ToDouble(TC4S);
                    TC5Num = Convert.ToDouble(TC5S);
                    TC6Num = Convert.ToDouble(TC6S);
                    TC7Num = Convert.ToDouble(TC7S);
                    TC8Num = Convert.ToDouble(TC8S);
                    TC9Num = Convert.ToDouble(TC9S);
                    TC10Num = Convert.ToDouble(TC10S);

                    // Paso Final
                    TC1S = TC1S + " C°";
                    TC2S = TC2S + " C°";
                    TC3S = TC3S + " C°";
                    TC4S = TC4S + " C°";
                    TC5S = TC5S + " C°";
                    TC6S = TC6S + " C°";
                    TC7S = TC7S + " C°";
                    TC8S = TC8S + " C°";
                    TC9S = TC9S + " C°";
                    TC10S = TC10S + " C°";

                    //TODO GRAFICAR.
                    GraficarDatosTxt();
                }
            }
        }

        private void GraficarDatosTxt()
        {
            txtTC1.Text = TC8S;
            txtTC2.Text = TC7S;
            txtTC3.Text = TC6S;
            txtTC4.Text = TC5S;
            txtTC5.Text = TC4S;
            txtTC6.Text = TC3S;
            txtTC7.Text = TC2S;
            txtTC8.Text = TC1S;
            txtActualTempTCGeneral.Text = TC5S;
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMaxi_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BtnRefreshCOM_Click(object sender, EventArgs e)
        {
            if (lbConnectedStatus.Text == "Disconnected")
            {
                btnConnect.Enabled = false;

                cbCOMSelect.Enabled = true;
                string[] ports = SerialPort.GetPortNames();
                cbCOMSelect.Items.Clear();
                cbCOMSelect.Items.AddRange(ports);

                SetConfigSerialPortForTCS();
                BanderaRespuestaParaTCS = false;
            }
        }

        bool PrendeApaga = true;
        private void TimerEMOActive_Tick(object sender, EventArgs e)
        {
            if (PrendeApaga)
            {
                picGREEN.Image.Dispose();
                picRED.Image.Dispose();
                picYELLOW.Image.Dispose();

                picGREEN.Image = Properties.Resources.tc8on;
                picYELLOW.Image = Properties.Resources.tc3on;
                picRED.Image = Properties.Resources.tc1on;
                PrendeApaga = false;
            }
            else
            {
                picGREEN.Image.Dispose();
                picRED.Image.Dispose();
                picYELLOW.Image.Dispose();

                picGREEN.Image = Properties.Resources.tc8off;
                picYELLOW.Image = Properties.Resources.tc3off;
                picRED.Image = Properties.Resources.tc1off;
                PrendeApaga = true;
            }
        }
    }
}




