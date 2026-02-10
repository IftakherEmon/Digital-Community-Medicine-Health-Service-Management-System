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
    public partial class FrmLabTestBooking : Form
    {
        int _labId;
        string cs =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmLabTestBooking(int labId)
        {
            InitializeComponent();
            _labId = labId;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestName.Text))
            {
                MessageBox.Show("Enter test name.");
                return;
            }

            string query =
                @"INSERT INTO LabTestBooking
                  (LabId, PatientId, TestName, PreferredDate)
                  VALUES
                  (@LabId, @PatientId, @Test, @Date)";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@LabId", _labId);
                cmd.Parameters.AddWithValue("@PatientId", Session.PatientId);
                cmd.Parameters.AddWithValue("@Test", txtTestName.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lab test booked successfully.");

            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
