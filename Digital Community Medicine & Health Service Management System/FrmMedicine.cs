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
    public partial class FrmMedicine : Form
    {
        public FrmMedicine()
        {
            InitializeComponent();
        }

        private void FrmMedicine_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadMedicine();
        }
        private void LoadCategories()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT CategoryId, CategoryName FROM MedicineCategory";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryId";
            }

            cmbCategory.SelectedIndex = -1;
        }
        private void LoadMedicine()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                @"SELECT M.MedicineId, M.MedicineName, M.Strength,
                 C.CategoryName
          FROM Medicine M
          INNER JOIN MedicineCategory C ON M.CategoryId = C.CategoryId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMedicine.DataSource = dt;
            }

            dgvMedicine.ClearSelection();
        }
        private void ClearFields()
        {
            txtMedicineName.Clear();
            txtStrength.Clear();
            cmbCategory.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text) ||
                string.IsNullOrWhiteSpace(txtStrength.Text) ||
                cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all required fields.");
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                @"INSERT INTO Medicine (MedicineName, Strength, CategoryId)
          VALUES (@Name, @Strength, @CategoryId)";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtMedicineName.Text.Trim());
                cmd.Parameters.AddWithValue("@Strength", txtStrength.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", cmbCategory.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Medicine added.");
            ClearFields();
            LoadMedicine();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a medicine.");
                return;
            }

            int medicineId =
                Convert.ToInt32(dgvMedicine.SelectedRows[0].Cells["MedicineId"].Value);

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                @"UPDATE Medicine
          SET MedicineName=@Name, Strength=@Strength, CategoryId=@CategoryId
          WHERE MedicineId=@Id";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtMedicineName.Text.Trim());
                cmd.Parameters.AddWithValue("@Strength", txtStrength.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", cmbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Id", medicineId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Medicine updated.");
            ClearFields();
            LoadMedicine();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a medicine.");
                return;
            }

            int medicineId =
                Convert.ToInt32(dgvMedicine.SelectedRows[0].Cells["MedicineId"].Value);

            DialogResult result = MessageBox.Show(
                "Delete this medicine?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "DELETE FROM Medicine WHERE MedicineId=@Id";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", medicineId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Medicine deleted.");
            ClearFields();
            LoadMedicine();
        }

        private void dgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMedicineName.Text =
                    dgvMedicine.Rows[e.RowIndex].Cells["MedicineName"].Value.ToString();

                txtStrength.Text =
                    dgvMedicine.Rows[e.RowIndex].Cells["Strength"].Value.ToString();

                cmbCategory.Text =
                    dgvMedicine.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPharmacyDashboard().Show();
            this.Hide();
        }
    }
}
