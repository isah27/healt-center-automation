
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FACCID
{
    public partial class ATTENDACE : Form
    {
      
       
        public ATTENDACE()
        {
            InitializeComponent();
        }
        void HOME()
        {
            HOME h = new HOME();
            h.Show();
            this.Close();
        }
        private void CheckInBtn_Click(object sender, EventArgs e)
        {
          if(textBox1.Text!="")
            {
                checkin();
               
                textBox1.Text="";
                
            }
            else
            {
                MessageBox.Show("Fill up the required information");
            }
        }
        void checkin()
        {
            bool realName = false;
            using (SQLiteConnection con = new SQLiteConnection(connections.connectionStrings()))
            {
                string sex = null;
                string cart = null;
                string name = null;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SQLiteDataAdapter adpt = new SQLiteDataAdapter("select * from StaffReg", con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                    foreach (DataRow dr in dt.Rows)
                    {
                        string testName = textBox1.Text.ToUpper();
                        name = (string)dr["NAME"];
                        cart = (string)dr["CATEGORY"];

                        if (name == testName)
                        {
                            realName = true;

                        }
                       

                    }
                if (realName == true)
                {
                    MarkAttendance(cart);
                }
                else
                {
                    MessageBox.Show("INVALID DETAILS!!");
                    return;
                }
                realName = false;
                        
                


            }
        }
        void MarkAttendance(string cart)
        {
            try
            {
                string name = textBox1.Text.ToUpper();
               

                using (SQLiteConnection con = new SQLiteConnection(connections.connectionStrings()))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SQLiteCommand cmd = new SQLiteCommand("insert into StaffAttendance(NAME,CATEGORY,DATE,TIME) values (@name,@cat,@date,@time)", con);
                    cmd.Parameters.AddWithValue("@cat", cart);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SUCCESSFUL!!");
                    textBox1.Visible = false;
                    label2.Visible = false;
                    label1.Visible = false;
                    label5.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckOutBtn_Click(object sender, EventArgs e)
        {
           
        }       
        
       
        
        private void HOMEbTN_Click(object sender, EventArgs e)
        {
            HOME();
            
        }

        private void NOTICEBOARDbTN_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "NOTICE BOARD")
                {
                    isOpen = true;
                    f.BringToFront();

                    break;
                }
            }

            if (isOpen == false)
            {
                noticeBoardView N = new noticeBoardView();
                N.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckInBtn.Visible = true;
            textBox1.Visible = true;
           
            label1.Visible = true;
            label2.Visible = true;
            
            label5.Visible = false;
        }
    }
}
