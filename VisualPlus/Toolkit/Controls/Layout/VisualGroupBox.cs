namespace VisualPlus.Toolkit.Controls.Layout
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
<<<<<<< HEAD
=======
    using VisualPlus.Managers;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(GroupBox))]
    [DefaultEvent("Enter")]
    [DefaultProperty("Text")]
    [Description("The Visual GroupBox")]
    public class VisualGroupBox : NestedControlsBase
    {
        #region Variables

        private Border _border;
        private BorderEdge _borderEdge;
        private GroupBoxStyle _boxStyle;
<<<<<<< HEAD
        private StringAlignment _stringAlignment;
        private TitleAlignments _titleAlignment;
        private int _titleBoxHeight;
        private Rectangle _titleBoxRectangle;
        private bool _titleBoxVisible;
=======
        private Image _image;
        private StringAlignment _stringAlignment;
        private StringAlignment _textAlignment;
        private TextImageRelation _textImageRelation;
        private StringAlignment _textLineAlignment;
        private int _titleBoxHeight;
        private Rectangle _titleBoxRectangle;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:VisualPlus.Toolkit.Controls.Layout.VisualGroupBox" /> class.</summary>
        public VisualGroupBox()
        {
            _boxStyle = GroupBoxStyle.Default;
            _stringAlignment = StringAlignment.Center;
<<<<<<< HEAD
            _titleAlignment = TitleAlignments.Top;
            _titleBoxVisible = Settings.DefaultValue.TitleBoxVisible;
            _titleBoxHeight = 25;
            _borderEdge = new BorderEdge();

=======
            _titleBoxHeight = 25;
            _borderEdge = new BorderEdge();
            _textImageRelation = TextImageRelation.ImageBeforeText;
            _textAlignment = StringAlignment.Center;
            _textLineAlignment = StringAlignment.Center;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Size = new Size(220, 180);
            _border = new Border();
            Padding = new Padding(5, _titleBoxHeight + _border.Thickness, 5, 5);

            Controls.Add(_borderEdge);

            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        public enum GroupBoxStyle
        {
            /// <summary>The default.</summary>
            Default,

            /// <summary>The classic.</summary>
            Classic
        }

<<<<<<< HEAD
        public enum TitleAlignments
        {
            /// <summary>The bottom.</summary>
            Bottom,

            /// <summary>The top.</summary>
            Top
        }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        #endregion

        #region Properties

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
        [Description(Property.Type)]
        public GroupBoxStyle BoxStyle
        {
            get
            {
                return _boxStyle;
            }

            set
            {
                _boxStyle = value;

                if (_boxStyle == GroupBoxStyle.Classic)
                {
                    _borderEdge.Visible = false;
                }
                else
                {
                    _borderEdge.Visible = true;
                }

                Invalidate();
            }
        }

        [Category(Propertys.Appearance)]
<<<<<<< HEAD
=======
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
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        [Description(Property.Color)]
        public bool Separator
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

        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
        public StringAlignment TextAlignment
        {
            get
            {
<<<<<<< HEAD
                return _stringAlignment;
=======
                return _textAlignment;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _stringAlignment = value;
=======
                _textAlignment = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

<<<<<<< HEAD
        [Category(Propertys.Layout)]
        [Description(Property.Alignment)]
        public TitleAlignments TitleAlignment
        {
            get
            {
                return _titleAlignment;
=======
        [Category(Propertys.Behavior)]
        [Description(Property.TextImageRelation)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return _textImageRelation;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _titleAlignment = value;
=======
                _textImageRelation = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

<<<<<<< HEAD
        [DefaultValue("25")]
        [Category(Propertys.Layout)]
        [Description(Property.Size)]
        public int TitleBoxHeight
        {
            get
            {
                return _titleBoxHeight;
=======
        [Category(Propertys.Appearance)]
        [Description(Property.Alignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return _textLineAlignment;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _titleBoxHeight = value;
=======
                _textLineAlignment = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

<<<<<<< HEAD
        [DefaultValue(Settings.DefaultValue.TitleBoxVisible)]
        [Category(Propertys.Behavior)]
        [Description(Property.Visible)]
        public bool TitleBoxVisible
        {
            get
            {
                return _titleBoxVisible;
=======
        [Category(Propertys.Layout)]
        [Description(Property.Size)]
        public int TitleBoxHeight
        {
            get
            {
                return _titleBoxHeight;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }

            set
            {
<<<<<<< HEAD
                _titleBoxVisible = value;
=======
                _titleBoxHeight = value;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                Invalidate();
            }
        }

        #endregion

        #region Events

        public void UpdateTheme(Styles style)
        {
            StyleManager = new VisualStyleManager(style);
            _border.Color = StyleManager.ShapeStyle.Color;
            _border.HoverColor = StyleManager.BorderStyle.HoverColor;
            ForeColor = StyleManager.FontStyle.ForeColor;
            ForeColorDisabled = StyleManager.FontStyle.ForeColorDisabled;

            BackColorState.Enabled = StyleManager.ControlStyle.Background(0);
            BackColorState.Disabled = StyleManager.ControlStyle.Background(0);

            _borderEdge.BackColor = StyleManager.ControlStyle.Line;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
<<<<<<< HEAD

            // graphics.Clear(Parent.BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.GammaCorrected;

            Size textArea = GDI.MeasureText(graphics, Text, Font);
=======
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.GammaCorrected;

            Size textArea = GraphicsManager.MeasureText(graphics, Text, Font);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Rectangle group = ConfigureStyleBox(textArea);
            Rectangle title = ConfigureStyleTitleBox(textArea);

            _titleBoxRectangle = new Rectangle(title.X, title.Y, title.Width - 1, title.Height);

<<<<<<< HEAD
            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
=======
            Rectangle _clientRectangle = new Rectangle(group.X, group.Y, group.Width, group.Height);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            ControlGraphicsPath = VisualBorderRenderer.CreateBorderTypePath(_clientRectangle, _border);
            graphics.FillRectangle(new SolidBrush(BackColor), _clientRectangle);

            Color _backColor = Enabled ? BackColorState.Enabled : BackColorState.Disabled;
            VisualBackgroundRenderer.DrawBackground(e.Graphics, _backColor, BackgroundImage, MouseState, group, Border);

            if (_borderEdge.Visible)
            {
<<<<<<< HEAD
                switch (TitleAlignment)
                {
                    case TitleAlignments.Bottom:
                        {
                            _borderEdge.Location = new Point(_titleBoxRectangle.X + _border.Thickness, _titleBoxRectangle.Y);
                            _borderEdge.Size = new Size(Width - _border.Thickness - 1, 1);
                            break;
                        }

                    case TitleAlignments.Top:
                        {
                            _borderEdge.Location = new Point(_titleBoxRectangle.X + _border.Thickness, _titleBoxRectangle.Bottom);
                            _borderEdge.Size = new Size(Width - _border.Thickness - 1, 1);
                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }

            if (_boxStyle == GroupBoxStyle.Classic)
            {
                graphics.FillRectangle(new SolidBrush(BackColorState.Enabled), _titleBoxRectangle);
                graphics.DrawString(Text, Font, new SolidBrush(ForeColor), _titleBoxRectangle);
            }
            else
            {
                StringFormat stringFormat = new StringFormat
                    {
                        Alignment = _stringAlignment,
                        LineAlignment = StringAlignment.Center
                    };

                graphics.DrawString(Text, Font, new SolidBrush(ForeColor), _titleBoxRectangle, stringFormat);
=======
                _borderEdge.Location = new Point(_titleBoxRectangle.X + _border.Thickness, _titleBoxRectangle.Bottom);
                _borderEdge.Size = new Size(Width - _border.Thickness - 1, 1);
            }

            VisualBorderRenderer.DrawBorderStyle(e.Graphics, _border, ControlGraphicsPath, MouseState);

            if (_boxStyle == GroupBoxStyle.Classic)
            {
                Point _titleBoxBackground = GraphicsManager.GetTextImageRelationLocation(e.Graphics, _textImageRelation, new Rectangle(new Point(), _image.Size), Text, Font, _titleBoxRectangle, false);
                graphics.FillRectangle(new SolidBrush(BackColorState.Enabled), new Rectangle(new Point(_titleBoxBackground.X, _titleBoxBackground.Y), new Size(_titleBoxRectangle.Width, _titleBoxRectangle.Height)));
            }

            if (_image != null)
            {
                VisualControlRenderer.DrawContent(e.Graphics, _titleBoxRectangle, Text, Font, ForeColor, _image, _image.Size, _textImageRelation);
            }
            else
            {
                VisualControlRenderer.DrawContentText(e.Graphics, _titleBoxRectangle, Text, Font, ForeColor, _textAlignment, _textLineAlignment);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.Clear(BackColor);
        }

        private Rectangle ConfigureStyleBox(Size textArea)
        {
<<<<<<< HEAD
            Size groupBoxSize = new Size(Width, Height);
=======
            Size groupBoxSize;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            Point groupBoxPoint = new Point(0, 0);

            switch (_boxStyle)
            {
                case GroupBoxStyle.Default:
                    {
                        groupBoxSize = new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                        break;
                    }

                case GroupBoxStyle.Classic:
                    {
<<<<<<< HEAD
                        if (_titleAlignment == TitleAlignments.Top)
                        {
                            groupBoxPoint = new Point(0, textArea.Height / 2);
                            groupBoxSize = new Size(Width - _border.Thickness, Height - (textArea.Height / 2) - _border.Thickness);
                        }
                        else
                        {
                            groupBoxPoint = new Point(0, 0);
                            groupBoxSize = new Size(Width - _border.Thickness, Height - (textArea.Height / 2));
                        }
=======
                        groupBoxPoint = new Point(0, textArea.Height / 2);
                        groupBoxSize = new Size(Width - _border.Thickness, Height - (textArea.Height / 2) - _border.Thickness);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            Rectangle groupBoxRectangle = new Rectangle(groupBoxPoint, groupBoxSize);

            return groupBoxRectangle;
        }

        private Rectangle ConfigureStyleTitleBox(Size textArea)
        {
            Size titleSize = new Size(Width, _titleBoxHeight);
            Point titlePoint = new Point(0, 0);

            switch (_boxStyle)
            {
                case GroupBoxStyle.Default:
                    {
<<<<<<< HEAD
                        // Declare Y
                        if (_titleAlignment == TitleAlignments.Top)
                        {
                            titlePoint = new Point(titlePoint.X, 0);
                        }
                        else
                        {
                            titlePoint = new Point(titlePoint.X, Height - _titleBoxHeight);
                        }
=======
                        titlePoint = new Point(titlePoint.X, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

                        break;
                    }

                case GroupBoxStyle.Classic:
                    {
<<<<<<< HEAD
                        _titleBoxVisible = false;
                        var spacing = 5;

                        if (_titleAlignment == TitleAlignments.Top)
                        {
                            titlePoint = new Point(titlePoint.X, 0);
                        }
                        else
                        {
                            titlePoint = new Point(titlePoint.X, Height - textArea.Height);
                        }
=======
                        const int Spacing = 5;

                        titlePoint = new Point(titlePoint.X, 0);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

                        // +1 extra whitespace in case of FontStyle=Bold
                        titleSize = new Size(textArea.Width + 2, textArea.Height);

                        switch (_stringAlignment)
                        {
                            case StringAlignment.Near:
                                {
                                    titlePoint.X += 5;
                                    break;
                                }

                            case StringAlignment.Center:
                                {
                                    titlePoint.X = (Width / 2) - (textArea.Width / 2);
                                    break;
                                }

                            case StringAlignment.Far:
                                {
<<<<<<< HEAD
                                    titlePoint.X = Width - textArea.Width - spacing;
                                    break;
                                }
=======
                                    titlePoint.X = Width - textArea.Width - Spacing;
                                    break;
                                }

                            default:
                                throw new ArgumentOutOfRangeException();
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                        }

                        break;
                    }
<<<<<<< HEAD
            }

            Rectangle titleRectangle = new Rectangle(titlePoint, titleSize);
            return titleRectangle;
        }

        #endregion

        // private Color _titleColor;
=======

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            return new Rectangle(titlePoint, titleSize);
        }

        #endregion
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    }
}