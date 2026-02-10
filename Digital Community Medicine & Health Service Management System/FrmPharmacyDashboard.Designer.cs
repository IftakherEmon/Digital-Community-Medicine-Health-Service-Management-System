namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmPharmacyDashboard
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
            this.btnMedicineCategory = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnMedicine = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPrescriptionVerification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMedicineCategory
            // 
            this.btnMedicineCategory.Location = new System.Drawing.Point(40, 160);
            this.btnMedicineCategory.Name = "btnMedicineCategory";
            this.btnMedicineCategory.Size = new System.Drawing.Size(108, 68);
            this.btnMedicineCategory.TabIndex = 0;
            this.btnMedicineCategory.Text = "Manage Medicine Category";
            this.btnMedicineCategory.UseVisualStyleBackColor = true;
            this.btnMedicineCategory.Click += new System.EventHandler(this.btnMedicineCategory_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(205, 160);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(112, 68);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Pharmacy Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnMedicine
            // 
            this.btnMedicine.Location = new System.Drawing.Point(363, 160);
            this.btnMedicine.Name = "btnMedicine";
            this.btnMedicine.Size = new System.Drawing.Size(104, 68);
            this.btnMedicine.TabIndex = 2;
            this.btnMedicine.Text = "Manage Medicines";
            this.btnMedicine.UseVisualStyleBackColor = true;
            this.btnMedicine.Click += new System.EventHandler(this.btnMedicine_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(522, 160);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(101, 68);
            this.btnOrders.TabIndex = 3;
            this.btnOrders.Text = "View Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(330, 339);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 48);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPrescriptionVerification
            // 
            this.btnPrescriptionVerification.Location = new System.Drawing.Point(653, 160);
            this.btnPrescriptionVerification.Name = "btnPrescriptionVerification";
            this.btnPrescriptionVerification.Size = new System.Drawing.Size(101, 68);
            this.btnPrescriptionVerification.TabIndex = 5;
            this.btnPrescriptionVerification.Text = "Prescription Verification";
            this.btnPrescriptionVerification.UseVisualStyleBackColor = true;
            this.btnPrescriptionVerification.Click += new System.EventHandler(this.btnPrescriptionVerification_Click);
            // 
            // FrmPharmacyDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrescriptionVerification);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnMedicine);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnMedicineCategory);
            this.Name = "FrmPharmacyDashboard";
            this.Text = "FrmPharmacyDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMedicineCategory;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnMedicine;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPrescriptionVerification;
    }
}