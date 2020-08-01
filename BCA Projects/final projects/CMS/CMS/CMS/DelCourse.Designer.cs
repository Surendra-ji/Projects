namespace CMS
{
    partial class DelCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelCourse));
            this.btnaddcourse = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtcoursename = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnaddcourse
            // 
            this.btnaddcourse.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnaddcourse.FlatAppearance.BorderSize = 2;
            this.btnaddcourse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnaddcourse.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnaddcourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddcourse.Image = ((System.Drawing.Image)(resources.GetObject("btnaddcourse.Image")));
            this.btnaddcourse.Location = new System.Drawing.Point(209, 126);
            this.btnaddcourse.Name = "btnaddcourse";
            this.btnaddcourse.Size = new System.Drawing.Size(89, 29);
            this.btnaddcourse.TabIndex = 3;
            this.btnaddcourse.Text = " DELETE";
            this.btnaddcourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaddcourse.UseVisualStyleBackColor = true;
            this.btnaddcourse.Click += new System.EventHandler(this.btnaddcourse_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(101, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 15);
            this.label30.TabIndex = 6;
            this.label30.Text = "Course Name";
            // 
            // txtcoursename
            // 
            this.txtcoursename.Location = new System.Drawing.Point(199, 69);
            this.txtcoursename.Name = "txtcoursename";
            this.txtcoursename.Size = new System.Drawing.Size(155, 21);
            this.txtcoursename.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnaddcourse);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtcoursename);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(82, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 174);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Course";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 13);
            this.panel1.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(146, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(318, 45);
            this.label11.TabIndex = 1;
            this.label11.Text = "Delete Course";
            // 
            // DelCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 391);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DelCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DelCourse";
            this.Load += new System.EventHandler(this.DelCourse_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnaddcourse;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtcoursename;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
    }
}