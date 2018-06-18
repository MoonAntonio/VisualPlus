#region Namespace

using System.ComponentModel;
using System.Diagnostics;

#endregion

namespace VisualPlus.Structure
{
    /// <summary>Contains the global identifier for the object.</summary>
    public class GlobalId
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="GlobalId" /> class.</summary>
        [DebuggerStepThrough]
        public GlobalId()
        {
            Id = NextId;
        }

        #endregion

        #region Properties

        /// <summary>Gets the unique identifier of the object.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id { get; }

        /// <summary>Gets the next global identifier in sequence.</summary>
        public static int NextId
        {
            [DebuggerStepThrough]
            get
            {
                return _nextId++;
            }
        }

        #endregion

        #region Methods

        private static int _nextId = 1000;

        #endregion
    }
}