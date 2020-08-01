using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            groupBox4.Hide();
            groupBox3.Hide();
            groupBox1.Hide();
           gbcourse.Hide();
           groupBox5.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {
            panel1.Show();
           panel1.Height = Student.Height;
           panel1.Top = Student.Top;
            panel3.Show();
            groupBox1.Hide();
           groupBox5.Hide();
            groupBox3.Hide();

            gbcourse.Hide();
            groupBox4.Show();
             }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

   
        private void Course_Click(object sender, EventArgs e)
        {
          panel1.Show();
           panel1.Height = Course.Height;
           panel1.Top = Course.Top;

           panel3.Show();
           groupBox1.Hide();
           groupBox5.Hide();
           groupBox3.Hide();
           groupBox4.Hide();
           gbcourse.Show();
             
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

   
        private void AddStudent_Click(object sender, EventArgs e)
        {
            StdReg ob = new StdReg();
            ob.Show();

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void NewBookp_Click(object sender, EventArgs e)
        {
            NewBook ob = new NewBook();
            ob.ShowDialog();
        }
        BlurForm b;
        private void AddCourse_Click(object sender, EventArgs e)
        {
            if (b == null)
            {
                b = new BlurForm(AddCourse.Name);
                b.AllowTransparency = true;
                b.FormClosed += b_FormClosed;
                b.Show();
            }
        }

        void b_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            b = null;
            this.Activate();
        }

        private void DelCourse_Click(object sender, EventArgs e)
        {
            DelCourse ob = new DelCourse();
            ob.ShowDialog();
        }

        private void EditCourse_Click(object sender, EventArgs e)
        {
            if (b == null)
            {
                b = new BlurForm(EditCourse.Name);
                b.AllowTransparency = true;
                b.FormClosed += b_FormClosed;
                b.Show();
            }
        }

        private void EditStudent_Click(object sender, EventArgs e)
        {
            EditStd ob = new EditStd();
            ob.ShowDialog();
        }

        private void ShowStudent_Click(object sender, EventArgs e)
        {
            ShowStd ob = new ShowStd();
            ob.ShowDialog();
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {

        }

        private void SearchCourse_Click(object sender, EventArgs e)
        {
            if (b == null)
            {
                b = new BlurForm(SearchCourse.Name);
                b.AllowTransparency = true;
                b.FormClosed += b_FormClosed;
                b.Show();
            }
        }

        private void StudentFee_Click(object sender, EventArgs e)
        {
            FeesCard ob = new FeesCard();
            ob.ShowDialog();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddTeacher ob = new AddTeacher();
            ob.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SETeacher ob = new SETeacher();
            ob.ShowDialog();

        }

        private void Employee_Click(object sender, EventArgs e)
        {
        
            panel1.Show();
            panel1.Height = Employee.Height;
            panel1.Top = Employee.Top;
            panel3.Show();
            groupBox5.Hide();
            groupBox4.Hide();
            groupBox3.Hide();

           gbcourse.Hide();
            groupBox1.Show();
       
        }

        private void Library_Click(object sender, EventArgs e)
        {
           panel1.Show();
           panel1.Height = Library.Height;
           panel1.Top = Library.Top;
           panel3.Show();
           groupBox1.Hide();
           groupBox5.Hide();
           groupBox4.Hide();

           gbcourse.Hide();
           groupBox3.Show();
          }

        private void Finance_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel1.Height = Finance.Height;
            panel1.Top = Finance.Top;
             
            panel3.Show();
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
           gbcourse.Hide();

            groupBox5.Show();
  }

        private void Exit_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel1.Height = Exit.Height;
            panel1.Top = Exit.Top;
          
            this.Close();

        }

        private void AddMemberP_Click(object sender, EventArgs e)
        {
            Member ob = new Member();
            ob.ShowDialog();
        }

        private void IssueBookP_Click(object sender, EventArgs e)
        {
            BookIssue ob = new BookIssue();
            ob.ShowDialog();
        }

        private void ReissueBookP_Click(object sender, EventArgs e)
        {
            SubmitBook sb = new SubmitBook();
            sb.ShowDialog();

        }

        private void EmployeeFee_Click(object sender, EventArgs e)
        {
            AllFeesCard ob = new AllFeesCard();
            ob.ShowDialog();
        }

        private void FinanReport_Click(object sender, EventArgs e)
        {
            FeesCardReport ob = new FeesCardReport();
            ob.ShowDialog();
        }

        private void SearchBookP_Click(object sender, EventArgs e)
        {
            SearchBook ob = new SearchBook();
            ob.ShowDialog();

        }
    }
}
