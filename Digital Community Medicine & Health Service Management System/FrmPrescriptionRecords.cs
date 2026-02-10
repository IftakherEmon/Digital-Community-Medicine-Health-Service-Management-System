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
    public partial class FrmPrescriptionRecords : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmPrescriptionRecords()
        {
            InitializeComponent();
        }

        private void FrmPrescriptionRecords_Load(object sender, EventArgs e)
        {
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadPrescriptions();
        }
        private void LoadPrescriptions()
        {
            string query =
                @"SELECT
                    p.PrescriptionId,
                    d.FullName AS DoctorName,
                    p.CreatedAt AS PrescriptionDate,
                    p.Diagnosis
                  FROM Prescription p
                  JOIN Appointment a ON p.AppointmentId = a.AppointmentId
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  JOIN Doctor d ON dc.DoctorId = d.DoctorId
                  WHERE a.PatientId = @PatientId
                  ORDER BY p.CreatedAt DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPrescriptions.DataSource = dt;
            }

            dataGridViewPrescriptions.Columns["PrescriptionId"].Visible = false;
            dataGridViewPrescriptions.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewPrescriptions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int prescriptionId =
                    Convert.ToInt32(
                        dataGridViewPrescriptions.Rows[e.RowIndex]
                        .Cells["PrescriptionId"].Value);

                this.Hide();
                new FrmPrescriptionDetails(prescriptionId).Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
