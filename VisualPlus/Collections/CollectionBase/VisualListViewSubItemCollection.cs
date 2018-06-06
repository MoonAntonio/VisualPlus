namespace VisualPlus.Collections.CollectionBase
{
    #region Namespace

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;

    using VisualPlus.Delegates;
    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Extensibility;
    using VisualPlus.Managers;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataManagement;

    #endregion

    public class VisualListViewSubItemCollection : CollectionBase, ICloneable, IList
    {
        #region Variables

        private int _lastAccessedIndex;
        private VisualListViewAdvanced _listView;
        private VisualListViewItem _owner;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewSubItemCollection" /> class.</summary>
        public VisualListViewSubItemCollection()
        {
            _lastAccessedIndex = -1;
            _owner = null;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualListViewSubItemCollection" /> class.</summary>
        /// <param name="owner">The <see cref="VisualListViewItem" /> that owns the collection.</param>
        public VisualListViewSubItemCollection(VisualListViewItem owner) : this()
        {
            _owner = owner;
        }

        #endregion

        #region Events

        public event ListViewChangedEventHandler ChangedEvent;

        #endregion

        #region Properties

        /// <summary>Gets or sets the parent to know what to refresh on change.</summary>
        [Description("Parent")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public VisualListViewAdvanced ListView
        {
            get
            {
                return _listView;
            }

            set
            {
                _listView = value;

                // Iterate through each item and send them to the parent.
                foreach (VisualListViewSubItem _subItem in List)
                {
                    _subItem.ListView = _listView;
                }
            }
        }

        /// <summary>Returns a list of only the selected items indexes.</summary>
        [Description("Selected items array of indicies")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ArrayList SelectedIndicies
        {
            get
            {
                ArrayList _selectedItems = new ArrayList();

                // Go through list and add only selected items.
                for (int index = 0; index < Count; index++)
                {
                    if (this[index].Selected)
                    {
                        _selectedItems.Add(index);
                    }
                }

                return _selectedItems;
            }
        }

        /// <summary>Returns a list of only the selected items.</summary>
        [Description("Selected items array")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ArrayList SelectedItems
        {
            get
            {
                ArrayList _selectedItems = new ArrayList();

                // Go through list and add only selected items.
                for (var index = 0; index < Count; index++)
                {
                    if (this[index].Selected)
                    {
                        _selectedItems.Add(this[index]);
                    }
                }

                return _selectedItems;
            }
        }

        #endregion

        #region Indexers

        /// <summary>Gets or sets the subitem at the specified index within the collection.</summary>
        /// <param name="index">The index of the item in the collection to retrieve.</param>
        /// <returns>
        ///     A <see cref="VisualListViewSubItem" /> representing the subitem located at the specified index within the
        ///     collection.
        /// </returns>
        public VisualListViewSubItem this[int index]
        {
            get
            {
                int bailOut = 0;

                while (List.Count <= index)
                {
                    VisualListViewSubItem newitem = new VisualListViewSubItem();
                    newitem.ChangedEvent += SubItem_Changed;
                    newitem.ListView = ListView;

                    // newitem.Control = Parent.Columns[ nItemIndex ]
                    List.Add(newitem); // if the index doesn't yet exist, fill in the subitems till it does

                    if (bailOut++ > 25)
                    {
                        break;
                    }
                }

                return (VisualListViewSubItem)List[index];
            }
        }

        /// <summary>Gets an item with the specified key from the collection.</summary>
        /// <param name="key">The name of the <see cref="VisualListViewSubItem" /> to retrieve.</param>
        /// <returns>The <see cref="VisualListViewSubItem" /> with the specified key.</returns>
        public virtual VisualListViewSubItem this[string key]
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                {
                    return null;
                }

                int _index = IndexOfKey(key);
                DebugTraceManager.WriteDebug("VisualListViewSubItem this[string key - Key: " + key + " Index: " + _index, DebugTraceManager.DebugOutput.TraceListener);

                if (List.IsValidIndex(_index))
                {
                    return this[_index];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Overrides

        /// <summary>Items have been cleared event.</summary>
        protected override void OnClear()
        {
            ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.ItemCollectionChanged, null, null, null));
        }

        #endregion

        #region Methods

        /// <summary>Adds a subitem to the collection with the specified text.</summary>
        /// <param name="text">The text to display.</param>
        /// <returns>The <see cref="VisualListViewSubItem" /> that was added to the collection.</returns>
        public VisualListViewSubItem Add(string text)
        {
            VisualListViewSubItem _item = new VisualListViewSubItem(_owner, text);
            Add(_item);
            return _item;
        }

        /// <summary>Adds an existing <see cref="VisualListViewSubItem" /> to the collection.</summary>
        /// <param name="item">The <see cref="VisualListViewSubItem" /> to add to the collection.</param>
        /// <returns>The <see cref="VisualListViewSubItem" /> that was added to the collection.</returns>
        public VisualListViewSubItem Add(VisualListViewSubItem item)
        {
            Insert(-1, item);
            return item;
        }

        /// <summary>
        ///     Adds a subitem to the collection with the specified text, foreground color, background color, and font
        ///     settings.
        /// </summary>
        /// <param name="text">The text to display for the subitem.</param>
        /// <param name="foreColor">A <see cref="Color" /> that represents the foreground color of the subitem.</param>
        /// <param name="backColor">A <see cref="Color" /> that represents the background color of the subitem.</param>
        /// <param name="font">A <see cref="Font" /> that represents the typeface to display the subitem's text in.</param>
        /// <returns>The <see cref="VisualListViewSubItem" /> that was added to the collection.</returns>
        public VisualListViewSubItem Add(string text, Color foreColor, Color backColor, Font font)
        {
            VisualListViewSubItem _item = new VisualListViewSubItem(_owner, text, foreColor, backColor, font);
            Add(_item);
            return _item;
        }

        /// <summary>Adds an array of <see cref="VisualListViewSubItem" /> objects to the collection.</summary>
        /// <param name="items">An array of <see cref="VisualListViewSubItem" /> objects to add to the collection.</param>
        public void AddRange(VisualListViewSubItem[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach (VisualListViewSubItem _item in items)
            {
                Add(_item);
            }
        }

        /// <summary>
        ///     Creates new subitems based on an array and adds them to the collection with specified foreground color,
        ///     background color, and font.
        /// </summary>
        /// <param name="items">An array of string representing the text of each subitem to add to the collection.</param>
        /// <param name="foreColor">A <see cref="Color" /> that represents the foreground color of the subitem.</param>
        /// <param name="backColor">A <see cref="Color" /> that represents the background color of the subitem.</param>
        /// <param name="font">A <see cref="Font" /> that represents the typeface to display the subitem's text in.</param>
        public void AddRange(string[] items, Color foreColor, Color backColor, Font font)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            VisualListViewSubItem[] _items = { };

            for (var i = 0; i < items.Length; i++)
            {
                _items[i].Text = items[i];
                _items[i].ForeColor = foreColor;
                _items[i].BackColor = backColor;
                _items[i].Font = font;
            }

            AddRange(_items);
        }

        /// <summary>Creates new subitems based on an array and adds them to the collection.</summary>
        /// <param name="items">An array of string representing the text of each subitem to add to the collection.</param>
        public void AddRange(string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            VisualListViewSubItem[] _items = { };

            for (var i = 0; i < items.Length; i++)
            {
                _items[i].Text = items[i];
            }

            AddRange(_items);
        }

        /// <summary>Clears all selection bits in the item structure.</summary>
        /// <param name="itemIgnore">This overload is an optimization to stop a redraw on a re-selection.</param>
        public void ClearSelection(VisualListViewSubItem itemIgnore)
        {
            for (var index = 0; index < List.Count; index++)
            {
                VisualListViewSubItem _item = this[index];
                if (_item != itemIgnore)
                {
                    _item.Selected = false;
                }
            }
        }

        /// <summary>Clears all selection bits in the item structure.</summary>
        public void ClearSelection()
        {
            for (var index = 0; index < List.Count; index++)
            {
                this[index].Selected = false;
            }
        }

        /// <summary>Creates a shallow copy of the current object.</summary>
        /// <returns>The <see cref="object" />.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>Determines whether the specified item is located in the collection.</summary>
        /// <param name="value">A <see cref="VisualListViewSubItem" /> representing the item to locate in the collection.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public bool Contains(VisualListViewSubItem value)
        {
            if (value == null)
            {
                return false;
            }

            return List.Contains(value);
        }

        /// <summary>Determines whether the collection contains an item with the specified key.</summary>
        /// <param name="key">The name of the item to search for.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public bool Contains(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            return List.Cast<VisualListViewSubItem>().Any(_item => _item.Name == key);
        }

        /// <summary>Return the index within the collection of the specified item.</summary>
        /// <param name="subItem">A <see cref="VisualListViewSubItem" /> representing the item to locate in the collection.</param>
        /// <returns>
        ///     The zero-based index of the subitem's location in the collection. if the subitems is not located in the
        ///     collection, the return value is negative one(-1).
        /// </returns>
        public int IndexOf(VisualListViewSubItem subItem)
        {
            for (var index = 0; index < Count; index++)
            {
                if (List[index] == subItem)
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>Retrieves the index of the item with the specified key.</summary>
        /// <param name="key">The name of the item to find in the collection.</param>
        /// <returns>The <see cref="int" />.</returns>
        public virtual int IndexOfKey(string key)
        {
            // Step 0 - Argument validation.
            if (string.IsNullOrEmpty(key))
            {
                return -1;
            }

            // Step 1 - Check the last cached item.
            if (List.IsValidIndex(_lastAccessedIndex))
            {
                if (TextManager.SafeCompareStrings(this[_lastAccessedIndex].Name, key, true))
                {
                    return _lastAccessedIndex;
                }
            }

            // Step 2 - Search for the item.
            for (var i = 0; i < List.Count; i++)
            {
                if (TextManager.SafeCompareStrings(this[i].Name, key, true))
                {
                    _lastAccessedIndex = i;
                    return i;
                }
            }

            _lastAccessedIndex = -1;
            return -1;
        }

        /// <summary>Creates a new item and inserts it into the collection at the specified index.</summary>
        /// <param name="index">The zero-based index location where the item is inserted.</param>
        /// <param name="text">The text to display for the item.</param>
        /// <returns>The <see cref="VisualListViewSubItem" />.</returns>
        public VisualListViewSubItem Insert(int index, string text)
        {
            VisualListViewSubItem _item = new VisualListViewSubItem
                    {
                       Text = text 
                    };

            return Insert(index, _item);
        }

        /// <summary>Inserts a subitem into the collection at the specified index.</summary>
        /// <param name="index">The zero-based index location where the item is inserted.</param>
        /// <param name="item">A <see cref="VisualListViewSubItem" /> representing the subitem to insert into the collection.</param>
        /// <returns>The <see cref="VisualListViewSubItem" />.</returns>
        public VisualListViewSubItem Insert(int index, VisualListViewSubItem item)
        {
            item.ListView = _listView;
            item.ChangedEvent += SubItem_Changed;

            if (index < 0)
            {
                List.Add(item);
            }
            else
            {
                List.Insert(index, item);
            }

            ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.SubItemCollectionChanged, null, null, null));
            return item;
        }

        /// <summary>Removes the specified item from the collection.</summary>
        /// <param name="item">The <see cref="VisualListViewSubItem" /> representing the item to remove from the collection.</param>
        public virtual void Remove(VisualListViewSubItem item)
        {
            RemoveByKey(item.Name);
        }

        /// <summary>Removes the item at the specified index within the collection.</summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public new virtual void RemoveAt(int index)
        {
            if (List.IsValidIndex(index))
            {
                List.RemoveAt(index);
                ChangedEvent?.Invoke(this, new ListViewChangedEventArgs(ListViewChangedTypes.SubItemCollectionChanged, null, null, null));
            }
        }

        /// <summary>Removes the item with the specified key from the collection.</summary>
        /// <param name="key">The name of the item to remove from the collection.</param>
        public virtual void RemoveByKey(string key)
        {
            int _index = IndexOfKey(key);
            if (List.IsValidIndex(_index))
            {
                RemoveAt(_index);
            }
        }

        /// <summary>The sub item has changed.</summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The event args.</param>
        public void SubItem_Changed(object source, ListViewChangedEventArgs e)
        {
            DebugTraceManager.WriteDebug("VisualListViewSubItemCollection::SubItem_Changed", DebugTraceManager.DebugOutput.TraceListener);
            ChangedEvent?.Invoke(source, e);
        }

        #endregion
    }
}