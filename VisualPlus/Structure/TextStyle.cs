#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;

using VisualPlus.Localization;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [TypeConverter(typeof(BasicSettingsTypeConverter))]
    public class TextStyle : ITextColor
    {
        #region Variables

        private StringAlignment textAlignment;
        private ControlColorState textColorState;
        private StringAlignment textLineAlignment;
        private TextRenderingHint textRenderingHint;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="TextStyle" /> class.</summary>
        /// <param name="colorState">The color State.</param>
        public TextStyle(ControlColorState colorState) : this()
        {
            if (colorState.IsEmpty)
            {
                throw new ArgumentNullException(nameof(colorState));
            }

            textColorState = colorState;
        }

        /// <summary>Initializes a new instance of the <see cref="TextStyle" /> class.</summary>
        public TextStyle()
        {
            textColorState = new ControlColorState();
            textRenderingHint = Settings.DefaultValue.TextRenderingHint;
            textAlignment = StringAlignment.Center;
            textLineAlignment = StringAlignment.Center;
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlColorState ColorState
        {
            get
            {
                return textColorState;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Disabled
        {
            get
            {
                return textColorState.Disabled;
            }

            set
            {
                textColorState.Disabled = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Enabled
        {
            get
            {
                return textColorState.Enabled;
            }

            set
            {
                textColorState.Enabled = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Hover
        {
            get
            {
                return textColorState.Hover;
            }

            set
            {
                textColorState.Hover = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Pressed
        {
            get
            {
                return textColorState.Pressed;
            }

            set
            {
                textColorState.Pressed = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat
                    {
                        Alignment = textAlignment,
                        LineAlignment = textLineAlignment
                    };

                return stringFormat;
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Alignment)]
        public StringAlignment TextAlignment
        {
            get
            {
                return textAlignment;
            }

            set
            {
                textAlignment = value;
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Alignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return textLineAlignment;
            }

            set
            {
                textLineAlignment = value;
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Type)]
        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return textRenderingHint;
            }

            set
            {
                textRenderingHint = value;
            }
        }

        #endregion
    }
}