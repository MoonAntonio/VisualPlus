namespace VisualPlus.Extensibility
{
    #region Namespace

    using System.Drawing;

    #endregion

    public static class PointExtension
    {
        #region Events

        /// <summary>Returns the center point of the rectangle.</summary>
        /// <param name="rectangle">This rectangle.</param>
<<<<<<< HEAD
        /// <returns>Center point.</returns>
=======
        /// <returns>The <see cref="Point" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Top + (rectangle.Height / 2));
        }

        #endregion
    }
}