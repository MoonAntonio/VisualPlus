#region Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using VisualPlus.Constants;
using VisualPlus.Enumerators;
using VisualPlus.Extensibility;
using VisualPlus.Managers;

#endregion

namespace VisualPlus.Structure
{
    public class ThemeSerialization
    {
        #region Methods

        /// <summary>Deserialize the theme contents.</summary>
        /// <param name="themeDocument">The theme document.</param>
        /// <returns>The <see cref="Theme" />.</returns>
        public static Theme Deserialize(XContainer themeDocument)
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

            // TODO: Simplify to decompose body.
            try
            {
                themeInformation.Author = XMLManager.ReadElement(themeDocument, Information + "Author");
                themeInformation.Name = XMLManager.ReadElement(themeDocument, Information + "Name");

                colorPalette.BorderNormal = XMLManager.ReadElement(themeDocument, Shared + "Border/Normal").ToColor();
                colorPalette.BorderHover = XMLManager.ReadElement(themeDocument, Shared + "Border/Hover").ToColor();

                colorPalette.TextDisabled = XMLManager.ReadElement(themeDocument, Shared + "Text/Disabled").ToColor();
                colorPalette.TextEnabled = XMLManager.ReadElement(themeDocument, Shared + "Text/Enabled").ToColor();
                colorPalette.TextHover = XMLManager.ReadElement(themeDocument, Shared + "Text/Hover").ToColor();
                colorPalette.TextPressed = XMLManager.ReadElement(themeDocument, Shared + "Text/Pressed").ToColor();
                colorPalette.Selected = XMLManager.ReadElement(themeDocument, Shared + "Text/Selected").ToColor();
                colorPalette.SubscriptColor = XMLManager.ReadElement(themeDocument, Shared + "Text/Subscript").ToColor();
                colorPalette.SuperscriptColor = XMLManager.ReadElement(themeDocument, Shared + "Text/Superscript").ToColor();

                // colorPalette.Font = FontManager.ResolveFontFamily(themeDocument.GetValue(Shared + "Font/FontFamily"));
                colorPalette.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualButton/Enabled").ToColor();
                colorPalette.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualButton/Disabled").ToColor();
                colorPalette.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualButton/Hover").ToColor();
                colorPalette.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualButton/Pressed").ToColor();

                colorPalette.FormBackground = XMLManager.ReadElement(themeDocument, Toolkit + "VisualForm/Background").ToColor();
                colorPalette.FormWindowBar = XMLManager.ReadElement(themeDocument, Toolkit + "VisualForm/WindowBar").ToColor();

                colorPalette.Item = XMLManager.ReadElement(themeDocument, Shared + "ListItem/Normal").ToColor();
                colorPalette.ItemHover = XMLManager.ReadElement(themeDocument, Shared + "ListItem/Hover").ToColor();
                colorPalette.ItemSelected = XMLManager.ReadElement(themeDocument, Shared + "ListItem/Selected").ToColor();
                colorPalette.ItemAlternate = XMLManager.ReadElement(themeDocument, Shared + "ListItem/Alternate").ToColor();

                colorPalette.Type1 = XMLManager.ReadElement(themeDocument, Shared + "Background/Type1").ToColor();
                colorPalette.Type2 = XMLManager.ReadElement(themeDocument, Shared + "Background/Type2").ToColor();
                colorPalette.Type3 = XMLManager.ReadElement(themeDocument, Shared + "Background/Type3").ToColor();
                colorPalette.Type4 = XMLManager.ReadElement(themeDocument, Shared + "Background/Type4").ToColor();

                colorPalette.Line = XMLManager.ReadElement(themeDocument, Shared + "Line").ToColor();
                colorPalette.Shadow = XMLManager.ReadElement(themeDocument, Shared + "Shadow").ToColor();
                colorPalette.LightText = XMLManager.ReadElement(themeDocument, Shared + "LightText").ToColor();

                colorPalette.ColumnHeader = XMLManager.ReadElement(themeDocument, Shared + "ColumnHeader/Header").ToColor();
                colorPalette.ColumnText = XMLManager.ReadElement(themeDocument, Shared + "ColumnHeader/Text").ToColor();

                colorPalette.ControlEnabled = XMLManager.ReadElement(themeDocument, Shared + "Control/Enabled").ToColor();
                colorPalette.ControlDisabled = XMLManager.ReadElement(themeDocument, Shared + "Control/Disabled").ToColor();

                colorPalette.BackCircle = XMLManager.ReadElement(themeDocument, Toolkit + "VisualRadialProgress/BackCircle").ToColor();
                colorPalette.ForeCircle = XMLManager.ReadElement(themeDocument, Toolkit + "VisualRadialProgress/ForeCircle").ToColor();

                colorPalette.ProgressBackground = XMLManager.ReadElement(themeDocument, Shared + "ProgressBar/Background").ToColor();
                colorPalette.Progress = XMLManager.ReadElement(themeDocument, Shared + "ProgressBar/Working").ToColor();
                colorPalette.ProgressDisabled = XMLManager.ReadElement(themeDocument, Shared + "ProgressBar/Disabled").ToColor();

                colorPalette.HatchBackColor = XMLManager.ReadElement(themeDocument, Shared + "Hatch/BackColor").ToColor();
                colorPalette.HatchForeColor = XMLManager.ReadElement(themeDocument, Shared + "Hatch/ForeColor").ToColor();

                colorPalette.FlatControlDisabled = XMLManager.ReadElement(themeDocument, Shared + "FlatControl/Enabled").ToColor();
                colorPalette.FlatControlEnabled = XMLManager.ReadElement(themeDocument, Shared + "FlatControl/Enabled").ToColor();

                colorPalette.BoxDisabled = XMLManager.ReadElement(themeDocument, Shared + "Box/Disabled").ToColor();
                colorPalette.BoxEnabled = XMLManager.ReadElement(themeDocument, Shared + "Box/Enabled").ToColor();

                colorPalette.WatermarkActive = XMLManager.ReadElement(themeDocument, Shared + "Watermark/Active").ToColor();
                colorPalette.WatermarkInactive = XMLManager.ReadElement(themeDocument, Shared + "Watermark/Inactive").ToColor();

                colorPalette.TabPageEnabled = XMLManager.ReadElement(themeDocument, Shared + "TabPage/Enabled").ToColor();
                colorPalette.TabPageDisabled = XMLManager.ReadElement(themeDocument, Shared + "TabPage/Disabled").ToColor();
                colorPalette.TabPageHover = XMLManager.ReadElement(themeDocument, Shared + "TabPage/Hover").ToColor();
                colorPalette.TabPageSelected = XMLManager.ReadElement(themeDocument, Shared + "TabPage/Selected").ToColor();

                colorPalette.HelpButtonBack.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/BackColorState/Disabled").ToColor();
                colorPalette.HelpButtonBack.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/BackColorState/Enabled").ToColor();
                colorPalette.HelpButtonBack.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/BackColorState/Hover").ToColor();
                colorPalette.HelpButtonBack.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/BackColorState/Pressed").ToColor();

                colorPalette.HelpButtonFore.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/ForeColorState/Disabled").ToColor();
                colorPalette.HelpButtonFore.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/ForeColorState/Enabled").ToColor();
                colorPalette.HelpButtonFore.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/ForeColorState/Hover").ToColor();
                colorPalette.HelpButtonFore.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/HelpButton/ForeColorState/Pressed").ToColor();

                colorPalette.MinimizeButtonBack.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Disabled").ToColor();
                colorPalette.MinimizeButtonBack.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Enabled").ToColor();
                colorPalette.MinimizeButtonBack.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Hover").ToColor();
                colorPalette.MinimizeButtonBack.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/BackColorState/Pressed").ToColor();

                colorPalette.MinimizeButtonFore.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Disabled").ToColor();
                colorPalette.MinimizeButtonFore.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Enabled").ToColor();
                colorPalette.MinimizeButtonFore.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Hover").ToColor();
                colorPalette.MinimizeButtonFore.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MinimizeButton/ForeColorState/Pressed").ToColor();

                colorPalette.MaximizeButtonBack.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Disabled").ToColor();
                colorPalette.MaximizeButtonBack.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Enabled").ToColor();
                colorPalette.MaximizeButtonBack.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Hover").ToColor();
                colorPalette.MaximizeButtonBack.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/BackColorState/Pressed").ToColor();

                colorPalette.MaximizeButtonFore.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Disabled").ToColor();
                colorPalette.MaximizeButtonFore.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Enabled").ToColor();
                colorPalette.MaximizeButtonFore.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Hover").ToColor();
                colorPalette.MaximizeButtonFore.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/MaximizeButton/ForeColorState/Pressed").ToColor();

                colorPalette.CloseButtonBack.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/BackColorState/Disabled").ToColor();
                colorPalette.CloseButtonBack.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/BackColorState/Enabled").ToColor();
                colorPalette.CloseButtonBack.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/BackColorState/Hover").ToColor();
                colorPalette.CloseButtonBack.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/BackColorState/Pressed").ToColor();

                colorPalette.CloseButtonFore.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/ForeColorState/Disabled").ToColor();
                colorPalette.CloseButtonFore.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/ForeColorState/Enabled").ToColor();
                colorPalette.CloseButtonFore.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/ForeColorState/Hover").ToColor();
                colorPalette.CloseButtonFore.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualControlBox/CloseButton/ForeColorState/Pressed").ToColor();

                colorPalette.ScrollBar.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Bar/Disabled").ToColor();
                colorPalette.ScrollBar.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Bar/Enabled").ToColor();

                colorPalette.ScrollThumb.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Thumb/Disabled").ToColor();
                colorPalette.ScrollThumb.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Thumb/Enabled").ToColor();
                colorPalette.ScrollThumb.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Thumb/Hover").ToColor();
                colorPalette.ScrollThumb.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Thumb/Pressed").ToColor();

                colorPalette.ScrollButton.Disabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Button/Disabled").ToColor();
                colorPalette.ScrollButton.Enabled = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Button/Enabled").ToColor();
                colorPalette.ScrollButton.Hover = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Button/Hover").ToColor();
                colorPalette.ScrollButton.Pressed = XMLManager.ReadElement(themeDocument, Toolkit + "VisualScrollBar/Button/Pressed").ToColor();
            }
            catch (Exception e)
            {
                ConsoleEx.WriteDebug(e);
            }

