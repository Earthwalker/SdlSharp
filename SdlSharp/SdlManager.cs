//-----------------------------------------------------------------------
// <copyright file="SdlManager.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using SDL2;

    /// <summary>
    /// SdlManager
    /// </summary>
    public class SdlManager : IDisposable
    {
        /// <summary>
        /// The event handler for the <see cref="SdlEvent"/> event.
        /// </summary>
        private EventHandler<SdlEventArgs> sdlEventHandler;

        /// <summary>
        /// Handles new sdl events.
        /// </summary>
        public event EventHandler<SdlEventArgs> SdlEvent
        {
            add
            {
                sdlEventHandler += value;
            }

            remove
            {
                sdlEventHandler -= value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlManager" /> class.
        /// </summary>
        /// <param name="flags">The flags.</param>
        public SdlManager(uint flags)
        {
            SDL.SDL_Init(flags);
        }

        /// <summary>
        /// Handles the events.
        /// </summary>
        public void Poll()
        {
            if (SDL.SDL_PollEvent(out SDL.SDL_Event sdlEvent) == 1)
                sdlEventHandler?.Invoke(this, new SdlEventArgs(sdlEvent));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL.SDL_Quit();

            GC.SuppressFinalize(this);
        }
    }
}
