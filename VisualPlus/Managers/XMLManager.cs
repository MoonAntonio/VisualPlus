#region Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;

using VisualPlus.Extensibility;

#endregion

namespace VisualPlus.Managers
{
    public class XMLManager
    {
        #region Methods

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
                throw new ArgumentNullException($@"The element doesnt contain a value: {name}");
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
        /// <param name="elementName">The element name.</param>
        /// <param name="colorTable">The element color table.</param>
        public static void WriteElementGroup(XmlWriter xmlWriter, string elementName, Dictionary<string, Color> colorTable)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            xmlWriter.WriteStartElement(elementName);

            foreach (var element in colorTable)
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

        #endregion
    }
}