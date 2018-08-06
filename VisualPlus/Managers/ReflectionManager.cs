#region Namespace

using System;
using System.Linq;
using System.Reflection;

#endregion

namespace VisualPlus.Managers
{
    public class ReflectionManager
    {
        #region Methods

        public const BindingFlags DefaultBindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        /// <summary>Loads the constructor using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="ConstructorInfo" /> array.</returns>
        public static ConstructorInfo[] LoadConstructors(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var constructors = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetConstructors(bindingFlags)).Where(constructorInfo => constructorInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return constructors;
        }

        /// <summary>Loads the event using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="EventInfo" /> array.</returns>
        public static EventInfo[] LoadEvents(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var events = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetEvents(bindingFlags)).Where(eventInfo => eventInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return events;
        }

        /// <summary>Loads the fields using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="FieldInfo" /> array.</returns>
        public static FieldInfo[] LoadFields(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var fields = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetFields(bindingFlags)).Where(fieldInfo => fieldInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return fields;
        }

        /// <summary>Loads the members using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="MemberInfo" /> array.</returns>
        public static MemberInfo[] LoadMembers(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var members = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetMembers(bindingFlags)).Where(memberInfo => memberInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return members;
        }

        /// <summary>Loads the methods using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="MethodInfo" /> array.</returns>
        public static MethodInfo[] LoadMethods(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var methods = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetMethods(bindingFlags)).Where(methodInfo => methodInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return methods;
        }

        /// <summary>Loads the property using the specified attribute type and binding flags.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>The <see cref="PropertyInfo" /> array.</returns>
        public static PropertyInfo[] LoadProperties(Assembly assembly, Type attributeType, BindingFlags bindingFlags = DefaultBindingFlags)
        {
            var properties = assembly.GetTypes().SelectMany(typeInformation => typeInformation.GetProperties(bindingFlags)).Where(memberInfo => memberInfo.GetCustomAttributes(attributeType, false).Length > 0).ToArray();
            return properties;
        }

        #endregion
    }
}