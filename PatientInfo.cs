using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FACCID
{
    public partial class PatientInfo : Form
    {

        DataTable dtbl;

        public PatientInfo()
        {
            InitializeComponent();
            populateDGV();
        }
        void fillDataGridView()
        {
            DataView DV = new DataView(dtbl);
            DV.RowFilter = string.Format("NAME LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
            dataGridView1.Columns[0].Visible = false;
        }
       
        void populateDGV()
        {
            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                {
                    sqlcon.Open();
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter("SELECT * FROM PatientInfo", sqlcon);
                    dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    dataGridView1.Columns[0].Visible = false;
                   
                    //dataGridView1.Refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillDataGridView();
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
                        SQLiteCommand sqlcmd = new SQLiteCommand("DELETE FROM PatientInfo WHERE Id=@Id", sqlcon);
                     
                        sqlcmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value));
                        sqlcmd.ExecuteNonQuery();

                    }
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }
        void SAVEPATIENT()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connections.connectionStrings()))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("insert into PatientInfo (NAME,SEX,ADDRESS, [HEALTH INFORMATION]) values (@NAME,@SEX,@ADDRESS,@HEALTH_INFORMATION)", conn);
                cmd.Parameters.AddWithValue("@NAME", NameTbox.Text);
                cmd.Parameters.AddWithValue("@SEX", SexCheckBox.Text);
                cmd.Parameters.AddWithValue("@ADDRESS", AddressTbox.Text);
                cmd.Parameters.AddWithValue("@HEALTH_INFORMATION", HealthInfoTbox.Text);
                cmd.ExecuteNonQuery();
                clear();
            }
            populateDGV();
        }
        void clear()
        {
            NameTbox.Text = "";
            SexCheckBox.Text = "?";
            AddressTbox.Text = "";
            HealthInfoTbox.Text = "";
        }
        private void Update()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connections.connectionStrings()))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE PatientInfo SET NAME=@NAME,SEX=@SEX,[HEALTH INFORMATION]=@HEALTH_INFORMATION WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@NAME", NameTbox.Text);
                cmd.Parameters.AddWithValue("@SEX", SexCheckBox.Text);
                cmd.Parameters.AddWithValue("@ADDRESS", AddressTbox.Text);
                cmd.Parameters.AddWithValue("@HEALTH_INFORMATION", HealthInfoTbox.Text);
                cmd.ExecuteNonQuery();
                clear();
                populateDGV();
            }

        }
        private void SAVEBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (!dataGridView1.CurrentRow.Selected)
                {
                    if (NameTbox.Text != "" && SexCheckBox.Text != "" && AddressTbox.Text != "" && HealthInfoTbox.Text != "")
                    {
                        SAVEPATIENT();
                    }
                }
            }
            else
            {
                if (NameTbox.Text != "" && SexCheckBox.Text != "" && AddressTbox.Text != "" && HealthInfoTbox.Text != "")
                {
                    SAVEPATIENT();
                }
            }
            
        }

        private void UPDATEBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    if (NameTbox.Text != "" && SexCheckBox.Text != "" && AddressTbox.Text != "" && HealthInfoTbox.Text != "")
                    {
                        Update();
                    }
                }
            }
              
        }

        private void SexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SexCheckBox.CheckState == CheckState.Checked)
            {
                SexCheckBox.Text = "MALE";
            }
            else if (SexCheckBox.CheckState == CheckState.Unchecked)
            {
                SexCheckBox.Text = "FEMALE";
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    NameTbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    SexCheckBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    AddressTbox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    HealthInfoTbox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


                }
                else
                {
                    clear();
                }
            }
        }
    }
}
