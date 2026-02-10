namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmEmergencyRequests
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.dgvEmergency = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergency)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(242, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Emergency Requests";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(171, 355);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(260, 38);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Assign Doctor and Ambulance";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // dgvEmergency
            // 
            this.dgvEmergency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmergency.Location = new System.Drawing.Point(113, 72);
            this.dgvEmergency.Name = "dgvEmergency";
            this.dgvEmergency.RowHeadersWidth = 51;
            this.dgvEmergency.RowTemplate.Height = 24;
            this.dgvEmergency.Size = new System.Drawing.Size(526, 277);
            this.dgvEmergency.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(456, 355);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 38);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmEmergencyRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvEmergency);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmEmergencyRequests";
            this.Text = "FrmEmergencyRequests";
            this.Load += new System.EventHandler(this.FrmEmergencyRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.DataGridView dgvEmergency;
        private System.Windows.Forms.Button btnBack;
    }
}