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
    public partial class FrmAddReview : Form
    {
        int appointmentId;
        int doctorId;
        public FrmAddReview(int aId, int dId)
        {
            InitializeComponent();
            appointmentId = aId;
            doctorId = dId;
        }

        private void FrmAddReview_Load(object sender, EventArgs e)
        {
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                this.Hide();
                new FrmLogin().Show();
                return;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int rating = (int)numericUpDownRating.Value;
            string comment = txtComment.Text.Trim();

            if (rating < 1 || rating > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5.");
                return;
            }

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 🔒 Prevent duplicate review
                string checkQuery =
                    "SELECT COUNT(*) FROM DoctorReview WHERE AppointmentId = @AppointmentId";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("You already reviewed this appointment.");
                        return;
                    }
                }

                // ✅ Insert review
                string insertQuery =
                    "INSERT INTO DoctorReview " +
                    "(DoctorId, PatientId, AppointmentId, Rating, Comment, IsVerified) " +
                    "VALUES (@DoctorId, @PatientId, @AppointmentId, @Rating, @Comment, 0)";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    insertCmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                    insertCmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    insertCmd.Parameters.AddWithValue("@Rating", rating);
                    insertCmd.Parameters.AddWithValue("@Comment", comment);

                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Review submitted successfully! Pending admin verification.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Hide();
            new FrmPatientDashboard().Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMyAppointments().Show();

        }
    }
}
