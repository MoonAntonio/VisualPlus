#region Namespace

using System;
using System.Diagnostics;

using VisualPlus.Collections.CollectionBase;
using VisualPlus.Enumerators;
using VisualPlus.Toolkit.Child;

#endregion

namespace VisualPlus.Toolkit.Controls.DataManagement.ListViewComponents
{
    internal class LVQuickSort
    {
        #region Variables

        private bool _numericCompare;
        private int _sortColumn;
        private SortDirections _sortDirection;
        private bool _stopRequested;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="LVQuickSort" /> class.</summary>
        public LVQuickSort()
        {
            _numericCompare = false;
            _stopRequested = false;
            _sortColumn = 0;
            _sortDirection = SortDirections.Descending;
        }

        #endregion

        #region Properties

        /// <summary>Compare only numeric values in items. Warning - This can end up slowing down process.</summary>
        public bool NumericCompare
        {
            get
            {
                return _numericCompare;
            }

            set
            {
                _numericCompare = value;
            }
        }

        /// <summary>Column within the items structure to sort.</summary>
        public int SortColumn
        {
            get
            {
                return _sortColumn;
            }

            set
            {
                _sortColumn = value;
            }
        }

        /// <summary>Direction this sorting routine will move items.</summary>
        public SortDirections SortDirection
        {
            get
            {
                return _sortDirection;
            }

            set
            {
                _sortDirection = value;
            }
        }

        /// <summary>Stop the sort before it finishes.</summary>
        public bool StopRequested
        {
            get
            {
                return _stopRequested;
            }

            set
            {
                _stopRequested = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>The list-view insertion sort.</summary>
        /// <param name="items">The items.</param>
        /// <param name="low0">The low.</param>
        /// <param name="high0">The high.</param>
        public void LVInsertionSort(VisualListViewItemCollection items, int low0, int high0)
        {
            int w;
            VisualListViewItem _tempItem;

            for (int x = low0; x <= high0; x++)
            {
                _tempItem = items[x];
                w = x;

                while ((w > low0) && CompareItems(items[w - 1], _tempItem, CompareDirection.GreaterThan))
                {
                    items[w] = items[w - 1];
                    w--;
                }

                items[w] = _tempItem;
            }
        }

        /// <summary>Quick sort the items collection.</summary>
        /// <param name="items">The items.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public void QuickSort(VisualListViewItemCollection items, int left, int right)
        {
            int w;
            int x;

            VisualListViewItem _tempItem;
            int med = 4;

            if (right - left > med)
            {
                w = (right + left) / 2;

                if (CompareItems(items[left], items[w], CompareDirection.GreaterThan))
                {
                    Swap(items, left, w);
                }

                if (CompareItems(items[left], items[right], CompareDirection.GreaterThan))
                {
                    Swap(items, left, right);
                }

                if (CompareItems(items[w], items[right], CompareDirection.GreaterThan))
                {
                    Swap(items, w, right);
                }

                x = right - 1;
                Swap(items, w, x);
                w = left;
                _tempItem = items[x];

                while (true)
                {
                    while (CompareItems(items[++w], _tempItem, CompareDirection.LessThan))
                    {
                    }

                    while (CompareItems(items[--x], _tempItem, CompareDirection.GreaterThan))
                    {
                    }

                    if (x < w)
                    {
                        break;
                    }

                    Swap(items, w, x);

                    if (_stopRequested)
                    {
                        return;
                    }
                }

                Swap(items, w, right - 1);

                QuickSort(items, left, x);
                QuickSort(items, w + 1, right);
            }
        }

        /// <summary>Sort the items collection.</summary>
        /// <param name="items">The items.</param>
        public void Sort(VisualListViewItemCollection items)
        {
            QuickSort(items, 0, items.Count - 1);
            LVInsertionSort(items, 0, items.Count - 1);
        }

        /// <summary>Compare items.</summary>
        /// <param name="item1">Item 1.</param>
        /// <param name="item2">Item 2.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>The <see cref="bool" />.</returns>
        private bool CompareItems(VisualListViewItem item1, VisualListViewItem item2, CompareDirection direction)
        {
            bool dir = false;

            if (direction == CompareDirection.GreaterThan)
            {
                dir = true;
            }

            if (SortDirection == SortDirections.Ascending)
            {
                dir = !dir;
            }

            if (!NumericCompare)
            {
                if (dir)
                {
                    return string.Compare(item1.SubItems[SortColumn].Text, item2.SubItems[SortColumn].Text, StringComparison.Ordinal) < 0;
                }
                else
                {
                    return string.Compare(item1.SubItems[SortColumn].Text, item2.SubItems[SortColumn].Text, StringComparison.Ordinal) > 0;
                }
            }
            else
            {
                try
                {
                    double n1 = double.Parse(item1.SubItems[SortColumn].Text);
                    double n2 = double.Parse(item2.SubItems[SortColumn].Text);

                    if (dir)
                    {
                        return n1 < n2;
                    }
                    else
                    {
                        return n1 > n2;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        /// <summary>Swap items.</summary>
        /// <param name="items">The items.</param>
        /// <param name="x">The x.</param>
        /// <param name="w">The w.</param>
        private void Swap(VisualListViewItemCollection items, int x, int w)
        {
            VisualListViewItem _tempItem;
            _tempItem = items[x];
            items[x] = items[x];
            items[w] = _tempItem;
        }

        #endregion
    }
}