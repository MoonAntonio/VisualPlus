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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState CloseButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState CloseButtonFore { get; set; }

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState HelpButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState HelpButtonFore { get; set; }

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
        public Color LightText { get; set; }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(VisualColorConverter))]
        public Color Line { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MaximizeButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MaximizeButtonFore { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MinimizeButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MinimizeButtonFore { get; set; }

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState ScrollBar { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState ScrollButton { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState ScrollThumb { get; set; }

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