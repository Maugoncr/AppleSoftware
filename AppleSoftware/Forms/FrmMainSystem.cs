using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AppleSoftware.Forms
{
    public partial class FrmMainSystem : Form
    {
        public int CualTemperatura;

        public FrmMainSystem()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMainSystem_Load(object sender, EventArgs e)
        {
            TimerHoraFecha.Start();
            CargarCombo();
            LimpiarArranque();
            checkByRanges.Checked = true;

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

        private void LimpiarArranque()
        {
            cbSelect.SelectedIndex = -1;
            checkOnlyOne.Checked = true;
            checkTemp1.Checked = true;
            checkByRanges.Checked = false;
            CualTemperatura = 1;

            // CONECTAR COM
            btnConnect.Enabled = false;

            cbCOMSelect.Enabled = true;
            string[] ports = SerialPort.GetPortNames();
            cbCOMSelect.Items.Clear();
            cbCOMSelect.Items.AddRange(ports);

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


            i = false;

            // Desactivar todo hasta que eliga cooling o heating

            btnON.Enabled = false;
            TrackbarTemp.Enabled = false;
            txtSetTemp1.Enabled = false;
            checkOnlyOne.Enabled = false;
            checkByRanges.Enabled = false;

            txtSetTemp1.Clear();
           
            txtSetTemp2.Clear();
           

            lbStatus.Text = "-----";
            lbStatus.ForeColor = Color.Red;

            TrackbarTemp.Value = 0;
            TrackbarTemp.TrackerColor = Color.FromArgb(64, 64, 64);

            btnON.BackColor = Color.FromArgb(64, 64, 64);

            panel11.BackColor = Color.FromArgb(64, 64, 64);
            panel12.BackColor = Color.FromArgb(64, 64, 64);
            panel13.BackColor = Color.FromArgb(64, 64, 64);
            panel14.BackColor = Color.FromArgb(64, 64, 64);

            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel9.BackColor = Color.FromArgb(64, 64, 64);
            panel7.BackColor = Color.FromArgb(64, 64, 64);
            panel10.BackColor = Color.FromArgb(64, 64, 64);

            panel1.BackColor = Color.FromArgb(64, 64,64);
            panel2.BackColor = Color.FromArgb(64, 64, 64);
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel4.BackColor = Color.FromArgb(64, 64, 64);

            panelHeating.BackColor = SystemColors.Control;
            panelCooling.BackColor = SystemColors.Control;

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
                    txtSetTemp2.Text = "5";
                    txtSetTemp1.Text = "80";
                   

                    led1.Image.Dispose();
                    led2.Image.Dispose();
                    led1.Image = Properties.Resources.led_on_green;
                    led2.Image = Properties.Resources.led_off;

                    panel1.BackColor = Color.FromArgb(24, 130, 198);
                    panel2.BackColor = Color.FromArgb(24, 130, 198);
                    panel3.BackColor = Color.FromArgb(24, 130, 198);
                    panel4.BackColor = Color.FromArgb(24, 130, 198);

                    TrackbarTemp.TrackerColor = Color.FromArgb(24, 130, 198);

                    panel5.BackColor = Color.FromArgb(24, 130, 198);
                    panel9.BackColor = Color.FromArgb(24, 130, 198);
                    panel7.BackColor = Color.FromArgb(24, 130, 198);
                    panel10.BackColor = Color.FromArgb(24, 130, 198);

                    panel11.BackColor = Color.FromArgb(64, 64, 64);
                    panel12.BackColor = Color.FromArgb(64, 64, 64);
                    panel13.BackColor = Color.FromArgb(64, 64, 64);
                    panel14.BackColor = Color.FromArgb(64, 64, 64);

                    panelCooling.BackColor = Color.Yellow;
                    panelHeating.BackColor = SystemColors.Control;

                }
                // Heating
                else if (cbSelect.SelectedIndex == 0)
                {
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

                    TrackbarTemp.TrackerColor = Color.FromArgb(183, 43, 41);

                    panel11.BackColor = Color.FromArgb(183, 43, 41);
                    panel12.BackColor = Color.FromArgb(183, 43, 41);
                    panel13.BackColor = Color.FromArgb(183, 43, 41);
                    panel14.BackColor = Color.FromArgb(183, 43, 41);

                    panel5.BackColor = Color.FromArgb(64, 64, 64);
                    panel9.BackColor = Color.FromArgb(64, 64, 64);
                    panel7.BackColor = Color.FromArgb(64, 64, 64);
                    panel10.BackColor = Color.FromArgb(64, 64, 64);

                    panelHeating.BackColor = Color.Yellow;
                    panelCooling.BackColor = SystemColors.Control;
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
                    MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSetTemp1.Clear();
                    TrackbarTemp.Value = 0;
                    return;
                }
                TrackbarTemp.Value = Convert.ToInt32(txtSetTemp1.Text.Trim());
            }
            
        }

        private void txtSetTemp2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSetTemp2.Text.Trim()))
            {
                if (Convert.ToInt32(txtSetTemp2.Text.Trim()) > 100)
                {
                    MessageBox.Show("Out of range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Only numbers are allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSetTemp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Only numbers are allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        MessageBox.Show("Wrong ranges", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return R;
                    }
                   
                }
            }
            MessageBox.Show("There are empty spaces", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                string validarData = serialPort1.ReadExisting();

                if (validarData == null || validarData == "")
                {
                    serialPort1.Close();

                    MessageBox.Show("Data is not being received correctly. The program will not start until this is fixed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    return false;
                }

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
                    btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    lbConnectedStatus.Text = "Connected";
                    lbConnectedStatus.ForeColor = Color.FromArgb(0, 143, 57);

                    // cCHANGER
                    timerForTC.Start();

                }

            }
            else if (btnConnect.IconChar == FontAwesome.Sharp.IconChar.ToggleOn)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                btnConnect.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                lbConnectedStatus.Text = "Disconnected";
                lbConnectedStatus.ForeColor = Color.Red;

                timerForTC.Stop();
            }

        }







        double tiempo = 0;
        private void timerForTC_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo + 100;
            double temp = tiempo / 1000;

            chart1.Series["TC-1"].Points.AddXY(temp.ToString(),TC1.ToString());
            chart1.Series["TC-2"].Points.AddXY(temp.ToString(),TC2.ToString());
            chart1.Series["TC-3"].Points.AddXY(temp.ToString(),TC3.ToString());
            chart1.Series["TC-4"].Points.AddXY(temp.ToString(),TC4.ToString());
            chart1.Series["TC-5"].Points.AddXY(temp.ToString(),TC5.ToString());
            chart1.Series["TC-6"].Points.AddXY(temp.ToString(),TC6.ToString());
            chart1.Series["TC-7"].Points.AddXY(temp.ToString(),TC7.ToString());
            chart1.Series["TC-8"].Points.AddXY(temp.ToString(),TC8.ToString());

            chart1.ChartAreas[0].RecalculateAxesScale();

            txtTC1.Text = TC1.ToString() + "°C";
            txtTC2.Text = TC2.ToString() + "°C";
            txtTC3.Text = TC3.ToString() + "°C";
            txtTC4.Text = TC4.ToString() + "°C";
            txtTC5.Text = TC5.ToString() + "°C";
            txtTC6.Text = TC6.ToString() + "°C";
            txtTC7.Text = TC7.ToString() + "°C";
            txtTC8.Text = TC8.ToString() + "°C";
            txtActualTempTCGeneral.Text = TC9.ToString() + "°C";


        }


        double TC1, TC2,TC3,TC4,TC5,TC6,TC7,TC8,TC9;


        private void cbCOMSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCOMSelect.SelectedIndex >= 0)
            {
                btnConnect.Enabled = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(txtTest.Text.ToString());
        }

        Boolean i = false;

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (i == false)
            {
                tiempo = 0;
                i = true;
            }

            try
            {
                CapturarInformacion(serialPort1.ReadLine());
              
                serialPort1.DiscardInBuffer();
                    
            }
            catch (Exception)
            {
            }


        }

        private void CapturarInformacion(string cadena)
        {
            string[] temps = cadena.Split(',');

            TC1 = Convert.ToDouble(temps[0]);
            TC2 = Convert.ToDouble(temps[1]);
            TC3 = Convert.ToDouble(temps[2]);
            TC4 = Convert.ToDouble(temps[3]);
            TC5 = Convert.ToDouble(temps[4]);
            TC6 = Convert.ToDouble(temps[5]);
            TC7 = Convert.ToDouble(temps[6]);
            TC8 = Convert.ToDouble(temps[7]);
            TC9 = Convert.ToDouble(temps[8]);

        }


    }
}




