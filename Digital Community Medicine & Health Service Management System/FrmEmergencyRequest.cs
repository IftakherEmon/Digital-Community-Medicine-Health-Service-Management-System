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
    public partial class FrmEmergencyRequest : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmEmergencyRequest()
        {
            InitializeComponent();
        }

        private void FrmEmergencyRequest_Load(object sender, EventArgs e)
        {
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

            LoadEmergencyTypes();
        }
        private void LoadEmergencyTypes()
        {
            cmbEmergencyType.Items.Clear();
            cmbEmergencyType.Items.Add("Accident");
            cmbEmergencyType.Items.Add("Heart Problem");
            cmbEmergencyType.Items.Add("Breathing Issue");
            cmbEmergencyType.Items.Add("Stroke");
            cmbEmergencyType.Items.Add("Pregnancy Emergency");
            cmbEmergencyType.Items.Add("Burn Injury");
            cmbEmergencyType.Items.Add("Other");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbEmergencyType.Text) ||
                string.IsNullOrWhiteSpace(txtSymptoms.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill all required fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    @"INSERT INTO EmergencyRequest
                      (PatientId, EmergencyType, Symptoms, Address, Status)
                      VALUES
                      (@PatientId, @EmergencyType, @Symptoms, @Address, 'Pending')";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                    cmd.Parameters.AddWithValue("@EmergencyType", cmbEmergencyType.Text);
                    cmd.Parameters.AddWithValue("@Symptoms", txtSymptoms.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Emergency request sent successfully.\nPlease wait for assistance.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Hide();
            new FrmPatientDashboard().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
