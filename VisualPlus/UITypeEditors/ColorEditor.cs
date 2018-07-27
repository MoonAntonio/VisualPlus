#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualPlus.UITypeEditors
{
    public class ColorEditor : UITypeEditor
    {
        #region Overrides

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Color defaultDialogColor = Color.Black;

            if (value != null)
            {
                defaultDialogColor = (Color)value;
            }

            VisualColorDialog colorDialog = new VisualColorDialog(defaultDialogColor);
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                defaultDialogColor = colorDialog.Color;
            }

            return defaultDialogColor;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            Color color = (Color)e.Value;
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        }

        #endregion
    }
}