#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

#endregion

namespace VisualPlus.Managers
{
    [Description("The exception manager.")]
    public sealed class ExceptionManager
    {
        #region Methods

        /// <summary>Returns a bool indicating whether the value is in range.</summary>
        /// <param name="value">The main value.</param>
        /// <param name="minimum">Minimum value.</param>
        /// <param name="maximum">Maximum value.</param>
        /// <param name="round">Round to nearest value when out of range.</param>
        /// <returns>The <see cref="int" />.</returns>
        public static int ArgumentOutOfRangeException(int value, int minimum, int maximum, bool round)
        {
            if ((value >= minimum) && (value <= maximum))
            {
                return value;
            }
            else
            {
                if (round)
                {
                    return MathManager.FindClosestValue(value, new[] { minimum, maximum });
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $@"The value ({value}) must be in range of ({minimum}) to ({maximum}).");
                }
            }
        }

        /// <summary>Returns a bool indicating whether the value is in range.</summary>
        /// <param name="value">The main value.</param>
        /// <param name="minimum">Minimum value.</param>
        /// <param name="maximum">Maximum value.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool ArgumentOutOfRangeException(float value, float minimum, float maximum)
        {
            if ((value >= minimum) && (value <= maximum))
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), $@"The value ({value}) must be in range of ({minimum}) to ({maximum}).");
            }
        }

        /// <summary>Runs an object reference not set to an instance of an object error check.</summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="source">The object source.</param>
        public static void ObjectReferenceNotSetToAnInstanceOfAnObject<T>(object source)
        {
            if (source != null)
            {
                return;
            }

            StringBuilder emptyObject = new StringBuilder();
            emptyObject.AppendLine($"The {nameof(source)} object is null.");

            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();

            Type memberInfo = new StackTrace().GetFrame(1).GetMethod().DeclaringType;

            if (memberInfo != null)
            {
                string declaringType = memberInfo.ToString();
                emptyObject.AppendLine($"Declaring Type: {declaringType}");
            }

            string fileName = new StackTrace().GetFrame(1).GetFileName();

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "null";
            }

            emptyObject.AppendLine($"Method: {methodBase}");
            emptyObject.AppendLine($"File Name: {fileName}");

            emptyObject.AppendLine();
            emptyObject.AppendLine("Object Information:");
            emptyObject.AppendLine($"Name: {typeof(T).Name}");
            emptyObject.AppendLine($"Namespace: {typeof(T).Namespace}");

            throw new ArgumentNullException(emptyObject.ToString());
        }

        #endregion
    }
}