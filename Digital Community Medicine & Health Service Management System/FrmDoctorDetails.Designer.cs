namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmDoctorDetails
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
            this.dataGridViewClinics = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClinics)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Location = new System.Drawing.Point(198, 51);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(87, 16);
            this.lblDoctorName.TabIndex = 0;
            this.lblDoctorName.Text = "Doctor Name";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Location = new System.Drawing.Point(468, 51);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(91, 16);
            this.lblSpecialization.TabIndex = 1;
            this.lblSpecialization.Text = "Specialization";
            // 
            // dataGridViewClinics
            // 
            this.dataGridViewClinics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClinics.Location = new System.Drawing.Point(53, 91);
            this.dataGridViewClinics.Name = "dataGridViewClinics";
            this.dataGridViewClinics.RowHeadersWidth = 51;
            this.dataGridViewClinics.RowTemplate.Height = 24;
            this.dataGridViewClinics.Size = new System.Drawing.Size(605, 324);
            this.dataGridViewClinics.TabIndex = 2;
            this.dataGridViewClinics.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClinics_CellDoubleClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(682, 390);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 48);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmDoctorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewClinics);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.lblDoctorName);
            this.Name = "FrmDoctorDetails";
            this.Text = "FrmDoctorDetails";
            this.Load += new System.EventHandler(this.FrmDoctorDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClinics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.DataGridView dataGridViewClinics;
        private System.Windows.Forms.Button btnBack;
    }
}