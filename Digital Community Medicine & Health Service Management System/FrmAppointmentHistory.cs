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
    public partial class FrmAppointmentHistory : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmAppointmentHistory()
        {
            InitializeComponent();
        }

        private void FrmAppointmentHistory_Load(object sender, EventArgs e)
        {
            // 🔐 Session check
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

            LoadAppointmentHistory();
        }
        private void LoadAppointmentHistory()
        {
            string query =
                @"SELECT
            a.AppointmentId,
            d.FullName AS DoctorName,
            sl.Name AS ClinicName,
            aps.SlotDateTime,
            a.Status
          FROM Appointment a
          JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
          JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
          JOIN Doctor d ON dc.DoctorId = d.DoctorId
          JOIN Clinic c ON dc.ClinicId = c.ClinicId
          JOIN ServiceLocation sl ON c.LocationId = sl.LocationId
          WHERE a.PatientId = @PatientId
          ORDER BY aps.SlotDateTime DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewAppointments.DataSource = dt;
            }

            // UI polish
            dataGridViewAppointments.Columns["AppointmentId"].Visible = false;
            dataGridViewAppointments.Columns["SlotDateTime"].HeaderText = "Date & Time";
            dataGridViewAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
