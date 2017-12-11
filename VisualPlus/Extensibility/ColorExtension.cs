namespace VisualPlus.Extensibility
{
    #region Namespace

    using System.Drawing;

    #endregion

    public static class ColorExtension
    {
        #region Events

        /// <summary>Converts the string HTML to a color.</summary>
        /// <param name="color">The color.</param>
        /// <param name="withoutHash">The HTML color. (Don't include hash '#')</param>
<<<<<<< HEAD
        /// <returns>The color from the HTML.</returns>
=======
        /// <returns>The <see cref="Color" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static Color FromHTML(this Color color, string withoutHash)
        {
            return ColorTranslator.FromHtml("#" + withoutHash);
        }

        /// <summary>Converts the color to HTML string.</summary>
        /// <param name="color">The color to convert to HTML.</param>
<<<<<<< HEAD
        /// <returns>The HTML from the color.</returns>
=======
        /// <returns>The <see cref="string" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static string ToHTML(this Color color)
        {
            return ColorTranslator.ToHtml(color);
        }

        #endregion
    }
}