#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
                    typeof(VisualTile),
                    typeof(VisualToggle),
                    typeof(VisualTrackBar)
                };

            return control;
        }

        #endregion
    }
}