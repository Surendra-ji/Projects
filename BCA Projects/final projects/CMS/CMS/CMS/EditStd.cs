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
    public partial class EditStd : Form
    {
        SqlConnection cn;
        MemoryStream ms;
        SqlCommand cm;
        public EditStd()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
 
        }

        private void EditStd_Load(object sender, EventArgs e)
        {
           //gpcourse.Hide();
           //gbpersoneld.Hide();
        }

        private void Add_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Name");
                    textBox1.Focus();

                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter  Father Name");
                    textBox2.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Enter  Mother Name");
                    textBox3.Focus();
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Contact Number Not Filled");
                    textBox5.Focus();
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Address is Not Filled  ");
                    textBox6.Focus();
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Enter  Your EmailId");
                    textBox9.Focus();
                }
                else
                {
                    gpcourse.Show();
                   // gbpersoneld.Hide();
                    gpcourse.Enabled = true;
                }
            }
            catch { }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.gbpersoneld.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";

                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from StdReg where RegNo=@rn", cn);
               // string course = comboBox1.Text.ToString();
               // MessageBox.Show(course);
                cm.Parameters.AddWithValue("@rn", textBox10.Text);
             //   cm.Parameters.AddWithValue("@c",course);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds, "StdReg");
                //cm.ExecuteReader();
                gbpersoneld.Show();
                if (ds.Tables[0].Rows[0]["Pic"] != System.DBNull.Value)
                {
                    textBox1.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0][3].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][4]);
                    string gender = ds.Tables[0].Rows[0][5].ToString();
                    if (gender.Equals("Male"))
                        radioButton1.Checked = true;
                    else if (gender.Equals("Female"))
                        radioButton2.Checked = true;
                    else if (gender.Equals("Transgender"))
                        radioButton3.Checked = true;
                    textBox5.Text = ds.Tables[0].Rows[0][6].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0][7].ToString();
                    textBox7.Text = ds.Tables[0].Rows[0][8].ToString();
                    tbs.Text = ds.Tables[0].Rows[0][9].ToString();
                    textBox9.Text = ds.Tables[0].Rows[0][10].ToString();
                    byte[] data = (byte[])ds.Tables[0].Rows[0]["pic"];
                    ms = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(ms);
                    cmbcourse.Text = ds.Tables[0].Rows[0][12].ToString();
                    txtfees.Text = ds.Tables[0].Rows[0][13].ToString();
                    cmbcollege.Text = ds.Tables[0].Rows[0][14].ToString();
                   datestart.Value=Convert.ToDateTime( ds.Tables[0].Rows[0][15].ToString());
                   dateend.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][16].ToString());
                   cmbteacher.Text = ds.Tables[0].Rows[0][17].ToString();
                   txtproject.Text = ds.Tables[0].Rows[0][18].ToString();
                   Drpyear.Text = ds.Tables[0].Rows[0][19].ToString();
                   cbbtiming.Text = ds.Tables[0].Rows[0][20].ToString();
                }
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

        private void Back_Click(object sender, EventArgs e)
        {
            gbpersoneld.Show();
            gpcourse.Hide();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("update StdReg set Name=@n,FName=@fn,MName=@mn,DOB=@dob,Gender=@g,Contact=@c,Address=@a,PinCode=@pi,State=@s,Email_Id=@ei,Pic=@p,Fees=@f,College=@college,SDate=@sd,EDate=@ed,CTeacher=@ct,TDeatils=@td,Year=@y ,BatchTiming=@bt where RegNo=@rn and Course=@course", cn);
                cm.Parameters.AddWithValue("@rn", textBox10.Text);
                string name =textBox1 .Text.ToString().Trim();
               cm.Parameters.AddWithValue("@n", name);
                cm.Parameters.AddWithValue("@fn", textBox2.Text);
                cm.Parameters.AddWithValue("@mn", textBox3.Text);
                cm.Parameters.AddWithValue("@dob", dateTimePicker1.Value.Date);
                string gender = null;
                if (radioButton1.Checked)
                    gender = radioButton1.Text.ToString();
                else if (radioButton2.Checked)
                    gender = radioButton2.Text.ToString();
                else if (radioButton3.Checked)
                    gender = radioButton3.Text.ToString();
                cm.Parameters.AddWithValue("@g",gender);
                cm.Parameters.AddWithValue("@c", textBox5.Text);
                cm.Parameters.AddWithValue("@a", textBox6.Text);
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@pi", textBox7.Text);
                cm.Parameters.AddWithValue("@s", tbs.Text);
                cm.Parameters.AddWithValue("@ei", textBox9.Text);
                cm.Parameters.AddWithValue("@p", p);

                cm.Parameters.AddWithValue("@course", cmbcourse.Text);
                cm.Parameters.AddWithValue("@f", txtfees.Text);
                cm.Parameters.AddWithValue("@college", cmbcollege.Text);
                cm.Parameters.AddWithValue("@sd", datestart.Value.Date);
                cm.Parameters.AddWithValue("@ed", dateend.Value.Date);
                cm.Parameters.AddWithValue("@ct", cmbteacher.Text);
                cm.Parameters.AddWithValue("@td",txtproject.Text) ;
                cm.Parameters.AddWithValue("@y", Drpyear.Text);
                cm.Parameters.AddWithValue("@bt", cbbtiming.Text);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                    AddM.Show("Update Success ","Fully");
                else
                    DelM.Show("Unable To ","Update");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Exception");
            }
            finally
            {
                cn.Close();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
