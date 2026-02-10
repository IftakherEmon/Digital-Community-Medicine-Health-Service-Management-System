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
    public partial class FrmCheckout : Form
    {

        public FrmCheckout()
        {
            InitializeComponent();
        }

        private void FrmCheckout_Load(object sender, EventArgs e)
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

            dataGridViewCheckout.AllowUserToAddRows = false;

            LoadPaymentMethods();
            LoadCheckoutSummary();
        }
        private void LoadCheckoutSummary()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT " +
                "m.MedicineName, " +
                "ci.Quantity, " +
                "pi.Price, " +
                "(ci.Quantity * pi.Price) AS Total " +
                "FROM CartItem ci " +
                "JOIN Cart c ON ci.CartId = c.CartId " +
                "JOIN PharmacyInventory pi ON ci.PharmacyInventoryId = pi.InventoryId " +
                "JOIN Medicine m ON pi.MedicineId = m.MedicineId " +
                "WHERE c.PatientId = @PatientId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewCheckout.DataSource = dt;
            }

            CalculateGrandTotal();
        }
        private void CalculateGrandTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCheckout.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            lblTotalAmount.Text = total.ToString("0.00") + " BDT";
        }

        private void LoadPaymentMethods()
        {
            comboBoxPaymentMethod.Items.Clear();
            comboBoxPaymentMethod.Items.Add("Cash");
            comboBoxPaymentMethod.Items.Add("bKash");
            comboBoxPaymentMethod.Items.Add("Nagad");
            comboBoxPaymentMethod.Items.Add("Card");
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewCheckout.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string paymentMethod = comboBoxPaymentMethod.Text;

            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                MessageBox.Show("Please select a payment method.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount =
                Convert.ToDecimal(lblTotalAmount.Text.Replace(" BDT", ""));

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 🔹 1️⃣ Get PharmacyId (single pharmacy per cart)
                    int pharmacyId;
                    string pharmacyQuery =
                        "SELECT TOP 1 pi.PharmacyId " +
                        "FROM CartItem ci " +
                        "JOIN Cart c ON ci.CartId = c.CartId " +
                        "JOIN PharmacyInventory pi ON ci.PharmacyInventoryId = pi.InventoryId " +
                        "WHERE c.PatientId = @PatientId";

                    using (SqlCommand cmd = new SqlCommand(pharmacyQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);

                        object result = cmd.ExecuteScalar();
                        if (result == null)
                            throw new Exception("Pharmacy not found for cart.");

                        pharmacyId = Convert.ToInt32(result);
                    }

                    // 🔹 2️⃣ Insert MedicineOrder
                    int orderId;
                    string orderQuery =
                        "INSERT INTO MedicineOrder (PatientId, PharmacyId, TotalAmount, Status, OrderedAt) " +
                        "VALUES (@PatientId, @PharmacyId, @TotalAmount, 'Pending', GETDATE()); " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(orderQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                        cmd.Parameters.AddWithValue("@PharmacyId", pharmacyId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        orderId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 🔹 3️⃣ Insert Payment (Admin verify করবে)
                    string paymentQuery =
                        "INSERT INTO Payment (OrderId, Amount, Method, PaymentStatus) " +
                        "VALUES (@OrderId, @Amount, @Method, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(paymentQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@Amount", totalAmount);
                        cmd.Parameters.AddWithValue("@Method", paymentMethod);
                        cmd.ExecuteNonQuery();
                    }

                    // 🔹 4️⃣ Clear Cart
                    string clearCartQuery =
                        "DELETE ci FROM CartItem ci " +
                        "JOIN Cart c ON ci.CartId = c.CartId " +
                        "WHERE c.PatientId = @PatientId";

                    using (SqlCommand cmd = new SqlCommand(clearCartQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Order placed successfully!\nPayment pending verification.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.Hide();
                    new FrmPatientDashboard().Show();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message,
                                    "Checkout Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmCart().Show();
        }
    }
}
