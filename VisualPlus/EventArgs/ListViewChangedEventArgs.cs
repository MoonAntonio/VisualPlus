#region Namespace

using VisualPlus.Enumerators;
using VisualPlus.Toolkit.Child;

#endregion

namespace VisualPlus.EventArgs
{
    public class ListViewChangedEventArgs : System.EventArgs
    {
        #region Variables

        private VisualListViewColumn _column;
        private VisualListViewItem _item;
        private ListViewChangedTypes _listViewChangedType;
        private VisualListViewSubItem _subItem;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ListViewChangedEventArgs" /> class.</summary>
        /// <param name="listViewChangedType">The list View Changed Type.</param>
        /// <param name="column">The column.</param>
        /// <param name="item">The item.</param>
        /// <param name="subItem">The sub Item.</param>
        public ListViewChangedEventArgs(ListViewChangedTypes listViewChangedType, VisualListViewColumn column, VisualListViewItem item, VisualListViewSubItem subItem)
        {
            _listViewChangedType = listViewChangedType;
            _column = column;
            _item = item;
            _subItem = subItem;
        }

        #endregion

        #region Properties

        /// <summary>The type of change.</summary>
        public ListViewChangedTypes ChangedType
        {
            get
            {
                return _listViewChangedType;
            }
        }

        /// <summary>The column name.</summary>
        public VisualListViewColumn Column
        {
            get
            {
                return _column;
            }

            set
            {
                _column = value;
            }
        }

        /// <summary>The item name.</summary>
        public VisualListViewItem Item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
            }
        }

        /// <summary>The sub item name.</summary>
        public VisualListViewSubItem SubItem
        {
            get
            {
                return _subItem;
            }

            set
            {
                _subItem = value;
            }
        }

        #endregion
    }
}