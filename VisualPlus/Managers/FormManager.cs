#region Namespace

using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Constants;
using VisualPlus.Toolkit.Components;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualPlus.Managers
{
    public sealed class FormManager
    {
        #region Methods

        /// <summary>Draws the control box icon.</summary>
        /// <param name="size">The size.</param>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Bitmap" />.</returns>
        public static Bitmap DrawControlBoxIcon(Size size, string text)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Font font = new Font("Marlett", 12);

            graphics.DrawString(text, font, new SolidBrush(Color.Black), new PointF(0, 0));
            return bitmap;
        }

        /// <summary>Prepares the form for moving.</summary>
        /// <param name="form">The form.</param>
        public static void Move(Form form)
        {
            var defaultWindowHeight = 15;
            Point center = new Point(form.Width / 2, defaultWindowHeight);

            if (form is VisualForm visualForm)
            {
                if (visualForm.Moveable)
                {
                    center = new Point(visualForm.Width / 2, visualForm.WindowBarHeight / 2);
                }
                else
                {
                    return;
                }
            }

            Cursor.Position = form.PointToScreen(center);
        }

        /// <summary>Move the cursor to the form edge for sizing.</summary>
        /// <param name="form">The form.</param>
        public static void Sizing(Form form)
        {
            if (form.FormBorderStyle == FormBorderStyle.Fixed3D)
            {
                return;
            }

            if (form.FormBorderStyle == FormBorderStyle.FixedDialog)
            {
                return;
            }

            if (form.FormBorderStyle == FormBorderStyle.FixedToolWindow)
            {
                return;
            }

            if (form is VisualForm visualForm)
            {
                if (!visualForm.Sizable)
                {
                    return;
                }
            }

            Cursor.Position = form.PointToScreen(new Point(form.Width - 1, form.Height - 1));
        }

        /// <summary>Creates a default window context menu.</summary>
        /// <param name="form">The form.</param>
        /// <returns>The <see cref="VisualContextMenu" />.</returns>
        public static VisualContextMenu WindowContextMenu(VisualForm form)
        {
            VisualContextMenu _contextMenu = new VisualContextMenu
                    {
                       Name = Application.ProductName 
                    };

            ToolStripMenuItem _restore = new ToolStripMenuItem("Restore", null, (sender, args) => form.ControlBox.RestoreFormWindow(form));

            if ((form.WindowState == FormWindowState.Maximized) && form.MaximizeBox)
            {
                _restore.Enabled = true;
            }
            else
            {
                _restore.Enabled = false;
            }

            _restore.Image = DrawControlBoxIcon(new Size(20, 20), ControlBoxConstants.RestoreText);

            ToolStripMenuItem _move = new ToolStripMenuItem("Move", null, (sender, args) => Move(form))
                    {
                       Enabled = form.Moveable 
                    };

            ToolStripMenuItem _size = new ToolStripMenuItem("Size", null, (sender, args) => Sizing(form))
                    {
                       Enabled = form.Sizable 
                    };

            ToolStripMenuItem _minimize = new ToolStripMenuItem("Minimize", null, (sender, args) => form.ControlBox.MinimizeForm(form));

            if ((form.WindowState != FormWindowState.Minimized) && form.MinimizeBox)
            {
                _minimize.Enabled = true;
            }
            else
            {
                _minimize.Enabled = false;
            }

            _minimize.Image = DrawControlBoxIcon(new Size(20, 20), ControlBoxConstants.MinimizeText);

            ToolStripMenuItem _maximize = new ToolStripMenuItem("Maximize", null, (sender, args) => form.ControlBox.MaximizeForm(form));

            if ((form.WindowState == FormWindowState.Normal) && form.MaximizeBox)
            {
                _maximize.Enabled = true;
            }
            else
            {
                _maximize.Enabled = false;
            }

            _maximize.Image = DrawControlBoxIcon(new Size(20, 20), ControlBoxConstants.MaximizeText);

            ToolStripSeparator _separator = new ToolStripSeparator();

            ToolStripMenuItem _close = new ToolStripMenuItem("Close", null, (sender, args) => form.ControlBox.CloseForm(form))
                {
                    Image = DrawControlBoxIcon(new Size(20, 20), ControlBoxConstants.CloseText)
                };

            // Fix: shortcut keys drawing.
            // _close.ShortcutKeys = Keys.Alt | Keys.F4;
            _contextMenu.Items.Add(_restore);
            _contextMenu.Items.Add(_move);
            _contextMenu.Items.Add(_size);
            _contextMenu.Items.Add(_minimize);
            _contextMenu.Items.Add(_maximize);
            _contextMenu.Items.Add(_separator);
            _contextMenu.Items.Add(_close);

            return _contextMenu;
        }

        #endregion
    }
}