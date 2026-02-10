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
    public partial class FrmPrescriptionVerification : Form
    {
        private int _prescriptionId;
        private int _orderId;

        private readonly string cs =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmPrescriptionVerification(int prescriptionId, int orderId)
        {
            InitializeComponent();
            _prescriptionId = prescriptionId;
            _orderId = orderId;
        }

        private void FrmPrescriptionVerification_Load(object sender, EventArgs e)
        {
            if (Session.PharmacistId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            LoadStatusCombo();
            LoadPrescriptionInfo();
            LoadMedicines();
        }
        private void LoadStatusCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Verified");
            cmbStatus.Items.Add("Rejected");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadPrescriptionInfo()
        {
            string query =
                @"SELECT 
                    P.PrescriptionId,
                    U.Email AS PatientEmail,
                    P.CreatedAt
                  FROM Prescription P
                  INNER JOIN Appointment A ON P.AppointmentId = A.AppointmentId
                  INNER JOIN Patient PT ON A.PatientId = PT.PatientId
                  INNER JOIN Users U ON PT.UserId = U.UserId
                  WHERE P.PrescriptionId = @PrescriptionId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PrescriptionId", _prescriptionId);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtPrescriptionId.Text = dr["PrescriptionId"].ToString();
                        txtPatientName.Text = dr["PatientEmail"].ToString();
                        txtDoctorName.Text = "N/A";
                        txtDate.Text =
                            Convert.ToDateTime(dr["CreatedAt"]).ToShortDateString();
                    }
                }
            }
        }
        private void LoadMedicines()
        {
            string query =
                @"SELECT 
                    M.MedicineName,
                    PM.Dosage
                  FROM PrescriptionMedicine PM
                  INNER JOIN Medicine M ON PM.MedicineId = M.MedicineId
                  WHERE PM.PrescriptionId = @PrescriptionId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PrescriptionId", _prescriptionId);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMedicines.DataSource = dt;
                }
            }

            dgvMedicines.ClearSelection();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            SaveVerificationStatus("Verified");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            SaveVerificationStatus("Rejected");
        }
        private void SaveVerificationStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please add remarks.");
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // 🔍 Step 1: Check if already exists
                string checkQuery =
                @"SELECT COUNT(*) 
          FROM OrderPrescription 
          WHERE OrderId = @OrderId AND PrescriptionId = @PrescriptionId";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@OrderId", _orderId);
                    checkCmd.Parameters.AddWithValue("@PrescriptionId", _prescriptionId);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        // 🔁 UPDATE instead of INSERT
                        string updateQuery =
                        @"UPDATE OrderPrescription
                  SET VerificationStatus = @Status,
                      VerifiedByPharmacistId = @PharmacistId,
                      VerificationNotes = @Remarks,
                      VerifiedAt = GETDATE()
                  WHERE OrderId = @OrderId AND PrescriptionId = @PrescriptionId";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@Status", status);
                            updateCmd.Parameters.AddWithValue("@PharmacistId", Session.PharmacistId);
                            updateCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@OrderId", _orderId);
                            updateCmd.Parameters.AddWithValue("@PrescriptionId", _prescriptionId);

                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // ➕ First time insert
                        string insertQuery =
                        @"INSERT INTO OrderPrescription
                  (OrderId, PrescriptionId, VerificationStatus,
                   VerifiedByPharmacistId, VerificationNotes, VerifiedAt)
                  VALUES
                  (@OrderId, @PrescriptionId, @Status,
                   @PharmacistId, @Remarks, GETDATE())";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@OrderId", _orderId);
                            insertCmd.Parameters.AddWithValue("@PrescriptionId", _prescriptionId);
                            insertCmd.Parameters.AddWithValue("@Status", status);
                            insertCmd.Parameters.AddWithValue("@PharmacistId", Session.PharmacistId);
                            insertCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show($"Prescription {status} successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            new FrmPharmacyDashboard().Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPharmacyDashboard().Show();
        }
    }
}
