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
    public partial class AddServerManually : Form
    {
        public AddServerManually()
        {
            InitializeComponent();
        }

        private void tb_IP_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_IP_Validating(object sender, CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_UserName_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_UserName_Validating(object sender, CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Password_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Password_Validating(object sender, CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ServerWrapper.AddServerManually(tb_IP.Text,tb_UserName.Text,tb_Password.Text);
            tb_IP.Clear();
            tb_UserName.Clear();
            tb_Password.Clear();
        }

        private void tb_IP_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            this.btn_Add.Enabled = !string.IsNullOrWhiteSpace(tb_IP.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_UserName.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_Password.Text);
        }

        private void tb_UserName_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }
    }
}
