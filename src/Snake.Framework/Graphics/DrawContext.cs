﻿using Snake.Framework.Texts;

namespace Snake.Framework.Graphics
{
    public class DrawContext : IDrawContext
    {
        public DrawContext(ICanvas canvas, ITextSystem textSystem)
        {
            Canvas = canvas;
            TextSystem = textSystem;
        }

        public ICanvas Canvas { get; private set; }
        public ITextSystem TextSystem { get; private set; }
	}
}
