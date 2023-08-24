//-----------------------------------------------------------------------
// <copyright file="Surface.cs" company="Leamware">
//     Copyright (c) Leamware. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using SDL2;
    using static Utility;

    /// <summary>
    /// Surface
    /// </summary>
    public class Surface : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface"/> class.
        /// </summary>
        /// <param name="surfaceHandle">The surface handle.</param>
        public Surface(IntPtr surfaceHandle)
        {
            Handle = surfaceHandle;

            SDL.SDL_GetClipRect(Handle, out SDL.SDL_Rect rect);

            Size = VectorInt(rect.w, rect.h);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Surface" /> class from an image.
        /// </summary>
        /// <param name="fileName">Name of the image file.</param>
        public Surface(string fileName)
        {
            Handle = SDL_image.IMG_Load(fileName);

            SDL.SDL_GetClipRect(Handle, out SDL.SDL_Rect rect);

            Size = VectorInt(rect.w, rect.h);
        }

        public SDL.SDL_Surface SurfaceStruct
        {
            get
            {
                GC.KeepAlive(this);
                return (SDL.SDL_Surface)Marshal.PtrToStructure(Handle, typeof(SDL.SDL_Surface));
            }
        }

        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        public IntPtr Handle { get; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int[] Size { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL.SDL_FreeSurface(Handle);

            GC.SuppressFinalize(this);
        }
    }
}
