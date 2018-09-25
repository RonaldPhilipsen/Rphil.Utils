// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Solid Optics">
//   
// Copyright 2017 Solid Optics. </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   General purpose extension methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RPhil.Utils
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary> General purpose extension methods. </summary>
    public static class ExtensionMethods
    {
        /// <summary>Get a named property from an object. </summary>
        /// <param name="src">The source object. </param>
        /// <param name="propName">The property name. </param>
        /// <returns>The value of the object <see cref="object"/>. </returns>
        public static object GetPropValue(this object src, string propName) => src?.GetType().GetProperty(propName)?.GetValue(src, null);

        /// <summary>set the value of a named property in an object. </summary>
        /// <param name="src">The source. </param>
        /// <param name="propName">The property name. </param>
        /// <param name="value">The value. </param>
        public static void SetPropValue(this object src, string propName, string value) => src.GetType().GetProperty(propName)?.SetValue(src, value);

        /// <summary>converts a byte to a binary string </summary>
        /// <param name="b">the given byte </param>
        /// <returns>the new binary string </returns>
        public static string ToBinaryString(this byte b) => Convert.ToString(b, 2).PadLeft(8, '0');

        /// <summary>Copies T by value </summary>
        /// <param name="item">The item. </param>
        /// <typeparam name="T">the Type </typeparam>
        /// <returns>The <see cref="T"/>. </returns>
        public static T DeepCopy<T>(T item)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            var result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}