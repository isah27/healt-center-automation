using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FACCID
{
    public partial class CHANGEPASSWORD : Form
    {

        public CHANGEPASSWORD()
        {
            InitializeComponent();
        }
        void CLEARTEXT()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void ChangeBtn_Click(object sender, EventArgs e)
        {

           
            using(SQLiteConnection con= new SQLiteConnection(connections.connectionStrings()))
            {
                string pasword = null;
                con.Open();
                
                SQLiteCommand cmd = new SQLiteCommand("UPDATE PASSWORD SET Password=@password", con);
                string Query = "SELECT Password FROM PASSWORD";
                SQLiteDataAdapter sqladp = new SQLiteDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sqladp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                    pasword = (string)dr["Password"];
                if (pasword == textBox1.Text.Trim())
                {
                    if (textBox2.Text.Trim() == textBox3.Text.Trim())
                    {
                        cmd.Parameters.AddWithValue("@password", textBox3.Text.Trim());
                        cmd.ExecuteNonQuery();
                        CLEARTEXT();
                        MessageBox.Show("CHANGE PASSWORD SUCCESSFUL");
                    }
                    else
                    {
                        MessageBox.Show("New password does not match the confirm password");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Initial Password");
                }
            }
           
    
        }
    }
}
