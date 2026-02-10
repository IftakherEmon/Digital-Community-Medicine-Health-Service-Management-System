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
using static System.Collections.Specialized.BitVector32;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSignup signup = new FrmSignup();
            signup.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter Email and Password.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                @"SELECT UserId, Role
                  FROM Users
                  WHERE Email = @Email
                    AND PasswordHash = @Password
                    AND IsActive = 1";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Invalid Email or Password.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                int userId = Convert.ToInt32(reader["UserId"]);
                string role = reader["Role"].ToString();

                // 🔐 SET SESSION
                Session.UserId = userId;
                Session.Role = role;
                MessageBox.Show("Login successful!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information); 

                reader.Close();
                this.Hide();

                // ===============================
                // 🔑 ROLE BASED ACCESS CONTROL
                // ===============================

                switch (role)
                {
                    case "Patient":
                        if (IsPatientProfileCompleted(userId))
                        {
                            Session.PatientId = GetPatientId(userId);
                            new FrmPatientDashboard().Show();
                        }
                        else
                        {
                            MessageBox.Show("Please complete patient registration first.");
                            new FrmPatientRegistration().Show();
                        }
                        break;

                    case "Doctor":
                        if (IsDoctorProfileCompleted(userId))
                        {
                            Session.DoctorId = GetDoctorId(userId);
                            new FrmDoctorDashboard().Show();
                        }
                        else
                        {
                            MessageBox.Show("Please complete doctor registration first.");
                            new FrmDoctorRegistration().Show();
                        }
                        break;

                    case "Pharmacist":

                        // 🔹 Step 1: Pharmacist profile check
                        if (!IsPharmacistProfileCompleted(userId))
                        {
                            MessageBox.Show("Please complete pharmacist registration first.");
                            new FrmPharmacistRegistration().Show();
                            break;
                        }

                        // 🔹 Step 2: Set PharmacistId
                        Session.PharmacistId = GetPharmacistId(userId);

                        // 🔹 Step 3: Pharmacy registration check
                        if (!IsPharmacyRegistered(Session.PharmacistId))
                        {
                            MessageBox.Show("Please complete pharmacy registration first.");
                            new FrmPharmacyRegistration().Show();
                        }
                        else
                        {
                            new FrmPharmacyDashboard().Show();
                        }
                        break;

                    case "Admin":

                        Session.AdminId = GetAdminId(userId);

                        MessageBox.Show(
                            "LOGIN UserId = " + userId +
                            "\nAdminId = " + Session.AdminId
                        );

                        new FrmAdminDashboard().Show();
                        break;

                    default:
                        MessageBox.Show("Invalid user role.");
                        break;
                }
            }
        }
        private bool IsPatientProfileCompleted(int userId)
        {
            return Exists("SELECT COUNT(*) FROM Patient WHERE UserId=@UserId", userId);
        }

        private bool IsDoctorProfileCompleted(int userId)
        {
            return Exists("SELECT COUNT(*) FROM Doctor WHERE UserId=@UserId", userId);
        }

        private bool IsPharmacistProfileCompleted(int userId)
        {
            return Exists("SELECT COUNT(*) FROM Pharmacist WHERE UserId=@UserId", userId);
        }
        private bool Exists(string query, int userId)
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        private bool IsPharmacyRegistered(int pharmacistId)
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string q =
                @"SELECT COUNT(*)
                  FROM Pharmacist
                  WHERE PharmacistId = @PharmacistId
                    AND PharmacyId IS NOT NULL";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@PharmacistId", pharmacistId);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        // ===============================
        // 🔍 GET ROLE SPECIFIC IDs
        // ===============================

        private int GetPatientId(int userId)
        {
            return GetId("SELECT PatientId FROM Patient WHERE UserId=@UserId", userId);
        }

        private int GetDoctorId(int userId)
        {
            return GetId("SELECT DoctorId FROM Doctor WHERE UserId=@UserId", userId);
        }
        private int GetAdminId(int userId)
        {
            return GetId("SELECT AdminId FROM Admin WHERE UserId=@UserId", userId);
        }

        private int GetPharmacistId(int userId)
        {
            return GetId("SELECT PharmacistId FROM Pharmacist WHERE UserId=@UserId", userId);
        }
        private int GetId(string query, int userId)
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}

