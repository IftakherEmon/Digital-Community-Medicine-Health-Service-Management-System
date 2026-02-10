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
    public partial class FrmCreatePrescription : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        private int appointmentId;
        public FrmCreatePrescription(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
        }

        private void FrmCreatePrescription_Load(object sender, EventArgs e)
        {
            lblAppointmentId.Text = "Appointment ID: " + appointmentId;
            dtpNextVisitDate.Checked = false; // optional
        }

        private void btnSavePrescription_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtxtSymptoms.Text) ||
    string.IsNullOrWhiteSpace(rtxtDiagnosis.Text))
            {
                MessageBox.Show("Symptoms and Diagnosis are required.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // -----------------------------
            // DUPLICATE CHECK
            // -----------------------------
            if (PrescriptionExists())
            {
                MessageBox.Show("Prescription already exists for this appointment.",
                                "Duplicate",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // -----------------------------
            // INSERT PRESCRIPTION
            // -----------------------------
            string query =
                @"INSERT INTO Prescription
                  (AppointmentId, Diagnosis, Symptoms, MedicalAdvice, NextVisitDate)
                  VALUES
                  (@AppointmentId, @Diagnosis, @Symptoms, @Advice, @NextVisitDate);
                  SELECT SCOPE_IDENTITY();";

            int prescriptionId;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                cmd.Parameters.AddWithValue("@Diagnosis", rtxtDiagnosis.Text.Trim());
                cmd.Parameters.AddWithValue("@Symptoms", rtxtSymptoms.Text.Trim());
                cmd.Parameters.AddWithValue("@Advice", rtxtAdvice.Text.Trim());

                if (dtpNextVisitDate.Checked)
                    cmd.Parameters.AddWithValue("@NextVisitDate", dtpNextVisitDate.Value.Date);
                else
                    cmd.Parameters.AddWithValue("@NextVisitDate", DBNull.Value);

                con.Open();
                prescriptionId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            MessageBox.Show("Prescription saved successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // -----------------------------
            // GO TO MEDICINE FORM
            // -----------------------------
            this.Hide();
            new FrmPrescriptionMedicine(prescriptionId).Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorAppointments().Show();
        }
        private bool PrescriptionExists()
        {
            string q =
                "SELECT COUNT(*) FROM Prescription WHERE AppointmentId = @AppointmentId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
