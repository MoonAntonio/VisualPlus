#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

#endregion

namespace VisualPlus.UITypeEditors
{
    internal class ColorEditor : UITypeEditor
    {
        #region Overrides

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ColorDialog colorDialog = new ColorDialog
                    {
                       FullOpen = true 
                    };

            Color editColorValue = Color.Black;
            colorDialog.SolidColorOnly = false;

            if (value != null)
            {
                editColorValue = (Color)value;
            }

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                editColorValue = colorDialog.Color;
            }

            return editColorValue;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        #endregion
    }

    internal class VisualColorConverter : ColorConverter
    {
        #region Overrides

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #endregion
    }
}