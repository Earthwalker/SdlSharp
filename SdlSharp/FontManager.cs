//-----------------------------------------------------------------------
// <copyright file="FontManager.cs" company="">
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
    /// FontManager
    /// </summary>
    public class FontManager : IDisposable
    {
        /// <summary>
        /// The fonts.
        /// </summary>
        private readonly List<TTF_Font> fonts = new List<TTF_Font>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FontManager"/> class.
        /// </summary>
        public FontManager()
        {
            SDL_ttf.TTF_Init();
        }

        /// <summary>
        /// Adds the font if it hasn't been added already and return the desired font.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns>
        /// The <see cref="TTF_Font" />.
        /// </returns>
        public TTF_Font AddFont(TTF_Font font)
        {
            // ensure a texture with this name has not already been added
            var oldFont = FindFont(font.FontFaceStyleName, font.Height);

            if (oldFont == null)
            {
                // add the new font
                fonts.Add(font);
                return font;
            }

            // since this font has already been loaded, dispose the new one
            font?.Dispose();

            // return the old font
            return oldFont;
        }

        /// <summary>
        /// Removes the font. Does NOT dispose the font.
        /// </summary>
        /// <param name="font">The font.</param>
        public void RemoveFont(TTF_Font font)
        {
            // remove from the collection
            fonts.Remove(font);
        }

        /// <summary>
        /// Finds the font with specified name and point size.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pointSize">Point size.</param>
        /// <returns>The <see cref="TTF_Font"/>.</returns>
        public TTF_Font FindFont(string name, int pointSize = 0)
        {
            return fonts.Find(f => string.Compare(f.FontFaceStyleName, name, StringComparison.OrdinalIgnoreCase) == 0 && (pointSize == 0 || f.Height == pointSize));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // dispose fonts
            foreach (var font in fonts)
                font?.Dispose();

            SDL_ttf.TTF_Quit();
            GC.SuppressFinalize(this);
        }
    }
}
