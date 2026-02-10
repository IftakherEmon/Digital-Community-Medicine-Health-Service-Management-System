using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmDoctorRegistration : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmDoctorRegistration()
        {
            InitializeComponent();
        }

        private void FrmDoctorRegistration_Load(object sender, EventArgs e)
        {
            cmbSpecialization.Items.Clear();

            cmbSpecialization.Items.Add("Medicine");
            cmbSpecialization.Items.Add("Cardiology");
            cmbSpecialization.Items.Add("Neurology");
            cmbSpecialization.Items.Add("Orthopedics");
            cmbSpecialization.Items.Add("Gynecology");
            cmbSpecialization.Items.Add("Pediatrics");
            cmbSpecialization.Items.Add("Dermatology");
            cmbSpecialization.Items.Add("Psychiatry");

            // -------------------------
            // Approval Status
            // -------------------------
            lblApprovalStatus.Text = "Pending Admin Approval";
            lblApprovalStatus.ForeColor = Color.OrangeRed;

            txtCertificatePath.ReadOnly = true;
            txtArea.ReadOnly = true;
            txtConsultationFee.ReadOnly = true;

            // -------------------------
            // Load Clinics
            // -------------------------
            LoadClinics();
        }
        private void LoadClinics()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT 
            c.ClinicId,
            (sl.Area + ' - ' + sl.Address) AS ClinicDisplay,
            sl.Area,
            c.ConsultationFee
          FROM Clinic c
          JOIN ServiceLocation sl ON c.LocationId = sl.LocationId
          WHERE c.IsActive = 1", con))
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cmbClinic.DisplayMember = "ClinicDisplay";
                cmbClinic.ValueMember = "ClinicId";
                cmbClinic.DataSource = dt;
            }
        }

        private void btnBrowseCertificate_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|Image Files (*.jpg;*.png)|*.jpg;*.png",
                Title = "Select Certificate File"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCertificatePath.Text = ofd.FileName;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                cmbSpecialization.SelectedIndex == -1 ||
                cmbClinic.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtRegNo.Text) ||
                string.IsNullOrWhiteSpace(txtCertificatePath.Text))
            {
                MessageBox.Show("Please fill all required fields.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (IsAlreadyRegistered())
            {
                MessageBox.Show("You have already submitted your registration.",
                                "Duplicate Entry",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // -------------------------
            // COPY CERTIFICATE
            // -------------------------
            string certFolder = Application.StartupPath + @"\Certificates\";

            if (!Directory.Exists(certFolder))
                Directory.CreateDirectory(certFolder);

            string fileName = Path.GetFileName(txtCertificatePath.Text);
            string destinationPath = certFolder + fileName;

            File.Copy(txtCertificatePath.Text, destinationPath, true);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // -------------------------
                // INSERT DOCTOR
                // -------------------------
                string doctorQuery =
                    @"INSERT INTO Doctor
                      (UserId, FullName, Specialization, RegistrationNumber,
                       CertificatePath, YearsOfExperience, IsApproved)
                      VALUES
                      (@UserId, @FullName, @Specialization, @RegNo,
                       @CertPath, @Experience, 0);
                      SELECT SCOPE_IDENTITY();";

                int doctorId;

                using (SqlCommand cmd = new SqlCommand(doctorQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", cmbSpecialization.Text);
                    cmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@CertPath", destinationPath);
                    cmd.Parameters.AddWithValue("@Experience", numExperience.Value);

                    doctorId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // -------------------------
                // MAP DOCTOR TO SELECTED CLINIC
                // -------------------------
                int clinicId = Convert.ToInt32(cmbClinic.SelectedValue);

                string mapQuery =
                    @"INSERT INTO DoctorClinic (DoctorId, ClinicId, IsPrimary)
                      VALUES (@DoctorId, @ClinicId, 1)";

                using (SqlCommand mapCmd = new SqlCommand(mapQuery, con))
                {
                    mapCmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    mapCmd.Parameters.AddWithValue("@ClinicId", clinicId);
                    mapCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Registration successful!\nYour profile is pending admin approval.",
                "Pending Approval",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Hide();
            new FrmLogin().Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmLogin().Show();
        }
        private bool IsAlreadyRegistered()
        {
            string q = "SELECT COUNT(*) FROM Doctor WHERE UserId = @UserId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void cmbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClinic.SelectedItem is DataRowView row)
            {
                txtArea.Text = row["Area"].ToString();
                txtConsultationFee.Text = row["ConsultationFee"].ToString();
            }
        }
    }
}
