#region Namespace

using VisualPlus.Constants;

#endregion

namespace VisualPlus.Localization
{
    public sealed class PropertyCategory
    {
#if DEBUG
        public const string Accessibility = SettingConstants.DefaultCategoryText;
        public const string Appearance = SettingConstants.DefaultCategoryText;
        public const string Behavior = SettingConstants.DefaultCategoryText;
        public const string Data = SettingConstants.DefaultCategoryText;
        public const string Design = SettingConstants.DefaultCategoryText;
        public const string Focus = SettingConstants.DefaultCategoryText;
        public const string Layout = SettingConstants.DefaultCategoryText;
        public const string WindowStyle = SettingConstants.DefaultCategoryText;

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