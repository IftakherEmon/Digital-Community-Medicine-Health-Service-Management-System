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
    public partial class FrmMedicalHistory : Form
    {
        public FrmMedicalHistory()
        {
            InitializeComponent();
        }

        private void FrmMedicalHistory_Load(object sender, EventArgs e)
        {
            // Session validation
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
                "SELECT " +
                "ConditionName, " +
                "DiagnosisDate, " +
                "Notes, " +
                "CreatedAt " +
                "FROM PatientMedicalHistory " +
                "WHERE PatientId = @PatientId " +
                "ORDER BY DiagnosisDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewMedicalHistory.DataSource = dt;
                }
            }

            // Read-only grid
            dataGridViewMedicalHistory.ReadOnly = true;
            dataGridViewMedicalHistory.AllowUserToAddRows = false;
            dataGridViewMedicalHistory.AllowUserToDeleteRows = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
