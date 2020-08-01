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
    public partial class Register : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        MemoryStream ms;
        public Register()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into Login values(@pic,@un,@pas,@cnt,@dpt)",cn);
                cm.Parameters.AddWithValue("@dpt", textBox1.Text);
                cm.Parameters.AddWithValue("@un", textBox3.Text);
                
                cm.Parameters.AddWithValue("@pas", textBox5.Text);
                cm.Parameters.AddWithValue("@cnt", textBox6.Text);

                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            string str1 = textBox5.Text;
            if(str.Equals(str1))
            {

            }
            else
            {
                MessageBox.Show("Password Are Not Same ");
                textBox4.Clear();
                textBox5.Clear();
                textBox4.Focus();
            }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            //if (pictureBox1.Image !=null)
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";

                }
            }
        }
    }
}
