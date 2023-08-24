//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using SDL2;
using System;

namespace SdlSharp
{
    /// <summary>
    /// Utility
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Creates a vector of the specified x and y values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>
        /// The new vector.
        /// </returns>
        internal static double[] Vector(params double[] values)
        {
            return values;
        }

        /// <summary>
        /// Creates a vector of the specified x and y values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>
        /// The new vector.
        /// </returns>
        internal static int[] VectorInt(params int[] values)
        {
            return values;
        }

        /// <summary>
        /// Returns the X component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The X component.</returns>
        internal static double X(this double[] vector)
        {
            if (vector?.Length > 0)
                return vector[0];

            return 0;
        }

        /// <summary>
        /// Returns the X component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The X component.</returns>
        internal static int X(this int[] vector)
        {
            if (vector?.Length > 0)
                return vector[0];

            return 0;
        }

        /// <summary>
        /// Returns the Y component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The Y component.</returns>
        internal static double Y(this double[] vector)
        {
            if (vector?.Length > 1)
                return vector[1];

            return 0;
        }

        /// <summary>
        /// Returns the Y component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The Y component.</returns>
        internal static int Y(this int[] vector)
        {
            if (vector?.Length > 1)
                return vector[1];

            return 0;
        }

        /// <summary>
        /// Returns the Z component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The Z component.</returns>
        internal static double Z(this double[] vector)
        {
            if (vector?.Length > 1)
                return vector[2];

            return 0;
        }

        /// <summary>
        /// Returns the Z component of the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The Z component.</returns>
        internal static int Z(this int[] vector)
        {
            if (vector?.Length > 1)
                return vector[2];

            return 0;
        }

        public static SDL.SDL_Color ToColor(this byte[] colorArray)
        {
            var color = new SDL.SDL_Color();

            if (colorArray.Length > 0)
                color.r = colorArray[0];
            if (colorArray.Length > 1)
                color.g = colorArray[1];
            if (colorArray.Length > 2)
                color.b = colorArray[2];
            if (colorArray.Length > 3)
                color.a = colorArray[3];

            return color;
        }

        /// <summary>
        /// Returns the vector equivalent of the specified <see cref="Layout"/>.
        /// </summary>
        /// <param name="layout">The layout.</param>
        /// <returns>The vector.</returns>
        public static double[] ToVector(this Layout layout)
        {
            switch (layout)
            {
                case Layout.TopLeft:
                    return Vector(0, 0);
                case Layout.TopCenter:
                    return Vector(.5f, 0);
                case Layout.TopRight:
                    return Vector(1, 0);
                case Layout.CenterLeft:
                    return Vector(0, .5f);
                case Layout.Center:
                    return Vector(.5f, .5f);
                case Layout.CenterRight:
                    return Vector(1, .5f);
                case Layout.BottomLeft:
                    return Vector(0, 1);
                case Layout.BottomCenter:
                    return Vector(.5f, 1);
                case Layout.BottomRight:
                    return Vector(1, 1);
                default:
                    return Vector(0, 0);
            }
        }

        /// <summary>
        /// Returns the <see cref="Layout"/> equivalent of the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The layout.</returns>
        public static Layout ToLayout(this double[] vector)
        {
            if (vector == Vector(0, 0))
                return Layout.TopLeft;
            else if (vector == Vector(.5f, 0))
                return Layout.TopCenter;
            else if (vector == Vector(1, 0))
                return Layout.TopRight;
            else if (vector == Vector(0, .5f))
                return Layout.CenterLeft;
            else if (vector == Vector(.5f, .5f))
                return Layout.Center;
            else if (vector == Vector(1, .5f))
                return Layout.CenterRight;
            else if (vector == Vector(0, 1))
                return Layout.BottomLeft;
            else if (vector == Vector(.5f, 1))
                return Layout.BottomCenter;
            else if (vector == Vector(1, 1))
                return Layout.BottomRight;
            else
                return Layout.TopLeft;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The radians.</param>
        /// <returns>The degrees.</returns>
        public static double ToDegrees(this double radians)
        {
            return radians * (180 / Math.PI);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>The radians.</returns>
        public static double ToRadians(this double degrees)
        {
            return degrees / (180 / Math.PI);
        }
    }
}
