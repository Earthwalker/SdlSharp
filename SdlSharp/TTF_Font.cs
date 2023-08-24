//-----------------------------------------------------------------------
// <copyright file="TTF_Font.cs" company="">
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

    public enum FontStyle
    {
        Normal = 0x00,
        Bold = 0x01,
        Italic = 0x02,
        Underline = 0x04,
        Strikethrough = 0x08
    }

    /// <summary>
    /// TTF_Font
    /// </summary>
    public class TTF_Font : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TTF_Font" /> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="pointSize">Point size.</param>
        public TTF_Font(string fileName, int pointSize)
        {
            Handle = SDL_ttf.TTF_OpenFont(fileName, pointSize);
        }

        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        public IntPtr Handle { get; }

        public FontStyle FontStyle
        {
            get
            {
                return (FontStyle)SDL_ttf.TTF_GetFontStyle(Handle);
            }

            set
            {
                SDL_ttf.TTF_SetFontStyle(Handle, (int)value);
            }
        }

        public int Outline
        {
            get
            {
                return SDL_ttf.TTF_GetFontOutline(Handle);
            }

            set
            {
                SDL_ttf.TTF_SetFontOutline(Handle, value);
            }
        }

        public int Height
        {
            get
            {
                return SDL_ttf.TTF_FontHeight(Handle);
            }
        }

        public string FontFaceFamilyName
        {
            get
            {
                return SDL_ttf.TTF_FontFaceFamilyName(Handle);
            }
        }

        public string FontFaceStyleName
        {
            get
            {
                return SDL_ttf.TTF_FontFaceStyleName(Handle);
            }
        }

        public int[] SizeText(string text)
        {
            SDL_ttf.TTF_SizeText(Handle, text, out int w, out int h);

            return VectorInt(w, h);
        }

        public Surface RenderText_Solid(string text, SDL.SDL_Color color)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Solid(Handle, text, color));
        }

        public Surface RenderText_Solid(string text, byte[] color)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Solid(Handle, text, color.ToColor()));
        }

        public Surface RenderText_Shaded(string text, SDL.SDL_Color foreColor, SDL.SDL_Color backColor)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Shaded(Handle, text, foreColor, backColor));
        }

        public Surface RenderText_Shaded(string text, byte[] foreColor, byte[] backColor)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Shaded(Handle, text, foreColor.ToColor(), backColor.ToColor()));
        }

        public Surface RenderText_Blended(string text, SDL.SDL_Color color)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Blended(Handle, text, color));
        }

        public Surface RenderText_Blended(string text, byte[] color)
        {
            return new Surface(SDL_ttf.TTF_RenderText_Blended(Handle, text, color.ToColor()));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL_ttf.TTF_CloseFont(Handle);
            GC.SuppressFinalize(this);
        }
    }
}
