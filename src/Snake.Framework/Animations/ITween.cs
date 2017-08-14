﻿using System;
using Snake.Framework.Behaviors;

namespace Snake.Framework.Animations
{
    public enum TweenState
    {
        Playing,
        Paused,
        Stopped
    }

    /// <summary>
    /// Define an interface for a tweening component.
    /// </summary>
    public interface ITween : IUpdatable
    {
        event EventHandler<TweenEndedEventArgs> Ended;

        TweenState State { get; }
		IEase Ease { get; set; }
        void Play();
        void Pause();
        void Resume();
        void Stop();
        void Reset();
        void Reverse();
    }
}