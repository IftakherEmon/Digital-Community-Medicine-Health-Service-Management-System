namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmClinicDetails
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
            this.lblClinicName = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFee = new System.Windows.Forms.Label();
            this.buttonBook = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClinicName
            // 
            this.lblClinicName.AutoSize = true;
            this.lblClinicName.Location = new System.Drawing.Point(167, 47);
            this.lblClinicName.Name = "lblClinicName";
            this.lblClinicName.Size = new System.Drawing.Size(79, 16);
            this.lblClinicName.TabIndex = 0;
            this.lblClinicName.Text = "Clinic Name";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(431, 47);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(36, 16);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Area";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(167, 153);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 16);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Location = new System.Drawing.Point(423, 164);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(31, 16);
            this.lblFee.TabIndex = 3;
            this.lblFee.Text = "Fee";
            // 
            // buttonBook
            // 
            this.buttonBook.Location = new System.Drawing.Point(281, 263);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(116, 54);
            this.buttonBook.TabIndex = 4;
            this.buttonBook.Text = "Book";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(619, 370);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmClinicDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblClinicName);
            this.Name = "FrmClinicDetails";
            this.Text = "FrmClinicDetails";
            this.Load += new System.EventHandler(this.FrmClinicDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClinicName;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Button buttonBook;
        private System.Windows.Forms.Button btnBack;
    }
}