            Theme theme = new Theme(themeInformation, colorPalette);
            return theme;
        }

        /// <summary>Deserialize a internal theme from resources.</summary>
        /// <param name="themes">The internal themes.</param>
        /// <returns>The <see cref="Theme" />.</returns>
        public static Theme Deserialize(Themes themes)
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
        public static Theme Deserialize(string filePath)
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

        /// <summary>Serialize the theme contents to a string.</summary>
        /// <param name="themeInformation">The information.</param>
        /// <param name="colorPalette">The color palette.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Serialize(ThemeInformation themeInformation, ColorPalette colorPalette)
        {
            const string Header = @"VisualPlus-Theme";
            const string Information = @"Information";
            const string StyleTable = @"StyleTable";
            const string Shared = @"Shared";
            const string Toolkit = @"Toolkit";

            string serializedXML;

            // TODO: Simplify to decompose body.
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, XMLManager.WriterSettings()))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteWhitespace("\n\n");

                    // Write main theme header
                    xmlWriter.WriteStartElement(Header);

                    // Write theme information header.
                    var themeDataDictionary = new Dictionary<string, string>
                        {
                            { "Name", themeInformation.Name },
                            { "Author", themeInformation.Author }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, Information, themeDataDictionary);

                    // Write theme style table header.
                    xmlWriter.WriteStartElement(StyleTable);

                    // Write theme shared.
                    xmlWriter.WriteStartElement(Shared);

                    // < ----------------------------------------------------------------------- |
                    xmlWriter.WriteElementString("LightText", colorPalette.LightText.ToHTML());
                    xmlWriter.WriteElementString("Line", colorPalette.Line.ToHTML());
                    xmlWriter.WriteElementString("Shadow", colorPalette.Shadow.ToHTML());

                    var backgroundDictionary = new Dictionary<string, Color>
                        {
                            { "Type1", colorPalette.Type1 },
                            { "Type2", colorPalette.Type2 },
                            { "Type3", colorPalette.Type3 },
                            { "Type4", colorPalette.Type4 }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Background", backgroundDictionary);

                    var borderDictionary = new Dictionary<string, Color>
                        {
                            { "BorderNormal", colorPalette.BorderNormal },
                            { "BorderHover", colorPalette.BorderHover }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Border", borderDictionary);

                    var boxDictionary = new Dictionary<string, Color>
                        {
                            { "Enabled", colorPalette.BoxEnabled },
                            { "Disabled", colorPalette.BoxDisabled }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Box", boxDictionary);

                    var columnHeaderDictionary = new Dictionary<string, Color>
                        {
                            { "Header", colorPalette.ColumnHeader },
                            { "Text", colorPalette.ColumnText }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ColumnHeader", columnHeaderDictionary);

                    var controlDictionary = new Dictionary<string, Color>
                        {
                            { "Enabled", colorPalette.ControlEnabled },
                            { "Disabled", colorPalette.ControlDisabled }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Control", controlDictionary);

                    var flatControlDictionary = new Dictionary<string, Color>
                        {
                            { "Enabled", colorPalette.FlatControlEnabled },
                            { "Disabled", colorPalette.FlatControlDisabled }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "FlatControl", flatControlDictionary);

                    var textDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.TextDisabled },
                            { "Enabled", colorPalette.TextEnabled },
                            { "Hover", colorPalette.TextHover },
                            { "Pressed", colorPalette.TextPressed },
                            { "Selected", colorPalette.Selected },
                            { "Subscript", colorPalette.SubscriptColor },
                            { "Superscript", colorPalette.SuperscriptColor }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Text", textDictionary);

                    var listItemDictionary = new Dictionary<string, Color>
                        {
                            { "Normal", colorPalette.Item },
                            { "Hover", colorPalette.ItemHover },
                            { "Selected", colorPalette.ItemSelected },
                            { "Alternate", colorPalette.ItemAlternate }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ListItem", listItemDictionary);

                    var hatchDictionary = new Dictionary<string, Color>
                        {
                            { "BackColor", colorPalette.HatchBackColor },
                            { "ForeColor", colorPalette.HatchForeColor }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Hatch", hatchDictionary);

                    var progressDictionary = new Dictionary<string, Color>
                        {
                            { "Background", colorPalette.ProgressBackground },
                            { "Working", colorPalette.Progress },
                            { "Disabled", colorPalette.ProgressDisabled }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ProgressBar", progressDictionary);

                    var tabPageDictionary = new Dictionary<string, Color>
                        {
                            { "Enabled", colorPalette.TabPageEnabled },
                            { "Disabled", colorPalette.TabPageDisabled },
                            { "Selected", colorPalette.TabPageSelected },
                            { "Hover", colorPalette.TabPageHover }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "TabPage", tabPageDictionary);

                    var watermarkDictionary = new Dictionary<string, Color>
                        {
                            { "Active", colorPalette.WatermarkActive },
                            { "Inactive", colorPalette.WatermarkInactive }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Watermark", watermarkDictionary);

                    // End shared.
                    xmlWriter.WriteEndElement();

                    // Write theme toolkit.
                    xmlWriter.WriteStartElement(Toolkit);

                    var buttonDictionary = new Dictionary<string, Color>
                        {
                            { "Enabled", colorPalette.Enabled },
                            { "Disabled", colorPalette.Disabled },
                            { "Hover", colorPalette.Hover },
                            { "Pressed", colorPalette.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "VisualButton", buttonDictionary);

                    xmlWriter.WriteStartElement("VisualControlBox");

                    xmlWriter.WriteStartElement("HelpButton");

                    var helpBackDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.HelpButtonBack.Disabled },
                            { "Enabled", colorPalette.HelpButtonBack.Enabled },
                            { "Hover", colorPalette.HelpButtonBack.Hover },
                            { "Pressed", colorPalette.HelpButtonBack.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "BackColorState", helpBackDictionary);

                    var helpForeDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.HelpButtonFore.Disabled },
                            { "Enabled", colorPalette.HelpButtonFore.Enabled },
                            { "Hover", colorPalette.HelpButtonFore.Hover },
                            { "Pressed", colorPalette.HelpButtonFore.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ForeColorState", helpForeDictionary);

                    // End Help Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("MinimizeButton");

                    var minBackDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.MinimizeButtonBack.Disabled },
                            { "Enabled", colorPalette.MinimizeButtonBack.Enabled },
                            { "Hover", colorPalette.MinimizeButtonBack.Hover },
                            { "Pressed", colorPalette.MinimizeButtonBack.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "BackColorState", minBackDictionary);

                    var minForeDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.MinimizeButtonFore.Disabled },
                            { "Enabled", colorPalette.MinimizeButtonFore.Enabled },
                            { "Hover", colorPalette.MinimizeButtonFore.Hover },
                            { "Pressed", colorPalette.MinimizeButtonFore.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ForeColorState", minForeDictionary);

                    // End Minimize Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("MaximizeButton");

                    var maxBackDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.MaximizeButtonBack.Disabled },
                            { "Enabled", colorPalette.MaximizeButtonBack.Enabled },
                            { "Hover", colorPalette.MaximizeButtonBack.Hover },
                            { "Pressed", colorPalette.MaximizeButtonBack.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "BackColorState", maxBackDictionary);

                    var maxForeDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.MaximizeButtonFore.Disabled },
                            { "Enabled", colorPalette.MaximizeButtonFore.Enabled },
                            { "Hover", colorPalette.MaximizeButtonFore.Hover },
                            { "Pressed", colorPalette.MaximizeButtonFore.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ForeColorState", maxForeDictionary);

                    // End Maximize Button
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("CloseButton");

                    var closeBackDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.CloseButtonBack.Disabled },
                            { "Enabled", colorPalette.CloseButtonBack.Enabled },
                            { "Hover", colorPalette.CloseButtonBack.Hover },
                            { "Pressed", colorPalette.CloseButtonBack.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "BackColorState", closeBackDictionary);

                    var closeForeDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.CloseButtonFore.Disabled },
                            { "Enabled", colorPalette.CloseButtonFore.Enabled },
                            { "Hover", colorPalette.CloseButtonFore.Hover },
                            { "Pressed", colorPalette.CloseButtonFore.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "ForeColorState", closeForeDictionary);

                    // End Close Button
                    xmlWriter.WriteEndElement();

                    // End VisualControlBox
                    xmlWriter.WriteEndElement();

                    var formDictionary = new Dictionary<string, Color>
                        {
                            { "Background", colorPalette.FormBackground },
                            { "WindowBar", colorPalette.FormWindowBar }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "VisualForm", formDictionary);

                    var radialDictionary = new Dictionary<string, Color>
                        {
                            { "BackCircle", colorPalette.BackCircle },
                            { "ForeCircle", colorPalette.ForeCircle }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "VisualRadialProgress", radialDictionary);

                    xmlWriter.WriteStartElement("VisualScrollbar");

                    var barDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.ScrollBar.Disabled },
                            { "Enabled", colorPalette.ScrollBar.Enabled }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Bar", barDictionary);

                    var scrollButtonDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.ScrollButton.Disabled },
                            { "Enabled", colorPalette.ScrollButton.Enabled },
                            { "Hover", colorPalette.ScrollButton.Hover },
                            { "Pressed", colorPalette.ScrollButton.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Button", scrollButtonDictionary);

                    var scrollThumbDictionary = new Dictionary<string, Color>
                        {
                            { "Disabled", colorPalette.ScrollThumb.Disabled },
                            { "Enabled", colorPalette.ScrollThumb.Enabled },
                            { "Hover", colorPalette.ScrollThumb.Hover },
                            { "Pressed", colorPalette.ScrollThumb.Pressed }
                        };

                    XMLManager.WriteElementGroup(xmlWriter, "Thumb", scrollThumbDictionary);

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

        /// <summary>Serialize the theme to a raw string.</summary>
        /// <param name="theme">The theme.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Serialize(Theme theme)
        {
            return Serialize(theme.Information, theme.ColorPalette);
        }

        #endregion
    }
}