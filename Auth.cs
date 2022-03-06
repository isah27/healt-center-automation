using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace FACCID
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        void managementForm()
        {
            MANAGEMENTVIEW m = new MANAGEMENTVIEW();
            m.Show();
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            DbAuthentication();
        }
        private void DbAuthentication()
        {
            string password = textBox1.Text.Trim();
            if (password != "")
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                {

                    sqlcon.Open();
                    string Query = "SELECT Password FROM PASSWORD";
                    SQLiteDataAdapter sqladp = new SQLiteDataAdapter(Query, sqlcon);
                    DataTable dt = new DataTable();
                    sqladp.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        string pasword = null;
                        foreach (DataRow dr in dt.Rows)
                            pasword = (string)dr["Password"];

                        if (pasword == textBox1.Text.Trim())
                        {
                            managementForm();
                        }
                        else
                        {
                            HOME h = new HOME();
                            h.Show();
                            this.Close();
                        }

                    }
                    else
                    {
                        string querry = "INSERT INTO PASSWORD (Password)VALUES(@Password)";
                        SQLiteCommand cmd = new SQLiteCommand(querry, sqlcon);
                        cmd.Parameters.AddWithValue("@Password", textBox1.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password Saved");
                        managementForm();
                    }
                    sqlcon.Close();

                }
            
        }
            else
            {
                MessageBox.Show("PLEASE ENTER A VALID PASSWORD");
            }
        }   
    }
}
