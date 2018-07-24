#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using VisualPlus.Native;
using VisualPlus.Toolkit.Controls.DataVisualization;

#endregion

namespace VisualPlus.Managers
{
    [Description("The graphics manager.")]
    public sealed class GraphicsManager
    {
        #region Methods

        /// <summary>Anchors the rectangle to an anchored alignment of the base rectangle.</summary>
        /// <param name="anchorStyle">Alignment style.</param>
        /// <param name="baseRectangle">Base rectangle.</param>
        /// <param name="anchorWidth">Anchor width.</param>
        /// <returns>The <see cref="Rectangle" />.</returns>
        public static Rectangle ApplyAnchor(TabAlignment anchorStyle, Rectangle baseRectangle, int anchorWidth)
        {
            Point anchoredLocation;
            Size anchoredSize;

            switch (anchorStyle)
            {
                case TabAlignment.Top:
                    {
                        anchoredLocation = new Point(baseRectangle.X, baseRectangle.Y);
                        anchoredSize = new Size(baseRectangle.Width, anchorWidth);
                        break;
                    }

                case TabAlignment.Bottom:
                    {
                        anchoredLocation = new Point(baseRectangle.X, baseRectangle.Bottom - anchorWidth);
                        anchoredSize = new Size(baseRectangle.Width, anchorWidth);
                        break;
                    }

                case TabAlignment.Left:
                    {
                        anchoredLocation = new Point(baseRectangle.X, baseRectangle.Y);
                        anchoredSize = new Size(anchorWidth, baseRectangle.Height);
                        break;
                    }

                case TabAlignment.Right:
                    {
                        anchoredLocation = new Point(baseRectangle.Right - anchorWidth, baseRectangle.Y);
                        anchoredSize = new Size(anchorWidth, baseRectangle.Height);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(anchorStyle), anchorStyle, null);
                    }
            }

            Rectangle anchoredRectangle = new Rectangle(anchoredLocation, anchoredSize);
            return anchoredRectangle;
        }

        /// <summary>Apply BackColor change on the container and it's child controls.</summary>
        /// <param name="container">The container control.</param>
        /// <param name="backgroundColor">The container backgroundColor.</param>
        public static void ApplyContainerBackColorChange(Control container, Color backgroundColor)
        {
            foreach (object control in container.Controls)
            {
                if (control != null)
                {
                    ((Control)control).BackColor = backgroundColor;
                }
            }
        }

        /// <summary>Apply a gradient background image on the control.</summary>
        /// <param name="control">The control.</param>
        /// <param name="size">The size.</param>
        /// <param name="topLeft">The color for top-left.</param>
        /// <param name="topRight">The color for top-right.</param>
        /// <param name="bottomLeft">The color for bottom-left.</param>
        /// <param name="bottomRight">The color for bottom-right.</param>
        public static void ApplyGradientBackground(Control control, Size size, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight)
        {
            if (control.BackgroundImageLayout != ImageLayout.Stretch)
            {
                control.BackgroundImageLayout = ImageLayout.Stretch;
            }

            Image _image = ImageManager.CreateGradientBitmap(size, topLeft, topRight, bottomLeft, bottomRight);
            control.BackgroundImage = _image;
        }

