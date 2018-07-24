#region Namespace

using System.Drawing;

using VisualPlus.Enumerators;
using VisualPlus.Managers;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Renders
{
    public class VisualTextRenderer
    {
        #region Methods

        /// <summary>Render the text in the specified location.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="location">The location.</param>
        public static void RenderText(Graphics graphics, Rectangle clientRectangle, string text, Font font, Color foreColor, Point location)
        {
            graphics.DrawString(text, font, new SolidBrush(foreColor), new Rectangle(location, clientRectangle.Size));
        }

        /// <summary>Render the text using the string format.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="stringFormat">The string Format.</param>
        public static void RenderText(Graphics graphics, Rectangle clientRectangle, string text, Font font, Color foreColor, StringFormat stringFormat)
        {
            graphics.DrawString(text, font, new SolidBrush(foreColor), clientRectangle, stringFormat);
        }

        /// <summary>Render the text using the text style.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="textStyle">The text Style.</param>
        public static void RenderText(Graphics graphics, Rectangle clientRectangle, string text, Font font, bool enabled, TextStyle textStyle)
        {
            Color _textColor = enabled ? textStyle.Enabled : textStyle.Disabled;
            RenderText(graphics, clientRectangle, text, font, _textColor, textStyle.StringFormat);
        }

        /// <summary>Render the text using the text style.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="mouseState">The mouse State.</param>
        /// <param name="textStyle">The text Style.</param>
        public static void RenderText(Graphics graphics, Rectangle clientRectangle, string text, Font font, bool enabled, MouseStates mouseState, TextStyle textStyle)
        {
            Color _textColor = TextStyle.GetColorState(enabled, mouseState, textStyle);
            RenderText(graphics, clientRectangle, text, font, _textColor, textStyle.StringFormat);
        }

        /// <summary>Render the text in the center of the client rectangle.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="offset">The location offset.</param>
        public static void RenderTextCentered(Graphics graphics, Rectangle clientRectangle, string text, Font font, Color foreColor, Point offset = new Point())
        {
            Size _stringSize = TextManager.MeasureText(text, font, graphics);
            Point _location = new Point(((clientRectangle.Width / 2) - (_stringSize.Width / 2)) + offset.X, ((clientRectangle.Height / 2) - (_stringSize.Height / 2)) + offset.Y);

            graphics.DrawString(text, font, new SolidBrush(foreColor), _location);
        }

        #endregion
    }
}