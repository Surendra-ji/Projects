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
    public partial class BlurForm : Form
    {
        AddCourse a;
        EditCourse ec;
        SearchCourse sc;
        SubmitBook sb;
        string SenderName = "";
        public BlurForm(string sendername)
        {
            InitializeComponent();
            SenderName = sendername;
        }

        
        private void BlurForm_Load(object sender, EventArgs e)
        {
           if(SenderName=="AddCourse")
           {
               a = new AddCourse();
               a.FormClosed += a_FormClosed;
               a.ShowDialog();
           }
           else if(SenderName=="EditCourse")
           {
               ec = new EditCourse();
               ec.FormClosed += ec_FormClosed;
               ec.ShowDialog();
           }
           else if(SenderName =="SearchCourse")
           {
               sc = new SearchCourse();
               sc.FormClosed += sc_FormClosed;
               sc.ShowDialog();
           }
           else if (SenderName == "ReissueBookP")
           {
               sb = new SubmitBook();
               sb.FormClosed += sb_FormClosed;
               sb.ShowDialog();
           }
        }

        void sb_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            sb = null;
            this.Close();

        }

        void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            sc = null;
            this.Close();
        }

        void ec_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            ec = null;
            this.Close();
        }

        void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            a = null;
            this.Close();

        }
    }
}
