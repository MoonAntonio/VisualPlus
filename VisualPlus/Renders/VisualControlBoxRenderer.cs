#region Namespace

using System;
using System.Drawing;

using VisualPlus.Constants;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualPlus.Renders
{
    public sealed class VisualControlBoxRenderer
    {
        #region Methods

        /// <summary>Renders the control box icon to a bitmap.</summary>
        /// <param name="size">The bitmap size.</param>
        /// <param name="controlBoxIcons">The control Box Icon.</param>
        /// <param name="color">The color.</param>
        /// <param name="emSize">The em Size.</param>
        /// <returns>The <see cref="Bitmap" />.</returns>
        public static Bitmap RenderControlBoxIcon(Size size, VisualForm.ControlBoxIcons controlBoxIcons, Color color, float emSize = 12F)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            string text;

            switch (controlBoxIcons)
            {
                case VisualForm.ControlBoxIcons.Help:
                    {
                        text = ControlBoxConstants.HelpText;
                        break;
                    }

                case VisualForm.ControlBoxIcons.Minimize:
                    {
                        text = ControlBoxConstants.MinimizeText;
                        break;
                    }

                case VisualForm.ControlBoxIcons.Maximize:
                    {
                        text = ControlBoxConstants.MaximizeText;
                        break;
                    }

                case VisualForm.ControlBoxIcons.Restore:
                    {
                        text = ControlBoxConstants.RestoreText;
                        break;
                    }

                case VisualForm.ControlBoxIcons.Close:
                    {
                        text = ControlBoxConstants.CloseText;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(controlBoxIcons), controlBoxIcons, null);
                    }
            }

            graphics.DrawString(text, new Font("Marlett", emSize), new SolidBrush(color), new PointF(0, 0));
            return bitmap;
        }

        #endregion
    }
}