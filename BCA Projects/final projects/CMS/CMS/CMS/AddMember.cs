using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace CMS
{
    public partial class AddMember : Form
    {
        SqlCommand cm;
        SqlConnection cn;

        public AddMember()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into Member values(@mid,@n,@fn,@c,@add,@e,@pic,@st,@doj,@doe) ", cn);
                cm.Parameters.AddWithValue("@mid", textBox1.Text);
                cm.Parameters.AddWithValue("@n", textBox2.Text);
                cm.Parameters.AddWithValue("@fn", textBox3.Text);
                cm.Parameters.AddWithValue("@c", textBox4.Text);
                cm.Parameters.AddWithValue("@add", textBox5.Text);
                cm.Parameters.AddWithValue("@e", textBox6.Text);
                cm.Parameters.AddWithValue("@st", textBox7.Text);
                cm.Parameters.AddWithValue("@doj",dateTimePicker1.Value.Date);
                cm.Parameters.AddWithValue("@doe", dateTimePicker2.Value.Date);
                MemoryStream  ms = new MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@pic", p);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Success Fully", "Added");
                }
                else
                {
                    DelM ob = new DelM();
                    ob.Show();
                }
            }catch(Exception ex)
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
         
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control cx in groupBox1.Controls)
            {
                if (cx is TextBox)
                    cx.Text = "";
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
}
    }
