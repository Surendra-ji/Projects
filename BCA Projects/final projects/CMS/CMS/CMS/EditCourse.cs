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
    public partial class EditCourse : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        
        public EditCourse()
        {
             InitializeComponent();
             cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Hide();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Course where CourseName=@cn", cn);
                string course = comboBox1.SelectedItem.ToString();
                MessageBox.Show(course);
                cm.Parameters.AddWithValue("@cn", course);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                groupBox2.Show();
                cnt.Text = dr[0].ToString();
                ft.Text = dr[1].ToString();
                tdc.Text = dr[2].ToString();
                ibt.Text = dr[3].ToString();
                cbt.Text = dr[4].ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { cn.Close(); }
        }

        private void EditCourse_Load(object sender, EventArgs e)
        {
            groupBox2.Hide();   
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            clear();
        
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Update Course set CourseName=@ncn,Fees=@f,Duration=@d,IssuedBy=@ib,CertifiedBy=@cb where CourseName=@cn", cn);
                string course = comboBox1.SelectedItem.ToString();             
                cm.Parameters.AddWithValue("@cn", course);
                cm.Parameters.AddWithValue("@ncn", cnt.Text);
                cm.Parameters.AddWithValue("@f", ft.Text);
                cm.Parameters.AddWithValue("@d", tdc.Text);
                cm.Parameters.AddWithValue("@ib", ibt.Text);
                cm.Parameters.AddWithValue("@cb", cbt.Text);
                int reg = cm.ExecuteNonQuery();
                if (reg > 0)
                {
                    clear();

                }
                else
                    MessageBox.Show("Record Not Added ");

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
        public void clear()
        {
            foreach (Control x in this.groupBox2.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
                if (x is ComboBox)
                    x.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
