namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmDoctorRegistration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblApprovalStatus = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowseCertificate = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.numExperience = new System.Windows.Forms.NumericUpDown();
            this.txtCertificatePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbClinic = new System.Windows.Forms.ComboBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtConsultationFee = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor Information Section";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Specialization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reg No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Years Of Experience";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Certificate Upload";
            // 
            // lblApprovalStatus
            // 
            this.lblApprovalStatus.AutoSize = true;
            this.lblApprovalStatus.Location = new System.Drawing.Point(290, 340);
            this.lblApprovalStatus.Name = "lblApprovalStatus";
            this.lblApprovalStatus.Size = new System.Drawing.Size(156, 16);
            this.lblApprovalStatus.TabIndex = 6;
            this.lblApprovalStatus.Text = "Pending Admin Approval";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(238, 400);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowseCertificate
            // 
            this.btnBrowseCertificate.Location = new System.Drawing.Point(596, 124);
            this.btnBrowseCertificate.Name = "btnBrowseCertificate";
            this.btnBrowseCertificate.Size = new System.Drawing.Size(172, 41);
            this.btnBrowseCertificate.TabIndex = 9;
            this.btnBrowseCertificate.Text = "Browse Certificate";
            this.btnBrowseCertificate.UseVisualStyleBackColor = true;
            this.btnBrowseCertificate.Click += new System.EventHandler(this.btnBrowseCertificate_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(151, 63);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(162, 22);
            this.txtFullName.TabIndex = 10;
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Location = new System.Drawing.Point(151, 103);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(162, 24);
            this.cmbSpecialization.TabIndex = 11;
            // 
            // txtRegNo
            // 
            this.txtRegNo.Location = new System.Drawing.Point(151, 143);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(162, 22);
            this.txtRegNo.TabIndex = 12;
            // 
            // numExperience
            // 
            this.numExperience.Location = new System.Drawing.Point(193, 197);
            this.numExperience.Name = "numExperience";
            this.numExperience.Size = new System.Drawing.Size(120, 22);
            this.numExperience.TabIndex = 13;
            // 
            // txtCertificatePath
            // 
            this.txtCertificatePath.Location = new System.Drawing.Point(596, 63);
            this.txtCertificatePath.Name = "txtCertificatePath";
            this.txtCertificatePath.Size = new System.Drawing.Size(154, 22);
            this.txtCertificatePath.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Clinic";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Area";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Consultation Fee";
            // 
            // cmbClinic
            // 
            this.cmbClinic.FormattingEnabled = true;
            this.cmbClinic.Location = new System.Drawing.Point(151, 239);
            this.cmbClinic.Name = "cmbClinic";
            this.cmbClinic.Size = new System.Drawing.Size(162, 24);
            this.cmbClinic.TabIndex = 18;
            this.cmbClinic.SelectedIndexChanged += new System.EventHandler(this.cmbClinic_SelectedIndexChanged);
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(615, 220);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(153, 22);
            this.txtArea.TabIndex = 19;
            // 
            // txtConsultationFee
            // 
            this.txtConsultationFee.Location = new System.Drawing.Point(615, 279);
            this.txtConsultationFee.Name = "txtConsultationFee";
            this.txtConsultationFee.Size = new System.Drawing.Size(153, 22);
            this.txtConsultationFee.TabIndex = 20;
            // 
            // FrmDoctorRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtConsultationFee);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.cmbClinic);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCertificatePath);
            this.Controls.Add(this.numExperience);
            this.Controls.Add(this.txtRegNo);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.btnBrowseCertificate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblApprovalStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoctorRegistration";
            this.Text = "FrmDoctorRegistration";
            this.Load += new System.EventHandler(this.FrmDoctorRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblApprovalStatus;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowseCertificate;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.NumericUpDown numExperience;
        private System.Windows.Forms.TextBox txtCertificatePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbClinic;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtConsultationFee;
    }
}