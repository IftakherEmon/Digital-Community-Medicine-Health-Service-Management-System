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
    public partial class FrmDoctorSearch : Form
    {
        string connectionString =
        "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmDoctorSearch()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxArea.SelectedIndex == 0 ||
                comboBoxSpecialization.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Area and Specialization",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT DISTINCT
                    d.DoctorId,
                    d.FullName        AS DoctorName,
                    d.Specialization,
                    sl.Area,
                    sl.Address,
                    c.ConsultationFee,
                    c.ClinicId
                FROM Doctor d
                JOIN DoctorClinic dc ON d.DoctorId = dc.DoctorId
                JOIN Clinic c ON dc.ClinicId = c.ClinicId
                JOIN ServiceLocation sl ON c.LocationId = sl.LocationId
                WHERE d.IsApproved = 1
                  AND sl.Area = @Area
                  AND d.Specialization = @Specialization
                ORDER BY d.FullName;
            ";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Area", comboBoxArea.Text);
                cmd.Parameters.AddWithValue("@Specialization", comboBoxSpecialization.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewDoctors.DataSource = dt;
            }

            dataGridViewDoctors.Columns["DoctorId"].Visible = false;
            dataGridViewDoctors.Columns["ClinicId"].Visible = false;
            dataGridViewDoctors.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int clinicId = Convert.ToInt32(
                dataGridViewDoctors.Rows[e.RowIndex].Cells["ClinicId"].Value);

            int doctorId = Convert.ToInt32(
                dataGridViewDoctors.Rows[e.RowIndex].Cells["DoctorId"].Value);

            this.Hide();
            new FrmClinicDetails(clinicId, doctorId).Show();
        }

        private void FrmDoctorSearch_Load(object sender, EventArgs e)
        {
            LoadAreas();
            LoadSpecializations();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
        private void LoadAreas()
        {
            comboBoxArea.Items.Clear();
            comboBoxArea.Items.Add("-- Select Area --");

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT Area FROM ServiceLocation ORDER BY Area", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxArea.Items.Add(dr["Area"].ToString());
                }
            }

            comboBoxArea.SelectedIndex = 0;
        }
        private void LoadSpecializations()
        {
            comboBoxSpecialization.Items.Clear();
            comboBoxSpecialization.Items.Add("-- Select Specialization --");

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT Specialization FROM Doctor WHERE IsApproved = 1 ORDER BY Specialization", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxSpecialization.Items.Add(dr["Specialization"].ToString());
                }
            }

            comboBoxSpecialization.SelectedIndex = 0;
        }
    }
}
