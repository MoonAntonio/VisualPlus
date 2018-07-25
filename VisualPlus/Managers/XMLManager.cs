#region Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using VisualPlus.Constants;
using VisualPlus.Extensibility;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Managers
{
    public class XMLManager
    {
        #region Methods

        /// <summary>Verify the element node is empty.</summary>
        /// <param name="container">The theme container.</param>
        /// <param name="elementPath">The element path.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool NodeEmpty(XContainer container, string elementPath)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (string.IsNullOrEmpty(elementPath))
            {
                throw new ArgumentNullException(nameof(elementPath));
            }

            bool nodeEmpty;
            if (NodeExists(container, elementPath))
            {
                XElement node = container.GetNode(elementPath);
                nodeEmpty = string.IsNullOrEmpty(node.Value);
            }
            else
            {
                throw new ArgumentNullException($@"The node doesn't exist. Element Path: {elementPath}");
            }

            return nodeEmpty;
        }

        /// <summary>Verify the element node exists.</summary>
        /// <param name="container">The theme container.</param>
        /// <param name="elementPath">The element path.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool NodeExists(XContainer container, string elementPath)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (string.IsNullOrEmpty(elementPath))
            {
                throw new ArgumentNullException(nameof(elementPath));
            }

            XElement node = container.GetNode(elementPath);
            bool nodeExists = node != null;
            return nodeExists;
        }

        /// <summary>Reads the xml container element to string.</summary>
        /// <param name="container">The xml container.</param>
        /// <param name="elementPath">The element path.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string ReadElement(XContainer container, string elementPath)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (string.IsNullOrEmpty(elementPath))
            {
                throw new ArgumentNullException(nameof(elementPath));
            }

            string element;

            if (NodeExists(container, elementPath))
            {
                if (NodeEmpty(container, elementPath))
                {
                    // Empty node return a default or null value;
                    element = null;
                }
                else
                {
                    // Read node value.
                    element = container.GetNode(elementPath).Value;
                }
            }
            else
            {
                element = null;

                // Node not found logging to trace listener.
                ConsoleEx.WriteDebug($@"Unable to read the xml node. Path: {elementPath}");
            }

            return element;
        }

        /// <summary>Write the element string to xml.</summary>
        /// <param name="xmlWriter">The xml writer.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void WriteElement(XmlWriter xmlWriter, string name, string value)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($@"The element doesnt contain a name. Value: {value}");
            }

            if (string.IsNullOrEmpty(value))
            {
                value = ResetToDefault(name, value);

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($@"The element doesnt contain a value: {name}");
                }
            }

            xmlWriter.WriteElementString(name, value);
        }

        /// <summary>Write the element color to xml.</summary>
        /// <param name="xmlWriter">The xml writer.</param>
        /// <param name="name">The name.</param>
        /// <param name="color">The color.</param>
        public static void WriteElement(XmlWriter xmlWriter, string name, Color color)
        {
            if (color == Color.Empty)
            {
                throw new ArgumentNullException($@"The color is empty for the element: {name}");
            }

            WriteElement(xmlWriter, name, color.ToHTML());
        }

        /// <summary>Write the element group to xml.</summary>
        /// <param name="xmlWriter">The xml writer.</param>
        /// <param name="groupName">The group name.</param>
        /// <param name="colorTable">The element color table.</param>
        public static void WriteElementGroup(XmlWriter xmlWriter, string groupName, Dictionary<string, Color> colorTable)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            xmlWriter.WriteStartElement(groupName);

            foreach (var element in colorTable)
            {
                WriteElement(xmlWriter, element.Key, element.Value);
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>Write the element group to xml.</summary>
        /// <param name="xmlWriter">The xml writer.</param>
        /// <param name="groupName">The group name.</param>
        /// <param name="dataTable">The data Table.</param>
        public static void WriteElementGroup(XmlWriter xmlWriter, string groupName, Dictionary<string, string> dataTable)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            xmlWriter.WriteStartElement(groupName);

            foreach (var element in dataTable)
            {
                WriteElement(xmlWriter, element.Key, element.Value);
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

        /// <summary>Resets the empty <see cref="ThemeInformation" /> element to the defaults.</summary>
        /// <param name="name">The element name.</param>
        /// <param name="value">The element value.</param>
        /// <returns>The <see cref="string" />.</returns>
        private static string ResetToDefault(string name, string value)
        {
            if ((name == "Name") && string.IsNullOrEmpty(value))
            {
                value = SettingConstants.ThemeName;
            }
            else if ((name == "Author") && string.IsNullOrEmpty(value))
            {
                value = SettingConstants.ThemeAuthor;
            }

            return value;
        }

        #endregion
    }
}