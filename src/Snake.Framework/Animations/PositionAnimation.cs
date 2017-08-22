﻿using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A position animation.
    /// </summary>
    public class PositionAnimation : AnimationBase<Transform>
    {
        private Point? originalFrom;
        private Point from;
        private Point to;

        public PositionAnimation(Transform owner, string name, Point to, float duration)
            : base(owner, name, duration)
        {
            this.to = to;
        }

        public override void Play()
        {
            if (!originalFrom.HasValue)
            {
                originalFrom = Owner.Position;
            }

            this.from = originalFrom.Value;
            base.Play();
        }

        protected override void UpdateValue(float time)
        {
            Owner.Position = new Point(
                Easing.Calculate(from.X, to.X, time),
                Easing.Calculate(from.Y, to.Y, time));
        }

        public override void Reset()
        {
            Owner.Position = from;
            base.Reset();
        }

        public override void Reverse()
        {
            var temp = from;
            from = to;
            to = temp;
        }
    }
}