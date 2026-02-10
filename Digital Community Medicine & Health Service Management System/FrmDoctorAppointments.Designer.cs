namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmDoctorAppointments
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnCreatePrescription = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCompleteAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor Appointments";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(45, 49);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(705, 273);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellClick);
            // 
            // btnCreatePrescription
            // 
            this.btnCreatePrescription.Location = new System.Drawing.Point(231, 355);
            this.btnCreatePrescription.Name = "btnCreatePrescription";
            this.btnCreatePrescription.Size = new System.Drawing.Size(99, 55);
            this.btnCreatePrescription.TabIndex = 2;
            this.btnCreatePrescription.Text = "Create Prescription";
            this.btnCreatePrescription.UseVisualStyleBackColor = true;
            this.btnCreatePrescription.Click += new System.EventHandler(this.btnCreatePrescription_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(406, 368);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 29);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(594, 368);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 29);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCompleteAppointment
            // 
            this.btnCompleteAppointment.Location = new System.Drawing.Point(83, 355);
            this.btnCompleteAppointment.Name = "btnCompleteAppointment";
            this.btnCompleteAppointment.Size = new System.Drawing.Size(94, 64);
            this.btnCompleteAppointment.TabIndex = 5;
            this.btnCompleteAppointment.Text = "Complete Appointment";
            this.btnCompleteAppointment.UseVisualStyleBackColor = true;
            this.btnCompleteAppointment.Click += new System.EventHandler(this.btnCompleteAppointment_Click);
            // 
            // FrmDoctorAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCompleteAppointment);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCreatePrescription);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoctorAppointments";
            this.Text = "FrmDoctorAppointments";
            this.Load += new System.EventHandler(this.FrmDoctorAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnCreatePrescription;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCompleteAppointment;
    }
}