namespace VisualPlus.Extensibility
{
    #region Namespace

    using System.Collections;

    #endregion

    public static class ListExtension
    {
        #region Methods

        /// <summary>Retrieve the next ID from the <see cref="IList" />.</summary>
        /// <param name="list">The list.</param>
        /// <returns>The <see cref="int" />.</returns>
        public static int GetNextID(this IList list)
        {
            return list.Count + 1;
        }

        /// <summary>Determines if the index is valid for the collection..</summary>
        /// <param name="list">The list.</param>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool IsValidIndex(this IList list, int index)
        {
            return (index >= 0) && (index < list.Count);
        }

        #endregion
    }
}