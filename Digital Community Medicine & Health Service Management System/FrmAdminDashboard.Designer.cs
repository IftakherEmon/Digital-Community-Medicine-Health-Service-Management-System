namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmAdminDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnDiagnosticLab = new System.Windows.Forms.Button();
            this.btnComplaintManagement = new System.Windows.Forms.Button();
            this.btnAmbulanceManagement = new System.Windows.Forms.Button();
            this.btnEmergencyRequests = new System.Windows.Forms.Button();
            this.btnPaymentVerification = new System.Windows.Forms.Button();
            this.btnDoctorApproval = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageClinic = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(198, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Dashboard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Digital Community Medicine and Health Service Management System";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(539, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(109, 16);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome, Admin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnManageClinic);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnDiagnosticLab);
            this.panel1.Controls.Add(this.btnComplaintManagement);
            this.panel1.Controls.Add(this.btnAmbulanceManagement);
            this.panel1.Controls.Add(this.btnEmergencyRequests);
            this.panel1.Controls.Add(this.btnPaymentVerification);
            this.panel1.Controls.Add(this.btnDoctorApproval);
            this.panel1.Location = new System.Drawing.Point(128, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 358);
            this.panel1.TabIndex = 3;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(12, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(397, 33);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnDiagnosticLab
            // 
            this.btnDiagnosticLab.Location = new System.Drawing.Point(12, 231);
            this.btnDiagnosticLab.Name = "btnDiagnosticLab";
            this.btnDiagnosticLab.Size = new System.Drawing.Size(397, 33);
            this.btnDiagnosticLab.TabIndex = 9;
            this.btnDiagnosticLab.Text = "Diagnostic Lab";
            this.btnDiagnosticLab.UseVisualStyleBackColor = true;
            this.btnDiagnosticLab.Click += new System.EventHandler(this.btnDiagnosticLab_Click);
            // 
            // btnComplaintManagement
            // 
            this.btnComplaintManagement.Location = new System.Drawing.Point(12, 192);
            this.btnComplaintManagement.Name = "btnComplaintManagement";
            this.btnComplaintManagement.Size = new System.Drawing.Size(397, 33);
            this.btnComplaintManagement.TabIndex = 8;
            this.btnComplaintManagement.Text = "Complaint Management";
            this.btnComplaintManagement.UseVisualStyleBackColor = true;
            this.btnComplaintManagement.Click += new System.EventHandler(this.btnComplaintManagement_Click);
            // 
            // btnAmbulanceManagement
            // 
            this.btnAmbulanceManagement.Location = new System.Drawing.Point(12, 153);
            this.btnAmbulanceManagement.Name = "btnAmbulanceManagement";
            this.btnAmbulanceManagement.Size = new System.Drawing.Size(397, 33);
            this.btnAmbulanceManagement.TabIndex = 7;
            this.btnAmbulanceManagement.Text = "Ambulance Management";
            this.btnAmbulanceManagement.UseVisualStyleBackColor = true;
            this.btnAmbulanceManagement.Click += new System.EventHandler(this.btnAmbulanceManagement_Click);
            // 
            // btnEmergencyRequests
            // 
            this.btnEmergencyRequests.Location = new System.Drawing.Point(12, 114);
            this.btnEmergencyRequests.Name = "btnEmergencyRequests";
            this.btnEmergencyRequests.Size = new System.Drawing.Size(397, 33);
            this.btnEmergencyRequests.TabIndex = 6;
            this.btnEmergencyRequests.Text = "Emergency Requests";
            this.btnEmergencyRequests.UseVisualStyleBackColor = true;
            this.btnEmergencyRequests.Click += new System.EventHandler(this.btnEmergencyRequests_Click);
            // 
            // btnPaymentVerification
            // 
            this.btnPaymentVerification.Location = new System.Drawing.Point(12, 75);
            this.btnPaymentVerification.Name = "btnPaymentVerification";
            this.btnPaymentVerification.Size = new System.Drawing.Size(397, 33);
            this.btnPaymentVerification.TabIndex = 5;
            this.btnPaymentVerification.Text = "Payment Verification";
            this.btnPaymentVerification.UseVisualStyleBackColor = true;
            this.btnPaymentVerification.Click += new System.EventHandler(this.btnPaymentVerification_Click);
            // 
            // btnDoctorApproval
            // 
            this.btnDoctorApproval.Location = new System.Drawing.Point(12, 36);
            this.btnDoctorApproval.Name = "btnDoctorApproval";
            this.btnDoctorApproval.Size = new System.Drawing.Size(397, 33);
            this.btnDoctorApproval.TabIndex = 4;
            this.btnDoctorApproval.Text = "Doctor Approval";
            this.btnDoctorApproval.UseVisualStyleBackColor = true;
            this.btnDoctorApproval.Click += new System.EventHandler(this.btnDoctorApproval_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(644, 389);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageClinic
            // 
            this.btnManageClinic.Location = new System.Drawing.Point(12, 309);
            this.btnManageClinic.Name = "btnManageClinic";
            this.btnManageClinic.Size = new System.Drawing.Size(397, 33);
            this.btnManageClinic.TabIndex = 11;
            this.btnManageClinic.Text = "Manage Clinics";
            this.btnManageClinic.UseVisualStyleBackColor = true;
            this.btnManageClinic.Click += new System.EventHandler(this.btnManageClinic_Click);
            // 
            // FrmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmAdminDashboard";
            this.Text = "Digital Community Medicine & Health Service Management System";
            this.Load += new System.EventHandler(this.Admin_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoctorApproval;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnDiagnosticLab;
        private System.Windows.Forms.Button btnComplaintManagement;
        private System.Windows.Forms.Button btnAmbulanceManagement;
        private System.Windows.Forms.Button btnEmergencyRequests;
        private System.Windows.Forms.Button btnPaymentVerification;
        private System.Windows.Forms.Button btnManageClinic;
    }
}