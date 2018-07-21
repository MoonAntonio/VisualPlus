#region Namespace

using System;

using VisualPlus.Enumerators;

#endregion

namespace VisualPlus.Managers
{
    public class DateTimeManager
    {
        #region Methods

        /// <summary>Compares the dates and determines the comparison type.</summary>
        /// <param name="source">The source.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>The <see cref="DateTimeComparer" />.</returns>
        public static DateTimeComparer CompareDates(DateTime source, DateTime comparison)
        {
            int result = DateTime.Compare(source, comparison);

            DateTimeComparer dateTimeComparer;

            if (result < 0)
            {
                dateTimeComparer = DateTimeComparer.Earlier;
            }
            else if (result == 0)
            {
                dateTimeComparer = DateTimeComparer.Same;
            }
            else
            {
                dateTimeComparer = DateTimeComparer.Later;
            }

            return dateTimeComparer;
        }

        /// <summary>Determines if the date is currently expired.</summary>
        /// <param name="expiryDateTime">The expired date time.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool DateExpired(DateTime expiryDateTime)
        {
            bool dateExpired;

            if (DateTime.Now > expiryDateTime)
            {
                dateExpired = true;
            }
            else
            {
                dateExpired = false;
            }

            return dateExpired;
        }

        /// <summary>Determines if the source date is older.</summary>
        /// <param name="source">Thee source.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool DateOlder(DateTime source, DateTime comparison)
        {
            bool sourceOlder;

            switch (CompareDates(source, comparison))
            {
                case DateTimeComparer.Earlier:
                    {
                        sourceOlder = false;
                        break;
                    }

                case DateTimeComparer.Same:
                    {
                        sourceOlder = false;
                        break;
                    }

                case DateTimeComparer.Later:
                    {
                        sourceOlder = true;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            return sourceOlder;
        }

        #endregion
    }
}