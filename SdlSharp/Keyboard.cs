//-----------------------------------------------------------------------
// <copyright file="Keyboard.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using SDL2;

    /// <summary>
    /// Keyboard
    /// </summary>
    public static class Keyboard
    {
        private static byte[] oldKeys;

        private static byte[] keys;

        public static void UpdateState()
        {
            var pointer = SDL.SDL_GetKeyboardState(out int keyNumber);
            KeyNumber = keyNumber;

            // copy the current keys to the old ones
            if (oldKeys == null)
                oldKeys = new byte[keyNumber];
            else
                keys.CopyTo(oldKeys, 0);

            // clear existing key array
            keys = new byte[keyNumber];

            // copy to the array
            Marshal.Copy(pointer, keys, 0, keys.Length);
        }

        public static int KeyNumber { get; private set; }

        public static bool IsKeyDown(SDL.SDL_Scancode key)
        {
            return keys[(int)key] != 0;
        }

        public static bool IsKeyUp(SDL.SDL_Scancode key)
        {
            return keys[(int)key] == 0;
        }

        public static bool IsKeyPressed(SDL.SDL_Scancode key)
        {
            return oldKeys[(int)key] != 0 && keys[(int)key] == 0;
        }
    }
}
