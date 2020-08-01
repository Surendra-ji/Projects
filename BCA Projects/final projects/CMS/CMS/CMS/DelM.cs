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
    public partial class DelM : Form
    {
        public DelM()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, this.Width - 10, this.Height);
            this.Region = new Region(p);
            base.OnPaint(e);
        }
        internal static void Show(string msg, string msg1)
        {
            DelM mg = new DelM();
            mg.setMessage(msg, msg1);
            mg.ShowDialog();
        }


        private void setMessage(string msg, string msg1)
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
        private void DelM_Load(object sender, EventArgs e)
        {

        }
        int mouseX = 0, mouseY = 0;
        bool mousedown;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousedown)
            {
                mouseX = MousePosition.X - 100;
                mouseY = MousePosition.Y - 20;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
