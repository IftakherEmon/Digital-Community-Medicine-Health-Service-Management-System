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
    public partial class FrmAdminDashboard : Form
    {
        public FrmAdminDashboard()
        {
            InitializeComponent();
        }

        private void btnDoctorApproval_Click(object sender, EventArgs e)
        {
            FrmPendingDoctors pd = new FrmPendingDoctors();
            pd.Show();
            this.Hide();
        }

        private void btnPaymentVerification_Click(object sender, EventArgs e)
        {
            FrmPaymentList pl = new FrmPaymentList();
            pl.Show();
            this.Hide();

        }

        private void btnEmergencyRequests_Click(object sender, EventArgs e)
        {
            FrmEmergencyRequests er = new FrmEmergencyRequests();
            er.Show();
            this.Hide();

        }

        private void btnAmbulanceManagement_Click(object sender, EventArgs e)
        {
            FrmAmbulanceList al = new FrmAmbulanceList();
            al.Show();
            this.Hide();

        }

        private void btnComplaintManagement_Click(object sender, EventArgs e)
        {
            FrmComplaintList cl = new FrmComplaintList();
            cl.Show();
            this.Hide();

        }

        private void btnDiagnosticLab_Click(object sender, EventArgs e)
        {
            FrmLabList lab = new FrmLabList();
            lab.Show();
            this.Hide();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmSystemReport sr = new FrmSystemReport();
            sr.Show();
            this.Hide();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Session clear
            Session.UserId = 0;
            Session.Role = null;

            FrmLogin login = new FrmLogin();
            login.Show();
            this.Hide();

        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Admin";
        }

        private void btnManageClinic_Click(object sender, EventArgs e)
        {
            FrmManageClinic mc = new FrmManageClinic();
            mc.Show();
            this.Hide();
        }
    }
}
