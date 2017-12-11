namespace VisualPlus.Managers
{
    #region Namespace

    using System;
<<<<<<< HEAD
    using System.Drawing;
    using System.Drawing.Imaging;

    #endregion

    internal class ColorManager
    {
        #region Constructors

        public enum Brightness
        {
            /// <summary>Darker.</summary>
            Dark,

            /// <summary>Lighter.</summary>
            Light
        }

        #endregion

        #region Events

        public static double BlendColor(double foreColor, double backgroundColor, double alpha)
        {
            double result = backgroundColor + (alpha * (foreColor - backgroundColor));
            if (result < 0.0)
            {
                result = 0.0;
            }

            if (result > 255)
            {
                result = 255;
            }

            return result;
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor, double blend)
        {
            double ratio = blend / 255d;
            double invRatio = 1d - ratio;
            var r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            var g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            var b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(r, g, b);
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor)
        {
            return BlendColor(backgroundColor, frontColor, frontColor.A);
        }

        /// <summary>The create color from rgb.</summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns>The <see cref="Color" />.</returns>
        public static Color CreateColorFromRGB(int red, int green, int blue)
=======
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;

    using VisualPlus.Enumerators;
    using VisualPlus.PInvoke;

    #endregion

    [Description("The color manager.")]
    public sealed class ColorManager
    {
        #region Events

        /// <summary>Blends the colors.</summary>
        /// <param name="backColor">The back color.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color BlendColor(Color backColor, Color foreColor, double alpha)
        {
            double _ratio = alpha / 255d;
            double _inverseRatio = 1d - _ratio;
            var _r = (int)((backColor.R * _inverseRatio) + (foreColor.R * _ratio));
            var _g = (int)((backColor.G * _inverseRatio) + (foreColor.G * _ratio));
            var _b = (int)((backColor.B * _inverseRatio) + (foreColor.B * _ratio));
            return Color.FromArgb(_r, _g, _b);
        }

        /// <summary>Blends the colors.</summary>
        /// <param name="backColor">The back color.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color BlendColor(Color backColor, Color foreColor)
        {
            return BlendColor(backColor, foreColor, foreColor.A);
        }

        /// <summary>Get the color from the Hex value.</summary>
        /// <param name="alpha">The alpha value.</param>
        /// <param name="value">The Hex value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color ColorFromHex(int alpha, string value)
        {
            return Color.FromArgb(alpha, ColorTranslator.FromHtml(value));
        }

        /// <summary>Get the color from the Hex value.</summary>
        /// <param name="value">The Hex value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color ColorFromHex(string value)
        {
            return ColorTranslator.FromHtml(value);
        }

        /// <summary>Get the color from position.</summary>
        /// <param name="position">The position.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color ColorFromPosition(Point position)
        {
            Bitmap _pixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

            using (Graphics _graphicsDestination = Graphics.FromImage(_pixel))
            {
                using (Graphics _graphicsSource = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr handleContextSource = _graphicsSource.GetHdc();
                    IntPtr handleContextDestination = _graphicsDestination.GetHdc();
                    int _retrievedResult = Gdi32.BitBlt(handleContextDestination, 0, 0, 1, 1, handleContextSource, position.X, position.Y, (int)CopyPixelOperation.SourceCopy);
                    _graphicsDestination.ReleaseHdc();
                    _graphicsSource.ReleaseHdc();
                }
            }

            return _pixel.GetPixel(0, 0);
        }

        /// <summary>Create a color from RGB values.</summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color ColorFromRGB(int red, int green, int blue)
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        {
            // Correct Red element
            int r = red;
            if (r > 255)
            {
                r = 255;
            }

            if (r < 0)
            {
                r = 0;
            }

            // Correct Green element
            int g = green;
            if (g > 255)
            {
                g = 255;
            }

            if (g < 0)
            {
                g = 0;
            }

            // Correct Blue Element
            int b = blue;
            if (b > 255)
            {
                b = 255;
            }

            if (b < 0)
            {
                b = 0;
            }

            return Color.FromArgb(r, g, b);
        }

<<<<<<< HEAD
        /// <summary>Gets the color under the mouse.</summary>
        /// <returns>The color.</returns>
        public static Color CurrentPointerColor()
        {
            Point cursor = new Point();
            Native.GetCursorPos(ref cursor);
            return GetColorFromPosition(cursor);
        }

        /// <summary>Get the color from position.</summary>
        /// <param name="location">Cursor position.</param>
        /// <returns>The color.</returns>
        public static Color GetColorFromPosition(Point location)
        {
            using (Graphics graphicsDestination = Graphics.FromImage(screenPixel))
            {
                using (Graphics graphicsSource = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr handleContextSource = graphicsSource.GetHdc();
                    IntPtr handleContextDestination = graphicsDestination.GetHdc();
                    int retrieval = Native.BitBlt(handleContextDestination, 0, 0, 1, 1, handleContextSource, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    graphicsDestination.ReleaseHdc();
                    graphicsSource.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        /// <summary>Returns a brightness difference in color.</summary>
        /// <param name="brightness">The color tint.</param>
        /// <param name="c">The color.</param>
        /// <param name="d">The byte.</param>
        /// <returns>The new color.</returns>
        public static Color GetColorTint(Brightness brightness, Color c, byte d)
        {
            Color newColor = new Color();
            byte r;
            byte g;
            byte b;

            switch (brightness)
            {
                case Brightness.Dark:
                    {
                        r = 0;
                        g = 0;
                        b = 0;

                        if (c.R > d)
                        {
                            r = (byte)(c.R - d);
                        }

                        if (c.G > d)
                        {
                            g = (byte)(c.G - d);
                        }

                        if (c.B > d)
                        {
                            b = (byte)(c.B - d);
                        }

                        newColor = Color.FromArgb(r, g, b);
                        break;
                    }

                case Brightness.Light:
                    {
                        r = 255;
                        g = 255;
                        b = 255;

                        if (c.R + d < 255)
                        {
                            r = (byte)(c.R + d);
                        }

                        if (c.G + d < 255)
                        {
                            g = (byte)(c.G + d);
                        }

                        if (c.B + d < 255)
                        {
                            b = (byte)(c.B + d);
                        }

                        newColor = Color.FromArgb(r, g, b);
                        break;
                    }
            }

            return newColor;
        }

        /// <summary>
        /// </summary>
        /// <param name="blendColor"></param>
        /// <param name="baseColor"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static Color OpacityMix(Color blendColor, Color baseColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = blendColor.R;
            g1 = blendColor.G;
            b1 = blendColor.B;
            r2 = baseColor.R;
            g2 = baseColor.G;
            b2 = baseColor.B;
            r3 = (int)((r1 * ((float)opacity / 100)) + (r2 * (1 - ((float)opacity / 100))));
            g3 = (int)((g1 * ((float)opacity / 100)) + (g2 * (1 - ((float)opacity / 100))));
            b3 = (int)((b1 * ((float)opacity / 100)) + (b2 * (1 - ((float)opacity / 100))));
            return CreateColorFromRGB(r3, g3, b3);
        }

        /// <summary>
        /// </summary>
        /// <param name="ibase"></param>
        /// <param name="blend"></param>
        /// <returns></returns>
        public static int OverlayMath(int ibase, int blend)
        {
            double dbase;
            double dblend;
            dbase = (double)ibase / 255;
            dblend = (double)blend / 255;
            if (dbase < 0.5)
            {
                return (int)(2 * dbase * dblend * 255);
            }
            else
            {
                return (int)((1 - (2 * (1 - dbase) * (1 - dblend))) * 255);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="baseColor"></param>
        /// <param name="blendColor"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static Color OverlayMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = baseColor.R;
            g1 = baseColor.G;
            b1 = baseColor.B;
            r2 = blendColor.R;
            g2 = blendColor.G;
            b2 = blendColor.B;
            r3 = OverlayMath(baseColor.R, blendColor.R);
            g3 = OverlayMath(baseColor.G, blendColor.G);
            b3 = OverlayMath(baseColor.B, blendColor.B);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }

        /// <summary>Generates a random color.</summary>
        /// <returns>A random color.</returns>
        public static Color RandomColor()
        {
            Random _random = new Random();
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        /// <summary>
        /// </summary>
        /// <param name="baseColor"></param>
        /// <param name="blendColor"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static Color SoftLightMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = baseColor.R;
            g1 = baseColor.G;
            b1 = baseColor.B;
            r2 = blendColor.R;
            g2 = blendColor.G;
            b2 = blendColor.B;
            r3 = SoftLightMath(r1, r2);
            g3 = SoftLightMath(g1, g2);
            b3 = SoftLightMath(b1, b2);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }

        public static Color StepColor(Color color, int inputAlpha)
        {
            if (inputAlpha == 100)
            {
                return color;
            }

            byte a = color.A;
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            float background;

            int alpha = Math.Min(inputAlpha, 200);
            alpha = Math.Max(alpha, 0);
            double doubleAlpha = (alpha - 100.0) / 100.0;

            if (doubleAlpha > 100)
            {
                // Blend with white
                background = 255.0F;

                // 0 = transparent fg; 1 = opaque fg
                doubleAlpha = 1.0F - doubleAlpha;
            }
            else
            {
                // Blend with black
                background = 0.0F;

                // 0 = transparent fg; 1 = opaque fg
                doubleAlpha = 1.0F + doubleAlpha;
            }

            r = (byte)BlendColor(r, background, doubleAlpha);
            g = (byte)BlendColor(g, background, doubleAlpha);
            b = (byte)BlendColor(b, background, doubleAlpha);

            return Color.FromArgb(a, r, g, b);
        }

        private static Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        /// <summary>
        /// </summary>
        /// <param name="ibase"></param>
        /// <param name="blend"></param>
        /// <returns></returns>
        private static int SoftLightMath(int ibase, int blend)
        {
            float dbase;
            float dblend;
            dbase = (float)ibase / 255;
            dblend = (float)blend / 255;
            if (dblend < 0.5)
            {
                return (int)(((2 * dbase * dblend) + (Math.Pow(dbase, 2) * (1 - (2 * dblend)))) * 255);
            }
            else
            {
                return (int)(((Math.Sqrt(dbase) * ((2 * dblend) - 1)) + (2 * dbase * (1 - dblend))) * 255);
=======
        /// <summary>Get the color underneath the cursor.</summary>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color CursorPointerColor()
        {
            Point cursor = new Point();
            User32.GetCursorPos(ref cursor);
            return ColorFromPosition(cursor);
        }

        /// <summary>Insert the color on to another color.</summary>
        /// <param name="baseColor">The base color.</param>
        /// <param name="insertColor">The insertColor.</param>
        /// <returns>The <see cref="Color" />.</returns>
        public static Color InsertColor(Color baseColor, Color insertColor)
        {
            return Color.FromArgb((baseColor.R + insertColor.R) / 2, (baseColor.G + insertColor.G) / 2, (baseColor.B + insertColor.B) / 2);
        }

        /// <summary>Creates an opacity mix color.</summary>
        /// <param name="baseColor">The base color.</param>
        /// <param name="blendColor">The blend color.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color OpacityMix(Color baseColor, Color blendColor, int opacity)
        {
            int _r0 = blendColor.R;
            int _g0 = blendColor.G;
            int _b0 = blendColor.B;
            int _r1 = baseColor.R;
            int _g1 = baseColor.G;
            int _b1 = baseColor.B;
            var _r2 = (int)((_r0 * ((float)opacity / 100)) + (_r1 * (1 - ((float)opacity / 100))));
            var _g2 = (int)((_g0 * ((float)opacity / 100)) + (_g1 * (1 - ((float)opacity / 100))));
            var _b2 = (int)((_b0 * ((float)opacity / 100)) + (_b1 * (1 - ((float)opacity / 100))));

            return ColorFromRGB(_r2, _g2, _b2);
        }

        /// <summary>Creates an overlay mix color.</summary>
        /// <param name="baseColor">The base color.</param>
        /// <param name="blendColor">The blend color.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color OverlayMix(Color baseColor, Color blendColor, int opacity)
        {
            int _r0 = baseColor.R;
            int _g0 = baseColor.G;
            int _b0 = baseColor.B;
            int _r1 = blendColor.R;
            int _g1 = blendColor.G;
            int _b1 = blendColor.B;
            int _r2 = OverlayMath(baseColor.R, blendColor.R);
            int _g2 = OverlayMath(baseColor.G, blendColor.G);
            int _b3 = OverlayMath(baseColor.B, blendColor.B);
            return OpacityMix(baseColor, ColorFromRGB(_r2, _g2, _b3), opacity);
        }

        /// <summary>Generates a random color.</summary>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color RandomColor()
        {
            Random _random = new Random();
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        /// <summary>Creates a soft light mix color.</summary>
        /// <param name="baseColor">The base color.</param>
        /// <param name="blendColor">The blend color.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color SoftLightMix(Color baseColor, Color blendColor, int opacity)
        {
            int _r0 = baseColor.R;
            int _g0 = baseColor.G;
            int _b0 = baseColor.B;
            int _r1 = blendColor.R;
            int _g1 = blendColor.G;
            int _b1 = blendColor.B;
            int _r2 = SoftLightMath(_r0, _r1);
            int _g2 = SoftLightMath(_g0, _g1);
            int _b2 = SoftLightMath(_b0, _b1);
            return OpacityMix(ColorFromRGB(_r2, _g2, _b2), baseColor, opacity);
        }

        /// <summary>Create a color step.</summary>
        /// <param name="color">The color.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color StepColor(Color color, int alpha)
        {
            if (alpha == 100)
            {
                return color;
            }

            byte _a = color.A;
            byte _r = color.R;
            byte _g = color.G;
            byte _b = color.B;
            float background;

            int _newAlpha = Math.Min(alpha, 200);
            _newAlpha = Math.Max(_newAlpha, 0);
            double doubleAlpha = (_newAlpha - 100.0) / 100.0;

            if (doubleAlpha > 100)
            {
                // Blend with white
                background = 255.0F;

                // 0 = transparent fg; 1 = opaque fg
                doubleAlpha = 1.0F - doubleAlpha;
            }
            else
            {
                // Blend with black
                background = 0.0F;

                // 0 = transparent fg; 1 = opaque fg
                doubleAlpha = 1.0F + doubleAlpha;
            }

            _r = (byte)BlendColor(background, _r, doubleAlpha);
            _g = (byte)BlendColor(background, _g, doubleAlpha);
            _b = (byte)BlendColor(background, _b, doubleAlpha);

            return Color.FromArgb(_a, _r, _g, _b);
        }

        /// <summary>Creates a tinted color.</summary>
        /// <param name="brightness">The brightness.</param>
        /// <param name="color">The color.</param>
        /// <param name="data">The byte.</param>
        /// <returns>
        ///     <see cref="Color" />
        /// </returns>
        public static Color TintColor(Brightness brightness, Color color, byte data)
        {
            Color _tintedColor;
            byte _r;
            byte _g;
            byte _b;

            switch (brightness)
            {
                case Brightness.Darker:
                    {
                        _r = 0;
                        _g = 0;
                        _b = 0;

                        if (color.R > data)
                        {
                            _r = (byte)(color.R - data);
                        }

                        if (color.G > data)
                        {
                            _g = (byte)(color.G - data);
                        }

                        if (color.B > data)
                        {
                            _b = (byte)(color.B - data);
                        }

                        _tintedColor = Color.FromArgb(_r, _g, _b);
                        break;
                    }

                case Brightness.Lighter:
                    {
                        _r = 255;
                        _g = 255;
                        _b = 255;

                        if (color.R + data < 255)
                        {
                            _r = (byte)(color.R + data);
                        }

                        if (color.G + data < 255)
                        {
                            _g = (byte)(color.G + data);
                        }

                        if (color.B + data < 255)
                        {
                            _b = (byte)(color.B + data);
                        }

                        _tintedColor = Color.FromArgb(_r, _g, _b);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(brightness), brightness, null);
                    }
            }

            return _tintedColor;
        }

        /// <summary>Retrieves the transition color between two other colors.</summary>
        /// <param name="value">The progress value in the transition.</param>
        /// <param name="beginColor">The beginning color.</param>
        /// <param name="endColor">The ending color.</param>
        /// <returns>The <see cref="Color" />.</returns>
        public static Color TransitionColor(int value, Color beginColor, Color endColor)
        {
            try
            {
                try
                {
                    int _red = int.Parse(Math.Round(beginColor.R + ((endColor.R - beginColor.R) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    int _green = int.Parse(Math.Round(beginColor.G + ((endColor.G - beginColor.G) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    int _blue = int.Parse(Math.Round(beginColor.B + ((endColor.B - beginColor.B) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    return Color.FromArgb(255, _red, _green, _blue);
                }
                catch (Exception)
                {
                    return beginColor;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>Blends the colors.</summary>
        /// <param name="backColor">The back color.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>
        ///     <see cref="double" />
        /// </returns>
        private static double BlendColor(double backColor, double foreColor, double alpha)
        {
            double result = backColor + (alpha * (foreColor - backColor));
            if (result < 0.0)
            {
                result = 0.0;
            }

            if (result > 255)
            {
                result = 255;
            }

            return result;
        }

        /// <summary>Calculate the overlay.</summary>
        /// <param name="baseValue">The base value.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>
        ///     <see cref="int" />
        /// </returns>
        private static int OverlayMath(int baseValue, int alpha)
        {
            double _baseOverlay = (double)baseValue / 255;
            double _alphaOverlay = (double)alpha / 255;
            if (_baseOverlay < 0.5)
            {
                return (int)(2 * _baseOverlay * _alphaOverlay * 255);
            }
            else
            {
                return (int)((1 - (2 * (1 - _baseOverlay) * (1 - _alphaOverlay))) * 255);
            }
        }

        /// <summary>Calculate the soft light.</summary>
        /// <param name="baseValue">The base value.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>
        ///     <see cref="int" />
        /// </returns>
        private static int SoftLightMath(int baseValue, int alpha)
        {
            float _softLightBase = (float)baseValue / 255;
            float _softLightAlpha = (float)alpha / 255;
            if (_softLightAlpha < 0.5)
            {
                return (int)(((2 * _softLightBase * _softLightAlpha) + (Math.Pow(_softLightBase, 2) * (1 - (2 * _softLightAlpha)))) * 255);
            }
            else
            {
                return (int)(((Math.Sqrt(_softLightBase) * ((2 * _softLightAlpha) - 1)) + (2 * _softLightBase * (1 - _softLightAlpha))) * 255);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }
        }

        #endregion
    }
}