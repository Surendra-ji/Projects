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
using System.Data.SqlClient;
using System.IO;
namespace CMS
{
    public partial class Login : Form
    {
        SqlCommand cm; SqlConnection cn;
        string str1;
        MemoryStream ms;
        int i = 0;

        public Login()
        {
            InitializeComponent();

            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }
     public void circle()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }
     
        private void Login_Load(object sender, EventArgs e)
     {
         circle();
         timer1.Enabled = true;
      
         label3.Hide();
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

            string str = textBox1.Text;
             try
             {
                 cn.Open();
                 cm = new SqlCommand("Select * from Login Where UserName='" + str + "' ", cn);
                 SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    str1 = dr[1].ToString();
                    byte[] data = (byte[])dr[0];
                    ms = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(ms);

                    if (str.Equals(str1))
                    {
                        panel2.Hide();
                        textBox1.Hide();
                        label3.Text = str1;
                        label3.Show();

                    }
                }
             }catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }finally
             {
                 cn.Close();
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword ob = new ForgotPassword();
            ob.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from Login Where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", cn);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Main ob = new Main();
                    ob.Show();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            Register ob = new Register();
            ob.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         foreach(Control x in this.Controls)
            {
                if(x is TextBox)
                {
                    x.Text = "";

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
