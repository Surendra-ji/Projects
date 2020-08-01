using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace cprogress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void runprogress()
        {
            
            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.progressupdate)).Start(i);
                    Thread.Sleep(40);
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.progressupdate)).Start(i);
                    Thread.Sleep(40);
                }
            });
            }
        public void progressupdate(object progress)
        {
            circularprogresssbar1.Invoke((MethodInvoker)delegate { circularprogresssbar1.updateprogress(Convert.ToInt32(progress)); });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runprogress();
        }
            }
        }
    

