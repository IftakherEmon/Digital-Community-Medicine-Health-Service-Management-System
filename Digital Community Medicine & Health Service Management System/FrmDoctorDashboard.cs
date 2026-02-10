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
    public partial class FrmDoctorDashboard : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmDoctorDashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void Logout()
        {
            Session.UserId = 0;
            Session.DoctorId = 0;
            this.Hide();
            new FrmLogin().Show();
        }

        private void FrmDoctorDashboard_Load(object sender, EventArgs e)
        {
            if (!IsDoctorApproved())
            {
                MessageBox.Show(
                    "Your profile is pending admin approval.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Logout();
                return;
            }

            LoadDoctorInfo();
            LoadDashboardStats();
        }
        private bool IsDoctorApproved()
        {
            string q = "SELECT IsApproved FROM Doctor WHERE DoctorId = @DoctorId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                object result = cmd.ExecuteScalar();
                return result != null && Convert.ToBoolean(result);
            }
        }
        private void LoadDoctorInfo()
        {
            string q =
                "SELECT FullName, Specialization " +
                "FROM Doctor WHERE DoctorId = @DoctorId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblDoctorName.Text = "Welcome, Dr. " + reader["FullName"].ToString();
                    lblSpecialization.Text = "Specialization: " + reader["Specialization"].ToString();
                }
            }
        }
        private void LoadDashboardStats()
        {
            LoadAppointmentsCount();
            LoadPatientStatistics();
            LoadRevenueSummary();
            LoadAverageRating();
        }
        private void LoadAppointmentsCount()
        {
            string q =
                @"SELECT
                    SUM(CASE WHEN CAST(aps.SlotDateTime AS DATE) = CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END) AS TodayCount,
                    SUM(CASE WHEN aps.SlotDateTime > GETDATE() THEN 1 ELSE 0 END) AS UpcomingCount
                  FROM Appointment a
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  WHERE dc.DoctorId = @DoctorId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    lblTodayAppointments.Text = r["TodayCount"].ToString();
                    lblUpcomingAppointments.Text = r["UpcomingCount"].ToString();
                }
            }
        }
        private void LoadPatientStatistics()
        {
            string q =
                @"SELECT COUNT(DISTINCT a.PatientId)
                  FROM Appointment a
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  WHERE dc.DoctorId = @DoctorId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                lblTotalPatients.Text = cmd.ExecuteScalar().ToString();
            }
        }
        private void LoadRevenueSummary()
        {
            string q =
                @"SELECT ISNULL(SUM(p.Amount),0)
                  FROM Payment p
                  JOIN Appointment a ON p.AppointmentId = a.AppointmentId
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  WHERE dc.DoctorId = @DoctorId
                  AND p.PaymentStatus = 'Completed'";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
                lblTotalRevenue.Text = "৳ " + revenue.ToString("N2");
            }
        }
        private void LoadAverageRating()
        {
            string q =
                @"SELECT AVG(CAST(Rating AS FLOAT))
                  FROM DoctorReview
                  WHERE DoctorId = @DoctorId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                con.Open();

                object result = cmd.ExecuteScalar();
                lblAvgRating.Text = result != DBNull.Value
                    ? "⭐ " + Convert.ToDouble(result).ToString("0.0") + " / 5"
                    : "⭐ N/A";
            }
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorAppointments().Show();
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorPrescriptionHistory().Show();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmNotificationLog().Show();
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please select a prescription first.",
                "Action Not Allowed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSetAvailability_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorAvailability().Show();
        }
    }
}
