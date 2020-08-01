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
    public partial class SETeacher : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        public SETeacher()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        int mouseX = 0, mouseY = 0;
        bool mousedown;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void SETeacher_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {

            try
            {
                cn.Open();
                cm = new SqlCommand("select * from Teacher ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds, "Teacher");
                dataGridView1.DataSource = ds.Tables[0];

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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Enabled = true;
           

        }
        public void click()
        {
            try
            {
                cn.Open();
                SqlDataAdapter sda;
                DataSet da1;


                sda = new SqlDataAdapter("Select * from Teacher where Tid= '" + dataGridView1.CurrentRow.Cells[0].Value + " ' ", cn);
                da1 = new DataSet();
                sda.Fill(da1, "Teacher");
                label3.Text = da1.Tables[0].Rows[0][0].ToString();
                tname.Text = da1.Tables[0].Rows[0][1].ToString();
                tdepartment.Text = da1.Tables[0].Rows[0][2].ToString();
                tcontact.Text = da1.Tables[0].Rows[0][3].ToString();
                tsalary.Text = da1.Tables[0].Rows[0][4].ToString();
                tspecification.Text = da1.Tables[0].Rows[0][5].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(da1.Tables[0].Rows[0][6].ToString());
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
        private void btnaddcourse_Click(object sender, EventArgs e)
        {
          try
            {
                cn.Open();
                cm = new SqlCommand(" update Teacher  set TName=@tn,Department=@d,Contact=@c,Salary=@s,Specification=@se,JDate=@jd where Tid=@id", cn);
                cm.Parameters.AddWithValue("@id", label3.Text);
                cm.Parameters.AddWithValue("@tn", tname.Text);
                cm.Parameters.AddWithValue("@d", tdepartment.Text);
                cm.Parameters.AddWithValue("@c", tcontact.Text);
                cm.Parameters.AddWithValue("@s", tsalary.Text);
                cm.Parameters.AddWithValue("@se", tspecification.Text);
                cm.Parameters.AddWithValue("@jd", dateTimePicker1.Value.Date);
                int re = cm.ExecuteNonQuery();
                if (re > 0)
                {
                    AddM.Show("Update Success", "Fully");
                 
                    clear();
                }
                else
                {
                    DelM ob = new DelM();
                    ob.Show();
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
          reload();

        }
        public void clear()
        {
            foreach (Control x in this.groupBox2.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                mouseX = MousePosition.X - 1;
                mouseY = MousePosition.Y + 1;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
