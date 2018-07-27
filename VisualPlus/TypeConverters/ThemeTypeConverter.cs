#region Namespace

using System;
using System.ComponentModel;
using System.Globalization;

using VisualPlus.Structure;

#endregion

namespace VisualPlus.TypeConverters
{
    public class ThemeTypeConverter : ExpandableObjectConverter
    {
        #region Overrides

        /// <summary>Can convert context from source type.</summary>
        /// <param name="context">The context.</param>
        /// <param name="sourceType">The source type.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Sets the property to read only.
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object result = null;

            if (value is Theme theme && (destinationType == typeof(string)))
            {
                string text = $@"{theme.Information.Name} by {theme.Information.Author}";

                result = text;
            }

            return result ?? base.ConvertTo(context, culture, value, destinationType);
        }

        #endregion
    }
}