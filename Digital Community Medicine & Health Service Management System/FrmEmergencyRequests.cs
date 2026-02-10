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
    public partial class FrmEmergencyRequests : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmEmergencyRequests()
        {
            InitializeComponent();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvEmergency.SelectedRows.Count > 0)
            {
                int emergencyId = Convert.ToInt32(dgvEmergency.SelectedRows[0].Cells["EmergencyRequestId"].Value);

                FrmAssignDoctorAmbulance assign = new FrmAssignDoctorAmbulance(emergencyId);
                assign.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select an emergency request first.");
            }
        }

        private void FrmEmergencyRequests_Load(object sender, EventArgs e)
        {
            LoadEmergencyRequests();
        }
        private void LoadEmergencyRequests()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT EmergencyRequestId, PatientId, EmergencyType, Status, RequestTime " +
                               "FROM EmergencyRequest WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEmergency.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAdminDashboard().Show();
            this.Hide();
        }
    }
}
