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
    public partial class ShowStd : Form
    {
        public static string stdreg;
        SqlCommand cm;
        SqlConnection cn;
        public ShowStd()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void ShowStd_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void alldata()
        {
            try
            {
                cn.Open();
                string course = comboBox1.Text.ToString();
                int length = course.Length;
                cm = new SqlCommand("select * from StdReg where left (RegNo," + length + ")=@a order by RegNo desc", cn);
                MessageBox.Show(course);
                cm.Parameters.AddWithValue("@a", course);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds, "StdReg");
                dataGridView2.DataSource = ds.Tables[0];
                dataGridView2.Show();
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
        private void Search_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                alldata();
            }
            else
            {
                try
                {
                    cn.Open();
                    cm = new SqlCommand("select * from StdReg where RegNo=@rn", cn);
                    cm.Parameters.AddWithValue("@rn", textBox10.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "StdReg");
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Show();
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
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            //radioButton1.Checked = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // stdreg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            StdReport ob = new StdReport();
            ob.ShowDialog();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stdreg = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
