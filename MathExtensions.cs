// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathExtensions.cs" company="Solid Optics">
//   
// Copyright 2017 Solid Optics. </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   Extensions that have to do with numbers
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RPhil.Utils
{
    using System;
    using System.Globalization;

    /// <summary> Extensions that have to do with numbers </summary>
    public static class MathExtensions
    {
        /// <summary>Checks if the value exists within a range </summary>
        /// <typeparam name="T">The type </typeparam>
        /// <param name="value">The value </param>
        /// <param name="minimum">Lower bound of the range </param>
        /// <param name="maximum">Upper bound of the range </param>
        /// <returns>the result </returns>
        public static bool Between<T>(this T value, T minimum, T maximum)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
            {
                return false;
            }

            return value.CompareTo(maximum) <= 0;
        }

        /// <summary>The is bit set. </summary>
        /// <param name="val">The value. </param>
        /// <param name="bitToCheck">The bit to check. </param>
        /// <typeparam name="T">the type </typeparam>
        /// <returns>The <see cref="bool"/>. </returns>
        public static bool IsBitSet<T>(this T val, int bitToCheck)
            where T : struct, IConvertible
        {
            var value = val.ToInt64(CultureInfo.CurrentCulture);
            return (value & (1 << bitToCheck)) != 0;
        }

        /// <summary>Sets a bit in a byte </summary>
        /// <param name="b">the given byte </param>
        /// <param name="pos">the position </param>
        /// <returns>the new byte </returns>
        public static byte SetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), "Index not in range");
            }

            return (byte)(b | (1 << pos));
        }

        /// <summary>Toggles a bit in a byte </summary>
        /// <param name="b">the given byte </param>
        /// <param name="pos">the position </param>
        /// <returns>the new byte </returns>
        public static byte ToggleBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), "Index not in range");
            }

            return (byte)(b ^ (1 << pos));
        }

        /// <summary>un sets a bit in a byte </summary>
        /// <param name="b">the given byte </param>
        /// <param name="pos">the position </param>
        /// <returns>the new byte </returns>
        public static byte UnsetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), "Index not in range");
            }

            return (byte)(b & ~(1 << pos));
        }
    }
}