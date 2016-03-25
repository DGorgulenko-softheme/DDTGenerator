using System;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class SQLPrerequisites : Form
    {
        public SQLPrerequisites()
        {
            InitializeComponent();
            lbl_prerequisitesText.Text =
               "* SQL server configured for remote access by IP.\n" +
               "* Database(s) for generation created.\n" +
               "Note: In current implementation of SQL generations server in domains is not supported.\n" +
               "          There are also some other cases where it will not work. Please let me know about such cases.\n"+
               "          In such cases try to run tool locally.\n" +
               "          In future versions it will be possible to specify different types of SQL connections.";
        }

        private void cb_doNotShow_CheckedChanged(object sender, EventArgs e)
        {
            SqlGenWrapper.DoNotShowSqlPrerequisites = cb_doNotShow.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
