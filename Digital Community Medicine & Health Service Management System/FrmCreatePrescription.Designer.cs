namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmCreatePrescription
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
            this.lblAppointmentId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtxtSymptoms = new System.Windows.Forms.RichTextBox();
            this.rtxtDiagnosis = new System.Windows.Forms.RichTextBox();
            this.rtxtAdvice = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNextVisitDate = new System.Windows.Forms.DateTimePicker();
            this.btnSavePrescription = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAppointmentId
            // 
            this.lblAppointmentId.AutoSize = true;
            this.lblAppointmentId.Location = new System.Drawing.Point(104, 40);
            this.lblAppointmentId.Name = "lblAppointmentId";
            this.lblAppointmentId.Size = new System.Drawing.Size(96, 16);
            this.lblAppointmentId.TabIndex = 0;
            this.lblAppointmentId.Text = "Appointment Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symptoms  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diagnosis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Advice  ";
            // 
            // rtxtSymptoms
            // 
            this.rtxtSymptoms.Location = new System.Drawing.Point(186, 98);
            this.rtxtSymptoms.Name = "rtxtSymptoms";
            this.rtxtSymptoms.Size = new System.Drawing.Size(242, 32);
            this.rtxtSymptoms.TabIndex = 4;
            this.rtxtSymptoms.Text = "";
            // 
            // rtxtDiagnosis
            // 
            this.rtxtDiagnosis.Location = new System.Drawing.Point(186, 159);
            this.rtxtDiagnosis.Name = "rtxtDiagnosis";
            this.rtxtDiagnosis.Size = new System.Drawing.Size(242, 32);
            this.rtxtDiagnosis.TabIndex = 5;
            this.rtxtDiagnosis.Text = "";
            // 
            // rtxtAdvice
            // 
            this.rtxtAdvice.Location = new System.Drawing.Point(186, 228);
            this.rtxtAdvice.Name = "rtxtAdvice";
            this.rtxtAdvice.Size = new System.Drawing.Size(242, 32);
            this.rtxtAdvice.TabIndex = 6;
            this.rtxtAdvice.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Next Visit Date";
            // 
            // dtpNextVisitDate
            // 
            this.dtpNextVisitDate.Location = new System.Drawing.Point(186, 294);
            this.dtpNextVisitDate.Name = "dtpNextVisitDate";
            this.dtpNextVisitDate.Size = new System.Drawing.Size(256, 22);
            this.dtpNextVisitDate.TabIndex = 8;
            // 
            // btnSavePrescription
            // 
            this.btnSavePrescription.Location = new System.Drawing.Point(242, 354);
            this.btnSavePrescription.Name = "btnSavePrescription";
            this.btnSavePrescription.Size = new System.Drawing.Size(139, 62);
            this.btnSavePrescription.TabIndex = 9;
            this.btnSavePrescription.Text = "Save Prescription";
            this.btnSavePrescription.UseVisualStyleBackColor = true;
            this.btnSavePrescription.Click += new System.EventHandler(this.btnSavePrescription_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(687, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 32);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmCreatePrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSavePrescription);
            this.Controls.Add(this.dtpNextVisitDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxtAdvice);
            this.Controls.Add(this.rtxtDiagnosis);
            this.Controls.Add(this.rtxtSymptoms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAppointmentId);
            this.Name = "FrmCreatePrescription";
            this.Text = "FrmCreatePrescription";
            this.Load += new System.EventHandler(this.FrmCreatePrescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppointmentId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtxtSymptoms;
        private System.Windows.Forms.RichTextBox rtxtDiagnosis;
        private System.Windows.Forms.RichTextBox rtxtAdvice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNextVisitDate;
        private System.Windows.Forms.Button btnSavePrescription;
        private System.Windows.Forms.Button btnBack;
    }
}