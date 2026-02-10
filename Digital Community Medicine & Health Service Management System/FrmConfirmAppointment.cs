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
    public partial class FrmConfirmAppointment : Form
    {
        int slotId;
        int clinicId;
        int doctorId;
        public FrmConfirmAppointment(int sId, int cId, int dId)
        {
            InitializeComponent();
            slotId = sId;
            clinicId = cId;
            doctorId = dId;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1️⃣ Insert Appointment
                string insertQuery =
                    "INSERT INTO Appointment (PatientId, SlotId, Status, CreatedAt) " +
                    "VALUES (@PatientId, @SlotId, 'Confirmed', GETDATE())";

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                    insertCmd.Parameters.AddWithValue("@SlotId", slotId);

                    insertCmd.ExecuteNonQuery();
                }

                // 2️⃣ Update Slot Status
                string updateQuery =
                    "UPDATE AppointmentSlot SET Status = 'Booked' " +
                    "WHERE SlotId = @SlotId";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@SlotId", slotId);
                    updateCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Appointment Confirmed Successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Hide();
            FrmPatientDashboard dashboard = new FrmPatientDashboard();
            dashboard.Show();
        }

        private void FrmConfirmAppointment_Load(object sender, EventArgs e)
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

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT d.FullName AS DoctorName, d.Specialization, " +
                "sl.Name AS ClinicName, c.ConsultationFee, " +
                "aps.SlotDateTime, aps.DurationMinutes " +
                "FROM AppointmentSlot aps " +
                "JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId " +
                "JOIN Doctor d ON dc.DoctorId = d.DoctorId " +
                "JOIN Clinic c ON dc.ClinicId = c.ClinicId " +
                "JOIN ServiceLocation sl ON c.LocationId = sl.LocationId " +
                "WHERE aps.SlotId = @SlotId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SlotId", slotId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DateTime start = Convert.ToDateTime(reader["SlotDateTime"]);
                    int duration = Convert.ToInt32(reader["DurationMinutes"]);
                    DateTime end = start.AddMinutes(duration);

                    lblDoctor.Text =
                        reader["DoctorName"].ToString() +
                        " (" + reader["Specialization"].ToString() + ")";

                    lblClinic.Text = reader["ClinicName"].ToString();
                    lblFee.Text = reader["ConsultationFee"].ToString() + " BDT";
                    lblDate.Text = start.ToString("dd-MMM-yyyy");
                    lblTime.Text = start.ToString("hh:mm tt") + " - " + end.ToString("hh:mm tt");
                }

                reader.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmSelectSlot slotForm =
                new FrmSelectSlot(clinicId, doctorId);

            slotForm.Show();
        }
    }
}
