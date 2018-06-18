#region Namespace

using VisualPlus.Events;

#endregion

namespace VisualPlus.Delegates
{
    public delegate void BorderColorChangedEventHandler(ColorEventArgs e);

    public delegate void BorderRoundingChangedEventHandler();

    public delegate void BorderThicknessChangedEventHandler();

    public delegate void BorderTypeChangedEventHandler();

    public delegate void BorderVisibleChangedEventHandler();

    public delegate void BorderHoverVisibleChangedEventHandler();

    public delegate void BorderHoverColorChangedEventHandler(ColorEventArgs e);
}