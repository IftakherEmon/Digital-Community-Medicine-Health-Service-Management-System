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
    public partial class FrmMyFollowUps : Form
    {
        string connectionString =
           "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmMyFollowUps()
        {
            InitializeComponent();
        }

        private void FrmMyFollowUps_Load(object sender, EventArgs e)
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

            LoadFollowUps();
        }
        private void LoadFollowUps()
        {
            string query =
                @"SELECT 
            fur.ReminderDate,
            fur.ReminderType,
            fur.Message,
            fur.Status,
            d.FullName AS DoctorName
          FROM FollowUpReminder fur
          JOIN Prescription pr ON fur.PrescriptionId = pr.PrescriptionId
          JOIN Appointment a ON pr.AppointmentId = a.AppointmentId
          JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
          JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
          JOIN Doctor d ON dc.DoctorId = d.DoctorId
          WHERE fur.PatientId = @PatientId
          ORDER BY fur.ReminderDate ASC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewFollowUps.DataSource = dt;
            }

            dataGridViewFollowUps.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
