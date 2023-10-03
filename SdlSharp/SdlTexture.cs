//-----------------------------------------------------------------------
// <copyright file="SdlTexture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using SDL2;
    using static Utility;

    /// <summary>
    /// Texture
    /// </summary>
    public class SdlTexture : ITexture
    {
        /// <summary>
        /// The renderer.
        /// </summary>
        private readonly SdlRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlTexture" /> class.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="surface">The surface.</param>
        public SdlTexture(SdlRenderer renderer, Surface surface)
        {
            this.renderer = renderer;
            Handle = SDL.SDL_CreateTextureFromSurface(renderer.Handle, surface.Handle);
            Size = surface.Size;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int[] Size { get; }

        /// <summary>
        /// Gets the sdl handle.
        /// </summary>
        /// <value>
        /// The sdl handle.
        /// </value>
        public IntPtr Handle { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlTexture" /> class.
        /// </summary>
        /// <param name="textureManager">The texture manager.</param>
        /// <param name="renderer">The renderer.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// The new <see cref="SdlTexture" />.
        /// </returns>
        public static SdlTexture Create(TextureManager textureManager, SdlRenderer renderer, string fileName)
        {
            // check if the texture has already been loaded
            var texture = textureManager.GetTextureFromName(fileName);

            if (texture == null)
            {
                // load the image to a surface
                using (var image = new Surface(fileName))
                {
                    // create the texture from the image
                    return (SdlTexture)textureManager.AddTexture(new SdlTexture(renderer, image), fileName);
                }
            }

            return (SdlTexture)texture;
        }

        /// <summary>
        /// Draws this instance at the specified position, rotation, and scale, relative to the origin.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="center">The center point to draw and rotate around. Null for the same as position.</param>
        public void Draw(double[] position, double[] rotation, double[] scale, int[] center)
        {
            //var trueScale = Vector(scale.X() - ((Math.Cos(rotation.Z().ToRadians()) - Math.Sin(rotation.X().ToRadians())) * Math.Cos(rotation.Y().ToRadians())),
            //                       scale.Y() - ((Math.Cos(rotation.X().ToRadians()) - Math.Sin(rotation.Z().ToRadians()) ) * Math.Cos(rotation.Y().ToRadians())));
            var trueScale = scale;
            var drawPosition = Vector(position.X() - (trueScale.X() * center.X()),
                                      position.Y() - (trueScale.Y() * center.Y()));

            // .5 = 

            var sourceRect = new SDL.SDL_Rect
            {
                x = 0,
                y = 0,
                w = Size.X(),
                h = Size.Y()
            };

            var destRect = new SDL.SDL_Rect
            {
                x = (int)Math.Round(drawPosition.X()),
                y = (int)Math.Round(drawPosition.Y()),
                w = Math.Abs((int)Math.Round(trueScale.X() * Size.X())),
                h = Math.Abs((int)Math.Round(trueScale.Y() * Size.Y()))
            };

            var point = new SDL.SDL_Point
            {
                x = (int)Math.Round((trueScale.X() * center.X())),
                y = (int)Math.Round(((trueScale.Y() * center.Y())))
            };

            // handle flipping
            var flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;

            if (trueScale.X() * Size.X() < 0)
            {
                flip |= SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;

                destRect.x -= destRect.w;
            }

            if (trueScale.Y() * Size.Y() < 0)
            {
                flip |= SDL.SDL_RendererFlip.SDL_FLIP_VERTICAL;

                destRect.y -= destRect.h;
            }

            //SDL.SDL_RenderCopy(renderer.Handle, Handle, IntPtr.Zero, ref rect);
            SDL.SDL_RenderCopyEx(renderer.Handle, Handle, ref sourceRect, ref destRect, rotation.Y(), ref point, flip);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SDL.SDL_DestroyTexture(Handle);

            GC.SuppressFinalize(this);
        }
    }
}
