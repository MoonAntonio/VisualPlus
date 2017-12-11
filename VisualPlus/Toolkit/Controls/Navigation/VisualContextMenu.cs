namespace VisualPlus.Toolkit.Controls.Navigation
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
<<<<<<< HEAD
=======
    using System.Runtime.InteropServices;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;

    #endregion

<<<<<<< HEAD
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ContextMenuStrip))]
    [DefaultEvent("Opening")]
    [DefaultProperty("Items")]
    [Description("The Visual Context Menu Strip")]
=======
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Opening")]
    [DefaultProperty("Items")]
    [Description("The Visual Context Menu Strip")]
    [ToolboxBitmap(typeof(VisualContextMenuStrip), "Resources.ToolboxBitmaps.VisualContextMenuStrip.bmp")]
    [ToolboxItem(true)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public class VisualContextMenuStrip : ContextMenuStrip
    {
        #region Variables

        private VisualStyleManager _styleManager;
<<<<<<< HEAD
        private ToolStripItemClickedEventArgs clickedEventArgs;
=======
        private ToolStripItemClickedEventArgs _toolStripItemClickedEventArgs;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:VisualPlus.Toolkit.Controls.Navigation.VisualContextMenuStrip" /> class.
        /// </summary>
        public VisualContextMenuStrip()
        {
            _styleManager = new VisualStyleManager(Settings.DefaultValue.DefaultStyle);

            Renderer = new VisualToolStripRender();
            ConfigureStyleManager();
        }

        public delegate void ClickedEventHandler(object sender);

        public event ClickedEventHandler Clicked;

        #endregion

        #region Properties

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ArrowColor
        {
            get
            {
                return arrowColor;
            }

            set
            {
                arrowColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color ArrowDisabledColor
        {
            get
            {
                return arrowDisabledColor;
            }

            set
            {
                arrowDisabledColor = value;
                Invalidate();
            }
        }

        [DefaultValue(Settings.DefaultValue.BorderVisible)]
        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool ArrowVisible
        {
            get
            {
<<<<<<< HEAD
                return arrowVisible;
=======
                return _arrowVisible;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                arrowVisible = value;
=======
                _arrowVisible = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
        public Color Background
        {
            get
            {
<<<<<<< HEAD
                return background;
=======
                return _backgroundColor;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                background = value;
=======
                _backgroundColor = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
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
                return border;
            }

            set
            {
                border = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get
            {
                return foreColor;
            }

            set
            {
                base.ForeColor = value;
                foreColor = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
<<<<<<< HEAD
=======
        [Description(Property.Color)]
        public Color ItemHoverColor
        {
            get
            {
                return _itemHoverColor;
            }

            set
            {
                _itemHoverColor = value;
            }
        }

        [Category(Propertys.Appearance)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        [Description(Property.Font)]
        public Font MenuFont
        {
            get
            {
                return contextMenuFont;
            }

            set
            {
                contextMenuFont = value;
                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
<<<<<<< HEAD
=======
        public Color SelectedItemBackColor
        {
            get
            {
                return _selectedItemBackColor;
            }

            set
            {
                _selectedItemBackColor = value;
            }
        }

        [Category(Propertys.Appearance)]
        [Description(Property.Color)]
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public Color TextDisabledColor
        {
            get
            {
                return textDisabledColor;
            }

            set
            {
                textDisabledColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            if ((e.ClickedItem != null) && !(e.ClickedItem is ToolStripSeparator))
            {
<<<<<<< HEAD
                if (ReferenceEquals(e, clickedEventArgs))
=======
                if (ReferenceEquals(e, _toolStripItemClickedEventArgs))
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                {
                    OnItemClicked(e);
                }
                else
                {
<<<<<<< HEAD
                    clickedEventArgs = e;
                    if (Clicked != null)
                    {
                        Clicked(this);
                    }
=======
                    _toolStripItemClickedEventArgs = e;
                    Clicked?.Invoke(this);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            Cursor = Cursors.Hand;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor = Cursors.Hand;
            Invalidate();
        }

<<<<<<< HEAD
        private static Color arrowColor;
        private static Color arrowDisabledColor;
        private static bool arrowVisible = Settings.DefaultValue.TextVisible;
        private static Color background;
=======
        private static bool _arrowVisible = Settings.DefaultValue.TextVisible;
        private static Color _backgroundColor;
        private static Color _itemHoverColor;
        private static Color _selectedItemBackColor;

        private static Color arrowColor;
        private static Color arrowDisabledColor;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        private static Border border;
        private static Font contextMenuFont;
        private static Color foreColor;
        private static Color textDisabledColor;

        private void ConfigureStyleManager()
        {
            border = new Border
                {
                    HoverVisible = false,
                    Type = ShapeType.Rectangle
                };

            Font = _styleManager.Font;
            foreColor = _styleManager.FontStyle.ForeColor;
            textDisabledColor = _styleManager.FontStyle.ForeColorDisabled;

<<<<<<< HEAD
            BackColor = background;
=======
            BackColor = _backgroundColor;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            arrowColor = _styleManager.ControlStyle.FlatButtonEnabled;
            arrowDisabledColor = _styleManager.ControlStyle.FlatButtonDisabled;
            contextMenuFont = Font;

<<<<<<< HEAD
            background = _styleManager.ControlStyle.Background(0);
=======
            _backgroundColor = _styleManager.ControlStyle.Background(0);
            _selectedItemBackColor = _styleManager.ControlStyle.ItemHover;
            _itemHoverColor = _styleManager.BorderStyle.HoverColor;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        #endregion

        #region Methods

        public sealed class VisualToolStripRender : ToolStripProfessionalRenderer
        {
            #region Events

<<<<<<< HEAD
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                if (arrowVisible)
                {
                    int arrowX = e.Item.ContentRectangle.X + e.Item.ContentRectangle.Width;
                    int arrowY = (e.ArrowRectangle.Y + e.ArrowRectangle.Height) / 2;

                    Point[] arrowPoints =
                        {
                            new Point(arrowX - 5, arrowY - 5),
                            new Point(arrowX, arrowY),
                            new Point(arrowX - 5, arrowY + 5)
                        };

                    // Set control state color
                    foreColor = e.Item.Enabled ? foreColor : textDisabledColor;
                    Color controlCheckTemp = e.Item.Enabled ? arrowColor : arrowDisabledColor;

                    // Draw the arrowButton
                    e.Graphics.FillPolygon(new SolidBrush(controlCheckTemp), arrowPoints);
                }
            }

=======
            /// <summary>Renders the arrow.</summary>
            /// <param name="e">The tool strip render event args.</param>
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                if (!_arrowVisible)
                {
                    return;
                }

                int _xArrow = e.Item.ContentRectangle.X + e.Item.ContentRectangle.Width;
                int _yArrow = (e.ArrowRectangle.Y + e.ArrowRectangle.Height) / 2;

                Point[] _arrowLocation =
                    {
                        new Point(_xArrow - 5, _yArrow - 5),
                        new Point(_xArrow, _yArrow),
                        new Point(_xArrow - 5, _yArrow + 5)
                    };

                Color _arrowStateColor = e.Item.Enabled ? arrowColor : arrowDisabledColor;
                e.Graphics.FillPolygon(new SolidBrush(_arrowStateColor), _arrowLocation);
            }

            /// <summary>Renders the image margin.</summary>
            /// <param name="e">The tool strip render event args.</param>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                // Allow to add images to ToolStrips
                // MyBase.OnRenderImageMargin(e) 
            }

<<<<<<< HEAD
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                Rectangle textRect = new Rectangle(25, e.Item.ContentRectangle.Y, e.Item.ContentRectangle.Width - (24 + 16), e.Item.ContentRectangle.Height - 4);

                // Set control state color
                foreColor = e.Item.Enabled ? foreColor : textDisabledColor;

                StringFormat stringFormat = new StringFormat
=======
            /// <summary>Renders the item text.</summary>
            /// <param name="e">The tool strip render event args.</param>
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                Rectangle _itemTextRectangle = new Rectangle(25, e.Item.ContentRectangle.Y, e.Item.ContentRectangle.Width - (24 + 16), e.Item.ContentRectangle.Height - 4);

                Color _itemTextColor = e.Item.Enabled ? e.Item.Selected ? _itemHoverColor : foreColor : textDisabledColor;

                StringFormat _stringFormat = new StringFormat
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                    {
                        // Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

<<<<<<< HEAD
                e.Graphics.DrawString(e.Text, contextMenuFont, new SolidBrush(foreColor), textRect, stringFormat);
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.Clear(background);
                Rectangle menuItemRectangle = new Rectangle(0, e.Item.ContentRectangle.Y - 2, e.Item.ContentRectangle.Width + 4, e.Item.ContentRectangle.Height + 3);
                e.Graphics.FillRectangle(e.Item.Selected && e.Item.Enabled ? new SolidBrush(Color.FromArgb(130, background)) : new SolidBrush(background), menuItemRectangle);
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(new Pen(Color.FromArgb(200, border.Color), border.Thickness), new Point(e.Item.Bounds.Left, e.Item.Bounds.Height / 2), new Point(e.Item.Bounds.Right - 5, e.Item.Bounds.Height / 2));
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                base.OnRenderToolStripBackground(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.Clear(background);
            }

=======
                e.Graphics.DrawString(e.Text, contextMenuFont, new SolidBrush(_itemTextColor), _itemTextRectangle, _stringFormat);
            }

            /// <summary>Renders the menu item background.</summary>
            /// <param name="e">The tool strip render event args.</param>
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.Clear(_backgroundColor);

                Rectangle _menuItemBackgroundRectangle = new Rectangle(0, e.Item.ContentRectangle.Y - 2, e.Item.ContentRectangle.Width + 4, e.Item.ContentRectangle.Height + 3);

                e.Graphics.FillRectangle(e.Item.Selected && e.Item.Enabled ? new SolidBrush(_selectedItemBackColor) : new SolidBrush(_backgroundColor), _menuItemBackgroundRectangle);
            }

            /// <summary>Renders the separator.</summary>
            /// <param name="e">The tool strip render event args.</param>
            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                Point _pt1 = new Point(e.Item.Bounds.Left, e.Item.Bounds.Height / 2);
                Point _pt2 = new Point(e.Item.Bounds.Right - 5, e.Item.Bounds.Height / 2);

                e.Graphics.DrawLine(new Pen(Color.FromArgb(200, border.Color), border.Thickness), _pt1, _pt2);
            }

            /// <summary>Renders the tool strip background.</summary>
            /// <param name="e">The tool strip render event args.</param>
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                base.OnRenderToolStripBackground(e);
                e.Graphics.Clear(_backgroundColor);
            }

            /// <summary>Renders the tool strip border.</summary>
            /// <param name="e">The tool strip render event args.</param>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                if (border.Visible)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.High;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

<<<<<<< HEAD
                    Rectangle borderRectangle = new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - border.Thickness, e.AffectedBounds.Height - border.Thickness);
=======
                    Rectangle borderRectangle = new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - border.Thickness - 1, e.AffectedBounds.Height - border.Thickness - 1);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                    GraphicsPath borderPath = new GraphicsPath();
                    borderPath.AddRectangle(borderRectangle);
                    borderPath.CloseAllFigures();

                    e.Graphics.SetClip(borderPath);
                    e.Graphics.DrawPath(new Pen(border.Color), borderPath);
                    e.Graphics.ResetClip();
                }
            }

            #endregion
        }

        #endregion
    }
}