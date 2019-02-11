﻿using System;

namespace Doog
{
	/// <summary>
	/// An InExpo easing.
	/// </summary>
	public class InExpoEasing : IEasing
    {
        public float Calculate(float time)
        {
            return time.EqualsTo(0.0f) ? time : (float) Math.Pow(2, 10 * (time - 1));
		}
    }

	/// <summary>
	/// An OutExpo easing.
	/// </summary>
	public class OutExpoEasing : IEasing
	{
        public float Calculate(float time)
		{
            return time.EqualsTo(1.0f) ? time : 1 - (float) Math.Pow(2, -10 * time);
		}
	}

	/// <summary>
	/// An InOutExpo easing.
	/// </summary>
	public class InOutExpoEasing : IEasing
	{
        public float Calculate(float time)
		{
            if (time.EqualsTo(0.0f) || time.EqualsTo(1.0f)) 
            { 
                return time;
            }

			if (time < 0.5f)
			{
				return 0.5f * (float) Math.Pow(2, (20 * time) - 10);
			}
			else
			{
				return -0.5f * (float) Math.Pow(2, (-20 * time) + 10) + 1;
			}
		}
	}
}
