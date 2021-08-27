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
namespace DateDiffrence
{
    public partial class Form1 : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-D4GIESE\SQLEXPRESS;Initial Catalog=Sir;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into DateDiffrence values (@c,@sd,@ed)", cn);
                cm.Parameters.AddWithValue("@c", textBox1.Text);
                cm.Parameters.AddWithValue("@sd",dateTimePicker1.Value.Date);
                cm.Parameters.AddWithValue("@ed", dateTimePicker2.Value.Date);
                int reg = cm.ExecuteNonQuery();
                if (reg > 0)
                    MessageBox.Show("Reord Inserted");
                else
                    MessageBox.Show("Reord Not Inserted");
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                cn.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from DateDiffrence ", cn);
                SqlDataReader dr=cm.ExecuteReader();
                dr.Read();
                textBox1.Text = dr[0].ToString();
                DateTime sd = Convert.ToDateTime(dr[1].ToString());
                DateTime ed = Convert.ToDateTime(dr[2].ToString());
                TimeSpan dd = (sd-ed);
                MessageBox.Show("Total Day's"+dd.Days);
               int day = Convert.ToInt32(dd.Days);
                if(day<365)
                { 
                    textBox2.Text = "1";
                    if (day > 182)
                        textBox3.Text = "First Semester";
                    else
                        textBox3.Text = "Second Semester";
                    
                }
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
