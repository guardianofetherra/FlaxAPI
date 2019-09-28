// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Represents font object that can be using during text rendering (it uses Font Asset but with precached data for chosen font properties).
    /// </summary>
    public partial class Font : Object
    {
        /// <summary>
        /// Creates new <see cref="Font"/> object.
        /// </summary>
        private Font() : base()
        {
        }

        /// <summary>
        /// Gets the parent font asset that contains font family used by this font.
        /// </summary>
        [UnmanagedCall]
        public FontAsset Asset
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetAsset(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the font size.
        /// </summary>
        [UnmanagedCall]
        public int Size
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetSize(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the font characters height.
        /// </summary>
        [UnmanagedCall]
        public int Height
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetHeight(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the largest vertical distance above the baseline for any character in the font.
        /// </summary>
        [UnmanagedCall]
        public int Ascender
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetAscender(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the largest vertical distance below the baseline for any character in the font.
        /// </summary>
        [UnmanagedCall]
        public int Descender
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetDescender(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the line gap property.
        /// </summary>
        [UnmanagedCall]
        public int LineGap
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLineGap(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the kerning amount for a pair of characters.
        /// </summary>
        /// <param name="first">The first character in the pair.</param>
        /// <param name="second">The second character in the pair.</param>
        /// <returns>The kerning amount or 0 if no kerning.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public int GetKerning(char first, char second)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetKerning(unmanagedPtr, first, second);
#endif
        }

        /// <summary>
        /// Caches the given text to prepared for the rendering.
        /// </summary>
        /// <param name="text">The text witch characters to cache.</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void CacheText(string text)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_CacheText(unmanagedPtr, text);
#endif
        }

        /// <summary>
        /// Measures minimum size of the rectangle that will be needed to draw given text.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <returns>The minimum size for that text and fot to render properly.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Vector2 MeasureText(string text)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Vector2 resultAsRef;
            Internal_MeasureText(unmanagedPtr, text, out resultAsRef);
            return resultAsRef;
#endif
        }

        /// <summary>
        /// Processes text to get cached lines for rendering.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <returns>The output lines cache.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public FontLineCache[] ProcessText(string text)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_ProcessText1(unmanagedPtr, text);
#endif
        }

        /// <summary>
        /// Processes text to get cached lines for rendering.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="layout">The layout properties.</param>
        /// <returns>The output lines cache.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public FontLineCache[] ProcessText(string text, ref TextLayoutOptions layout)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_ProcessText2(unmanagedPtr, text, ref layout);
#endif
        }

        /// <summary>
        /// Calculates character position for given text and character index.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="index">The text position to get it's coordinates.</param>
        /// <param name="layout">The layout properties.</param>
        /// <returns>The character position (upper left corner which can be used for a caret position).</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Vector2 GetCharPosition(string text, int index, TextLayoutOptions layout)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Vector2 resultAsRef;
            Internal_GetCharPosition1(unmanagedPtr, text, index, ref layout, out resultAsRef);
            return resultAsRef;
#endif
        }

        /// <summary>
        /// Calculates character position for given text and character index.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="index">The text position to get it's coordinates.</param>
        /// <returns>The character position (upper left corner which can be used for a caret position).</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Vector2 GetCharPosition(string text, int index)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Vector2 resultAsRef;
            Internal_GetCharPosition2(unmanagedPtr, text, index, out resultAsRef);
            return resultAsRef;
#endif
        }

        /// <summary>
        /// Calculates hit character index at given location.
        /// </summary>
        /// <param name="text">The input text to test.</param>
        /// <param name="location">The location to test.</param>
        /// <param name="layout">Layout properties.</param>
        /// <returns>The selected character position index (can be equal to text length if location is outside of the layout rectangle).</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public int HitTestText(string text, Vector2 location, TextLayoutOptions layout)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_HitTestText1(unmanagedPtr, text, ref location, ref layout);
#endif
        }

        /// <summary>
        /// Calculates hit character index at given location.
        /// </summary>
        /// <param name="text">The input text to test.</param>
        /// <param name="location">The location to test.</param>
        /// <returns>The selected character position index (can be equal to text length if location is outside of the layout rectangle).</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public int HitTestText(string text, Vector2 location)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_HitTestText2(unmanagedPtr, text, ref location);
#endif
        }

        /// <summary>
        /// Invalidates all cached dynamic font atlases using this font. Can be used to reload font characters after changing font asset options.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void Invalidate()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Invalidate(unmanagedPtr);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern FontAsset Internal_GetAsset(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetSize(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetHeight(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetAscender(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetDescender(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetLineGap(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetKerning(IntPtr obj, char first, char second);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_CacheText(IntPtr obj, string text);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_MeasureText(IntPtr obj, string text, out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern FontLineCache[] Internal_ProcessText1(IntPtr obj, string text);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern FontLineCache[] Internal_ProcessText2(IntPtr obj, string text, ref TextLayoutOptions layout);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetCharPosition1(IntPtr obj, string text, int index, ref TextLayoutOptions layout, out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetCharPosition2(IntPtr obj, string text, int index, out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_HitTestText1(IntPtr obj, string text, ref Vector2 location, ref TextLayoutOptions layout);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_HitTestText2(IntPtr obj, string text, ref Vector2 location);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Invalidate(IntPtr obj);
#endif

        #endregion
    }
}
