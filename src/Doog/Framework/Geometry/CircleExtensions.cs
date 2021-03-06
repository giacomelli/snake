﻿using System;

namespace Doog
{

    /// <summary>
    /// Circle extension methods.
    /// </summary>
    public static class CircleExtensions
    {
        /// <summary>
        /// Iterates through the circle points.
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <param name="step">Action called each point iterate.</param>
        /// <param name="radiusStep">The radius step.</param>
        /// <param name="degreesStepSize">The degrees step size.</param>
        /// <remarks>
        /// http://www.mathopenref.com/coordcirclealgorithm.html
        /// </remarks> 
        public static void Iterate(this ICircle circle, Action<float, float> step, float radiusStep = 1f, float degreesStepSize = 1f)
        {
            if (radiusStep <= 0)
            {
                throw new ArgumentOutOfRangeException("radiusStep", "radiusStep should be a non-zero positive value.");
            }

            if (degreesStepSize <= 0)
            {
                throw new ArgumentOutOfRangeException("degreesStepSize", "degreesStepSize should be a non-zero positive value.");
            }

            var center = circle.GetCenter();

            for (var r = circle.Radius; r > 0; r -= radiusStep)
            {
                for (var theta = 0f; theta < 360f; theta += degreesStepSize)
                {
                    var point = Circle.GetPoint(center, r, theta);
                    step(point.X, point.Y);
                }
            }

        }
    }
}