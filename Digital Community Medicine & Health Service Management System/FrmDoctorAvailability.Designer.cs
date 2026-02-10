namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmDoctorAvailability
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
            this.datePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbClinic = new System.Windows.Forms.ComboBox();
            this.btnGenerateSlots = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // datePickerDate
            // 
            this.datePickerDate.Location = new System.Drawing.Point(147, 52);
            this.datePickerDate.Name = "datePickerDate";
            this.datePickerDate.Size = new System.Drawing.Size(274, 22);
            this.datePickerDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "End Time";
            // 
            // timePickerStart
            // 
            this.timePickerStart.Location = new System.Drawing.Point(147, 105);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.Size = new System.Drawing.Size(274, 22);
            this.timePickerStart.TabIndex = 4;
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.Location = new System.Drawing.Point(147, 156);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.Size = new System.Drawing.Size(274, 22);
            this.timePickerEnd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clinic";
            // 
            // cmbClinic
            // 
            this.cmbClinic.FormattingEnabled = true;
            this.cmbClinic.Location = new System.Drawing.Point(147, 209);
            this.cmbClinic.Name = "cmbClinic";
            this.cmbClinic.Size = new System.Drawing.Size(274, 24);
            this.cmbClinic.TabIndex = 7;
            // 
            // btnGenerateSlots
            // 
            this.btnGenerateSlots.Location = new System.Drawing.Point(159, 304);
            this.btnGenerateSlots.Name = "btnGenerateSlots";
            this.btnGenerateSlots.Size = new System.Drawing.Size(126, 49);
            this.btnGenerateSlots.TabIndex = 8;
            this.btnGenerateSlots.Text = "Generate Slots";
            this.btnGenerateSlots.UseVisualStyleBackColor = true;
            this.btnGenerateSlots.Click += new System.EventHandler(this.btnGenerateSlots_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(354, 304);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 49);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmDoctorAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGenerateSlots);
            this.Controls.Add(this.cmbClinic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timePickerEnd);
            this.Controls.Add(this.timePickerStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePickerDate);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoctorAvailability";
            this.Text = "FrmDoctorAvailability";
            this.Load += new System.EventHandler(this.FrmDoctorAvailability_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClinic;
        private System.Windows.Forms.Button btnGenerateSlots;
        private System.Windows.Forms.Button btnBack;
    }
}