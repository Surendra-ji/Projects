using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;

namespace backuprestore
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        
        SqlDataReader dr;
        
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(@"data source=SAROJNI-PC;integrated security=true");
        }


        public void CreateConnection()
        {
            
            cn.Open();
            SqlCommand cm = new SqlCommand("select * from sys.databases", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        public void ServerName()
        {
            cn.Close();
            cn.Open();
            SqlCommand cm1 = new SqlCommand("select * from sys.servers", cn);
            dr = cm1.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            cn.Close();
        }

        public void BackupData(string str)
        {

            //str = comboBox3.SelectedItem.ToString();
            SqlDataReader dr;

            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Server Name or DataBase can Not Be Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (str == "backup")
                    {
                        if (cn.State != ConnectionState.Open)
                            cn.Open();
                        saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files(*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            SqlCommand cm2 = new SqlCommand();
                           // MessageBox.Show(saveFileDialog1.FileName);
                            cm2.CommandText = @"Backup database   " + comboBox2.SelectedItem.ToString() + "  to disk =    '" + saveFileDialog1.FileName + "' ";
                            cm2.CommandType = CommandType.Text;
                            cm2.Connection = cn;
                            dr = cm2.ExecuteReader();
                            dr.Read();
                            cn.Close();
                            MessageBox.Show("backup completed Successfully");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void RestoreData()
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateConnection();
            ServerName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackupData(comboBox3.SelectedItem.ToString());
        }
    }
}
