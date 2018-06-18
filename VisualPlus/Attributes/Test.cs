#region Namespace

using System;

#endregion

namespace VisualPlus.Attributes
{
    /// <summary>Marks the program elements that need to be tested further.</summary>
    public class Test : Attribute
    {
        #region Properties

        public object Tag { get; set; }

        #endregion
    }
}