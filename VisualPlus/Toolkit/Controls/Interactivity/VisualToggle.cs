namespace VisualPlus.Toolkit.Controls.Interactivity
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
<<<<<<< HEAD
    using System.Windows.Forms;

=======
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Designer;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Managers;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

<<<<<<< HEAD
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Control))]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Toggled")]
    [Description("The Visual Toggle")]
    [Designer(ControlManager.FilterProperties.VisualToggle)]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Toggled")]
    [Description("The Visual Toggle")]
    [Designer(typeof(VisualToggleDesigner))]
    [ToolboxBitmap(typeof(VisualToggle), "Resources.ToolboxBitmaps.VisualToggle.bmp")]
    [ToolboxItem(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualToggle : ToggleBase
    {
        #region Variables

        private readonly Timer _animationTimer;
        private Border _border;
        private Border _buttonBorder;
        private ControlColorState _buttonColorState;
        private Rectangle _buttonRectangle;
        private Size _buttonSize;
        private ColorState _controlColorState;
        private Image _progressImage;
        private string _textProcessor;
        private int _toggleLocation;
        private ToggleTypes _toggleType;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualToggle" /> class.</summary>
        public VisualToggle()
        {
            Size = new Size(50, 25);
            Font = StyleManager.Font;

            _animationTimer = new Timer
                {
                    Interval = 1
                };

            _animationTimer.Tick += AnimationTimerTick;
<<<<<<< HEAD
            _controlColorState = new ColorState();
            _buttonColorState = new ControlColorState();
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _toggleType = ToggleTypes.YesNo;
            _buttonSize = new Size(20, 20);

            _border = new Border
                {
                    Rounding = Settings.DefaultValue.Rounding.ToggleBorder
                };

            _buttonBorder = new Border
                {
                    Rounding = Settings.DefaultValue.Rounding.ToggleButton
                };

            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        public enum ToggleTypes
        {
            /// <summary>Yes / No toggle.</summary>
            YesNo,

            /// <summary>On / Off toggle.</summary>
            OnOff,

            /// <summary>I / O toggle.</summary>
            IO
        }

        #endregion

        #region Properties

        [TypeConverter(typeof(ColorStateConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public ColorState BackColorState
        {
            get
            {
                return _controlColorState;
            }

            set
            {
                if (value == _controlColorState)
                {
                    return;
                }

                _controlColorState = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public Border Border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public Border ButtonBorder
        {
            get
            {
                return _buttonBorder;
            }

            set
            {
                _buttonBorder = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(ControlColorStateConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public ControlColorState ButtonColorState
        {
            get
            {
                return _buttonColorState;
            }

            set
            {
                if (value == _buttonColorState)
                {
                    return;
                }

                _buttonColorState = value;
                Invalidate();
            }
        }

        [Category(Propertys.Layout)]
        [Description(Property.Size)]
        public Size ButtonSize
        {
            get
            {
                return _buttonSize;
            }

            set
            {
                _buttonSize = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Image)]
        public Image ProgressImage
        {
            get
            {
                return _progressImage;
            }

            set
            {
                _progressImage = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category(Propertys.Behavior)]
        [Description(Property.Toggle)]
        public bool Toggled
        {
            get
            {
                return Toggle;
            }

            set
            {
                Toggle = value;
                Invalidate();
                OnToggleChanged(new ToggleEventArgs(Toggle));
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Type)]
        public ToggleTypes Type
        {
            get
            {
                return _toggleType;
            }

            set
            {
                _toggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        public void UpdateTheme(Styles style)
        {
            StyleManager = new VisualStyleManager(style);

            ForeColor = StyleManager.FontStyle.ForeColor;
            ForeColorDisabled = StyleManager.FontStyle.ForeColorDisabled;

<<<<<<< HEAD
            _controlColorState.Enabled = StyleManager.ControlStyle.Background(3);
            _controlColorState.Disabled = StyleManager.ControlStyle.Background(0);

            _buttonColorState.Enabled = StyleManager.ControlStyle.Background(0);
            _buttonColorState.Disabled = Color.FromArgb(224, 224, 224);
            _buttonColorState.Hover = Color.FromArgb(224, 224, 224);
            _buttonColorState.Pressed = Color.Silver;
=======
            _controlColorState = new ColorState
                {
                    Enabled = StyleManager.ControlStyle.Background(3),
                    Disabled = StyleManager.ControlStyle.Background(0)
                };

            _buttonColorState = new ControlColorState
                {
                    Enabled = StyleManager.ControlStyle.Background(0),
                    Disabled = Color.FromArgb(224, 224, 224),
                    Hover = Color.FromArgb(224, 224, 224),
                    Pressed = Color.Silver
                };
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            _border.Color = StyleManager.ShapeStyle.Color;
            _border.HoverColor = StyleManager.BorderStyle.HoverColor;
            _buttonBorder.Color = StyleManager.ShapeStyle.Color;
            _buttonBorder.HoverColor = StyleManager.BorderStyle.HoverColor;
            Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _animationTimer.Start();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = MouseStates.Down;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = MouseStates.Normal;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseState = MouseState = MouseStates.Hover;
            Toggled = !Toggled;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics _graphics = e.Graphics;
            _graphics.Clear(Parent.BackColor);
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TextRenderingHint = TextRenderingHint;
            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            ControlGraphicsPath = VisualBorderRenderer.CreateBorderTypePath(_clientRectangle, _border);
<<<<<<< HEAD
            _graphics.FillRectangle(new SolidBrush(BackColor), _clientRectangle);

            Color _backColor = Enabled ? _controlColorState.Enabled : _controlColorState.Disabled;
=======
            Color _backColor = Enabled ? _controlColorState.Enabled : _controlColorState.Disabled;

            _graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1));
            _graphics.SetClip(ControlGraphicsPath);

>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, MouseState, _clientRectangle, Border);

            // Determines button/toggle state
            Point _startPoint = new Point(0 + 2, (_clientRectangle.Height / 2) - (_buttonSize.Height / 2));
            Point _endPoint = new Point(_clientRectangle.Width - _buttonSize.Width - 2, (_clientRectangle.Height / 2) - (_buttonSize.Height / 2));
            Point _buttonLocation = Toggle ? _endPoint : _startPoint;
            _buttonRectangle = new Rectangle(_buttonLocation, _buttonSize);
            DrawToggleText(_graphics);

<<<<<<< HEAD
            Color _buttonColor = GDI.GetBackColorState(Enabled, ButtonColorState.Enabled, ButtonColorState.Hover, ButtonColorState.Pressed, ButtonColorState.Disabled, MouseState);
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _buttonColor, _buttonRectangle, _buttonBorder);
=======
            Color _buttonColor = ControlColorState.BackColorState(ButtonColorState, Enabled, MouseState);
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _buttonColor, _buttonRectangle, _buttonBorder);

            VisualBorderRenderer.DrawBorderStyle(e.Graphics, _border, ControlGraphicsPath, MouseState);
            _graphics.ResetClip();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.Clear(BackColor);
        }

        /// <summary>Create a slide animation when toggled.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            if (Toggle)
            {
                if (_toggleLocation >= 100)
                {
                    return;
                }

                _toggleLocation += 10;
                Invalidate(false);
            }
            else if (_toggleLocation > 0)
            {
                _toggleLocation -= 10;
                Invalidate(false);
            }
        }

        private void DrawToggleText(Graphics graphics)
        {
            // Determines the type of toggle to draw.
            switch (_toggleType)
            {
                case ToggleTypes.YesNo:
                    {
                        _textProcessor = Toggled ? "No" : "Yes";

                        break;
                    }

                case ToggleTypes.OnOff:
                    {
                        _textProcessor = Toggled ? "Off" : "On";

                        break;
                    }

                case ToggleTypes.IO:
                    {
                        _textProcessor = Toggled ? "O" : "I";

                        break;
                    }
            }

            // Draw string
            Rectangle textBoxRectangle;

            const int XOff = 5;
            const int XOn = 7;

            if (Toggle)
            {
                textBoxRectangle = new Rectangle(XOff, 0, Width - 1, Height - 1);
            }
            else
            {
<<<<<<< HEAD
                Size textSize = GDI.MeasureText(graphics, _textProcessor, Font);
=======
                Size textSize = GraphicsManager.MeasureText(graphics, _textProcessor, Font);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                textBoxRectangle = new Rectangle(Width - (textSize.Width / 2) - (XOn * 2), 0, Width - 1, Height - 1);
            }

            StringFormat stringFormat = new StringFormat
                {
                    // Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

            Color _foreColor = Enabled ? ForeColor : ForeColorDisabled;

            graphics.DrawString(
                _textProcessor,
                new Font(Font.FontFamily, 7f, Font.Style),
                new SolidBrush(_foreColor),
                textBoxRectangle,
                stringFormat);
        }

        #endregion
    }
}