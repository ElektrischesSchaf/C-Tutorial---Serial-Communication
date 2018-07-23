using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     
             
     
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                serialPort1.PortName = cboPort.Text;
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
   
                if (serialPort1.IsOpen)
                {
                    txtReceive.Text = serialPort1.ReadExisting();
                }
                if (txtReceive.Text.Contains("touched"))
                    {
                        pictureBox1.ImageLocation = "http://i.imgur.com/s4mst47.png";

                    }
               else
                    {
                        pictureBox1.ImageLocation = "http://i.imgur.com/pZLI5rN.png";
                    }
                 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }
            
    }
}
