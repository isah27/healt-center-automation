using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace FACCID
{
    public partial class STAFFATTENDANCEVIEW : Form
    {
        DataTable dt;
        public STAFFATTENDANCEVIEW()
        {
            InitializeComponent();
            PopulateDGV();
        }
       

       
        void PopulateDGV()
        {
           using(SQLiteConnection con= new SQLiteConnection(connections.connectionStrings()))
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter("SELECT * FROM StaffAttendance", con);
                dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
            }

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells["Id"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Are you Sure to Delete this Record", "DataTable", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                    {
                        sqlcon.Open();
                        SQLiteCommand sqlcmd = new SQLiteCommand("DELETE FROM StaffAttendance WHERE Id=@Id", sqlcon);
                       
                        sqlcmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value));
                        sqlcmd.ExecuteNonQuery();

                    }
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
            PopulateDGV();
        }

        void fillDataGridView()
        {

            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("CATEGORY LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }
    }
}
