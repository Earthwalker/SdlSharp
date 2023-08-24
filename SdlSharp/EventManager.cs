//-----------------------------------------------------------------------
// <copyright file="EventManager.cs" company="">
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
    /// EventManager
    /// </summary>
    public class EventManager
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

        public void WaitForEvent()
        {
            SDL.SDL_Event sdlEvent;
            SDL.SDL_WaitEvent(out sdlEvent);
            sdlEventHandler?.Invoke(this, new SdlEventArgs(sdlEvent));
        }
    }
}
