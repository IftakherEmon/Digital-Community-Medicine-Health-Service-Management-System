namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmFollowUpReminder
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtxtNote = new System.Windows.Forms.RichTextBox();
            this.cmbReminderType = new System.Windows.Forms.ComboBox();
            this.dtpReminderDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrescriptionId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(639, 370);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 53);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(361, 370);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(85, 53);
            this.btnSkip.TabIndex = 18;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 53);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save Remainder";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtxtNote
            // 
            this.rtxtNote.Location = new System.Drawing.Point(186, 157);
            this.rtxtNote.Name = "rtxtNote";
            this.rtxtNote.Size = new System.Drawing.Size(247, 30);
            this.rtxtNote.TabIndex = 16;
            this.rtxtNote.Text = "";
            // 
            // cmbReminderType
            // 
            this.cmbReminderType.FormattingEnabled = true;
            this.cmbReminderType.Location = new System.Drawing.Point(186, 115);
            this.cmbReminderType.Name = "cmbReminderType";
            this.cmbReminderType.Size = new System.Drawing.Size(247, 24);
            this.cmbReminderType.TabIndex = 15;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Location = new System.Drawing.Point(183, 80);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(250, 22);
            this.dtpReminderDate.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Reminder Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Reminder Date";
            // 
            // lblPrescriptionId
            // 
            this.lblPrescriptionId.AutoSize = true;
            this.lblPrescriptionId.Location = new System.Drawing.Point(358, 28);
            this.lblPrescriptionId.Name = "lblPrescriptionId";
            this.lblPrescriptionId.Size = new System.Drawing.Size(92, 16);
            this.lblPrescriptionId.TabIndex = 10;
            this.lblPrescriptionId.Text = "Prescription Id";
            // 
            // FrmFollowUpReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtxtNote);
            this.Controls.Add(this.cmbReminderType);
            this.Controls.Add(this.dtpReminderDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPrescriptionId);
            this.Name = "FrmFollowUpReminder";
            this.Text = "FrmFollowUpReminder";
            this.Load += new System.EventHandler(this.FrmFollowUpReminder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtxtNote;
        private System.Windows.Forms.ComboBox cmbReminderType;
        private System.Windows.Forms.DateTimePicker dtpReminderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrescriptionId;
    }
}