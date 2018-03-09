namespace VisualPlus.Managers
{
    #region Namespace

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    #endregion

    public sealed class RelationManager
    {
        #region Events

        /// <summary>Draws the text image relation.</summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="relation">The relation type.</param>
        /// <param name="image">The image rectangle.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="bounds">The outer bounds.</param>
        /// <param name="imagePoint">Return image point.</param>
        /// <returns>The <see cref="Point" />.</returns>
        public static Point GetTextImageRelationLocation(Graphics graphics, TextImageRelation relation, Rectangle image, string text, Font font, Rectangle bounds, bool imagePoint)
        {
            Point _newPosition = new Point(0, 0);
            Point _imageLocation = new Point(0, 0);
            Point _textLocation = new Point(0, 0);
            Size textSize = GraphicsManager.MeasureText(text, font, graphics);

            switch (relation)
            {
                case TextImageRelation.Overlay:
                    {
                        // Set center
                        _newPosition.X = bounds.Width / 2;
                        _newPosition.Y = bounds.Height / 2;

                        // Set image
                        _imageLocation.X = _newPosition.X - (image.Width / 2);
                        _imageLocation.Y = _newPosition.Y - (image.Height / 2);

                        // Set text
                        _textLocation.X = _newPosition.X - (textSize.Width / 2);
                        _textLocation.Y = _newPosition.Y - (textSize.Height / 2);
                        break;
                    }

                case TextImageRelation.ImageBeforeText:
                    {
                        // Set center
                        _newPosition.Y = bounds.Height / 2;

                        // Set image
                        _imageLocation.X = _newPosition.X + 4;
                        _imageLocation.Y = _newPosition.Y - (image.Height / 2);

                        // Set text
                        _textLocation.X = _imageLocation.X + image.Width;
                        _textLocation.Y = _newPosition.Y - (textSize.Height / 2);
                        break;
                    }

                case TextImageRelation.TextBeforeImage:
                    {
                        // Set center
                        _newPosition.Y = bounds.Height / 2;

                        // Set text
                        _textLocation.X = _newPosition.X + 4;
                        _textLocation.Y = _newPosition.Y - (textSize.Height / 2);

                        // Set image
                        _imageLocation.X = _textLocation.X + textSize.Width;
                        _imageLocation.Y = _newPosition.Y - (image.Height / 2);
                        break;
                    }

                case TextImageRelation.ImageAboveText:
                    {
                        // Set center
                        _newPosition.X = bounds.Width / 2;

                        // Set image
                        _imageLocation.X = _newPosition.X - (image.Width / 2);
                        _imageLocation.Y = _newPosition.Y + 4;

                        // Set text
                        _textLocation.X = _newPosition.X - (textSize.Width / 2);
                        _textLocation.Y = _imageLocation.Y + image.Height;
                        break;
                    }

                case TextImageRelation.TextAboveImage:
                    {
                        // Set center
                        _newPosition.X = bounds.Width / 2;

                        // Set text
                        _textLocation.X = _newPosition.X - (textSize.Width / 2);
                        _textLocation.Y = _imageLocation.Y + 4;

                        // Set image
                        _imageLocation.X = _newPosition.X - (image.Width / 2);
                        _imageLocation.Y = _newPosition.Y + textSize.Height + 4;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
                    }
            }

            if (imagePoint)
            {
                return _imageLocation;
            }
            else
            {
                return _textLocation;
            }
        }

        #endregion
    }
}