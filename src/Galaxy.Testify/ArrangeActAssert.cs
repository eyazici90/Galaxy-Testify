using System;

namespace Galaxy.Testify
{
    public class ArrangeActAssert<TSut, TResult> : TestContext<TSut, TResult>
        where TSut : class
    {
        public ArrangeResult<TSut, TResult> Arrange(Action arrange)
        {
            arrange();
            return new ArrangeResult<TSut, TResult>(this);
        }
    }

    public class ArrangeActAssert : TestContext
    {
        public ArrangeResult Arrange(Action arrange)
        {
            arrange();
            return new ArrangeResult(this);
        }
    }
}
