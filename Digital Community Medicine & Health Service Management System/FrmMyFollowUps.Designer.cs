namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmMyFollowUps
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
            this.dataGridViewFollowUps = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFollowUps)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFollowUps
            // 
            this.dataGridViewFollowUps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFollowUps.Location = new System.Drawing.Point(72, 34);
            this.dataGridViewFollowUps.Name = "dataGridViewFollowUps";
            this.dataGridViewFollowUps.RowHeadersWidth = 51;
            this.dataGridViewFollowUps.RowTemplate.Height = 24;
            this.dataGridViewFollowUps.Size = new System.Drawing.Size(622, 304);
            this.dataGridViewFollowUps.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(344, 385);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmMyFollowUps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewFollowUps);
            this.Name = "FrmMyFollowUps";
            this.Text = "FrmMyFollowUps";
            this.Load += new System.EventHandler(this.FrmMyFollowUps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFollowUps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFollowUps;
        private System.Windows.Forms.Button btnBack;
    }
}