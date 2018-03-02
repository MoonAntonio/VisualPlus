namespace VisualPlus.Toolkit.Child
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    using VisualPlus.Designer;
    using VisualPlus.Localization;

    #endregion

    [Designer(typeof(VisualTabPageDesigner))]
    [ToolboxItem(true)]
    public class VisualTabPage : TabPage
    {
        #region Variables

        private Image _image;

        /// <summary>Required designer variable.</summary>
        private Container components;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualTabPage" /> class.</summary>
        public VisualTabPage()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            UpdateStyles();
        }

        #endregion

        #region Properties

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

            if (_image != null)
            {
                _graphics.DrawImage(_image, new Rectangle(new Point(0, 0), Size));
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