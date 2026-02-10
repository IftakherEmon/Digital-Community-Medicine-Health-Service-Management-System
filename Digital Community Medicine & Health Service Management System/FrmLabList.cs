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
    public partial class FrmLabList : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmLabList()
        {
            InitializeComponent();
        }

        private void FrmLabList_Load(object sender, EventArgs e)
        {
            LoadLabs();
        }
        private void LoadLabs()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT dl.LabId, dl.LabName, dl.LicenseNumber, dl.IsActive " +
                               "FROM DiagnosticLab dl";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLabs.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FrmAddEditLab().Show();
            this.Hide();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLabs.SelectedRows.Count > 0)
            {
                int labId = Convert.ToInt32(dgvLabs.SelectedRows[0].Cells["LabId"].Value);
                new FrmAddEditLab(labId).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a lab first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAdminDashboard().Show();
            this.Hide();
        }
    }
}
