﻿namespace VisualPlus.Toolkit.Controls.Interactivity
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
<<<<<<< HEAD
=======
    using System.Linq;
    using System.Runtime.InteropServices;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Managers;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
<<<<<<< HEAD
    using VisualPlus.Toolkit.ActionList;
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Toolkit.Components;

    #endregion

<<<<<<< HEAD
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ComboBox))]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    [Description("The Visual ComboBox")]
    [Designer(ControlManager.FilterProperties.VisualComboBox, typeof(VisualComboBoxTasks))]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    [Description("The Visual ComboBox")]
    [ToolboxBitmap(typeof(ComboBox), "Resources.ToolboxBitmaps.VisualComboBox.bmp")]
    [ToolboxItem(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualComboBox : ComboBox
    {
        #region Variables

        private ColorState _backColorState;
        private Border _border;
        private BorderEdge _borderEdge;
        private Color _buttonColor;
<<<<<<< HEAD
        private Alignment.Horizontal _buttonHorizontal;
        private DropDownButtons _buttonStyles;
=======
        private Image _buttonImage;
        private ButtonStyles _buttonStyle;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private bool _buttonVisible;
        private int _buttonWidth;
        private GraphicsPath _controlGraphicsPath;
        private Color _foreColor;
<<<<<<< HEAD
        private Size _itemSize;
=======
        private ImageList _imageList;
        private bool _imageVisible;
        private int _index;
        private bool _itemImageVisible;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private Color _menuItemHover;
        private Color _menuItemNormal;
        private Color _menuTextColor;
        private MouseStates _mouseState;
<<<<<<< HEAD
        private int _startIndex;
        private VisualStyleManager _styleManager;
        private StringAlignment _textAlignment;
        private Color _textDisabledColor;
=======
        private VisualStyleManager _styleManager;
        private StringAlignment _textAlignment;
        private Color _textDisabledColor;
        private TextImageRelation _textImageRelation;
        private StringAlignment _textLineAlignment;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private TextRenderingHint _textRendererHint;
        private Watermark _watermark;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:VisualPlus.Toolkit.Controls.Interactivity.VisualComboBox" />
        ///     class.
        /// </summary>
        public VisualComboBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor,
                true);

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            _styleManager = new VisualStyleManager(Settings.DefaultValue.DefaultStyle);
<<<<<<< HEAD

            _buttonWidth = 30;
            _buttonHorizontal = Alignment.Horizontal.Right;
            _buttonStyles = DropDownButtons.Arrow;
            _buttonVisible = Settings.DefaultValue.TextVisible;
            _textAlignment = StringAlignment.Center;
            _watermark = new Watermark();
            _backColorState = new ColorState();
            _mouseState = MouseStates.Normal;
            DrawMode = DrawMode.OwnerDrawFixed;
=======
            _textImageRelation = TextImageRelation.ImageBeforeText;
            _textAlignment = StringAlignment.Center;
            _textLineAlignment = StringAlignment.Center;
            _itemImageVisible = true;
            _imageVisible = false;
            _buttonWidth = 30;
            _buttonStyle = ButtonStyles.Arrow;
            _buttonVisible = Settings.DefaultValue.TextVisible;
            _watermark = new Watermark();
            _mouseState = MouseStates.Normal;

            DrawMode = DrawMode.OwnerDrawVariable;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            DropDownStyle = ComboBoxStyle.DropDownList;

            _borderEdge = new BorderEdge();

            Size = new Size(135, 26);
<<<<<<< HEAD
            ItemHeight = 20;
            UpdateStyles();
            DropDownHeight = 100;

            BackColor = SystemColors.Control;

=======
            ItemHeight = 24;
            UpdateStyles();
            DropDownHeight = 100;

            // BackColor = SystemColors.Control;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _border = new Border();

            _textRendererHint = Settings.DefaultValue.TextRenderingHint;

            Controls.Add(_borderEdge);
<<<<<<< HEAD

            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        public enum DropDownButtons
        {
            /// <summary>Use arrow button.</summary>
            Arrow,

            /// <summary>Use bars button.</summary>
            Bars
=======
            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        public enum ButtonStyles
        {
            /// <summary>Arrow style.</summary>
            Arrow,

            /// <summary>Bars style.</summary>
            Bars,

            /// <summary>Image style.</summary>
            Image
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
                return _backColorState;
            }

            set
            {
                _backColorState = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Description(Property.Image)]
        public new Image BackgroundImage { get; set; }

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

<<<<<<< HEAD
        [Category(Propertys.Layout)]
        [Description(Property.Direction)]
        public Alignment.Horizontal ButtonHorizontal
        {
            get
            {
                return _buttonHorizontal;
=======
        [Category(Propertys.Appearance)]
        [Description(Property.Image)]
        public Image ButtonImage
        {
            get
            {
                return _buttonImage;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _buttonHorizontal = value;
=======
                _buttonImage = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Type)]
<<<<<<< HEAD
        public DropDownButtons ButtonStyles
        {
            get
            {
                return _buttonStyles;
=======
        public ButtonStyles ButtonStyle
        {
            get
            {
                return _buttonStyle;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _buttonStyles = value;
=======
                _buttonStyle = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

        [DefaultValue(Settings.DefaultValue.TextVisible)]
        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool ButtonVisible
        {
            get
            {
                return _buttonVisible;
            }

            set
            {
                _buttonVisible = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
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

        public new Color ForeColor
        {
            get
            {
                return _foreColor;
            }

            set
            {
                base.ForeColor = value;
                _foreColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
<<<<<<< HEAD
=======
        [Description(Property.Image)]
        public ImageList ImageList
        {
            get
            {
                return _imageList;
            }

            set
            {
                _imageList = value;
                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool ImageVisible
        {
            get
            {
                return _imageVisible;
            }

            set
            {
                _imageVisible = value;
                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        [Description(Property.StartIndex)]
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
                try
                {
                    SelectedIndex = value;
                }
                catch (Exception)
                {
                    // ignored
                }

                Invalidate();
            }
        }

        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool ItemImageVisible
        {
            get
            {
                return _itemImageVisible;
            }

            set
            {
                _itemImageVisible = value;
            }
        }

        [Category(Propertys.Appearance)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        [Description(Property.Color)]
        public Color MenuItemHover
        {
            get
            {
                return _menuItemHover;
            }

            set
            {
                _menuItemHover = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color MenuItemNormal
        {
            get
            {
                return _menuItemNormal;
            }

            set
            {
                _menuItemNormal = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color MenuTextColor
        {
            get
            {
                return _menuTextColor;
            }

            set
            {
                _menuTextColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.MouseState)]
        public MouseStates MouseState
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
        [Description(Property.Color)]
        public Color SeparatorColor
        {
            get
            {
                return _borderEdge.BackColor;
            }

            set
            {
                _borderEdge.BackColor = value;
                Invalidate();
            }
        }

        [DefaultValue(Settings.DefaultValue.TextVisible)]
        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool SeparatorVisible
        {
            get
            {
                return _borderEdge.Visible;
            }

            set
            {
                _borderEdge.Visible = value;
                Invalidate();
            }
        }

<<<<<<< HEAD
        [Category(Propertys.Behavior)]
        [Description(Property.StartIndex)]
        public int StartIndex
        {
            get
            {
                return _startIndex;
            }

            set
            {
                _startIndex = value;
                try
                {
                    SelectedIndex = value;
                }
                catch (Exception)
                {
                    // ignored
                }

                Invalidate();
            }
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
        public StringAlignment TextAlignment
        {
            get
            {
                return _textAlignment;
            }

            set
            {
                _textAlignment = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color TextDisabledColor
        {
            get
            {
                return _textDisabledColor;
            }

            set
            {
                _textDisabledColor = value;
                Invalidate();
            }
        }

<<<<<<< HEAD
=======
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
        [Category(Propertys.Appearance)]
        [Description(Property.TextRenderingHint)]
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

        [TypeConverter(typeof(WatermarkConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Propertys.Behavior)]
        public Watermark Watermark
        {
            get
            {
                return _watermark;
            }

            set
            {
                _watermark = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>Update the style of the control.</summary>
        /// <param name="style">The visual style.</param>
        public void UpdateTheme(Styles style)
        {
            _styleManager = new VisualStyleManager(Settings.DefaultValue.DefaultStyle);

            _border.Color = _styleManager.ShapeStyle.Color;
            _border.HoverColor = _styleManager.BorderStyle.HoverColor;

            Font = _styleManager.Font;
            _foreColor = _styleManager.FontStyle.ForeColor;
            _textDisabledColor = _styleManager.FontStyle.ForeColorDisabled;

<<<<<<< HEAD
            _backColorState.Enabled = _styleManager.ControlStyle.BoxEnabled;
            _backColorState.Disabled = _styleManager.ControlStyle.BoxDisabled;
=======
            _backColorState = new ColorState
                {
                    Enabled = _styleManager.ControlStyle.BoxEnabled,
                    Disabled = _styleManager.ControlStyle.BoxDisabled
                };
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            _buttonColor = _styleManager.ControlStyle.FlatButtonEnabled;
            _menuTextColor = _styleManager.FontStyle.ForeColor;

            _menuItemNormal = _styleManager.ControlStyle.ItemEnabled;
            _menuItemHover = _styleManager.ControlStyle.ItemHover;

            _borderEdge.BackColor = _styleManager.ControlStyle.Line;

            Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
<<<<<<< HEAD
            e.Graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(_menuItemHover) : new SolidBrush(_menuItemNormal), e.Bounds);

            _itemSize = e.Bounds.Size;

            Point itemPoint = new Point(e.Bounds.X, e.Bounds.Y);
            Rectangle itemBorderRectangle = new Rectangle(itemPoint, _itemSize);
            GraphicsPath itemBorderPath = new GraphicsPath();
            itemBorderPath.AddRectangle(itemBorderRectangle);

            if (e.Index != -1)
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(_menuTextColor), e.Bounds);
            }
=======
            // e.DrawBackground();
            e.Graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(_menuItemHover) : new SolidBrush(_menuItemNormal), e.Bounds);

            if (e.Index != -1)
            {
                Point _location;

                if ((_imageList != null) && _itemImageVisible)
                {
                    e.Graphics.DrawImage(_imageList.Images[e.Index], e.Bounds.X, (e.Bounds.Y + (e.Bounds.Height / 2)) - (_imageList.ImageSize.Height / 2), _imageList.ImageSize.Width, _imageList.ImageSize.Height);

                    _location = new Point(e.Bounds.X + _imageList.ImageSize.Width, e.Bounds.Y);
                }
                else
                {
                    _location = new Point(e.Bounds.X, e.Bounds.Y);
                }

                StringFormat _stringFormat = new StringFormat
                    {
                        LineAlignment = _textLineAlignment
                    };

                e.Graphics.DrawString(GetItemText(Items[e.Index]), Font, new SolidBrush(_menuTextColor), new Rectangle(_location, new Size(DropDownWidth, ItemHeight)), _stringFormat);
            }

            // Draw rectangle over the item selected 
            // e.DrawFocusRectangle();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _watermark.Brush = new SolidBrush(_watermark.ActiveColor);
            _mouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _watermark.Brush = new SolidBrush(_watermark.InactiveColor);
            _mouseState = MouseStates.Normal;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            SuspendLayout();
            Update();
            ResumeLayout();
            _mouseState = MouseStates.Normal;
            Invalidate();
        }

<<<<<<< HEAD
=======
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            Graphics g = CreateGraphics();
            var maxWidth = 0;

            foreach (int width in Items.Cast<object>().Select(element => (int)g.MeasureString(element.ToString(), Font).Width).Where(width => width > maxWidth))
            {
                maxWidth = width;
            }

            DropDownWidth = maxWidth + 20;
        }

>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = MouseStates.Down;
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
            base.OnMouseLeave(e);
            _mouseState = MouseStates.Normal;
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
            Graphics _graphics = e.Graphics;
            _graphics.Clear(Parent.BackColor);
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TextRenderingHint = _textRendererHint;
<<<<<<< HEAD
            _graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            _controlGraphicsPath = VisualBorderRenderer.CreateBorderTypePath(_clientRectangle, _border);

<<<<<<< HEAD
            Color _textColor = Enabled ? _foreColor : _textDisabledColor;
            Color _backColor = Enabled ? _backColorState.Enabled : _backColorState.Disabled;

            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, _mouseState, _clientRectangle, Border);

            Point _textBoxLocation;
            Point _buttonLocation;
            Size _buttonSize = new Size(_buttonWidth, Height);

            if (_buttonHorizontal == Alignment.Horizontal.Right)
            {
                _buttonLocation = new Point(Width - _buttonWidth, 0);
                _textBoxLocation = new Point(0, 0);
            }
            else
            {
                _buttonLocation = new Point(0, 0);
                _textBoxLocation = new Point(_buttonWidth, 0);
            }

            Rectangle _buttonRectangle = new Rectangle(_buttonLocation, _buttonSize);
            Rectangle _textBoxRectangle = new Rectangle(_textBoxLocation.X, _textBoxLocation.Y, Width - _buttonWidth, Height);

            DrawButton(_graphics, _buttonRectangle);

            DrawSeparator(_buttonRectangle);

            StringFormat _stringFormat = new StringFormat
                {
                    Alignment = _textAlignment,
                    LineAlignment = StringAlignment.Center
                };

            ConfigureDirection(_textBoxRectangle, _buttonRectangle);
            _graphics.DrawString(Text, Font, new SolidBrush(_textColor), _textBoxRectangle, _stringFormat);

            if (Text.Length == 0)
            {
                Watermark.DrawWatermark(_graphics, _textBoxRectangle, _stringFormat, _watermark);
            }
=======
            _graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1));
            _graphics.SetClip(_controlGraphicsPath);

            Color _backColor = Enabled ? _backColorState.Enabled : _backColorState.Disabled;
            VisualBackgroundRenderer.DrawBackground(_graphics, _backColor, BackgroundImage, _mouseState, _clientRectangle, Border);

            Rectangle _buttonRectangle = new Rectangle(new Point(Width - _buttonWidth, 0), new Size(_buttonWidth, Height));
            Rectangle _textBoxRectangle = new Rectangle(0, 0, Width - _buttonWidth, Height);

            ConfigureSeparator(_buttonRectangle);

            DrawContent(_graphics, _textBoxRectangle);
            DrawButton(_graphics, _buttonRectangle);

            _graphics.ResetClip();

            DrawWatermark(_graphics, _textBoxRectangle);
            VisualBorderRenderer.DrawBorderStyle(_graphics, _border, _controlGraphicsPath, _mouseState);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
<<<<<<< HEAD
            e.Graphics.Clear(Parent.BackColor);
=======
            e.Graphics.Clear(BackColor);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            OnLostFocus(e);
        }

<<<<<<< HEAD
        private void ConfigureDirection(Rectangle textBoxRectangle, Rectangle buttonRectangle)
        {
            if (_buttonHorizontal == Alignment.Horizontal.Right)
            {
                switch (_textAlignment)
                {
                    case StringAlignment.Far:
                        textBoxRectangle.Width -= buttonRectangle.Width;
                        break;
                    case StringAlignment.Near:
                        textBoxRectangle.X = 0;
                        break;
                    case StringAlignment.Center:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (_textAlignment)
                {
                    case StringAlignment.Far:
                        textBoxRectangle.Width -= buttonRectangle.Width;
                        textBoxRectangle.X = Width - textBoxRectangle.Width;
                        break;
                    case StringAlignment.Near:
                        textBoxRectangle.X = _buttonWidth;
                        break;
                    case StringAlignment.Center:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void DrawButton(Graphics graphics, Rectangle buttonRectangle)
        {
            if (_buttonVisible)
            {
                Point _buttonImageLocation;
                Size _buttonImageSize;

                switch (_buttonStyles)
                {
                    case DropDownButtons.Arrow:
                        {
                            _buttonImageSize = new Size(10, 8);
                            _buttonImageLocation = new Point((buttonRectangle.X + (buttonRectangle.Width / 2)) - (_buttonImageSize.Width / 2), (buttonRectangle.Y + (buttonRectangle.Height / 2)) - (_buttonImageSize.Height / 2));
                            GDI.DrawTriangle(graphics, new Rectangle(_buttonImageLocation, _buttonImageSize), new SolidBrush(_buttonColor), false);
                            break;
                        }

                    case DropDownButtons.Bars:
                        {
                            _buttonImageSize = new Size(18, 10);
                            _buttonImageLocation = new Point((buttonRectangle.X + (buttonRectangle.Width / 2)) - (_buttonImageSize.Width / 2), (buttonRectangle.Y + (buttonRectangle.Height / 2)) - _buttonImageSize.Height);
                            Bars.DrawBars(graphics, _buttonImageLocation, _buttonImageSize, _buttonColor, 3, 5);
                            break;
                        }
                }
            }
        }

        private void DrawSeparator(Rectangle rectangle)
        {
            if (_borderEdge.Visible)
            {
                if (_buttonHorizontal == Alignment.Horizontal.Right)
                {
                    _borderEdge.Location = new Point(rectangle.X - 1, _border.Thickness);
                    _borderEdge.Size = new Size(1, Height - _border.Thickness - 1);
                }
                else
                {
                    _borderEdge.Location = new Point(rectangle.Width - 1, _border.Thickness);
                    _borderEdge.Size = new Size(1, Height - _border.Thickness - 1);
                }
            }
=======
        private void ConfigureSeparator(Rectangle rectangle)
        {
            if (!_borderEdge.Visible)
            {
                return;
            }

            _borderEdge.Location = new Point(rectangle.X - 1, _border.Thickness);
            _borderEdge.Size = new Size(1, Height - _border.Thickness - 1);
        }

        /// <summary>Draws the button.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle to draw on.</param>
        private void DrawButton(Graphics graphics, Rectangle rectangle)
        {
            if (!_buttonVisible)
            {
                return;
            }

            Point _buttonImageLocation;
            Size _buttonImageSize;

            switch (_buttonStyle)
            {
                case ButtonStyles.Arrow:
                    {
                        _buttonImageSize = new Size(10, 6);
                        _buttonImageLocation = new Point((rectangle.X + (rectangle.Width / 2)) - (_buttonImageSize.Width / 2), (rectangle.Y + (rectangle.Height / 2)) - (_buttonImageSize.Height / 2));
                        GraphicsManager.DrawTriangle(graphics, new Rectangle(_buttonImageLocation, _buttonImageSize), new SolidBrush(_buttonColor), false);

                        break;
                    }

                case ButtonStyles.Bars:
                    {
                        _buttonImageSize = new Size(18, 10);
                        _buttonImageLocation = new Point((rectangle.X + (rectangle.Width / 2)) - (_buttonImageSize.Width / 2), (rectangle.Y + (rectangle.Height / 2)) - _buttonImageSize.Height);
                        Bars.DrawBars(graphics, _buttonImageLocation, _buttonImageSize, _buttonColor, 3, 5);

                        break;
                    }

                case ButtonStyles.Image:
                    {
                        if (_buttonImage != null)
                        {
                            _buttonImageLocation = new Point((rectangle.X + (rectangle.Width / 2)) - (_buttonImage.Width / 2), (rectangle.Y + (rectangle.Height / 2)) - (_buttonImage.Height / 2));
                            graphics.DrawImage(_buttonImage, _buttonImageLocation);
                        }

                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        /// <summary>Draws the button.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle to draw on.</param>
        private void DrawContent(Graphics graphics, Rectangle rectangle)
        {
            Color _textColor = Enabled ? _foreColor : _textDisabledColor;

            if ((SelectedIndex != -1) && (_imageList != null) && _imageVisible)
            {
                VisualControlRenderer.DrawContent(graphics, rectangle, Text, Font, _textColor, _imageList.Images[SelectedIndex], _imageList.ImageSize, _textImageRelation);
            }
            else
            {
                VisualControlRenderer.DrawContentText(graphics, rectangle, Text, Font, _textColor, _textAlignment, _textLineAlignment);
            }
        }

        /// <summary>Draws the watermark.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle to draw on.</param>
        private void DrawWatermark(Graphics graphics, Rectangle rectangle)
        {
            if (Text.Length != 0)
            {
                return;
            }

            StringFormat _stringFormat = new StringFormat
                {
                    Alignment = _textAlignment,
                    LineAlignment = _textLineAlignment
                };

            Watermark.DrawWatermark(graphics, rectangle, _stringFormat, _watermark);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        #endregion
    }
}