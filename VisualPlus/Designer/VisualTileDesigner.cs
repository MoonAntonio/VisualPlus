#region Namespace

using System.Collections;
using System.Windows.Forms.Design;

#endregion

namespace VisualPlus.Designer
{
    internal class VisualTileDesigner : ControlDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("ImeMode");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}