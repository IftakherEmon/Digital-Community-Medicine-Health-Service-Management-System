using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmComplaintList : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmComplaintList()
        {
            InitializeComponent();
        }

        private void FrmComplaintList_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Resolved");
            cmbStatus.SelectedIndex = 0;

            LoadComplaints();
        }
        private void LoadComplaints()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ComplaintId, UserId, ComplaintType, Status, Priority, CreatedAt " +
                               "FROM Complaint WHERE Status = @Status";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvComplaints.DataSource = dt;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComplaints();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvComplaints.SelectedRows.Count > 0)
            {
                int complaintId = Convert.ToInt32(dgvComplaints.SelectedRows[0].Cells["ComplaintId"].Value);

                FrmComplaintDetails details = new FrmComplaintDetails(complaintId);
                details.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a complaint first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAdminDashboard().Show();
            this.Hide();
        }
    }
}
