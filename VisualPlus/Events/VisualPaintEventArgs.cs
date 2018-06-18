#region Namespace

using System;
using System.Drawing;

#endregion

namespace VisualPlus.Events
{
    public class VisualPaintEventArgs : EventArgs
    {
        #region Variables

        private Graphics _graphics;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualPaintEventArgs" /> class.</summary>
        /// <param name="graphics">The graphics.</param>
        public VisualPaintEventArgs(Graphics graphics)
        {
            _graphics = graphics;
        }

        #endregion

        #region Properties

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