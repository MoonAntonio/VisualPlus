#region Namespace

using System;
using System.Drawing;

#endregion

namespace VisualPlus.Events
{
    public class VisualPaintEventArgs : EventArgs
    {
        #region Variables

        private Color _backColor;
        private Color _foreColor;
        private Graphics _graphics;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualPaintEventArgs" /> class.</summary>
        /// <param name="backColor">The back Color.</param>
        /// <param name="foreColor">The fore Color.</param>
        /// <param name="graphics">The graphics.</param>
        public VisualPaintEventArgs(Color backColor, Color foreColor, Graphics graphics)
        {
            _graphics = graphics;
            _backColor = backColor;
            _foreColor = foreColor;
        }

        #endregion

        #region Properties

        public Color BackColor
        {
            get
            {
                return _backColor;
            }
        }

        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }
        }

        public Graphics Graphics
        {
            get
            {
                return _graphics;
            }
        }

        #endregion
    }
}