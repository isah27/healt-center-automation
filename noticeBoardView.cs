using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FACCID
{
    public partial class noticeBoardView : Form
    {

        public noticeBoardView()
        {
            InitializeComponent();
            populateDGV();
        }

        private void noticeBoardView_Load(object sender, EventArgs e)
        {

        }
        void populateDGV()
        {
            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection(connections.connectionStrings()))
                {
                    sqlcon.Open();
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter("SELECT * FROM NOTICEBOARD", sqlcon);
                    DataTable dtbl = new DataTable();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
