﻿using System;
namespace Doog
{
	/// <summary>
	/// A linear easing with no easing and no acceleration.
	/// </summary>
	public class LinearEasing : IEasing
    {
        public float Calculate(float time)
        {
            return time;
        }
    }
}