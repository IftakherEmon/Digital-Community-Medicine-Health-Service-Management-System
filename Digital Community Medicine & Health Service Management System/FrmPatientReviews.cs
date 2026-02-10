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
    public partial class FrmPatientReviews : Form
    {
        public FrmPatientReviews()
        {
            InitializeComponent();
        }

        private void FrmPatientReviews_Load(object sender, EventArgs e)
        {
            // 🔐 Session check
            if (Session.UserId <= 0 || Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadReviews();
        }
        private void LoadReviews()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            // ⭐ OPTION–2: Only VERIFIED reviews
            string query =
                "SELECT " +
                "d.FullName AS DoctorName, " +
                "dr.Rating, " +
                "dr.Comment, " +
                "dr.CreatedAt AS ReviewDate " +
                "FROM DoctorReview dr " +
                "JOIN Doctor d ON dr.DoctorId = d.DoctorId " +
                "WHERE dr.PatientId = @PatientId " +
                "AND dr.IsVerified = 1 " +
                "ORDER BY dr.CreatedAt DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewReviews.DataSource = dt;
            }

            // UI polish
            dataGridViewReviews.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewReviews.ReadOnly = true;
            dataGridViewReviews.AllowUserToAddRows = false;
            dataGridViewReviews.AllowUserToDeleteRows = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