        /// <summary>Calculates a 5 point star.</summary>
        /// <param name="originF"> The originF is the middle of the star.</param>
        /// <param name="outerRadius">Radius of the surrounding circle.</param>
        /// <param name="innerRadius">Radius of the circle for the "inner" points</param>
        /// <returns>The <see cref="PointF" />.</returns>
        public static PointF[] Calculate5PointStar(PointF originF, float outerRadius, float innerRadius)
        {
            // Define some variables to avoid as much calculations as possible
            // conversions to radians
            const double Ang36 = Math.PI / 5.0; // 36Â° x PI/180
            const double Ang72 = 2.0 * Ang36; // 72Â° x PI/180

            // some sine and cosine values we need
            var sin36 = (float)Math.Sin(Ang36);
            var sin72 = (float)Math.Sin(Ang72);
            var cos36 = (float)Math.Cos(Ang36);
            var cos72 = (float)Math.Cos(Ang72);

            // Fill array with 10 originF points
            PointF[] pointsArray = { originF, originF, originF, originF, originF, originF, originF, originF, originF, originF };
            pointsArray[0].Y -= outerRadius; // top off the star, or on a clock this is 12:00 or 0:00 hours
            pointsArray[1].X += innerRadius * sin36;
            pointsArray[1].Y -= innerRadius * cos36; // 0:06 hours
            pointsArray[2].X += outerRadius * sin72;
            pointsArray[2].Y -= outerRadius * cos72; // 0:12 hours
            pointsArray[3].X += innerRadius * sin72;
            pointsArray[3].Y += innerRadius * cos72; // 0:18
            pointsArray[4].X += outerRadius * sin36;
            pointsArray[4].Y += outerRadius * cos36; // 0:24 

            // Phew! Glad I got that trig working.
            pointsArray[5].Y += innerRadius;

            // I use the symmetry of the star figure here
            pointsArray[6].X += pointsArray[6].X - pointsArray[4].X;
            pointsArray[6].Y = pointsArray[4].Y; // mirror point
            pointsArray[7].X += pointsArray[7].X - pointsArray[3].X;
            pointsArray[7].Y = pointsArray[3].Y; // mirror point
            pointsArray[8].X += pointsArray[8].X - pointsArray[2].X;
            pointsArray[8].Y = pointsArray[2].Y; // mirror point
            pointsArray[9].X += pointsArray[9].X - pointsArray[1].X;
            pointsArray[9].Y = pointsArray[1].Y; // mirror point

            return pointsArray;
        }

        /// <summary>Draws the control.</summary>
        /// <param name="control">The control to draw.</param>
        /// <param name="point">The point.</param>
        public static void DrawControl(Control control, Point point)
        {
            Bitmap _bitmap = new Bitmap(control.Size.Width, control.Size.Height);
            control.DrawToBitmap(_bitmap, new Rectangle(point.X, point.Y, _bitmap.Width, _bitmap.Height));
        }

        /// <summary>Draws the rounded rectangle with the specific values.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rounding">The curve.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(int x, int y, int width, int height, int rounding)
        {
            Rectangle _rectangle = new Rectangle(x, y, width, height);
            GraphicsPath _graphicsPath = DrawRoundedRectangle(_rectangle, rounding);
            return _graphicsPath;
        }

        /// <summary>Draws the rounded rectangle with the specified values.</summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="rounding">The rounding.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(Rectangle rectangle, int rounding)
        {
            GraphicsPath _graphicsPath = new GraphicsPath();
            _graphicsPath.AddArc(rectangle.X, rectangle.Y, rounding, rounding, 180F, 90F);
            _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Y, rounding, rounding, 270F, 90F);
            _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
            _graphicsPath.AddArc(rectangle.X, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
            return _graphicsPath;
        }

        /// <summary>Draws the rounded rectangle with the specified values.</summary>
        /// <param name="rectangle">The Rectangle to fill.</param>
        /// <param name="curve">The Rounding border radius.</param>
        /// <param name="topLeft">The top left of rectangle be round or not.</param>
        /// <param name="topRight">The top right of rectangle be round or not.</param>
        /// <param name="bottomLeft">The bottom left of rectangle be round or not.</param>
        /// <param name="bottomRight">The bottom right of rectangle be round or not.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(Rectangle rectangle, int curve, bool topLeft = true, bool topRight = true, bool bottomLeft = true, bool bottomRight = true)
        {
            curve = curve * 2;

            GraphicsPath createRoundPath = new GraphicsPath(FillMode.Winding);
            if (!topLeft)
            {
                createRoundPath.AddLine(rectangle.X, rectangle.Y, rectangle.X, rectangle.Y);
            }
            else
            {
                createRoundPath.AddArc(rectangle.X, rectangle.Y, curve, curve, 180f, 90f);
            }

            if (!topRight)
            {
                createRoundPath.AddLine(rectangle.Right - rectangle.Width, rectangle.Y, rectangle.Width, rectangle.Y);
            }
            else
            {
                createRoundPath.AddArc(rectangle.Right - curve, rectangle.Y, curve, curve, 270f, 90f);
            }

            if (!bottomRight)
            {
                createRoundPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
            }
            else
            {
                createRoundPath.AddArc(rectangle.Right - curve, rectangle.Bottom - curve, curve, curve, 0f, 90f);
            }

            if (!bottomLeft)
            {
                createRoundPath.AddLine(rectangle.X, rectangle.Bottom, rectangle.X, rectangle.Bottom);
            }
            else
            {
                createRoundPath.AddArc(rectangle.X, rectangle.Bottom - curve, curve, curve, 90f, 90f);
            }

            createRoundPath.CloseFigure();
            return createRoundPath;
        }

