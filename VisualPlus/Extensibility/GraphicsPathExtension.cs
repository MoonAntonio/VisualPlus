namespace VisualPlus.Extensibility
{
    #region Namespace

    using System.Drawing;
    using System.Drawing.Drawing2D;

    using VisualPlus.Renders;
    using VisualPlus.Structure;

    #endregion

    public static class GraphicsPathExtension
    {
        #region Events

        /// <summary>Converts the GraphicsPath to a border path.</summary>
        /// <param name="borderPath">The border path.</param>
        /// <param name="border">The border.</param>
<<<<<<< HEAD
        /// <returns>Converted border path.</returns>
=======
        /// <returns>The <see cref="GraphicsPath" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static GraphicsPath ToBorderPath(this GraphicsPath borderPath, Border border)
        {
            return VisualBorderRenderer.CreateBorderTypePath(borderPath.GetBounds().ToRectangle(), border);
        }

        /// <summary>Converts the Rectangle to a GraphicsPath.</summary>
        /// <param name="rectangle">The rectangle.</param>
<<<<<<< HEAD
        /// <returns>The graphics path.</returns>
=======
        /// <returns>The <see cref="GraphicsPath" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static GraphicsPath ToGraphicsPath(this Rectangle rectangle)
        {
            GraphicsPath convertedPath = new GraphicsPath();
            convertedPath.AddRectangle(rectangle);
            return convertedPath;
        }

        #endregion
    }
}