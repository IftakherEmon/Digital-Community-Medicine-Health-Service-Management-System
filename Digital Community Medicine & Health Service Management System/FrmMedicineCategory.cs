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
    public partial class FrmMedicineCategory : Form
    {
        public FrmMedicineCategory()
        {
            InitializeComponent();
        }

        private void FrmMedicineCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }
        private void LoadCategories()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query = "SELECT CategoryId, CategoryName FROM MedicineCategory";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategories.DataSource = dt;
            }

            dgvCategories.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Enter category name.");
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "INSERT INTO MedicineCategory (CategoryName) VALUES (@Name)";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim());
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category added successfully!");
            txtCategoryName.Clear();
            LoadCategories();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a category to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name cannot be empty.");
                return;
            }

            int categoryId =
                Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["CategoryId"].Value);

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "UPDATE MedicineCategory SET CategoryName=@Name WHERE CategoryId=@Id";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@Id", categoryId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category updated.");
            txtCategoryName.Clear();
            LoadCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a category to delete.");
                return;
            }

            int categoryId =
                Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["CategoryId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this category?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "DELETE FROM MedicineCategory WHERE CategoryId=@Id";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", categoryId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category deleted.");
            txtCategoryName.Clear();
            LoadCategories();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCategoryName.Text =
                    dgvCategories.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPharmacyDashboard().Show();
            this.Hide();
        }
    }
}
