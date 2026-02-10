namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmDoctorDashboard
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
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.lblTodayAppointments = new System.Windows.Forms.Label();
            this.lblUpcomingAppointments = new System.Windows.Forms.Label();
            this.lblTotalPatients = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblAvgRating = new System.Windows.Forms.Label();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnPrescriptions = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnFollowUp = new System.Windows.Forms.Button();
            this.btnSetAvailability = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Location = new System.Drawing.Point(70, 50);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(87, 16);
            this.lblDoctorName.TabIndex = 0;
            this.lblDoctorName.Text = "Doctor Name";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Location = new System.Drawing.Point(70, 89);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(91, 16);
            this.lblSpecialization.TabIndex = 1;
            this.lblSpecialization.Text = "Specialization";
            // 
            // lblTodayAppointments
            // 
            this.lblTodayAppointments.AutoSize = true;
            this.lblTodayAppointments.Location = new System.Drawing.Point(70, 138);
            this.lblTodayAppointments.Name = "lblTodayAppointments";
            this.lblTodayAppointments.Size = new System.Drawing.Size(132, 16);
            this.lblTodayAppointments.TabIndex = 2;
            this.lblTodayAppointments.Text = "Today Appointments";
            // 
            // lblUpcomingAppointments
            // 
            this.lblUpcomingAppointments.AutoSize = true;
            this.lblUpcomingAppointments.Location = new System.Drawing.Point(70, 186);
            this.lblUpcomingAppointments.Name = "lblUpcomingAppointments";
            this.lblUpcomingAppointments.Size = new System.Drawing.Size(154, 16);
            this.lblUpcomingAppointments.TabIndex = 3;
            this.lblUpcomingAppointments.Text = "Upcoming Appointments";
            // 
            // lblTotalPatients
            // 
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Location = new System.Drawing.Point(510, 50);
            this.lblTotalPatients.Name = "lblTotalPatients";
            this.lblTotalPatients.Size = new System.Drawing.Size(89, 16);
            this.lblTotalPatients.TabIndex = 4;
            this.lblTotalPatients.Text = "Total Patients";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(510, 89);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(96, 16);
            this.lblTotalRevenue.TabIndex = 5;
            this.lblTotalRevenue.Text = "Total Revenue";
            // 
            // lblAvgRating
            // 
            this.lblAvgRating.AutoSize = true;
            this.lblAvgRating.Location = new System.Drawing.Point(510, 138);
            this.lblAvgRating.Name = "lblAvgRating";
            this.lblAvgRating.Size = new System.Drawing.Size(73, 16);
            this.lblAvgRating.TabIndex = 6;
            this.lblAvgRating.Text = "Avg Rating";
            // 
            // btnAppointments
            // 
            this.btnAppointments.Location = new System.Drawing.Point(73, 225);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(156, 47);
            this.btnAppointments.TabIndex = 7;
            this.btnAppointments.Text = "View Appointments";
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnPrescriptions
            // 
            this.btnPrescriptions.Location = new System.Drawing.Point(73, 301);
            this.btnPrescriptions.Name = "btnPrescriptions";
            this.btnPrescriptions.Size = new System.Drawing.Size(141, 52);
            this.btnPrescriptions.TabIndex = 8;
            this.btnPrescriptions.Text = "Prescription History";
            this.btnPrescriptions.UseVisualStyleBackColor = true;
            this.btnPrescriptions.Click += new System.EventHandler(this.btnPrescriptions_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(337, 336);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 41);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNotifications
            // 
            this.btnNotifications.Location = new System.Drawing.Point(556, 225);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(156, 47);
            this.btnNotifications.TabIndex = 10;
            this.btnNotifications.Text = "Notifications";
            this.btnNotifications.UseVisualStyleBackColor = true;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnFollowUp
            // 
            this.btnFollowUp.Location = new System.Drawing.Point(556, 306);
            this.btnFollowUp.Name = "btnFollowUp";
            this.btnFollowUp.Size = new System.Drawing.Size(156, 47);
            this.btnFollowUp.TabIndex = 11;
            this.btnFollowUp.Text = "Follow-Up Reminders";
            this.btnFollowUp.UseVisualStyleBackColor = true;
            this.btnFollowUp.Click += new System.EventHandler(this.btnFollowUp_Click);
            // 
            // btnSetAvailability
            // 
            this.btnSetAvailability.Location = new System.Drawing.Point(302, 225);
            this.btnSetAvailability.Name = "btnSetAvailability";
            this.btnSetAvailability.Size = new System.Drawing.Size(156, 47);
            this.btnSetAvailability.TabIndex = 12;
            this.btnSetAvailability.Text = "Set Availability";
            this.btnSetAvailability.UseVisualStyleBackColor = true;
            this.btnSetAvailability.Click += new System.EventHandler(this.btnSetAvailability_Click);
            // 
            // FrmDoctorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSetAvailability);
            this.Controls.Add(this.btnFollowUp);
            this.Controls.Add(this.btnNotifications);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnPrescriptions);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.lblAvgRating);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.lblTotalPatients);
            this.Controls.Add(this.lblUpcomingAppointments);
            this.Controls.Add(this.lblTodayAppointments);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.lblDoctorName);
            this.Name = "FrmDoctorDashboard";
            this.Text = "FrmDoctorDashboard";
            this.Load += new System.EventHandler(this.FrmDoctorDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Label lblTodayAppointments;
        private System.Windows.Forms.Label lblUpcomingAppointments;
        private System.Windows.Forms.Label lblTotalPatients;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblAvgRating;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnPrescriptions;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnFollowUp;
        private System.Windows.Forms.Button btnSetAvailability;
    }
}