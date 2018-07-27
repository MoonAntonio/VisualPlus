#region Namespace

using System;
using System.ComponentModel;
using System.Globalization;

#endregion

namespace VisualPlus.TypeConverters
{
    public class VisualSettingsTypeConverter : ExpandableObjectConverter
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
            return $@"{value.GetType().Name} Settings";
        }

        #endregion
    }
}