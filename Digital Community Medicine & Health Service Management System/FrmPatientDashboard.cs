using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmPatientDashboard : Form
    {
        public FrmPatientDashboard()
        {
            InitializeComponent();
        }

        private void buttonFindDoctor_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorSearch().Show();
        }

        private void buttonMyAppointments_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMyAppointments().Show();
        }

        private void buttonMedicalHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMedicalHistory().Show();
        }

        private void buttonNearbyClinics_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmNearbyClinics().Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Session.UserId = 0;
            Session.PatientId = 0;
            Session.DoctorId = 0;
            Session.PharmacistId = 0;
            Session.Role = null;
            Session.CartItems = null;

            this.Hide();
            new FrmLogin().Show();
        }

        private void FrmPatientDashboard_Load(object sender, EventArgs e)
        {
            if (Session.UserId <= 0 || Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientProfile().Show();
        }

        private void btnAppointmentHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmAppointmentHistory().Show();
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPrescriptionRecords().Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPaymentRecords().Show();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientReviews().Show();
        }

        private void btnBuyMedicine_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMedicineSearch().Show();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMyOrders().Show();
        }

        private void btnEmergency_Click(object sender, EventArgs e)
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

            this.Hide();
            new FrmEmergencyRequest().Show();
        }

        private void btnFollowUps_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMyFollowUps().Show();
        }

        private void btnComplaint_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmSubmitComplaint().Show();
        }

        private void btnDiagnosticLab_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientLabList().Show();
        }
    }
}
