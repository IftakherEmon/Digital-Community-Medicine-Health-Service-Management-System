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
    public partial class FrmPharmacyInventory : Form
    {
        public FrmPharmacyInventory()
        {
            InitializeComponent();
        }

        private void FrmPharmacyInventory_Load(object sender, EventArgs e)
        {
            if (Session.PharmacistId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            // 🔐 Safety check: pharmacy registered or not
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

            LoadMedicine();
            LoadInventory();
        }
        private void LoadMedicine()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query = "SELECT MedicineId, MedicineName FROM Medicine";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMedicine.DataSource = dt;
                cmbMedicine.DisplayMember = "MedicineName";
                cmbMedicine.ValueMember = "MedicineId";
            }

            cmbMedicine.SelectedIndex = -1;
        }
        private void LoadInventory()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
            @"SELECT I.InventoryId,
         M.MedicineName,
         I.Price,
         I.StockQuantity,
         I.LastRestocked
  FROM PharmacyInventory I
  INNER JOIN Medicine M ON I.MedicineId = M.MedicineId
  WHERE I.PharmacyId = @PharmacyId";


            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PharmacyId", GetPharmacyId());

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvInventory.DataSource = dt;
                }
            }

            dgvInventory.ClearSelection();
        }
        private int GetPharmacyId()
        {
            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT PharmacyId FROM Pharmacist WHERE PharmacistId = @PharmacistId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PharmacistId", Session.PharmacistId);
                con.Open();

                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value
                    ? Convert.ToInt32(result)
                    : 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedIndex == -1 ||
    string.IsNullOrWhiteSpace(txtPrice.Text) ||
    string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query = @"
IF EXISTS (
    SELECT 1 FROM PharmacyInventory
    WHERE PharmacyId = @PharmacyId
      AND MedicineId = @MedicineId
)
BEGIN
    UPDATE PharmacyInventory
    SET
        Price = @Price,
        StockQuantity = StockQuantity + @Stock,
        LastRestocked = GETDATE()
    WHERE PharmacyId = @PharmacyId
      AND MedicineId = @MedicineId
END
ELSE
BEGIN
    INSERT INTO PharmacyInventory
    (PharmacyId, MedicineId, Price, StockQuantity)
    VALUES
    (@PharmacyId, @MedicineId, @Price, @Stock)
END
";


            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PharmacyId", GetPharmacyId());
                cmd.Parameters.AddWithValue("@MedicineId", cmbMedicine.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));
               

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inventory added successfully.");
            ClearFields();
            LoadInventory();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an inventory item.");
                return;
            }

            int inventoryId =
                Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["InventoryId"].Value);

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
            @"UPDATE PharmacyInventory
  SET Price = @Price,
      StockQuantity = @Stock,
      LastRestocked = GETDATE()
  WHERE InventoryId = @InventoryId";


            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));
                cmd.Parameters.AddWithValue("@ExpiryDate", dtpExpiry.Value.Date);
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inventory updated successfully.");
            ClearFields();
            LoadInventory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an inventory item.");
                return;
            }

            int inventoryId =
                Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["InventoryId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            string cs =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "DELETE FROM PharmacyInventory WHERE InventoryId=@InventoryId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inventory deleted.");
            ClearFields();
            LoadInventory();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmbMedicine.Text =
                    dgvInventory.Rows[e.RowIndex].Cells["MedicineName"].Value.ToString();
                txtPrice.Text =
                    dgvInventory.Rows[e.RowIndex].Cells["Price"].Value.ToString();

                txtStock.Text =
                    dgvInventory.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();


            }
        }
        private void ClearFields()
        {
            cmbMedicine.SelectedIndex = -1;
            txtPrice.Clear();
            txtStock.Clear();
            dtpExpiry.Value = DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPharmacyDashboard().Show();
            this.Hide();
        }
    }
}
