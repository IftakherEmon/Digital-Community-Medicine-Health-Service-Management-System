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
    public partial class FrmAddEditAmbulance : Form
    {
        int ambulanceId = 0;
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmAddEditAmbulance(int id = 0)
        {
            InitializeComponent();
            ambulanceId = id;

            if (ambulanceId > 0)
                LoadAmbulanceData();
        }

        /*public FrmAddEditAmbulance()
        {
            InitializeComponent();
        }*/


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query;

                if (ambulanceId == 0)
                {
                    query = "INSERT INTO Ambulance (AmbulanceNumber, DriverName, Phone, IsAvailable) " +
                            "VALUES (@Number, @Driver, @Phone, 1)";
                }
                else
                {
                    query = "UPDATE Ambulance SET AmbulanceNumber=@Number, DriverName=@Driver, Phone=@Phone WHERE AmbulanceId=@AmbulanceId";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Number", txtAmbulanceNumber.Text);
                cmd.Parameters.AddWithValue("@Driver", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);

                if (ambulanceId > 0)
                    cmd.Parameters.AddWithValue("@AmbulanceId", ambulanceId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Ambulance saved successfully!");

            new FrmAmbulanceList().Show();
            this.Hide();
        }

        private void FrmAddEditAmbulance_Load(object sender, EventArgs e)
        {

        }
        private void LoadAmbulanceData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ambulance WHERE AmbulanceId=@AmbulanceId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AmbulanceId", ambulanceId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtAmbulanceNumber.Text = reader["AmbulanceNumber"].ToString();
                    txtDriverName.Text = reader["DriverName"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAmbulanceList().Show();
            this.Hide();

        }
    }
}
