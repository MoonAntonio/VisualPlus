#region Namespace

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

using VisualPlus.Enumerators;

#endregion

namespace VisualPlus.Structure
{
    public static class ConsoleEx
    {
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
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(string text, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            WriteLog(text, formatted, output);
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(Exception exception, DebugOutput output = DebugOutput.TraceListener)
        {
            WriteLog(CreateException(exception), false, output);
        }

        /// <summary>Write the debug text to console.</summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="formatted">The toggle.</param>
        public static void WriteToConsole(string text, bool formatted = true)
        {
            string formattedText = text;
            if (formatted)
            {
                formattedText = FormattedText(text);
            }

            Console.WriteLine(formattedText);
        }

        /// <summary>Write the debug text to file.</summary>
        /// <param name="file">The file to output.</param>
        /// <param name="text">The text to write to the file.</param>
        /// <param name="formatted">The toggle.</param>
        public static void WriteToFile(string file, string text, bool formatted = true)
        {
            try
            {
                string formattedText = text;
                if (formatted)
                {
                    formattedText = FormattedText(text);
                }

                StreamWriter _streamWriter = new StreamWriter(file, true);
                _streamWriter.Write(formattedText);
                _streamWriter.Close();
            }
            catch (UnauthorizedAccessException)
            {
                WriteDebug("UnauthorizedAccessException - Unable to access file!", true, DebugOutput.All);
            }
        }

        /// <summary>Write the debug text to file.</summary>
        /// <param name="text">The text to write to the file.</param>
        /// <param name="formatted">The toggle.</param>
        public static void WriteToTraceListener(string text, bool formatted = true)
        {
            string formattedText = text;
            if (formatted)
            {
                formattedText = FormattedText(text);
            }

            Debug.WriteLine(formattedText);
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="text">The text to write.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        private static void WriteLog(string text, bool formatted = true, DebugOutput output = DebugOutput.All)
        {
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
                case DebugOutput.Console:
                    {
                        WriteToConsole(text, formatted);
                        break;
                    }

                case DebugOutput.File:
                    {
                        WriteToFile(_output, text, formatted);
                        break;
                    }

                case DebugOutput.TraceListener:
                    {
                        WriteToTraceListener(text, formatted);
                        break;
                    }

                case DebugOutput.All:
                    {
                        WriteToFile(_output, text, formatted);
                        WriteToTraceListener(text, formatted);
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