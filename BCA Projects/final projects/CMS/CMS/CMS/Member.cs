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
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember ob = new AddMember();
            ob.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateMember ob = new UpdateMember();
            ob.Show();
        }

        private void Member_Load(object sender, EventArgs e)
        {

        }
    }
}
