#region Namespace

using System;
using System.ComponentModel;
using System.ComponentModel.Design;

using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Controls.DataManagement;

#endregion

namespace VisualPlus.Collections.CollectionsEditor
{
    internal class VisualListViewSubItemCollectionEditor : CollectionEditor
    {
        #region Variables

        private int _uniqueID = 1;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewSubItemCollectionEditor" /> class.</summary>
        /// <param name="type">The type.</param>
        public VisualListViewSubItemCollectionEditor(Type type) : base(type)
        {
        }

        #endregion

        #region Overrides

        protected override Type CreateCollectionItemType()
        {
            return typeof(VisualListViewSubItem);
        }

        protected override object CreateInstance(Type itemType)
        {
            object[] _subItems;
            string _subItemName;

            do
            {
                _subItemName = itemType.Name + _uniqueID;
                _subItems = GetItems(_subItemName);
                _uniqueID++;
            }
            while (_subItems.Length != 0);

            object _subItem = base.CreateInstance(itemType);

            ((VisualListViewSubItem)_subItem).Name = _subItemName;
            ((VisualListViewSubItem)_subItem).Text = _subItemName;

            return _subItem;
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(VisualListViewSubItem) };
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