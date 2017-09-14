﻿using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class Food : RectangleComponent, IDrawable, ICollidable
	{
        public static readonly Point DefaultScale = Point.Zero;

		public Food(IWorldContext context)
            : base(0, 0, context)
		{
            Sprite = 'o';
            Transform.Scale = DefaultScale;
     	}

  		public void OnCollision(Collision collision)
		{
            var otherTag = collision.Other.Tag;

            if (otherTag != "Food" &&  otherTag != "Snake")
            {
                Enabled = false;
            }
		}

        protected override void OnEnabled()
        {
            base.OnEnabled();
            Transform.Enabled = true;
        }

        protected override void OnDisabled()
        {
            base.OnDisabled();
            Transform.Enabled = false;
        }
	}
}
