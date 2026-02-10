namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmAssignDoctorAmbulance
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
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblAmbulance = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.cmbAmbulance = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(197, 113);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(88, 16);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "Select Doctor";
            // 
            // lblAmbulance
            // 
            this.lblAmbulance.AutoSize = true;
            this.lblAmbulance.Location = new System.Drawing.Point(169, 163);
            this.lblAmbulance.Name = "lblAmbulance";
            this.lblAmbulance.Size = new System.Drawing.Size(116, 16);
            this.lblAmbulance.TabIndex = 1;
            this.lblAmbulance.Text = "Select Ambulance";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(304, 110);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(205, 24);
            this.cmbDoctor.TabIndex = 2;
            // 
            // cmbAmbulance
            // 
            this.cmbAmbulance.FormattingEnabled = true;
            this.cmbAmbulance.Location = new System.Drawing.Point(304, 160);
            this.cmbAmbulance.Name = "cmbAmbulance";
            this.cmbAmbulance.Size = new System.Drawing.Size(205, 24);
            this.cmbAmbulance.TabIndex = 3;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(314, 208);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(77, 34);
            this.btnAssign.TabIndex = 4;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(418, 208);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 34);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmAssignDoctorAmbulance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbAmbulance);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.lblAmbulance);
            this.Controls.Add(this.lblDoctor);
            this.Name = "FrmAssignDoctorAmbulance";
            this.Text = "FrmAssignDoctorAmbulance";
            this.Load += new System.EventHandler(this.FrmAssignDoctorAmbulance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblAmbulance;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.ComboBox cmbAmbulance;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnBack;
    }
}