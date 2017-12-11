namespace VisualPlus
{
    #region Namespace

    using System.ComponentModel;
    using System.Drawing;

<<<<<<< HEAD
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
    using VisualPlus.Structure;
=======
    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Localization.Descriptions;
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    using VisualPlus.Toolkit.Components;

    #endregion

    public interface IThemeSupport
    {
        #region Events

        /// <summary>Updates the control theme.</summary>
        /// <param name="style">The style to update the control with.</param>
        void UpdateTheme(Enumerators.Styles style);

        #endregion
    }

    /// <summary>Exposes access to content values.</summary>
    public interface IContentValues
    {
        #region Events

        /// <summary>Gets the content long text.</summary>
        /// <returns>String value.</returns>
        string GetLongText();

        /// <summary>Gets the content short text.</summary>
        /// <returns>String value.</returns>
        string GetShortText();

        #endregion
    }

    public interface IInputMethods
    {
        #region Events

        void AppendText(string text);

        void Clear();

        void ClearUndo();

        void Copy();

        void Cut();

        void DeselectAll();

        int GetCharFromPosition(Point pt);

        int GetCharIndexFromPosition(Point pt);

        int GetFirstCharIndexFromLine(int lineNumber);

        int GetLineFromCharIndex(int index);

        Point GetPositionFromCharIndex(int index);

        void Paste();

        void ScrollToCaret();

        void Select(int start, int length);

        void SelectAll();

        void Undo();

        #endregion
    }

    public interface IControlStyle
    {
        #region Properties

        VisualStyleManager StyleManager { get; set; }

        #endregion
    }

    public interface IAnimationSupport
    {
        #region Properties

        [DefaultValue(Settings.DefaultValue.Animation)]
        [Category(Propertys.Behavior)]
        [Description(Property.Animation)]
        bool Animation { get; set; }

        #endregion

        #region Events

        /// <summary>Configures the animation settings.</summary>
<<<<<<< HEAD
        void ConfigureAnimation();
=======
        /// <param name="effectIncrement">The effect Increment.</param>
        /// <param name="effectType">The effect Type.</param>
        void ConfigureAnimation(double[] effectIncrement, EffectType[] effectType);
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3

        /// <summary>Draws the animation on the graphics.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        void DrawAnimation(Graphics graphics);

        #endregion
    }

    public interface IControlStateColor
    {
        #region Properties

        Color Background { get; set; }

        Color BackgroundDisabled { get; set; }

        Color BackgroundHover { get; set; }

        Color BackgroundPressed { get; set; }

        #endregion
    }

<<<<<<< HEAD
    public interface IControlState
    {
        #region Properties

        Gradient DisabledGradient { get; }

        Gradient EnabledGradient { get; }

        #endregion
    }

    public interface IControlStates : IControlState
    {
        #region Properties

        Gradient HoverGradient { get; }

        Gradient PressedGradient { get; }

        #endregion
    }

=======
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    public interface IImageControl
    {
        #region Properties

        Image Hover { get; set; }

        Image Normal { get; set; }

        Image Pressed { get; set; }

        #endregion
    }
}