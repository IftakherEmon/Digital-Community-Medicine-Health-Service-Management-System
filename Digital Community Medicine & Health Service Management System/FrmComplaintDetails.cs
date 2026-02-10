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
    public partial class FrmComplaintDetails : Form
    {
        int complaintId;
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmComplaintDetails(int cid)
        {
            InitializeComponent();
            complaintId = cid;

        }

        private void FrmComplaintDetails_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Resolved");
            cmbStatus.Items.Add("Closed");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Description, Status FROM Complaint WHERE ComplaintId=@ComplaintId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ComplaintId", complaintId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblComplaintText.Text = reader["Description"].ToString();
                    cmbStatus.Text = reader["Status"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Complaint SET Status=@Status, ResolutionNotes=@Notes, ResolvedAt=GETDATE(), ResolvedByAdminId=@AdminId " +
                               "WHERE ComplaintId=@ComplaintId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@Notes", txtResolution.Text);
                cmd.Parameters.AddWithValue("@AdminId", Session.UserId);
                cmd.Parameters.AddWithValue("@ComplaintId", complaintId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Complaint updated successfully!");

            new FrmComplaintList().Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmComplaintList().Show();
            this.Hide();
        }
    }
}
