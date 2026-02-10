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
    public partial class FrmFollowUpReminder : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        private int prescriptionId;
        public FrmFollowUpReminder(int prescriptionId)
        {
            InitializeComponent();
            this.prescriptionId = prescriptionId;
        }

        private void FrmFollowUpReminder_Load(object sender, EventArgs e)
        {
            lblPrescriptionId.Text = "Prescription ID: " + prescriptionId;

            cmbReminderType.Items.Clear();
            cmbReminderType.Items.Add("Follow-up Visit");
            cmbReminderType.Items.Add("Medicine Refill");
            cmbReminderType.Items.Add("Diagnostic Test");

            cmbReminderType.SelectedIndex = 0;
            dtpReminderDate.MinDate = DateTime.Today.AddDays(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpReminderDate.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Reminder date must be a future date.",
                                "Invalid Date",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string insertReminder =
                @"INSERT INTO FollowUpReminder
                  (PrescriptionId, ReminderDate, ReminderType, Note, Status, CreatedAt)
                  VALUES
                  (@PrescriptionId, @ReminderDate, @ReminderType, @Note, 'Pending', GETDATE());
                  SELECT SCOPE_IDENTITY();";

            int reminderId;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertReminder, con))
            {
                cmd.Parameters.AddWithValue("@PrescriptionId", prescriptionId);
                cmd.Parameters.AddWithValue("@ReminderDate", dtpReminderDate.Value.Date);
                cmd.Parameters.AddWithValue("@ReminderType", cmbReminderType.Text);
                cmd.Parameters.AddWithValue("@Note", rtxtNote.Text.Trim());

                con.Open();
                reminderId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // -----------------------------
            // NOTIFICATION SIMULATION
            // -----------------------------
            InsertNotification(reminderId);

            MessageBox.Show("Follow-up reminder saved successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Hide();
            new FrmDoctorDashboard().Show();
        }
        private void InsertNotification(int reminderId)
        {
            string q =
                @"INSERT INTO NotificationLog
                  (ReferenceId, NotificationType, Message, Status, CreatedAt)
                  VALUES
                  (@RefId, 'SMS', @Message, 'Sent', GETDATE())";

            string message =
                $"Reminder scheduled on {dtpReminderDate.Value:dd-MMM-yyyy} " +
                $"for {cmbReminderType.Text}.";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@RefId", reminderId);
                cmd.Parameters.AddWithValue("@Message", message);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorDashboard().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPrescriptionMedicine(prescriptionId).Show();
        }
    }
}
