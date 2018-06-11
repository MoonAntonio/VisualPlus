namespace VisualPlus.Toolkit.Dialogs
{
    #region Namespace

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Constants;
    using VisualPlus.Delegates;
    using VisualPlus.Designer;
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Localization;
    using VisualPlus.Managers;
    using VisualPlus.Native;
    using VisualPlus.Properties;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;
    using VisualPlus.Toolkit.Controls.Interactivity;

    #endregion

    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DesignTimeVisible(false)]
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual Form")]
    [Designer(typeof(VisualFormDesigner), typeof(IRootDesigner))]
    [DesignerCategory("Form")]
    [InitializationEvent("Load")]
    [ToolboxBitmap(typeof(VisualForm), "VisualForm.bmp")]
    [ToolboxItemFilter("System.Windows.Forms.Control.TopLevel")]
    [ToolboxItem(false)]
    public class VisualForm : Form, ICloneable, IThemeSupport
    {
        #region Variables

        protected VisualControlBox _visualControlBox;

        #endregion

        #region Variables

        private readonly Cursor[] _resizeCursors;
        private readonly Dictionary<int, int> _resizedLocationsCommand;
        private Color _background;
        private Border _border;
        private bool _dropShadow;
        private bool _headerMouseDown;
        private bool _magnetic;
        private int _magneticRadius;
        private bool _maximized;
        private MouseStates _mouseState;
        private Size _previousSize;
        private ResizeDirection _resizeDir;
        private StyleManager _styleManager;
        private Rectangle _textRectangle;
        private Alignment.TextAlignment _titleAlignment;
        private Rectangle _titleBarRectangle;
        private VisualBitmap _vsImage;
        private Color _windowBarColor;
        private int _windowBarHeight;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualForm" /> class.</summary>
        /// <param name="text">The text associated with this control.</param>
        public VisualForm(string text) : this()
        {
            InitializeText(text);
        }

        /// <summary>Initializes a new instance of the <see cref="VisualForm" /> class.</summary>
        public VisualForm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            _resizeCursors = new[] { Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeWE, Cursors.SizeNS };

            _resizedLocationsCommand = new Dictionary<int, int>
                {
                    { FormConstants.HTTOP, FormConstants.WMSZ_TOP },
                    { FormConstants.HTTOPLEFT, FormConstants.WMSZ_TOPLEFT },
                    { FormConstants.HTTOPRIGHT, FormConstants.WMSZ_TOPRIGHT },
                    { FormConstants.HTLEFT, FormConstants.WMSZ_LEFT },
                    { FormConstants.HTRIGHT, FormConstants.WMSZ_RIGHT },
                    { FormConstants.HTBOTTOM, FormConstants.WMSZ_BOTTOM },
                    { FormConstants.HTBOTTOMLEFT, FormConstants.WMSZ_BOTTOMLEFT },
                    { FormConstants.HTBOTTOMRIGHT, FormConstants.WMSZ_BOTTOMRIGHT }
                };

            _styleManager = new StyleManager(Settings.DefaultValue.DefaultStyle);

            _border = new Border
                {
                    Thickness = 3,
                    Type = ShapeType.Rectangle
                };

            _dropShadow = true;

            FormBorderStyle = FormBorderStyle.None;
            _magnetic = false;
            _magneticRadius = 100;
            Padding = new Padding(0, 0, 0, 0);
            Sizable = true;
            _titleAlignment = Alignment.TextAlignment.Center;
            TransparencyKey = Color.Fuchsia;
            _windowBarHeight = 30;
            _previousSize = Size.Empty;
            _titleBarRectangle = new Rectangle(0, 0, Width, _windowBarHeight);

            _vsImage = new VisualBitmap(Resources.VisualPlus, new Size(16, 16))
                    {
                       Visible = true 
                    };

            _vsImage.Point = new Point(5, (_windowBarHeight / 2) - (_vsImage.Size.Height / 2));

            _visualControlBox = new VisualControlBox();
            Controls.Add(_visualControlBox);
            _visualControlBox.Location = new Point(Width - _visualControlBox.Width - 16, _border.Thickness);

            _textRectangle = new Rectangle(0, 7, 0, 0);
            UpdateTheme(_styleManager.Theme);

            // This enables the form to trigger the MouseMove event even when mouse is over another control
            Application.AddMessageFilter(new MouseMessageFilter());
            MouseMessageFilter.MouseMove += OnGlobalMouseMove;
        }

        #endregion

        #region Events

        [Category(EventCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public event BackgroundChangedEventHandler BackgroundChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ControlBoxEventHandler CloseButtonClicked
        {
            add
            {
                _visualControlBox.CloseClick += value;
            }

            remove
            {
                _visualControlBox.CloseClick -= value;
            }
        }

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public new event ControlBoxEventHandler HelpButtonClicked
        {
            add
            {
                _visualControlBox.HelpClick += value;
            }

            remove
            {
                _visualControlBox.HelpClick -= value;
            }
        }

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ControlBoxEventHandler MaximizeButtonClicked
        {
            add
            {
                _visualControlBox.MaximizeClick += value;
            }

            remove
            {
                _visualControlBox.MaximizeClick -= value;
            }
        }

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ControlBoxEventHandler MinimizeButtonClicked
        {
            add
            {
                _visualControlBox.MinimizeClick += value;
            }

            remove
            {
                _visualControlBox.MinimizeClick -= value;
            }
        }

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event ControlBoxEventHandler RestoredFormWindow
        {
            add
            {
                _visualControlBox.RestoredFormWindow += value;
            }

            remove
            {
                _visualControlBox.RestoredFormWindow -= value;
            }
        }

        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the theme of the control has changed.")]
        public event ThemeChangedEventHandler ThemeChanged;

        #endregion

        #region Enumerators

        public enum ResizeDirection
        {
            /// <summary>The bottom left.</summary>
            BottomLeft,

            /// <summary>The left.</summary>
            Left,

            /// <summary>The right.</summary>
            Right,

            /// <summary>The bottom right.</summary>
            BottomRight,

            /// <summary>The bottom.</summary>
            Bottom,

            /// <summary>The none.</summary>
            None
        }

        #endregion

        #region Properties

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                if (_background == value)
                {
                    return;
                }

                _background = value;
                Invalidate();
                BackgroundChanged?.Invoke(new ColorEventArgs(_background));
            }
        }

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
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

        [TypeConverter(typeof(VisualControlBoxConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
        public new VisualControlBox ControlBox
        {
            get
            {
                return _visualControlBox;
            }

            set
            {
                _visualControlBox = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Toggle)]
        public bool DropShadow
        {
            get
            {
                return _dropShadow;
            }

            set
            {
                _dropShadow = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Visible)]
        public new bool HelpButton
        {
            get
            {
                return _visualControlBox.HelpButton.Visible;
            }

            set
            {
                _visualControlBox.HelpButton.Visible = value;
            }
        }

        [Browsable(true)]
        public new Icon Icon
        {
            get
            {
                return base.Icon;
            }

            set
            {
                base.Icon = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(VisualBitmapConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
        public VisualBitmap Image
        {
            get
            {
                return _vsImage;
            }

            set
            {
                _vsImage = value;
                Invalidate();
            }
        }

        [DefaultValue(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("Snap window snaps toggles snapping to screen edges.")]
        public bool Magnetic
        {
            get
            {
                return _magnetic;
            }

            set
            {
                _magnetic = value;
            }
        }

        [DefaultValue(100)]
        [Category(PropertyCategory.Behavior)]
        [Description("The snap radius determines the distance to trigger the snap.")]
        public int MagneticRadius
        {
            get
            {
                return _magneticRadius;
            }

            set
            {
                _magneticRadius = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Visible)]
        public new bool MaximizeBox
        {
            get
            {
                return _visualControlBox.MaximizeButton.Visible;
            }

            set
            {
                _visualControlBox.MaximizeButton.Visible = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Visible)]
        public new bool MinimizeBox
        {
            get
            {
                return _visualControlBox.MinimizeButton.Visible;
            }

            set
            {
                _visualControlBox.MinimizeButton.Visible = value;
            }
        }

        [Category(PropertyCategory.WindowStyle)]
        [Description(PropertyDescription.ShowIcon)]
        public new bool ShowIcon
        {
            get
            {
                return _vsImage.Visible;
            }

            set
            {
                _vsImage.Visible = value;
            }
        }

        public bool Sizable { get; set; }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.MouseState)]
        public MouseStates State
        {
            get
            {
                return _mouseState;
            }

            set
            {
                _mouseState = value;
                Invalidate();
            }
        }

        /// <summary>Gets or sets the <see cref="Components.StyleManager" />.</summary>
        [Browsable(false)]
        [Category(PropertyCategory.Appearance)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleManager StyleManager
        {
            get
            {
                return _styleManager;
            }

            set
            {
                _styleManager = value;
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Rectangle)]
        public Rectangle TextRectangle
        {
            get
            {
                return _textRectangle;
            }

            set
            {
                _textRectangle = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Alignment)]
        public Alignment.TextAlignment TitleAlignment
        {
            get
            {
                return _titleAlignment;
            }

            set
            {
                _titleAlignment = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color WindowBarColor
        {
            get
            {
                return _windowBarColor;
            }

            set
            {
                _windowBarColor = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Size)]
        public int WindowBarHeight
        {
            get
            {
                return _windowBarHeight;
            }

            set
            {
                _windowBarHeight = value;
                Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams _parameter = base.CreateParams;

                // WS_SYSMENU: Trigger the creation of the system menu.
                // WS_MINIMIZEBOX: Allow minimizing from task bar.
                _parameter.Style = _parameter.Style | FormConstants.WS_MINIMIZEBOX | FormConstants.WS_SYSMENU; // Turn on the WS_MINIMIZEBOX style flag

                if (_dropShadow)
                {
                    _parameter.ClassStyle |= 0x20000;
                }

                return _parameter;
            }
        }

        #endregion

        #region Overrides

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DoubleBuffered = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            State = MouseStates.Hover;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            State = MouseStates.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if ((e.Button == MouseButtons.Left) && !_maximized)
            {
                ResizeForm(_resizeDir);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (DesignMode)
            {
                return;
            }

            if (Sizable)
            {
                // True if the mouse is hovering over a child control
                bool isChildUnderMouse = GetChildAtPoint(e.Location) != null;

                if ((e.Location.X < _border.Thickness) && (e.Location.Y > Height - _border.Thickness) && !isChildUnderMouse && !_maximized)
                {
                    _resizeDir = ResizeDirection.BottomLeft;
                    Cursor = Cursors.SizeNESW;
                }
                else if ((e.Location.X < _border.Thickness) && !isChildUnderMouse && !_maximized)
                {
                    _resizeDir = ResizeDirection.Left;
                    Cursor = Cursors.SizeWE;
                }
                else if ((e.Location.X > Width - _border.Thickness) && (e.Location.Y > Height - _border.Thickness) && !isChildUnderMouse && !_maximized)
                {
                    _resizeDir = ResizeDirection.BottomRight;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((e.Location.X > Width - _border.Thickness) && !isChildUnderMouse && !_maximized)
                {
                    _resizeDir = ResizeDirection.Right;
                    Cursor = Cursors.SizeWE;
                }
                else if ((e.Location.Y > Height - _border.Thickness) && !isChildUnderMouse && !_maximized)
                {
                    _resizeDir = ResizeDirection.Bottom;
                    Cursor = Cursors.SizeNS;
                }
                else
                {
                    _resizeDir = ResizeDirection.None;

                    // Only reset the cursor when needed, this prevents it from flickering when a child control changes the cursor to its own needs
                    if (((IList)_resizeCursors).Contains(Cursor))
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            base.OnMouseUp(e);
            User32.ReleaseCapture();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                Graphics graphics = e.Graphics;
                graphics.Clear(BackColor);

                GraphicsPath _clientPath = VisualBorderRenderer.CreateBorderTypePath(GetBorderBounds(), _border);

                if (_border.Type != ShapeType.Rectangle)
                {
                    graphics.SetClip(_clientPath);
                }

                graphics.FillRectangle(new SolidBrush(_background), new Rectangle(0, 0, Width, Height));

                if (BackgroundImage != null)
                {
                    Rectangle _windowWithoutTitleBar = new Rectangle(1, _textRectangle.Bottom, ClientRectangle.Width + 1, ClientRectangle.Height + 1);
                    graphics.DrawImage(BackgroundImage, _windowWithoutTitleBar);
                }

                DrawWindowTitleBar(graphics);
                graphics.ResetClip();
                VisualBorderRenderer.DrawBorderStyle(graphics, _border, _clientPath, State);
            }
            catch (Exception exception)
            {
                VisualExceptionDialog.Show(exception);
            }
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            if (!_magnetic)
            {
                return;
            }

            Screen _screen = Screen.FromPoint(Location);
            if (DoSnap(Left, _screen.WorkingArea.Left))
            {
                Left = _screen.WorkingArea.Left;
            }

            if (DoSnap(Top, _screen.WorkingArea.Top))
            {
                Top = _screen.WorkingArea.Top;
            }

            if (DoSnap(_screen.WorkingArea.Right, Right))
            {
                Left = _screen.WorkingArea.Right - Width;
            }

            if (DoSnap(_screen.WorkingArea.Bottom, Bottom))
            {
                Top = _screen.WorkingArea.Bottom - Height;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (DesignMode || IsDisposed)
            {
                return;
            }

            if ((m.Msg == FormConstants.WM_MOUSEMOVE) && _maximized && _titleBarRectangle.Contains(PointToClient(Cursor.Position)))
            {
                if (_headerMouseDown)
                {
                    _maximized = false;
                    _headerMouseDown = false;

                    Point mousePoint = PointToClient(Cursor.Position);
                    if (mousePoint.X < Width / 2)
                    {
                        Location = mousePoint.X < _previousSize.Width / 2 ? new Point(Cursor.Position.X - mousePoint.X, Cursor.Position.Y - mousePoint.Y) : new Point(Cursor.Position.X - (_previousSize.Width / 2), Cursor.Position.Y - mousePoint.Y);
                    }
                    else
                    {
                        Location = Width - mousePoint.X < _previousSize.Width / 2 ? new Point(((Cursor.Position.X - _previousSize.Width) + Width) - mousePoint.X, Cursor.Position.Y - mousePoint.Y) : new Point(Cursor.Position.X - (_previousSize.Width / 2), Cursor.Position.Y - mousePoint.Y);
                    }

                    Size = _previousSize;
                    User32.ReleaseCapture();
                    User32.SendMessage(Handle, FormConstants.WM_NCLBUTTONDOWN, FormConstants.HT_CAPTION, 0);
                }
            }
            else if ((m.Msg == FormConstants.WM_LBUTTONDOWN) && _titleBarRectangle.Contains(PointToClient(Cursor.Position)))
            {
                if (!_maximized)
                {
                    User32.ReleaseCapture();
                    User32.SendMessage(Handle, FormConstants.WM_NCLBUTTONDOWN, FormConstants.HT_CAPTION, 0);
                }
                else
                {
                    _headerMouseDown = true;
                }
            }
            else if (m.Msg == FormConstants.WM_RBUTTONDOWN)
            {
                Point cursorPos = PointToClient(Cursor.Position);

                if (_titleBarRectangle.Contains(cursorPos))
                {
                    // Show default system menu when right clicking title bar
                    int id = User32.TrackPopupMenuEx(User32.GetSystemMenu(Handle, false), FormConstants.TPM_LEFTALIGN | FormConstants.TPM_RETURNCMD, Cursor.Position.X, Cursor.Position.Y, Handle, IntPtr.Zero);

                    // Pass the command as a WM_SYSCOMMAND message
                    User32.SendMessage(Handle, FormConstants.WM_SYSCOMMAND, id, 0);
                }
            }
            else if (m.Msg == FormConstants.WM_NCLBUTTONDOWN)
            {
                // This re-enables resizing by letting the application know when the
                // user is trying to resize a side. This is disabled by default when using WS_SYSMENU.
                if (!Sizable)
                {
                    return;
                }

                byte bFlag = 0;

                // Get which side to resize from
                if (_resizedLocationsCommand.ContainsKey((int)m.WParam))
                {
                    bFlag = (byte)_resizedLocationsCommand[(int)m.WParam];
                }

                if (bFlag != 0)
                {
                    User32.SendMessage(Handle, FormConstants.WM_SYSCOMMAND, 0xF000 | bFlag, (int)m.LParam);
                }
            }
            else if (m.Msg == FormConstants.WM_LBUTTONUP)
            {
                _headerMouseDown = false;
            }
        }

        /// <summary>Invokes the theme changed event.</summary>
        /// <param name="e">The event args.</param>
        protected virtual void OnThemeChanged(ThemeEventArgs e)
        {
            Invalidate();
            ThemeChanged?.Invoke(e);
        }

        #endregion

        #region Methods

        /// <summary>Snap the position to edge.</summary>
        /// <param name="position">The position.</param>
        /// <param name="edge">The edge.</param>
        /// <returns>The <see cref="bool" />.</returns>
        private bool DoSnap(int position, int edge)
        {
            return (position - edge > 0) && (position - edge <= _magneticRadius);
        }

        /// <summary>Draws the title icon image.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawImageIcon(Graphics graphics)
        {
            VisualBitmap.DrawImage(graphics, _vsImage.Border, _vsImage.Point, _vsImage.Image, _vsImage.Size, _vsImage.Visible);
        }

        /// <summary>Draws the text title.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawTitle(Graphics graphics)
        {
            try
            {
                Size _textSize = GraphicsManager.MeasureTextRenderer(Text, Font);

                // Fixes: Lower hanging characters like 'g'.
                _textSize.Height = _textSize.Height + 1;

                Point _titleLocation;

                switch (_titleAlignment)
                {
                    case Alignment.TextAlignment.Center:
                        {
                            _titleLocation = new Point((Width / 2) - (_textSize.Width / 2), _textRectangle.Y);
                            break;
                        }

                    case Alignment.TextAlignment.Left:
                        {
                            _titleLocation = new Point(_vsImage.Point.X + _vsImage.Size.Width + 1, _textRectangle.Y);
                            break;
                        }

                    case Alignment.TextAlignment.Right:
                        {
                            _titleLocation = new Point(Width - _border.Thickness - _textSize.Width - _visualControlBox.Width - 1, _textRectangle.Y);
                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }

                _textRectangle = new Rectangle(_titleLocation.X, _titleLocation.Y, _textSize.Width, _textSize.Height);
                graphics.DrawString(Text, Font, new SolidBrush(ForeColor), _textRectangle);
            }
            catch (Exception e)
            {
                VisualExceptionDialog.Show(e);
            }
        }

        /// <summary>Draws the window title bar.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawWindowTitleBar(Graphics graphics)
        {
            _titleBarRectangle = new Rectangle(0, 0, Width, _windowBarHeight);
            graphics.FillRectangle(new SolidBrush(_windowBarColor), _titleBarRectangle);

            DrawImageIcon(graphics);
            DrawTitle(graphics);
        }

        /// <summary>Retrieves the border bounds.</summary>
        /// <returns>The <see cref="Rectangle" />.</returns>
        private Rectangle GetBorderBounds()
        {
            Rectangle _borderBounds;
            switch (_border.Type)
            {
                case ShapeType.Rectangle:
                    {
                        _borderBounds = new Rectangle(1, 1, Width, Height);
                        break;
                    }

                case ShapeType.Rounded:
                    {
                        _borderBounds = new Rectangle(0, 0, Width - 1, Height - 1);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            return _borderBounds;
        }

        /// <summary>Initialize the components text.</summary>
        /// <param name="text">The text associated with this control.</param>
        private void InitializeText(string text)
        {
            // Fixes: Virtual member call in constructor.
            Text = text;
        }

        private void OnGlobalMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            // Convert to client position and pass to Form.MouseMove
            Point _clientCursorLocation = PointToClient(e.Location);
            MouseEventArgs _mouseEventArgs = new MouseEventArgs(MouseButtons.None, 0, _clientCursorLocation.X, _clientCursorLocation.Y, 0);
            OnMouseMove(_mouseEventArgs);
        }

        /// <summary>Resize the form using the resize direction.</summary>
        /// <param name="direction">The direction.</param>
        private void ResizeForm(ResizeDirection direction)
        {
            if (DesignMode)
            {
                return;
            }

            int _resizeDirection = -1;
            switch (direction)
            {
                case ResizeDirection.BottomLeft:
                    {
                        _resizeDirection = FormConstants.HTBOTTOMLEFT;
                        break;
                    }

                case ResizeDirection.Left:
                    {
                        _resizeDirection = FormConstants.HTLEFT;
                        break;
                    }

                case ResizeDirection.Right:
                    {
                        _resizeDirection = FormConstants.HTRIGHT;
                        break;
                    }

                case ResizeDirection.BottomRight:
                    {
                        _resizeDirection = FormConstants.HTBOTTOMRIGHT;
                        break;
                    }

                case ResizeDirection.Bottom:
                    {
                        _resizeDirection = FormConstants.HTBOTTOM;
                        break;
                    }

                case ResizeDirection.None:
                    {
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                    }
            }

            User32.ReleaseCapture();
            if (_resizeDirection != -1)
            {
                User32.SendMessage(Handle, FormConstants.WM_NCLBUTTONDOWN, _resizeDirection, 0);
            }
        }

        /// <summary>Creates a copy of the current object.</summary>
        /// <returns>The <see cref="object" />.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        public void UpdateTheme(Theme theme)
        {
            try
            {
                _styleManager = new StyleManager(theme);

                _background = theme.OtherSettings.FormBackground;
                _border.Color = theme.BorderSettings.Normal;
                _border.HoverColor = theme.BorderSettings.Hover;
                ForeColor = theme.TextSetting.Enabled;
                Font = theme.TextSetting.Font;
                _windowBarColor = theme.OtherSettings.FormWindowBar;
            }
            catch (Exception e)
            {
                VisualExceptionDialog.Show(e);
            }

            OnThemeChanged(new ThemeEventArgs(theme));
        }

        private class MouseMessageFilter : IMessageFilter
        {
            #region Events

            public static event MouseEventHandler MouseMove;

            #endregion

            #region Methods

            public bool PreFilterMessage(ref Message m)
            {
                if ((m.Msg != FormConstants.WM_MOUSEMOVE) || (MouseMove == null))
                {
                    return false;
                }

                MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, MousePosition.X, MousePosition.Y, 0));
                return false;
            }

            #endregion
        }

        #endregion
    }
}