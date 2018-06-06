namespace VisualPlus.TypeConverters
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    using System.Reflection;

    using VisualPlus.Toolkit.Child;

    #endregion

    public class VisualListViewItemConverter : TypeConverter
    {
        #region Events

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
            if ((destinationType == typeof(InstanceDescriptor)) && value is VisualListViewItem item)
            {
                ConstructorInfo _constructorInfo = typeof(VisualListViewItem).GetConstructor(new Type[] { });
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