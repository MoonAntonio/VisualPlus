#region Namespace

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using VisualPlus.Enumerators;
using VisualPlus.Managers;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Renders
{
    public sealed class VisualControlRenderer
    {
        #region Methods

        /// <summary>Draws a button control.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The coordinates of the rectangle to draw.</param>
        /// <param name="backColor">The BackColor of the button.</param>
        /// <param name="backgroundImage">The background image for the button.</param>
        /// <param name="border">The border.</param>
        /// <param name="mouseState">The mouse State.</param>
        /// <param name="text">The string to draw.</param>
        /// <param name="font">The font to use in the string.</param>
        /// <param name="foreColor">The color of the string.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="imageSize">The image Size.</param>
        /// <param name="textImageRelation">The text image relation.</param>
        public static void DrawButton(Graphics graphics, Rectangle rectangle, Color backColor, Image backgroundImage, Border border, MouseStates mouseState, string text, Font font, Color foreColor, Image image, Size imageSize, TextImageRelation textImageRelation)
        {
            GraphicsPath _controlGraphicsPath = VisualBorderRenderer.CreateBorderTypePath(rectangle, border);
            VisualBackgroundRenderer.DrawBackground(graphics, backColor, backgroundImage, mouseState, rectangle, border);
            DrawContent(graphics, rectangle, text, font, foreColor, image, imageSize, textImageRelation);
            VisualBorderRenderer.DrawBorderStyle(graphics, border, _controlGraphicsPath, mouseState);
        }

        /// <summary>Draws the text and image content.</summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The coordinates of the rectangle to draw.</param>
        /// <param name="text">The string to draw.</param>
        /// <param name="font">The font to use in the string.</param>
        /// <param name="foreColor">The color of the string.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="imageSize">The image Size.</param>
        /// <param name="textImageRelation">The text image relation.</param>
        public static void DrawContent(Graphics graphics, Rectangle rectangle, string text, Font font, Color foreColor, Image image, Size imageSize, TextImageRelation textImageRelation)
        {
            Rectangle _imageRectangle = new Rectangle(new Point(), imageSize);
            Point _imagePoint = RelationManager.GetTextImageRelationLocation(graphics, textImageRelation, _imageRectangle, text, font, rectangle, Relation.Image);
            Point _textPoint = RelationManager.GetTextImageRelationLocation(graphics, textImageRelation, _imageRectangle, text, font, rectangle, Relation.Text);

            graphics.DrawImage(image, new Rectangle(_imagePoint, imageSize));
            graphics.DrawString(text, font, new SolidBrush(foreColor), _textPoint);
        }

        /// <summary>Draws a hatch component on the specified path.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="hatch">The hatch type.</param>
        /// <param name="hatchGraphicsPath">The hatch path to fill.</param>
        public static void DrawHatch(Graphics graphics, Hatch hatch, GraphicsPath hatchGraphicsPath)
        {
            if (!hatch.Visible)
            {
                return;
            }

            HatchBrush _hatchBrush = new HatchBrush(hatch.Style, hatch.ForeColor, hatch.BackColor);
            using (TextureBrush _textureBrush = GraphicsManager.DrawTextureUsingHatch(_hatchBrush))
            {
                _textureBrush.ScaleTransform(hatch.Size.Width, hatch.Size.Height);
                graphics.FillPath(_textureBrush, hatchGraphicsPath);
            }
        }

        #endregion
    }
}