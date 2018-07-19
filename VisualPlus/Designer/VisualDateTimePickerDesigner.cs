#region Namespace

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace VisualPlus.Designer
{
    internal class VisualDateTimePickerDesigner : ControlDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("RightToLeft");

            properties.Remove("CalendarFont");
            properties.Remove("CalendarForeColor");
            properties.Remove("CalendarMonthBackground");
            properties.Remove("CalendarTitleBackColor");
            properties.Remove("CalendarTitleForeColor");
            properties.Remove("CalendarTrailingForeColor");
            properties.Remove("DropDownAlign");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}