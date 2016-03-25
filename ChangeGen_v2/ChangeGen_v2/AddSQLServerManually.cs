using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class AddSqlServerManually : Form
    {
        public AddSqlServerManually()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ServerWrapper.AddSqlServerManually(tb_IP.Text,tb_UserName.Text,tb_Password.Text);
            tb_IP.Clear();
            tb_UserName.Clear();
            tb_Password.Clear();
            tb_IP.Focus();
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

        private void tb_IP_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void tb_UserName_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            btn_Add.Enabled = !string.IsNullOrWhiteSpace(tb_IP.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_UserName.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_Password.Text);
        }
    }
}
