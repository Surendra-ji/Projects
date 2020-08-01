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
    public partial class BookIssue : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        int q;
        public BookIssue()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Member where MID=@mid", cn);
                cm.Parameters.AddWithValue("@mid", textBox11.Text);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                MessageBox.Show(dr[0].ToString());
                if (dr.HasRows)
                {

                    mid.Text = dr[0].ToString();
                    mn.Text = dr[1].ToString();
                    c.Text = dr[3].ToString();
                    eid.Text = dr[5].ToString();
                    byte[] data = (byte[])dr[6];
                    MemoryStream ms = new MemoryStream(data);
                    mp.Image = Image.FromStream(ms);
                   textBox2.Text = dr[7].ToString();
                   dateTimePicker3.Value =Convert.ToDateTime( dr[8]);
                }
                else
                {

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
                cm = new SqlCommand("select * from Book where BookId=@bid", cn);
                cm.Parameters.AddWithValue("@bid", textBox6.Text);
                SqlDataReader dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    bid.Text = dr[0].ToString();
                    title.Text = dr[1].ToString();
                    author.Text = dr[2].ToString();
                    p.Text = dr[3].ToString();
                    l.Text = dr[4].ToString();
                    quan.Text = dr[7].ToString();
                    q = Convert.ToInt32(quan.Text);
                    byte[] data = (byte[])dr[10];
                    MemoryStream ms = new MemoryStream(data);
                    bp.Image = Image.FromStream(ms);
                }
                else
                {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void BookIssue_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            DateTime id = dateTimePicker1.Value.Date;

            DateTime dd = dateTimePicker2.Value.Date;

            textBox1.Text = ((dd.Day) - (id.Day)).ToString();

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into BookIssue values(@mid,@bid,@id,@dd,@t)", cn);
                cm.Parameters.AddWithValue("@mid", mid.Text);
                cm.Parameters.AddWithValue("@bid", bid.Text);
                cm.Parameters.AddWithValue("@id", dateTimePicker1.Value.Date);
                cm.Parameters.AddWithValue("@dd", dateTimePicker2.Value.Date);
                cm.Parameters.AddWithValue("@t", textBox1.Text);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Book Issued", "Success Fully");
                    cn.Close();
                    upd();
                }
                else
                {

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

       public void upd()
       {
           try
           {
               cn.Open();
               int tq = q - 1;
               cm = new SqlCommand("update Book set Quantity='" + tq + "' where Title ='"+title.Text + "'", cn);
               int re = cm.ExecuteNonQuery();
               if (re > 0)
               {
                   string  str = "Book :";
                       str=str+tq.ToString();
                   AddM.Show("Avaliable Quantity ",str);

               }
               else
               {

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
    }
}
