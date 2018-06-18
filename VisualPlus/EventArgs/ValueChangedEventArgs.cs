namespace VisualPlus.EventArgs
{
    public class ValueChangedEventArgs : System.EventArgs
    {
        #region Variables

        private long _value;

        #endregion

        #region Constructors

        public ValueChangedEventArgs(long value)
        {
            _value = value;
        }

        #endregion

        #region Properties

        public long Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        #endregion
    }
}