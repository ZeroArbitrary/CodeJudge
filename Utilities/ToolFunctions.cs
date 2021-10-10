using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;


namespace Utilities.Tools
{
    public static class ToolFunctions
    {
        /// <summary>
        /// Cast Me to the Typeof T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static T CastTo<T>(this object obj)
        {
            return (T)obj;
        }

        /// <summary>
        /// return fn(me), can be considered as a kind of pipe 
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyMeTo<TMe, TResult>(this TMe me, Func<TMe, TResult> fn)
        {
            return fn(me);
        }


        /// <summary>
        /// A subfix version of ForEach
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <param name="fn"></param>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this IEnumerable<TSource> list, Action<TSource> fn)
        {
            foreach (var x in list)
            {
                fn(x);
            }
        }

        /// <summary>
        /// do fn(me); then return me;
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="me"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static TSource Also<TSource>(this TSource me, Action<TSource> fn)
        {
            fn(me);
            return me;
        }

        /// <summary>
        /// return caller's lineNumber
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <returns></returns
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static int LINE([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }

        /// <summary>
        ///  return caller's fileName in which the caller is in.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]

        public static string FILE([System.Runtime.CompilerServices.CallerFilePath] string fileName = "")
        {

            return fileName;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]

        public static void MyAssert(bool b, string str, string fileName, int lineNumber)
        {
            if (!b)
            {
                throw new Exception($"Assertation {str} fails at file: {fileName} line: {lineNumber}");
            }
        }



        // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    }
}
