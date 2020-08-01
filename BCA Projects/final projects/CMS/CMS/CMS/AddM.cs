using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CMS
{
    public partial class AddM : Form
    {
        public AddM()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, this.Width-10, this.Height);
            this.Region = new Region(p);
            GraphicsPath p1 = new GraphicsPath();
            p1.AddEllipse(0, 0, panel1.Width-10, panel1.Height);
           panel1.Region = new Region(p1);
            base.OnPaint(e);
        }
       
        internal static void Show(string msg,string msg1)
        {
            AddM mg = new AddM();
            mg.setMessage(msg,msg1);
            mg.ShowDialog();
        }
       
       
        private void setMessage(string msg,string msg1)
        {
            int number = Math.Abs(msg.Length / 30);
            if (number != 0)
                this.label1.Height = number * 25;
            this.label1.Text = msg;
            int number1 = Math.Abs(msg.Length / 30);
            if (number1 != 0)
                this.label2.Height = number1 * 25;
            this.label2.Text = msg1;
        }
        private void AddM_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
