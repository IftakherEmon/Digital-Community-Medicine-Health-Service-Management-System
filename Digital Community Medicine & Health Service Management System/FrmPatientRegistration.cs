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
    public partial class FrmPatientRegistration : Form
    {
        public FrmPatientRegistration()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string gender = comboBoxGender.Text;
            DateTime dob = dateTimePickerDOB.Value;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string bloodGroup = comboBoxBloodGroup.Text;
            string emergencyContact = textBoxEmergencyContact.Text;

            // 🔹 Validation
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill all required fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            // 🔹 INSERT + GET PatientId (FIXED COLUMN NAME)
            string insertQuery =
                "INSERT INTO Patient " +
                "(UserId, FullName, Gender, DateOfBirth, Phone, Address, BloodGroup, EmergencyContactPhone) " +
                "VALUES (@UserId, @FullName, @Gender, @DOB, @Phone, @Address, @BloodGroup, @EmergencyContactPhone); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@UserId", Session.UserId);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                command.Parameters.AddWithValue("@EmergencyContactPhone", emergencyContact);

                connection.Open();

                // 🔥 GET NEW PatientId
                int newPatientId = Convert.ToInt32(command.ExecuteScalar());

                // 🔹 SET SESSION
                Session.PatientId = newPatientId;
            }

            MessageBox.Show("Patient profile created successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // 🔹 Redirect to Patient Dashboard
            this.Hide();
            FrmPatientDashboard dashboard = new FrmPatientDashboard();
            dashboard.Show();
        }

        private void FrmPatientRegistration_Load(object sender, EventArgs e)
        {
            // Gender
            comboBoxGender.Items.Clear();
            comboBoxGender.Items.Add("Male");
            comboBoxGender.Items.Add("Female");
            comboBoxGender.Items.Add("Other");

            // Blood Group
            comboBoxBloodGroup.Items.Clear();
            comboBoxBloodGroup.Items.AddRange(new string[]
            {
        "A+","A-","B+","B-","O+","O-","AB+","AB-"
            });
        }
    }
}
