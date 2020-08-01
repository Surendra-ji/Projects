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
    public partial class FeesCard : Form
    {
        int mrno;
        SqlConnection cn;
        SqlCommand cm;
        int sem;
        int amt;
        int inst;
        int brkup;
        int da1;
        string lblmsg;
        double tot_remaining;
        double record;
        int j = 0;
        DateTime lpd;
        DateTime ldd;
        SqlDataReader dr;
        public FeesCard()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True"); 
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label16.Text = "";
            alldata();
            payment();
        }

        public void alldata()
        {
            lastfeesdd();
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from StdReg where RegNo=@a", cn);
                cm.Parameters.AddWithValue("@a",textBox4.Text );
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                DateTime sd =Convert.ToDateTime(dr[15].ToString());
                DateTime cd = DateTime.Now;
                TimeSpan day=(cd-sd);
                int dd = Convert.ToInt32(day.Days);
                textBox3.Text = dr[12].ToString();
                da1 = Convert.ToInt32(dr[13]);
                textBox6.Text = dr[1].ToString();
                textBox7.Text = dr[2].ToString();
                textBox8.Text = dr[6].ToString();
                textBox9.Text = dr[10].ToString();
                if (dd<=365)
                {
                    textBox1.Text = "1 Year";
                    if (dd <= 182)
                    {
                        textBox5.Text = "First Semester";
                         }

                    else
                    {
                        textBox5.Text = "Second Semester";
                    }
                }
                else if (dd > 365 && dd <= 730)
                {
                    textBox1.Text = "2 Year";
                    if (dd > 365 && dd <= 547)
                    {
                        textBox5.Text = "Thered  Semester";

                    }

                    else
                    {
                        textBox5.Text = "Fourth Semester";
                    }
                }
                else if (dd >= 730)
                {
                    textBox1.Text = "3 Year";
                    if (dd > 730 && dd < 912)
                    {
                        textBox5.Text = "Fifth  Semester";
                 
                    }
                    else
                    {
                        textBox5.Text = " Six Semester";
                 
                    }
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
        public void view()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Fees where RegNO='" + textBox4.Text + "' and Sem='" +sem+ "'", cn);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                MessageBox.Show("Feees");
                textBox13.Text = mrno.ToString();
                int lf=Convert.ToInt32(dr[4].ToString());
                int t=Convert.ToInt32(dr[2].ToString());
                int cf=t-lf;
                textBox11.Text= lf.ToString();
                textBox12.Text= t.ToString();
                textBox13.Text = mrno.ToString();
                textBox10.Text= cf.ToString();
                dateTimePicker2.Value= Convert.ToDateTime(dr[5].ToString());
           
         }catch(Exception ex)
            { MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            }
        public void lastfeesdd()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select  Max(ReciptNo),Max(DepDate),Max(Sem) from  Fees where RegNo=@a", cn);
                cm.Parameters.AddWithValue("@a", textBox4.Text);
                SqlDataReader dr= cm.ExecuteReader();
                 dr.Read();
                 mrno = Convert.ToInt32(dr[0].ToString()); 
                 ldd = Convert.ToDateTime(dr[1].ToString());
                 dateTimePicker3.Value = ldd;
                 sem = Convert.ToInt32(dr[2].ToString());
                 DateTime dch = ldd.AddMonths(6);
                 DateTime cud = DateTime.Now.Date;
                 if (cud < dch)
                 {
                     button3.Enabled = false;
                     label16.Text = "Paid";
                     textBox13.Text = mrno.ToString();
                     view();
                     
                 }
                 else
                     button3.Enabled = true;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
      

        private void FessCard_Load(object sender, EventArgs e)
        {

        }

       public void payment()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from Course", cn);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                textBox2.Text=dr[0].ToString();
                amt = Convert.ToInt32(dr[1].ToString());
                inst = Convert.ToInt32(dr[2].ToString());
                amt = amt - da1;
                inst--;
                brkup = inst;
                double tot_remaining = amt - inst;
                double record = tot_remaining / brkup;
                lblmsg = record.ToString();
                j = 6;
                dateTimePicker2.Value = ldd.AddMonths(j);
                MessageBox.Show(ldd.ToString());
                textBox10.Text = record.ToString();
                 lpd = dateTimePicker2.Value.Date;

                DateTime cd = DateTime.Now;
                //MessageBox.Show("Current Date " + cd.Date);
                TimeSpan day = (cd - lpd);
                int lf = Convert.ToInt32(day.Days);
                int lp;
                if (lf <= 5)
                {
                    lp = 500;
                }
                else if (lf <= 10)
                {
                    lp = 1000;
                }
                else
                    lp = 1500;
                textBox11.Text = lp.ToString();
                textBox12.Text = (Convert.ToInt32(lp) + record).ToString();
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
        public void select()
        {    
            try
            {
                cn.Open();
                cm = new SqlCommand("select max(ReciptNo) from Fees", cn);
                string str = cm.ExecuteScalar().ToString();
                textBox13.Text = (Int32.Parse(str) + 1).ToString();
                MessageBox.Show("Your Recipt Number Is  :" + textBox13.Text.ToString());
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

        
        private void button3_Click(object sender, EventArgs e)
        {
             select();
           //Insert Date
            try
            {

                cn.Open();
                cm = new SqlCommand("insert into Fees(RegNo,DepFee,LateFee,DepDate,Sem) values(@rn,@df,@lf,@dd,@sem)", cn);
                cm.Parameters.AddWithValue("@rn", textBox4.Text);
                cm.Parameters.AddWithValue("@df", textBox10.Text);
                cm.Parameters.AddWithValue("@lf", textBox11.Text);
                cm.Parameters.AddWithValue("@dd", dateTimePicker2.Value.Date);
                cm.Parameters.AddWithValue("@sem", ++sem);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    MessageBox.Show("Fees Added");
                    dateTimePicker1.Value = DateTime.Now.Date;
                    label16.Text = "Paid";
                }
                else
                    MessageBox.Show("Fees Not Added");

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                cn.Close();
            }
            button3.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
