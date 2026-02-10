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
    public partial class FrmAmbulanceList : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmAmbulanceList()
        {
            InitializeComponent();
        }

        private void FrmAmbulanceList_Load(object sender, EventArgs e)
        {

            LoadAmbulances();
        }

        private void LoadAmbulances()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT AmbulanceId, AmbulanceNumber, DriverName, Phone, IsAvailable FROM Ambulance";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAmbulance.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FrmAddEditAmbulance().Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAmbulance.SelectedRows.Count > 0)
            {
                int ambulanceId = Convert.ToInt32(dgvAmbulance.SelectedRows[0].Cells["AmbulanceId"].Value);
                new FrmAddEditAmbulance(ambulanceId).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select an ambulance first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAdminDashboard().Show();
            this.Hide();
        }
    }
}
