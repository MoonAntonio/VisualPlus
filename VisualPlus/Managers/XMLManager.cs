#region Namespace

using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using VisualPlus.Constants;
using VisualPlus.Enumerators;
using VisualPlus.Extensibility;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Managers
{
    public class XMLManager
    {
        #region Methods

        /// <summary>Deserialize a internal theme from resources.</summary>
        /// <param name="themes">The internal themes.</param>
        /// <returns>The <see cref="Theme" />.</returns>
        public static Theme DeserializeTheme(Themes themes)
        {
            Theme _theme = null;

            try
            {
                string rawThemeResource = ResourcesManager.ReadResource(Assembly.GetExecutingAssembly().Location, $"{SettingConstants.ThemeResourceLocation}{themes.ToString()}.xml");
                XDocument resourceDocumentTheme = XDocument.Parse(rawThemeResource);
                _theme = Deserialize(resourceDocumentTheme);
            }
            catch (Exception e)
            {
                ConsoleEx.WriteDebug(e);
            }

            return _theme;
        }

        /// <summary>Deserialize the theme from a file path.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The <see cref="Theme" />.</returns>
        public static Theme DeserializeTheme(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new NoNullAllowedException(ExceptionMessenger.IsNullOrEmpty(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(ExceptionMessenger.FileNotFound(filePath));
            }

            Theme _theme = null;

            try
            {
                XDocument themeDocument = XDocument.Load(filePath);
                _theme = Deserialize(themeDocument);
            }
            catch (Exception e)
            {
                ConsoleEx.WriteDebug(e);
            }

            return _theme;
        }

        /// <summary>Serialize the theme to a raw string.</summary>
        /// <param name="themeInformation">The theme information.</param>
        /// <param name="colorPalette">The color Palette.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string SerializeTheme(ThemeInformation themeInformation, ColorPalette colorPalette)
        {
            return Serialize(themeInformation, colorPalette);
        }

        /// <summary>Deserialize the theme contents.</summary>
        /// <param name="themeDocument">The theme document.</param>
        /// <returns>The <see cref="Theme" />.</returns>
        private static Theme Deserialize(XContainer themeDocument)
        {
            const string Header = @"VisualPlus-Theme/";
            const string Information = Header + @"Information/";
            const string StyleTable = Header + @"StyleTable/";
            const string Shared = StyleTable + @"Shared/";
            const string Toolkit = StyleTable + @"Toolkit/";

            ThemeInformation themeInformation = new ThemeInformation();
            ColorPalette colorPalette = new ColorPalette
                {
                    HelpButtonBack = new ControlColorState(),
                    HelpButtonFore = new ControlColorState(),
                    MinimizeButtonBack = new ControlColorState(),
                    MinimizeButtonFore = new ControlColorState(),
                    MaximizeButtonBack = new ControlColorState(),
                    MaximizeButtonFore = new ControlColorState(),
                    CloseButtonBack = new ControlColorState(),
                    CloseButtonFore = new ControlColorState(),
                    ScrollBar = new ColorState(),
                    ScrollButton = new ControlColorState(),
                    ScrollThumb = new ControlColorState()
                };

            // TODO: Decompose body to simplify.
            try
            {
                themeInformation.Name = themeDocument.GetValue(Information + "Name");
                themeInformation.Author = themeDocument.GetValue(Information + "Author");

                colorPalette.BorderNormal = themeDocument.GetValue(Shared + "Border/Normal").ToColor();
                colorPalette.BorderHover = themeDocument.GetValue(Shared + "Border/Hover").ToColor();

                colorPalette.TextEnabled = themeDocument.GetValue(Shared + "Font/Enabled").ToColor();
                colorPalette.TextHover = themeDocument.GetValue(Shared + "Font/Hover").ToColor();
                colorPalette.TextDisabled = themeDocument.GetValue(Shared + "Font/Disabled").ToColor();
                colorPalette.Selected = themeDocument.GetValue(Shared + "Font/Selected").ToColor();
                colorPalette.SubscriptColor = themeDocument.GetValue(Shared + "Font/Subscript").ToColor();
                colorPalette.SuperscriptColor = themeDocument.GetValue(Shared + "Font/Superscript").ToColor();

                // colorPalette.Font = FontManager.ResolveFontFamily(themeDocument.GetValue(Shared + "Font/FontFamily"));
                colorPalette.Enabled = themeDocument.GetValue(Toolkit + "VisualButton/Enabled").ToColor();
                colorPalette.Disabled = themeDocument.GetValue(Toolkit + "VisualButton/Disabled").ToColor();
                colorPalette.Hover = themeDocument.GetValue(Toolkit + "VisualButton/Hover").ToColor();
                colorPalette.Pressed = themeDocument.GetValue(Toolkit + "VisualButton/Pressed").ToColor();

                colorPalette.FormBackground = themeDocument.GetValue(Toolkit + "VisualForm/Background").ToColor();
                colorPalette.FormWindowBar = themeDocument.GetValue(Toolkit + "VisualForm/WindowBar").ToColor();

                colorPalette.Item = themeDocument.GetValue(Shared + "ListItem/Normal").ToColor();
                colorPalette.ItemHover = themeDocument.GetValue(Shared + "ListItem/Hover").ToColor();
                colorPalette.ItemSelected = themeDocument.GetValue(Shared + "ListItem/Selected").ToColor();
                colorPalette.ItemAlternate = themeDocument.GetValue(Shared + "ListItem/Alternate").ToColor();

                colorPalette.Type1 = themeDocument.GetValue(Shared + "Background/Type1").ToColor();
                colorPalette.Type2 = themeDocument.GetValue(Shared + "Background/Type2").ToColor();
                colorPalette.Type3 = themeDocument.GetValue(Shared + "Background/Type3").ToColor();
                colorPalette.Type4 = themeDocument.GetValue(Shared + "Background/Type4").ToColor();

                colorPalette.Line = themeDocument.GetValue(Shared + "Line").ToColor();
                colorPalette.Shadow = themeDocument.GetValue(Shared + "Shadow").ToColor();
                colorPalette.LightText = themeDocument.GetValue(Shared + "LightText").ToColor();

                colorPalette.ColumnHeader = themeDocument.GetValue(Shared + "ColumnHeader/Header").ToColor();
                colorPalette.ColumnText = themeDocument.GetValue(Shared + "ColumnHeader/Text").ToColor();

                colorPalette.ControlEnabled = themeDocument.GetValue(Shared + "Control/Enabled").ToColor();
                colorPalette.ControlDisabled = themeDocument.GetValue(Shared + "Control/Disabled").ToColor();

                colorPalette.BackCircle = themeDocument.GetValue(Toolkit + "VisualRadialProgress/BackCircle").ToColor();
                colorPalette.ForeCircle = themeDocument.GetValue(Toolkit + "VisualRadialProgress/ForeCircle").ToColor();

                colorPalette.ProgressBackground = themeDocument.GetValue(Shared + "ProgressBar/Background").ToColor();
                colorPalette.Progress = themeDocument.GetValue(Shared + "ProgressBar/Working").ToColor();
                colorPalette.ProgressDisabled = themeDocument.GetValue(Shared + "ProgressBar/Disabled").ToColor();

                colorPalette.HatchBackColor = themeDocument.GetValue(Shared + "Hatch/BackColor").ToColor();
                colorPalette.HatchForeColor = themeDocument.GetValue(Shared + "Hatch/ForeColor").ToColor();

                colorPalette.FlatControlDisabled = themeDocument.GetValue(Shared + "FlatControl/Enabled").ToColor();
                colorPalette.FlatControlEnabled = themeDocument.GetValue(Shared + "FlatControl/Enabled").ToColor();

                colorPalette.BoxDisabled = themeDocument.GetValue(Shared + "Box/Disabled").ToColor();
                colorPalette.BoxEnabled = themeDocument.GetValue(Shared + "Box/Enabled").ToColor();

                colorPalette.WatermarkActive = themeDocument.GetValue(Shared + "Watermark/Active").ToColor();
                colorPalette.WatermarkInactive = themeDocument.GetValue(Shared + "Watermark/Inactive").ToColor();

                colorPalette.TabPageEnabled = themeDocument.GetValue(Shared + "TabPage/Enabled").ToColor();
                colorPalette.TabPageDisabled = themeDocument.GetValue(Shared + "TabPage/Disabled").ToColor();
                colorPalette.TabPageHover = themeDocument.GetValue(Shared + "TabPage/Hover").ToColor();
                colorPalette.TabPageSelected = themeDocument.GetValue(Shared + "TabPage/Selected").ToColor();

                colorPalette.HelpButtonBack.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/BackColorState/Disabled").ToColor();
                colorPalette.HelpButtonBack.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/BackColorState/Enabled").ToColor();
                colorPalette.HelpButtonBack.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/BackColorState/Hover").ToColor();
                colorPalette.HelpButtonBack.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/BackColorState/Pressed").ToColor();

                colorPalette.HelpButtonFore.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/ForeColorState/Disabled").ToColor();
                colorPalette.HelpButtonFore.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/ForeColorState/Enabled").ToColor();
                colorPalette.HelpButtonFore.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/ForeColorState/Hover").ToColor();
                colorPalette.HelpButtonFore.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/HelpButton/ForeColorState/Pressed").ToColor();

                colorPalette.MinimizeButtonBack.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Disabled").ToColor();
                colorPalette.MinimizeButtonBack.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Enabled").ToColor();
                colorPalette.MinimizeButtonBack.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Hover").ToColor();
                colorPalette.MinimizeButtonBack.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Pressed").ToColor();

                colorPalette.MinimizeButtonFore.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Disabled").ToColor();
                colorPalette.MinimizeButtonFore.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Enabled").ToColor();
                colorPalette.MinimizeButtonFore.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Hover").ToColor();
                colorPalette.MinimizeButtonFore.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Pressed").ToColor();

                colorPalette.MaximizeButtonBack.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Disabled").ToColor();
                colorPalette.MaximizeButtonBack.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Enabled").ToColor();
                colorPalette.MaximizeButtonBack.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Hover").ToColor();
                colorPalette.MaximizeButtonBack.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Pressed").ToColor();

                colorPalette.MaximizeButtonFore.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Disabled").ToColor();
                colorPalette.MaximizeButtonFore.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Enabled").ToColor();
                colorPalette.MaximizeButtonFore.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Hover").ToColor();
                colorPalette.MaximizeButtonFore.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Pressed").ToColor();

                colorPalette.CloseButtonBack.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/BackColorState/Disabled").ToColor();
                colorPalette.CloseButtonBack.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/BackColorState/Enabled").ToColor();
                colorPalette.CloseButtonBack.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/BackColorState/Hover").ToColor();
                colorPalette.CloseButtonBack.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/BackColorState/Pressed").ToColor();

                colorPalette.CloseButtonFore.Disabled = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/ForeColorState/Disabled").ToColor();
                colorPalette.CloseButtonFore.Enabled = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/ForeColorState/Enabled").ToColor();
                colorPalette.CloseButtonFore.Hover = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/ForeColorState/Hover").ToColor();
                colorPalette.CloseButtonFore.Pressed = themeDocument.GetValue(Toolkit + "VisualControlBox/CloseButton/ForeColorState/Pressed").ToColor();

                colorPalette.ScrollBar.Disabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Bar/Disabled").ToColor();
                colorPalette.ScrollBar.Enabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Bar/Enabled").ToColor();

                colorPalette.ScrollThumb.Disabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Thumb/Disabled").ToColor();
                colorPalette.ScrollThumb.Enabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Thumb/Enabled").ToColor();
                colorPalette.ScrollThumb.Hover = themeDocument.GetValue(Toolkit + "VisualScrollBar/Thumb/Hover").ToColor();
                colorPalette.ScrollThumb.Pressed = themeDocument.GetValue(Toolkit + "VisualScrollBar/Thumb/Pressed").ToColor();

                colorPalette.ScrollButton.Disabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Button/Disabled").ToColor();
                colorPalette.ScrollButton.Enabled = themeDocument.GetValue(Toolkit + "VisualScrollBar/Button/Enabled").ToColor();
                colorPalette.ScrollButton.Hover = themeDocument.GetValue(Toolkit + "VisualScrollBar/Button/Hover").ToColor();
                colorPalette.ScrollButton.Pressed = themeDocument.GetValue(Toolkit + "VisualScrollBar/Button/Pressed").ToColor();
            }
            catch (Exception e)
            {
                ConsoleEx.WriteDebug(e);
            }

            Theme theme = new Theme(themeInformation, colorPalette);
            return theme;
        }

        /// <summary>Serialize the theme contents to a string.</summary>
        /// <param name="themeInformation">The information.</param>
        /// <param name="colorPalette">The color palette.</param>
        /// <returns>The <see cref="string" />.</returns>
        private static string Serialize(ThemeInformation themeInformation, ColorPalette colorPalette)
        {
            const string Header = @"VisualPlus-Theme";
            const string Information = @"Information";
            const string StyleTable = @"StyleTable";
            const string Shared = @"Shared";
            const string Toolkit = @"Toolkit";

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    Encoding = new UTF8Encoding(false),
                    NewLineHandling = NewLineHandling.None,
                    NewLineChars = "\n"
                };

            string serializedXML;

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteWhitespace("\n\n");

                    // Write main theme header
                    xmlWriter.WriteStartElement(Header);

                    // Write theme information header.
                    xmlWriter.WriteStartElement(Information);

                    xmlWriter.WriteElementString("Name", themeInformation.Name);
                    xmlWriter.WriteElementString("Author", themeInformation.Author);

                    xmlWriter.WriteEndElement();

                    // Write theme style table header.
                    xmlWriter.WriteStartElement(StyleTable);

                    // Write theme shared.
                    xmlWriter.WriteStartElement(Shared);

                    // < ----------------------------------------------------------------------- |
                    xmlWriter.WriteElementString("LightText", colorPalette.LightText.ToHTML());
                    xmlWriter.WriteElementString("Line", colorPalette.Line.ToHTML());
                    xmlWriter.WriteElementString("Shadow", colorPalette.Shadow.ToHTML());

                    // < ----------------------------------------------------------------------- |
                    xmlWriter.WriteStartElement("Background");
                    xmlWriter.WriteElementString("Type1", colorPalette.Type1.ToHTML());
                    xmlWriter.WriteElementString("Type2", colorPalette.Type2.ToHTML());
                    xmlWriter.WriteElementString("Type3", colorPalette.Type3.ToHTML());
                    xmlWriter.WriteElementString("Type4", colorPalette.Type4.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Border");
                    xmlWriter.WriteElementString("Normal", colorPalette.BorderNormal.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.BorderHover.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Box");
                    xmlWriter.WriteElementString("Enabled", colorPalette.BoxEnabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.BoxDisabled.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ColumnHeader");
                    xmlWriter.WriteElementString("Header", colorPalette.ColumnHeader.ToHTML());
                    xmlWriter.WriteElementString("Text", colorPalette.ColumnText.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Control");
                    xmlWriter.WriteElementString("Enabled", colorPalette.ControlEnabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.ControlDisabled.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("FlatControl");
                    xmlWriter.WriteElementString("Enabled", colorPalette.FlatControlEnabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.FlatControlDisabled.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Font");
                    xmlWriter.WriteElementString("Enabled", colorPalette.TextEnabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.TextDisabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.TextHover.ToHTML());
                    xmlWriter.WriteElementString("Selected", colorPalette.Selected.ToHTML());
                    xmlWriter.WriteElementString("Subscript", colorPalette.SubscriptColor.ToHTML());
                    xmlWriter.WriteElementString("Superscript", colorPalette.SuperscriptColor.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ListItem");
                    xmlWriter.WriteElementString("Normal", colorPalette.Item.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.ItemHover.ToHTML());
                    xmlWriter.WriteElementString("Selected", colorPalette.ItemSelected.ToHTML());
                    xmlWriter.WriteElementString("Alternate", colorPalette.ItemAlternate.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Hatch");
                    xmlWriter.WriteElementString("BackColor", colorPalette.HatchBackColor.ToHTML());
                    xmlWriter.WriteElementString("ForeColor", colorPalette.HatchForeColor.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ProgressBar");
                    xmlWriter.WriteElementString("Background", colorPalette.ProgressBackground.ToHTML());
                    xmlWriter.WriteElementString("Working", colorPalette.Progress.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.ProgressDisabled.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("TabPage");
                    xmlWriter.WriteElementString("Enabled", colorPalette.TabPageEnabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.TabPageDisabled.ToHTML());
                    xmlWriter.WriteElementString("Selected", colorPalette.TabPageSelected.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.TabPageHover.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Watermark");
                    xmlWriter.WriteElementString("Active", colorPalette.WatermarkActive.ToHTML());
                    xmlWriter.WriteElementString("Inactive", colorPalette.WatermarkInactive.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End shared.
                    xmlWriter.WriteEndElement();

                    // Write theme toolkit.
                    xmlWriter.WriteStartElement(Toolkit);

                    xmlWriter.WriteStartElement("VisualButton");
                    xmlWriter.WriteElementString("Enabled", colorPalette.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Disabled", colorPalette.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("VisualControlBox");

                    xmlWriter.WriteStartElement("HelpButton");
                    xmlWriter.WriteStartElement("BackColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.HelpButtonBack.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.HelpButtonBack.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.HelpButtonBack.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.HelpButtonBack.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ForeColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.HelpButtonFore.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.HelpButtonFore.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.HelpButtonFore.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.HelpButtonFore.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End Help Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("MinimizeButton");
                    xmlWriter.WriteStartElement("BackColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.MinimizeButtonBack.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.MinimizeButtonBack.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.MinimizeButtonBack.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.MinimizeButtonBack.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ForeColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.MinimizeButtonFore.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.MinimizeButtonFore.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.MinimizeButtonFore.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.MinimizeButtonFore.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End Minimize Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("MaximizeButton");
                    xmlWriter.WriteStartElement("BackColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.MaximizeButtonBack.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.MaximizeButtonBack.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.MaximizeButtonBack.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.MaximizeButtonBack.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ForeColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.MaximizeButtonFore.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.MaximizeButtonFore.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.MaximizeButtonFore.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.MaximizeButtonFore.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End Maximize Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("CloseButton");
                    xmlWriter.WriteStartElement("BackColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.CloseButtonBack.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.CloseButtonBack.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.CloseButtonBack.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.CloseButtonBack.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ForeColorState");
                    xmlWriter.WriteElementString("Disabled", colorPalette.CloseButtonFore.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.CloseButtonFore.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.CloseButtonFore.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.CloseButtonFore.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End Close Button
                    xmlWriter.WriteEndElement();

                    // End VisualControlBox
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("VisualForm");
                    xmlWriter.WriteElementString("Background", colorPalette.FormBackground.ToHTML());
                    xmlWriter.WriteElementString("WindowBar", colorPalette.FormWindowBar.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("VisualRadialProgress");
                    xmlWriter.WriteElementString("BackCircle", colorPalette.BackCircle.ToHTML());
                    xmlWriter.WriteElementString("ForeCircle", colorPalette.ForeCircle.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("VisualScrollbar");
                    xmlWriter.WriteStartElement("Bar");
                    xmlWriter.WriteElementString("Disabled", colorPalette.ScrollBar.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.ScrollBar.Disabled.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Button");
                    xmlWriter.WriteElementString("Disabled", colorPalette.ScrollButton.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.ScrollButton.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.ScrollButton.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.ScrollButton.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Thumb");
                    xmlWriter.WriteElementString("Disabled", colorPalette.ScrollThumb.Disabled.ToHTML());
                    xmlWriter.WriteElementString("Enabled", colorPalette.ScrollThumb.Enabled.ToHTML());
                    xmlWriter.WriteElementString("Hover", colorPalette.ScrollThumb.Hover.ToHTML());
                    xmlWriter.WriteElementString("Pressed", colorPalette.ScrollThumb.Pressed.ToHTML());
                    xmlWriter.WriteEndElement();

                    // End visual scrollbar.
                    xmlWriter.WriteEndElement();

                    // End toolkit.
                    xmlWriter.WriteEndElement();

                    // End Style table.
                    xmlWriter.WriteEndElement();

                    // End main header.
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndDocument();
                }

                serializedXML = Encoding.Default.GetString(outputStream.ToArray());
            }

            return serializedXML;
        }

        #endregion
    }
}