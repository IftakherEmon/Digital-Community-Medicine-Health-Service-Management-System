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
    public partial class FrmDoctorDetails : Form
    {
        int doctorId;
        public FrmDoctorDetails(int docId)
        {
            InitializeComponent();
            doctorId = docId;
        }
        private void FrmDoctorDetails_Load(object sender, EventArgs e)
        {
            string connectionString =
           "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1️⃣ Load Doctor Info
                string doctorQuery =
                    "SELECT FullName, Specialization " +
                    "FROM Doctor WHERE DoctorId = @DoctorId";

                using (SqlCommand docCmd =
                    new SqlCommand(doctorQuery, connection))
                {
                    docCmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    SqlDataReader reader = docCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblDoctorName.Text = reader["FullName"].ToString();
                        lblSpecialization.Text = reader["Specialization"].ToString();
                    }
                    reader.Close();
                }

                // 2️⃣ Load Clinics List
                string clinicQuery =
                    "SELECT c.ClinicId, c.ClinicName, sl.Area, c.ConsultationFee " +
                    "FROM DoctorClinic dc " +
                    "JOIN Clinic c ON dc.ClinicId = c.ClinicId " +
                    "JOIN ServiceLocation sl ON c.LocationId = sl.LocationId " +
                    "WHERE dc.DoctorId = @DoctorId";

                using (SqlCommand clinicCmd =
                    new SqlCommand(clinicQuery, connection))
                {
                    clinicCmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    SqlDataAdapter adapter = new SqlDataAdapter(clinicCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewClinics.DataSource = dt;
                }
            }

            // Hide ClinicId column
            dataGridViewClinics.Columns["ClinicId"].Visible = false;
        }

        private void dataGridViewClinics_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int clinicId = Convert.ToInt32(
                    dataGridViewClinics.Rows[e.RowIndex]
                    .Cells["ClinicId"].Value);

                // doctorId এই form-এর field (constructor থেকে এসেছে)
                this.Hide();

                FrmClinicDetails clinicDetails =
                    new FrmClinicDetails(clinicId, doctorId);

                clinicDetails.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorSearch().Show();
        }
    }
}
