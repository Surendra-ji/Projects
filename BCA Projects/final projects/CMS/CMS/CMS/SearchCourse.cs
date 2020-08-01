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
    public partial class SearchCourse : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public SearchCourse()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void SearchCourse_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            Combo();
        }
        public void Combo()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Course", cn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Course where CourseName=@c",cn);
                cm.Parameters.AddWithValue("@c", comboBox1.Text.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds, "Course");
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        
    }
}
