#region Namespace

using System;
using System.Linq;

#endregion

namespace VisualPlus.Managers
{
    public sealed class ObjectManagement
    {
        #region Methods

        /// <summary>Retrieves the namespace of the type.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="type" />.</returns>
        public static string GetNamespace(Type type)
        {
            return type.Namespace;
        }

        /// <summary>Gets the enumerated object.</summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The <see cref="object" />.</returns>
        public static object GetObjectEnumerated<T>()
        {
            if (!IsEnum<T>())
            {
                throw new ArgumentException($@"{nameof(T)} is not an enumerator type.");
            }

            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>Determines whether the object has the method.</summary>
        /// <param name="source">The object source.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool HasMethod(object source, string methodName)
        {
            return source.GetType().GetMethod(methodName) != null;
        }

        /// <summary>Determines whether the object has the method.</summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool HasMethod<T>(string methodName)
        {
            return typeof(T).GetMethod(methodName) != null;
        }

        /// <summary>Determines whether the object is an enum.</summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool IsEnum<T>()
        {
            return typeof(T).IsEnum;
        }

        #endregion
    }
}