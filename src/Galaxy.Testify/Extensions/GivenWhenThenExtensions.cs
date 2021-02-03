using System;
using System.Threading.Tasks;

namespace Galaxy.Testify.Extensions
{
    public static class GivenWhenThenExtensions
    {
        public static WhenResult<TSut, TResult> When<TSut, TResult>(this GivenResult<TSut, TResult> @this,
           Func<Task> when) where TSut : class
        {
            when().ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new WhenResult<TSut, TResult>(@this.TestContext);
        }

        public static WhenResult<TSut, TResult> When<TSut, TResult>(this GivenResult<TSut, TResult> @this,
            Func<Task<TResult>> when) where TSut : class
        {
            var result = when()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            @this.TestContext.Result = result;

            return new WhenResult<TSut, TResult>(@this.TestContext);
        }

        public static WhenResult When(this GivenResult @this, Func<Task> when)
        {
            when()
                 .ConfigureAwait(false)
                 .GetAwaiter()
                 .GetResult();

            return new WhenResult(@this.TestContext);
        }
        public static WhenResult<TSut, TResult> When<TSut, TResult>(this GivenResult<TSut, TResult> @this,
          Func<ITestContext<TSut, TResult>, Task> when) where TSut : class
        {
            when(@this.TestContext).ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            return new WhenResult<TSut, TResult>(@this.TestContext);
        }

        public static WhenResult<TSut, TResult> When<TSut, TResult>(this GivenResult<TSut, TResult> @this,
            Func<ITestContext<TSut, TResult>, Task<TResult>> when) where TSut : class
        {
            var result = when(@this.TestContext)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            @this.TestContext.Result = result;

            return new WhenResult<TSut, TResult>(@this.TestContext);
        }

        public static WhenResult When(this GivenResult @this, Func<ITestContext, Task> when)
        {
            when(@this.TestContext)
                 .ConfigureAwait(false)
                 .GetAwaiter()
                 .GetResult();

            return new WhenResult(@this.TestContext);
        }
        public static void Then(this WhenResult @this, Action<ITestContext> then) => then(@this.TestContext);
        public static void Then<TSut>(this WhenResult<TSut> @this, Action<ITestContext<TSut>> then)
         where TSut : class => then(@this.TestContext);

        public static void Then<TSut, TResult>(this WhenResult<TSut, TResult> @this, Action<ITestContext<TSut, TResult>> then)
              where TSut : class => then(@this.TestContext);
    }
}
