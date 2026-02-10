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
    public partial class FrmSignup : Form
    {
        public FrmSignup()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string role = comboBoxRole.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                comboBoxRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check existing email
                string checkQuery =
                    "SELECT COUNT(*) FROM Users WHERE Email = @Email AND IsActive = 1;";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Email already exists.",
                                        "Signup Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insert new user + get UserId
                string insertQuery =
    "INSERT INTO Users (Email, PasswordHash, Role, IsActive) " +
    "VALUES (@Email, @Password, @Role, 1); " +
    "SELECT SCOPE_IDENTITY();";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Password", password);
                    insertCmd.Parameters.AddWithValue("@Role", role);

                    int newUserId = Convert.ToInt32(insertCmd.ExecuteScalar());

                    // 🔥 SET SESSION
                    Session.UserId = newUserId;
                    Session.Role = role;
                }
            }

            MessageBox.Show("Registration successful!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Hide();

            // Role based redirect
            if (role == "Patient")
            {
                new FrmPatientRegistration().Show();
            }
            else if (role == "Doctor")
            {
                new FrmDoctorRegistration().Show();
            }
            else if (role == "Pharmacist")
            {
                new FrmPharmacistRegistration().Show();
            }
            else if (role == "Admin")
            {
                new FrmAdminDashboard().Show();
            }
        }

        private void FrmSignup_Load(object sender, EventArgs e)
        {
            comboBoxRole.Items.Clear();

            comboBoxRole.Items.Add("Patient");
            comboBoxRole.Items.Add("Doctor");
            comboBoxRole.Items.Add("Pharmacist");
            comboBoxRole.Items.Add("Admin");

            comboBoxRole.SelectedIndex = 0;
        }
    }
}
