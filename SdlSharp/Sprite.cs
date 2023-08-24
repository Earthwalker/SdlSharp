//-----------------------------------------------------------------------
// <copyright file="Sprite.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.IO;
    using SDL2;
    using static Utility;

    /// <summary>
    /// Layout for the <see cref="Sprite"/> origin.
    /// </summary>
    public enum Layout
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    /// <summary>
    /// Sprite
    /// </summary>
    public class Sprite : IDisposable
    {
        /// <summary>
        /// The sprite manager.
        /// </summary>
        private readonly TextureManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="name">The name of the sprite.</param>
        /// <param name="texture">The texture.</param>
        public Sprite(TextureManager manager, string name, ITexture texture)
        {
            this.manager = manager;
            Name = name;
            Texture = texture;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>
        /// The texture.
        /// </value>
        public ITexture Texture { get; }

        /// <summary>
        /// Gets or sets the center in pixels for drawing and rotation.
        /// </summary>
        /// <value>
        /// The center.
        /// </value>
        public int[] Center { get; set; } = VectorInt(0 , 0);

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public Layout Layout
        {
            get
            {
                return Vector(Center.X() / Texture.Size.X(), Center.Y() / Texture.Size.Y()).ToLayout();
            }

            set
            {
                var vector = value.ToVector();

                Center = VectorInt((int)Math.Round(vector.X() * Texture.Size.X()), (int)Math.Round(vector.Y() * Texture.Size.Y()));
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public double[] Position { get; set; } = Vector(0, 0, 0);

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public double[] Rotation { get; set; } = Vector(0, 0, 0);

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public double[] Scale { get; set; } = Vector(1, 1);

        /// <summary>
        /// Gets or sets the depth this instance is drawn at.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; set; } = 0;

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw()
        {
            Texture.Draw(Position, Rotation, Scale, Center);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <param name="name">The name of the cloned sprite.</param>
        /// <returns>
        /// The new <see cref="Sprite" />.
        /// </returns>
        public Sprite Clone(string name)
        {
            return new Sprite(manager, name, Texture);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // might be a bad idea if the texture is shared across sprites.
            Texture.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
