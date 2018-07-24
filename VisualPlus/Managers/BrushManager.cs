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

        #endregion
    }
}