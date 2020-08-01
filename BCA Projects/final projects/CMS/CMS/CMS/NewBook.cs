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
    public partial class NewBook : Form
    {
        SqlCommand cm;
        SqlConnection cn;
        MemoryStream ms;
        public NewBook()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-I7HBV64;Initial Catalog=CMSDB;Integrated Security=True");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "*jpeg|*.jpg|*.bmp|*.gif|all files|*.*";
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.groupBox1.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                    MessageBox.Show("Enter ");
                }
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into Book(BookId,Title,Author,Publisher,Language,Pages,DOA,Quantity,Price,Description,Pic) values(@bid,@t,@a,@p,@l,@pages,@doa,@q,@price,@d,@pic)", cn);
                cm.Parameters.AddWithValue("@bid", textBox1.Text);
                cm.Parameters.AddWithValue("@t", textBox2.Text);
                cm.Parameters.AddWithValue("@a", textBox3.Text);
                cm.Parameters.AddWithValue("@p", textBox4.Text);
                cm.Parameters.AddWithValue("@l", textBox5.Text);
                cm.Parameters.AddWithValue("@pages", textBox6.Text);
                cm.Parameters.AddWithValue("@doa", dateTimePicker1.Value.Date);
                cm.Parameters.AddWithValue("@q", textBox7.Text);
                cm.Parameters.AddWithValue("@price", textBox8.Text);
                cm.Parameters.AddWithValue("@d", textBox9.Text);
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] p = ms.ToArray();
                cm.Parameters.AddWithValue("@pic",p);
                int re = cm.ExecuteNonQuery();
                if(re>0)
                    MessageBox.Show("Record Saved");

                else
                    MessageBox.Show("Record Not Saved");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void NewBook_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
