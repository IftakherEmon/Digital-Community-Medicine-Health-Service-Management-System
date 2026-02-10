namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmMedicalHistory
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
            this.dataGridViewMedicalHistory = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicalHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMedicalHistory
            // 
            this.dataGridViewMedicalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMedicalHistory.Location = new System.Drawing.Point(98, 56);
            this.dataGridViewMedicalHistory.Name = "dataGridViewMedicalHistory";
            this.dataGridViewMedicalHistory.RowHeadersWidth = 51;
            this.dataGridViewMedicalHistory.RowTemplate.Height = 24;
            this.dataGridViewMedicalHistory.Size = new System.Drawing.Size(522, 296);
            this.dataGridViewMedicalHistory.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(303, 380);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 34);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmMedicalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewMedicalHistory);
            this.Name = "FrmMedicalHistory";
            this.Text = "FrmMedicalHistory";
            this.Load += new System.EventHandler(this.FrmMedicalHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicalHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMedicalHistory;
        private System.Windows.Forms.Button btnBack;
    }
}