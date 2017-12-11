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
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Managers;
<<<<<<< HEAD
    using VisualPlus.Properties;
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

<<<<<<< HEAD
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The Visual Button")]
    [Designer(ControlManager.FilterProperties.VisualButton)]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The Visual Button")]
    [Designer(typeof(VisualButtonDesigner))]
    [ToolboxBitmap(typeof(VisualButton), "Resources.ToolboxBitmaps.VisualButton.bmp")]
    [ToolboxItem(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualButton : VisualControlBase, IAnimationSupport, IThemeSupport
    {
        #region Variables

        private bool _animation;
<<<<<<< HEAD

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private ControlColorState _backColorState;
        private Border _border;
        private VFXManager _effectsManager;
        private VFXManager _hoverEffectsManager;
<<<<<<< HEAD
        private TextImageRelation _textImageRelation;
        private VisualBitmap _visualBitmap;
=======
        private Image _image;
        private StringAlignment _textAlignment;
        private TextImageRelation _textImageRelation;
        private StringAlignment _textLineAlignment;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:VisualPlus.Toolkit.Controls.Interactivity.VisualButton" />
        ///     class.
        /// </summary>
        public VisualButton()
        {
            Size = new Size(140, 45);
            _animation = Settings.DefaultValue.Animation;
            _border = new Border();
            _textImageRelation = TextImageRelation.Overlay;
<<<<<<< HEAD
            _backColorState = new ControlColorState();
            _visualBitmap = new VisualBitmap(Resources.VisualPlus, new Size(24, 24))
                {
                    Visible = false,
                    Image = Resources.VisualPlus
                };
            _visualBitmap.Point = new Point(0, (Height / 2) - (_visualBitmap.Size.Height / 2));

            ConfigureAnimation();
=======
            _textAlignment = StringAlignment.Center;
            _textLineAlignment = StringAlignment.Center;
            ConfigureAnimation(new[] { 0.03, 0.07 }, new[] { EffectType.EaseOut, EffectType.EaseInOut });
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        #endregion

        #region Properties

<<<<<<< HEAD
=======
        [DefaultValue(Settings.DefaultValue.Animation)]
        [Category(Propertys.Behavior)]
        [Description(Property.Animation)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public bool Animation
        {
            get
            {
                return _animation;
            }

            set
            {
                _animation = value;
                AutoSize = AutoSize; // Make AutoSize directly set the bounds.

                if (value)
                {
                    Margin = new Padding(0);
                }

                Invalidate();
            }
        }

        [TypeConverter(typeof(ControlColorStateConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState BackColorState
        {
            get
            {
                return _backColorState;
            }

            set
            {
                if (value == _backColorState)
                {
                    return;
                }

                _backColorState = value;
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

<<<<<<< HEAD
        [TypeConverter(typeof(VisualBitmapConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public VisualBitmap Image
        {
            get
            {
                return _visualBitmap;
=======
        [Category(Propertys.Appearance)]
        [Description(Property.Image)]
        public Image Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
        public StringAlignment TextAlignment
        {
            get
            {
                return _textAlignment;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _visualBitmap = value;
=======
                _textAlignment = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        [Description(Property.TextImageRelation)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return _textImageRelation;
            }

            set
            {
                _textImageRelation = value;
                Invalidate();
            }
        }

<<<<<<< HEAD
=======
        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return _textLineAlignment;
            }

            set
            {
                _textLineAlignment = value;
                Invalidate();
            }
        }

>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        #endregion

        #region Events

<<<<<<< HEAD
        public void ConfigureAnimation()
        {
            _effectsManager = new VFXManager(false)
                {
                    Increment = 0.03,
                    EffectType = EffectType.EaseOut
                };
            _hoverEffectsManager = new VFXManager
                {
                    Increment = 0.07,
                    EffectType = EffectType.Linear
=======
        public void ConfigureAnimation(double[] effectIncrement, EffectType[] effectType)
        {
            _effectsManager = new VFXManager(false)
                {
                    Increment = effectIncrement[0],
                    EffectType = effectType[0]
                };

            _hoverEffectsManager = new VFXManager
                {
                    Increment = effectIncrement[1],
                    EffectType = effectType[1]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                };

            _hoverEffectsManager.OnAnimationProgress += sender => Invalidate();
            _effectsManager.OnAnimationProgress += sender => Invalidate();
        }

        public void DrawAnimation(Graphics graphics)
        {
<<<<<<< HEAD
            if (_effectsManager.IsAnimating() && _animation)
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (var i = 0; i < _effectsManager.GetAnimationCount(); i++)
                {
                    double animationValue = _effectsManager.GetProgress(i);
                    Point animationSource = _effectsManager.GetSource(i);

                    using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), Color.Black)))
                    {
                        var rippleSize = (int)(animationValue * Width * 2);
                        graphics.SetClip(ControlGraphicsPath);
                        graphics.FillEllipse(rippleBrush, new Rectangle(animationSource.X - (rippleSize / 2), animationSource.Y - (rippleSize / 2), rippleSize, rippleSize));
                    }
                }

                graphics.SmoothingMode = SmoothingMode.None;
            }
=======
            if (!_effectsManager.IsAnimating() || !_animation)
            {
                return;
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (var i = 0; i < _effectsManager.GetAnimationCount(); i++)
            {
                double _value = _effectsManager.GetProgress(i);
                Point _source = _effectsManager.GetSource(i);

                using (Brush _rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (_value * 100)), Color.Black)))
                {
                    var _rippleSize = (int)(_value * Width * 2);
                    graphics.SetClip(ControlGraphicsPath);
                    graphics.FillEllipse(_rippleBrush, new Rectangle(_source.X - (_rippleSize / 2), _source.Y - (_rippleSize / 2), _rippleSize, _rippleSize));
                }
            }

            graphics.SmoothingMode = SmoothingMode.None;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        public void UpdateTheme(Styles style)
        {
            StyleManager.Style = style;
            _border.Color = StyleManager.ShapeStyle.Color;
            _border.HoverColor = StyleManager.BorderStyle.HoverColor;
            ForeColor = StyleManager.FontStyle.ForeColor;
            ForeColorDisabled = StyleManager.FontStyle.ForeColorDisabled;
            Font = StyleManager.Font;

<<<<<<< HEAD
            _backColorState.Enabled = StyleManager.ControlStyle.Background(0);
            _backColorState.Disabled = Color.FromArgb(224, 224, 224);
            _backColorState.Hover = Color.FromArgb(224, 224, 224);
            _backColorState.Pressed = Color.Silver;
=======
            _backColorState = new ControlColorState
                {
                    Enabled = StyleManager.ControlStyle.Background(0),
                    Disabled = Color.FromArgb(224, 224, 224),
                    Hover = Color.FromArgb(224, 224, 224),
                    Pressed = Color.Silver
                };
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode)
            {
                return;
            }

            MouseState = MouseStates.Normal;
            MouseEnter += (sender, args) =>
                {
                    MouseState = MouseStates.Hover;
                    _hoverEffectsManager.StartNewAnimation(AnimationDirection.In);
                    Invalidate();
                };
            MouseLeave += (sender, args) =>
                {
                    MouseState = MouseStates.Normal;
                    _hoverEffectsManager.StartNewAnimation(AnimationDirection.Out);
                    Invalidate();
                };
            MouseDown += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        MouseState = MouseStates.Down;
                        _effectsManager.StartNewAnimation(AnimationDirection.In, args.Location);
                        Invalidate();
                    }
                };
            MouseUp += (sender, args) =>
                {
                    MouseState = MouseStates.Hover;
                    Invalidate();
                };
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = MouseStates.Down;
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            MouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseState = MouseState = MouseStates.Hover;
            Invalidate();
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

            Color _backColor = GDI.GetBackColorState(Enabled, BackColorState.Enabled, BackColorState.Hover, BackColorState.Pressed, BackColorState.Disabled, MouseState);
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, MouseState, _clientRectangle, Border);

            Color _textColor = Enabled ? ForeColor : ForeColorDisabled;

            VisualControlRenderer.DrawInternalContent(e.Graphics, ClientRectangle, Text, Font, _textColor, Image, _textImageRelation);
            DrawAnimation(e.Graphics);
=======
            _graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1));

            Color _backColor = ControlColorState.BackColorState(BackColorState, Enabled, MouseState);

            e.Graphics.SetClip(ControlGraphicsPath);
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, MouseState, _clientRectangle, _border);

            Color _textColor = Enabled ? ForeColor : ForeColorDisabled;

            if (_image != null)
            {
                VisualControlRenderer.DrawContent(e.Graphics, ClientRectangle, Text, Font, _textColor, _image, _image.Size, _textImageRelation);
            }
            else
            {
                VisualControlRenderer.DrawContentText(e.Graphics, ClientRectangle, Text, Font, _textColor, _textAlignment, _textLineAlignment);
            }

            VisualBorderRenderer.DrawBorderStyle(e.Graphics, _border, ControlGraphicsPath, MouseState);
            DrawAnimation(e.Graphics);
            e.Graphics.ResetClip();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.Clear(BackColor);
        }

        #endregion
    }
}