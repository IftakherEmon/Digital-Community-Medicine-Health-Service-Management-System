namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmPrescriptionMedicine
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
            this.dgvPrescriptionMedicine = new System.Windows.Forms.DataGridView();
            this.numDurationDays = new System.Windows.Forms.NumericUpDown();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.cmbMedicine = new System.Windows.Forms.ComboBox();
            this.Instructions = new System.Windows.Forms.Label();
            this.DurationDays = new System.Windows.Forms.Label();
            this.Frequency = new System.Windows.Forms.Label();
            this.Dosage = new System.Windows.Forms.Label();
            this.Medicine = new System.Windows.Forms.Label();
            this.lblPrescriptionId = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSaveFinish = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddMedicine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationDays)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrescriptionMedicine
            // 
            this.dgvPrescriptionMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptionMedicine.Location = new System.Drawing.Point(404, 66);
            this.dgvPrescriptionMedicine.Name = "dgvPrescriptionMedicine";
            this.dgvPrescriptionMedicine.RowHeadersWidth = 51;
            this.dgvPrescriptionMedicine.RowTemplate.Height = 24;
            this.dgvPrescriptionMedicine.Size = new System.Drawing.Size(352, 227);
            this.dgvPrescriptionMedicine.TabIndex = 16;
            // 
            // numDurationDays
            // 
            this.numDurationDays.Location = new System.Drawing.Point(110, 201);
            this.numDurationDays.Name = "numDurationDays";
            this.numDurationDays.Size = new System.Drawing.Size(225, 22);
            this.numDurationDays.TabIndex = 26;
            // 
            // txtInstructions
            // 
            this.txtInstructions.Location = new System.Drawing.Point(110, 241);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(225, 22);
            this.txtInstructions.TabIndex = 25;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(110, 165);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(225, 22);
            this.txtFrequency.TabIndex = 24;
            // 
            // txtDosage
            // 
            this.txtDosage.Location = new System.Drawing.Point(110, 125);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(225, 22);
            this.txtDosage.TabIndex = 23;
            // 
            // cmbMedicine
            // 
            this.cmbMedicine.FormattingEnabled = true;
            this.cmbMedicine.Location = new System.Drawing.Point(110, 84);
            this.cmbMedicine.Name = "cmbMedicine";
            this.cmbMedicine.Size = new System.Drawing.Size(221, 24);
            this.cmbMedicine.TabIndex = 22;
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Location = new System.Drawing.Point(12, 241);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(66, 16);
            this.Instructions.TabIndex = 21;
            this.Instructions.Text = "Instruction";
            // 
            // DurationDays
            // 
            this.DurationDays.AutoSize = true;
            this.DurationDays.Location = new System.Drawing.Point(12, 203);
            this.DurationDays.Name = "DurationDays";
            this.DurationDays.Size = new System.Drawing.Size(92, 16);
            this.DurationDays.TabIndex = 20;
            this.DurationDays.Text = "Duration Days";
            // 
            // Frequency
            // 
            this.Frequency.AutoSize = true;
            this.Frequency.Location = new System.Drawing.Point(12, 171);
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(71, 16);
            this.Frequency.TabIndex = 19;
            this.Frequency.Text = "Frequency";
            // 
            // Dosage
            // 
            this.Dosage.AutoSize = true;
            this.Dosage.Location = new System.Drawing.Point(12, 125);
            this.Dosage.Name = "Dosage";
            this.Dosage.Size = new System.Drawing.Size(56, 16);
            this.Dosage.TabIndex = 18;
            this.Dosage.Text = "Dosage";
            // 
            // Medicine
            // 
            this.Medicine.AutoSize = true;
            this.Medicine.Location = new System.Drawing.Point(12, 84);
            this.Medicine.Name = "Medicine";
            this.Medicine.Size = new System.Drawing.Size(62, 16);
            this.Medicine.TabIndex = 17;
            this.Medicine.Text = "Medicine";
            // 
            // lblPrescriptionId
            // 
            this.lblPrescriptionId.AutoSize = true;
            this.lblPrescriptionId.Location = new System.Drawing.Point(326, 34);
            this.lblPrescriptionId.Name = "lblPrescriptionId";
            this.lblPrescriptionId.Size = new System.Drawing.Size(92, 16);
            this.lblPrescriptionId.TabIndex = 27;
            this.lblPrescriptionId.Text = "Prescription Id";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(671, 375);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 46);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSaveFinish
            // 
            this.btnSaveFinish.Location = new System.Drawing.Point(459, 375);
            this.btnSaveFinish.Name = "btnSaveFinish";
            this.btnSaveFinish.Size = new System.Drawing.Size(92, 46);
            this.btnSaveFinish.TabIndex = 30;
            this.btnSaveFinish.Text = "Save & Finish";
            this.btnSaveFinish.UseVisualStyleBackColor = true;
            this.btnSaveFinish.Click += new System.EventHandler(this.btnSaveFinish_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(205, 375);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 46);
            this.btnRemove.TabIndex = 29;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.Location = new System.Drawing.Point(15, 375);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(92, 46);
            this.btnAddMedicine.TabIndex = 28;
            this.btnAddMedicine.Text = "Add Medicine";
            this.btnAddMedicine.UseVisualStyleBackColor = true;
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);
            // 
            // FrmPrescriptionMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveFinish);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddMedicine);
            this.Controls.Add(this.lblPrescriptionId);
            this.Controls.Add(this.numDurationDays);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.cmbMedicine);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.DurationDays);
            this.Controls.Add(this.Frequency);
            this.Controls.Add(this.Dosage);
            this.Controls.Add(this.Medicine);
            this.Controls.Add(this.dgvPrescriptionMedicine);
            this.Name = "FrmPrescriptionMedicine";
            this.Text = "FrmPrescriptionMedicine";
            this.Load += new System.EventHandler(this.FrmPrescriptionMedicine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPrescriptionMedicine;
        private System.Windows.Forms.NumericUpDown numDurationDays;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.ComboBox cmbMedicine;
        private System.Windows.Forms.Label Instructions;
        private System.Windows.Forms.Label DurationDays;
        private System.Windows.Forms.Label Frequency;
        private System.Windows.Forms.Label Dosage;
        private System.Windows.Forms.Label Medicine;
        private System.Windows.Forms.Label lblPrescriptionId;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSaveFinish;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddMedicine;
    }
}