#region Namespace

using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

using VisualPlus.ActionList;

#endregion

namespace VisualPlus.Designer
{
    internal class VisualListViewDesigner : ControlDesigner
    {
        #region Variables

        private DesignerActionListCollection _actionListCollection;
        private IDesignerHost _designerHost;

        #endregion

        #region Properties

        /// <summary>Gets the design-time action lists supported by the component associated with the designer.</summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionListCollection == null)
                {
                    _actionListCollection = new DesignerActionListCollection
                            {
                               new VisualListViewActionList(Component) 
                            };
                }

                return _actionListCollection;
            }
        }

        /// <summary>Provides an interface for managing designer transactions and components.</summary>
        public IDesignerHost DesignerHost
        {
            get
            {
                if (_designerHost == null)
                {
                    _designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                }

                return _designerHost;
            }
        }

        #endregion

        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("TextImageRelation");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("UseVisualStyleBackColor");
            properties.Remove("RightToLeft");
            properties.Remove("View");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}