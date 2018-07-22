#region Namespace

using System;
using System.Drawing;

using VisualPlus.Toolkit.Controls.DataVisualization;

#endregion

namespace VisualPlus.Renders
{
    public class VisualTileRenderer
    {
        #region Methods

        /// <summary>Render the tile.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="type">The type to draw.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to  draw.</param>
        /// <param name="foreColor">The fore color.</param>
        /// <param name="stringFormat">The string Format.</param>
        /// <param name="offset">The location offset.</param>
        public static void RenderTile(Graphics graphics, VisualTile.TileType type, Rectangle clientRectangle, Image image, string text, Font font, Color foreColor, StringFormat stringFormat, Point offset = new Point())
        {
            switch (type)
            {
                case VisualTile.TileType.Image:
                    {
                        VisualImageRenderer.RenderImageCentered(graphics, clientRectangle, image, offset);
                        break;
                    }

                case VisualTile.TileType.Text:
                    {
                        VisualTextRenderer.RenderText(graphics, clientRectangle, text, font, foreColor, stringFormat);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                    }
            }
        }

        #endregion
    }
}