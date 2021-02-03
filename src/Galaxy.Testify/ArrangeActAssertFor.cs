using System;

namespace Galaxy.Testify
{
    public class ArrangeActAssertFor<TSut, TResult> where TSut : class
    {
        public static ArrangeActAssertFor<TSut, TResult> New { get; } = new ArrangeActAssertFor<TSut, TResult>();
        public ArrangeResult<TSut, TResult> Arrange(Action<ITestContext<TSut, TResult>> arrange)
        {
            var ctx = new TestContext<TSut, TResult>();
            arrange(ctx);
            return new ArrangeResult<TSut, TResult>(ctx);
        }
    }

    public class ArrangeActAssertFor
    {
        public static ArrangeActAssertFor New { get; } = new ArrangeActAssertFor();
        public ArrangeResult Arrange(Action<ITestContext> arrange)
        {
            var ctx = new TestContext();
            arrange(ctx);
            return new ArrangeResult(ctx);
        }
    }
}
