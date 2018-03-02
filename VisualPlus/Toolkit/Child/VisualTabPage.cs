namespace VisualPlus.Toolkit.Child
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    using VisualPlus.Designer;

    #endregion

    [Designer(typeof(VisualTabPageDesigner))]
    [ToolboxItem(true)]
    public class VisualTabPage : TabPage
    {
        #region Variables

        private Color backColor;

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private Container components;

        #endregion

        #region Constructors

        public VisualTabPage()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            backColor = Color.Transparent;
            BackgroundColor = Color.FromArgb(241, 244, 249);
            UpdateStyles();
        }

        #endregion

        #region Properties

        [Browsable(false)]
        public new Color BackColor
        {
            get
            {
                return backColor;
            }

            set
            {
                backColor = value;
            }
        }

        [Category("VisualPlus")]
        [Bindable(false)]
        public Color BackgroundColor { get; set; }

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

        /// <summary>Creates a control instance.</summary>
        /// <returns>The <see cref="Control.ControlCollection" />.</returns>
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

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">The disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>Raises the Paint event.</summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            _graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (SolidBrush _backgroundBrush = new SolidBrush(BackgroundColor))
            {
                _graphics.FillRectangle(_backgroundBrush, ClientRectangle);
            }
        }

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            // this.Disposed += new EventHandler(TabpageEx_Disposed);
        }

        #endregion
    }
}