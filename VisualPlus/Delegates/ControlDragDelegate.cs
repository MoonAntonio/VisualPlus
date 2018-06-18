#region Namespace

using VisualPlus.Events;

#endregion

namespace VisualPlus.Delegates
{
    public delegate void ControlDragEventHandler(DragControlEventArgs e);

    public delegate void ControlDragToggleEventHandler(ToggleEventArgs e);

    public delegate void ControlDragCursorChangedEventHandler(CursorChangedEventArgs e);
}