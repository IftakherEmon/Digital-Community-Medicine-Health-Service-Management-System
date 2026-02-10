using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmPharmacistRegistration : Form
    {
        public FrmPharmacistRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Prevent duplicate pharmacist
                string checkQ = "SELECT COUNT(*) FROM Pharmacist WHERE UserId=@UserId";
                using (SqlCommand checkCmd = new SqlCommand(checkQ, con))
                {
                    checkCmd.Parameters.AddWithValue("@UserId", Session.UserId);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Pharmacist profile already exists.");
                        return;
                    }
                }

                // Insert pharmacist
                string insertQ =
                    "INSERT INTO Pharmacist (UserId, FullName, LicenseNumber) " +
                    "VALUES (@UserId, @FullName, @LicenseNumber); " +
                    "SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertQ, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text.Trim());

                    Session.PharmacistId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            MessageBox.Show("Pharmacist registration completed.\nPlease register your pharmacy.");

            this.Hide();
            new FrmPharmacyRegistration().Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtLicenseNumber.Clear();

            txtFullName.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Cancel pharmacist registration and logout?",
"Confirm",
MessageBoxButtons.YesNo,
MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear session
                Session.UserId = 0;
                Session.Role = null;
                Session.PharmacistId = 0;

                this.Hide();
                new FrmLogin().Show();
            }
        }
    }
}
