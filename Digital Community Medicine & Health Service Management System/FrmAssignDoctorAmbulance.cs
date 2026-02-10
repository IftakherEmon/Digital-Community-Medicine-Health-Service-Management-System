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
    public partial class FrmAssignDoctorAmbulance : Form
    {
        int emergencyId;
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
       
        public FrmAssignDoctorAmbulance(int eid)
        {
            InitializeComponent();
            emergencyId = eid;
        }

        /*public FrmAssignDoctorAmbulance()
        {
            InitializeComponent();
        }*/


        private void btnAssign_Click(object sender, EventArgs e)
        {
            int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);
            int ambulanceId = Convert.ToInt32(cmbAmbulance.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE EmergencyRequest SET DoctorId=@DoctorId, AmbulanceId=@AmbulanceId, Status='Ambulance Dispatched' " +
                               "WHERE EmergencyRequestId=@EmergencyRequestId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@AmbulanceId", ambulanceId);
                cmd.Parameters.AddWithValue("@EmergencyRequestId", emergencyId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Doctor and Ambulance assigned successfully!");

            new FrmEmergencyRequests().Show();
            this.Hide();
        }

        private void FrmAssignDoctorAmbulance_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            LoadAmbulances();
        }
        private void LoadDoctors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DoctorId, FullName FROM Doctor WHERE IsApproved = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "FullName";
                cmbDoctor.ValueMember = "DoctorId";
            }
        }
        private void LoadAmbulances()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT AmbulanceId, AmbulanceNumber FROM Ambulance WHERE IsAvailable = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbAmbulance.DataSource = dt;
                cmbAmbulance.DisplayMember = "AmbulanceNumber";
                cmbAmbulance.ValueMember = "AmbulanceId";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmEmergencyRequests().Show();
            this.Hide();
        }
    }
}
