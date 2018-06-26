#region Namespace

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

using VisualPlus.Collections.CollectionsBase;
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
            _dockState = false;
            _dockText = ContainerText.Dock;
        }

        #endregion

        #region Properties

        // FIX: Editor is causing drop-down error. Removing it prevents the columns from being filled with default data.
        // [Editor(typeof(VisualListViewColumnCollectionEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public VisualListViewColumnCollection Columns
        {
            get
            {
                return _control.Columns;
            }
        }

        // FIX: Editor is causing drop-down error. Removing it prevents the columns from being filled with default data.
        // [Editor(typeof(VisualListViewItemCollectionEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public VisualListViewItemCollection Items
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
                    new DesignerActionPropertyItem("Items", "Edit Items..."),
                    new DesignerActionPropertyItem("Columns", "Edit Columns..."),
                    
                    // new DesignerActionPropertyItem("Groups", "Edit Groups..."),
                    new DesignerActionMethodItem(this, "DockContainer", _dockText)
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
                _dockText = ContainerText.Dock;
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
            public const string Dock = "Dock in Parent Container.";
            public const string Undock = "Undock in Parent Container.";
        }

        #endregion
    }
}