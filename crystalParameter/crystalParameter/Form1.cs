using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine; //descread method
using CrystalDecisions.Shared;  //for parameter

namespace crystalParameter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"H:\crystalParameter\crystalParameter\CrystalReport1.rpt");
            ParameterFieldDefinition pfd;
            ParameterFieldDefinitions pfds;
            ParameterValues pv = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value =Int32.Parse(textBox1.Text);
            pfds = rd.DataDefinition.ParameterFields;
            pfd = pfds["Serial Number"];
            pv = pfd.CurrentValues;
            pv.Clear();
            pv.Add(pdv);
            pfd.ApplyCurrentValues(pv);
            crystalReportViewer1.ReportSource = rd;
            crystalReportViewer1.Refresh();


        }
    }
}
