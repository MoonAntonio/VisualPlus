#region Namespace

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        /// <summary>Generate an exception entry string.</summary>
        /// <param name="exception">The exception to format.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Generate(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

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

        /// <summary>Generate the formatted string.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Generate(string text)
        {
            return DateTime.Now.ToLocalTime() + " : " + text + Environment.NewLine;
        }

        /// <summary>Generate object formatting.</summary>
        /// <param name="source">The object source.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Generate(object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            string objectFormatting = $@"Type: {source.GetType()}, Value: {source}";
            return objectFormatting;
        }

        /// <summary>Write the debug object to the output.</summary>
        /// <param name="source">The object source.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(object source, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(source);
            WriteLog(generateObjectFormatting, formatted, output);
        }

        /// <summary>Write the debug int to the output.</summary>
        /// <param name="value">The value.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(int value, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(value);
            WriteLog(generateObjectFormatting, formatted, output);
        }

        /// <summary>Write the debug color to the output.</summary>
        /// <param name="color">The color.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(Color color, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(color);
            WriteLog(generateObjectFormatting, formatted, output);
        }

        /// <summary>Write the debug rectangle to the output.</summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(Rectangle rectangle, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(rectangle);
            WriteLog(generateObjectFormatting, formatted, output);
        }

        /// <summary>Write the debug text to the output.</summary>
        /// <param name="point">The point.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(Point point, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(point);
            WriteLog(generateObjectFormatting, formatted, output);
        }

        /// <summary>Write the debug bool to the output.</summary>
        /// <param name="value">The value.</param>
        /// <param name="formatted">The toggle.</param>
        /// <param name="output">The output method to use.</param>
        public static void WriteDebug(bool value, bool formatted = true, DebugOutput output = DebugOutput.TraceListener)
        {
            string generateObjectFormatting = Generate(value);
            WriteLog(generateObjectFormatting, formatted, output);
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
            WriteLog(Generate(exception), false, output);
        }

        /// <summary>Write the debug text to console.</summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="formatted">The toggle.</param>
        public static void WriteToConsole(string text, bool formatted = true)
        {
            string formattedText = text;
            if (formatted)
            {
                formattedText = Generate(text);
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
                    formattedText = Generate(text);
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
                formattedText = Generate(text);
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