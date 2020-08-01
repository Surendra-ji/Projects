using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cprogress.cprogress
{
    public partial class circularprogresssbar : UserControl
    {
        int progress;
        public circularprogresssbar()
        {
            progress = 0;
            InitializeComponent();
        }

        private void circularprogresssbar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(-90);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           Pen obj=new Pen(Color.Red);
            Rectangle rect1=new Rectangle(0-this.Width/2+20,0-this.Height/2+20,this.Width-40,this.Height-40);
            e.Graphics.DrawPie(obj, rect1, 0,(int) (this.progress*3.6));
            e.Graphics.FillPie(new SolidBrush(Color.Red), rect1, 0, (int)(this.progress * 3.6));
            obj = new Pen(Color.White);
             rect1 = new Rectangle(0 - this.Width / 2+30, 0 - this.Height / 2+30, this.Width-60, this.Height-60);
            e.Graphics.DrawPie(obj, rect1, 0, 360);
            e.Graphics.FillPie(new SolidBrush(Color.Blue), rect1, 0, 360);
            StringFormat ft=new StringFormat();
            ft.LineAlignment=StringAlignment.Center;
            ft.Alignment=StringAlignment.Center;
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(this.progress.ToString()+"%", new Font("Arial", 30), new SolidBrush(Color.Purple), rect1, ft);


        }
        public void updateprogress(int progress)
        {
            this.progress = progress;
            this.Invalidate();
        }

    }
}
