using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class FeesCardReport : Form
    {
        public FeesCardReport()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FeesCardReport_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Your Registration Number is  = " + AllFeesCard.stdreg);
        }
    }
}
