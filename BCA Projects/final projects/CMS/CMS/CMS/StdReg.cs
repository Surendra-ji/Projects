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
using System.Text.RegularExpressions;
using System.Threading;
namespace CMS
{
    public partial class StdReg : Form
    {
        string str;
        public static string fstr;
        public static string sstr;
        SqlConnection cn;
        SqlCommand cm;
        MemoryStream ms;
        Double totalf;
        public StdReg()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            //if (pictureBox1.Image !=null)
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
          
                //MessageBox.Show("first select the picture");

        }

        private void StdReg_Load(object sender, EventArgs e)
        {
            gpcourse.Enabled = false;
           
        Combo();
        }
        public void addfees()
        {
            cn.Close();
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into Fees values(@rn,@tf,@df,@lf,@dd,@sem)", cn);
                cm.Parameters.AddWithValue("@rn", tbr.Text);
                cm.Parameters.AddWithValue("@tf", totalf);
                cm.Parameters.AddWithValue("@df", txtfees.Text);
                float f=0;
                cm.Parameters.AddWithValue("@lf",f );
                cm.Parameters.AddWithValue("@dd", datestart.Value.Date);
                int sem=1;
                cm.Parameters.AddWithValue("@sem", sem);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                    AddM.Show("Success*Fully", "Added");
                 
                else
                    MessageBox.Show("Fees Not Added");

            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
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
        public void Fees()
        {
            try
            {
                    cn.Open();
                    cm = new SqlCommand("select * from Course where CourseName=@c", cn);
                    cm.Parameters.AddWithValue("@c",str);
                    SqlDataReader dr = cm.ExecuteReader();
                    dr.Read();
                    Double f =Convert.ToDouble(dr[1].ToString());
                    totalf = f;
                    f=f/6;
                    datestart.Value = Convert.ToDateTime(dr[5].ToString());
                    dateend.Value = Convert.ToDateTime(dr[6].ToString());
                    txtfees.Text =f.ToString();
                    txtfees.Enabled=false;
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
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Add_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                if (tbn.Text == "")
                {
                    MessageBox.Show("Enter Name");
                    tbn.Focus();
                   
                }
                else if (tbfn.Text == "")
                {
                    MessageBox.Show("Enter  Father Name");
                    tbfn.Focus();
                }
                else if (tbmn.Text == "")
                {
                    MessageBox.Show("Enter  Mother Name");
                    tbmn.Focus();
                }
                else if (tbc.Text == "")
                {
                    MessageBox.Show("Contact Number Not Filled");
                    tbc.Focus();
                }
                else if (tba.Text == "")
                {
                    MessageBox.Show("Address is Not Filled  ");
                    tba.Focus();
                }
                else if (tbei.Text == "")
                {
                    MessageBox.Show("Enter  Your EmailId");
                    tbei.Focus();
                }
                else
                {
                    gpcourse.Enabled = true;
                   gbpersoneld.Enabled = false;
                }
            }

            catch { }
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            gbpersoneld.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.gbpersoneld.Controls)
            {
                if (x is TextBox)
                {
                    x.Text ="";
                  
                }
            }
        
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
            //  cm = new SqlCommand("insert into RegStd(RegNo,Name,FName,MName,DOB,Gender,Contact,Address,PinCode,State,Email_Id,Pic)values(@rn,@n,@fn,@mn,@dob,@c,@a)", cn);
                cm = new SqlCommand("insert into StdReg(RegNo,Name,FName,MName,DOB,Gender,Contact,Address,PinCode,State,Email_Id,Pic,Course,Fees,College,SDate,EDate,CTeacher,TDeatils,Year,BatchTiming) values(@rn,@n,@fn,@mn,@dob,@g,@c,@a,@pi,@s,@ei,@p,@course,@f,@college,@sd,@ed,@ct,@td,@y,@bt)",cn);
                cm.Parameters.AddWithValue("@rn", tbr.Text);
                string name = tbn.Text.ToString().Trim();
                name = name +" "+tbn1.Text.ToString().Trim();
                cm.Parameters.AddWithValue("@n", name);
                cm.Parameters.AddWithValue("@fn", tbfn.Text);
                cm.Parameters.AddWithValue("@mn", tbmn.Text);
                cm.Parameters.AddWithValue("@dob", dob.Value.Date);
                string gender = null;
                if (radioButton1.Checked)
                gender = radioButton1.Text.ToString();
                else if (radioButton2.Checked)
                gender = radioButton2.Text.ToString();
                else if (radioButton3.Checked)
                gender = radioButton3.Text.ToString();
                cm.Parameters.AddWithValue("@g", gender);
                cm.Parameters.AddWithValue("@c", tbc.Text);
                cm.Parameters.AddWithValue("@a", tba.Text);
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@pi", tbp.Text);
                cm.Parameters.AddWithValue("@s", tbs.Text);
                cm.Parameters.AddWithValue("@ei", tbei.Text);
                cm.Parameters.AddWithValue("@p", p);
                cm.Parameters.AddWithValue("@course", cmbcourse.Text);
                cm.Parameters.AddWithValue("@f", txtfees.Text);
                cm.Parameters.AddWithValue("@college", cmbcollege.Text);
                cm.Parameters.AddWithValue("@sd", datestart.Value.Date);
                cm.Parameters.AddWithValue("@ed", dateend.Value.Date);
                cm.Parameters.AddWithValue("@ct", cmbteacher.Text);
                cm.Parameters.AddWithValue("@td", tbd.Text);
                cm.Parameters.AddWithValue("@y", tby.Text);
                cm.Parameters.AddWithValue("@bt",cbbtiming.Text);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Success Fully", "Added");
                   
                    addfees();

                }
                else
                {   DelM ob = new DelM();
                    ob.Show();
                                    }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"Exception");
            }
            finally
            {
                cn.Close();

            }        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reg = 0;
                 try
            {
                cn.Open();
                str = cmbcourse.SelectedItem.ToString();
                int length = str.Length;
                cm = new SqlCommand("select top 1 right(RegNo,5) from StdReg where left (RegNo," + length + ")=@a order by RegNo Asc", cn);
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
                     Fees();
        }

        private void tbc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbfn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void tbmn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbei_Leave(object sender, EventArgs e)
        {
            try
            {
                string pattern = @"^[a-z][a-z|0-9]*([_][a-z|0-9]+)*([.][a-z|" +
                    @"0-9]+([_][a-z]|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
                    @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
                System.Text.RegularExpressions.Match match;
                match = Regex.Match(tbei.Text, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    //MessageBox.Show("Success");
                }
                else
                {

                    MessageBox.Show("Not Valid Email Id   :  " + tbei.Text.ToString());
                    tbei.Clear();
                    tbei.Focus();
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }

        }

        private void tbp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
       

        }

        private void gbpersoneld_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {

            try
            {
                cn.Open();
                //  cm = new SqlCommand("insert into RegStd(RegNo,Name,FName,MName,DOB,Gender,Contact,Address,PinCode,State,Email_Id,Pic)values(@rn,@n,@fn,@mn,@dob,@c,@a)", cn);
                cm = new SqlCommand("insert into StdReg(RegNo,Name,FName,MName,DOB,Gender,Contact,Address,PinCode,State,Email_Id,Pic,Course,Fees,College,SDate,EDate,CTeacher,TDeatils,Year,BatchTiming) values(@rn,@n,@fn,@mn,@dob,@g,@c,@a,@pi,@s,@ei,@p,@course,@f,@college,@sd,@ed,@ct,@td,@y,@bt)", cn);
                cm.Parameters.AddWithValue("@rn", tbr.Text);
                string name = tbn.Text.ToString().Trim();
                name = name + " " + tbn1.Text.ToString().Trim();
                cm.Parameters.AddWithValue("@n", name);
                cm.Parameters.AddWithValue("@fn", tbfn.Text);
                cm.Parameters.AddWithValue("@mn", tbmn.Text);
                cm.Parameters.AddWithValue("@dob", dob.Value.Date);
                string gender = null;
                if (radioButton1.Checked)
                    gender = radioButton1.Text.ToString();
                else if (radioButton2.Checked)
                    gender = radioButton2.Text.ToString();
                else if (radioButton3.Checked)
                    gender = radioButton3.Text.ToString();
                cm.Parameters.AddWithValue("@g", gender);
                cm.Parameters.AddWithValue("@c", tbc.Text);
                cm.Parameters.AddWithValue("@a", tba.Text);
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@pi", tbp.Text);
                cm.Parameters.AddWithValue("@s", tbs.Text);
                cm.Parameters.AddWithValue("@ei", tbei.Text);
                cm.Parameters.AddWithValue("@p", p);
                cm.Parameters.AddWithValue("@course", cmbcourse.Text);
                cm.Parameters.AddWithValue("@f", txtfees.Text);
                cm.Parameters.AddWithValue("@college", cmbcollege.Text);
                cm.Parameters.AddWithValue("@sd", datestart.Value.Date);
                cm.Parameters.AddWithValue("@ed", dateend.Value.Date);
                cm.Parameters.AddWithValue("@ct", cmbteacher.Text);
                cm.Parameters.AddWithValue("@td", tbd.Text);
                cm.Parameters.AddWithValue("@y", tby.Text);
                cm.Parameters.AddWithValue("@bt", cbbtiming.Text);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Success Fully", "Added");

                    addfees();

                }
                else
                {
                    DelM ob = new DelM();
                    ob.Show();
                }

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

        
    }
}
