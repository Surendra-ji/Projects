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
using System.Threading;

namespace CMS
{
    public partial class AddTeacher : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public AddTeacher()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            Combo();
        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into Teacher  values(@tid,@tn,@d,@c,@s,@se,@jd)", cn);
                cm.Parameters.AddWithValue("@tid", label3.Text);
                cm.Parameters.AddWithValue("@tn", tname.Text);
                cm.Parameters.AddWithValue("@d", tdepartment.Text);
                cm.Parameters.AddWithValue("@c", tcontact.Text);
                cm.Parameters.AddWithValue("@s", tsalary.Text);
                cm.Parameters.AddWithValue("@se", tspecification.Text);
                cm.Parameters.AddWithValue("@jd", dateTimePicker1.Value.Date);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Success Fully", "Added");
                    clear();
                   
                }
                else
                {  
                    DelM ob = new DelM();
                    ob.Show();
                 }
                }catch(Exception  ex)
            {
                    MessageBox.Show(ex.Message);
                }
            finally
            {
                cn.Close();
            }


            }

        public void Combo()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Teacher", cn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                   int i=Convert.ToInt32(dr[0]);
                   i++;
                   label3.Text = i.ToString();

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
        public void clear()
        {
            foreach (Control x in this.groupBox2.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }
        }
    }

