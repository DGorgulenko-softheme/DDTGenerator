using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
