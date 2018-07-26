#region Namespace

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

using VisualPlus.UITypeEditors;

#endregion

namespace VisualPlus.Structure
{
    public class ColorPalette
    {
        #region Properties

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color BackCircle { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color BorderHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color BorderNormal { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color BoxDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color BoxEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonBackDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonBackEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonBackHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonBackPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonForeDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonForeEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonForeHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color CloseButtonForePressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ColumnHeader { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ColumnText { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ControlDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ControlEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Disabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Enabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color FlatControlDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color FlatControlEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ForeCircle { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color FormBackground { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color FormWindowBar { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HatchBackColor { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HatchForeColor { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonBackDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonBackEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonBackHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonBackPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonForeDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonForeEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonForeHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color HelpButtonForePressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Hover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Item { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ItemAlternate { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ItemHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ItemSelected { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TextLight { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Line { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonBackDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonBackEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonBackHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonBackPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonForeDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonForeEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonForeHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MaximizeButtonForePressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonBackDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonBackEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonBackHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonBackPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonForeDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonForeEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonForeHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color MinimizeButtonForePressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Pressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Progress { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ProgressBackground { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ProgressDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollBarDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollBarEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollButtonDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollButtonEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollButtonHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollButtonPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollThumbDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollThumbEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollThumbHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color ScrollThumbPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Selected { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Shadow { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color SubscriptColor { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color SuperscriptColor { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TabPageDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TabPageEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TabPageHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TabPageSelected { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TextDisabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TextEnabled { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TextHover { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color TextPressed { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Type1 { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Type2 { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Type3 { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Type4 { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color WatermarkActive { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color WatermarkInactive { get; set; }

        #endregion
    }
}