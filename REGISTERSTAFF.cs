using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FACCID
{
    public partial class REGISTERSTAFF : Form
    {
        #region variable
        DataTable tb;
        List<string> personNames = new List<string>();
        #endregion
        public REGISTERSTAFF()
        {
            InitializeComponent();
            populateDGV();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(NameTbox.Text != "" && AddressTbox.Text != ""&& CatTbox.Text != ""&& SexTbox.Text != "")
            {
                string name = NameTbox.Text.ToUpper();
                string cat = CatTbox.Text.ToUpper();
                string sex = SexTbox.Text.ToUpper();
                string address = AddressTbox.Text.ToUpper();
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(connections.connectionStrings()))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SQLiteCommand cmd = new SQLiteCommand("insert into StaffReg (NAME,ADDRESS,CATEGORY, SEX) values (@name,@address,@category,@sex)" , con);
                        
                        cmd.Parameters.AddWithValue("@name", name);

                        cmd.Parameters.AddWithValue("@category", cat);
                        cmd.Parameters.AddWithValue("@sex",sex );
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.ExecuteNonQuery();
                        populateDGV();
                        con.Close();
                        MessageBox.Show("Record added Successfully!!");
                        NameTbox.Text = "";
                        AddressTbox.Text = "";
                        CatTbox.Text = "";
                        SexTbox.Text = "";
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("FILL UP THE REQUIRED INFORMATION ABOVE");
            }
            
        }

       
       
        void populateDGV()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connections.connectionStrings()))
                {

                    SQLiteDataAdapter adpta = new SQLiteDataAdapter("SELECT * FROM StaffReg", con);
                    tb = new DataTable();
                    adpta.Fill(tb);
                    dataGridView1.DataSource = tb;
                    dataGridView1.Columns[0].Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        private void REGISTERSTAFF_Load(object sender, EventArgs e)
        {

        }
        

        private void dataGridView1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Id"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Are you Sure to Delete this Record", "DataTable", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                    {
                        sqlcon.Open();
                        SQLiteCommand sqlcmd = new SQLiteCommand("DELETE FROM StaffReg WHERE Id=@Id", sqlcon);
                        
                        sqlcmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value));
                        sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                    
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }
        void fillDataGridView()
        {
            DataView DV = new DataView(tb);
            DV.RowFilter = string.Format("NAME LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void SexTbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SexTbox.CheckState == CheckState.Checked)
                SexTbox.Text = "MALE";
            else if (SexTbox.CheckState == CheckState.Unchecked)
                SexTbox.Text = "FEMALE";
            else
                SexTbox.Text = "??";
        }
    }
}
