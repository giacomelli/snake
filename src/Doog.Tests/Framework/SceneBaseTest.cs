﻿using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework
{
    [TestFixture]
    public class SceneBaseTest
    {
        [Test]
        public void Initialize_Default_Methods()
        {
            var context = Substitute.For<IWorldContext>();
            var target = Substitute.ForPartsOf<SceneBase>(context);
            target.Initialize();
            target.Update();
            target.Draw(null);
        }
    }
}
