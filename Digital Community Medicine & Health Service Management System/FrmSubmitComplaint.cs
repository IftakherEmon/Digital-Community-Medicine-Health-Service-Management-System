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
    public partial class FrmSubmitComplaint : Form
    {
        string cs =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmSubmitComplaint()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter complaint details.");
                return;
            }

            string query =
                @"INSERT INTO Complaint
                  (UserId, ComplaintType, Description, Priority, Status, CreatedAt)
                  VALUES
                  (@UserId, @Type, @Desc, @Priority, 'Open', GETDATE())";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                cmd.Parameters.AddWithValue("@Type", cmbType.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Priority", cmbPriority.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Complaint submitted successfully.");

            this.Hide();
            new FrmPatientDashboard().Show();
        }

        private void FrmSubmitComplaint_Load(object sender, EventArgs e)
        {
            if (Session.UserId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            cmbType.Items.Add("Doctor");
            cmbType.Items.Add("Pharmacy");
            cmbType.Items.Add("Diagnostic Lab");
            cmbType.Items.Add("Service");

            cmbPriority.Items.Add("Low");
            cmbPriority.Items.Add("Medium");
            cmbPriority.Items.Add("High");

            cmbType.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
