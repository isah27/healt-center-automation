using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace FACCID
{
    public partial class NoticeBoard : Form
    {
      
        DataTable dtbl;

        public NoticeBoard()
        {
            InitializeComponent();
          
            populateDGV();
        }
        void populateDGV()
        {
            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                {
                    sqlcon.Open();
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter("SELECT * FROM NOTICEBOARD", sqlcon);
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
        void fillDataGridView()
        {
            DataView DV = new DataView(dtbl);
            DV.RowFilter = string.Format("TITLE LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }
      
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells["IDTXT"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Are you Sure to Delete this Record", "DataTable", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                    {
                        sqlcon.Open();
                        SQLiteCommand sqlcmd = new SQLiteCommand("DELETE FROM NOTICEBOARD WHERE Id=@ID", sqlcon);
                        sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDTXT"].Value));
                        sqlcmd.ExecuteNonQuery();

                    }
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void NoticeBoard_Load(object sender, EventArgs e)
        {

        }
        void PostNotice()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connections.connectionStrings()))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("insert into NOTICEBOARD (TITLE,DATE,INFORMATION) values (@TITLE,@DATE,@INFORMATION)", conn);
                cmd.Parameters.AddWithValue("@TITLE", TITLEINFO.Text);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@INFORMATION", INFONOTICE.Text);
                cmd.ExecuteNonQuery();
                clear();
            }
            populateDGV();
        }
        private void POSTBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >1)
            {
                if (!dataGridView1.CurrentRow.Selected)
                {
                    if (INFONOTICE.Text != "" && TITLEINFO.Text != "")
                    {
                        PostNotice();
                    }
                }
            }
            else
            {
                if (INFONOTICE.Text != "" && TITLEINFO.Text != "")
                {
                    PostNotice();
                }
            }
        }
        void clear()
        {
            INFONOTICE.Text = "";
            TITLEINFO.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    Update();
                }
                
            }
           
        }
        void Update()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connections.connectionStrings()))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("UPDATE NOTICEBOARD SET TITLE=@TITLE,DATE=@DATE,INFORMATION=@INFORMATION WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@TITLE", TITLEINFO.Text);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@INFORMATION", INFONOTICE.Text);
                cmd.ExecuteNonQuery();
                clear();
                populateDGV();
            }
            
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                fillDataGridView();
            }
            else
            {
                populateDGV();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    TITLEINFO.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    INFONOTICE.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    
                }
                else
                {
                    clear();
                }
            }
        }
    }
}

