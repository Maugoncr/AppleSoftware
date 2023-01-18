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

            // CONECTAR COM
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
            
            btnAddMin.Enabled = false;
            btnAddMin2.Enabled = false;
            btnAddSeg.Enabled = false;
            btnAddSeg2.Enabled = false;
            btnReset.Enabled = false;
            btnReset2.Enabled = false;


            txtSetTemp1.Clear();
           
            txtSetTemp2.Clear();

            SelectTittle.Text = "Not selected";
            lbStatus.Text = "-----";
            lbStatus.ForeColor = Color.Red;

            //Desactivar hasta tener la conexion

            cbSelect.Enabled = false;

            TrackbarTemp.Value = 5;
          

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
                //checkOnlyOne.Enabled = true;
                checkByRanges.Enabled = true;
                lbStatus.Text = "OFF";

                btnON.BackColor = Color.FromArgb(0, 143, 57);

                // Cooling
                if (cbSelect.SelectedIndex == 1)
                {
                    FormatCadena = "Chiller";
                    ChillerRangeOn();
                    //TrackbarTemp.Minimum = 5;
                    //TrackbarTemp.Maximum = 40;
                    //TrackbarTemp.Size = new System.Drawing.Size(32, 231);
                    //TrackbarTemp.Location = new System.Drawing.Point(353, 88);

                    SelectTittle.Text = "Cooling";
                    txtSetTemp2.Text = "5";
                    txtSetTemp1.Text = "40";
                   

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
                    FormatCadena = "Heater";
                    ChillerRangeOff();


                    SelectTittle.Text = "Heating";
                    txtSetTemp2.Text = "5";
                    txtSetTemp1.Text = "80";
                   

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
            if (TrackbarTemp.Value < 5)
            {
                TrackbarTemp.Value = 5;
            }
            if (TrackbarTemp.Value > 80)
            {
                TrackbarTemp.Value = 80;
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
            if (!string.IsNullOrEmpty(txtSetTemp1.Text.Trim()))
            {
                if (Convert.ToInt32(txtSetTemp1.Text.Trim()) > 100)
                {
                    System.Windows.Forms.MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSetTemp1.Clear();
                    TrackbarTemp.Value = 25;
                    return;
                }
                if (FormatCadena == "Chiller")
                {
                    int validate =  Convert.ToInt32(txtSetTemp1.Text.Trim());
                    if (validate >= 5 && validate <= 40)
                    {
                        TrackbarTemp.Value = Convert.ToInt32(txtSetTemp1.Text.Trim());
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSetTemp1.Clear();
                        TrackbarTemp.Value = 5;
                        return;
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
        private void ChillerRangeOff()
        {
            Chiller1.Visible = false;
            Chiller2.Visible = false;
            Chiller3.Visible = false;
            Chiller4Label.Visible = false;
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

        private void btnON_Click(object sender, EventArgs e)
        {

            if (lbStatus.Text == "OFF" && ValidadEncender())
            {
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
                Temporizador.Start();

                //Comando iniciar Chiller

                if (FormatCadena == "Chiller")
                {
                    if (serialPort1.IsOpen)
                    {
                        SetConfigSerialPortForChiller();
                        Thread.Sleep(1000);
                        serialPort1.DiscardOutBuffer();
                        serialPort1.WriteLine(":0106000C0001EC" + Environment.NewLine);
                        BanderaRespuestaParaTCS = false;
                        Thread.Sleep(1000);
                        SetConfigSerialPortForTCS();

                    }
                   
                }

                if (FormatCadena == "Heater")
                {
                    if (serialPort1.IsOpen)
                    {
                        SetConfigSerialPortForHeater();
                        Thread.Sleep(1000);
                        serialPort1.DiscardOutBuffer();
                        // TODO SETEAR UNA TEMP POR DEFECTO PARA EL ENCENDIDO.

                       // byte[] bytes = { 4, 6, 33, 3, 0, 0, 115, 163 };
                       // serialPort1.Write(bytes, 0, bytes.Length);


                        BanderaRespuestaParaTCS = false;
                        Thread.Sleep(1000);
                        SetConfigSerialPortForTCS();
                    }
                }


            }
            else if (lbStatus.Text == "ON")
            {
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
                btnON.BackColor = Color.FromArgb(0, 143, 57);
                Temporizador.Stop();

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
                    cbSelect.Enabled = true;
                    cbCOMSelect.Enabled = false;
                    btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    lbConnectedStatus.Text = "Connected";
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


                }

            }
            else if (btnConnect.IconChar == FontAwesome.Sharp.IconChar.ToggleOn)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                LimpiarArranque();
                btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                lbConnectedStatus.Text = "Disconnected";
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

                picGREEN.Image.Dispose();
                picGREEN.Image = Properties.Resources.tc8off;
                picRED.Image.Dispose();
                picRED.Image = Properties.Resources.tc1on;

            }

        }

        double tiempo = 0;
        private void timerForTC_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo + 100;
            double temp = tiempo / 1000;

            chart1.Series["TC-1"].Points.AddXY(temp.ToString(),TC1Num.ToString());
            chart1.Series["TC-2"].Points.AddXY(temp.ToString(),TC2Num.ToString());
            chart1.Series["TC-3"].Points.AddXY(temp.ToString(),TC3Num.ToString());
            chart1.Series["TC-4"].Points.AddXY(temp.ToString(),TC4Num.ToString());
            chart1.Series["TC-5"].Points.AddXY(temp.ToString(),TC5Num.ToString());
            chart1.Series["TC-6"].Points.AddXY(temp.ToString(),TC6Num.ToString());
            chart1.Series["TC-7"].Points.AddXY(temp.ToString(),TC7Num.ToString());
            chart1.Series["TC-8"].Points.AddXY(temp.ToString(),TC8Num.ToString());

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

        }

        private void btnSetTemp_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                switch (FormatCadena)
                {
                    case "Chiller":
                        SetConfigSerialPortForChiller();
                        Thread.Sleep(1000);
                        SetTemperatureChiller(txtSetTemp1.Text);
                        Thread.Sleep(1000);
                        SetConfigSerialPortForTCS();
                        break;
                    case "Heater":
                        //TODO


                        switch (txtSetTemp1.Text)
                        {
                            case "1":
                                //SetConfigSerialPortForHeater();
                                //Thread.Sleep(1000);
                                //serialPort1.DiscardOutBuffer();
                                ////TODO Cambiar las cadenas
                                //byte[] bytes = { 4, 6, 33, 3, 0, 0, 115, 163 };
                                //serialPort1.Write(bytes, 0, bytes.Length);
                                //BanderaRespuestaParaTCS = false;
                                //Thread.Sleep(1000);
                                //SetConfigSerialPortForTCS();
                                // Check ☻

                                break;
                            case "2":
                                //SetConfigSerialPortForHeater();
                                //Thread.Sleep(1000);
                                //serialPort1.DiscardOutBuffer();
                                ////TODO Cambiar las cadenas
                                //byte[] bytes2 = { 4, 6, 33, 3, 0, 0, 116, 163 };
                                //serialPort1.Write(bytes2, 0, bytes2.Length);
                                //BanderaRespuestaParaTCS = false;
                                //Thread.Sleep(1000);
                                //SetConfigSerialPortForTCS();
                                break;
                            case "3":

                                break;
                            case "4":

                                break;
                            case "5":

                                break;
                            case "6":

                                break;
                            case "7":

                                break;
                            case "8":

                                break;
                            case "9":

                                break;
                            case "10":

                                break;
                            case "11":

                                break;
                            case "12":

                                break;
                            case "13":

                                break;
                            case "14":

                                break;
                            case "15":

                                break;
                            case "16":

                                break;
                            case "17":

                                break;
                            case "18":

                                break;
                            case "19":

                                break;
                            case "20":

                                break;
                            case "21":

                                break;
                            case "22":

                                break;
                            case "23":

                                break;
                            case "24":

                                break;
                            case "25":

                                break;
                            case "26":

                                break;
                            case "27":

                                break;
                            case "28":

                                break;
                            case "29":

                                break;
                            case "30":

                                break;
                            case "31":

                                break;
                            case "32":

                                break;
                            case "33":

                                break;
                            case "34":

                                break;
                            case "35":

                                break;
                            case "36":

                                break;
                            case "37":

                                break;
                            case "38":

                                break;
                            case "39":

                                break;
                            case "40":

                                break;
                            case "41":

                                break;
                            case "42":

                                break;
                            case "43":

                                break;
                            case "44":

                                break;
                            case "45":

                                break;
                            case "46":

                                break;
                            case "47":

                                break;
                            case "48":

                                break;
                            case "49":

                                break;
                            case "50":

                                break;
                            case "51":

                                break;
                            case "52":

                                break;
                            case "53":

                                break;
                            case "54":

                                break;
                            case "55":

                                break;
                            case "56":

                                break;
                            case "57":

                                break;
                            case "58":

                                break;
                            case "59":

                                break;
                            case "60":

                                break;
                            case "61":

                                break;
                            case "62":

                                break;
                            case "63":

                                break;
                            case "64":

                                break;
                            case "65":

                                break;
                            case "66":

                                break;
                            case "67":

                                break;
                            case "68":

                                break;
                            case "69":

                                break;
                            case "70":

                                break;
                            case "71":

                                break;
                            case "72":

                                break;
                            case "73":

                                break;
                            case "74":

                                break;
                            case "75":

                                break;
                            case "76":

                                break;
                            case "77":

                                break;
                            case "78":

                                break;
                            case "79":

                                break;
                            case "80":

                                break;
                            case "81":

                                break;
                            case "82":

                                break;
                            case "83":

                                break;
                            case "84":

                                break;
                            case "85":

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
                tcs = tcs.Replace("\r",string.Empty);
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

        private void GraficarDatosTxt()
        {
            txtTC1.Text = TC9S;
            txtTC2.Text = TC2S;
            txtTC3.Text = TC3S;
            txtTC4.Text = TC4S;
            txtTC5.Text = TC5S;
            txtTC6.Text = TC6S;
            txtTC7.Text = TC7S;
            txtTC8.Text = TC8S;
            txtActualTempTCGeneral.Text = TC1S;
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
    }
}




