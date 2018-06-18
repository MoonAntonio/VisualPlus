#region Namespace

using System;
using System.ComponentModel;
using System.ComponentModel.Design;

using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Controls.DataManagement;

#endregion

namespace VisualPlus.Collections.CollectionsEditor
{
    internal class VisualListViewItemCollectionEditor : CollectionEditor
    {
        #region Variables

        private int _uniqueID = 1;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewItemCollectionEditor" /> class.</summary>
        /// <param name="type">The type.</param>
        public VisualListViewItemCollectionEditor(Type type) : base(type)
        {
        }

        #endregion

        #region Overrides

        protected override object CreateInstance(Type itemType)
        {
            object[] _items;
            string _itemName;

            do
            {
                _itemName = itemType.Name + _uniqueID;
                _items = GetItems(_itemName);
                _uniqueID++;
            }
            while (_items.Length != 0);

            object _item = base.CreateInstance(itemType);

            ((VisualListViewItem)_item).Name = _itemName;
            ((VisualListViewItem)_item).Text = _itemName;

            return _item;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
        {
            VisualListViewEx originalControl = (VisualListViewEx)context.Instance;

            object returnObject = base.EditValue(context, isp, value);

            originalControl.Refresh();
            return returnObject;
        }

        #endregion
    }
}