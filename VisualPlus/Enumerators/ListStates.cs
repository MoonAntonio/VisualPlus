namespace VisualPlus.Enumerators
{
    public enum ListStates
    {
        /// <summary>List-view is in normal state.</summary>
        None,

        /// <summary>An item is selected in list-view.</summary>
        Selecting,

        /// <summary>A column is selected in list-view.</summary>
        ColumnSelect,

        /// <summary>A column is being selected in list-view.</summary>
        ColumnResizing
    }
}