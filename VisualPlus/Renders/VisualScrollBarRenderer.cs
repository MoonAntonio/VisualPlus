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
    using VisualPlus.Toolkit.Controls.Layout;

    #endregion

    public sealed class VisualScrollBarRenderer
    {
        #region Constructors

        /// <summary>Initializes static members of the <see cref="VisualScrollBarRenderer" /> class.</summary>
        static VisualScrollBarRenderer()
        {
            // hot state
            thumbColors[0, 0] = Color.FromArgb(96, 111, 148); // border color
            thumbColors[0, 1] = Color.FromArgb(232, 233, 233); // left/top start color
            thumbColors[0, 2] = Color.FromArgb(230, 233, 241); // left/top end color
            thumbColors[0, 3] = Color.FromArgb(233, 237, 242); // right/bottom line color
            thumbColors[0, 4] = Color.FromArgb(209, 218, 228); // right/bottom start color
            thumbColors[0, 5] = Color.FromArgb(218, 227, 235); // right/bottom end color
            thumbColors[0, 6] = Color.FromArgb(190, 202, 219); // right/bottom middle color
            thumbColors[0, 7] = Color.FromArgb(96, 11, 148); // left/top line color

            // over state
            thumbColors[1, 0] = Color.FromArgb(60, 110, 176);
            thumbColors[1, 1] = Color.FromArgb(187, 204, 228);
            thumbColors[1, 2] = Color.FromArgb(205, 227, 254);
            thumbColors[1, 3] = Color.FromArgb(252, 253, 255);
            thumbColors[1, 4] = Color.FromArgb(170, 207, 247);
            thumbColors[1, 5] = Color.FromArgb(219, 232, 251);
            thumbColors[1, 6] = Color.FromArgb(190, 202, 219);
            thumbColors[1, 7] = Color.FromArgb(233, 233, 235);

            // pressed state
            thumbColors[2, 0] = Color.FromArgb(23, 73, 138);
            thumbColors[2, 1] = Color.FromArgb(154, 184, 225);
            thumbColors[2, 2] = Color.FromArgb(166, 202, 250);
            thumbColors[2, 3] = Color.FromArgb(221, 235, 251);
            thumbColors[2, 4] = Color.FromArgb(110, 166, 240);
            thumbColors[2, 5] = Color.FromArgb(194, 218, 248);
            thumbColors[2, 6] = Color.FromArgb(190, 202, 219);
            thumbColors[2, 7] = Color.FromArgb(194, 211, 231);

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

            // background colors
            backgroundColors[0] = Color.FromArgb(235, 237, 239);
            backgroundColors[1] = Color.FromArgb(252, 252, 252);
            backgroundColors[2] = Color.FromArgb(247, 247, 247);
            backgroundColors[3] = Color.FromArgb(238, 238, 238);
            backgroundColors[4] = Color.FromArgb(240, 240, 240);

            // track colors
            trackColors[0] = Color.FromArgb(204, 204, 204);
            trackColors[1] = Color.FromArgb(220, 220, 220);

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

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty
                                  || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            if (orientation == Orientation.Vertical)
            {
                DrawArrowButtonVertical(graphics, rectangle, state, arrowUp);
            }
            else
            {
                DrawArrowButtonHorizontal(graphics, rectangle, state, arrowUp);
            }
        }

        /// <summary>Draws the background.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        public static void DrawBackground(Graphics graphics, Rectangle rectangle, Orientation orientation)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty
                                  || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            if (orientation == Orientation.Vertical)
            {
                DrawBackgroundVertical(graphics, rectangle);
            }
            else
            {
                DrawBackgroundHorizontal(graphics, rectangle);
            }
        }

        /// <summary>Draws the thumb.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarState" /> of the thumb.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        public static void DrawThumb(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarState state, Orientation orientation)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty
                                  || !graphics.VisibleClipBounds.IntersectsWith(rectangle)
                                  || (state == VisualScrollBar.VisualScrollBarState.Disabled))
            {
                return;
            }

            if (orientation == Orientation.Vertical)
            {
                DrawThumbVertical(graphics, rectangle, state);
            }
            else
            {
                DrawThumbHorizontal(graphics, rectangle, state);
            }
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

            if (rectangle.IsEmpty || graphics.IsVisibleClipEmpty
                                  || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            // get grip image
            using (Image gripImage = Resources.GripNormal)
            {
                // adjust rectangle and rotate grip image if necessary
                Rectangle r = AdjustThumbGrip(rectangle, orientation, gripImage);

                // adjust alpha channel of grip image
                using (ImageAttributes attr = new ImageAttributes())
                {
                    attr.SetColorMatrix(
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

                    // draw grip image
                    graphics.DrawImage(gripImage, r, 0, 0, r.Width, r.Height, GraphicsUnit.Pixel, attr);
                }
            }
        }

        /// <summary>Draws the channel ( or track ).</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The scrollbar state.</param>
        /// <param name="orientation">The <see cref="Orientation" />.</param>
        public static void DrawTrack(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarState state, Orientation orientation)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if ((rectangle.Width <= 0) || (rectangle.Height <= 0)
                                     || (state != VisualScrollBar.VisualScrollBarState.Pressed) || graphics.IsVisibleClipEmpty
                                     || !graphics.VisibleClipBounds.IntersectsWith(rectangle))
            {
                return;
            }

            if (orientation == Orientation.Vertical)
            {
                DrawTrackVertical(graphics, rectangle);
            }
            else
            {
                DrawTrackHorizontal(graphics, rectangle);
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

        /// <summary>The background colors.</summary>
        private static Color[] backgroundColors = new Color[5];

        /// <summary>Creates a rounded rectangle.</summary>
        /// <param name="rectangle">The rectangle to create the rounded rectangle from.</param>
        /// <param name="radiusX">The x-radius.</param>
        /// <param name="radiusY">The y-radius.</param>
        /// <returns>A <see cref="GraphicsPath" /> object representing the rounded rectangle.</returns>
        private static GraphicsPath CreateRoundPath(Rectangle rectangle, float radiusX, float radiusY)
        {
            // create new graphics path object
            GraphicsPath path = new GraphicsPath();

            // calculate radius of edges
            PointF d = new PointF(Math.Min(radiusX * 2, rectangle.Width), Math.Min(radiusY * 2, rectangle.Height));

            // make sure radius is valid
            d.X = Math.Max(1, d.X);
            d.Y = Math.Max(1, d.Y);

            // add top left arc
            path.AddArc(rectangle.X, rectangle.Y, d.X, d.Y, 180, 90);

            // add top right arc
            path.AddArc(rectangle.Right - d.X, rectangle.Y, d.X, d.Y, 270, 90);

            // add bottom right arc
            path.AddArc(rectangle.Right - d.X, rectangle.Bottom - d.Y, d.X, d.Y, 0, 90);

            // add bottom left arc
            path.AddArc(rectangle.X, rectangle.Bottom - d.Y, d.X, d.Y, 90, 90);

            // close path
            path.CloseFigure();

            return path;
        }

        /// <summary>Draws an arrow button.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarArrowButtonState" /> of the arrow button.</param>
        /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
        private static void DrawArrowButtonHorizontal(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarArrowButtonState state, bool arrowUp)
        {
            using (Image arrowImage = GetArrowDownButtonImage(state))
            {
                if (arrowUp)
                {
                    arrowImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    arrowImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }

                graphics.DrawImage(arrowImage, rectangle);
            }
        }

        /// <summary>Draws an arrow button.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarArrowButtonState" /> of the arrow button.</param>
        /// <param name="arrowUp">true for an up arrow, false otherwise.</param>
        private static void DrawArrowButtonVertical(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarArrowButtonState state, bool arrowUp)
        {
            using (Image arrowImage = GetArrowDownButtonImage(state))
            {
                if (arrowUp)
                {
                    arrowImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }

                graphics.DrawImage(arrowImage, rectangle);
            }
        }

        /// <summary>Draws the background.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        private static void DrawBackgroundHorizontal(Graphics graphics, Rectangle rectangle)
        {
            using (Pen p = new Pen(backgroundColors[0]))
            {
                graphics.DrawLine(p, rectangle.Left + 1, rectangle.Top + 1, rectangle.Right - 1, rectangle.Top + 1);
                graphics.DrawLine(p, rectangle.Left + 1, rectangle.Bottom - 2, rectangle.Right - 1, rectangle.Bottom - 2);
            }

            using (Pen p = new Pen(backgroundColors[1]))
            {
                graphics.DrawLine(p, rectangle.Left + 1, rectangle.Top + 2, rectangle.Right - 1, rectangle.Top + 2);
            }

            Rectangle firstRect = new Rectangle(
                rectangle.Left,
                rectangle.Top + 3,
                rectangle.Width,
                8);

            Rectangle secondRect = new Rectangle(
                firstRect.Left,
                firstRect.Bottom - 1,
                firstRect.Width,
                7);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                firstRect,
                backgroundColors[2],
                backgroundColors[3],
                LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, firstRect);
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(
                secondRect,
                backgroundColors[3],
                backgroundColors[4],
                LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, secondRect);
            }
        }

        /// <summary>Draws the background.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        private static void DrawBackgroundVertical(Graphics graphics, Rectangle rectangle)
        {
            using (Pen p = new Pen(backgroundColors[0]))
            {
                graphics.DrawLine(p, rectangle.Left + 1, rectangle.Top + 1, rectangle.Left + 1, rectangle.Bottom - 1);
                graphics.DrawLine(p, rectangle.Right - 2, rectangle.Top + 1, rectangle.Right - 2, rectangle.Bottom - 1);
            }

            using (Pen p = new Pen(backgroundColors[1]))
            {
                graphics.DrawLine(p, rectangle.Left + 2, rectangle.Top + 1, rectangle.Left + 2, rectangle.Bottom - 1);
            }

            Rectangle firstRect = new Rectangle(
                rectangle.Left + 3,
                rectangle.Top,
                8,
                rectangle.Height);

            Rectangle secondRect = new Rectangle(
                firstRect.Right - 1,
                firstRect.Top,
                7,
                firstRect.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                firstRect,
                backgroundColors[2],
                backgroundColors[3],
                LinearGradientMode.Horizontal))
            {
                graphics.FillRectangle(brush, firstRect);
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(
                secondRect,
                backgroundColors[3],
                backgroundColors[4],
                LinearGradientMode.Horizontal))
            {
                graphics.FillRectangle(brush, secondRect);
            }
        }

        /// <summary>Draws the thumb.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarState" /> of the thumb.</param>
        private static void DrawThumbHorizontal(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarState state)
        {
            int index = 0;

            switch (state)
            {
                case VisualScrollBar.VisualScrollBarState.Hot:
                    {
                        index = 1;
                        break;
                    }

                case VisualScrollBar.VisualScrollBarState.Pressed:
                    {
                        index = 2;
                        break;
                    }
            }

            Rectangle innerRect = rectangle;
            innerRect.Inflate(-1, -1);

            Rectangle r = innerRect;
            r.Height = 6;
            r.Width++;

            // draw left gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(r, thumbColors[index, 1], thumbColors[index, 2], LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, r);
            }

            r.Y = r.Bottom;

            // draw right gradient
            if (index == 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    r,
                    thumbColors[index, 4],
                    thumbColors[index, 5],
                    LinearGradientMode.Vertical))
                {
                    brush.InterpolationColors = new ColorBlend(3)
                        {
                            Colors = new[]
                                {
                                    thumbColors[index, 4],
                                    thumbColors[index, 6],
                                    thumbColors[index, 5]
                                },
                            Positions = new[] { 0f, .5f, 1f }
                        };

                    graphics.FillRectangle(brush, r);
                }
            }
            else
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(r, thumbColors[index, 4], thumbColors[index, 5], LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(brush, r);
                }

                // draw left line
                using (Pen p = new Pen(thumbColors[index, 7]))
                {
                    graphics.DrawLine(p, innerRect.X, innerRect.Y, innerRect.Right, innerRect.Y);
                }
            }

            // draw right line
            using (Pen p = new Pen(thumbColors[index, 3]))
            {
                graphics.DrawLine(p, innerRect.X, innerRect.Bottom, innerRect.Right, innerRect.Bottom);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // draw border
            using (Pen p = new Pen(thumbColors[index, 0]))
            {
                using (GraphicsPath path = CreateRoundPath(rectangle, 2f, 2f))
                {
                    graphics.DrawPath(p, path);
                }
            }

            graphics.SmoothingMode = SmoothingMode.None;
        }

        /// <summary>Draws the thumb.</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        /// <param name="state">The <see cref="VisualScrollBar.VisualScrollBarState" /> of the thumb.</param>
        private static void DrawThumbVertical(Graphics graphics, Rectangle rectangle, VisualScrollBar.VisualScrollBarState state)
        {
            int index = 0;

            switch (state)
            {
                case VisualScrollBar.VisualScrollBarState.Hot:
                    {
                        index = 1;
                        break;
                    }

                case VisualScrollBar.VisualScrollBarState.Pressed:
                    {
                        index = 2;
                        break;
                    }
            }

            Rectangle innerRect = rectangle;
            innerRect.Inflate(-1, -1);

            Rectangle r = innerRect;
            r.Width = 6;
            r.Height++;

            // draw left gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                r,
                thumbColors[index, 1],
                thumbColors[index, 2],
                LinearGradientMode.Horizontal))
            {
                graphics.FillRectangle(brush, r);
            }

            r.X = r.Right;

            // draw right gradient
            if (index == 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    r,
                    thumbColors[index, 4],
                    thumbColors[index, 5],
                    LinearGradientMode.Horizontal))
                {
                    brush.InterpolationColors = new ColorBlend(3)
                        {
                            Colors = new[]
                                {
                                    thumbColors[index, 4],
                                    thumbColors[index, 6],
                                    thumbColors[index, 5]
                                },
                            Positions = new[] { 0f, .5f, 1f }
                        };

                    graphics.FillRectangle(brush, r);
                }
            }
            else
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    r,
                    thumbColors[index, 4],
                    thumbColors[index, 5],
                    LinearGradientMode.Horizontal))
                {
                    graphics.FillRectangle(brush, r);
                }

                // draw left line
                using (Pen p = new Pen(thumbColors[index, 7]))
                {
                    graphics.DrawLine(p, innerRect.X, innerRect.Y, innerRect.X, innerRect.Bottom);
                }
            }

            // draw right line
            using (Pen p = new Pen(thumbColors[index, 3]))
            {
                graphics.DrawLine(p, innerRect.Right, innerRect.Y, innerRect.Right, innerRect.Bottom);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // draw border
            using (Pen p = new Pen(thumbColors[index, 0]))
            {
                using (GraphicsPath path = CreateRoundPath(rectangle, 2f, 2f))
                {
                    graphics.DrawPath(p, path);
                }
            }

            graphics.SmoothingMode = SmoothingMode.None;
        }

        /// <summary>Draws the channel ( or track ).</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        private static void DrawTrackHorizontal(Graphics graphics, Rectangle rectangle)
        {
            Rectangle innerRect = new Rectangle(rectangle.Left, rectangle.Top + 1, rectangle.Width, 15);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                innerRect,
                trackColors[0],
                trackColors[1],
                LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, innerRect);
            }
        }

        /// <summary>Draws the channel ( or track ).</summary>
        /// <param name="graphics">The <see cref="Graphics" /> used to paint.</param>
        /// <param name="rectangle">The rectangle in which to paint.</param>
        private static void DrawTrackVertical(Graphics graphics, Rectangle rectangle)
        {
            Rectangle innerRect = new Rectangle(rectangle.Left + 1, rectangle.Top, 15, rectangle.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                innerRect,
                trackColors[0],
                trackColors[1],
                LinearGradientMode.Horizontal))
            {
                graphics.FillRectangle(brush, innerRect);
            }
        }

        /// <summary>Draws the arrow down button for the scrollbar.</summary>
        /// <param name="state">The button state.</param>
        /// <returns>The arrow down button as <see cref="Image" />.</returns>
        private static Image GetArrowDownButtonImage(VisualScrollBar.VisualScrollBarArrowButtonState state)
        {
            Rectangle rect = new Rectangle(0, 0, 15, 17);
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
                        g.DrawLine(p1, rect.X, rect.Y, rect.Right - 1, rect.Y);
                        g.DrawLine(p2, rect.X, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                    }

                    rect.Inflate(0, -1);

                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, arrowBorderColors[2], arrowBorderColors[1], LinearGradientMode.Vertical))
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
                            g.DrawLine(p, rect.X, rect.Y, rect.X, rect.Bottom - 1);
                            g.DrawLine(p, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 1);
                        }
                    }

                    rect.Inflate(0, 1);

                    Rectangle upper = rect;
                    upper.Inflate(-1, 0);
                    upper.Y++;
                    upper.Height = 7;

                    using (LinearGradientBrush brush = new LinearGradientBrush(upper, arrowColors[index, 2], arrowColors[index, 3], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, upper);
                    }

                    upper.Inflate(-1, 0);
                    upper.Height = 6;

                    using (LinearGradientBrush brush = new LinearGradientBrush(upper, arrowColors[index, 0], arrowColors[index, 1], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, upper);
                    }

                    Rectangle lower = rect;
                    lower.Inflate(-1, 0);
                    lower.Y = 8;
                    lower.Height = 8;

                    using (LinearGradientBrush brush = new LinearGradientBrush(lower, arrowColors[index, 6], arrowColors[index, 7], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, lower);
                    }

                    lower.Inflate(-1, 0);

                    using (LinearGradientBrush brush = new LinearGradientBrush(lower, arrowColors[index, 4], arrowColors[index, 5], LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, lower);
                    }
                }

                using (Image arrowIcon = Resources.ScrollBarArrowDown)
                {
                    if ((state == VisualScrollBar.VisualScrollBarArrowButtonState.DownDisabled) || (state == VisualScrollBar.VisualScrollBarArrowButtonState.UpDisabled))
                    {
                        ControlPaint.DrawImageDisabled(
                            g,
                            arrowIcon,
                            3,
                            6,
                            Color.Transparent);
                    }
                    else
                    {
                        g.DrawImage(arrowIcon, 3, 6);
                    }
                }
            }

            return bitmap;
        }

        /// <summary>The colors of the thumb in the 3 states.</summary>
        private static Color[,] thumbColors = new Color[3, 8];

        /// <summary>The track colors.</summary>
        private static Color[] trackColors = new Color[2];

        #endregion
    }
}