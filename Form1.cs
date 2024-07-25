using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ED64PLoad
{
    public partial class ED64PLoad : Form
    {
        ED64API api;
        BackgroundWorker bw;
        BackgroundWorker bw2;
        Timer t;
        string ROMFn = "";
        string PortN = "";

        public ED64PLoad()
        {
            InitializeComponent();

            bw = new BackgroundWorker();
            bw.DoWork += bw_SendROM;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += Bw_ProgressChanged;

            bw2 = new BackgroundWorker();
            bw2.DoWork += bw_TryMakePort;
            bw2.WorkerReportsProgress = true;
            bw2.RunWorkerCompleted += Bw2_RunWorkerCompleted;

            t = new Timer();
            t.Interval = 200;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (!bw2.IsBusy && !ED64API.DoingStuff)
                bw2.RunWorkerAsync();
        }

        private void Bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRefresh.Invoke((MethodInvoker)delegate { btnRefresh.Enabled = true; });
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value == 100)
                lblStatusExp.Text = "ROM Sent!";
        }

        private void bw_SendROM(object sender, DoWorkEventArgs e)
        {
            byte[] f = File.ReadAllBytes(ROMFn);
            ED64API.ED64SendROM(f, bw);
        }

        private void bw_TryMakePort(object sender, DoWorkEventArgs e)
        {

            ED64API.setED64API(PortN);

            if (ED64API.ED64TestPort())
            {
                lblStatusExp.Invoke((MethodInvoker)delegate { lblStatusExp.Text = "ED64P detected."; });
                btn_SendROM.Invoke((MethodInvoker)delegate { btn_SendROM.Enabled = true; });
            }
            else
            {
                lblStatusExp.Invoke((MethodInvoker)delegate { lblStatusExp.Text = "ED64P not detected."; });
                btn_SendROM.Invoke((MethodInvoker)delegate { btn_SendROM.Enabled = false; });
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PortN = comboCOMPorts.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            
            if (of.ShowDialog() == DialogResult.OK)
            {
                lblStatusExp.Text = "Sending ROM...";
                ROMFn = of.FileName;
                bw.RunWorkerAsync();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (api != null)
                ED64API.Destroy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboCOMPorts.DataSource = ports;
        }

        private void ED64PLoad_Load(object sender, EventArgs e)
        {

        }
    }
}
