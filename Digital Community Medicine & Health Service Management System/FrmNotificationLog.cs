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
    public partial class FrmNotificationLog : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmNotificationLog()
        {
            InitializeComponent();
        }

        private void FrmNotificationLog_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }
        private void LoadNotifications()
        {
            string query =
                @"SELECT 
        NotificationId,
        UserId,
        NotificationType,
        Title,
        Message,
        Channel,
        Status,
        ISNULL(SentAt, CreatedAt) AS SentTime
      FROM NotificationLog
      ORDER BY CreatedAt DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNotifications.DataSource = dt;

                dgvNotifications.Columns["NotificationId"].HeaderText = "ID";
                dgvNotifications.Columns["UserId"].HeaderText = "User ID";
                dgvNotifications.Columns["NotificationType"].HeaderText = "Type";
                dgvNotifications.Columns["Title"].HeaderText = "Title";
                dgvNotifications.Columns["Message"].HeaderText = "Message";
                dgvNotifications.Columns["Channel"].HeaderText = "Channel";
                dgvNotifications.Columns["Status"].HeaderText = "Status";
                dgvNotifications.Columns["SentTime"].HeaderText = "Sent Time";


                dgvNotifications.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvNotifications.ClearSelection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmDoctorDashboard().Show();
        }
    }
}
