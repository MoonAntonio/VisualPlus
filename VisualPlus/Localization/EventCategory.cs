#region Namespace

using VisualPlus.Constants;

#endregion

namespace VisualPlus.Localization
{
    public sealed class EventCategory
    {
#if DEBUG
        public const string Action = SettingConstants.DefaultCategoryText;
        public const string Appearance = SettingConstants.DefaultCategoryText;
        public const string Behavior = SettingConstants.DefaultCategoryText;
        public const string Data = SettingConstants.DefaultCategoryText;
        public const string DragDrop = SettingConstants.DefaultCategoryText;
        public const string Focus = SettingConstants.DefaultCategoryText;
        public const string Key = SettingConstants.DefaultCategoryText;
        public const string Layout = SettingConstants.DefaultCategoryText;
        public const string Misc = SettingConstants.DefaultCategoryText;
        public const string Mouse = SettingConstants.DefaultCategoryText;
        public const string PropertyChanged = SettingConstants.DefaultCategoryText;
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