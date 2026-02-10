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
    public partial class FrmManageClinic : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        int selectedClinicId = 0;
        int selectedLocationId = 0;
        public FrmManageClinic()
        {
            InitializeComponent();
        }

        private void FrmManageClinic_Load(object sender, EventArgs e)
        {
            LoadClinics();
        }
        private void LoadClinics()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT 
                    c.ClinicId,
                    sl.LocationId,
                    sl.Area,
                    sl.Address,
                    c.ConsultationFee,
                    c.IsActive
                  FROM Clinic c
                  JOIN ServiceLocation sl ON c.LocationId = sl.LocationId", con))
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dgvClinic.DataSource = dt;
            }

            dgvClinic.Columns["ClinicId"].Visible = false;
            dgvClinic.Columns["LocationId"].Visible = false;
            dgvClinic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvClinic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedClinicId =
                Convert.ToInt32(dgvClinic.Rows[e.RowIndex].Cells["ClinicId"].Value);

            selectedLocationId =
                Convert.ToInt32(dgvClinic.Rows[e.RowIndex].Cells["LocationId"].Value);

            txtArea.Text =
                dgvClinic.Rows[e.RowIndex].Cells["Area"].Value.ToString();

            txtAddress.Text =
                dgvClinic.Rows[e.RowIndex].Cells["Address"].Value.ToString();

            txtFee.Text =
                dgvClinic.Rows[e.RowIndex].Cells["ConsultationFee"].Value.ToString();

            chkIsActive.Checked =
                Convert.ToBoolean(dgvClinic.Rows[e.RowIndex].Cells["IsActive"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedClinicId == 0 || selectedLocationId == 0)
            {
                MessageBox.Show("Please select a clinic first.");
                return;
            }

            if (!decimal.TryParse(txtFee.Text, out decimal fee))
            {
                MessageBox.Show("Invalid consultation fee.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 🔹 Update ServiceLocation (Area + Address)
                string locationQuery =
                    @"UPDATE ServiceLocation
                      SET Area = @Area,
                          Address = @Address
                      WHERE LocationId = @LocationId";

                using (SqlCommand cmd = new SqlCommand(locationQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Area", txtArea.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@LocationId", selectedLocationId);
                    cmd.ExecuteNonQuery();
                }

                // 🔹 Update Clinic (Fee + Active)
                string clinicQuery =
                    @"UPDATE Clinic
                      SET ConsultationFee = @Fee,
                          IsActive = @IsActive
                      WHERE ClinicId = @ClinicId";

                using (SqlCommand cmd = new SqlCommand(clinicQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Fee", fee);
                    cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                    cmd.Parameters.AddWithValue("@ClinicId", selectedClinicId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Clinic updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LoadClinics();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmAdminDashboard().Show();
        }
    }
}
