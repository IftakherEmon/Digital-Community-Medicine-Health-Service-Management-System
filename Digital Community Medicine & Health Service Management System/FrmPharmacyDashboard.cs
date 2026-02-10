using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmPharmacyDashboard : Form
    {
        public FrmPharmacyDashboard()
        {
            InitializeComponent();
        }

        private void btnMedicineCategory_Click(object sender, EventArgs e)
        {
            new FrmMedicineCategory().Show();
            this.Hide();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            new FrmPharmacyInventory().Show();
            this.Hide();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            new FrmMedicine().Show();
            this.Hide();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            new FrmMedicineOrders().Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Are you sure you want to logout?",
    "Logout",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Session.UserId = 0;
                Session.PharmacistId = 0;
                Session.Role = null;

                new FrmLogin().Show();
                this.Hide();
            }
        }

        private void btnPrescriptionVerification_Click(object sender, EventArgs e)
        {
            new FrmPendingPrescriptionOrders().Show();
            this.Hide();
        }
    }
}
