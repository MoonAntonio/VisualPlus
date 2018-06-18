#region Namespace

using System;

#endregion

namespace VisualPlus.Events
{
    public class ListViewClickEventArgs : EventArgs
    {
        #region Variables

        private int _columnIndex;
        private int _itemIndex;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ListViewClickEventArgs" /> class.</summary>
        /// <param name="itemIndex">The item Index.</param>
        /// <param name="columnIndex">The column Index.</param>
        public ListViewClickEventArgs(int itemIndex, int columnIndex)
        {
            _itemIndex = itemIndex;
            _columnIndex = columnIndex;
        }

        #endregion

        #region Properties

        /// <summary>The column index.</summary>
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
        }

        /// <summary>The item index.</summary>
        public int ItemIndex
        {
            get
            {
                return _itemIndex;
            }
        }

        #endregion
    }
}