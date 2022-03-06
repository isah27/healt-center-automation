using System;
using System.Windows.Forms;

namespace FACCID
{
    public partial class MANAGEMENTVIEW : Form
    {
        public MANAGEMENTVIEW()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {

            HOME h = new HOME();
            h.Show();
            this.Close();
        }

        private void AttendanceBtn_Click(object sender, EventArgs e)
        {
            openNestForm(new STAFFATTENDANCEVIEW());
        }
        private Form activeForm = null;
        private void openNestForm(Form nestForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = nestForm;
            nestForm.TopLevel = false;
            nestForm.FormBorderStyle = FormBorderStyle.None;
            nestForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(nestForm);
            panel1.Tag = nestForm;
            nestForm.BringToFront();
            nestForm.Show();
        }

        private void RegStaffBtn_Click(object sender, EventArgs e)
        {
            openNestForm(new REGISTERSTAFF());
        }

        private void PatientInfoBtn_Click(object sender, EventArgs e)
        {
            openNestForm(new PatientInfo());
        }

        private void ChangePinBtn_Click(object sender, EventArgs e)
        {
            openNestForm(new CHANGEPASSWORD());
        }

        private void NoticeBtn_Click(object sender, EventArgs e)
        {
            openNestForm(new NoticeBoard());
        }
    }
}
