﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class AddExchangeServerManually : Form
    {
        public AddExchangeServerManually()
        {
            InitializeComponent();
        }

        private void tb_IP_TextChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void tb_domain_TextChanged(object sender, EventArgs e)
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ServerWrapper.AddExchangeServerManually(tb_IP.Text, tb_domain.Text, tb_UserName.Text, tb_Password.Text);
            tb_IP.Clear();
            tb_UserName.Clear();
            tb_Password.Clear();
            tb_domain.Clear();
            tb_IP.Focus();
        }

        private void UpdateAddButtonState()
        {
            btn_Add.Enabled = !string.IsNullOrWhiteSpace(tb_IP.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_UserName.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_Password.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_domain.Text);
        }

        private void tb_IP_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_IP_Validating(object sender, CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_domain_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_domain_Validating(object sender, CancelEventArgs e)
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
    }
}