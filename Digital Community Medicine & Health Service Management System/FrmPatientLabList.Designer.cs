namespace Digital_Community_Medicine___Health_Service_Management_System
{
    partial class FrmPatientLabList
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
            this.dgvLabs = new System.Windows.Forms.DataGridView();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLabs
            // 
            this.dgvLabs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabs.Location = new System.Drawing.Point(112, 31);
            this.dgvLabs.Name = "dgvLabs";
            this.dgvLabs.RowHeadersWidth = 51;
            this.dgvLabs.RowTemplate.Height = 24;
            this.dgvLabs.Size = new System.Drawing.Size(499, 262);
            this.dgvLabs.TabIndex = 0;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(230, 364);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(75, 23);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(382, 364);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmPatientLabList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.dgvLabs);
            this.Name = "FrmPatientLabList";
            this.Text = "FrmPatientLabList";
            this.Load += new System.EventHandler(this.FrmPatientLabList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLabs;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnBack;
    }
}