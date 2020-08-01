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
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            label3.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                /*
                 *        Next Page Code Put Here
                 * */
                this.Hide();
         
                Login ob = new Login();

                ob.ShowDialog();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}