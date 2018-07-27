#region Namespace

using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

using VisualPlus.Delegates;
using VisualPlus.Enumerators;
using VisualPlus.Events;
using VisualPlus.Localization;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [TypeConverter(typeof(VisualSettingsTypeConverter))]
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The border.")]
    public class Border : Shape
    {
        #region Variables

        private Color _hoverColor;
        private bool _hoverVisible;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Border" /> class.</summary>
        /// <param name="hoverColor">The hover Color.</param>
        /// <param name="hoverVisible">The hover Visible.</param>
        public Border(Color hoverColor, bool hoverVisible)
        {
            ConstructBorder(hoverColor, hoverVisible);
        }

        /// <summary>Initializes a new instance of the <see cref="Border" /> class.</summary>
        /// <param name="hoverColor">The hover Color.</param>
        public Border(Color hoverColor)
        {
            ConstructBorder(hoverColor, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Border" /> class.</summary>
        public Border()
        {
            Theme theme = new Theme(Themes.Visual);
            Color color = theme.ColorPalette.BorderHover;
            ConstructBorder(color, true);
        }

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event BorderHoverColorChangedEventHandler HoverColorChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event BorderHoverVisibleChangedEventHandler HoverVisibleChanged;

        #endregion

        #region Properties

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        public Color HoverColor
        {
            get
            {
                return _hoverColor;
            }

            set
            {
                _hoverColor = value;
                HoverColorChanged?.Invoke(new ColorEventArgs(_hoverColor));
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Visible)]
        public bool HoverVisible
        {
            get
            {
                return _hoverVisible;
            }

            set
            {
                _hoverVisible = value;
                HoverVisibleChanged?.Invoke();
            }
        }

        #endregion

        #region Methods

        /// <summary>Constructs the shape.</summary>
        /// <param name="hoverColor">The hover Color.</param>
        /// <param name="hoverVisible">The hover Visible.</param>
        private void ConstructBorder(Color hoverColor, bool hoverVisible)
        {
            _hoverColor = hoverColor;
            _hoverVisible = hoverVisible;
        }

        #endregion
    }
}