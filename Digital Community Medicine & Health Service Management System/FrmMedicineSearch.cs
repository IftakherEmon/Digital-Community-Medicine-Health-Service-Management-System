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
    public partial class FrmMedicineSearch : Form
    {
        string connectionString =
           "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmMedicineSearch()
        {
            InitializeComponent();
        }

        private void FrmMedicineSearch_Load(object sender, EventArgs e)
        {
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadCategories();
            LoadMedicines();
        }
        private void LoadCategories()
        {
            comboCategory.Items.Clear();
            comboCategory.Items.Add("All");

            string query = "SELECT CategoryName FROM MedicineCategory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboCategory.Items.Add(reader["CategoryName"].ToString());
                }
            }

            comboCategory.SelectedIndex = 0;
        }
        private void LoadMedicines()
        {
            string query =
            @"SELECT
    pi.InventoryId,
    m.MedicineId,
    m.MedicineName,
    mc.CategoryName,
    pi.Price,
    pi.StockQuantity,
    sl.Area AS PharmacyArea,
    p.PharmacyName
  FROM PharmacyInventory pi
  JOIN Medicine m ON pi.MedicineId = m.MedicineId
  JOIN MedicineCategory mc ON m.CategoryId = mc.CategoryId
  JOIN Pharmacy p ON pi.PharmacyId = p.PharmacyId
  JOIN ServiceLocation sl ON p.LocationId = sl.LocationId
  WHERE m.MedicineName LIKE @MedicineName
    AND pi.StockQuantity > 0";


            if (comboCategory.Text != "All")
            {
                query += " AND mc.CategoryName = @Category";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MedicineName", "%" + txtSearch.Text.Trim() + "%");

                if (comboCategory.Text != "All")
                {
                    cmd.Parameters.AddWithValue("@Category", comboCategory.Text);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewMedicines.DataSource = dt;
            }

            dataGridViewMedicines.Columns["MedicineId"].Visible = false;
            dataGridViewMedicines.Columns["InventoryId"].Visible = false;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewMedicines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medicine.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int inventoryId = Convert.ToInt32(
                dataGridViewMedicines.SelectedRows[0]
                .Cells["InventoryId"].Value);

            decimal price = Convert.ToDecimal(
                dataGridViewMedicines.SelectedRows[0]
                .Cells["Price"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                DECLARE @CartId INT;

                SELECT @CartId = CartId 
                FROM Cart 
                WHERE PatientId = @PatientId;

                IF @CartId IS NULL
                BEGIN
                    INSERT INTO Cart (PatientId, CreatedAt)
                    VALUES (@PatientId, GETDATE());

                    SET @CartId = SCOPE_IDENTITY();
                END

                IF EXISTS (
                    SELECT 1 FROM CartItem
                    WHERE CartId = @CartId
                    AND PharmacyInventoryId = @InventoryId
                )
                BEGIN
                    UPDATE CartItem
                    SET Quantity = Quantity + 1
                    WHERE CartId = @CartId
                    AND PharmacyInventoryId = @InventoryId;
                END
                ELSE
                BEGIN
                    INSERT INTO CartItem
                    (CartId, PharmacyInventoryId, Quantity, PriceAtTime)
                    VALUES
                    (@CartId, @InventoryId, 1, @Price);
                END
                ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                    cmd.Parameters.AddWithValue("@InventoryId", inventoryId);
                    cmd.Parameters.AddWithValue("@Price", price);

                    cmd.ExecuteNonQuery();
                }
            }

            DialogResult result = MessageBox.Show(
                "Medicine added to cart successfully!\n\nDo you want to go to Cart now?",
                "Added to Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                new FrmCart().Show();
            }
        }
    }
}
