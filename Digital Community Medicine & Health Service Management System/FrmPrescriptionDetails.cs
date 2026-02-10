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
    public partial class FrmPrescriptionDetails : Form
    {
        int prescriptionId;
        public FrmPrescriptionDetails(int pId)
        {
            InitializeComponent();
            prescriptionId = pId;
        }

        private void FrmPrescriptionDetails_Load(object sender, EventArgs e)
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

            LoadPrescriptionHeader();
            LoadMedicineList();
        }
        private void LoadPrescriptionHeader()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT d.FullName AS DoctorName, " +
                "p.Diagnosis, p.CreatedAt " +
                "FROM Prescription p " +
                "JOIN Doctor d ON p.DoctorId = d.DoctorId " +
                "JOIN Appointment a ON p.AppointmentId = a.AppointmentId " +
                "WHERE p.PrescriptionId = @PrescriptionId " +
                "AND a.PatientId = @PatientId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PrescriptionId", prescriptionId);
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblDoctorName.Text = reader["DoctorName"].ToString();
                    lblDiagnosis.Text = reader["Diagnosis"].ToString();

                    DateTime date =
                        Convert.ToDateTime(reader["CreatedAt"]);
                    lblDate.Text = date.ToString("dd-MMM-yyyy");
                }

                reader.Close();
            }
        }
        private void LoadMedicineList()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT " +
                "MedicineName, " +
                "Dosage, " +
                "Duration, " +
                "Instructions " +
                "FROM PrescriptionMedicine " +
                "WHERE PrescriptionId = @PrescriptionId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PrescriptionId", prescriptionId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewMedicines.DataSource = dt;
            }

            dataGridViewMedicines.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPrescriptionRecords().Show();
        }
    }
}
