namespace VisualPlus.Extensibility
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    #endregion

    public static class EnumExtension
    {
        #region Events

        /// <summary>Returns the count length.</summary>
        /// <param name="enumerator">The enumerator.</param>
<<<<<<< HEAD
        /// <returns>The count length.</returns>
=======
        /// <returns>The <see cref="int" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static int Count(this Enum enumerator)
        {
            return Enum.GetNames(enumerator.GetType()).Length;
        }

        /// <summary>Gets the enumerator index from the value.</summary>
        /// <param name="enumerator">The enumerator.</param>
        /// <param name="value">Value to search.</param>
<<<<<<< HEAD
        /// <returns>The value index.</returns>
=======
        /// <returns>The <see cref="int" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static int GetIndexByValue(this Enum enumerator, string value)
        {
            try
            {
                var indexCount = (int)Enum.Parse(enumerator.GetType(), value);
                return indexCount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        /// <summary>Gets the enumerator value from the index.</summary>
        /// <typeparam name="T">Type parameter.</typeparam>
        /// <param name="enumerator">The enumerator.</param>
        /// <param name="index">The index to search.</param>
<<<<<<< HEAD
        /// <returns>The value string.</returns>
=======
        /// <returns>The <see cref="string" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static string GetValueByIndex<T>(this Enum enumerator, int index)
            where T : struct
        {
            Type type = typeof(T);
            if (type.IsEnum && Enum.IsDefined(enumerator.GetType(), index))
            {
                return Enum.GetName(enumerator.GetType(), index);
            }
            else
            {
                return null;
            }
        }

        /// <summary>Returns the string as an enumerator.</summary>
        /// <typeparam name="T">Type parameter.</typeparam>
        /// <param name="enumeratorString">The string.</param>
<<<<<<< HEAD
        /// <returns>The enumerator.</returns>
=======
        /// <returns>The <see cref="Enum" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static Enum ToEnum<T>(this string enumeratorString)
            where T : struct
        {
            Type type = typeof(T);

            try
            {
                return (Enum)Enum.Parse(type, enumeratorString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>Converts enumerator to a list type.</summary>
        /// <typeparam name="T">Type parameter.</typeparam>
        /// <param name="enumerator">The enumerator.</param>
<<<<<<< HEAD
        /// <returns>Returns enumerated list.</returns>
=======
        /// <returns>The <see cref="List{T}" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static List<T> ToList<T>(this Enum enumerator)
            where T : struct
        {
            Type type = typeof(T);
            return !type.IsEnum ? null : Enum.GetValues(type).Cast<T>().ToList();
        }

        /// <summary>Returns the value.</summary>
        /// <param name="enumerator">The enumerator.</param>
<<<<<<< HEAD
        /// <returns>The enumerator description.</returns>
=======
        /// <returns>The <see cref="string" />.</returns>
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
        public static string Value(this Enum enumerator)
        {
            try
            {
                DescriptionAttribute attribute = enumerator.GetType().GetField(enumerator.ToString()).GetCustomAttribute<DescriptionAttribute>(false);
                return attribute != null ? attribute.Description : enumerator.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion
    }
}