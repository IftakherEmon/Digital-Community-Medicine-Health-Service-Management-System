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
    public partial class FrmCart : Form
    {
        int cartId = 0;
        public FrmCart()
        {
            InitializeComponent();
        }

        private void FrmCart_Load(object sender, EventArgs e)
        {
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadOrCreateCart();
            LoadCartItems();
        }
        private void LoadOrCreateCart()
        {
            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string getCart =
                    "SELECT CartId FROM Cart WHERE PatientId = @PatientId";

                using (SqlCommand cmd = new SqlCommand(getCart, con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        cartId = Convert.ToInt32(result);
                    }
                    else
                    {
                        string createCart =
                            "INSERT INTO Cart (PatientId) VALUES (@PatientId); SELECT SCOPE_IDENTITY();";

                        using (SqlCommand createCmd = new SqlCommand(createCart, con))
                        {
                            createCmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                            cartId = Convert.ToInt32(createCmd.ExecuteScalar());
                        }
                    }
                }
            }
        }
        private void LoadCartItems()
        {
            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                @"SELECT
         ci.CartItemId,
         m.MedicineName,
         pi.Price,
         ci.Quantity,
         (pi.Price * ci.Quantity) AS SubTotal
         FROM CartItem ci
         JOIN PharmacyInventory pi
          ON ci.PharmacyInventoryId = pi.InventoryId
          JOIN Medicine m
         ON pi.MedicineId = m.MedicineId
         WHERE ci.CartId = @CartId";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@CartId", cartId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewCart.DataSource = dt;
            }

            dataGridViewCart.Columns["CartItemId"].Visible = false;
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }

            lblTotalAmount.Text = "Total: " + total.ToString("0.00") + " BDT";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item to remove.");
                return;
            }

            int cartItemId =
                Convert.ToInt32(dataGridViewCart.SelectedRows[0]
                .Cells["CartItemId"].Value);

            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query =
                    "DELETE FROM CartItem WHERE CartItemId = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", cartItemId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadCartItems();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            this.Hide();
            new FrmCheckout().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMedicineSearch().Show();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            UpdateQuantity(+1);
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            UpdateQuantity(-1);
        }
        private void UpdateQuantity(int change)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item first.");
                return;
            }

            int cartItemId =
                Convert.ToInt32(dataGridViewCart.SelectedRows[0]
                .Cells["CartItemId"].Value);

            int currentQty =
                Convert.ToInt32(dataGridViewCart.SelectedRows[0]
                .Cells["Quantity"].Value);

            int newQty = currentQty + change;

            if (newQty <= 0)
            {
                MessageBox.Show("Quantity cannot be less than 1.");
                return;
            }

            string cs = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query =
                    "UPDATE CartItem SET Quantity = @Qty WHERE CartItemId = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Qty", newQty);
                    cmd.Parameters.AddWithValue("@Id", cartItemId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadCartItems();
        }
    }
}
