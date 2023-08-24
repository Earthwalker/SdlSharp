//-----------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp.Interfaces
{
    using System;

    /// <summary>
    /// Interface for renderers.
    /// </summary>
    public interface IRenderer : IDisposable
    {
        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        IntPtr Handle { get; }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();

        /// <summary>
        /// Draws this instance.
        /// </summary>
        void Draw();
    }
}
