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
namespace CMS
{
    public partial class ForgotPassword : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public ForgotPassword()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from Login Where Contact=@c", cn);
                cm.Parameters.AddWithValue("@c", textBox1.Text);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    label2.Show();
                    label3.Show();
                    label2.Text = dr[2].ToString();
                }
                else
                {
                    MessageBox.Show("Contact Number Is Not Right ");
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

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
        }
        }
    }

