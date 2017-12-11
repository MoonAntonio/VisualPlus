namespace VisualPlus.Toolkit.Controls.Interactivity
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
<<<<<<< HEAD
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
=======
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Delegates;
    using VisualPlus.Designer;
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
    [ToolboxBitmap(typeof(NumericUpDown))]
    [DefaultEvent("Click")]
    [DefaultProperty("Value")]
    [Description("The Visual NumericUpDown")]
    [Designer(ControlManager.FilterProperties.VisualNumericUpDown)]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    [Description("The Visual NumericUpDown")]
    [Designer(typeof(VisualNumericUpDownDesigner))]
    [ToolboxBitmap(typeof(VisualNumericUpDown), "Resources.ToolboxBitmaps.VisualNumericUpDown.bmp")]
    [ToolboxItem(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualNumericUpDown : VisualControlBase
    {
        #region Variables

        private Border _border;
        private BorderEdge _borderButtons;

        private BorderEdge _borderEdge;
        private Color _buttonColor;
        private Font _buttonFont;
        private Color _buttonForeColor;
        private Orientation _buttonOrientation;
        private GraphicsPath _buttonPath;
        private Rectangle _buttonRectangle;
        private int _buttonWidth;
        private ColorState _colorState;
        private Point[] _decrementButtonPoints;
        private Point[] _incrementButtonPoints;
        private bool _keyboardNum;
        private long _maximumValue;
        private long _minimumValue;
<<<<<<< HEAD
        private long _numericValue;
=======
        private long _value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private int _xValue;
        private int _yValue;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown" /> class.
        /// </summary>
        public VisualNumericUpDown()
        {
            _decrementButtonPoints = new Point[2];
            _incrementButtonPoints = new Point[2];
            _buttonWidth = 50;

            _borderEdge = new BorderEdge();
            _borderButtons = new BorderEdge();

            _minimumValue = 0;
            _maximumValue = 100;
            Size = new Size(125, 25);
            MinimumSize = new Size(0, 0);
<<<<<<< HEAD
            _colorState = new ColorState();
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _buttonOrientation = Orientation.Horizontal;

            _border = new Border();

            Controls.Add(_borderEdge);
            Controls.Add(_borderButtons);

            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

<<<<<<< HEAD
=======
        [Category(Localization.Category.Events.PropertyChanged)]
        [Description(Event.PropertyEventChanged)]
        public event ValueChangedEventHandler ValueChanged;

>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        #endregion

        #region Properties

        [TypeConverter(typeof(ColorStateConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState BackColorState
        {
            get
            {
                return _colorState;
            }

            set
            {
                if (value == _colorState)
                {
                    return;
                }

                _colorState = value;
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

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonColor
        {
            get
            {
                return _buttonColor;
            }

            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Font)]
        public Font ButtonFont
        {
            get
            {
                return _buttonFont;
            }

            set
            {
                _buttonFont = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonForeColor
        {
            get
            {
                return _buttonForeColor;
            }

            set
            {
                _buttonForeColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
        public Orientation ButtonOrientation
        {
            get
            {
                return _buttonOrientation;
            }

            set
            {
                _buttonOrientation = value;
                Invalidate();
            }
        }

        [Category(Propertys.Layout)]
        [Description(Property.Size)]
        public int ButtonWidth
        {
            get
            {
                return _buttonWidth;
            }

            set
            {
                _buttonWidth = value;
                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        public long MaximumValue
        {
            get
            {
                return _maximumValue;
            }

            set
            {
                if (value > _minimumValue)
                {
                    _maximumValue = value;
                }

<<<<<<< HEAD
                if (_numericValue > _maximumValue)
                {
                    _numericValue = _maximumValue;
=======
                if (_value > _maximumValue)
                {
                    _value = _maximumValue;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }

                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        public long MinimumValue
        {
            get
            {
                return _minimumValue;
            }

            set
            {
                if (value < _maximumValue)
                {
                    _minimumValue = value;
                }

<<<<<<< HEAD
                if (_numericValue < _minimumValue)
                {
                    _numericValue = MinimumValue;
=======
                if (_value < _minimumValue)
                {
                    _value = MinimumValue;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }

                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color Separator
        {
            get
            {
                return _borderEdge.BackColor;
            }

            set
            {
                _borderEdge.BackColor = value;
                _borderButtons.BackColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        public long Value
        {
            get
            {
<<<<<<< HEAD
                return _numericValue;
=======
                return _value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
                if ((value <= _maximumValue) & (value >= _minimumValue))
                {
<<<<<<< HEAD
                    _numericValue = value;
=======
                    _value = value;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }

                Invalidate();
            }
        }

        #endregion

        #region Events

        public void Decrement(int value)
        {
<<<<<<< HEAD
            _numericValue -= value;
=======
            _value -= value;
            OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Invalidate();
        }

        public void Increment(int value)
        {
<<<<<<< HEAD
            _numericValue += value;
=======
            _value += value;
            OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Invalidate();
        }

        public void UpdateTheme(Styles style)
        {
            StyleManager = new VisualStyleManager(style);

            _buttonForeColor = Color.Gray;
            _buttonFont = new Font(StyleManager.Font.FontFamily, 14, FontStyle.Bold);
            _buttonColor = StyleManager.ControlStyle.Background(3);

            ForeColor = StyleManager.FontStyle.ForeColor;
            ForeColorDisabled = StyleManager.FontStyle.ForeColorDisabled;

<<<<<<< HEAD
            _colorState.Enabled = StyleManager.ControlStyle.Background(3);
            _colorState.Disabled = StyleManager.ControlStyle.Background(0);
=======
            _colorState = new ColorState
                {
                    Enabled = StyleManager.ControlStyle.Background(3),
                    Disabled = StyleManager.ControlStyle.Background(0)
                };
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            _borderButtons.BackColor = StyleManager.ControlStyle.Line;
            _borderEdge.BackColor = StyleManager.ControlStyle.Line;

            _border.Color = StyleManager.ShapeStyle.Color;
            _border.HoverColor = StyleManager.BorderStyle.HoverColor;

            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (_keyboardNum)
                {
<<<<<<< HEAD
                    _numericValue = long.Parse(_numericValue + e.KeyChar.ToString());
                }

                if (_numericValue > _maximumValue)
                {
                    _numericValue = _maximumValue;
=======
                    _value = long.Parse(_value + e.KeyChar.ToString());
                    OnValueChanged(new ValueChangedEventArgs(_value));
                }

                if (_value > _maximumValue)
                {
                    _value = _maximumValue;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Back)
            {
<<<<<<< HEAD
                string temporaryValue = _numericValue.ToString();
=======
                string temporaryValue = _value.ToString();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                temporaryValue = temporaryValue.Remove(Convert.ToInt32(temporaryValue.Length - 1));
                if (temporaryValue.Length == 0)
                {
                    temporaryValue = "0";
                }

<<<<<<< HEAD
                _numericValue = Convert.ToInt32(temporaryValue);
=======
                _value = Convert.ToInt32(temporaryValue);
                OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            OnMouseClick(e);

            switch (_buttonOrientation)
            {
                case Orientation.Vertical:
                    {
                        // Check if mouse in X position.
                        if ((_xValue > Width - _buttonRectangle.Width) && (_xValue < Width))
                        {
                            // Determine the button middle separator by checking for the Y position.
                            if ((_yValue > _buttonRectangle.Y) && (_yValue < Height / 2))
                            {
                                if (Value + 1 <= _maximumValue)
                                {
<<<<<<< HEAD
                                    _numericValue++;
=======
                                    _value++;
                                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                                }
                            }
                            else if ((_yValue > Height / 2) && (_yValue < Height))
                            {
                                if (Value - 1 >= _minimumValue)
                                {
<<<<<<< HEAD
                                    _numericValue--;
=======
                                    _value--;
                                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                                }
                            }
                        }
                        else
                        {
                            _keyboardNum = !_keyboardNum;
                            Focus();
                        }

                        break;
                    }

                case Orientation.Horizontal:
                    {
                        // Check if mouse in X position.
                        if ((_xValue > Width - _buttonRectangle.Width) && (_xValue < Width))
                        {
                            // Determine the button middle separator by checking for the X position.
                            if ((_xValue > _buttonRectangle.X) && (_xValue < _buttonRectangle.X + (_buttonRectangle.Width / 2)))
                            {
                                if (Value + 1 <= _maximumValue)
                                {
<<<<<<< HEAD
                                    _numericValue++;
=======
                                    _value++;
                                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                                }
                            }
                            else if ((_xValue > _buttonRectangle.X + (_buttonRectangle.Width / 2)) && (_xValue < Width))
                            {
                                if (Value - 1 >= _minimumValue)
                                {
<<<<<<< HEAD
                                    _numericValue--;
=======
                                    _value--;
                                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                                }
                            }
                        }
                        else
                        {
                            _keyboardNum = !_keyboardNum;
                            Focus();
                        }

                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _xValue = e.Location.X;
            _yValue = e.Location.Y;
            Invalidate();

            // IBeam cursor toggle
            if (e.X < _buttonRectangle.X)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if (Value + 1 <= _maximumValue)
                {
<<<<<<< HEAD
                    _numericValue++;
=======
                    _value++;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }

                Invalidate();
            }
            else
            {
                if (Value - 1 >= _minimumValue)
                {
<<<<<<< HEAD
                    _numericValue--;
=======
                    _value--;
                    OnValueChanged(new ValueChangedEventArgs(_value));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }

                Invalidate();
            }
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

            _buttonRectangle = new Rectangle(Width - _buttonWidth, 1, _buttonWidth, Height);

            Size incrementSize = GDI.MeasureText(_graphics, "+", _buttonFont);
            Size decrementSize = GDI.MeasureText(_graphics, "-", _buttonFont);
=======
            _graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1));
            _graphics.SetClip(ControlGraphicsPath);

            _buttonRectangle = new Rectangle(Width - _buttonWidth, 1, _buttonWidth, Height);

            Size incrementSize = GraphicsManager.MeasureText(_graphics, "+", _buttonFont);
            Size decrementSize = GraphicsManager.MeasureText(_graphics, "-", _buttonFont);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            _incrementButtonPoints[0] = new Point((_buttonRectangle.X + (_buttonRectangle.Width / 2)) - (incrementSize.Width / 2), (_buttonRectangle.Y + (_buttonRectangle.Height / 2)) - (_buttonRectangle.Height / 4) - (incrementSize.Height / 2));
            _decrementButtonPoints[0] = new Point((_buttonRectangle.X + (_buttonRectangle.Width / 2)) - (decrementSize.Width / 2), (_buttonRectangle.Y + (_buttonRectangle.Height / 2) + (_buttonRectangle.Height / 4)) - (decrementSize.Height / 2));

            _incrementButtonPoints[1] = new Point((_buttonRectangle.X + (_buttonRectangle.Width / 4)) - (incrementSize.Width / 2), (Height / 2) - (incrementSize.Height / 2));
            _decrementButtonPoints[1] = new Point((_buttonRectangle.X + (_buttonRectangle.Width / 2) + (_buttonRectangle.Width / 4)) - (decrementSize.Width / 2), (Height / 2) - (decrementSize.Height / 2));

            int toggleInt;
            switch (_buttonOrientation)
            {
                case Orientation.Horizontal:
                    {
                        toggleInt = 1;
                        _borderButtons.Location = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2), _border.Thickness);
                        _borderButtons.Size = new Size(1, Height - _border.Thickness - 1);
                        break;
                    }

                case Orientation.Vertical:
                    {
                        toggleInt = 0;
                        _borderButtons.Location = new Point(_buttonRectangle.X, (_buttonRectangle.Bottom / 2) - _border.Thickness);
                        _borderButtons.Size = new Size(Width - _border.Thickness - 1, 1);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            _buttonPath = new GraphicsPath();
            _buttonPath.AddRectangle(_buttonRectangle);
            _buttonPath.CloseAllFigures();

            Color _backColor = Enabled ? BackColorState.Enabled : BackColorState.Disabled;
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, MouseState, _clientRectangle, Border);

            _graphics.SetClip(ControlGraphicsPath);
<<<<<<< HEAD

            VisualBackgroundRenderer.DrawBackground(_graphics, _buttonColor, _buttonRectangle);

=======
            _graphics.FillRectangle(new SolidBrush(_buttonColor), _buttonRectangle);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _graphics.ResetClip();

            _graphics.DrawString("+", _buttonFont, new SolidBrush(_buttonForeColor), _incrementButtonPoints[toggleInt]);
            _graphics.DrawString("-", _buttonFont, new SolidBrush(_buttonForeColor), _decrementButtonPoints[toggleInt]);

            _borderEdge.Location = new Point(_buttonRectangle.X, _border.Thickness);
            _borderEdge.Size = new Size(1, Height - _border.Thickness - 1);

            DrawText(_graphics);
<<<<<<< HEAD
=======

            VisualBorderRenderer.DrawBorderStyle(e.Graphics, _border, ControlGraphicsPath, MouseState);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
<<<<<<< HEAD
            e.Graphics.Clear(Parent.BackColor);
=======
            e.Graphics.Clear(BackColor);
        }

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(e);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        private void DrawText(Graphics _graphics)
        {
            Rectangle textBoxRectangle = new Rectangle(6, 0, Width - 1, Height - 1);
            StringFormat stringFormat = new StringFormat
                {
                    // Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
            _graphics.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor), textBoxRectangle, stringFormat);
        }

        #endregion
    }
}