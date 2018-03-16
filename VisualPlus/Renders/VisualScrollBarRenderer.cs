namespace VisualPlus.Renders
{
    #region Namespace

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.Properties;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Controls.Layout;

    #endregion

    public sealed class VisualScrollBarRenderer
    {
        #region Events

        /// <summary>Draws an arrow button.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarArrowButtonState" /> of the arrow button.</param>
        /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="color">The color.</param>
        /// <param name="border">The border.</param>
        /// <param name="image">The image.</param>
        public static void DrawArrowButton(Graphics graphics, Rectangle rectangle, MouseStates state, bool arrowUp, Orientation orientation, bool enabled, ControlColorState color, Border border, Image image)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            Color _thumbBackColor = ControlColorState.BackColorState(color, enabled, state);
            VisualBackgroundRenderer.DrawBackground(graphics, _thumbBackColor, image, state, rectangle, border);

            GraphicsPath _thumbGraphicsPath = VisualBorderRenderer.CreateBorderTypePath(rectangle, border);
            VisualBorderRenderer.DrawBorderStyle(graphics, border, _thumbGraphicsPath, state);

            Image _arrowImage = GetArrowDownButtonImage(enabled);
            if (orientation == Orientation.Vertical)
            {
                if (arrowUp)
                {
                    _arrowImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
            }
            else
            {
                if (arrowUp)
                {
                    _arrowImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    _arrowImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
            }

            graphics.DrawImage(_arrowImage, rectangle);
        }

        /// <summary>Draws the grip of the thumb.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        public static void DrawThumbGrip(Graphics graphics, Rectangle rectangle, Orientation orientation)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            using (Image _gripImage = Resources.GripNormal)
            {
                // adjust rectangle and rotate grip image if necessary
                Rectangle _rectangle = AdjustThumbGrip(rectangle, orientation, _gripImage);

                // adjust alpha channel of grip image
                using (ImageAttributes _imageAttributes = new ImageAttributes())
                {
                    _imageAttributes.SetColorMatrix(
                        new ColorMatrix(new[]
                            {
                                new[] { 1F, 0, 0, 0, 0 },
                                new[] { 0, 1F, 0, 0, 0 },
                                new[] { 0, 0, 1F, 0, 0 },
                                new[] { 0, 0, 0, .8F, 0 },
                                new[] { 0, 0, 0, 0, 1F }
                            }),
                        ColorMatrixFlag.Default,
                        ColorAdjustType.Bitmap);

                    graphics.DrawImage(_gripImage, _rectangle, 0, 0, _rectangle.Width, _rectangle.Height, GraphicsUnit.Pixel, _imageAttributes);
                }
            }
        }

        /// <summary>Adjusts the thumb grip according to the specified <see cref="Orientation" />.</summary>
        /// <param name="rectangle">The rectangle to adjust.</param>
        /// <param name="orientation">The scrollbar orientation.</param>
        /// <param name="gripImage">The grip image.</param>
        /// <returns>The adjusted rectangle.</returns>
        /// <remarks>Also rotates the grip image if necessary.</remarks>
        private static Rectangle AdjustThumbGrip(Rectangle rectangle, Orientation orientation, Image gripImage)
        {
            Rectangle r = rectangle;

            r.Inflate(-1, -1);

            if (orientation == Orientation.Vertical)
            {
                r.X += 3;
                r.Y += (r.Height / 2) - (gripImage.Height / 2);
            }
            else
            {
                gripImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                r.X += (r.Width / 2) - (gripImage.Width / 2);
                r.Y += 3;
            }

            r.Width = gripImage.Width;
            r.Height = gripImage.Height;

            return r;
        }

        /// <summary>The arrow image.</summary>
        /// <summary>Draws the arrow down button for the scrollbar.</summary>
        /// <param name="enabled">The enabled.</param>
        /// <returns>The arrow down button as <see cref="Image" />.</returns>
        private static Image GetArrowDownButtonImage(bool enabled)
        {
            Bitmap bitmap = new Bitmap(15, 17, PixelFormat.Format32bppArgb);
            bitmap.SetResolution(72f, 72f);

            using (Graphics _graphics = Graphics.FromImage(bitmap))
            {
                _graphics.SmoothingMode = SmoothingMode.None;
                _graphics.InterpolationMode = InterpolationMode.Low;

                using (Image _arrowImage = Resources.ScrollBarArrowDown)
                {
                    if (enabled)
                    {
                        _graphics.DrawImage(_arrowImage, 3, 6);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(_graphics, _arrowImage, 3, 6, Color.Transparent);
                    }
                }
            }

            return bitmap;
        }

        #endregion
    }
}