﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Philipsen IT">  
//   Copyright 2019 Philipsen IT.
// </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   General purpose Extension methods
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RPhil.Utils
{
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