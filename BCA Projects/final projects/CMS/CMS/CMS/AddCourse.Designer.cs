namespace CMS
{
    partial class AddCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCourse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblduration = new System.Windows.Forms.Label();
            this.cmbduration = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblcpricee = new System.Windows.Forms.Label();
            this.lblcnamee = new System.Windows.Forms.Label();
            this.btnaddcourse = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtcoursefees = new System.Windows.Forms.TextBox();
            this.txtcoursename = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 10);
            this.panel1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblduration);
            this.groupBox2.Controls.Add(this.cmbduration);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.lblcpricee);
            this.groupBox2.Controls.Add(this.lblcnamee);
            this.groupBox2.Controls.Add(this.btnaddcourse);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtcoursefees);
            this.groupBox2.Controls.Add(this.txtcoursename);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(148, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 326);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Course";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(105, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 15);
            this.label30.TabIndex = 31;
            this.label30.Text = "Course Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(271, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 31);
            this.button1.TabIndex = 30;
            this.button1.Text = "  REFRESH";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(358, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Certified By :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(199, 203);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 21);
            this.textBox2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(358, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Issued By :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 21);
            this.textBox1.TabIndex = 21;
            // 
            // lblduration
            // 
            this.lblduration.AutoSize = true;
            this.lblduration.ForeColor = System.Drawing.Color.Red;
            this.lblduration.Location = new System.Drawing.Point(358, 135);
            this.lblduration.Name = "lblduration";
            this.lblduration.Size = new System.Drawing.Size(12, 15);
            this.lblduration.TabIndex = 20;
            this.lblduration.Text = "*";
            this.lblduration.Visible = false;
            // 
            // cmbduration
            // 
            this.cmbduration.FormattingEnabled = true;
            this.cmbduration.Items.AddRange(new object[] {
            "1 MONTH",
            "2 MONTH",
            "3 MONTH",
            "4 MONTH",
            "5 MONTH",
            "6 MONTH",
            "10 MONTH",
            "1 YEAR",
            "2 YEAR",
            "3 YEAR",
            "4 YEAR"});
            this.cmbduration.Location = new System.Drawing.Point(199, 139);
            this.cmbduration.Name = "cmbduration";
            this.cmbduration.Size = new System.Drawing.Size(155, 23);
            this.cmbduration.TabIndex = 2;
            this.cmbduration.Text = "SELECT";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(104, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 15);
            this.label21.TabIndex = 18;
            this.label21.Text = "Time Duration :";
            // 
            // lblcpricee
            // 
            this.lblcpricee.AutoSize = true;
            this.lblcpricee.ForeColor = System.Drawing.Color.Red;
            this.lblcpricee.Location = new System.Drawing.Point(358, 102);
            this.lblcpricee.Name = "lblcpricee";
            this.lblcpricee.Size = new System.Drawing.Size(12, 15);
            this.lblcpricee.TabIndex = 17;
            this.lblcpricee.Text = "*";
            this.lblcpricee.Visible = false;
            // 
            // lblcnamee
            // 
            this.lblcnamee.AutoSize = true;
            this.lblcnamee.ForeColor = System.Drawing.Color.Red;
            this.lblcnamee.Location = new System.Drawing.Point(358, 69);
            this.lblcnamee.Name = "lblcnamee";
            this.lblcnamee.Size = new System.Drawing.Size(12, 15);
            this.lblcnamee.TabIndex = 16;
            this.lblcnamee.Text = "*";
            this.lblcnamee.Visible = false;
            // 
            // btnaddcourse
            // 
            this.btnaddcourse.BackColor = System.Drawing.Color.White;
            this.btnaddcourse.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnaddcourse.FlatAppearance.BorderSize = 2;
            this.btnaddcourse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnaddcourse.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnaddcourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddcourse.Image = ((System.Drawing.Image)(resources.GetObject("btnaddcourse.Image")));
            this.btnaddcourse.Location = new System.Drawing.Point(154, 256);
            this.btnaddcourse.Name = "btnaddcourse";
            this.btnaddcourse.Size = new System.Drawing.Size(78, 31);
            this.btnaddcourse.TabIndex = 3;
            this.btnaddcourse.Text = "  SAVE";
            this.btnaddcourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaddcourse.UseVisualStyleBackColor = false;
            this.btnaddcourse.Click += new System.EventHandler(this.btnaddcourse_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(105, 108);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 15);
            this.label29.TabIndex = 7;
            this.label29.Text = "Fees :";
            // 
            // txtcoursefees
            // 
            this.txtcoursefees.Location = new System.Drawing.Point(199, 105);
            this.txtcoursefees.Name = "txtcoursefees";
            this.txtcoursefees.Size = new System.Drawing.Size(155, 21);
            this.txtcoursefees.TabIndex = 1;
            // 
            // txtcoursename
            // 
            this.txtcoursename.Location = new System.Drawing.Point(199, 69);
            this.txtcoursename.Name = "txtcoursename";
            this.txtcoursename.Size = new System.Drawing.Size(155, 21);
            this.txtcoursename.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Algerian", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(205, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(343, 45);
            this.label11.TabIndex = 13;
            this.label11.Text = "Add New Course";
            // 
            // AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(717, 518);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(733, 557);
            this.MinimumSize = new System.Drawing.Size(733, 557);
            this.Name = "AddCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCourse";
            this.Load += new System.EventHandler(this.AddCourse_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblduration;
        private System.Windows.Forms.ComboBox cmbduration;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblcpricee;
        private System.Windows.Forms.Label lblcnamee;
        private System.Windows.Forms.Button btnaddcourse;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtcoursefees;
        private System.Windows.Forms.TextBox txtcoursename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label11;
    }
}