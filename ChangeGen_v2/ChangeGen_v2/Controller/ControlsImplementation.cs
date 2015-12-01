using System.Collections.Generic;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    static class ControlsImplementation
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

        public static void selectUnselectAll(ListView listview, bool selectAll)
        {
            if (selectAll)
            {
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    listview.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    listview.Items[i].Checked = false;
                }
            }
        }
    }
}
