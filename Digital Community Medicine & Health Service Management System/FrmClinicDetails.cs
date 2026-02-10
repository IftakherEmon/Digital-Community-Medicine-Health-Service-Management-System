using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmClinicDetails : Form
    {
        int clinicId;
        int doctorId;
        public FrmClinicDetails(int cId, int dId)
        {
            InitializeComponent();
            clinicId = cId;
            doctorId = dId;
        }

        private void FrmClinicDetails_Load(object sender, EventArgs e)
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "SELECT sl.Name AS ClinicName, c.ConsultationFee, sl.Area, sl.Address " +
                    "FROM Clinic c " +
                    "JOIN ServiceLocation sl ON c.LocationId = sl.LocationId " +
                    "WHERE c.ClinicId = @ClinicId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClinicId", clinicId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        lblClinicName.Text = reader["ClinicName"].ToString();
                        lblFee.Text = reader["ConsultationFee"].ToString();
                        lblArea.Text = reader["Area"].ToString();
                        lblAddress.Text = reader["Address"].ToString();
                    }

                    reader.Close();
                }
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmSelectSlot slot =
                new FrmSelectSlot(clinicId, doctorId);

            slot.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorDetails(doctorId).Show();
        }
    }
}

