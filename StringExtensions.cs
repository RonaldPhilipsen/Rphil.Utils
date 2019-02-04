// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Solid Optics">
//   
// Copyright 2017 Solid Optics. </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   text extension methods
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RPhil.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary> text extension methods </summary>
    public static class StringExtensions
    {
        /// <summary>Converts a hex string to ascii. </summary>
        /// <param name="hexString">The hex string. </param>
        /// <param name="numCharsPerValue">The num Chars In Param. </param>
        /// <returns>The ascii <see cref="string"/>. </returns>
        public static string ToAscii(this string hexString, int numCharsPerValue)
        {
            var ascii = new StringBuilder(hexString.Length / numCharsPerValue);

            for (var i = 0; i < hexString.Length; i += numCharsPerValue)
            {
                var hs = hexString.Substring(i, numCharsPerValue);
                var decimalValue = Convert.ToUInt32(hs, 16);
                var character = Convert.ToChar(decimalValue);
                ascii.Append(character);
            }

            return ascii.ToString();
        }

        /// <summary>Converts a given string to a byte array </summary>
        /// <param name="stringParam">The string to convert. </param>
        /// <param name="offset">the left-based offset. </param>
        /// <returns>The Byte array </returns>
        public static byte[] ToByteArray(this string stringParam, int offset)
        {
            byte[] result = null;
            var j = offset;
            for (var k = 0; k <= stringParam.Length - 1; k += 2)
            {
                Array.Resize(ref result, j + 1);
                result[j] = (byte)Convert.ToInt32(stringParam.Substring(k, 2), 16);
                ++j;
            }

            return result;
        }

        /// <summary>Converts an ascii string to hex. </summary>
        /// <param name="input">The input. </param>
        /// <param name="numCharsPerValue">the amount of characters in one value </param>
        /// <returns>The <see cref="string"/>. </returns>
        public static string ToHex(this string input, int numCharsPerValue)
        {
            var sb = new StringBuilder();
            var stringFormat = "{0:X" + numCharsPerValue + "}";

            foreach (var c in input)
            {
                sb.AppendFormat(stringFormat, (int)c);
            }

            return sb.ToString();
        }

        /// <summary>Converts a hex string to an array of unsigned shorts. </summary>
        /// <param name="hexString">The hex string. </param>
        /// <param name="dataBitWidth">the width of the registers </param>
        /// <returns>The ascii <see cref="string"/>. </returns>
        public static List<ushort> ToUshortList(this string hexString, byte dataBitWidth)
        {
            var numCharsInValue = dataBitWidth / 4;
            var arraySize = Math.Ceiling((float)hexString.Length / numCharsInValue);
            hexString = hexString.PadLeft(numCharsInValue, '0');
            var ascii = new List<ushort>((int)arraySize);

            for (var i = 0; i < arraySize; i++)
            {
                var hs = hexString.Substring(i * numCharsInValue, numCharsInValue);
                var decimalValue = Convert.ToUInt32(hs, 16);
                var character = Convert.ToUInt16(decimalValue);
                ascii.Add(character);
            }

            return ascii;
        }

        /// <summary>converts a byte to a binary string </summary>
        /// <param name="b">the given byte </param>
        /// <returns>the new binary string </returns>
        public static string ToBinaryString(this byte b) => Convert.ToString(b, 2).PadLeft(8, '0');
    }
}