#region Namespace

using System.ComponentModel;
using System.Drawing;

#endregion

namespace VisualPlus.TypeConverters
{
    public class VisualColorConverter : ColorConverter
    {
        #region Overrides

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #endregion
    }
}