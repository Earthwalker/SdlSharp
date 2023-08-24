//-----------------------------------------------------------------------
// <copyright file="SdlEventArgs.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SDL2;

    /// <summary>
    /// SdlEventArgs
    /// </summary>
    public class SdlEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SdlEventArgs" /> class.
        /// </summary>
        /// <param name="sdlEvent">The SDL event.</param>
        public SdlEventArgs(SDL.SDL_Event sdlEvent)
        {
            SdlEvent = sdlEvent;
        }

        /// <summary>
        /// Gets the SDL event.
        /// </summary>
        /// <value>
        /// The SDL event.
        /// </value>
        public SDL.SDL_Event SdlEvent { get; }
    }
}
