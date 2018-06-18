#region Namespace

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;

using VisualPlus.Collections.CollectionBase;
using VisualPlus.Collections.CollectionsEditor;
using VisualPlus.Localization;
using VisualPlus.Toolkit.Controls.DataManagement;

#endregion

namespace VisualPlus.ActionList
{
    internal class VisualListViewAdvActionList : DesignerActionList
    {
        #region Variables

        private VisualListViewEx _control;
        private DesignerActionUIService _designerService;

        private bool _dockState;
        private string _dockText;

        #endregion

        #region Constructors

        public VisualListViewAdvActionList(IComponent component) : base(component)
        {
            _control = (VisualListViewEx)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));

            _dockText = "Dock in Parent Container.";
            _dockState = false;
        }

        #endregion

        #region Properties

        [Category(PropertyCategory.Data)]
        [Description("The items in the VisualListView.")]
        [Editor(typeof(VisualListViewItemCollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public virtual VisualListViewItemCollection Items
        {
            get
            {
                return _control.Items;
            }
        }

        #endregion

        #region Overrides

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
                {
                    new DesignerActionPropertyItem("Items", "Edit Items...")

                    // new DesignerActionPropertyItem("Columns", "Edit Columns..."),
                    // new DesignerActionPropertyItem("Groups", "Edit Groups..."),
                    // new DesignerActionPropertyItem("View", "View:"),
                    // new DesignerActionMethodItem(this, "DockContainer", _dockText)
                };

            return items;
        }

        #endregion

        #region Methods

        public void DockContainer()
        {
            if (!_dockState)
            {
                _control.Dock = DockStyle.None;
                _dockText = ContainerText.Docked;
                _dockState = true;
            }
            else
            {
                _control.Dock = DockStyle.Fill;
                _dockText = ContainerText.Undock;
                _dockState = false;
            }

            _designerService.Refresh(_control);
        }

        private struct ContainerText
        {
            public const string Docked = "Dock in Parent Container";
            public const string Undock = "Undock in Parent Container.";
        }

        #endregion
    }
}