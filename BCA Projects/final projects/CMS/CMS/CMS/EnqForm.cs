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
    public partial class EnqForm : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        int fno;
        public EnqForm()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
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
        public void MaxFno()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select max(FNo) from EnqForm ", cn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    fno = Convert.ToInt32(dr[0]);
                    fno++;
                    textBox8.Text = fno.ToString();
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
       
        private void EnqForm_Load(object sender, EventArgs e)
        {
            Combo();
            MaxFno();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert Into EnqForm(Name,FName,Contact,Contact2,Address,EId,POS,Stream,Year,PQualification,IntrestedCourse,FIncome,ComingResource,NameOfResource,AnyOther) values(@n,@fn,@c1,@c1,@add,@eid,@pos,@s,@y,@pq,@ic,@fi,@cr,@nor,@ao) ", cn);
             string str=tbn.Text;
                str=str+"  "+tbn1.Text;
                cm.Parameters.AddWithValue("@n", str);
                cm.Parameters.AddWithValue("@fn", tbfn.Text);
                cm.Parameters.AddWithValue("@c1", tbc.Text);
                cm.Parameters.AddWithValue("@c2",textBox1.Text);
                cm.Parameters.AddWithValue("@add", tba.Text);
                cm.Parameters.AddWithValue("@eid", tbei.Text);
                cm.Parameters.AddWithValue("@pos",comboBox2.Text);
                cm.Parameters.AddWithValue("@s",comboBox3.Text);
                cm.Parameters.AddWithValue("@y",comboBox4.Text);
                cm.Parameters.AddWithValue("@pq",textBox9.Text);
                cm.Parameters.AddWithValue("@ic",comboBox1.Text);
                cm.Parameters.AddWithValue("@fi", textBox10.Text);
                if (checkBox1.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox1.Text);
                }
                else if (checkBox2.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox2.Text);
                    cm.Parameters.AddWithValue("@nor", textBox2.Text);
                }
                else if (checkBox3.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox3.Text);
                    cm.Parameters.AddWithValue("@nor", textBox3.Text);
                }
                else if (checkBox4.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox4.Text);
                    cm.Parameters.AddWithValue("@nor", textBox4.Text);
                }
                else if (checkBox5.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox5.Text);
                    cm.Parameters.AddWithValue("@nor", textBox5.Text);
                }
                else if (checkBox6.Checked == true)
                {
                    cm.Parameters.AddWithValue("@cr", checkBox6.Text);
                    cm.Parameters.AddWithValue("@nor", textBox6.Text);
                }
                else if (checkBox7.Checked == true)
                    cm.Parameters.AddWithValue("@cr", checkBox7.Text);
                else if (checkBox8.Checked == true)
                    cm.Parameters.AddWithValue("@cr", checkBox8.Text);
                    cm.Parameters.AddWithValue("@ao",textBox8.Text);
                    cm.Parameters.AddWithValue("@nor", textBox2.Text);
                    int re = cm.ExecuteNonQuery();
                if(re>0)
                {
                    AddM.Show("Success Fully", "Added");
                }
                else
                {
                    MessageBox.Show("Record Not Inserted");
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            foreach(Control x in this.groupBox1.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
            foreach (Control x in this.groupBox2.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
                if (x is ComboBox)
                    x.Text = "";
            }
            foreach (Control x in this.groupBox3.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
        }
    }
}
