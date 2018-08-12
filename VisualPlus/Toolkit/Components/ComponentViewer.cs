#region Namespace

using System;
using System.ComponentModel;
using System.Windows.Forms;

using VisualPlus.Constants;
using VisualPlus.Extensibility;
using VisualPlus.Structure;
using VisualPlus.Toolkit.Controls.Editors;

#endregion

namespace VisualPlus.Toolkit.Components
{
    /// <summary>The component viewer.</summary>
    [ToolboxItem(false)]
    public partial class ComponentViewer : UserControl
    {
        #region Variables

        private Control component;
        private Type componentType;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ComponentViewer" /> class.</summary>
        /// <param name="componentNamespace">The component namespace to display.</param>
        /// <param name="theme">The theme data.</param>
        public ComponentViewer(string componentNamespace, Theme theme) : this()
        {
            CreateComponentInstance(componentNamespace);
            UpdateTheme(theme);
        }

        /// <summary>Initializes a new instance of the <see cref="ComponentViewer" /> class.</summary>
        public ComponentViewer()
        {
            InitializeComponent();
            component = null;
            componentType = null;
        }

        #endregion

        #region Overrides

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (component != null)
            {
                component.ToCenter();
            }
        }

        #endregion

        #region Methods

        /// <summary>Updates the component to the new component namespace.</summary>
        /// <param name="componentNamespace">The component namespace.</param>
        public void UpdateComponent(string componentNamespace)
        {
            CreateComponentInstance(componentNamespace);
        }

        /// <summary>Update the component theme.</summary>
        /// <param name="theme">The theme data.</param>
        public void UpdateTheme(Theme theme)
        {
            if (component is IThemeSupport supportedControl)
            {
                supportedControl.UpdateTheme(theme);
            }
        }

        /// <summary>Create component instance.</summary>
        /// <param name="componentNamespace">The component namespace.</param>
        private void CreateComponentInstance(string componentNamespace)
        {
            if (componentNamespace == null)
            {
                return;
            }

            string visualPlusEntryPoint = SettingConstants.ProductName;

            componentType = Type.GetType(string.Concat(componentNamespace, ", ", visualPlusEntryPoint));

            // TODO: Determine if component is Control or Form.
            component = (Control)Activator.CreateInstance(componentType);

            if (component is VisualDateTimePicker)
            {
                // Do nothing.
            }
            else
            {
                component.Text = @"VisualPlus";
            }

            component.BackColor = BackColor;

            Controls.Clear();
            Controls.Add(component);

            component.ToCenter();
        }

        #endregion
    }
}