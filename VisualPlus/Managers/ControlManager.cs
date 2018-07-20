#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using VisualPlus.Native;
using VisualPlus.Toolkit.Controls.DataManagement;
using VisualPlus.Toolkit.Controls.DataVisualization;
using VisualPlus.Toolkit.Controls.Editors;
using VisualPlus.Toolkit.Controls.Interactivity;
using VisualPlus.Toolkit.Controls.Layout;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualPlus.Managers
{
    [Description("The control manager.")]
    public sealed class ControlManager
    {
        #region Properties

        /// <summary>Determines if the composition is currently enabled for the deskop.</summary>
        public static bool IsCompositionEnabled
        {
            get
            {
                // Desktop composition is only available on Vista upwards
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return false;
                }
                else
                {
                    // Ask the desktop window manager is composition is currently enabled
                    bool compositionEnabled;
                    Dwmapi.DwmIsCompositionEnabled(out compositionEnabled);
                    return compositionEnabled;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>Centers the control inside the parent control.</summary>
        /// <param name="control">The control to center.</param>
        /// <param name="parent">The parent control.</param>
        /// <param name="centerX">Center X coordinate.</param>
        /// <param name="centerY">Center Y coordinate.</param>
        public static void CenterControl(Control control, Control parent, bool centerX, bool centerY)
        {
            Point _controlLocation = control.Location;

            if (centerX)
            {
                _controlLocation.X = (parent.Width - control.Width) / 2;
            }

            if (centerY)
            {
                _controlLocation.Y = (parent.Height - control.Height) / 2;
            }

            control.Location = _controlLocation;
        }

        /// <summary>Gets the checked VisualRadioButton.</summary>
        /// <param name="control">The container control.</param>
        /// <returns>The checked VisualRadioButton.</returns>
        public static VisualRadioButton GetCheckedFromContainer(Control control)
        {
            return control.Controls.OfType<VisualRadioButton>().FirstOrDefault(r => r.Checked);
        }

        /// <summary>Gets the namespace location from the control.</summary>
        /// <param name="controlName">The control Name.</param>
        /// <returns>Returns namespace name.</returns>
        public static string GetControlNamespace(Control controlName)
        {
            return controlName.GetType().Namespace;
        }

        /// <summary>Determines whether the object has the method.</summary>
        /// <param name="objectToCheck">The object.</param>
        /// <param name="methodName">The method name.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool HasMethod(object objectToCheck, string methodName)
        {
            Type _methodType = objectToCheck.GetType();
            return _methodType.GetMethod(methodName) != null;
        }

        /// <summary>Retrieves the registered theme supported types.</summary>
        /// <returns>The <see cref="Type" /> list.</returns>
        public static List<Type> ThemeSupportedTypes()
        {
            var control = new List<Type>
                {
                    typeof(VisualButton),
                    typeof(VisualCheckBox),
                    typeof(VisualComboBox),
                    typeof(VisualDateTimePicker),
                    typeof(VisualForm),
                    typeof(VisualGauge),
                    typeof(VisualGroupBox),
                    typeof(VisualLabel),
                    typeof(VisualListBox),
                    typeof(VisualListView),
                    typeof(VisualNumericUpDown),
                    typeof(VisualPanel),
                    typeof(VisualProgressBar),
                    typeof(VisualRadialProgress),
                    typeof(VisualRadioButton),
                    typeof(VisualRichTextBox),
                    typeof(VisualScrollBar),
                    typeof(VisualSeparator),
                    typeof(VisualTextBox),
                    typeof(VisualToggle),
                    typeof(VisualTrackBar)
                };

            return control;
        }

        #endregion
    }
}