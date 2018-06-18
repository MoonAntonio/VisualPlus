#region Namespace

using VisualPlus.Structure;

#endregion

namespace VisualPlus.EventArgs
{
    public class ThemeEventArgs : System.EventArgs
    {
        #region Variables

        private Theme _theme;

        #endregion

        #region Constructors

        public ThemeEventArgs(Theme theme)
        {
            _theme = theme;
        }

        #endregion

        #region Properties

        public Theme Theme
        {
            get
            {
                return _theme;
            }

            set
            {
                _theme = value;
            }
        }

        #endregion
    }
}