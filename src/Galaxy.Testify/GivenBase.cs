using System;
using System.Threading.Tasks;

namespace Galaxy.Testify
{
    public abstract class GivenBase : TestContext
    {
        public GivenResult Given(Action action)
        {
            action();
            EnsureContainerInitialized();
            return new GivenResult(this);
        }

        public GivenResult Given(Func<Task> givenFunc) => Given(() => givenFunc().ConfigureAwait(false).GetAwaiter().GetResult());

    }

    public abstract class GivenBase<TSut> : TestContext<TSut>
        where TSut : class
    {
        public GivenResult Given(Action action)
        {
            action();
            EnsureContainerInitialized();
            return new GivenResult(this);
        }

        public GivenResult Given(Func<Task> givenFunc) => Given(() => givenFunc().ConfigureAwait(false).GetAwaiter().GetResult());

    }

    public abstract class GivenBase<TSut, TResult> : TestContext<TSut, TResult>
        where TSut : class
    {
        public GivenResult Given(Action action)
        {
            action();
            EnsureContainerInitialized();
            return new GivenResult(this);
        }

        public GivenResult Given(Func<Task> givenFunc) => Given(() => givenFunc().ConfigureAwait(false).GetAwaiter().GetResult());

    }
}
