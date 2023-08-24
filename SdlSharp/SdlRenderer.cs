//-----------------------------------------------------------------------
// <copyright file="SdlRenderer.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SDL2;
    using Interfaces;

    /// <summary>
    /// Renderer
    /// </summary>
    public class SdlRenderer : IRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SdlRenderer" /> class.
        /// </summary>
        /// <param name="window">The window where rendering is displayed.</param>
        /// <param name="index">The index of the rendering driver to initialize, or -1 to initialize the first one supporting the requested flags.</param>
        /// <param name="flags">0, or one or more <see cref="SDL.SDL_RendererFlags"/> OR'd together.</param>
        public SdlRenderer(Window window, int index, SDL.SDL_RendererFlags flags)
        {
            Handle = SDL.SDL_CreateRenderer(window.Handle, index, flags);
        }

        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        public IntPtr Handle { get; }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            SDL.SDL_RenderClear(Handle);
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw()
        {
            SDL.SDL_RenderPresent(Handle);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL.SDL_DestroyRenderer(Handle);

            GC.SuppressFinalize(this);
        }
    }
}
