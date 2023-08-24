//-----------------------------------------------------------------------
// <copyright file="Window.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SDL2;
    using static Utility;

    /// <summary>
    /// Window
    /// </summary>
    public class Window : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title of the window, in UTF-8 encoding.</param>
        /// <param name="position">The position of the window. Can use <see cref="SDL.SDL_WINDOWPOS_CENTERED"/> or <see cref="SDL.SDL_WINDOWPOS_UNDEFINED"/>.</param>
        /// <param name="size">The size of the window.</param>
        /// <param name="flags">0, or one or more <see cref="SDL.SDL_WindowFlags"/> OR'd together.</param>
        public Window(string title, int[] position, int[] size, SDL.SDL_WindowFlags flags)
        {
            Handle = SDL.SDL_CreateWindow(title, position.X(), position.Y(), size.X(), size.Y(), flags);
        }

        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        public IntPtr Handle { get; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return SDL.SDL_GetWindowTitle(Handle);
            }

            set
            {
                SDL.SDL_SetWindowTitle(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int[] Position
        {
            get
            {
                var result = VectorInt(0, 0);
                SDL.SDL_GetWindowPosition(Handle, out result[0], out result[1]);

                return result;
            }

            set
            {
                SDL.SDL_SetWindowPosition(Handle, value.X(), value.Y());
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int[] Size
        {
            get
            {
                var result = VectorInt(0, 0);
                SDL.SDL_GetWindowSize(Handle, out result[0], out result[1]);

                return result;
            }

            set
            {
                SDL.SDL_SetWindowSize(Handle, value.X(), value.Y());
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL.SDL_DestroyWindow(Handle);

            GC.SuppressFinalize(this);
        }
    }
}
