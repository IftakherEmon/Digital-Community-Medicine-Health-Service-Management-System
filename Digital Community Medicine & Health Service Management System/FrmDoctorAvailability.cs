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
    public partial class FrmDoctorAvailability : Form
    {
        string connectionString =
            "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmDoctorAvailability()
        {
            InitializeComponent();
        }

        private void FrmDoctorAvailability_Load(object sender, EventArgs e)
        {
            LoadClinics();

            // Date picker (date only)
            datePickerDate.Format = DateTimePickerFormat.Short;

            // Time pickers (TIME ONLY)
            timePickerStart.Format = DateTimePickerFormat.Custom;
            timePickerStart.CustomFormat = "hh:mm tt";
            timePickerStart.ShowUpDown = true;

            timePickerEnd.Format = DateTimePickerFormat.Custom;
            timePickerEnd.CustomFormat = "hh:mm tt";
            timePickerEnd.ShowUpDown = true;
        }
        private void LoadClinics()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q =
                    @"SELECT dc.DoctorClinicId,
                             sl.Area + ' - Fee: ৳' + CAST(c.ConsultationFee AS VARCHAR) AS DisplayText
                      FROM DoctorClinic dc
                      JOIN Clinic c ON dc.ClinicId = c.ClinicId
                      JOIN ServiceLocation sl ON c.LocationId = sl.LocationId
                      WHERE dc.DoctorId = @DoctorId";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                cmbClinic.DisplayMember = "DisplayText";
                cmbClinic.ValueMember = "DoctorClinicId";
                cmbClinic.DataSource = dt;
            }
        }

        private void btnGenerateSlots_Click(object sender, EventArgs e)
        {
            if (cmbClinic.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a clinic.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = datePickerDate.Value.Date;

            DateTime startDateTime =
                selectedDate.Add(timePickerStart.Value.TimeOfDay);

            DateTime endDateTime =
                selectedDate.Add(timePickerEnd.Value.TimeOfDay);

            if (endDateTime <= startDateTime)
            {
                MessageBox.Show("End time must be after start time.",
                                "Invalid Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int doctorClinicId = Convert.ToInt32(cmbClinic.SelectedValue);
            int slotDuration = 30; // minutes

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                DateTime slotTime = startDateTime;

                while (slotTime.AddMinutes(slotDuration) <= endDateTime)
                {
                    // ❌ Prevent duplicate slots
                    string checkQuery =
                        @"SELECT COUNT(*)
                          FROM AppointmentSlot
                          WHERE DoctorClinicId = @DoctorClinicId
                            AND SlotDateTime = @SlotDateTime";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@DoctorClinicId", doctorClinicId);
                    checkCmd.Parameters.AddWithValue("@SlotDateTime", slotTime);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists == 0)
                    {
                        string insertQuery =
                            @"INSERT INTO AppointmentSlot
                              (DoctorClinicId, SlotDateTime, DurationMinutes, Status)
                              VALUES
                              (@DoctorClinicId, @SlotDateTime, @Duration, 'Available')";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@DoctorClinicId", doctorClinicId);
                        insertCmd.Parameters.AddWithValue("@SlotDateTime", slotTime);
                        insertCmd.Parameters.AddWithValue("@Duration", slotDuration);

                        insertCmd.ExecuteNonQuery();
                    }

                    slotTime = slotTime.AddMinutes(slotDuration);
                }
            }

            MessageBox.Show("Appointment slots generated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorDashboard().Show();
        }
    }
}
