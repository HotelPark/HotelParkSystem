using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayerWP
{
    public class FormCleaner
    {
        public static void Clear(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item.HasChildren)
                {
                    Clear(item);
                }
                if (item is TextBoxBase)
                {
                    item.Text = "";
                }
                else if (item is ComboBox)
                {
                    ComboBox combo = (ComboBox)item;
                    combo.SelectedIndex = -1;
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now;
                }
            }
        }
    }
}
