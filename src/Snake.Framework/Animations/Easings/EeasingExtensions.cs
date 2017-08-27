﻿using System;
namespace Snake.Framework.Animations
{
    public static class EeasingExtensions
    {
		public static float Calculate(this IEasing easing, float start, float target, float time)
		{
			return start + (target - start) * easing.Calculate(time);
		}
    }
}