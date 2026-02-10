using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;



namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmPendingDoctors : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmPendingDoctors()
        {
            InitializeComponent();

        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmPendingDoctors_Load(object sender, EventArgs e)
        {
            LoadPendingDoctors();
        }
        private void LoadPendingDoctors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DoctorId, FullName, Specialization, RegistrationNumber FROM Doctor WHERE IsApproved = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDoctors.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard ad = new FrmAdminDashboard();
            ad.Show();
            this.Hide();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count > 0)
            {
                int doctorId = Convert.ToInt32(dgvDoctors.SelectedRows[0].Cells["DoctorId"].Value);

                FrmDoctorDetails details = new FrmDoctorDetails(doctorId);
                details.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a doctor first.");
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count > 0)
            {
                int doctorId = Convert.ToInt32(dgvDoctors.SelectedRows[0].Cells["DoctorId"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Doctor SET IsApproved = 1, ApprovalDate = GETDATE() WHERE DoctorId = @DoctorId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Doctor approved successfully!");

                LoadPendingDoctors(); // refresh
            }
            else
            {
                MessageBox.Show("Please select a doctor first.");
            }
        }
    }
}
