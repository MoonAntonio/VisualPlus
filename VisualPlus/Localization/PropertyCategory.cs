namespace VisualPlus.Localization
{
    public sealed class PropertyCategory
    {
#if DEBUG
        public const string Accessibility = Settings.DefaultCategoryText;
        public const string Appearance = Settings.DefaultCategoryText;
        public const string Behavior = Settings.DefaultCategoryText;
        public const string Data = Settings.DefaultCategoryText;
        public const string Design = Settings.DefaultCategoryText;
        public const string Focus = Settings.DefaultCategoryText;
        public const string Layout = Settings.DefaultCategoryText;
        public const string WindowStyle = Settings.DefaultCategoryText;

#else
            public const string Accessibility = "Accessibility";
            public const string Appearance = "Appearance";
            public const string Behavior = "Behavior";
            public const string Layout = "Layout";
            public const string Data = "Data";
            public const string Design = "Design";
            public const string Focus = "Focus";
            public const string WindowStyle = "Window style";
#endif
    }
}