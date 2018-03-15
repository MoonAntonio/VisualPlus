namespace VisualPlus.Toolkit.Controls.Layout
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Designer;
    using VisualPlus.EventArgs;
    using VisualPlus.Localization;
    using VisualPlus.Native;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Dialogs;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Scroll")]
    [DefaultProperty("Value")]
    [Description("The Visual ScrollBar")]
    [Designer(typeof(VisualScrollBarDesigner))]
    [ToolboxBitmap(typeof(VisualScrollBar), "VisualScrollBar.bmp")]
    [ToolboxItem(true)]
    public class VisualScrollBar : VisualStyleBase, IThemeSupport
    {
        #region Variables

        private int _arrowHeight;
        private int _arrowWidth;
        private Color _borderColor;
        private bool _bottomArrowClicked;
        private Rectangle _bottomArrowRectangle;
        private bool _bottomBarClicked;
        private VisualScrollBarArrowButtonState _bottomButtonState;
        private Rectangle _channelRectangle;
        private Rectangle _clickedBarRectangle;
        private IContainer _components;
        private ContextMenuStrip _contextMenu;
        private Color _disabledBorderColor;
        private bool _inUpdate;
        private int _largeChange;
        private int _maximum;
        private int _minimum;
        private Orientation _orientation;
        private Timer _progressTimer;
        private ScrollOrientation _scrollOrientation;
        private int _smallChange;
        private int _thumbBottomLimitBottom;
        private int _thumbBottomLimitTop;
        private bool _thumbClicked;
        private int _thumbHeight;
        private int _thumbPosition;
        private Rectangle _thumbRectangle;
        private VisualScrollBarState _thumbState;
        private int _thumbTopLimit;
        private int _thumbWidth;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripSeparator _toolStripSeparator3;
        private bool _topArrowClicked;
        private Rectangle _topArrowRectangle;
        private bool _topBarClicked;
        private VisualScrollBarArrowButtonState _topButtonState;
        private int _trackPosition;
        private ToolStripMenuItem _tsmiBottom;
        private ToolStripMenuItem _tsmiLargeDown;
        private ToolStripMenuItem _tsmiLargeUp;
        private ToolStripMenuItem _tsmiScrollHere;
        private ToolStripMenuItem _tsmiSmallDown;
        private ToolStripMenuItem _tsmiSmallUp;
        private ToolStripMenuItem _tsmiTop;
        private int _value;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualScrollBar" /> class.</summary>
        public VisualScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            InitializeComponent();

            Width = 19;
            Height = 200;

            _topButtonState = VisualScrollBarArrowButtonState.UpNormal;
            _thumbWidth = 15;
            _thumbState = VisualScrollBarState.Normal;
            _smallChange = 1;
            _scrollOrientation = ScrollOrientation.VerticalScroll;
            _progressTimer = new Timer();
            _orientation = Orientation.Vertical;
            _maximum = 100;
            _largeChange = 10;
            _bottomButtonState = VisualScrollBarArrowButtonState.DownNormal;
            _arrowWidth = 15;
            _arrowHeight = 17;

            // timer for clicking and holding the mouse button
            // over/below the thumb and on the arrow buttons
            _progressTimer.Interval = 20;
            _progressTimer.Tick += ProgressTimerTick;

            _contextMenu.ShowImageMargin = false;

            // this.ContextMenuStrip = contextMenu;
            UpdateTheme(ThemeManager.Theme);
            ConfigureScrollBar();
        }

        [Category(Localization.Category.Events.Behavior)]
        [Description(PropertyDescription.ScrollBars)]
        public event ScrollEventHandler Scroll;

        public enum VisualScrollBarArrowButtonState
        {
            /// <summary>Indicates the up arrow is in normal state.</summary>
            UpNormal,

            /// <summary>Indicates the up arrow is in hot state.</summary>
            UpHot,

            /// <summary>Indicates the up arrow is in active state.</summary>
            UpActive,

            /// <summary>Indicates the up arrow is in pressed state.</summary>
            UpPressed,

            /// <summary>Indicates the up arrow is in disabled state.</summary>
            UpDisabled,

            /// <summary>Indicates the down arrow is in normal state.</summary>
            DownNormal,

            /// <summary>Indicates the down arrow is in hot state.</summary>
            DownHot,

            /// <summary>Indicates the down arrow is in active state.</summary>
            DownActive,

            /// <summary>Indicates the down arrow is in pressed state.</summary>
            DownPressed,

            /// <summary>Indicates the down arrow is in disabled state.</summary>
            DownDisabled
        }

        public enum VisualScrollBarState
        {
            /// <summary>Indicates a normal scrollbar state.</summary>
            Normal,

            /// <summary>Indicates a hot scrollbar state.</summary>
            Hot,

            /// <summary>Indicates an active scrollbar state.</summary>
            Active,

            /// <summary>Indicates a pressed scrollbar state.</summary>
            Pressed,

            /// <summary>Indicates a disabled scrollbar state.</summary>
            Disabled
        }

        #endregion

        #region Properties

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;

                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color DisabledBorderColor
        {
            get
            {
                return _disabledBorderColor;
            }

            set
            {
                _disabledBorderColor = value;

                Invalidate();
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.LargeChange)]
        [DefaultValue(10)]
        public int LargeChange
        {
            get
            {
                return _largeChange;
            }

            set
            {
                // no change or new large change value is invalid - return
                if ((value == _largeChange) || (value < _smallChange) || (value < 2))
                {
                    return;
                }

                // if value is greater than scroll area - adjust
                if (value > _maximum - _minimum)
                {
                    _largeChange = _maximum - _minimum;
                }
                else
                {
                    // set new value
                    _largeChange = value;
                }

                ConfigureScrollBar();
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Maximum)]
        [DefaultValue(100)]
        public int Maximum
        {
            get
            {
                return _maximum;
            }

            set
            {
                // no change or new max. value invalid - return
                if ((value == _maximum) || (value < 1) || (value <= _minimum))
                {
                    return;
                }

                _maximum = value;

                // is large change value invalid - adjust
                if (_largeChange > _maximum - _minimum)
                {
                    _largeChange = _maximum - _minimum;
                }

                ConfigureScrollBar();

                // is current value greater than new maximum value - adjust
                if (_value > value)
                {
                    Value = _maximum;
                }
                else
                {
                    // current value is valid - adjust thumb position
                    ChangeThumbPosition(GetThumbPosition());

                    Refresh();
                }
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Minimum)]
        [DefaultValue(0)]
        public int Minimum
        {
            get
            {
                return _minimum;
            }

            set
            {
                // no change or value invalid - return
                if ((_minimum == value) || (value < 0) || (value >= _maximum))
                {
                    return;
                }

                _minimum = value;

                // current value less than new _minimum value - adjust
                if (_value < value)
                {
                    _value = value;
                }

                // is current large change value invalid - adjust
                if (_largeChange > _maximum - _minimum)
                {
                    _largeChange = _maximum - _minimum;
                }

                ConfigureScrollBar();

                // current value less than new _minimum value - adjust
                if (_value < value)
                {
                    Value = value;
                }
                else
                {
                    // current value is valid - adjust thumb position
                    ChangeThumbPosition(GetThumbPosition());

                    Refresh();
                }
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Opacity)]
        [DefaultValue(typeof(double), "1")]
        public double Opacity
        {
            get
            {
                return _contextMenu.Opacity;
            }

            set
            {
                if (value == _contextMenu.Opacity)
                {
                    return;
                }

                _contextMenu.AllowTransparency = value != 1;
                _contextMenu.Opacity = value;
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Orientation)]
        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                // no change - return
                if (value == _orientation)
                {
                    return;
                }

                _orientation = value;

                // change text of context menu entries
                ChangeContextMenuItems();

                // save scroll orientation for scroll event
                _scrollOrientation = value == Orientation.Vertical ? ScrollOrientation.VerticalScroll : ScrollOrientation.HorizontalScroll;

                // only in DesignMode switch width and height
                if (DesignMode)
                {
                    Size = new Size(Height, Width);
                }

                // sets the scrollbar up
                ConfigureScrollBar();
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.SmallChange)]
        [DefaultValue(1)]
        public int SmallChange
        {
            get
            {
                return _smallChange;
            }

            set
            {
                // no change or new small change value invalid - return
                if ((value == _smallChange) || (value < 1) || (value >= _largeChange))
                {
                    return;
                }

                _smallChange = value;

                ConfigureScrollBar();
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Value)]
        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                // no change or invalid value - return
                if ((_value == value) || (value < _minimum) || (value > _maximum))
                {
                    return;
                }

                _value = value;

                // adjust thumb position
                ChangeThumbPosition(GetThumbPosition());

                // raise scroll event
                OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, -1, _value, _scrollOrientation));

                Refresh();
            }
        }

        #endregion

        #region Events

        /// <summary>Prevents the drawing of the control until <see cref="EndUpdate" /> is called.</summary>
        public void BeginUpdate()
        {
            User32.SendMessage(Handle, Constants.WM_SETREDRAW, false, 0);
            _inUpdate = true;
        }

        /// <summary>Ends the updating process and the control can draw itself again.</summary>
        public void EndUpdate()
        {
            User32.SendMessage(Handle, Constants.WM_SETREDRAW, true, 0);
            _inUpdate = false;
            ConfigureScrollBar();
            Refresh();
        }

        public void UpdateTheme(Theme theme)
        {
            try
            {
                _borderColor = theme.BorderSettings.Hover;
                _disabledBorderColor = theme.BorderSettings.Normal;
            }
            catch (Exception e)
            {
                VisualExceptionDialog.Show(e);
            }

            Invalidate();
            OnThemeChanged(new ThemeEventArgs(theme));
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            ContextMenuStrip = _contextMenu;
        }

        /// <summary>Raises the <see cref="System.Windows.Forms.Control.EnabledChanged" /> event.</summary>
        /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (Enabled)
            {
                _thumbState = VisualScrollBarState.Normal;
                _topButtonState = VisualScrollBarArrowButtonState.UpNormal;
                _bottomButtonState = VisualScrollBarArrowButtonState.DownNormal;
            }
            else
            {
                _thumbState = VisualScrollBarState.Disabled;
                _topButtonState = VisualScrollBarArrowButtonState.UpDisabled;
                _bottomButtonState = VisualScrollBarArrowButtonState.DownDisabled;
            }

            Refresh();
        }

        /// <summary>Raises the MouseDown event.</summary>
        /// <param name="e">A <see cref="MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Focus();

            if (e.Button == MouseButtons.Left)
            {
                // prevents showing the context menu if pressing the right mouse
                // button while holding the left
                ContextMenuStrip = null;

                Point mouseLocation = e.Location;

                if (_thumbRectangle.Contains(mouseLocation))
                {
                    _thumbClicked = true;
                    _thumbPosition = _orientation == Orientation.Vertical ? mouseLocation.Y - _thumbRectangle.Y : mouseLocation.X - _thumbRectangle.X;
                    _thumbState = VisualScrollBarState.Pressed;

                    Invalidate(_thumbRectangle);
                }
                else if (_topArrowRectangle.Contains(mouseLocation))
                {
                    _topArrowClicked = true;
                    _topButtonState = VisualScrollBarArrowButtonState.UpPressed;

                    Invalidate(_topArrowRectangle);

                    ProgressThumb(true);
                }
                else if (_bottomArrowRectangle.Contains(mouseLocation))
                {
                    _bottomArrowClicked = true;
                    _bottomButtonState = VisualScrollBarArrowButtonState.DownPressed;

                    Invalidate(_bottomArrowRectangle);

                    ProgressThumb(true);
                }
                else
                {
                    _trackPosition = _orientation == Orientation.Vertical ? mouseLocation.Y : mouseLocation.X;

                    if (_trackPosition < (_orientation == Orientation.Vertical ? _thumbRectangle.Y : _thumbRectangle.X))
                    {
                        _topBarClicked = true;
                    }
                    else
                    {
                        _bottomBarClicked = true;
                    }

                    ProgressThumb(true);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                _trackPosition = _orientation == Orientation.Vertical ? e.Y : e.X;
            }
        }

        /// <summary>Raises the MouseEnter event.</summary>
        /// <param name="e">A <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            _bottomButtonState = VisualScrollBarArrowButtonState.DownActive;
            _topButtonState = VisualScrollBarArrowButtonState.UpActive;
            _thumbState = VisualScrollBarState.Active;

            Invalidate();
        }

        /// <summary>Raises the MouseLeave event.</summary>
        /// <param name="e">A <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            ResetScrollStatus();
        }

        /// <summary>Raises the MouseMove event.</summary>
        /// <param name="e">A <see cref="MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // moving and holding the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                // Update the thumb position, if the new location is within the bounds.
                if (_thumbClicked)
                {
                    int oldScrollValue = _value;

                    _topButtonState = VisualScrollBarArrowButtonState.UpActive;
                    _bottomButtonState = VisualScrollBarArrowButtonState.DownActive;
                    int pos = _orientation == Orientation.Vertical ? e.Location.Y : e.Location.X;

                    // The thumb is all the way to the top
                    if (pos <= _thumbTopLimit + _thumbPosition)
                    {
                        ChangeThumbPosition(_thumbTopLimit);

                        _value = _minimum;
                    }
                    else if (pos >= _thumbBottomLimitTop + _thumbPosition)
                    {
                        // The thumb is all the way to the bottom
                        ChangeThumbPosition(_thumbBottomLimitTop);

                        _value = _maximum;
                    }
                    else
                    {
                        // The thumb is between the ends of the track.
                        ChangeThumbPosition(pos - _thumbPosition);

                        int pixelRange, thumbPos, arrowSize;

                        // calculate the value - first some helper variables
                        // dependent on the current orientation
                        if (_orientation == Orientation.Vertical)
                        {
                            pixelRange = Height - (2 * _arrowHeight) - _thumbHeight;
                            thumbPos = _thumbRectangle.Y;
                            arrowSize = _arrowHeight;
                        }
                        else
                        {
                            pixelRange = Width - (2 * _arrowWidth) - _thumbWidth;
                            thumbPos = _thumbRectangle.X;
                            arrowSize = _arrowWidth;
                        }

                        var _percent = 0f;

                        if (pixelRange != 0)
                        {
                            // percent of the new position
                            _percent = (thumbPos - arrowSize) / (float)pixelRange;
                        }

                        // the new value is somewhere between max and min, starting
                        // at min position
                        _value = Convert.ToInt32((_percent * (_maximum - _minimum)) + _minimum);
                    }

                    // raise scroll event if new value different
                    if (oldScrollValue != _value)
                    {
                        OnScroll(new ScrollEventArgs(ScrollEventType.ThumbTrack, oldScrollValue, _value, _scrollOrientation));

                        Refresh();
                    }
                }
            }
            else if (!ClientRectangle.Contains(e.Location))
            {
                ResetScrollStatus();
            }
            else if (e.Button == MouseButtons.None)
            {
                // only moving the mouse
                if (_topArrowRectangle.Contains(e.Location))
                {
                    _topButtonState = VisualScrollBarArrowButtonState.UpHot;

                    Invalidate(_topArrowRectangle);
                }
                else if (_bottomArrowRectangle.Contains(e.Location))
                {
                    _bottomButtonState = VisualScrollBarArrowButtonState.DownHot;

                    Invalidate(_bottomArrowRectangle);
                }
                else if (_thumbRectangle.Contains(e.Location))
                {
                    _thumbState = VisualScrollBarState.Hot;

                    Invalidate(_thumbRectangle);
                }
                else if (ClientRectangle.Contains(e.Location))
                {
                    _topButtonState = VisualScrollBarArrowButtonState.UpActive;
                    _bottomButtonState = VisualScrollBarArrowButtonState.DownActive;
                    _thumbState = VisualScrollBarState.Active;

                    Invalidate();
                }
            }
        }

        /// <summary>Raises the MouseUp event.</summary>
        /// <param name="e">A <see cref="MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                ContextMenuStrip = _contextMenu;

                if (_thumbClicked)
                {
                    _thumbClicked = false;
                    _thumbState = VisualScrollBarState.Normal;

                    OnScroll(new ScrollEventArgs(
                        ScrollEventType.EndScroll,
                        -1,
                        _value,
                        _scrollOrientation));
                }
                else if (_topArrowClicked)
                {
                    _topArrowClicked = false;
                    _topButtonState = VisualScrollBarArrowButtonState.UpNormal;
                    StopTimer();
                }
                else if (_bottomArrowClicked)
                {
                    _bottomArrowClicked = false;
                    _bottomButtonState = VisualScrollBarArrowButtonState.DownNormal;
                    StopTimer();
                }
                else if (_topBarClicked)
                {
                    _topBarClicked = false;
                    StopTimer();
                }
                else if (_bottomBarClicked)
                {
                    _bottomBarClicked = false;
                    StopTimer();
                }

                Invalidate();
            }
        }

        /// <summary>Paints the control.</summary>
        /// <param name="e">A <see cref="PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // sets the smoothing mode to none
            e.Graphics.SmoothingMode = SmoothingMode.None;

            // save client rectangle
            Rectangle rect = ClientRectangle;

            // adjust the rectangle
            if (_orientation == Orientation.Vertical)
            {
                rect.X++;
                rect.Y += _arrowHeight + 1;
                rect.Width -= 2;
                rect.Height -= (_arrowHeight * 2) + 2;
            }
            else
            {
                rect.X += _arrowWidth + 1;
                rect.Y++;
                rect.Width -= (_arrowWidth * 2) + 2;
                rect.Height -= 2;
            }

            // draws the background
            VisualScrollBarRenderer.DrawBackground(e.Graphics, ClientRectangle, _orientation);

            // draws the track
            VisualScrollBarRenderer.DrawTrack(e.Graphics, rect, VisualScrollBarState.Normal, _orientation);

            // draw thumb and grip
            VisualScrollBarRenderer.DrawThumb(e.Graphics, _thumbRectangle, _thumbState, _orientation);

            if (Enabled)
            {
                VisualScrollBarRenderer.DrawThumbGrip(e.Graphics, _thumbRectangle, _orientation);
            }

            // draw arrows
            VisualScrollBarRenderer.DrawArrowButton(e.Graphics, _topArrowRectangle, _topButtonState, true, _orientation);

            VisualScrollBarRenderer.DrawArrowButton(e.Graphics, _bottomArrowRectangle, _bottomButtonState, false, _orientation);

            // check if top or bottom bar was clicked
            if (_topBarClicked)
            {
                if (_orientation == Orientation.Vertical)
                {
                    _clickedBarRectangle.Y = _thumbTopLimit;
                    _clickedBarRectangle.Height = _thumbRectangle.Y - _thumbTopLimit;
                }
                else
                {
                    _clickedBarRectangle.X = _thumbTopLimit;
                    _clickedBarRectangle.Width = _thumbRectangle.X - _thumbTopLimit;
                }

                VisualScrollBarRenderer.DrawTrack(e.Graphics, _clickedBarRectangle, VisualScrollBarState.Pressed, _orientation);
            }
            else if (_bottomBarClicked)
            {
                if (_orientation == Orientation.Vertical)
                {
                    _clickedBarRectangle.Y = _thumbRectangle.Bottom + 1;
                    _clickedBarRectangle.Height = (_thumbBottomLimitBottom - _clickedBarRectangle.Y) + 1;
                }
                else
                {
                    _clickedBarRectangle.X = _thumbRectangle.Right + 1;
                    _clickedBarRectangle.Width = (_thumbBottomLimitBottom - _clickedBarRectangle.X) + 1;
                }

                VisualScrollBarRenderer.DrawTrack(e.Graphics, _clickedBarRectangle, VisualScrollBarState.Pressed, _orientation);
            }

            // draw border
            using (Pen pen = new Pen(Enabled ? _borderColor : _disabledBorderColor))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>Paints the background of the control.</summary>
        /// <param name="e">A <see cref="PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // no painting here
        }

        /// <summary>Raises the <see cref="Scroll" /> event.</summary>
        /// <param name="e">The <see cref="ScrollEventArgs" /> that contains the event data.</param>
        protected virtual void OnScroll(ScrollEventArgs e)
        {
            Scroll?.Invoke(this, e);
        }

        /// <summary>Raises the <see cref="System.Windows.Forms.Control.SizeChanged" /> event.</summary>
        /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ConfigureScrollBar();
        }

        /// <summary>Processes a dialog key.</summary>
        /// <param name="keyData">One of the <see cref="System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true, if the key was processed by the control, false otherwise.</returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // key handling is here - keys recognized by the control
            // Up&Down or Left&Right, PageUp, PageDown, Home, End
            Keys keyUp = Keys.Up;
            Keys keyDown = Keys.Down;

            if (_orientation == Orientation.Horizontal)
            {
                keyUp = Keys.Left;
                keyDown = Keys.Right;
            }

            if (keyData == keyUp)
            {
                Value -= _smallChange;

                return true;
            }

            if (keyData == keyDown)
            {
                Value += _smallChange;

                return true;
            }

            if (keyData == Keys.PageUp)
            {
                Value = GetValue(false, true);

                return true;
            }

            if (keyData == Keys.PageDown)
            {
                if (_value + _largeChange > _maximum)
                {
                    Value = _maximum;
                }
                else
                {
                    Value += _largeChange;
                }

                return true;
            }

            if (keyData == Keys.Home)
            {
                Value = _minimum;

                return true;
            }

            if (keyData == Keys.End)
            {
                Value = _maximum;

                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>Performs the work of setting the specified bounds of this control.</summary>
        /// <param name="x">The new x value of the control.</param>
        /// <param name="y">The new y value of the control.</param>
        /// <param name="width">The new width value of the control.</param>
        /// <param name="height">The new height value of the control.</param>
        /// <param name="specified">A bit-wise combination of the <see cref="BoundsSpecified" /> values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // only in design mode - constrain size
            if (DesignMode)
            {
                if (_orientation == Orientation.Vertical)
                {
                    if (height < (2 * _arrowHeight) + 10)
                    {
                        height = (2 * _arrowHeight) + 10;
                    }

                    width = 19;
                }
                else
                {
                    if (width < (2 * _arrowWidth) + 10)
                    {
                        width = (2 * _arrowWidth) + 10;
                    }

                    height = 19;
                }
            }

            base.SetBoundsCore(x, y, width, height, specified);

            if (DesignMode)
            {
                ConfigureScrollBar();
            }
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void BottomClick(object sender, EventArgs e)
        {
            Value = _maximum;
        }

        /// <summary>Changes the displayed text of the context menu items dependent of the current <see cref="Orientation" />.</summary>
        private void ChangeContextMenuItems()
        {
            if (_orientation == Orientation.Vertical)
            {
                _tsmiTop.Text = @"Top";
                _tsmiBottom.Text = @"Bottom";
                _tsmiLargeDown.Text = @"Page down";
                _tsmiLargeUp.Text = @"Page up";
                _tsmiSmallDown.Text = @"Scroll down";
                _tsmiSmallUp.Text = @"Scroll up";
                _tsmiScrollHere.Text = @"Scroll here";
            }
            else
            {
                _tsmiTop.Text = @"Left";
                _tsmiBottom.Text = @"Right";
                _tsmiLargeDown.Text = @"Page left";
                _tsmiLargeUp.Text = @"Page right";
                _tsmiSmallDown.Text = @"Scroll right";
                _tsmiSmallUp.Text = @"Scroll left";
                _tsmiScrollHere.Text = @"Scroll here";
            }
        }

        /// <summary>Changes the position of the thumb.</summary>
        /// <param name="position">The new position.</param>
        private void ChangeThumbPosition(int position)
        {
            if (_orientation == Orientation.Vertical)
            {
                _thumbRectangle.Y = position;
            }
            else
            {
                _thumbRectangle.X = position;
            }
        }

        /// <summary>Sets up the scrollbar.</summary>
        private void ConfigureScrollBar()
        {
            // if no drawing - return
            if (_inUpdate)
            {
                return;
            }

            // set up the width's, height's and rectangles for the different
            // elements
            if (_orientation == Orientation.Vertical)
            {
                _arrowHeight = 17;
                _arrowWidth = 15;
                _thumbWidth = 15;
                _thumbHeight = GetThumbSize();

                _clickedBarRectangle = ClientRectangle;
                _clickedBarRectangle.Inflate(-1, -1);
                _clickedBarRectangle.Y += _arrowHeight;
                _clickedBarRectangle.Height -= _arrowHeight * 2;

                _channelRectangle = _clickedBarRectangle;

                _thumbRectangle = new Rectangle(
                    ClientRectangle.X + 2,
                    ClientRectangle.Y + _arrowHeight + 1,
                    _thumbWidth - 1,
                    _thumbHeight);

                _topArrowRectangle = new Rectangle(
                    ClientRectangle.X + 2,
                    ClientRectangle.Y + 1,
                    _arrowWidth,
                    _arrowHeight);

                _bottomArrowRectangle = new Rectangle(
                    ClientRectangle.X + 2,
                    ClientRectangle.Bottom - _arrowHeight - 1,
                    _arrowWidth,
                    _arrowHeight);

                // Set the default starting thumb position.
                _thumbPosition = _thumbRectangle.Height / 2;

                // Set the bottom limit of the thumb's bottom border.
                _thumbBottomLimitBottom =
                    ClientRectangle.Bottom - _arrowHeight - 2;

                // Set the bottom limit of the thumb's top border.
                _thumbBottomLimitTop =
                    _thumbBottomLimitBottom - _thumbRectangle.Height;

                // Set the top limit of the thumb's top border.
                _thumbTopLimit = ClientRectangle.Y + _arrowHeight + 1;
            }
            else
            {
                _arrowHeight = 15;
                _arrowWidth = 17;
                _thumbHeight = 15;
                _thumbWidth = GetThumbSize();

                _clickedBarRectangle = ClientRectangle;
                _clickedBarRectangle.Inflate(-1, -1);
                _clickedBarRectangle.X += _arrowWidth;
                _clickedBarRectangle.Width -= _arrowWidth * 2;

                _channelRectangle = _clickedBarRectangle;

                _thumbRectangle = new Rectangle(
                    ClientRectangle.X + _arrowWidth + 1,
                    ClientRectangle.Y + 2,
                    _thumbWidth,
                    _thumbHeight - 1);

                _topArrowRectangle = new Rectangle(
                    ClientRectangle.X + 1,
                    ClientRectangle.Y + 2,
                    _arrowWidth,
                    _arrowHeight);

                _bottomArrowRectangle = new Rectangle(
                    ClientRectangle.Right - _arrowWidth - 1,
                    ClientRectangle.Y + 2,
                    _arrowWidth,
                    _arrowHeight);

                // Set the default starting thumb position.
                _thumbPosition = _thumbRectangle.Width / 2;

                // Set the bottom limit of the thumb's bottom border.
                _thumbBottomLimitBottom =
                    ClientRectangle.Right - _arrowWidth - 2;

                // Set the bottom limit of the thumb's top border.
                _thumbBottomLimitTop =
                    _thumbBottomLimitBottom - _thumbRectangle.Width;

                // Set the top limit of the thumb's top border.
                _thumbTopLimit = ClientRectangle.X + _arrowWidth + 1;
            }

            ChangeThumbPosition(GetThumbPosition());

            Refresh();
        }

        /// <summary>Enables the timer.</summary>
        private void EnableTimer()
        {
            // if timer is not already enabled - enable it
            if (!_progressTimer.Enabled)
            {
                _progressTimer.Interval = 600;
                _progressTimer.Start();
            }
            else
            {
                // if already enabled, change tick time
                _progressTimer.Interval = 10;
            }
        }

        /// <summary>Calculates the new thumb position.</summary>
        /// <returns>The new thumb position.</returns>
        private int GetThumbPosition()
        {
            int pixelRange, arrowSize;

            if (_orientation == Orientation.Vertical)
            {
                pixelRange = Height - (2 * _arrowHeight) - _thumbHeight;
                arrowSize = _arrowHeight;
            }
            else
            {
                pixelRange = Width - (2 * _arrowWidth) - _thumbWidth;
                arrowSize = _arrowWidth;
            }

            int realRange = _maximum - _minimum;
            var _percent = 0f;

            if (realRange != 0)
            {
                _percent = (_value - (float)_minimum) / realRange;
            }

            return Math.Max(_thumbTopLimit, Math.Min(_thumbBottomLimitTop, Convert.ToInt32((_percent * pixelRange) + arrowSize)));
        }

        /// <summary>Calculates the height of the thumb.</summary>
        /// <returns>The height of the thumb.</returns>
        private int GetThumbSize()
        {
            int trackSize =
                _orientation == Orientation.Vertical ? Height - (2 * _arrowHeight) : Width - (2 * _arrowWidth);

            if ((_maximum == 0) || (_largeChange == 0))
            {
                return trackSize;
            }

            float newThumbSize = (_largeChange * (float)trackSize) / _maximum;

            return Convert.ToInt32(Math.Min(trackSize, Math.Max(newThumbSize, 10f)));
        }

        /// <summary>Calculates the new value of the scrollbar.</summary>
        /// <param name="smallIncrement">true for a small change, false otherwise.</param>
        /// <param name="up">true for up movement, false otherwise.</param>
        /// <returns>The new scrollbar value.</returns>
        private int GetValue(bool smallIncrement, bool up)
        {
            int newValue;

            // calculate the new value of the scrollbar
            // with checking if new value is in bounds (min/max)
            if (up)
            {
                newValue = _value - (smallIncrement ? _smallChange : _largeChange);

                if (newValue < _minimum)
                {
                    newValue = _minimum;
                }
            }
            else
            {
                newValue = _value + (smallIncrement ? _smallChange : _largeChange);

                if (newValue > _maximum)
                {
                    newValue = _maximum;
                }
            }

            return newValue;
        }

        /// <summary>Initializes the context menu.</summary>
        private void InitializeComponent()
        {
            _components = new Container();
            _contextMenu = new ContextMenuStrip(_components);
            _tsmiScrollHere = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _tsmiTop = new ToolStripMenuItem();
            _tsmiBottom = new ToolStripMenuItem();
            _toolStripSeparator2 = new ToolStripSeparator();
            _tsmiLargeUp = new ToolStripMenuItem();
            _tsmiLargeDown = new ToolStripMenuItem();
            _toolStripSeparator3 = new ToolStripSeparator();
            _tsmiSmallUp = new ToolStripMenuItem();
            _tsmiSmallDown = new ToolStripMenuItem();
            _contextMenu.SuspendLayout();
            SuspendLayout();

            // contextMenu
            _contextMenu.Items.AddRange(new ToolStripItem[]
                {
                    _tsmiScrollHere,
                    _toolStripSeparator1,
                    _tsmiTop,
                    _tsmiBottom,
                    _toolStripSeparator2,
                    _tsmiLargeUp,
                    _tsmiLargeDown,
                    _toolStripSeparator3,
                    _tsmiSmallUp,
                    _tsmiSmallDown
                });
            _contextMenu.Name = "_contextMenu";
            _contextMenu.Size = new Size(151, 176);

            // tsmiScrollHere
            _tsmiScrollHere.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiScrollHere.Name = "_tsmiScrollHere";
            _tsmiScrollHere.Size = new Size(150, 22);
            _tsmiScrollHere.Text = @"Scroll here";
            _tsmiScrollHere.Click += ScrollHereClick;

            // toolStripSeparator1
            _toolStripSeparator1.Name = "_toolStripSeparator1";
            _toolStripSeparator1.Size = new Size(147, 6);

            // tsmiTop
            _tsmiTop.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiTop.Name = "_tsmiTop";
            _tsmiTop.Size = new Size(150, 22);
            _tsmiTop.Text = @"Top";
            _tsmiTop.Click += TopClick;

            // tsmiBottom
            _tsmiBottom.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiBottom.Name = "_tsmiBottom";
            _tsmiBottom.Size = new Size(150, 22);
            _tsmiBottom.Text = @"Bottom";
            _tsmiBottom.Click += BottomClick;

            // toolStripSeparator2
            _toolStripSeparator2.Name = "_toolStripSeparator2";
            _toolStripSeparator2.Size = new Size(147, 6);

            // tsmiLargeUp
            _tsmiLargeUp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiLargeUp.Name = "_tsmiLargeUp";
            _tsmiLargeUp.Size = new Size(150, 22);
            _tsmiLargeUp.Text = @"Page up";
            _tsmiLargeUp.Click += LargeUpClick;

            // tsmiLargeDown
            _tsmiLargeDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiLargeDown.Name = "_tsmiLargeDown";
            _tsmiLargeDown.Size = new Size(150, 22);
            _tsmiLargeDown.Text = @"Page down";
            _tsmiLargeDown.Click += LargeDownClick;

            // toolStripSeparator3
            _toolStripSeparator3.Name = "_toolStripSeparator3";
            _toolStripSeparator3.Size = new Size(147, 6);

            // tsmiSmallUp
            _tsmiSmallUp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiSmallUp.Name = "_tsmiSmallUp";
            _tsmiSmallUp.Size = new Size(150, 22);
            _tsmiSmallUp.Text = @"Scroll up";
            _tsmiSmallUp.Click += SmallUpClick;

            // tsmiSmallDown
            _tsmiSmallDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _tsmiSmallDown.Name = "_tsmiSmallDown";
            _tsmiSmallDown.Size = new Size(150, 22);
            _tsmiSmallDown.Text = @"Scroll down";
            _tsmiSmallDown.Click += SmallDownClick;
            _contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LargeDownClick(object sender, EventArgs e)
        {
            Value = GetValue(false, false);
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void LargeUpClick(object sender, EventArgs e)
        {
            Value = GetValue(false, true);
        }

        /// <summary>Controls the movement of the thumb.</summary>
        /// <param name="enableTimer">true for enabling the timer, false otherwise.</param>
        private void ProgressThumb(bool enableTimer)
        {
            int scrollOldValue = _value;
            ScrollEventType type = ScrollEventType.First;
            int thumbSize, thumbPos;

            if (_orientation == Orientation.Vertical)
            {
                thumbPos = _thumbRectangle.Y;
                thumbSize = _thumbRectangle.Height;
            }
            else
            {
                thumbPos = _thumbRectangle.X;
                thumbSize = _thumbRectangle.Width;
            }

            // arrow down or shaft down clicked
            if (_bottomArrowClicked || (_bottomBarClicked && (thumbPos + thumbSize < _trackPosition)))
            {
                type = _bottomArrowClicked ? ScrollEventType.SmallIncrement : ScrollEventType.LargeIncrement;

                _value = GetValue(_bottomArrowClicked, false);

                if (_value == _maximum)
                {
                    ChangeThumbPosition(_thumbBottomLimitTop);

                    type = ScrollEventType.Last;
                }
                else
                {
                    ChangeThumbPosition(Math.Min(_thumbBottomLimitTop, GetThumbPosition()));
                }
            }
            else if (_topArrowClicked || (_topBarClicked && (thumbPos > _trackPosition)))
            {
                type = _topArrowClicked ? ScrollEventType.SmallDecrement : ScrollEventType.LargeDecrement;

                // arrow up or shaft up clicked
                _value = GetValue(_topArrowClicked, true);

                if (_value == _minimum)
                {
                    ChangeThumbPosition(_thumbTopLimit);

                    type = ScrollEventType.First;
                }
                else
                {
                    ChangeThumbPosition(Math.Max(_thumbTopLimit, GetThumbPosition()));
                }
            }
            else if (!((_topArrowClicked && (thumbPos == _thumbTopLimit)) || (_bottomArrowClicked && (thumbPos == _thumbBottomLimitTop))))
            {
                ResetScrollStatus();

                return;
            }

            if (scrollOldValue != _value)
            {
                OnScroll(new ScrollEventArgs(type, scrollOldValue, _value, _scrollOrientation));

                Invalidate(_channelRectangle);

                if (enableTimer)
                {
                    EnableTimer();
                }
            }
            else
            {
                if (_topArrowClicked)
                {
                    type = ScrollEventType.SmallDecrement;
                }
                else if (_bottomArrowClicked)
                {
                    type = ScrollEventType.SmallIncrement;
                }

                OnScroll(new ScrollEventArgs(type, _value));
            }
        }

        /// <summary>Handles the updating of the thumb.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">An object that contains the event data.</param>
        private void ProgressTimerTick(object sender, EventArgs e)
        {
            ProgressThumb(true);
        }

        /// <summary>Resets the scroll status of the scrollbar.</summary>
        private void ResetScrollStatus()
        {
            // get current mouse position
            Point pos = PointToClient(Cursor.Position);

            // set appearance of buttons in relation to where the mouse is -
            // outside or inside the control
            if (ClientRectangle.Contains(pos))
            {
                _bottomButtonState = VisualScrollBarArrowButtonState.DownActive;
                _topButtonState = VisualScrollBarArrowButtonState.UpActive;
            }
            else
            {
                _bottomButtonState = VisualScrollBarArrowButtonState.DownNormal;
                _topButtonState = VisualScrollBarArrowButtonState.UpNormal;
            }

            // set appearance of thumb
            _thumbState = _thumbRectangle.Contains(pos) ? VisualScrollBarState.Hot : VisualScrollBarState.Normal;

            _bottomArrowClicked = _bottomBarClicked =
                                      _topArrowClicked = _topBarClicked = false;

            StopTimer();

            Refresh();
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ScrollHereClick(object sender, EventArgs e)
        {
            int thumbSize, thumbPos, arrowSize, size;

            if (_orientation == Orientation.Vertical)
            {
                thumbSize = _thumbHeight;
                arrowSize = _arrowHeight;
                size = Height;

                ChangeThumbPosition(Math.Max(_thumbTopLimit, Math.Min(_thumbBottomLimitTop, _trackPosition - (_thumbRectangle.Height / 2))));

                thumbPos = _thumbRectangle.Y;
            }
            else
            {
                thumbSize = _thumbWidth;
                arrowSize = _arrowWidth;
                size = Width;

                ChangeThumbPosition(Math.Max(_thumbTopLimit, Math.Min(_thumbBottomLimitTop, _trackPosition - (_thumbRectangle.Width / 2))));

                thumbPos = _thumbRectangle.X;
            }

            int pixelRange = size - (2 * arrowSize) - thumbSize;
            float perc = 0f;

            if (pixelRange != 0)
            {
                perc = (thumbPos - arrowSize) / (float)pixelRange;
            }

            int oldValue = _value;

            _value = Convert.ToInt32((perc * (_maximum - _minimum)) + _minimum);

            OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, oldValue, _value, _scrollOrientation));

            Refresh();
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void SmallDownClick(object sender, EventArgs e)
        {
            Value = GetValue(true, false);
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void SmallUpClick(object sender, EventArgs e)
        {
            Value = GetValue(true, true);
        }

        /// <summary>Stops the progress timer.</summary>
        private void StopTimer()
        {
            _progressTimer.Stop();
        }

        /// <summary>Context menu handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void TopClick(object sender, EventArgs e)
        {
            Value = _minimum;
        }

        #endregion
    }
}