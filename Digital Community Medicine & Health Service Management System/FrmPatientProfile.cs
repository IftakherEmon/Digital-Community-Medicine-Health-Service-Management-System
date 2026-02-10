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
    public partial class FrmPatientProfile : Form
    {
        public FrmPatientProfile()
        {
            InitializeComponent();
        }
        private void LoadComboBoxes()
        {
            // Gender ComboBox
            comboGender.Items.Clear();
            comboGender.Items.Add("Male");
            comboGender.Items.Add("Female");
            comboGender.Items.Add("Other");

            // Blood Group ComboBox
            comboBloodGroup.Items.Clear();
            comboBloodGroup.Items.AddRange(new string[]
            {
        "A+","A-","B+","B-","O+","O-","AB+","AB-"
            });
        }

        private void FrmPatientProfile_Load(object sender, EventArgs e)
        {
            // Load ComboBoxes FIRST
            LoadComboBoxes();

            // Session check
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT FullName, Gender, DateOfBirth, Phone, Address, BloodGroup, EmergencyContactPhone " +
                "FROM Patient WHERE PatientId = @PatientId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFullName.Text = dr["FullName"].ToString();
                    comboGender.Text = dr["Gender"].ToString();
                    dtpDOB.Value = Convert.ToDateTime(dr["DateOfBirth"]);
                    txtPhone.Text = dr["Phone"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    comboBloodGroup.Text = dr["BloodGroup"].ToString();
                    txtEmergency.Text = dr["EmergencyContactPhone"].ToString();
                }
                dr.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "UPDATE Patient SET " +
                "FullName=@FullName, Gender=@Gender, DateOfBirth=@DOB, Phone=@Phone, " +
                "Address=@Address, BloodGroup=@BloodGroup, EmergencyContactPhone=@Emergency " +
                "WHERE PatientId=@PatientId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Gender", comboGender.Text);
                cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@BloodGroup", comboBloodGroup.Text);
                cmd.Parameters.AddWithValue("@Emergency", txtEmergency.Text);
                cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Profile updated successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Are you sure you want to delete your account?",
    "Confirm Delete",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Deactivate User
                string q1 = "UPDATE Users SET IsActive = 0 WHERE UserId = @UserId";
                using (SqlCommand cmd1 = new SqlCommand(q1, con))
                {
                    cmd1.Parameters.AddWithValue("@UserId", Session.UserId);
                    cmd1.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Account deactivated successfully.");

            // Clear session
            Session.UserId = 0;
            Session.PatientId = 0;
            Session.Role = null;

            this.Hide();
            new FrmLogin().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
