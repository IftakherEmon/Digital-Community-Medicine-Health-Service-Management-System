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
    public partial class FrmNearbyClinics : Form
    {
        public FrmNearbyClinics()
        {
            InitializeComponent();
        }

        private void FrmNearbyClinics_Load(object sender, EventArgs e)
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT DISTINCT Area FROM ServiceLocation WHERE ServiceType = 'Clinic'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxArea.Items.Add(reader["Area"].ToString());
                }

                reader.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxArea.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an area.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT c.ClinicName, c.ConsultationFee, sl.Area, sl.Address " +
                "FROM Clinic c " +
                "JOIN ServiceLocation sl ON c.LocationId = sl.LocationId " +
                "WHERE sl.Area = @Area";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Area", comboBoxArea.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewClinics.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
