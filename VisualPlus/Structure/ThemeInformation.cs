#region Namespace

using System.ComponentModel;

#endregion

namespace VisualPlus.Structure
{
    public class ThemeInformation
    {
        #region Properties

        public string Author { get; set; }

        /// <summary>Determines if the theme information is empty.</summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return (Author == null) && (Name == null);
            }
        }

        public string Name { get; set; }

        #endregion
    }
}