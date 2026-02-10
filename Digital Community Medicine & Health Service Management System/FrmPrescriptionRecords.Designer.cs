namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmPrescriptionRecords
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
            this.dataGridViewPrescriptions = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPrescriptions
            // 
            this.dataGridViewPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrescriptions.Location = new System.Drawing.Point(71, 91);
            this.dataGridViewPrescriptions.Name = "dataGridViewPrescriptions";
            this.dataGridViewPrescriptions.RowHeadersWidth = 51;
            this.dataGridViewPrescriptions.RowTemplate.Height = 24;
            this.dataGridViewPrescriptions.Size = new System.Drawing.Size(580, 252);
            this.dataGridViewPrescriptions.TabIndex = 0;
            this.dataGridViewPrescriptions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrescriptions_CellDoubleClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(323, 392);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "My Prescriptions";
            // 
            // FrmPrescriptionRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewPrescriptions);
            this.Name = "FrmPrescriptionRecords";
            this.Text = "FrmPrescriptionRecords";
            this.Load += new System.EventHandler(this.FrmPrescriptionRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPrescriptions;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
    }
}