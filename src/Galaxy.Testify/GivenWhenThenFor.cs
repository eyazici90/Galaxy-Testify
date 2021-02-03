using System;

namespace Galaxy.Testify
{
    public class GivenWhenThenFor<TSut, TResult> where TSut : class
    {
        public static GivenWhenThenFor<TSut, TResult> New { get; } = new GivenWhenThenFor<TSut, TResult>();
        public GivenResult<TSut, TResult> Given(Action<ITestContext<TSut, TResult>> given)
        {
            var ctx = new TestContext<TSut, TResult>();
            given(ctx);
            return new GivenResult<TSut, TResult>(ctx);
        }
    }

    public class GivenWhenThenFor
    {
        public static GivenWhenThenFor New { get; } = new GivenWhenThenFor();
        public GivenResult Given(Action<ITestContext> given)
        {
            var ctx = new TestContext();
            given(ctx);
            return new GivenResult(ctx);
        }
    }
}
