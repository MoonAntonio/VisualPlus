#region Namespace

using System;
using System.ComponentModel;
using System.ComponentModel.Design;

using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Controls.DataManagement;

#endregion

namespace VisualPlus.Collections.CollectionsEditor
{
    internal class VisualListViewColumnCollectionEditor : CollectionEditor
    {
        #region Variables

        private int _uniqueID = 1;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualListViewColumnCollectionEditor" /> class.</summary>
        /// <param name="type">The type.</param>
        public VisualListViewColumnCollectionEditor(Type type) : base(type)
        {
        }

        #endregion

        #region Overrides

        protected override Type CreateCollectionItemType()
        {
            return typeof(VisualListViewColumn);
        }

        protected override object CreateInstance(Type itemType)
        {
            object[] _columns;
            string _columnName;

            do
            {
                _columnName = itemType.Name + _uniqueID;
                _columns = GetItems(_columnName);
                _uniqueID++;
            }
            while (_columns.Length != 0);

            object _column = base.CreateInstance(itemType);

            ((VisualListViewColumn)_column).Name = _columnName;
            ((VisualListViewColumn)_column).Text = _columnName;

            return _column;
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(VisualListViewColumn) };
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
        {
            VisualListView originalControl = (VisualListView)context.Instance;

            object returnObject = base.EditValue(context, isp, value);

            originalControl.Refresh();
            return returnObject;
        }

        #endregion
    }
}