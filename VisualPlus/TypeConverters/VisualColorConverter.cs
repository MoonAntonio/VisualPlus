#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

#endregion

namespace VisualPlus.TypeConverters
{
    public class VisualColorConverter : ColorConverter
    {
        #region Overrides

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object result = null;

            if (value is Color color && (destinationType == typeof(string)))
            {
                string alpha = Convert.ToInt32(color.A).ToString();
                string red = Convert.ToInt32(color.R).ToString();
                string green = Convert.ToInt32(color.G).ToString();
                string blue = Convert.ToInt32(color.B).ToString();

                string text = $@"{alpha}, {red}, {green}, {blue}";
                result = text;
            }

            return result ?? base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #endregion
    }
}