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
        }

        private void cb_doNotShow_CheckedChanged(object sender, EventArgs e)
        {
            SQLGenWrapper.doNotShowSQLPrerequisites = cb_doNotShow.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
