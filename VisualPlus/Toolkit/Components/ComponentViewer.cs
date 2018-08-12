#region Namespace

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Constants;
using VisualPlus.Delegates;
using VisualPlus.Events;
using VisualPlus.Extensibility;
using VisualPlus.Structure;
using VisualPlus.Toolkit.Controls.Editors;

#endregion

namespace VisualPlus.Toolkit.Components
{
    /// <summary>The component viewer.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ThemeChanged")]
    [DefaultProperty("Theme")]
    [Description("The Component Viewer")]
    [ToolboxItem(false)]
    public partial class ComponentViewer : UserControl
    {
        #region Variables

        private Control component;
        private string componentNamespace;
        private Type componentType;
        private Theme theme;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ComponentViewer" /> class.</summary>
        /// <param name="typeNamespace">The component type namespace to display.</param>
        public ComponentViewer(string typeNamespace) : this()
        {
            componentNamespace = typeNamespace;
            ComponentNamespace = componentNamespace;
        }

        /// <summary>Initializes a new instance of the <see cref="ComponentViewer" /> class.</summary>
        public ComponentViewer()
        {
            InitializeComponent();
            component = null;
            componentNamespace = string.Empty;
            componentType = null;
            theme = new Theme(Settings.DefaultValue.DefaultStyle);
        }

        #endregion

        #region Events

        [Description("Occurs when the component has changed.")]
        public event ControlEventHandler ComponentChanged;

        [Description("Occurs when the theme has changed.")]
        public event ThemeChangedEventHandler ThemeChanged;

        #endregion

        #region Properties

        /// <summary>The <see cref="Component" /> namespace to use for the viewer.</summary>
        [Browsable(true)]
        public string ComponentNamespace
        {
            get
            {
                return componentType.Namespace;
            }

            set
            {
                componentNamespace = value;
                OnComponentChanged(new ControlEventArgs(component));
            }
        }

        /// <summary>The <see cref="Theme" /> to use for the <see cref="Component" />.</summary>
        [Browsable(true)]
        public Theme Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
                OnThemeChanged(new ThemeEventArgs(theme));
            }
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

        /// <summary>Occurs when the component changed.</summary>
        /// <param name="e">The event args.</param>
        protected virtual void OnComponentChanged(ControlEventArgs e)
        {
            CreateComponentInstance();
            ApplyTheme();
            ComponentChanged?.Invoke(this, e);
        }

        /// <summary>Occurs when the theme changed.</summary>
        /// <param name="e">The event args.</param>
        protected virtual void OnThemeChanged(ThemeEventArgs e)
        {
            ApplyTheme();
            ThemeChanged?.Invoke(e);
        }

        #endregion

        #region Methods

        /// <summary>Applies the theme to the <see cref="Component" />.</summary>
        private void ApplyTheme()
        {
            if (component is IThemeSupport supportedControl)
            {
                supportedControl.UpdateTheme(theme);
                component.BackColor = BackColor;
            }
        }

        /// <summary>Create component instance.</summary>
        private void CreateComponentInstance()
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

            Controls.Clear();
            Controls.Add(component);

            component.ToCenter();
        }

        #endregion
    }
}