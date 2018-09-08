//Miguel Pulido - Systems Architect

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace XBee
{
    public partial class Form1 : Form
    {
        private StringBuilder recievedData = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cmbCOMPort.Items.Add(portname);

            }
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = cmbCOMPort.Text;
            if (!serialPort1.IsOpen) serialPort1.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(DataOut.Text + "\n\r");
            }
        }

        //private void richTextBox1_TextChanged(object sender, EventArgs e)
     //   private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
       // {
         //   recievedData.Append(serialPort1.ReadExisting());
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            OutputWindow.Text = recievedData.ToString();

         //   This Section outputs "OutputWindow.Text string to a file located C:\TestFolder
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TestFolder\WriteText.txt",true))
            {
                file.WriteLine(OutputWindow.Text);
            }
        }

        private void OutputWindow_TextChanged(object sender, EventArgs e)
        {
            recievedData.Append(serialPort1.ReadExisting());

        }



    }
}
