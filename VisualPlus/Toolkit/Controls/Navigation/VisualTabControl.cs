namespace VisualPlus.Toolkit.Controls.Navigation
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Windows.Forms;

    using VisualPlus.Collections;
    using VisualPlus.Designer;
    using VisualPlus.Enumerators;
    using VisualPlus.Localization;
    using VisualPlus.Managers;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Components;
    using VisualPlus.Toolkit.Dialogs;

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TabControl))]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("TabPages")]
    [Description("The Visual TabControl")]
    [Designer(typeof(VisualTabControlDesigner))]
    public class VisualTabControl : TabControl
    {
        #region Variables

        private TabAlignment _alignment;
        private bool _arrowSelectorVisible;
        private int _arrowSpacing;
        private int _arrowThickness;
        private Border _border;
        private Size _itemSize;
        private Point _mouseLocation;
        private MouseStates _mouseState;
        private Color _separator;
        private int _separatorSpacing;
        private float _separatorThickness;
        private bool _separatorVisible;
        private StyleManager _styleManager;
        private Color _tabMenu;
        private Color _tabSelector;
        private TextRenderingHint _textRendererHint;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualTabControl" /> class.</summary>
        public VisualTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            UpdateStyles();

            _styleManager = new StyleManager(Settings.DefaultValue.DefaultStyle);

            _border = new Border
                    {
                       Type = ShapeType.Rectangle 
                    };

            _alignment = TabAlignment.Top;
            _arrowSelectorVisible = true;
            _arrowSpacing = 10;
            _arrowThickness = 5;
            _itemSize = new Size(100, 25);

            _tabMenu = Color.FromArgb(55, 61, 73);
            _tabSelector = _styleManager.Theme.BackgroundSettings.Type4;
            _textRendererHint = Settings.DefaultValue.TextRenderingHint;

            _separatorSpacing = 2;
            _separatorThickness = 2F;
            _separator = _styleManager.Theme.OtherSettings.Line;

            Size = new Size(320, 160);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            ItemSize = _itemSize;
        }

        #endregion

        #region Properties

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Alignment)]
        public new TabAlignment Alignment
        {
            get
            {
                return _alignment;
            }

            set
            {
                _alignment = value;
                base.Alignment = _alignment;

                // Resize tabs
                switch (_alignment)
                {
                    case TabAlignment.Top:
                    case TabAlignment.Bottom:
                        {
                            if (_itemSize.Width < _itemSize.Height)
                            {
                                ItemSize = new Size(_itemSize.Height, _itemSize.Width);
                            }

                            break;
                        }

                    case TabAlignment.Left:
                    case TabAlignment.Right:
                        {
                            if (_itemSize.Width > _itemSize.Height)
                            {
                                ItemSize = new Size(_itemSize.Height, _itemSize.Width);
                            }

                            break;
                        }

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                UpdateArrowLocation();
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Visible)]
        public bool ArrowSelectorVisible
        {
            get
            {
                return _arrowSelectorVisible;
            }

            set
            {
                _arrowSelectorVisible = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Spacing)]
        public int ArrowSpacing
        {
            get
            {
                return _arrowSpacing;
            }

            set
            {
                _arrowSpacing = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Size)]
        public int ArrowThickness
        {
            get
            {
                return _arrowThickness;
            }

            set
            {
                _arrowThickness = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Size)]
        public new Size ItemSize
        {
            get
            {
                return _itemSize;
            }

            set
            {
                _itemSize = value;
                base.ItemSize = _itemSize;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Separator
        {
            get
            {
                return _separator;
            }

            set
            {
                _separator = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Spacing)]
        public int SeparatorSpacing
        {
            get
            {
                return _separatorSpacing;
            }

            set
            {
                _separatorSpacing = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Size)]
        public float SeparatorThickness
        {
            get
            {
                return _separatorThickness;
            }

            set
            {
                _separatorThickness = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Visible)]
        public bool SeparatorVisible
        {
            get
            {
                return _separatorVisible;
            }

            set
            {
                _separatorVisible = value;
                Invalidate();
            }
        }

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

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabMenu
        {
            get
            {
                return _tabMenu;
            }

            set
            {
                _tabMenu = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(VisualTabPageCollectionEditor), typeof(UITypeEditor))]
        [MergableProperty(false)]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabSelector
        {
            get
            {
                return _tabSelector;
            }

            set
            {
                _tabSelector = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.TextRenderingHint)]
        public TextRenderingHint TextRendering
        {
            get
            {
                return _textRendererHint;
            }

            set
            {
                _textRendererHint = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>Swaps the tab pages.</summary>
        /// <param name="tabPage1">The tab page.</param>
        /// <param name="tabPage2">The other tab page.</param>
        public void SwapTabPages(TabPage tabPage1, TabPage tabPage2)
        {
            if (!TabPages.Contains(tabPage1) || !TabPages.Contains(tabPage2))
            {
                throw new ArgumentException(@"TabPages must be in the TabControls TabPageCollection.");
            }

            int _index1 = TabPages.IndexOf(tabPage1);
            int _index2 = TabPages.IndexOf(tabPage2);

            TabPages[_index1] = tabPage2;
            TabPages[_index2] = tabPage1;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            Appearance = TabAppearance.Normal;
            DoubleBuffered = true;
            Font = _styleManager.Theme.TextSetting.Font;
            MinimumSize = new Size(144, 85);
            SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            GraphicsManager.SetControlBackColor(e.Control, Parent.BackColor, true);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            _mouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            State = MouseStates.Normal;
            if (TabPages.Cast<VisualTabPage>().Any(Tab => Tab.DisplayRectangle.Contains(_mouseLocation)))
            {
                Invalidate();
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _mouseLocation = e.Location;
            if (TabPages.Cast<VisualTabPage>().Any(Tab => Tab.DisplayRectangle.Contains(e.Location)))
            {
                Invalidate();
            }

            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            _graphics.Clear(Parent.BackColor);
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.CompositingMode = CompositingMode.SourceOver;
            _graphics.CompositingQuality = CompositingQuality.Default;
            _graphics.InterpolationMode = InterpolationMode.Default;
            _graphics.PixelOffsetMode = PixelOffsetMode.Default;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TextRenderingHint = _textRendererHint;

            VisualBackgroundRenderer.DrawBackground(_graphics, _tabMenu, BackgroundImage, _mouseState, ClientRectangle, _border);

            DrawTabPages(_graphics);
            DrawSeparator(_graphics);
            DrawSelector(_graphics);
        }

        /// <summary>Draws the headers border.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="tabPage">The tab page to draw.</param>
        private static void DrawHeaderBorder(Graphics graphics, VisualTabPage tabPage)
        {
            if (!tabPage.Border.Visible)
            {
                return;
            }

            GraphicsPath _borderGraphicsPath = new GraphicsPath();
            _borderGraphicsPath.AddRectangle(tabPage.Rectangle);
            Pen _borderPen = new Pen(tabPage.Border.Color, tabPage.Border.Thickness);
            graphics.DrawPath(_borderPen, _borderGraphicsPath);
        }

        /// <summary>Draws the selection arrow.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="rectangle">The rectangle.</param>
        private void DrawSelectionArrow(Graphics graphics, Rectangle rectangle)
        {
            var _arrow = new Point[3];

            switch (Alignment)
            {
                case TabAlignment.Left:
                    {
                        _arrow[0].X = rectangle.Right - ArrowThickness;
                        _arrow[0].Y = rectangle.Y + (rectangle.Height / 2);

                        _arrow[1].X = rectangle.Right + ArrowSpacing;
                        _arrow[1].Y = rectangle.Top + ArrowSpacing;

                        _arrow[2].X = rectangle.Right + ArrowSpacing;
                        _arrow[2].Y = rectangle.Bottom - ArrowSpacing;
                        break;
                    }

                case TabAlignment.Top:
                    {
                        _arrow[0].X = rectangle.X + (rectangle.Width / 2);
                        _arrow[0].Y = rectangle.Bottom - ArrowThickness;

                        _arrow[1].X = rectangle.Left + ArrowSpacing;
                        _arrow[1].Y = rectangle.Bottom + ArrowSpacing;

                        _arrow[2].X = rectangle.Right - ArrowSpacing;
                        _arrow[2].Y = rectangle.Bottom + ArrowSpacing;
                        break;
                    }

                case TabAlignment.Bottom:
                    {
                        _arrow[0].X = rectangle.X + (rectangle.Width / 2);
                        _arrow[0].Y = rectangle.Top + ArrowThickness;

                        _arrow[1].X = rectangle.Left + ArrowSpacing;
                        _arrow[1].Y = rectangle.Top - ArrowSpacing;

                        _arrow[2].X = rectangle.Right - ArrowSpacing;
                        _arrow[2].Y = rectangle.Top - ArrowSpacing;
                        break;
                    }

                case TabAlignment.Right:
                    {
                        _arrow[0].X = rectangle.Left + ArrowThickness;
                        _arrow[0].Y = rectangle.Y + (rectangle.Height / 2);

                        _arrow[1].X = rectangle.Left - ArrowSpacing;
                        _arrow[1].Y = rectangle.Top + ArrowSpacing;

                        _arrow[2].X = rectangle.Left - ArrowSpacing;
                        _arrow[2].Y = rectangle.Bottom - ArrowSpacing;
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            graphics.FillPolygon(new SolidBrush(_tabSelector), _arrow);
        }

        /// <summary>Draws the selector.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawSelector(Graphics graphics)
        {
            try
            {
                for (var tabIndex = 0; tabIndex <= TabCount - 1; tabIndex++)
                {
                    VisualTabPage _tabPage = (VisualTabPage)TabPages[tabIndex];
                    _tabPage.Rectangle = GetStyledTabRectangle(tabIndex);

                    if (tabIndex == SelectedIndex)
                    {
                        if (_arrowSelectorVisible)
                        {
                            DrawSelectionArrow(graphics, _tabPage.Rectangle);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                VisualExceptionDialog.Show(e);
            }
        }

        /// <summary>Draws the separator.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawSeparator(Graphics graphics)
        {
            if (!_separatorVisible)
            {
                return;
            }

            // Draw divider that separates the panels.
            switch (Alignment)
            {
                case TabAlignment.Top:
                    {
                        graphics.DrawLine(new Pen(_separator, _separatorThickness), 0, ItemSize.Height + _separatorSpacing, Width, ItemSize.Height + _separatorSpacing);
                        break;
                    }

                case TabAlignment.Bottom:
                    {
                        graphics.DrawLine(new Pen(_separator, _separatorThickness), 0, Height - ItemSize.Height - _separatorSpacing, Width, Height - ItemSize.Height - _separatorSpacing);
                        break;
                    }

                case TabAlignment.Left:
                    {
                        graphics.DrawLine(new Pen(_separator, _separatorThickness), ItemSize.Height + _separatorSpacing, 0, ItemSize.Height + _separatorSpacing, Height);
                        break;
                    }

                case TabAlignment.Right:
                    {
                        graphics.DrawLine(new Pen(_separator, _separatorThickness), Width - ItemSize.Height - _separatorSpacing, 0, Width - ItemSize.Height - _separatorSpacing, Height);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        /// <summary>Draws the tab pages.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        private void DrawTabPages(Graphics graphics)
        {
            try
            {
                for (var tabIndex = 0; tabIndex <= TabCount - 1; tabIndex++)
                {
                    VisualTabPage _tabPage = (VisualTabPage)TabPages[tabIndex];
                    _tabPage.Rectangle = GetStyledTabRectangle(tabIndex);

                    StringFormat _tabStringFormat = new StringFormat
                        {
                            Alignment = _tabPage.TextAlignment,
                            LineAlignment = _tabPage.TextLineAlignment
                        };

                    Rectangle _imageRectangle = new Rectangle(_tabPage.Rectangle.X + _tabPage.Border.Thickness + 1, (_tabPage.Rectangle.Y + (_tabPage.Rectangle.Height / 2)) - (_tabPage.ImageSize.Height / 2), _tabPage.ImageSize.Width, _tabPage.ImageSize.Height);
                    Size _textSize = GraphicsManager.MeasureText(graphics, _tabPage.Text, _tabPage.Font);

                    if (tabIndex == SelectedIndex)
                    {
                        // Draw selected TabPageHeader
                        graphics.FillRectangle(new SolidBrush(_tabPage.TabSelected), _tabPage.Rectangle);

                        if (_tabPage.HeaderImage != null)
                        {
                            graphics.DrawImage(_tabPage.HeaderImage, new Point(0, 0));
                        }

                        if ((_mouseState == MouseStates.Hover) && _tabPage.Rectangle.Contains(_mouseLocation))
                        {
                            // BUG: doesn't un-select on mouse leave.
                            // graphics.FillRectangle(new SolidBrush(_tabPage.TabHover), _tabPage.Rectangle);
                        }

                        DrawHeaderBorder(graphics, _tabPage);

                        if (_tabPage.Image != null)
                        {
                            graphics.DrawImage(_tabPage.Image, _imageRectangle);
                            graphics.DrawString(_tabPage.Text, _tabPage.Font, new SolidBrush(_tabPage.TextSelected), new Rectangle(_imageRectangle.Right + 1, (_tabPage.Rectangle.Y + (_tabPage.Rectangle.Height / 2)) - (_textSize.Height / 2), _tabPage.Rectangle.Width, _tabPage.Rectangle.Height));
                        }
                        else
                        {
                            graphics.DrawString(_tabPage.Text, _tabPage.Font, new SolidBrush(_tabPage.TextSelected), _tabPage.Rectangle, _tabStringFormat);
                        }
                    }
                    else
                    {
                        // Draw unselected TabPageHeaders
                        graphics.FillRectangle(new SolidBrush(_tabPage.TabNormal), _tabPage.Rectangle);

                        if ((_mouseState == MouseStates.Hover) && _tabPage.Rectangle.Contains(_mouseLocation))
                        {
                            graphics.FillRectangle(new SolidBrush(_tabPage.TabHover), _tabPage.Rectangle);
                        }

                        DrawHeaderBorder(graphics, _tabPage);

                        if (_tabPage.Image != null)
                        {
                            graphics.DrawImage(_tabPage.Image, _imageRectangle);
                            graphics.DrawString(_tabPage.Text, _tabPage.Font, new SolidBrush(_tabPage.ForeColor), new Rectangle(_imageRectangle.Right + 1, (_tabPage.Rectangle.Y + (_tabPage.Rectangle.Height / 2)) - (_textSize.Height / 2), _tabPage.Rectangle.Width, _tabPage.Rectangle.Height));
                        }
                        else
                        {
                            graphics.DrawString(_tabPage.Text, _tabPage.Font, new SolidBrush(_tabPage.ForeColor), _tabPage.Rectangle, _tabStringFormat);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                VisualExceptionDialog.Show(e);
            }
        }

        /// <summary>Retrieves the styled tab rectangle using the index.</summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Rectangle" />.</returns>
        private Rectangle GetStyledTabRectangle(int index)
        {
            Rectangle _rectangle;

            if ((Alignment == TabAlignment.Top) && (Alignment == TabAlignment.Bottom))
            {
                // Top - Bottom
                _rectangle = new Rectangle(new Point(GetTabRect(index).Location.X, GetTabRect(index).Location.Y), new Size(GetTabRect(index).Width, GetTabRect(index).Height));
            }
            else
            {
                // Left - Right
                _rectangle = new Rectangle(new Point(GetTabRect(index).Location.X, GetTabRect(index).Location.Y), new Size(GetTabRect(index).Width, GetTabRect(index).Height));
            }

            return _rectangle;
        }

        /// <summary>Update the arrow location.</summary>
        private void UpdateArrowLocation()
        {
            switch (_alignment)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    {
                        _arrowThickness = 5;
                        _arrowSpacing = 10;
                        break;
                    }

                case TabAlignment.Left:
                case TabAlignment.Right:
                    {
                        _arrowThickness = 10;
                        _arrowSpacing = 3;
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}