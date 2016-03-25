using System.Collections.Generic;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    internal static class ControlsImplementation
    {
        // This method displays controls for ListView Page
        public static void ChangePage(List<Control> pageToHide, List<Control> pageToShow)
        {
            foreach (var control in pageToHide)
            {
                control.Visible = false;
            }

            foreach (var control in pageToShow)
            {
                control.Visible = true;
            }
        }

        public static void SelectUnselectAll(ListView listview, bool selectAll)
        {
            if (selectAll)
            {
                for (var i = 0; i < listview.Items.Count; i++)
                {
                    listview.Items[i].Checked = true;
                }
            }
            else
            {
                for (var i = 0; i < listview.Items.Count; i++)
                {
                    listview.Items[i].Checked = false;
                }
            }
        }
    }
}
