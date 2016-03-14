using System;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class ExchangePrerequisites : Form
    {
        public ExchangePrerequisites()
        {
            InitializeComponent();
            lbl_prerequisitesText.Text =
                "* Circular logging enabled for exchange database.\n" +
                "* Database limits set to 'Unlimited' or to other value that corresponds expected generated amount.\n" +
                "* Exchange server DNS correctly configured. (Usually default settings is OK).\n" +
                "Note: In current implementation of exchange generations all messages\n" +
                "          will be sent from and to administrator's mailbox.\n" +
                "          In future versions it will be possible to specify sender and recipient explicitly.";
        }

        private void cb_doNotShow_CheckedChanged(object sender, EventArgs e)
        {
           ExchangeGenWrapper.DoNotShowExchangePrerequisites = cb_doNotShow.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
