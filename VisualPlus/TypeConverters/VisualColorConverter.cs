using System.ComponentModel;
using System.Drawing;

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