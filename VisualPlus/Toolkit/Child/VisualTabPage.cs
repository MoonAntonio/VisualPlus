namespace VisualPlus.Toolkit.Child
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    using VisualPlus.Designer;
    using VisualPlus.Enumerators;
    using VisualPlus.Localization;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Components;

    #endregion

    [Designer(typeof(VisualTabPageDesigner))]
    [ToolboxItem(true)]
    public class VisualTabPage : TabPage
    {
        #region Variables

        private Shape _border;
        private Image _headerImage;
        private Image _image;
        private Size _imageSize;
        private Color _tabHover;
        private Color _tabNormal;
        private Color _tabSelected;
        private StringAlignment _textAlignment;
        private StringAlignment _textLineAlignment;
        private Color _textSelected;

        /// <summary>Required designer variable.</summary>
        private Container components;

        private TextImageRelations _textImageRelation;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualTabPage" /> class.</summary>
        public VisualTabPage()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            UpdateStyles();

            StyleManager _styleManager = new StyleManager(Settings.DefaultValue.DefaultStyle);

            _textSelected = Color.FromArgb(217, 220, 227);

            _textLineAlignment = StringAlignment.Center;
            _textAlignment = StringAlignment.Center;

            BackColor = _styleManager.Theme.BackgroundSettings.Type4;
            ForeColor = Color.FromArgb(174, 181, 187);
            Font = _styleManager.Theme.TextSetting.Font;

            _border = new Shape
                {
                    Visible = false,
                    Type = ShapeType.Rectangle
                };

            _textImageRelation = TextImageRelations.Text;

            _image = null;
            _imageSize = new Size(16, 16);

            _headerImage = null;

            _tabNormal = _styleManager.Theme.OtherSettings.TabPageEnabled;
            _tabSelected = _styleManager.Theme.OtherSettings.TabPageSelected;
            _tabHover = _styleManager.Theme.OtherSettings.TabPageHover;
        }

        public enum TextImageRelations
        {
            /// <summary>The image before text.</summary>
            ImageBeforeText,

            /// <summary>The image.</summary>
            Image,

            /// <summary>The text.</summary>
            Text
        }

        #endregion

        #region Properties

        [TypeConverter(typeof(ShapeConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
        public Shape Border
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

        [Browsable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Toggle)]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
        public Image HeaderImage
        {
            get
            {
                return _headerImage;
            }

            set
            {
                _headerImage = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
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

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Size)]
        public Size ImageSize
        {
            get
            {
                return _imageSize;
            }

            set
            {
                _imageSize = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextImageRelation)]
        public TextImageRelations TextImageRelation
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

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabHover
        {
            get
            {
                return _tabHover;
            }

            set
            {
                _tabHover = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabNormal
        {
            get
            {
                return _tabNormal;
            }

            set
            {
                _tabNormal = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabSelected
        {
            get
            {
                return _tabSelected;
            }

            set
            {
                _tabSelected = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.VerticalAlignment)]
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

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Alignment)]
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

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TextSelected
        {
            get
            {
                return _textSelected;
            }

            set
            {
                _textSelected = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        internal Rectangle Rectangle { get; set; }

        #endregion

        #region Events

        /// <summary>Updates the properties after an Invalidate.</summary>
        public void UpdateProperties()
        {
            try
            {
                Invalidate();
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
        }

        protected override ControlCollection CreateControlsInstance()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            DoubleBuffered = true;

            return base.CreateControlsInstance();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            _graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            if (BackgroundImage != null)
            {
                _graphics.DrawImage(BackgroundImage, new Rectangle(new Point(0, 0), Size));
            }
        }

        /// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            components = new Container();
            Disposed += VisualTabPage_Disposed;
        }

        private void VisualTabPage_Disposed(object sender, EventArgs e)
        {
        }

        #endregion
    }
}