        /// <summary>Draws the rounded rectangle with the specific values.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rounding">The curve.</param>
        /// <param name="addline">Adds a line between to extend to the curve.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle2(int x, int y, int width, int height, int rounding, bool addline)
        {
            Rectangle _rectangle = new Rectangle(x, y, width, height);
            GraphicsPath _rectangleGraphicsPath = DrawRoundedRectangle(_rectangle, rounding);
            return _rectangleGraphicsPath;
        }

        /// <summary>Draws the rounded rectangle with the specified values.</summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="rounding">The rounding.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle2(Rectangle rectangle, int rounding)
        {
            using (GraphicsPath _graphicsPath = new GraphicsPath())
            {
                _graphicsPath.StartFigure();
                _graphicsPath.AddArc(rectangle.X, rectangle.Y, rounding, rounding, 180F, 90F);
                _graphicsPath.AddLine(rounding, rectangle.Y, rectangle.Width - rounding, 90F);
                _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Y, rounding, rounding, 270F, 90F);
                _graphicsPath.AddLine(rectangle.Width, rounding, rectangle.Width, rectangle.Height - rounding);
                _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
                _graphicsPath.AddLine(rectangle.Width - rounding, rectangle.Height, rounding, rectangle.Height);
                _graphicsPath.AddArc(rectangle.X, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
                return _graphicsPath;
            }
        }

        /// <summary>Draws the rounded rectangle inside the rectangle.</summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="rounding">The rounding factor to apply.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangleInternal(Rectangle rectangle, int rounding)
        {
            GraphicsPath _roundedRectanglePath = new GraphicsPath();

            // Only use a rounding that will fit inside the rect
            rounding = Math.Min(rounding, Math.Min(rectangle.Width / 2, rectangle.Height / 2) - rounding);

            // If there is no room for any rounding effect...
            if (rounding <= 0)
            {
                // Just add a simple rectangle as a quick way of adding four lines
                _roundedRectanglePath.AddRectangle(rectangle);
            }
            else
            {
                // We create the path using a floating point rectangle
                RectangleF _rectangleF = new RectangleF(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

                // The border is made of up a quarter of a circle arc, in each corner
                int _arcLength = rounding * 2;
                _roundedRectanglePath.AddArc(_rectangleF.Left, _rectangleF.Top, _arcLength, _arcLength, 180F, 90F);
                _roundedRectanglePath.AddArc(_rectangleF.Right - _arcLength, _rectangleF.Top, _arcLength, _arcLength, 270F, 90F);
                _roundedRectanglePath.AddArc(_rectangleF.Right - _arcLength, _rectangleF.Bottom - _arcLength, _arcLength, _arcLength, 0F, 90F);
                _roundedRectanglePath.AddArc(_rectangleF.Left, _rectangleF.Bottom - _arcLength, _arcLength, _arcLength, 90F, 90F);

                // Make the last and first arc join up
                _roundedRectanglePath.CloseFigure();
            }

            return _roundedRectanglePath;
        }

        /// <summary>Draws the hatch brush as an image and then converts it to a texture brush for scaling.</summary>
        /// <param name="hatchBrush">Hatch brush pattern.</param>
        /// <returns>The <see cref="TextureBrush" />.</returns>
        public static TextureBrush DrawTextureUsingHatch(HatchBrush hatchBrush)
        {
            using (Bitmap _bitmap = new Bitmap(8, 8))
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                graphics.FillRectangle(hatchBrush, 0, 0, 8, 8);
                return new TextureBrush(_bitmap);
            }
        }

