﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    internal static class Validator
    {

        public static void TextBox_ValidatingEmpty(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {          
            string errorMsg;
            if (StringNotEmpty(textBox.Text, out errorMsg)) return;
            e.Cancel = true;


            errorProvider.SetError(textBox, errorMsg);
        }

        public static void TextBox_ValidatingPort(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            string errorMsg;
            if (StringNotEmpty(textBox.Text, out errorMsg) && ValidPort(textBox.Text, out errorMsg)) return;
            e.Cancel = true;

            errorProvider.SetError(textBox, errorMsg);
        }

        public static void TextBox_ValidatingNumeric(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            string errorMsg;
            if (ValueIsNumeric(textBox.Text, out errorMsg) && StringNotEmpty(textBox.Text, out errorMsg) && ValueNotNegative(textBox.Text, out errorMsg)) return;
            e.Cancel = true;

            errorProvider.SetError(textBox, errorMsg);
        }

        public static void TextBox_ValidatingCompression(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            string errorMsg;
            if (StringNotEmpty(textBox.Text, out errorMsg) && ValidCompression(textBox.Text, out errorMsg)) return;
            e.Cancel = true;

            errorProvider.SetError(textBox, errorMsg);
        }

        public static void TextBox_Validated(TextBox textBox, ErrorProvider errorProvider)
        {
            errorProvider.SetError(textBox, "");
        }

        private static bool StringNotEmpty(string text, out string errorMessage)
        {
            if (text.Length == 0)
            {
                errorMessage = "Value required.";
                return false;
            }
            errorMessage = "";
            return true;
        }

        private static bool ValidPort(string port, out string errorMessage)
        {
            if (Convert.ToInt32(port) < 0 || Convert.ToInt32(port) > 65535)
            {
                errorMessage = "Port value should be between 0-65535";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private static bool ValueNotNegative(string message, out string errorMessage)
        {
            if (Convert.ToInt32(message) < 0)
            {
                errorMessage = "Value should not be negative.";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private static bool ValidCompression(string compression, out string errorMessage)
        {
            if (Convert.ToInt32(compression) < 0 || Convert.ToInt32(compression) > 100)
            {
                errorMessage = "Compression parameter should be between 0-100";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private static bool ValueIsNumeric(string message, out string errorMessage)
        {
            int result;
            if (!int.TryParse(message, out result))
            {
                errorMessage = "Value should be a number.";
                return false;
            }

            errorMessage = "";
            return true;
        }
    }
}
