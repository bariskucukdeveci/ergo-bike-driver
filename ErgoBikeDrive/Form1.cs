using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgoBikeDrive
{
    public partial class myForm : Form
    {
        private bool onOffState = false;
        System.IO.Ports.SerialPort myPort = new System.IO.Ports.SerialPort("COM10", 4800, System.IO.Ports.Parity.None, 8);
        public myForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboPorts.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            if (ports != null && ports.Length > 0)
            {
                comboPorts.Items.AddRange(ports);
                comboPorts.SelectedItem = comboPorts.Items[0];
                myPort.PortName = comboPorts.SelectedItem.ToString();
                onOffSwitch.Enabled = true;
                onOffSwitch.BackColor = Color.Lime;
            }
            else
            {
                MessageBox.Show("No ports recognized");
                onOffSwitch.Enabled = false;
                onOffSwitch.BackColor = SystemColors.ControlDark;
                lblMessage.Text = "Connect appropriate ports to start!";
                lblMessage.ForeColor = Color.Red;
            }
            lblBikeImg.Enabled = false;
            if (!onOffState)
            {
                txtPower.Enabled = false;
            }
            lblByte.Visible = false;
            btnClearBytes.Visible = false;
        }

        private void txtPower_TextChanged(object sender, EventArgs e)
        {
            if (textConvert())
                btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (textConvert())
            {
                System.Text.ASCIIEncoding aa = new System.Text.ASCIIEncoding();

                byte[] crMessage = Encoding.UTF8.GetBytes("\r");
                byte[] powerStartMessage = aa.GetBytes("W");
                string s = txtPower.Text.Trim();
                s = s.PadLeft(3, '0');
                byte[] powerMessage = aa.GetBytes(s);
                if (!myPort.IsOpen)
                    myPort.Open();
                if (myPort.IsOpen)
                {
                    myPort.Write(powerStartMessage, 0, powerStartMessage.Length);
                    myPort.Write(powerMessage, 0, powerMessage.Length);
                    myPort.Write(crMessage, 0, crMessage.Length);
                    if (checkShowBytes.Checked)
                    {
                        ShowBytes(powerStartMessage, false);
                        ShowBytes(powerMessage, true);
                        ShowBytes(crMessage, false);
                    }
                    lblMessage.Text = "Power message is sent...";
                    lblMessage.ForeColor = Color.Lime;
                }
            }
        }
        private bool textConvert()
        {
            string enteredText = txtPower.Text;
            int power = 0;
            try
            {
                power = Convert.ToInt32(enteredText);
                if (power > 250 || power < 0)
                {
                    MessageBox.Show("Enter an integer between 0 and 250");
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong text!!!\nEnter an integer...");
                return false;
            }


        }

        private void onOffSwitch_Click(object sender, EventArgs e)
        {
            System.Text.ASCIIEncoding aa = new System.Text.ASCIIEncoding();
            byte[] startMessage = aa.GetBytes("s");
            byte[] crMessage = Encoding.UTF8.GetBytes("\r");
            byte[] stopMessage = aa.GetBytes("F");
            if (!onOffState)
            { //Starting the Bike.
                comboPorts.Enabled = false;
                this.BackColor = Color.White;
                lblBikeImg.Enabled = true;
                onOffSwitch.BackColor = Color.Red;
                onOffState = true;
                onOffSwitch.Text = "Stop";
                txtPower.Enabled = true;
                if (!myPort.IsOpen)
                    myPort.Open();
                if (myPort.IsOpen)
                {
                    myPort.Write(startMessage, 0, startMessage.Length);
                    myPort.Write(crMessage, 0, crMessage.Length);
                    if (checkShowBytes.Checked)
                    {
                        ShowBytes(startMessage,false);
                        ShowBytes(crMessage, false);
                    }
                    lblMessage.Text = "Bike is started...";
                    lblMessage.ForeColor = Color.Lime;
                }

            }
            else
            { //Stopping the Bike.
                comboPorts.Enabled = true;
                this.BackColor = SystemColors.ControlLight;
                lblBikeImg.Enabled = false;
                onOffSwitch.BackColor = Color.Lime;
                onOffState = false;
                onOffSwitch.Text = "Start";
                txtPower.Text = "";
                txtPower.Enabled = false;

                byte[] zeroPowerMessage = aa.GetBytes("000");
                byte[] powerStartMessage = aa.GetBytes("W");
                if (!myPort.IsOpen)
                    myPort.Open();
                if (myPort.IsOpen)
                {
                    //Zero power send first
                    myPort.Write(powerStartMessage, 0, powerStartMessage.Length);
                    myPort.Write(zeroPowerMessage, 0, zeroPowerMessage.Length);
                    myPort.Write(crMessage, 0, crMessage.Length);
                    //Stop message sent
                    myPort.Write(stopMessage, 0, stopMessage.Length);
                    myPort.Write(crMessage, 0, crMessage.Length);
                    if (checkShowBytes.Checked)
                    {
                        ShowBytes(powerStartMessage, false);
                        ShowBytes(zeroPowerMessage, true);
                        ShowBytes(crMessage, false);
                        ShowBytes(stopMessage, false);
                        ShowBytes(crMessage, false);
                    }
                    myPort.Close();
                    lblMessage.Text = "Bike is stopped...";
                    lblMessage.ForeColor = Color.Lime;
                }

            }
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPort.PortName = comboPorts.SelectedItem.ToString();
        }

        private void ShowBytes(byte[] mess, bool isPower)
        {
            if (checkShowBytes.Checked)
            {
                lblByte.Text += "\nMessage:";

                string strMessage = Encoding.ASCII.GetString(mess);
                string bitText = "";
                var bits = new BitArray(mess);
                int byteCounter = 1;
                int byteIndex = 0;
                string temptext = "";
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i])
                        bitText = "1" + bitText;
                    else
                        bitText = "0" + bitText;
                    if (byteCounter == 8)
                    {
                        bitText = "\n" + bitText;
                        byteCounter = 0;
                        if (isPower)
                        {
                            temptext += bitText.Substring(0, 9);
                            temptext += " = " + strMessage.ToCharArray()[byteIndex];
                            byteIndex++;
                        }
                        else
                        {
                            if (strMessage != "\r")
                                bitText += " = " + strMessage.ToCharArray()[byteIndex];
                            else
                                bitText += " = <CR>";
                            byteIndex++;
                        }
                            
                    }
                    byteCounter++;
                }
                if (isPower)
                    bitText = temptext;
                lblByte.Text += bitText + "\n";
            }
            btnClearBytes.Visible = true;
        }

        private void checkShowBytes_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkShowBytes.Checked)
            {
                lblByte.Visible = true;
            }
            else
            {
                lblByte.Visible = false;
                btnClearBytes.Visible = false;
            }
            //System.Text.ASCIIEncoding aa = new System.Text.ASCIIEncoding();
            //byte[] startMessage = aa.GetBytes("s");
            //byte[] crMessage = Encoding.UTF8.GetBytes("\r");
            //byte[] stopMessage = aa.GetBytes("F");
            //byte[] zeroPowerMessage = aa.GetBytes("025");
            //byte[] powerStartMessage = aa.GetBytes("W");
            //ShowBytes(startMessage, false);
            //ShowBytes(crMessage, false);
            //ShowBytes(powerStartMessage, false);
            //ShowBytes(zeroPowerMessage, true);
            //ShowBytes(crMessage, false);
            //ShowBytes(stopMessage, false);
            //ShowBytes(crMessage, false);

        }

        private void btnClearBytes_Click(object sender, EventArgs e)
        {
            lblByte.Text = "Bytes: ";
        }
    }
}
