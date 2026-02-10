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
    public partial class FrmPharmacyRegistration : Form
    {
        public FrmPharmacyRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPharmacyName.Text) ||
            string.IsNullOrWhiteSpace(txtLicenseNumber.Text) ||
            string.IsNullOrWhiteSpace(txtPhone.Text) ||
             string.IsNullOrWhiteSpace(txtAddress.Text) ||
             cmbArea.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (Session.PharmacistId <= 0)
            {
                MessageBox.Show("Invalid session. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    // ===============================
                    // 2️⃣ INSERT INTO ServiceLocation
                    // ===============================
                    string insertLocationQ =
                        @"INSERT INTO ServiceLocation
                  (Name, ServiceType, Address, Area, City, Phone, OpeningHours, IsVerified)
                  VALUES
                  (@Name, 'Pharmacy', @Address, @Area, @City, @Phone, @OpeningHours, 0);
                  SELECT SCOPE_IDENTITY();";

                    int locationId;
                    using (SqlCommand cmd = new SqlCommand(insertLocationQ, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtPharmacyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Area", cmbArea.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@OpeningHours", txtOpeningHours.Text.Trim());

                        locationId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // ===============================
                    // 3️⃣ INSERT INTO Pharmacy
                    // ===============================
                    string insertPharmacyQ =
                        @"INSERT INTO Pharmacy
                  (LocationId, PharmacyName, LicenseNumber, OwnerName, IsActive)
                  VALUES
                  (@LocationId, @PharmacyName, @LicenseNumber, @OwnerName, 1);
                  SELECT SCOPE_IDENTITY();";

                    int pharmacyId;
                    using (SqlCommand cmd = new SqlCommand(insertPharmacyQ, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@LocationId", locationId);
                        cmd.Parameters.AddWithValue("@PharmacyName", txtPharmacyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text.Trim());

                        pharmacyId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // ==========================================
                    // 4️⃣ UPDATE Pharmacist → SET PharmacyId
                    // ==========================================
                    string updatePharmacistQ =
                        "UPDATE Pharmacist SET PharmacyId=@PharmacyId WHERE PharmacistId=@PharmacistId";

                    using (SqlCommand cmd = new SqlCommand(updatePharmacistQ, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@PharmacyId", pharmacyId);
                        cmd.Parameters.AddWithValue("@PharmacistId", Session.PharmacistId);
                        cmd.ExecuteNonQuery();
                    }

                    // 5️⃣ COMMIT
                    tran.Commit();

                    MessageBox.Show("Pharmacy registered successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.Hide();
                    new FrmPharmacyDashboard().Show();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error occurred:\n" + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPharmacyName.Clear();
            txtLicenseNumber.Clear();
            txtOwnerName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtOpeningHours.Clear();
            cmbArea.SelectedIndex = -1;

            txtPharmacyName.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Cancel pharmacy registration and logout?",
            "Confirm",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Session.UserId = 0;
                Session.PharmacistId = 0;
                Session.Role = null;

                this.Hide();
                new FrmLogin().Show();
            }
        }

        private void FrmPharmacyRegistration_Load(object sender, EventArgs e)
        {
            LoadAreas();
        }
        private void LoadAreas()
        {
            cmbArea.Items.Clear();

            cmbArea.Items.AddRange(new string[]
            {
        // Dhaka Division
        "Dhaka", "Gazipur", "Narayanganj", "Narsingdi", "Tangail",
        "Kishoreganj", "Manikganj", "Munshiganj", "Faridpur",
        "Gopalganj", "Madaripur", "Rajbari", "Shariatpur",

        // Chattogram Division
        "Chattogram", "Cox's Bazar", "Cumilla", "Feni", "Noakhali",
        "Lakshmipur", "Brahmanbaria", "Chandpur", "Rangamati",
        "Khagrachari", "Bandarban",

        // Rajshahi Division
        "Rajshahi", "Bogura", "Joypurhat", "Naogaon", "Natore",
        "Chapainawabganj", "Pabna", "Sirajganj",

        // Khulna Division
        "Khulna", "Bagerhat", "Chuadanga", "Jashore", "Jhenaidah",
        "Kushtia", "Magura", "Meherpur", "Narail", "Satkhira",

        // Barishal Division
        "Barishal", "Bhola", "Jhalokathi", "Patuakhali",
        "Pirojpur", "Barguna",

        // Sylhet Division
        "Sylhet", "Habiganj", "Moulvibazar", "Sunamganj",

        // Rangpur Division
        "Rangpur", "Dinajpur", "Gaibandha", "Kurigram",
        "Lalmonirhat", "Nilphamari", "Panchagarh", "Thakurgaon",

        // Mymensingh Division
        "Mymensingh", "Jamalpur", "Netrokona", "Sherpur"
            });

            cmbArea.SelectedIndex = -1; // No default select
        }

    }
}
