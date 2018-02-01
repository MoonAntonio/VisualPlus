namespace VisualPlus.Collections
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    #endregion

    public class ReadOnlyControlCollection : VisualControlCollection
    {
        #region Variables

        private bool _allowRemove;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ReadOnlyControlCollection" /> class.</summary>
        public ReadOnlyControlCollection(Control owner) : base(owner)
        {
            _allowRemove = false;
        }

        #endregion

        #region Properties

        /// <summary>Clear out all the entries in the collection.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowRemoveInternal
        {
            get
            {
                return _allowRemove;
            }

            set
            {
                _allowRemove = value;
            }
        }

        #endregion

        #region Events

        /// <summary>Adds the specified control to the control collection.</summary>
        /// <param name="control">The control.</param>
        public override void Add(Control control)
        {
            if (AllowRemoveInternal)
            {
                base.Add(control);
            }
            else
            {
                throw new NotSupportedException("ReadOnly controls collection");
            }
        }

        /// <summary>Adds an array of control objects to the collection.</summary>
        /// <param name="controls">An array of Control objects to add to the collection.</param>
        public override void AddRange(Control[] controls)
        {
            if (AllowRemoveInternal)
            {
                base.AddRange(controls);
            }
            else
            {
                throw new NotSupportedException("ReadOnly controls collection");
            }
        }

        /// <summary>Removes all controls from the collection.</summary>
        public override void Clear()
        {
            if (AllowRemoveInternal)
            {
                base.Clear();
            }
            else
            {
                if (Count > 0)
                {
                    throw new NotSupportedException("ReadOnly controls collection");
                }
            }
        }

        /// <summary>Removes the specified control from the control collection.</summary>
        /// <param name="control">The control.</param>
        public override void Remove(Control control)
        {
            if (AllowRemoveInternal)
            {
                base.Remove(control);
            }
            else
            {
                if (Contains(control))
                {
                    throw new NotSupportedException("ReadOnly controls collection");
                }
            }
        }

        /// <summary>Removes the child control with the specified key.</summary>
        /// <param name="key">The name of the child control to remove.</param>
        public override void RemoveByKey(string key)
        {
            if (AllowRemoveInternal)
            {
                base.RemoveByKey(key);
            }
            else
            {
                if (ContainsKey(key))
                {
                    throw new NotSupportedException("ReadOnly controls collection");
                }
            }
        }

        #endregion
    }
}