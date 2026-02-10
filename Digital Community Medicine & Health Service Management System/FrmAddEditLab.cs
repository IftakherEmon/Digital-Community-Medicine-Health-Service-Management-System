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
    public partial class FrmAddEditLab : Form
    {
        int labId = 0;
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmAddEditLab(int id = 0)
        {
            InitializeComponent();
            labId = id;

            if (labId > 0)
                LoadLabData();
        }
        private void LoadLabData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT LabName, LicenseNumber FROM DiagnosticLab WHERE LabId=@LabId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LabId", labId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtLabName.Text = reader["LabName"].ToString();
                    txtLicense.Text = reader["LicenseNumber"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query;

                if (labId == 0)
                {
                    query = "INSERT INTO DiagnosticLab (LabName, LicenseNumber, IsActive) " +
                            "VALUES (@Name, @License, 1)";
                }
                else
                {
                    query = "UPDATE DiagnosticLab SET LabName=@Name, LicenseNumber=@License WHERE LabId=@LabId";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtLabName.Text);
                cmd.Parameters.AddWithValue("@License", txtLicense.Text);

                if (labId > 0)
                    cmd.Parameters.AddWithValue("@LabId", labId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Lab saved successfully!");

            new FrmLabList().Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmLabList().Show();
            this.Hide();
        }
    }
}
