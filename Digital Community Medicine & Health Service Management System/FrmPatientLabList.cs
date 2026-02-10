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
    public partial class FrmPatientLabList : Form
    {
        string cs =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmPatientLabList()
        {
            InitializeComponent();
        }

        private void FrmPatientLabList_Load(object sender, EventArgs e)
        {
            LoadLabs();
        }
        private void LoadLabs()
        {
            string query =
                @"SELECT LabId, LabName, LicenseNumber
                  FROM DiagnosticLab
                  WHERE IsActive = 1";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLabs.DataSource = dt;
            }

            dgvLabs.ClearSelection();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvLabs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a lab.");
                return;
            }

            int labId =
                Convert.ToInt32(dgvLabs.SelectedRows[0].Cells["LabId"].Value);

            new FrmLabTestBooking(labId).Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
