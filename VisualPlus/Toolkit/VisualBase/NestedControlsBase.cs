namespace VisualPlus.Toolkit.VisualBase
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
<<<<<<< HEAD
=======
    using VisualPlus.Managers;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Structure;

    #endregion

    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public abstract class NestedControlsBase : ContainedControlBase
    {
        #region Variables

        private ColorState _colorState;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="NestedControlsBase" /> class.</summary>
        protected NestedControlsBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
<<<<<<< HEAD

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            _colorState = new ColorState();
        }

        #endregion

        #region Properties

        [TypeConverter(typeof(ColorStateConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState BackColorState
        {
            get
            {
                return _colorState;
            }

            set
            {
                if (value == _colorState)
                {
                    return;
                }

                _colorState = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
<<<<<<< HEAD
            GDI.ApplyContainerBackColorChange(this, BackColorState.Enabled);
=======
            GraphicsManager.ApplyContainerBackColorChange(this, BackColorState.Enabled);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
<<<<<<< HEAD
            GDI.SetControlBackColor(e.Control, BackColorState.Enabled, false);
=======
            GraphicsManager.SetControlBackColor(e.Control, BackColorState.Enabled, false);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
<<<<<<< HEAD
            GDI.SetControlBackColor(e.Control, Parent.BackColor, true);
=======
            GraphicsManager.SetControlBackColor(e.Control, Parent.BackColor, true);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            MouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = MouseStates.Normal;
            Invalidate();
        }

        #endregion
    }
}