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
    public partial class FrmSelectSlot : Form
    {
        int clinicId;
        int doctorId;
        public FrmSelectSlot(int cId, int dId)
        {
            InitializeComponent();
            clinicId = cId;
            doctorId = dId;
        }
        private void LoadSlots()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT aps.SlotId, " +
                "CONVERT(VARCHAR, aps.SlotDateTime, 108) AS StartTime, " +
                "DATEADD(MINUTE, aps.DurationMinutes, aps.SlotDateTime) AS EndTime, " +
                "aps.Status " +
                "FROM AppointmentSlot aps " +
                "JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId " +
                "WHERE dc.ClinicId = @ClinicId " +
                "AND dc.DoctorId = @DoctorId " +
                "AND CAST(aps.SlotDateTime AS DATE) = @SlotDate " +
                "AND aps.Status = 'Available'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClinicId", clinicId);
                command.Parameters.AddWithValue("@DoctorId", doctorId);
                command.Parameters.AddWithValue("@SlotDate", dateTimePickerDate.Value.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewSlots.DataSource = dt;
            }

            dataGridViewSlots.Columns["SlotId"].Visible = false;
            dataGridViewSlots.ClearSelection();
        }

        private void FrmSelectSlot_Load(object sender, EventArgs e)
        {
            LoadSlots();
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSlots();
        }

        private void dataGridViewSlots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            object value =
                dataGridViewSlots.Rows[e.RowIndex]
                .Cells["SlotId"].Value;

            if (value == null || value == DBNull.Value)
            {
                MessageBox.Show("Invalid slot selected. Please try again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int slotId = Convert.ToInt32(value);

            this.Hide();

            FrmConfirmAppointment confirm =
                new FrmConfirmAppointment(slotId, clinicId, doctorId);

            confirm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmClinicDetails(clinicId, doctorId).Show();
        }
    }
}
