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
    public partial class FrmMyAppointments : Form
    {
        public FrmMyAppointments()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }

        private void FrmMyAppointments_Load(object sender, EventArgs e)
        {
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadAppointments();
        }
        private void LoadAppointments()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT " +
                "a.AppointmentId, " +
                "d.DoctorId, " +
                "d.FullName AS DoctorName, " +
                "sl.Area AS ClinicName, " +
                "CAST(aps.SlotDateTime AS DATE) AS SlotDate, " +
                "CAST(aps.SlotDateTime AS TIME) AS StartTime, " +
                "DATEADD(MINUTE, aps.DurationMinutes, aps.SlotDateTime) AS EndTime, " +
                "a.Status " +
                "FROM Appointment a " +
                "JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId " +
                "JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId " +
                "JOIN Doctor d ON dc.DoctorId = d.DoctorId " +
                "JOIN Clinic c ON dc.ClinicId = c.ClinicId " +
                "JOIN ServiceLocation sl ON c.LocationId = sl.LocationId " +
                "WHERE a.PatientId = @PatientId " +
                "ORDER BY aps.SlotDateTime DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewAppointments.DataSource = dt;
            }

            // Hide internal IDs
            dataGridViewAppointments.Columns["AppointmentId"].Visible = false;
            dataGridViewAppointments.Columns["DoctorId"].Visible = false;

            // Add Review button column once
            if (!dataGridViewAppointments.Columns.Contains("btnReview"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnReview";
                btn.HeaderText = "Review";
                btn.Text = "Give Review";
                btn.UseColumnTextForButtonValue = true;

                dataGridViewAppointments.Columns.Add(btn);
                dataGridViewAppointments.ClearSelection();
                dataGridViewAppointments.SelectionMode =
                 DataGridViewSelectionMode.FullRowSelect;

                dataGridViewAppointments.MultiSelect = false;
                dataGridViewAppointments.ClearSelection();

            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppointments.CurrentRow == null)
            {
                MessageBox.Show("Please select an appointment first.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridViewAppointments.CurrentRow;

            object statusObj = row.Cells["Status"].Value;
            object appointmentObj = row.Cells["AppointmentId"].Value;

            if (statusObj == null || statusObj == DBNull.Value ||
                appointmentObj == null || appointmentObj == DBNull.Value)
            {
                MessageBox.Show("Invalid appointment data.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            string status = statusObj.ToString();

            if (status != "Confirmed")
            {
                MessageBox.Show("Only confirmed appointments can be cancelled.",
                                "Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(appointmentObj);

            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int slotId;

                string getSlotQuery =
                    "SELECT SlotId FROM Appointment WHERE AppointmentId = @AppointmentId";

                using (SqlCommand getCmd = new SqlCommand(getSlotQuery, connection))
                {
                    getCmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    object slotObj = getCmd.ExecuteScalar();

                    if (slotObj == null || slotObj == DBNull.Value)
                    {
                        MessageBox.Show("Slot not found.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }

                    slotId = Convert.ToInt32(slotObj);
                }

                string cancelQuery =
                    "UPDATE Appointment SET Status = 'Cancelled' WHERE AppointmentId = @AppointmentId";

                using (SqlCommand cancelCmd = new SqlCommand(cancelQuery, connection))
                {
                    cancelCmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    cancelCmd.ExecuteNonQuery();
                }

                string slotUpdateQuery =
                    "UPDATE AppointmentSlot SET Status = 'Available' WHERE SlotId = @SlotId";

                using (SqlCommand slotCmd = new SqlCommand(slotUpdateQuery, connection))
                {
                    slotCmd.Parameters.AddWithValue("@SlotId", slotId);
                    slotCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Appointment cancelled successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LoadAppointments();
        }

        private void dataGridViewAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (!dataGridViewAppointments.Columns.Contains("btnReview")) return;

            if (dataGridViewAppointments.Columns[e.ColumnIndex].Name != "btnReview")
                return;

            string status =
                dataGridViewAppointments.Rows[e.RowIndex]
                .Cells["Status"].Value?.ToString();

            if (status != "Completed")
            {
                MessageBox.Show("You can review only completed appointments.",
                                "Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            object appVal =
                dataGridViewAppointments.Rows[e.RowIndex]
                .Cells["AppointmentId"].Value;

            object docVal =
                dataGridViewAppointments.Rows[e.RowIndex]
                .Cells["DoctorId"].Value;

            if (appVal == DBNull.Value || docVal == DBNull.Value)
            {
                MessageBox.Show("Invalid appointment data.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            int appointmentId = Convert.ToInt32(appVal);
            int doctorId = Convert.ToInt32(docVal);

            this.Hide();
            new FrmAddReview(appointmentId, doctorId).Show();
        }
    }
}
