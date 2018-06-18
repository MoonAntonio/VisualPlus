#region Namespace

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace VisualPlus.Collections.ControlCollection
{
    /// <summary>The base class for specific control collections.</summary>
    public class VisualControlCollection : Control.ControlCollection
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualControlCollection" /> class.</summary>
        /// <param name="owner">The owner.</param>
        public VisualControlCollection(Control owner) : base(owner)
        {
        }

        #endregion

        #region Methods

        /// <summary>Add a control to the collection.</summary>
        /// <param name="control">The control.</param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddInternal(Control control)
        {
            Add(control);
        }

        /// <summary>Clear the collection.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearInternal()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                RemoveInternal(this[i]);
            }
        }

        /// <summary>Remove a control from the collection.</summary>
        /// <param name="control">The control.</param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveInternal(Control control)
        {
            Remove(control);
        }

        #endregion
    }
}