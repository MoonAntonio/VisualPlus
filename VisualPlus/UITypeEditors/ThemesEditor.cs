#region Namespace

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using VisualPlus.Constants;

#endregion

namespace VisualPlus.UITypeEditors
{
    public class ThemesEditor : UITypeEditor
    {
        #region Overrides

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context == null) || (provider == null))
            {
                return base.EditValue(context, provider, value);
            }

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService == null)
            {
                return base.EditValue(context, provider, value);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    FileName = string.Empty,
                    Filter = SettingConstants.ThemeExtensionSupportedFileFilter,
                    InitialDirectory = SettingConstants.TemplatesFolder,
                    Multiselect = false,
                    Title = @"Browse for theme..."
                };

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : base.EditValue(context, provider, value);
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        #endregion
    }
}