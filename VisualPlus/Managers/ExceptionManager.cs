namespace VisualPlus.Managers
{
    #region Namespace

    using System;
<<<<<<< HEAD

    #endregion

    internal class ExceptionManager
=======
    using System.ComponentModel;

    #endregion

    [Description("The exception manager.")]
    public sealed class ExceptionManager
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
    {
        #region Events

        /// <summary>Returns a bool indicating whether the value is in range.</summary>
<<<<<<< HEAD
        /// <param name="sourceValue">The main value.</param>
        /// <param name="minimumValue">Minimum value.</param>
        /// <param name="maximumValue">Maximum value.</param>
        /// <param name="round">Round to nearest value when out of range.</param>
        /// <returns>Bool value.</returns>
        public static int ArgumentOutOfRangeException(int sourceValue, int minimumValue, int maximumValue, bool round)
        {
            if ((sourceValue >= minimumValue) && (sourceValue <= maximumValue))
            {
                return sourceValue;
=======
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
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }
            else
            {
                if (round)
                {
<<<<<<< HEAD
                    return MathManager.FindClosestValue(sourceValue, new[] { minimumValue, maximumValue });
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(sourceValue), $@"The value ({sourceValue}) must be in range of ({minimumValue}) to ({maximumValue}).");
=======
                    return MathManager.FindClosestValue(value, new[] { minimum, maximum });
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $@"The value ({value}) must be in range of ({minimum}) to ({maximum}).");
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
                }
            }
        }

        /// <summary>Returns a bool indicating whether the value is in range.</summary>
<<<<<<< HEAD
        /// <param name="sourceValue">The main value.</param>
        /// <param name="minimumValue">Minimum value.</param>
        /// <param name="maximumValue">Maximum value.</param>
        /// <returns>Bool value.</returns>
        public static bool ArgumentOutOfRangeException(float sourceValue, float minimumValue, float maximumValue)
        {
            if ((sourceValue >= minimumValue) && (sourceValue <= maximumValue))
=======
        /// <param name="value">The main value.</param>
        /// <param name="minimum">Minimum value.</param>
        /// <param name="maximum">Maximum value.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool ArgumentOutOfRangeException(float value, float minimum, float maximum)
        {
            if ((value >= minimum) && (value <= maximum))
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            {
                return true;
            }
            else
            {
<<<<<<< HEAD
                throw new ArgumentOutOfRangeException(nameof(sourceValue), $@"The value ({sourceValue}) must be in range of ({minimumValue}) to ({maximumValue}).");
=======
                throw new ArgumentOutOfRangeException(nameof(value), $@"The value ({value}) must be in range of ({minimum}) to ({maximum}).");
>>>>>>> 69c10d72b8497b62b8145ca299806a7ae828bcb3
            }
        }

        #endregion
    }
}