        /// <summary>Flip the size by orientation.</summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="size">Current size.</param>
        /// <returns>The <see cref="Size" />.</returns>
        public static Size FlipOrientationSize(Orientation orientation, Size size)
        {
            Size newSize = new Size(0, 0);

            // Resize
            if (orientation == Orientation.Vertical)
            {
                if (size.Width > size.Height)
                {
                    newSize = new Size(size.Height, size.Width);
                }
            }
            else
            {
                if (size.Width < size.Height)
                {
                    newSize = new Size(size.Height, size.Width);
                }
            }

            return newSize;
        }

        /// <summary>Flip the size by orientation.</summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="size">Current size.</param>
        /// <returns>The <see cref="Size" />.</returns>
        public static Size FlipOrientationSize(ScrollOrientation orientation, Size size)
        {
            Size _newSize;

            switch (orientation)
            {
                case ScrollOrientation.HorizontalScroll:
                    {
                        _newSize = FlipOrientationSize(Orientation.Horizontal, size);
                        break;
                    }

                case ScrollOrientation.VerticalScroll:
                    {
                        _newSize = FlipOrientationSize(Orientation.Vertical, size);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
                    }
            }

            return _newSize;
        }

        /// <summary>Checks whether the mouse is inside the bounds.</summary>
        /// <param name="mousePoint">Mouse location.</param>
        /// <param name="bounds">The rectangle.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool IsMouseInBounds(Point mousePoint, Rectangle bounds)
        {
            return bounds.Contains(mousePoint);
        }

        /// <summary>Rounds the region of the control.</summary>
        /// <param name="control">The control to round.</param>
        /// <param name="rounding">The amount of rounding.</param>
        public static void RoundRegion(Control control, int rounding)
        {
            try
            {
                control.Region = Region.FromHrgn(Gdi32.CreateRoundRectRgn(0, 0, control.Width, control.Height, rounding, rounding));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>Rounds the region of the control.</summary>
        /// <param name="form">The form control to round.</param>
        /// <param name="rounding">The amount of rounding.</param>
        public static void RoundRegion(Form form, int rounding)
        {
            try
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.Region = Region.FromHrgn(Gdi32.CreateRoundRectRgn(0, 0, form.Width, form.Height, rounding, rounding));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>Set's the container controls BackColor.</summary>
        /// <param name="control">Current control.</param>
        /// <param name="backgroundColor">Container background color.</param>
        /// <param name="onControlRemoved">Control removed?</param>
        public static void SetControlBackColor(Control control, Color backgroundColor, bool onControlRemoved)
        {
            Color backColor;

            if (onControlRemoved)
            {
                backColor = Color.Transparent;

                // Bug: The Control doesn't support transparent background
                if (control is VisualProgressIndicator)
                {
                    backColor = SystemColors.Control;
                }
            }
            else
            {
                backColor = backgroundColor;
            }

            control.BackColor = backColor;
        }

        /// <summary>Checks if the text is larger than the rectangle.</summary>
        /// <param name="text">The text.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool TextLargerThanRectangle(Size text, Rectangle rectangle)
        {
            return text.Height > rectangle.Size.Height;
        }

        /// <summary>Sets the graphics using picture box size mode.</summary>
        /// <param name="pictureBoxSizeMode">The picture box size mode.</param>
        /// <returns>The <see cref="Graphics" />.</returns>
        public Graphics SetPictureBoxSizeMode(PictureBoxSizeMode pictureBoxSizeMode)
        {
            Bitmap drawArea = new Bitmap(new PictureBox { SizeMode = pictureBoxSizeMode }.Size.Width, new PictureBox { SizeMode = pictureBoxSizeMode }.Size.Height);
            new PictureBox { SizeMode = pictureBoxSizeMode }.Image = drawArea;
            return Graphics.FromImage(drawArea);
        }

        #endregion
    }
}