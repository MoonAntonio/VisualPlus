﻿namespace VisualPlus.Extensibility
{
    #region Namespace

    using System.Drawing;

    #endregion

    public static class BitmapExtension
    {
        #region Events

        /// <summary>Filter the bitmap with GrayScale.</summary>
        /// <param name="bitmap">The bitmap.</param>
<<<<<<< HEAD
        /// <returns>Filtered bitmap.</returns>
=======
        /// <returns>The <see cref="Bitmap" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static Bitmap FilterGrayScale(this Bitmap bitmap)
        {
            Bitmap grayScale = new Bitmap(bitmap.Width, bitmap.Height);

            for (var y = 0; y < grayScale.Height; y++)
            {
                for (var x = 0; x < grayScale.Width; x++)
                {
                    Color c = bitmap.GetPixel(x, y);

                    var gs = (int)((c.R * 0.3) + (c.G * 0.59) + (c.B * 0.11));

                    grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
                }
            }

            return grayScale;
        }

        #endregion
    }
}