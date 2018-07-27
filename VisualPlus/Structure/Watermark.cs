#region Namespace

using System.ComponentModel;
using System.Drawing;

using VisualPlus.Delegates;
using VisualPlus.Localization;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [Description("The watermark")]
    [TypeConverter(typeof(BasicSettingsTypeConverter))]
    public class Watermark
    {
        #region Variables

        private Color active;
        private SolidBrush brush;
        private Font font;
        private Color inactive;
        private string text;
        private bool visible;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Watermark" /> class.</summary>
        public Watermark()
        {
            Theme theme = new Theme(Settings.DefaultValue.DefaultStyle);

            active = theme.ColorPalette.WatermarkActive;
            inactive = theme.ColorPalette.WatermarkInactive;

            font = SystemFonts.DefaultFont;

            text = Settings.DefaultValue.WatermarkText;
            visible = Settings.DefaultValue.WatermarkVisible;

            brush = new SolidBrush(inactive);
        }

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the active color property has changed.")]
        public event WatermarkActiveColorChangedEventHandler ActiveColorChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the font property has changed.")]
        public event WatermarkFontChangedEventHandler FontChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the inactive property has changed.")]
        public event WatermarkInactiveColorChangedEventHandler InactiveColorChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the text property has changed.")]
        public event WatermarkTextChangedEventHandler TextChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the visible property has changed.")]
        public event WatermarkVisibleChangedEventHandler VisibleChanged;

        #endregion

        #region Properties

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color Active
        {
            get
            {
                return active;
            }

            set
            {
                if (active != value)
                {
                    active = value;
                    ActiveColorChanged?.Invoke();
                }
            }
        }

        /// <summary>The <see cref="Watermark" /> brush.</summary>
        [Browsable(false)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public SolidBrush Brush
        {
            get
            {
                return brush;
            }

            set
            {
                brush = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Font)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Font Font
        {
            get
            {
                return font;
            }

            set
            {
                if (!font.Equals(value))
                {
                    font = value;
                    FontChanged?.Invoke();
                }
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color Inactive
        {
            get
            {
                return inactive;
            }

            set
            {
                if (inactive != value)
                {
                    inactive = value;
                    InactiveColorChanged?.Invoke();
                }
            }
        }

        [Category(PropertyCategory.Data)]
        [Description(PropertyDescription.Text)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                if (text != value)
                {
                    text = value;
                    TextChanged?.Invoke();
                }
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Visible)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                if (visible != value)
                {
                    visible = value;
                    VisibleChanged?.Invoke();
                }
            }
        }

        #endregion
    }
}