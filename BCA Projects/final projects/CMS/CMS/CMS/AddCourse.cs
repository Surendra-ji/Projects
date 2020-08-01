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
    public partial class AddCourse : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        public AddCourse()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        { 
            try{
                 cn.Open();
                 cm= new SqlCommand("insert into Course values(@cn,@f,@d,@ib,@cb)",cn);
                 cm.Parameters.AddWithValue("@cn", txtcoursename.Text);
                 cm.Parameters.AddWithValue("@f", txtcoursefees.Text);
                 cm.Parameters.AddWithValue("@d", cmbduration.Text);
                 cm.Parameters.AddWithValue("@ib", textBox1.Text);
                 cm.Parameters.AddWithValue("@cb", textBox2.Text);
                 int reg = cm.ExecuteNonQuery();
                 if (reg > 0)
                 {
                     clear();
                 }
                 else
                     MessageBox.Show("Record Not Added ");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        public void clear()
        {
            foreach (Control x in this.groupBox2.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
                if (x is ComboBox)
                    x.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            
        }
    }
}
