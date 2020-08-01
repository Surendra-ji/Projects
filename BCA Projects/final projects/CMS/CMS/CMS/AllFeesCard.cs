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
    public partial class AllFeesCard : Form
    {
        public static string stdreg;
        SqlCommand cm;
        SqlConnection cn;
        public AllFeesCard()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Fees where RegNo=@a", cn);
                cm.Parameters.AddWithValue("@a", textBox4.Text);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds, "Fees");
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Show();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          finally
            {
                cn.Close();
            }

        }
        public void click()
        {
            try
            {
                cn.Open();
                SqlDataAdapter sda;
                DataSet da1;


                sda = new SqlDataAdapter("Select * from  Fees where ReciptNo= '" + dataGridView1.CurrentRow.Cells[1].Value + " ' ", cn);
                da1 = new DataSet();
                sda.Fill(da1, "Fees");
                label3.Text = da1.Tables[0].Rows[0][0].ToString();
                rn.Text = da1.Tables[0].Rows[0][1].ToString();
                f.Text = da1.Tables[0].Rows[0][3].ToString();
                MessageBox.Show(da1.Tables[0].Rows[0][3].ToString());
                lf.Text = da1.Tables[0].Rows[0][4].ToString();
                dos.Text = da1.Tables[0].Rows[0][5].ToString();
                se.Text = da1.Tables[0].Rows[0][6].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                cn.Close();
            }
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from StdReg where RegNo=@a", cn);
                cm.Parameters.AddWithValue("@a", textBox4.Text);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                n.Text = dr[1].ToString();
                fn.Text = dr[2].ToString();

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
        private void AllFeesCard_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 2;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;

                click();
                label7.Text = "ON";

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
     progressBar1.Value = 0;
         timer1.Enabled = true;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Enabled = true;

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
           // stdreg = label3.Text;
            FeesCardReport ob = new FeesCardReport();
            ob.ShowDialog();
        }
    }
}
