#region Namespace

using System;
using System.Drawing;

#endregion

namespace VisualPlus.Renders
{
    public class VisualImageRenderer
    {
        #region Methods

        /// <summary>Renders the full image.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="image">The image to draw.</param>
        public static void RenderImage(Graphics graphics, Image image)
        {
            graphics.DrawImage(image, new Point(0, 0));
        }

        /// <summary>Render the image in the center of the client rectangle using the image size.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="offset">The location offset.</param>
        public static void RenderImageCentered(Graphics graphics, Rectangle clientRectangle, Image image, Point offset = new Point())
        {
            Point _location = new Point(((clientRectangle.Width / 2) - (image.Width / 2)) + offset.X, ((clientRectangle.Height / 2) - (image.Height / 2)) + offset.Y);
            graphics.DrawImage(image, _location);
        }

        /// <summary>
        ///     Render the image in the center of the client rectangle using the client size to make the image fit if it's too
        ///     large.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        public static void RenderImageCenteredFit(Graphics graphics, Rectangle clientRectangle, Image image)
        {
            Rectangle centerRectangle = new Rectangle
                {
                    Location = new Point(clientRectangle.Width / 4, clientRectangle.Height / 4),
                    Size = new Size(clientRectangle.Width / 2, clientRectangle.Height / 2)
                };

            graphics.DrawImage(image, centerRectangle);
        }

        /// <summary>Render the image.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        public static void RenderImageFilled(Graphics graphics, Rectangle clientRectangle, Image image)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            graphics.DrawImage(image, clientRectangle);
        }

        #endregion
    }
}