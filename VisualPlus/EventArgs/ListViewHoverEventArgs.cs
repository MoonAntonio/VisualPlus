#region Namespace

using VisualPlus.Enumerators;

#endregion

namespace VisualPlus.EventArgs
{
    public class ListViewHoverEventArgs : System.EventArgs
    {
        #region Variables

        private int _columnIndex;
        private ListViewHoverTypes _hoverType;
        private int _itemIndex;
        private ListViewRegion _region;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ListViewHoverEventArgs" /> class.</summary>
        /// <param name="hoverType">The hover Type.</param>
        /// <param name="itemIndex">The item Index.</param>
        /// <param name="columnIndex">The column Index.</param>
        /// <param name="region">The region.</param>
        public ListViewHoverEventArgs(ListViewHoverTypes hoverType, int itemIndex, int columnIndex, ListViewRegion region)
        {
            _hoverType = hoverType;
            _region = region;
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

        /// <summary>The hover type.</summary>
        public ListViewHoverTypes HoverType
        {
            get
            {
                return _hoverType;
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

        /// <summary>The region being hovered.</summary>
        public ListViewRegion Region
        {
            get
            {
                return _region;
            }
        }

        #endregion
    }
}