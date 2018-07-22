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
                _theme = ThemeSerialization.Deserialize(resourceDocumentTheme);
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
                _theme = ThemeSerialization.Deserialize(themeDocument);
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
            return ThemeSerialization.Serialize(themeInformation, colorPalette);
        }

        /// <summary>Write the element group to xml.</summary>
        /// <param name="xmlWriter">The xml writer.</param>
        /// <param name="elementName">The element name.</param>
        /// <param name="colorTable">The element color table.</param>
        public static void WriteElementGroup(XmlWriter xmlWriter, string elementName, Dictionary<string, Color> colorTable)
        {
            xmlWriter.WriteStartElement(elementName);

            foreach (var element in colorTable)
            {
                xmlWriter.WriteElementString(element.Key, element.Value.ToHTML());
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>Retrieves the writer settings.</summary>
        /// <returns>The <see cref="XmlWriterSettings" />.</returns>
        public static XmlWriterSettings WriterSettings()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    Encoding = new UTF8Encoding(false),
                    NewLineHandling = NewLineHandling.None,
                    NewLineChars = "\n"
                };

            return xmlWriterSettings;
        }

        #endregion
    }
}