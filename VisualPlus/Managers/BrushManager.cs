#region Namespace

using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace VisualPlus.Managers
{
    public sealed class BrushManager
    {
        #region Methods

        /// <summary>Creates a glow brush from the specified graphics path.</summary>
        /// <param name="center">The center color of path gradient.</param>
        /// <param name="surrounding">The array of colors correspond to the points in the path.</param>
        /// <param name="point">The focus point for the gradient offset.</param>
        /// <param name="graphicsPath">The graphics path.</param>
        /// <param name="wrapMode">The wrap mode.</param>
        /// <returns>The <see cref="Brush" />.</returns>
        public static Brush GlowBrush(Color center, Color[] surrounding, PointF point, GraphicsPath graphicsPath, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(graphicsPath) { CenterColor = center, SurroundColors = surrounding, FocusScales = point, WrapMode = wrapMode };
        }

        /// <summary>Creates a glow brush from the specified the specified points.</summary>
        /// <param name="center">The center color of path gradient.</param>
        /// <param name="surrounding">The array of colors correspond to the points in the path.</param>
        /// <param name="point">The focus point for the gradient offset.</param>
        /// <param name="wrapMode">The wrap mode.</param>
        /// <returns>The <see cref="Brush" />.</returns>
        public static Brush GlowBrush(Color center, Color[] surrounding, PointF[] point, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(point) { CenterColor = center, SurroundColors = surrounding, WrapMode = wrapMode };
        }

        /// <summary>Draws the hatch brush as an image and then converts it to a texture brush for scaling.</summary>
        /// <param name="brush">Hatch brush pattern.</param>
        /// <returns>The <see cref="TextureBrush" />.</returns>
        public static TextureBrush HatchTextureBrush(HatchBrush brush)
        {
            using (Bitmap _bitmap = new Bitmap(8, 8))
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                graphics.FillRectangle(brush, 0, 0, 8, 8);
                return new TextureBrush(_bitmap);
            }
        }

        #endregion
    }
}