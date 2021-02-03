using System;
using System.Threading.Tasks;

namespace Galaxy.Testify.Extensions
{
    public static class ArrangeActAssertExtensions
    {
        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
         Func<Task> act)
         where TSut : class
        {
            act().ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
            Func<TResult> act)
            where TSut : class
        {
            var result = act();

            @this.TestContext.Result = result;

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
           Func<ITestContext<TSut, TResult>, Task> act)
           where TSut : class
        {
            act(@this.TestContext).ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
           Func<Task<TResult>> act)
           where TSut : class
        {
            var result = act().ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            @this.TestContext.Result = result;

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
            Func<ITestContext<TSut, TResult>, TResult> act)
            where TSut : class
        {
            var result = act(@this.TestContext);

            @this.TestContext.Result = result;

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static ActResult Act(this ArrangeResult @this,
           Func<Task> act)
        {
            act().ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new ActResult(@this.TestContext);
        }

        public static ActResult<TSut, TResult> Act<TSut, TResult>(this ArrangeResult<TSut, TResult> @this,
            Func<ITestContext<TSut, TResult>, Task<TResult>> act)
            where TSut : class
        {
            var result = act(@this.TestContext).ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            @this.TestContext.Result = result;

            return new ActResult<TSut, TResult>(@this.TestContext);
        }

        public static void Assert(this ActResult _,
         Action act) 
        {
            act();
        }

        public static void Assert<TSut, TResult>(this ActResult<TSut, TResult> _,
           Action act)
           where TSut : class
        {
            act();
        }

        public static void Assert<TSut, TResult>(this ActResult<TSut, TResult> @this,
            Action<ITestContext<TSut, TResult>> act)
            where TSut : class
        {
            act(@this.TestContext);
        }
    }
}
