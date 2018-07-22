#region Namespace

using System;
using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Enumerators;

#endregion

namespace VisualPlus.Managers
{
    public sealed class RelationManager
    {
        #region Methods

        /// <summary>Draws the text image relation.</summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="textImageRelation">The text Image Relation.</param>
        /// <param name="image">The image rectangle.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="bounds">The outer bounds.</param>
        /// <param name="relation">The relation type.</param>
        /// <returns>The <see cref="Point" />.</returns>
        public static Point GetTextImageRelationLocation(Graphics graphics, TextImageRelation textImageRelation, Rectangle image, string text, Font font, Rectangle bounds, Relation relation)
        {
            Point imageLocation;
            Point textLocation;
            Size textSize = TextManager.MeasureText(text, font, graphics);

            switch (textImageRelation)
            {
                case TextImageRelation.Overlay:
                    {
                        imageLocation = Overlay(image, bounds, textSize, Relation.Image);
                        textLocation = Overlay(image, bounds, textSize, Relation.Text);
                        break;
                    }

                case TextImageRelation.ImageBeforeText:
                    {
                        imageLocation = ImageBeforeText(image, bounds, textSize, Relation.Image);
                        textLocation = ImageBeforeText(image, bounds, textSize, Relation.Text);
                        break;
                    }

                case TextImageRelation.TextBeforeImage:
                    {
                        imageLocation = TextBeforeImage(image, bounds, textSize, Relation.Image);
                        textLocation = TextBeforeImage(image, bounds, textSize, Relation.Text);
                        break;
                    }

                case TextImageRelation.ImageAboveText:
                    {
                        imageLocation = ImageAboveText(image, bounds, textSize, Relation.Image);
                        textLocation = ImageAboveText(image, bounds, textSize, Relation.Text);
                        break;
                    }

                case TextImageRelation.TextAboveImage:
                    {
                        imageLocation = TextAboveImage(image, bounds, textSize, Relation.Image);
                        textLocation = TextAboveImage(image, bounds, textSize, Relation.Text);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
                    }
            }

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>Retrieves the relation location.</summary>
        /// <param name="relation">The relation.</param>
        /// <param name="imageLocation">The image location.</param>
        /// <param name="textLocation">The text location.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point GetRelationPoint(Relation relation, Point imageLocation, Point textLocation)
        {
            Point result;
            switch (relation)
            {
                case Relation.Image:
                    {
                        result = imageLocation;
                        break;
                    }

                case Relation.Text:
                    {
                        result = textLocation;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
                    }
            }

            return result;
        }

        /// <summary>The image above text location.</summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point ImageAboveText(Rectangle image, Rectangle bounds, Size textSize, Relation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point
                    {
                       X = bounds.Width / 2 
                    };

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y + 4;

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = imageLocation.Y + image.Height;

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>The image before text location.</summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point ImageBeforeText(Rectangle image, Rectangle bounds, Size textSize, Relation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point
                    {
                       Y = bounds.Height / 2 
                    };

            // Set image
            imageLocation.X = newPosition.X + 4;
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            // Set text
            textLocation.X = imageLocation.X + image.Width;
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>The overlay location.</summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point Overlay(Rectangle image, Rectangle bounds, Size textSize, Relation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point
                {
                    X = bounds.Width / 2,
                    Y = bounds.Height / 2
                };

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>The text above image location.</summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point TextAboveImage(Rectangle image, Rectangle bounds, Size textSize, Relation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point
                    {
                       X = bounds.Width / 2 
                    };

            // Set text
            textLocation.X = newPosition.X - (textSize.Width / 2);
            textLocation.Y = imageLocation.Y + 4;

            // Set image
            imageLocation.X = newPosition.X - (image.Width / 2);
            imageLocation.Y = newPosition.Y + textSize.Height + 4;

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        /// <summary>The text before image location.</summary>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="textSize">The text size.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>The <see cref="Point" />.</returns>
        private static Point TextBeforeImage(Rectangle image, Rectangle bounds, Size textSize, Relation relation)
        {
            Point imageLocation = new Point(0, 0);
            Point textLocation = new Point(0, 0);

            // Set center
            Point newPosition = new Point
                    {
                       Y = bounds.Height / 2 
                    };

            // Set text
            textLocation.X = newPosition.X + 4;
            textLocation.Y = newPosition.Y - (textSize.Height / 2);

            // Set image
            imageLocation.X = textLocation.X + textSize.Width;
            imageLocation.Y = newPosition.Y - (image.Height / 2);

            Point result = GetRelationPoint(relation, imageLocation, textLocation);
            return result;
        }

        #endregion
    }
}