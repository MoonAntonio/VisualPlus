#region Namespace

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

using VisualPlus.Localization;
using VisualPlus.Renders;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [Description("The VisualBitmap")]
    [TypeConverter(typeof(BasicSettingsTypeConverter))]
    public class VisualBitmap
    {
        #region Variables

        private Border border;
        private Bitmap image;
        private Point imagePoint;
        private Size imageSize;
        private bool visible;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualBitmap" /> class.</summary>
        /// <param name="bitmap">The image bitmap.</param>
        /// <param name="bitmapSize">The size of the bitmap.</param>
        public VisualBitmap(Bitmap bitmap, Size bitmapSize)
        {
            border = new Border
                {
                    Visible = false,
                    HoverVisible = false
                };

            imagePoint = new Point();
            visible = false;

            image = bitmap;
            imageSize = bitmapSize;
        }

        #endregion

        #region Properties

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof(BasicSettingsTypeConverter))]
        [Category(PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Border Border
        {
            get
            {
                return border;
            }

            set
            {
                border = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Image)]
        public Bitmap Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Point)]
        public Point Point
        {
            get
            {
                return imagePoint;
            }

            set
            {
                imagePoint = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Size)]
        public Size Size
        {
            get
            {
                return imageSize;
            }

            set
            {
                imageSize = value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Visible)]
        public bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>Draws the bitmap image.</summary>
        /// <param name="graphics">Graphics controller.</param>
        /// <param name="_border">The border.</param>
        /// <param name="_imagePoint">The location.</param>
        /// <param name="_image">The image.</param>
        /// <param name="_imageSize">The size.</param>
        /// <param name="_visible">The visibility.</param>
        public static void DrawImage(Graphics graphics, Border _border, Point _imagePoint, Bitmap _image, Size _imageSize, bool _visible)
        {
            if (_image != null)
            {
                using (GraphicsPath imagePath = new GraphicsPath())
                {
                    imagePath.AddRectangle(new Rectangle(_imagePoint, _imageSize));

                    if (_border.Visible)
                    {
                        VisualBorderRenderer.DrawBorder(graphics, imagePath, _border.Color, thickness: _border.Thickness);
                    }
                }

                if (_visible)
                {
                    graphics.DrawImage(_image, new Rectangle(_imagePoint, _imageSize));
                }
            }
        }

        /// <summary>Returns the size of the image.</summary>
        /// <param name="_image">The image.</param>
        /// <returns>The <see cref="Size" />.</returns>
        public Size GetOriginalSize(Image _image)
        {
            return _image.Size;
        }

        #endregion
    }
}