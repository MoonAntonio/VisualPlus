#region Namespace

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

using VisualPlus.Toolkit.Child;

#endregion

namespace VisualPlus.TypeConverters
{
    public class VisualListViewColumnConverter : TypeConverter
    {
        #region Overrides

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(InstanceDescriptor)) && value is VisualListViewColumn column)
            {
                ConstructorInfo _constructorInfo = typeof(VisualListViewColumn).GetConstructor(new Type[] { });
                if (_constructorInfo != null)
                {
                    return new InstanceDescriptor(_constructorInfo, null, false);
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        #endregion
    }
}