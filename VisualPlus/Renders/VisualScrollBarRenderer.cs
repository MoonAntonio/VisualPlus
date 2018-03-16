namespace VisualPlus.Renders
{
    #region Namespace

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    using VisualPlus.Properties;
    using VisualPlus.Toolkit.Controls.Layout;

    #endregion

    public sealed class VisualScrollBarRenderer
    {
        #region Constructors

        /// <summary>Initializes static members of the <see cref="VisualScrollBarRenderer" /> class.</summary>
        static VisualScrollBarRenderer()
        {
            /* picture of colors and indices
             *(0,0)
             * -----------------------------------------------
             * |                                             |
             * | |-----------------------------------------| |
             * | |                  (2)                    | |
             * | | |-------------------------------------| | |
             * | | |                (0)                  | | |
             * | | |                                     | | |
             * | | |                                     | | |
             * | |3|                (1)                  |3| |
             * | |6|                (4)                  |6| |
             * | | |                                     | | |
             * | | |                (5)                  | | |
             * | | |-------------------------------------| | |
             * | |                  (12)                   | |
             * | |-----------------------------------------| |
             * |                                             |
             * ----------------------------------------------- (15,17)
             */

            // hot state
            arrowColors[0, 0] = Color.FromArgb(223, 236, 252);
            arrowColors[0, 1] = Color.FromArgb(207, 225, 248);
            arrowColors[0, 2] = Color.FromArgb(245, 249, 255);
            arrowColors[0, 3] = Color.FromArgb(237, 244, 252);
            arrowColors[0, 4] = Color.FromArgb(244, 249, 255);
            arrowColors[0, 5] = Color.FromArgb(244, 249, 255);
            arrowColors[0, 6] = Color.FromArgb(251, 253, 255);
            arrowColors[0, 7] = Color.FromArgb(251, 253, 255);

            // over state
            arrowColors[1, 0] = Color.FromArgb(205, 222, 243);
            arrowColors[1, 1] = Color.FromArgb(186, 208, 235);
            arrowColors[1, 2] = Color.FromArgb(238, 244, 252);
            arrowColors[1, 3] = Color.FromArgb(229, 237, 247);
            arrowColors[1, 4] = Color.FromArgb(223, 234, 247);
            arrowColors[1, 5] = Color.FromArgb(241, 246, 254);
            arrowColors[1, 6] = Color.FromArgb(243, 247, 252);
            arrowColors[1, 7] = Color.FromArgb(250, 252, 255);

            // pressed state
            arrowColors[2, 0] = Color.FromArgb(215, 220, 225);
            arrowColors[2, 1] = Color.FromArgb(195, 202, 210);
            arrowColors[2, 2] = Color.FromArgb(242, 244, 245);
            arrowColors[2, 3] = Color.FromArgb(232, 235, 238);
            arrowColors[2, 4] = Color.FromArgb(226, 228, 230);
            arrowColors[2, 5] = Color.FromArgb(230, 233, 236);
            arrowColors[2, 6] = Color.FromArgb(244, 245, 245);
            arrowColors[2, 7] = Color.FromArgb(245, 247, 248);

            // arrow border colors
            arrowBorderColors[0] = Color.FromArgb(135, 146, 160);
            arrowBorderColors[1] = Color.FromArgb(140, 151, 165);
            arrowBorderColors[2] = Color.FromArgb(128, 139, 153);
            arrowBorderColors[3] = Color.FromArgb(99, 110, 125);
        }

        #endregion

        #region Events

        /// <summary>Draws an arrow button.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarArrowButtonState" /> of the arrow button.</param>
        /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        public static void DrawArrowButton(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarArrowButtonState state, bool arrowUp, Orientation orientation)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            Image _arrowImage = GetArrowDownButtonImage(state);
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

        /// <summary>The arrow border colors.</summary>
        private static Color[] arrowBorderColors = new Color[4];

        /// <summary>The arrow colors in the three states.</summary>
        private static Color[,] arrowColors = new Color[3, 8];

        /// <summary>Draws the arrow down button for the scrollbar.</summary>
        /// <param name="state">The button state.</param>
        /// <returns>The arrow down button as <see cref="Image" />.</returns>
        private static Image GetArrowDownButtonImage(VisualScrollBar.VisualScrollBarArrowButtonState state)
        {
            Rectangle _rectangle = new Rectangle(0, 0, 15, 17);
            Bitmap bitmap = new Bitmap(15, 17, PixelFormat.Format32bppArgb);
            bitmap.SetResolution(72f, 72f);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.None;
                g.InterpolationMode = InterpolationMode.Low;

                int index = -1;

                switch (state)
                {
                    case VisualScrollBar.VisualScrollBarArrowButtonState.UpHot:
                    case VisualScrollBar.VisualScrollBarArrowButtonState.DownHot:
                        {
                            index = 1;

                            break;
                        }

                    case VisualScrollBar.VisualScrollBarArrowButtonState.UpActive:
                    case VisualScrollBar.VisualScrollBarArrowButtonState.DownActive:
                        {
                            index = 0;

                            break;
                        }

                    case VisualScrollBar.VisualScrollBarArrowButtonState.UpPressed:
                    case VisualScrollBar.VisualScrollBarArrowButtonState.DownPressed:
                        {
                            index = 2;

                            break;
                        }
                }

                if (index != -1)
                {
                    using (Pen p1 = new Pen(arrowBorderColors[0]), p2 = new Pen(arrowBorderColors[1]))
                    {
                        g.DrawLine(p1, _rectangle.X, _rectangle.Y, _rectangle.Right - 1, _rectangle.Y);
                        g.DrawLine(p2, _rectangle.X, _rectangle.Bottom - 1, _rectangle.Right - 1, _rectangle.Bottom - 1);
                    }

                    _rectangle.Inflate(0, -1);

                    using (LinearGradientBrush brush = new LinearGradientBrush(_rectangle, arrowBorderColors[2], arrowBorderColors[1], LinearGradientMode.Vertical))
                    {
                        ColorBlend blend = new ColorBlend(3)
                            {
                                Positions = new[] { 0f, .5f, 1f },
                                Colors = new[]
                                    {
                                        arrowBorderColors[2],
                                        arrowBorderColors[3],
                                        arrowBorderColors[0]
                                    }
                            };

                        brush.InterpolationColors = blend;

                        using (Pen p = new Pen(brush))
                        {
                            g.DrawLine(p, _rectangle.X, _rectangle.Y, _rectangle.X, _rectangle.Bottom - 1);
                            g.DrawLine(p, _rectangle.Right - 1, _rectangle.Y, _rectangle.Right - 1, _rectangle.Bottom - 1);
                        }
                    }

                    _rectangle.Inflate(0, 1);

                    Rectangle _upper = _rectangle;
                    _upper.Inflate(-1, 0);
                    _upper.Y++;
                    _upper.Height = 7;

                    using (LinearGradientBrush brush = new LinearGradientBrush(_upper, arrowColors[index, 2], arrowColors[index, 3], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, _upper);
                    }

                    _upper.Inflate(-1, 0);
                    _upper.Height = 6;

                    using (LinearGradientBrush brush = new LinearGradientBrush(_upper, arrowColors[index, 0], arrowColors[index, 1], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, _upper);
                    }

                    Rectangle _lower = _rectangle;
                    _lower.Inflate(-1, 0);
                    _lower.Y = 8;
                    _lower.Height = 8;

                    using (LinearGradientBrush brush = new LinearGradientBrush(_lower, arrowColors[index, 6], arrowColors[index, 7], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, _lower);
                    }

                    _lower.Inflate(-1, 0);

                    using (LinearGradientBrush brush = new LinearGradientBrush(_lower, arrowColors[index, 4], arrowColors[index, 5], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, _lower);
                    }
                }

                using (Image _arrowImage = Resources.ScrollBarArrowDown)
                {
                    if ((state == VisualScrollBar.VisualScrollBarArrowButtonState.DownDisabled) || (state == VisualScrollBar.VisualScrollBarArrowButtonState.UpDisabled))
                    {
                        ControlPaint.DrawImageDisabled(g, _arrowImage, 3, 6, Color.Transparent);
                    }
                    else
                    {
                        g.DrawImage(_arrowImage, 3, 6);
                    }
                }
            }

            return bitmap;
        }

        #endregion
    }
}