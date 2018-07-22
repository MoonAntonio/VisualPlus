#region Namespace

using System.ComponentModel;
using System.Drawing;

#endregion

namespace VisualPlus.Structure
{
    public class ColorPalette
    {
        #region Properties

        public Color BackCircle { get; set; }

        public Color BorderHover { get; set; }

        public Color BorderNormal { get; set; }

        public Color BoxDisabled { get; set; }

        public Color BoxEnabled { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState CloseButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState CloseButtonFore { get; set; }

        public Color ColumnHeader { get; set; }

        public Color ColumnText { get; set; }

        public Color ControlDisabled { get; set; }

        public Color ControlEnabled { get; set; }

        public Color Disabled { get; set; }

        public Color Enabled { get; set; }

        public Color FlatControlDisabled { get; set; }

        public Color FlatControlEnabled { get; set; }

        // public Font Font { get; set; }
        public Color ForeCircle { get; set; }

        public Color FormBackground { get; set; }

        public Color FormWindowBar { get; set; }

        public Color HatchBackColor { get; set; }

        public Color HatchForeColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState HelpButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState HelpButtonFore { get; set; }

        public Color Hover { get; set; }

        public Color Item { get; set; }

        public Color ItemAlternate { get; set; }

        public Color ItemHover { get; set; }

        public Color ItemSelected { get; set; }

        public Color LightText { get; set; }

        public Color Line { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MaximizeButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MaximizeButtonFore { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MinimizeButtonBack { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState MinimizeButtonFore { get; set; }

        public Color Pressed { get; set; }

        public Color Progress { get; set; }

        public Color ProgressBackground { get; set; }

        public Color ProgressDisabled { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState ScrollBar { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState ScrollButton { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState ScrollThumb { get; set; }

        public Color Selected { get; set; }

        public Color Shadow { get; set; }

        public Color SubscriptColor { get; set; }

        public Color SuperscriptColor { get; set; }

        public Color TabPageDisabled { get; set; }

        public Color TabPageEnabled { get; set; }

        public Color TabPageHover { get; set; }

        public Color TabPageSelected { get; set; }

        public Color TextDisabled { get; set; }

        public Color TextEnabled { get; set; }

        public Color TextHover { get; set; }

        public Color Type1 { get; set; }

        public Color Type2 { get; set; }

        public Color Type3 { get; set; }

        public Color Type4 { get; set; }

        public Color WatermarkActive { get; set; }

        public Color WatermarkInactive { get; set; }

        #endregion
    }
}