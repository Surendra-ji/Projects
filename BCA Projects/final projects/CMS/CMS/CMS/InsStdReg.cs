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
    public partial class InsStdReg : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        MemoryStream ms;
        string str;
        public InsStdReg()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void InsStdReg_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            label69.Text = (DateTime.Now.Date).ToString();
            Combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void gpcourse_Enter(object sender, EventArgs e)
        {

        }
       
        public void insert(string tname, string sname)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into " + tname + " (RegNo,FName,LName,FaName,MoName,DOB,Gender,Contact,Address,Pin,State,Email,Picture,Thumb,Signature,Course,AdmitDate,CmpltDate,Fee," + sname + ") values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20)", cn);
                cm.Parameters.AddWithValue("@1", tbr.Text);
                cm.Parameters.AddWithValue("@2", tbn.Text);
                cm.Parameters.AddWithValue("@3", tbn1.Text);
                cm.Parameters.AddWithValue("@4", tbfn.Text);
                cm.Parameters.AddWithValue("@5", tbmn.Text);
                cm.Parameters.AddWithValue("@6", dob.Value.Date);
                string gender = null;
                if (radioButton1.Checked)
                    gender = radioButton1.Text.ToString();
                else if (radioButton2.Checked)
                    gender = radioButton2.Text.ToString();
                else if (radioButton3.Checked)
                    gender = radioButton3.Text.ToString();
                cm.Parameters.AddWithValue("@7", gender);
                cm.Parameters.AddWithValue("@8", tbc.Text);
                cm.Parameters.AddWithValue("@9", tba.Text);

                cm.Parameters.AddWithValue("@10", tbp.Text);
                cm.Parameters.AddWithValue("@11", tbs.Text);
                cm.Parameters.AddWithValue("@12", tbei.Text);
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@13", p);
                ms = new MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p1 = ms.ToArray();
                cm.Parameters.AddWithValue("@14", p1);
                ms = new MemoryStream();
                pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p2 = ms.ToArray();
                cm.Parameters.AddWithValue("@15", p2);
                cm.Parameters.AddWithValue("@16", cmbcourse.Text);
                cm.Parameters.AddWithValue("@17", label69.Text);
                cm.Parameters.AddWithValue("@18", label69.Text);
                cm.Parameters.AddWithValue("@19",txtfees.Text );
                cm.Parameters.AddWithValue("@20", sname);

                int re = cm.ExecuteNonQuery();
                if(re>0)
                {
                    MessageBox.Show("Record Added");
                }else
                {
                    MessageBox.Show("Record Not Added");
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

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(str);
            insert(str, str);
        }

        public void regno(string tname)
        {
            int reg = 0;
            try
            {
                cn.Open();
                string str = cmbcourse.SelectedItem.ToString();
                int length = str.Length;
                cm = new SqlCommand("select top 1 right(RegNo,5) from " + tname + " where left (RegNo," + length + ")=@a order by RegNo Asc", cn);
                cm.Parameters.AddWithValue("@a", str);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                reg = Convert.ToInt32(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                cn.Close();
            }
            if (reg == 0)
                reg = 10001;
            else
                reg++;
            MessageBox.Show(" Registration Number : " + cmbcourse.Text + (reg.ToString()));
            tbr.Text = cmbcourse.Text + (reg.ToString());

        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = cmbcourse.SelectedItem.ToString();
            regno(str);
        }

        private void tbn_TextChanged(object sender, EventArgs e)
        {

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
                    cmbcourse.Items.Add(dr[0].ToString());

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
        private void Add_Click(object sender, EventArgs e)
        {
            gpcourse.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            //if (pictureBox1.Image !=null)
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            //if (pictureBox1.Image !=null)
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            //if (pictureBox1.Image !=null)
            pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
