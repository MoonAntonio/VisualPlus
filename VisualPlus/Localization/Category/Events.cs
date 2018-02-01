namespace VisualPlus.Localization.Category
{
    public sealed class Events
    {
#if DEBUG
        public const string Action = Settings.DefaultCategoryText;
        public const string Appearance = Settings.DefaultCategoryText;
        public const string Behavior = Settings.DefaultCategoryText;
        public const string Data = Settings.DefaultCategoryText;
        public const string DragDrop = Settings.DefaultCategoryText;
        public const string Focus = Settings.DefaultCategoryText;
        public const string Key = Settings.DefaultCategoryText;
        public const string Layout = Settings.DefaultCategoryText;
        public const string Misc = Settings.DefaultCategoryText;
        public const string Mouse = Settings.DefaultCategoryText;
        public const string PropertyChanged = Settings.DefaultCategoryText;
#else
            public const string Action = "Action";
            public const string Appearance = "Appearance";
            public const string Behavior = "Behavior";
            public const string Data = "Data";
            public const string DragDrop = "Drag Drop";
            public const string Focus = "Focus";
            public const string Key = "Key";
            public const string Layout = "Layout";
            public const string Misc = "Misc";
            public const string Mouse = "Mouse";
            public const string PropertyChanged = "Property Changed";
#endif
    }
}