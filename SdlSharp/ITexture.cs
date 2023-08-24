//-----------------------------------------------------------------------
// <copyright file="ITexture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SdlSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// ITexture
    /// </summary>
    public interface ITexture : IDisposable
    {
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        int[] Size { get; }

        /// <summary>
        /// Draws this instance at the specified position, rotation, and scale, relative to the origin.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="center">The center point to draw and rotate around. Null for the same as position.</param>
        void Draw(double[] position, double[] rotation, double[] scale, int[] center = null);
    }
}
