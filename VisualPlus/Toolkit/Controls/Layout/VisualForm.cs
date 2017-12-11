namespace VisualPlus.Toolkit.Controls.Layout
{
    #region Namespace

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Delegates;
<<<<<<< HEAD
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Managers;
=======
    using VisualPlus.Designer;
    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Managers;
    using VisualPlus.PInvoke;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Properties;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;

    #endregion

<<<<<<< HEAD
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(Form))]
    [Description("The Visual Form")]
    [Designer(ControlManager.FilterProperties.VisualForm)]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual Form")]
    [Designer(typeof(VisualFormDesigner))]
    [DesignerCategory("Form")]
    [InitializationEvent("Load")]
    [ToolboxBitmap(typeof(VisualForm), "Resources.ToolboxBitmaps.VisualForm.bmp")]
    [ToolboxItem(false)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualForm : Form
    {
        #region Variables

        private readonly Cursor[] _resizeCursors;
        private readonly Dictionary<int, int> _resizedLocationsCommand;
        private Color _background;
        private Border _border;
<<<<<<< HEAD
        private Color _buttonBackHoverColor;
        private Color _buttonBackPressedColor;
        private Size _buttonSize;
        private ButtonState _buttonState;
        private Color _closeColor;
        private bool _headerMouseDown;
        private bool _magnetic;
        private int _magneticRadius;
        private Rectangle _maxButtonBounds;
        private Color _maxColor;
        private bool _maximized;
        private Rectangle _minButtonBounds;
        private Color _minColor;
        private MouseStates _mouseState;
        private Point _previousLocation;
=======
        private bool _headerMouseDown;
        private bool _magnetic;
        private int _magneticRadius;
        private bool _maximized;
        private MouseStates _mouseState;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private Size _previousSize;
        private ResizeDirection _resizeDir;
        private Rectangle _statusBarBounds;
        private VisualStyleManager _styleManager;
        private Alignment.TextAlignment _titleAlignment;
        private Size _titleTextSize;
        private VisualBitmap _vsImage;
        private Color _windowBarColor;
        private int _windowBarHeight;
<<<<<<< HEAD
        private Rectangle _xButtonBounds;
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:VisualPlus.Toolkit.Controls.Layout.VisualForm" /> class.</summary>
        public VisualForm()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            _styleManager = new VisualStyleManager(Settings.DefaultValue.DefaultStyle);
            _resizeCursors = new[] { Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeWE, Cursors.SizeNS };

            _resizedLocationsCommand = new Dictionary<int, int>
                {
                    { HTTOP, WMSZ_TOP },
                    { HTTOPLEFT, WMSZ_TOPLEFT },
                    { HTTOPRIGHT, WMSZ_TOPRIGHT },
                    { HTLEFT, WMSZ_LEFT },
                    { HTRIGHT, WMSZ_RIGHT },
                    { HTBOTTOM, WMSZ_BOTTOM },
                    { HTBOTTOMLEFT, WMSZ_BOTTOMLEFT },
                    { HTBOTTOMRIGHT, WMSZ_BOTTOMRIGHT }
                };

            _titleAlignment = Alignment.TextAlignment.Center;
            FormBorderStyle = FormBorderStyle.None;
            Sizable = true;
<<<<<<< HEAD
            _closeColor = Color.IndianRed;
            _buttonBackHoverColor = _styleManager.ControlColorStateStyle.ControlHover;
            _buttonBackPressedColor = _styleManager.ControlColorStateStyle.ControlPressed;
            _buttonState = ButtonState.None;
            _maxColor = _styleManager.ControlStyle.FlatButtonEnabled;
            _minColor = _styleManager.ControlStyle.FlatButtonEnabled;
            _buttonSize = new Size(25, 25);
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _windowBarColor = _styleManager.ControlStyle.Background(0);
            _background = _styleManager.ControlStyle.Background(3);
            _magneticRadius = 100;
            _magnetic = true;
            _windowBarHeight = 30;
            TransparencyKey = Color.Fuchsia;
            DoubleBuffered = true;

<<<<<<< HEAD
            // Padding-Left: 5 for icon
            Padding = new Padding(5, 0, 0, 0);
=======
            Padding = new Padding(0, 0, 0, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            _border = new Border
                {
                    Thickness = 3,
                    Type = ShapeType.Rectangle
                };

            _vsImage = new VisualBitmap(Resources.VisualPlus, new Size(16, 16)) { Visible = true };
<<<<<<< HEAD
=======
            _vsImage.Point = new Point(5, (_windowBarHeight / 2) - (_vsImage.Size.Height / 2));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            // This enables the form to trigger the MouseMove event even when mouse is over another control
            Application.AddMessageFilter(new MouseMessageFilter());
            MouseMessageFilter.MouseMove += OnGlobalMouseMove;
        }

        [Category(Localization.Category.Events.Appearance)]
        [Description(Property.Color)]
        public event BackgroundChangedEventHandler BackgroundChanged;

        public enum ButtonState
        {
            /// <summary>The x over.</summary>
            XOver,

            /// <summary>The max over.</summary>
            MaxOver,

            /// <summary>The min over.</summary>
            MinOver,

            /// <summary>The x down.</summary>
            XDown,

            /// <summary>The max down.</summary>
            MaxDown,

            /// <summary>The min down.</summary>
            MinDown,

            /// <summary>The None.</summary>
            None
        }

<<<<<<< HEAD
        #endregion

        #region Properties

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
                OnBackgroundChanged(new ColorEventArgs(_background));
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
        public Color ButtonBackHoverColor
        {
            get
            {
                return _buttonBackHoverColor;
            }

            set
            {
                _buttonBackHoverColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonBackPressedColor
        {
            get
            {
                return _buttonBackPressedColor;
            }

            set
            {
                _buttonBackPressedColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonCloseColor
        {
            get
            {
                return _closeColor;
            }

            set
            {
                _closeColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonMaximizeColor
        {
            get
            {
                return _maxColor;
            }

            set
            {
                _maxColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ButtonMinimizeColor
        {
            get
            {
                return _minColor;
=======
        public enum ControlBoxAlignment
        {
            /// <summary>The bottom.</summary>
            Bottom,

            /// <summary>The center.</summary>
            Center,

            /// <summary>The top.</summary>
            Top
        }

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

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color Background
        {
            get
            {
                return _background;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _minColor = value;
=======
                _background = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

<<<<<<< HEAD
        [Category(Propertys.Layout)]
        [Description(Property.Size)]
        public Size ButtonSize
        {
            get
            {
                return _buttonSize;
=======
        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Appearance)]
        public Border Border
        {
            get
            {
                return _border;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _buttonSize = value;
=======
                _border = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

<<<<<<< HEAD
        [Browsable(false)]
=======
        [Browsable(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
        [Category(Propertys.Appearance)]
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
        [Category(Propertys.Behavior)]
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
        [Category(Propertys.Behavior)]
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

        [Category(Propertys.WindowStyle)]
        [Description(Property.ShowIcon)]
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

        [Category(Propertys.Appearance)]
        [Description(Property.MouseState)]
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

        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
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

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
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

        [Category(Propertys.Layout)]
        [Description(Property.Size)]
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
                CreateParams par = base.CreateParams;

                // WS_SYSMENU: Trigger the creation of the system menu
                // WS_MINIMIZEBOX: Allow minimizing from taskbar
                par.Style = par.Style | WS_MINIMIZEBOX | WS_SYSMENU; // Turn on the WS_MINIMIZEBOX style flag
                return par;
            }
        }

        #endregion

        #region Events

<<<<<<< HEAD
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_RBUTTONDOWN = 0x0204;

        protected virtual void OnBackgroundChanged(ColorEventArgs e)
        {
            GDI.ApplyContainerBackColorChange(this, Background);
            BackgroundChanged?.Invoke(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            GDI.SetControlBackColor(e.Control, Background, false);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            GDI.SetControlBackColor(e.Control, Background, true);
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            State = MouseStates.Hover;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            State = MouseStates.Hover;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            State = MouseStates.Normal;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            State = MouseStates.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

<<<<<<< HEAD
            UpdateButtons(e);

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            if ((e.Button == MouseButtons.Left) && !_maximized)
            {
                ResizeForm(_resizeDir);
            }

            base.OnMouseDown(e);
        }

<<<<<<< HEAD
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (DesignMode)
            {
                return;
            }

            if (_buttonState != ButtonState.None)
            {
                _buttonState = ButtonState.None;
                Invalidate();
            }
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
<<<<<<< HEAD

            UpdateButtons(e);
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

<<<<<<< HEAD
            UpdateButtons(e, true);

            base.OnMouseUp(e);
            Native.ReleaseCapture();
=======
            base.OnMouseUp(e);
            User32.ReleaseCapture();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.Default;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            Rectangle _clientRectangle;

            switch (_border.Type)
            {
                case ShapeType.Rectangle:
                    {
                        _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width + 1, ClientRectangle.Height + 1);
                        break;
                    }

                case ShapeType.Rounded:
                    {
                        _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            GraphicsPath _clientPath = VisualBorderRenderer.CreateBorderTypePath(_clientRectangle, _border);

            graphics.SetClip(_clientPath);
            graphics.FillPath(new SolidBrush(_background), _clientPath);

            // Title box
            graphics.FillRectangle(new SolidBrush(_windowBarColor), _statusBarBounds);

<<<<<<< HEAD
            DrawButtons(graphics);
            DrawIcon(graphics);
=======
            DrawImageIcon(graphics);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            graphics.SetClip(_clientPath);

            DrawTitle(graphics);

            graphics.ResetClip();

            VisualBorderRenderer.DrawBorderStyle(graphics, _border, _clientPath, State);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
<<<<<<< HEAD
            _minButtonBounds = new Rectangle(Width - Padding.Right - (3 * _buttonSize.Width), (Padding.Top + (_windowBarHeight / 2)) - (_buttonSize.Height / 2), _buttonSize.Width, _buttonSize.Height);
            _maxButtonBounds = new Rectangle(Width - Padding.Right - (2 * _buttonSize.Width), (Padding.Top + (_windowBarHeight / 2)) - (_buttonSize.Height / 2), _buttonSize.Width, _buttonSize.Height);
            _xButtonBounds = new Rectangle(Width - Padding.Right - _buttonSize.Width, (Padding.Top + (_windowBarHeight / 2)) - (_buttonSize.Height / 2), _buttonSize.Width, _buttonSize.Height);
=======
            _vsImage.Point = new Point(_vsImage.Point.X, (_windowBarHeight / 2) - (_vsImage.Size.Height / 2));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _statusBarBounds = new Rectangle(0, 0, Width, _windowBarHeight);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            if (_magnetic)
            {
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
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (DesignMode || IsDisposed)
            {
                return;
            }

<<<<<<< HEAD
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                MaximizeWindow(!_maximized);
            }
            else if ((m.Msg == WM_MOUSEMOVE) && _maximized && _statusBarBounds.Contains(PointToClient(Cursor.Position)) && !(_minButtonBounds.Contains(PointToClient(Cursor.Position)) || _maxButtonBounds.Contains(PointToClient(Cursor.Position)) || _xButtonBounds.Contains(PointToClient(Cursor.Position))))
=======
            if ((m.Msg == WM_MOUSEMOVE) && _maximized && _statusBarBounds.Contains(PointToClient(Cursor.Position)))
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
<<<<<<< HEAD
                    Native.ReleaseCapture();
                    Native.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            else if ((m.Msg == WM_LBUTTONDOWN) && _statusBarBounds.Contains(PointToClient(Cursor.Position)) && !(_minButtonBounds.Contains(PointToClient(Cursor.Position)) || _maxButtonBounds.Contains(PointToClient(Cursor.Position)) || _xButtonBounds.Contains(PointToClient(Cursor.Position))))
            {
                if (!_maximized)
                {
                    Native.ReleaseCapture();
                    Native.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
=======
                    User32.ReleaseCapture();
                    User32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            else if ((m.Msg == WM_LBUTTONDOWN) && _statusBarBounds.Contains(PointToClient(Cursor.Position)))
            {
                if (!_maximized)
                {
                    User32.ReleaseCapture();
                    User32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
                else
                {
                    _headerMouseDown = true;
                }
            }
            else if (m.Msg == WM_RBUTTONDOWN)
            {
                Point cursorPos = PointToClient(Cursor.Position);

<<<<<<< HEAD
                if (_statusBarBounds.Contains(cursorPos) && !_minButtonBounds.Contains(cursorPos) &&
                    !_maxButtonBounds.Contains(cursorPos) && !_xButtonBounds.Contains(cursorPos))
                {
                    // Show default system menu when right clicking titlebar
                    int id = Native.TrackPopupMenuEx(Native.GetSystemMenu(Handle, false), TPM_LEFTALIGN | TPM_RETURNCMD, Cursor.Position.X, Cursor.Position.Y, Handle, IntPtr.Zero);

                    // Pass the command as a WM_SYSCOMMAND message
                    Native.SendMessage(Handle, WM_SYSCOMMAND, id, 0);
=======
                if (_statusBarBounds.Contains(cursorPos))
                {
                    // Show default system menu when right clicking titlebar
                    int id = User32.TrackPopupMenuEx(User32.GetSystemMenu(Handle, false), TPM_LEFTALIGN | TPM_RETURNCMD, Cursor.Position.X, Cursor.Position.Y, Handle, IntPtr.Zero);

                    // Pass the command as a WM_SYSCOMMAND message
                    User32.SendMessage(Handle, WM_SYSCOMMAND, id, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
            }
            else if (m.Msg == WM_NCLBUTTONDOWN)
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
<<<<<<< HEAD
                    Native.SendMessage(Handle, WM_SYSCOMMAND, 0xF000 | bFlag, (int)m.LParam);
=======
                    User32.SendMessage(Handle, WM_SYSCOMMAND, 0xF000 | bFlag, (int)m.LParam);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
            }
            else if (m.Msg == WM_LBUTTONUP)
            {
                _headerMouseDown = false;
            }
        }

<<<<<<< HEAD
=======
        private const int HT_CAPTION = 0x2;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
<<<<<<< HEAD

        private const int MONITOR_DEFAULTTONEAREST = 2;

        private const uint TPM_LEFTALIGN = 0x0000;
        private const uint TPM_RETURNCMD = 0x0100;

=======
        private const int MONITOR_DEFAULTTONEAREST = 2;
        private const uint TPM_LEFTALIGN = 0x0000;
        private const uint TPM_RETURNCMD = 0x0100;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_RBUTTONDOWN = 0x0204;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private const int WM_SYSCOMMAND = 0x0112;
        private const int WMSZ_BOTTOM = 6;
        private const int WMSZ_BOTTOMLEFT = 7;
        private const int WMSZ_BOTTOMRIGHT = 8;
        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
<<<<<<< HEAD

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private const int WMSZ_TOP = 3;
        private const int WMSZ_TOPLEFT = 4;
        private const int WMSZ_TOPRIGHT = 5;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int WS_SYSMENU = 0x00080000;

        /// <summary>Snap the position to edge.</summary>
        /// <param name="position">The position.</param>
        /// <param name="edge">The edge.</param>
        /// <returns>Does a snap.</returns>
        private bool DoSnap(int position, int edge)
        {
            return (position - edge > 0) && (position - edge <= _magneticRadius);
        }

<<<<<<< HEAD
        private void DrawButtons(Graphics graphics)
        {
            // Determine whether or not we even should be drawing the buttons.
            bool showMin = MinimizeBox && ControlBox;
            bool showMax = MaximizeBox && ControlBox;
            SolidBrush hoverBrush = new SolidBrush(_buttonBackHoverColor);
            SolidBrush downBrush = new SolidBrush(_buttonBackPressedColor);

            // When MaximizeButton == false, the minimize button will be painted in its place
            DrawMinimizeOverMaximizeButton(graphics, showMin, showMax, hoverBrush, downBrush);

            var penWidth = 2;
            Pen minPen = new Pen(_minColor, penWidth);
            Pen maxPen = new Pen(_maxColor, penWidth);
            Pen closePen = new Pen(_closeColor, penWidth);

            // Minimize button.
            if (showMin)
            {
                int x = showMax ? _minButtonBounds.X : _maxButtonBounds.X;
                int y = showMax ? _minButtonBounds.Y : _maxButtonBounds.Y;

                graphics.DrawLine(
                    minPen,
                    x + (int)(_minButtonBounds.Width * 0.33),
                    y + (int)(_minButtonBounds.Height * 0.66),
                    x + (int)(_minButtonBounds.Width * 0.66),
                    y + (int)(_minButtonBounds.Height * 0.66));
            }

            // Maximize button
            if (showMax)
            {
                graphics.DrawRectangle(
                    maxPen,
                    _maxButtonBounds.X + (int)(_maxButtonBounds.Width * 0.33),
                    _maxButtonBounds.Y + (int)(_maxButtonBounds.Height * 0.36),
                    (int)(_maxButtonBounds.Width * 0.39),
                    (int)(_maxButtonBounds.Height * 0.35));

                graphics.DrawRectangle(
                    maxPen,
                    _maxButtonBounds.X + (int)(_maxButtonBounds.Width * 0.33),
                    _maxButtonBounds.Y + (int)(_maxButtonBounds.Height * 0.36),
                    (int)(_maxButtonBounds.Width * 0.39),
                    (int)(_maxButtonBounds.Height * 0.08));
            }

            // Close button
            if (ControlBox)
            {
                graphics.DrawLine(
                    closePen,
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66));

                graphics.DrawLine(
                    closePen,
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66));
            }
        }

        private void DrawIcon(Graphics graphics)
        {
            _vsImage.Point = new Point(Padding.Left, (_statusBarBounds.Height / 2) - (_vsImage.Size.Height / 2));
            VisualBitmap.DrawImage(graphics, _vsImage.Border, _vsImage.Point, _vsImage.Image, _vsImage.Size, _vsImage.Visible);
        }

        private void DrawMinimizeOverMaximizeButton(Graphics graphics, bool showMin, bool showMax, SolidBrush hoverBrush, SolidBrush downBrush)
        {
            if ((_buttonState == ButtonState.MinOver) && showMin)
            {
                graphics.FillRectangle(hoverBrush, showMax ? _minButtonBounds : _maxButtonBounds);
            }

            if ((_buttonState == ButtonState.MinDown) && showMin)
            {
                graphics.FillRectangle(downBrush, showMax ? _minButtonBounds : _maxButtonBounds);
            }

            if ((_buttonState == ButtonState.MaxOver) && showMax)
            {
                graphics.FillRectangle(hoverBrush, _maxButtonBounds);
            }

            if ((_buttonState == ButtonState.MaxDown) && showMax)
            {
                graphics.FillRectangle(downBrush, _maxButtonBounds);
            }

            if ((_buttonState == ButtonState.XOver) && ControlBox)
            {
                graphics.FillRectangle(hoverBrush, _xButtonBounds);
            }

            if ((_buttonState == ButtonState.XDown) && ControlBox)
            {
                graphics.FillRectangle(downBrush, _xButtonBounds);
            }
        }

        private void DrawTitle(Graphics graphics)
        {
            _titleTextSize = GDI.MeasureText(graphics, Text, Font);
=======
        private void DrawImageIcon(Graphics graphics)
        {
            VisualBitmap.DrawImage(graphics, _vsImage.Border, _vsImage.Point, _vsImage.Image, _vsImage.Size, _vsImage.Visible);
        }

        private void DrawTitle(Graphics graphics)
        {
            _titleTextSize = GraphicsManager.MeasureText(graphics, Text, Font);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Point titlePoint;

            switch (_titleAlignment)
            {
                case Alignment.TextAlignment.Center:
                    {
                        titlePoint = new Point((Width / 2) - (_titleTextSize.Width / 2), (_windowBarHeight / 2) - (_titleTextSize.Height / 2));
                        break;
                    }

                case Alignment.TextAlignment.Left:
                    {
<<<<<<< HEAD
                        titlePoint = new Point(5 + _vsImage.Size.Width + 5, (_windowBarHeight / 2) - (_titleTextSize.Height / 2));
=======
                        titlePoint = new Point(_vsImage.Point.X + _vsImage.Size.Width, (_windowBarHeight / 2) - (_titleTextSize.Height / 2));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                case Alignment.TextAlignment.Right:
                    {
<<<<<<< HEAD
                        titlePoint = new Point(_minButtonBounds.Left - 5 - _titleTextSize.Width, (_windowBarHeight / 2) - (_titleTextSize.Height / 2));
=======
                        titlePoint = new Point(Width - _border.Thickness - _titleTextSize.Width, (_windowBarHeight / 2) - (_titleTextSize.Height / 2));
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            Rectangle textRectangle = new Rectangle(titlePoint.X, titlePoint.Y, Width, _titleTextSize.Height);
            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle);
        }

<<<<<<< HEAD
        private void MaximizeWindow(bool maximize)
        {
            if (!MaximizeBox || !ControlBox)
            {
                return;
            }

            _maximized = maximize;

            if (maximize)
            {
                IntPtr monitorHandle = Native.MonitorFromWindow(Handle, MONITOR_DEFAULTTONEAREST);
                MonitorInfo monitorInfo = new MonitorInfo();
                Native.GetMonitorInfo(new HandleRef(null, monitorHandle), monitorInfo);
                _previousSize = Size;
                _previousLocation = Location;
                Size = new Size(monitorInfo.rcWork.Width(), monitorInfo.rcWork.Height());
                Location = new Point(monitorInfo.rcWork.left, monitorInfo.rcWork.top);
            }
            else
            {
                Size = _previousSize;
                Location = _previousLocation;
            }
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private void OnGlobalMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            // Convert to client position and pass to Form.MouseMove
            Point clientCursorPos = PointToClient(e.Location);
            MouseEventArgs newE = new MouseEventArgs(MouseButtons.None, 0, clientCursorPos.X, clientCursorPos.Y, 0);
            OnMouseMove(newE);
        }

        private void ResizeForm(ResizeDirection direction)
        {
            if (DesignMode)
            {
                return;
            }

<<<<<<< HEAD
            int dir = -1;
=======
            int _dir = -1;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            switch (direction)
            {
                case ResizeDirection.BottomLeft:
                    {
<<<<<<< HEAD
                        dir = HTBOTTOMLEFT;
=======
                        _dir = HTBOTTOMLEFT;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                case ResizeDirection.Left:
                    {
<<<<<<< HEAD
                        dir = HTLEFT;
=======
                        _dir = HTLEFT;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                case ResizeDirection.Right:
                    {
<<<<<<< HEAD
                        dir = HTRIGHT;
=======
                        _dir = HTRIGHT;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                case ResizeDirection.BottomRight:
                    {
<<<<<<< HEAD
                        dir = HTBOTTOMRIGHT;
=======
                        _dir = HTBOTTOMRIGHT;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        break;
                    }

                case ResizeDirection.Bottom:
                    {
<<<<<<< HEAD
                        dir = HTBOTTOM;
                        break;
                    }
            }

            Native.ReleaseCapture();
            if (dir != -1)
            {
                Native.SendMessage(Handle, WM_NCLBUTTONDOWN, dir, 0);
            }
        }

        private void UpdateButtons(MouseEventArgs e, bool up = false)
        {
            if (DesignMode)
            {
                return;
            }

            ButtonState oldState = _buttonState;
            bool showMin = MinimizeBox && ControlBox;
            bool showMax = MaximizeBox && ControlBox;

            if ((e.Button == MouseButtons.Left) && !up)
            {
                if (showMin && !showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinDown;
                }
                else if (showMin && showMax && _minButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinDown;
                }
                else if (showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MaxDown;
                }
                else if (ControlBox && _xButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.XDown;
                }
                else
                {
                    _buttonState = ButtonState.None;
                }
            }
            else
            {
                if (showMin && !showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinOver;

                    if ((oldState == ButtonState.MinDown) && up)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
                else if (showMin && showMax && _minButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinOver;

                    if ((oldState == ButtonState.MinDown) && up)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
                else if (MaximizeBox && ControlBox && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MaxOver;

                    if ((oldState == ButtonState.MaxDown) && up)
                    {
                        MaximizeWindow(!_maximized);
                    }
                }
                else if (ControlBox && _xButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.XOver;

                    if ((oldState == ButtonState.XDown) && up)
                    {
                        Close();
                    }
                }
                else
                {
                    _buttonState = ButtonState.None;
                }
            }

            if (oldState != _buttonState)
            {
                Invalidate(_maxButtonBounds);
                Invalidate(_minButtonBounds);
                Invalidate(_xButtonBounds);
=======
                        _dir = HTBOTTOM;
                        break;
                    }

                case ResizeDirection.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            User32.ReleaseCapture();
            if (_dir != -1)
            {
                User32.SendMessage(Handle, WM_NCLBUTTONDOWN, _dir, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }
        }

        #endregion

        #region Methods

<<<<<<< HEAD
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public class MonitorInfo
        {
            #region Variables

            public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));
            public int dwFlags = 0;
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szDevice = new char[32];

            #endregion
        }

        public class MouseMessageFilter : IMessageFilter
=======
        private class MouseMessageFilter : IMessageFilter
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        {
            #region Constructors

            public static event MouseEventHandler MouseMove;

            #endregion

            #region Events

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
                    if (MouseMove != null)
                    {
                        int x = MousePosition.X, y = MousePosition.Y;

                        MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, x, y, 0));
                    }
                }

                return false;
            }

            private const int WM_MOUSEMOVE = 0x0200;

            #endregion
        }

<<<<<<< HEAD
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public int Width()
            {
                return right - left;
            }

            public int Height()
            {
                return bottom - top;
            }
        }

        internal enum ResizeDirection
        {
            BottomLeft,
            Left,
            Right,
            BottomRight,
            Bottom,
            None
        }

        private enum ControlBoxAlignment
        {
            /// <summary>The bottom.</summary>
            Bottom,

            /// <summary>The center.</summary>
            Center,

            /// <summary>The top.</summary>
            Top
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        #endregion
    }
}