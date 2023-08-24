//-----------------------------------------------------------------------
// <copyright file="SpriteManager.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SDL2;
    using Interfaces;

    /// <summary>
    /// Manager for <see cref="ITexture"/>s.
    /// </summary>
    public class TextureManager : IDisposable
    {
        /// <summary>
        /// A dictionary holding file names and the texture loaded from it.
        /// </summary>
        private readonly Dictionary<string, ITexture> textures = new Dictionary<string, ITexture>();

        /// <summary>
        /// A list holding unnamed texutres.
        /// </summary>
        private readonly List<ITexture> unnamedTextures = new List<ITexture>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureManager"/> class.
        /// </summary>
        /// <param name="flags">0, or one or more <see cref="SDL_image.IMG_InitFlags"/> OR'd together.</param>
        public TextureManager(SDL_image.IMG_InitFlags flags)
        {
            SDL_image.IMG_Init(flags);
        }

        /// <summary>
        /// Adds the texture if it hasn't been added already and return the desired texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="name">The unique name if any.</param>
        /// <returns>The <see cref="ITexture"/>.</returns>
        public ITexture AddTexture(ITexture texture, string name = "")
        {
            // if this is an unnamed texture, add it to the appropriate list
            if (string.IsNullOrWhiteSpace(name) && !unnamedTextures.Contains(texture))
            {
                unnamedTextures.Add(texture);
                return texture;
            }

            // ensure a texture with this name has not already been added
            var oldTexture = GetTextureFromName(name);

            if (oldTexture == null)
            {
                // add the new texture
                textures.Add(name, texture);
                return texture;
            }

            // since this texture has already been loaded, dispose the new one
            texture?.Dispose();
            
            // return the old texture
            return oldTexture;
        }

        /// <summary>
        /// Removes the texture with the specified name. Does NOT dispose the texture.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RemoveTexture(string name)
        {
            // remove from the collection
            textures.Remove(name);
        }

        /// <summary>
        /// Removes the specified <see cref="ITexture"/>. Does NOT dispose the texture.
        /// </summary>
        /// <param name="texture">The <see cref="ITexture"/>.</param>
        public void RemoveTexture(ITexture texture)
        {
            // check if the texture is a named texture
            if (textures.ContainsValue(texture))
                textures.Remove(textures.First(t => t.Value == texture).Key);

            // check if the texture is an unnamed texture
            unnamedTextures.Remove(texture);
        }

        /// <summary>
        /// Finds the texture with the specified name.
        /// </summary>
        /// <param name="name">The name of the texture.</param>
        /// <returns>The <see cref="ITexture"/>.</returns>
        public ITexture GetTextureFromName(string name)
        {
            return textures.FirstOrDefault(t => string.Compare(t.Key, name, StringComparison.OrdinalIgnoreCase) == 0).Value;
        }

        /// <summary>
        /// Finds the name of the specified texture;
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns>The name of the texture.</returns>
        public string GetTextureName(ITexture texture)
        {
            if (textures.ContainsValue(texture))
                return textures.First(t => t.Value == texture).Key;

            return null;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // dispose named textures
            foreach (var texture in textures)
                texture.Value.Dispose();

            // dispose unnamed textures
            foreach (var texture in unnamedTextures)
                texture.Dispose();

            SDL_image.IMG_Quit();

            GC.SuppressFinalize(this);
        }
    }
}
