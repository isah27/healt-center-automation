using System;
using System.Windows.Forms;

namespace FACCID
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MANAGEMENTBtn_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if (f.Text == "Auth")
                {
                    isOpen = true;
                    f.BringToFront();
                    Hide();
                    break;
                }
            }

            if (isOpen == false)
            {
                Auth a = new Auth();
                a.Show();
                Hide();
            }
           
        }

        private void AttendaceBtn_Click(object sender, EventArgs e)
        {
            ATTENDACE a = new ATTENDACE();
            a.Show();
            this.Hide();
        }

        private void HOME_Load(object sender, EventArgs e)
        {

        }
    }
}
