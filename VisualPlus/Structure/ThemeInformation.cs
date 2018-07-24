#region Namespace

using System.ComponentModel;

#endregion

namespace VisualPlus.Structure
{
    public class ThemeInformation
    {
        #region Properties

        public string Author { get; set; }

        /// <summary>Determines if the <see cref="ThemeInformation" /> is null.</summary>
        [Browsable(false)]
        public bool IsNull
        {
            get
            {
                return (Author == null) || (Name == null);
            }
        }

        public string Name { get; set; }

        #endregion
    }
}