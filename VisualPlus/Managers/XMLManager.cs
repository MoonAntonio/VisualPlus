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