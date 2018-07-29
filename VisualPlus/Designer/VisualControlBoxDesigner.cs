#region Namespace

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace VisualPlus.Designer
{
    internal class VisualControlBoxDesigner : ControlDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("AllowDrop");
            properties.Remove("AutoEllipsis");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("RightToLeft");
            properties.Remove("Text");
            properties.Remove("UseCompatibleTextRendering");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}