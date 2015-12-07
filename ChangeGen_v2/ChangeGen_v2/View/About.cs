using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();

            lbl_About_description.Text = "If you have questions, you want to report issues," +Environment.NewLine+
                                         "bugs, or you have ideas for new features," +Environment.NewLine+
                                         "please visit link below or send an email" +Environment.NewLine+
                                         "to artem.bezzubets@software.dell.com";

            linkGDrive.Links.Remove(linkGDrive.Links[0]);
            linkGDrive.Links.Add(0, linkGDrive.Text.Length, "https://docs.google.com/document/d/1mZUMl7JOvwqQ_AZS1wubY89uyoFP8BAwmu3Ubu4HnYs/edit?usp=sharing");
        }

        private void linkGDrive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }
    }
}
