#region Namespace

using System;

#endregion

namespace VisualPlus.Events
{
    public class ToggleEventArgs : EventArgs
    {
        #region Variables

        private bool _state;

        #endregion

        #region Constructors

        public ToggleEventArgs(bool state)
        {
            _state = state;
        }

        #endregion

        #region Properties

        public bool State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        #endregion
    }
}