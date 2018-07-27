#region Namespace

using System;

#endregion

namespace VisualPlus.Attributes
{
    /// <summary>Marks the program elements that need to be tested further.</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class Test : Attribute
    {
        #region Variables

        private string text;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Test" /> class.</summary>
        /// <param name="text">The text.</param>
        public Test(string text)
        {
            Text = text;
        }

        /// <summary>Initializes a new instance of the <see cref="Test" /> class.</summary>
        public Test()
        {
            text = string.Empty;
        }

        #endregion

        #region Properties

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        #endregion
    }
}