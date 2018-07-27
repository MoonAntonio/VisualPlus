#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

using VisualPlus.Delegates;
using VisualPlus.Enumerators;
using VisualPlus.Events;
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
    [Description("The color states of a component.")]
    [Category(PropertyCategory.Appearance)]
    public class ColorState
    {
        #region Variables

        private Color _disabled;
        private Color _enabled;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ColorState" /> class.</summary>
        /// <param name="disabled">The disabled color.</param>
        /// <param name="enabled">The normal color.</param>
        public ColorState(Color disabled, Color enabled)
        {
            _disabled = disabled;
            _enabled = enabled;
        }

        /// <summary>Initializes a new instance of the <see cref="ColorState" /> class.</summary>
        public ColorState()
        {
            _disabled = Color.Empty;
            _enabled = Color.Empty;
        }

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event BackColorStateChangedEventHandler DisabledColorChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event BackColorStateChangedEventHandler NormalColorChanged;

        #endregion

        #region Properties

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        public Color Disabled
        {
            get
            {
                return _disabled;
            }

            set
            {
                _disabled = value;
                OnDisabledColorChanged(new ColorEventArgs(_disabled));
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Color)]
        public Color Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                OnDisabledColorChanged(new ColorEventArgs(_enabled));
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="ColorState" /> is empty.</summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return _disabled.IsEmpty && _enabled.IsEmpty;
            }
        }

        #endregion

        #region Overrides

        protected virtual void OnDisabledColorChanged(ColorEventArgs e)
        {
            DisabledColorChanged?.Invoke(e);
        }

        protected virtual void OnNormalColorChanged(ColorEventArgs e)
        {
            NormalColorChanged?.Invoke(e);
        }

        public override string ToString()
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(GetType().Name);
            _stringBuilder.Append(" [");

            if (IsEmpty)
            {
                _stringBuilder.Append("IsEmpty");
            }
            else
            {
                _stringBuilder.Append("Disabled=");
                _stringBuilder.Append(Disabled);
                _stringBuilder.Append("Normal=");
                _stringBuilder.Append(Enabled);
            }

            _stringBuilder.Append("]");

            return _stringBuilder.ToString();
        }

        #endregion

        #region Methods

        /// <summary>Get the control back color state.</summary>
        /// <param name="colorState">The color State.</param>
        /// <param name="enabled">The enabled toggle.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color BackColorState(ColorState colorState, bool enabled, MouseStates mouseState)
        {
            Color _color;

            if (enabled)
            {
                switch (mouseState)
                {
                    case MouseStates.Normal:
                        {
                            _color = colorState.Enabled;
                            break;
                        }

                    case MouseStates.Hover:
                        {
                            _color = colorState.Enabled;
                            break;
                        }

                    case MouseStates.Pressed:
                        {
                            _color = colorState.Enabled;
                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException(nameof(mouseState), mouseState, null);
                        }
                }
            }
            else
            {
                _color = colorState.Disabled;
            }

            return _color;
        }

        #endregion
    }
}