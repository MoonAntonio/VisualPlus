#region Namespace

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

using VisualPlus.Structure;

#endregion

namespace VisualPlus.Managers
{
    internal class ResourcesManager
    {
        #region Methods

        /// <summary>Retrieve the resource names from the file.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>The <see cref="string" />.</returns>
        internal static List<string> GetResourceNames(string file)
        {
            Assembly _assembly = LoadAssembly(file);
            return _assembly.GetManifestResourceNames().ToList();
        }

        /// <summary>Read the resource from the file.</summary>
        /// <param name="file">The file path.</param>
        /// <param name="resource">The resource name.</param>
        /// <returns>The <see cref="string" />.</returns>
        internal static string ReadResource(string file, string resource)
        {
            Assembly _assembly = LoadAssembly(file);

            try
            {
                string result;
                using (Stream stream = _assembly.GetManifestResourceStream(resource))
                using
                    (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return result;
            }
            catch (ArgumentNullException e)
            {
                // Value cannot be null.Parameter name: stream'
                // The embedded resource cannot be found. Set type to 'Embedded Resource'.
                ConsoleEx.WriteDebug(e);
            }
            catch (Exception e)
            {
                ConsoleEx.WriteDebug(e);
            }

            return null;
        }

        /// <summary>Loads the assembly file.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>The <see cref="Assembly" />.</returns>
        private static Assembly LoadAssembly(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                ConsoleEx.WriteDebug(new NoNullAllowedException(ExceptionMessenger.IsNullOrEmpty(file)));
            }

            if (!File.Exists(file))
            {
                ConsoleEx.WriteDebug(new NoNullAllowedException(ExceptionMessenger.FileNotFound(file)));
            }

            return Assembly.LoadFile(file);
        }

        #endregion
    }
}