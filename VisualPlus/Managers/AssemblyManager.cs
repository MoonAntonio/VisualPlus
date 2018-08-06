#region Namespace

using System;
using System.Data;
using System.IO;
using System.Reflection;

using VisualPlus.Structure;

#endregion

namespace VisualPlus.Managers
{
    public class AssemblyManager
    {
        #region Methods

        /// <summary>Loads the assembly file.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>The <see cref="Assembly" />.</returns>
        public static Assembly LoadAssembly(string file)
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

        /// <summary>Retrieves the VisualPlus <see cref="Assembly" />.</summary>
        /// <returns>The <see cref="Assembly" />.</returns>
        public static Assembly VisualPlus()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "VisualPlus.dll");
            return LoadAssembly(filePath);
        }

        #endregion
    }
}