#region Namespace

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace VisualPlus.Designer
{
    internal class VisualControlBoxButtonDesigner : ControlDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("AccessibleDescription");
            properties.Remove("AccessibleName");
            properties.Remove("AccessibleRole");
            properties.Remove("AllowDrop");
            properties.Remove("AutoEllipsis");
            properties.Remove("BackColor");
            properties.Remove("Dock");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("RightToLeft");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("Visible");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}