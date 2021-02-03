using System;
using System.Threading.Tasks;

namespace Galaxy.Testify
{
    public abstract class GivenWhenThen<TSut, TResult> : GivenBase<TSut, TResult> where TSut : class
    {
        protected virtual WhenResult<TSut, TResult> When(Func<Task<TResult>> whenFunc)
        {
            EnsureContainerInitialized();

            Result = whenFunc()
                 .ConfigureAwait(false)
                 .GetAwaiter()
                 .GetResult();

            return new WhenResult<TSut, TResult>(this);
        }

        protected virtual void Then(Action<TResult> act)
        {
            EnsureContainerInitialized();
            act(Result);
        }
    }
    public abstract class GivenWhenThen<TSut> : GivenBase<TSut> where TSut : class
    {
        protected virtual WhenResult<TSut> When(Func<Task> whenFunc)
        {
            EnsureContainerInitialized();

            whenFunc()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new WhenResult<TSut>(this);
        }

        protected virtual void Then(Action act)
        {
            EnsureContainerInitialized();
            act();
        }
    }

    public abstract class GivenWhenThen : GivenBase
    {
        private Func<object, Task> _whenLaterResultAsync;

        private Func<Task> _whenLaterAsync;

        public Func<object, Task> WhenResultAction
        {
            get { return _whenLaterResultAsync; }
            set
            {
                EnsureContainerInitialized();
                _whenLaterResultAsync = value;
            }
        }
        public Func<Task> WhenAction
        {
            get { return _whenLaterAsync; }
            set
            {
                EnsureContainerInitialized();
                _whenLaterAsync = value;
            }
        }
        protected virtual WhenResult When(Func<Task> whenFunc)
        {
            EnsureContainerInitialized();

            whenFunc()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new WhenResult(this);
        }

        protected virtual WhenResult When<TCommand>(TCommand cmd, Func<TCommand, Task> whenFunc)
        {
            EnsureContainerInitialized();

            whenFunc(cmd)
             .ConfigureAwait(false)
             .GetAwaiter()
             .GetResult();

            return new WhenResult(this);
        }

        protected virtual void Then(Action act)
        {
            EnsureContainerInitialized();
            act();
        }

        protected virtual void WhenLater(Func<Task> whenLaterFunc)
        {
            WhenAction = async () => await whenLaterFunc();
        }
        protected virtual void WhenLater<TCommand>(TCommand cmd, Func<TCommand, Task> whenLaterFunc)
        {
            WhenResultAction = async c => await whenLaterFunc(cmd);
        }

    }
}
