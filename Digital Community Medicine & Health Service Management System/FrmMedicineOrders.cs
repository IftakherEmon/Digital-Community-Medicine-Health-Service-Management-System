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
    public partial class FrmMedicineOrders : Form
    {
        public FrmMedicineOrders()
        {
            InitializeComponent();
        }

        private void FrmMedicineOrders_Load(object sender, EventArgs e)
        {
            // Session check
            if (Session.PharmacistId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            // 🔐 Pharmacy check (IMPORTANT)
            int pharmacyId = GetPharmacyId();
            if (pharmacyId <= 0)
            {
                MessageBox.Show(
                    "No pharmacy found. Please register your pharmacy first.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Hide();
                new FrmPharmacyRegistration().Show();
                return;
            }

            LoadOrders();
        }
        private void LoadOrders()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
            @"SELECT 
      O.OrderId,
      U.Email AS PatientEmail,
      O.OrderedAt AS OrderDate,
      O.TotalAmount,
      O.Status
  FROM MedicineOrder O
  INNER JOIN Patient P ON O.PatientId = P.PatientId
  INNER JOIN Users U ON P.UserId = U.UserId
  WHERE O.PharmacyId = @PharmacyId
  ORDER BY O.OrderedAt DESC";


            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PharmacyId", GetPharmacyId());

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOrders.DataSource = dt;
                }
            }

            dgvOrders.ClearSelection();
        }
        private int GetPharmacyId()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT PharmacyId FROM Pharmacist WHERE PharmacistId=@PharmacistId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PharmacistId", Session.PharmacistId);
                con.Open();

                object result = cmd.ExecuteScalar();

                // ✅ DBNull safe conversion
                return (result != null && result != DBNull.Value)
                    ? Convert.ToInt32(result)
                    : 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPharmacyDashboard().Show();
            this.Hide();
        }
    }
}
