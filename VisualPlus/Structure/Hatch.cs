#region Namespace

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

using VisualPlus.Localization;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [TypeConverter(typeof(BasicSettingsTypeConverter))]
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The Hatch structure.")]
    public class Hatch
    {
        #region Variables

        private Color _backColor;
        private Color _foreColor;
        private Size _size;
        private HatchStyle _style;
        private bool _visible;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Hatch" /> class.</summary>
        public Hatch()
        {
            Theme theme = new Theme(Settings.DefaultValue.DefaultStyle);

            _visible = Settings.DefaultValue.HatchVisible;
            _size = Settings.DefaultValue.HatchSize;
            _style = Settings.DefaultValue.HatchStyle;
            _backColor = theme.ColorPalette.HatchBackColor;
            _foreColor = Color.FromArgb(40, theme.ColorPalette.HatchForeColor);
        }

        /// <summary>Initializes a new instance of the <see cref="Hatch" /> class.</summary>
        /// <param name="visible">The visibility of the hatch.</param>
        /// <param name="size">The size of the hatch.</param>
        /// <param name="style">The style of the hatch.</param>
        /// <param name="backColor">The back Color.</param>
        /// <param name="foreColor">The fore Color.</param>
        public Hatch(bool visible, Size size, HatchStyle style, Color backColor, Color foreColor)
        {
            _visible = visible;
            _size = size;
            _style = style;
            _backColor = backColor;
            _foreColor = foreColor;
        }

        #endregion

        #region Properties

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        public Color BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }

            set
            {
                _foreColor = value;
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Size)]
        public Size Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.HatchStyle)]
        public HatchStyle Style
        {
            get
            {
                return _style;
            }

            set
            {
                _style = value;
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Visible)]
        public bool Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
            }
        }

        #endregion
    }
}