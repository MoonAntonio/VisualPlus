#region Namespace

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

#endregion

namespace VisualPlus.Managers
{
    public class DebugTraceManager
    {
        #region Enumerators

        public enum DebugOutput
        {
            /// <summary>The file.</summary>
            File = 0,

            /// <summary>The trace listener.</summary>
            TraceListener = 1,

            /// <summary>To both.</summary>
            Both = 2
        }

        #endregion

        #region Methods

        /// <summary>Create an entry exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string CreateException(Exception exception)
        {
            StringBuilder _log = new StringBuilder();
            _log.AppendLine("Message:");
            _log.AppendLine(exception.Message);
            _log.Append(Environment.NewLine);
            _log.AppendLine("Type:");
            _log.AppendLine(exception.GetType().FullName);
            _log.Append(Environment.NewLine);
            _log.AppendLine("Stack Trace:");
            _log.AppendLine(exception.StackTrace);
            _log.Append(Environment.NewLine);
            _log.AppendLine("Help Link: " + exception.HelpLink);
            _log.AppendLine("Source: " + exception.Source);
            _log.AppendLine("Target Site: " + exception.TargetSite);
            return _log.ToString();
        }

        /// <summary>Delete the debug text file.</summary>
        /// <param name="file">The file log.</param>
        public static void DeleteLogFile(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new NoNullAllowedException("file");
            }

            if (!File.Exists(file))
            {
                WriteToTraceListener("The file was not found.");
                return;
            }

            File.Delete(file);
        }

        /// <summary>The formatted debug trace string.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string FormattedText(string text)
        {
            return DateTime.Now.ToLocalTime() + " : " + text + Environment.NewLine;
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="text">The text to write.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(string text, DebugOutput output)
        {
            WriteLog(text, output);
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(Exception exception, DebugOutput output)
        {
            WriteLog(CreateException(exception), output);
        }

        /// <summary>Write the debug text to file.</summary>
        /// <param name="file">The file to output.</param>
        /// <param name="text">The text to write to the file.</param>
        public static void WriteToFile(string file, string text)
        {
            try
            {
                StreamWriter _streamWriter = new StreamWriter(file, true);
                _streamWriter.Write(text);
                _streamWriter.Close();
            }
            catch (UnauthorizedAccessException)
            {
                WriteDebug("UnauthorizedAccessException - Unable to access file!", DebugOutput.Both);
            }
        }

        /// <summary>Write the debug text to file.</summary>
        /// <param name="text">The text to write to the file.</param>
        public static void WriteToTraceListener(string text)
        {
            Debug.WriteLine(text);
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="text">The text to write.</param>
        /// <param name="output">The output method to use.</param>
        private static void WriteLog(string text, DebugOutput output = DebugOutput.Both)
        {
            string _formattedText = FormattedText(text);
            string _folderName = Assembly.GetExecutingAssembly().GetName().Name + "-Logs";
            string _executingAssembly = Assembly.GetExecutingAssembly().Location;
            string _directory = Path.GetDirectoryName(_executingAssembly);
            string _fileName = Settings.DebugLogFile;
            string _folderDirectory = _directory + @"\" + _folderName + @"\";
            string _output = _folderDirectory + _fileName;

            if (string.IsNullOrEmpty(_folderName))
            {
                throw new ArgumentNullException("FolderName { " + _folderName + " }");
            }

            if (!Directory.Exists(_folderDirectory))
            {
                Directory.CreateDirectory(_folderDirectory);
            }

            switch (output)
            {
                case DebugOutput.File:
                    {
                        WriteToFile(_output, _formattedText);
                        break;
                    }

                case DebugOutput.TraceListener:
                    {
                        WriteToTraceListener(_formattedText);
                        break;
                    }

                case DebugOutput.Both:
                    {
                        WriteToFile(_output, _formattedText);
                        WriteToTraceListener(_formattedText);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(output), output, null);
                    }
            }
        }

        #endregion
    }
}