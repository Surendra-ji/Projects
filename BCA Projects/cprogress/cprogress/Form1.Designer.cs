namespace cprogress
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.circularprogresssbar1 = new cprogress.circularprogresssbar();
            this.button1 = new System.Windows.Forms.Button();
            this.circularprogresssbar2 = new cprogress.circularprogresssbar();
            this.SuspendLayout();
            // 
            // circularprogresssbar1
            // 
            this.circularprogresssbar1.Location = new System.Drawing.Point(232, 94);
            this.circularprogresssbar1.Name = "circularprogresssbar1";
            this.circularprogresssbar1.Size = new System.Drawing.Size(200, 200);
            this.circularprogresssbar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // circularprogresssbar2
            // 
            this.circularprogresssbar2.Location = new System.Drawing.Point(494, 55);
            this.circularprogresssbar2.Name = "circularprogresssbar2";
            this.circularprogresssbar2.Size = new System.Drawing.Size(137, 127);
            this.circularprogresssbar2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 370);
            this.Controls.Add(this.circularprogresssbar2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.circularprogresssbar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private cprogress.circularprogresssbar circularprogresssbar1;
        private System.Windows.Forms.Button button1;
        private cprogress.circularprogresssbar circularprogresssbar2;


    }
}

