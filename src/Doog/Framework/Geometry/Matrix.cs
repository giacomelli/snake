﻿using System;

namespace Doog
{
    /// <summary>
    /// Represents the right-handed 3x3 floating point matrix, which can store translation, scale and rotation information.
    /// </summary>
    /// <remarks>
    /// Based on https://github.com/MonoGame/MonoGame/blob/develop/MonoGame.Framework/Matrix.cs
    /// </remarks>
    public struct Matrix
    {
        private static Matrix _identity = new Matrix(1f, 0f, 0f,
                                                     0f, 1f, 0f,
                                                     0f, 0f, 1f);

        /// <summary>
        /// A first row and first column value.
        /// </summary>
        public float M11;

        /// <summary>
        /// A first row and second column value.
        /// </summary>
        public float M12;

        /// <summary>
        /// A first row and third column value.
        /// </summary>
        public float M13;

        /// <summary>
        /// A second row and first column value.
        /// </summary>
        public float M21;

        /// <summary>
        /// A second row and second column value.
        /// </summary>
        public float M22;

        /// <summary>
        /// A second row and third column value.
        /// </summary>
        public float M23;

        /// <summary>
        /// A third row and first column value.
        /// </summary>
        public float M31;

        /// <summary>
        /// A third row and second column value.
        /// </summary>
        public float M32;

        /// <summary>
        /// A third row and third column value.
        /// </summary>
        public float M33;

        /// <summary>
        /// Constructs a matrix.
        /// </summary>
        /// <param name="m11">A first row and first column value.</param>
        /// <param name="m12">A first row and second column value.</param>
        /// <param name="m13">A first row and third column value.</param>
        /// <param name="m21">A second row and first column value.</param>
        /// <param name="m22">A second row and second column value.</param>
        /// <param name="m23">A second row and third column value.</param>
        /// <param name="m31">A third row and first column value.</param>
        /// <param name="m32">A third row and second column value.</param>
        /// <param name="m33">A third row and third column value.</param>
         public Matrix(float m11, float m12, float m13, 
                      float m21, float m22, float m23,
                      float m31, float m32, float m33)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <returns>The translation.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <remarks>
        /// See: https://en.wikipedia.org/wiki/Transformation_matrix
        /// </remarks>
        public static Matrix CreateTranslation(float x, float y)
        {
            var result = _identity;
            result.M13 = x;
            result.M23 = y;

            return result;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="left">The left <see cref="Doog.Matrix"/> to multiply.</param>
        /// <param name="right">The right <see cref="Doog.Matrix"/> to multiply.</param>
        /// <returns>The result matrix.</returns>
        /// <remarks>
        /// See: http://en.wikipedia.org/wiki/Matrix_multiplication
        /// </remarks>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            var m11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            var m12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;
            var m13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33;

            var m21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            var m22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
            var m23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33;

            var m31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31;
            var m32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32;
            var m33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33;

            left.M11 = m11;
            left.M12 = m12;
            left.M13 = m13;
            left.M21 = m21;
            left.M22 = m22;
            left.M23 = m23;
            left.M31 = m31;
            left.M32 = m32;
            left.M33 = m33;

            return left;
        }
    }
}