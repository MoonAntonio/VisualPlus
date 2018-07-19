#region Namespace

using VisualPlus.Toolkit.Child;

#endregion

namespace VisualPlus.Toolkit.Controls.DataManagement.ListViewComponents
{
    public interface ILVEmbeddedControl
    {
        #region Properties

        VisualListViewItem Item { get; set; }

        VisualListView ListView { get; set; }

        VisualListViewSubItem SubItem { get; set; }

        #endregion

        #region Methods

        /// <summary>Populate the control with settings.</summary>
        /// <param name="item">The item.</param>
        /// <param name="subItem">The sub item.</param>
        /// <param name="listView">The list view.</param>
        /// <returns>The <see cref="bool" />.</returns>
        bool LVEmbeddedControlLoad(VisualListViewItem item, VisualListViewSubItem subItem, VisualListView listView);

        /// <summary>The return text string.</summary>
        /// <returns>The <see cref="string" />.</returns>
        string LVEmbeddedControlReturnText();

        /// <summary>Unload the control.</summary>
        void LVEmbeddedControlUnload();

        #endregion
    }
}