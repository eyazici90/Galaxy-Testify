namespace Galaxy.Testify
{
    public class WhenResult<TSut, TResult> where TSut : class
    {
        public ITestContext<TSut, TResult> TestContext { get; }
        public WhenResult(ITestContext<TSut, TResult> testContext) => TestContext = testContext;
    }
    public class WhenResult<TSut> where TSut : class
    {
        public ITestContext<TSut> TestContext { get; }
        public WhenResult(ITestContext<TSut> testContext) => TestContext = testContext;
    }

    public class WhenResult
    {
        public ITestContext TestContext { get; }
        public WhenResult(ITestContext testContext) => TestContext = testContext;
    }

    public class GivenResult
    {
        public ITestContext TestContext { get; }
        public GivenResult(ITestContext testContext) => TestContext = testContext;

    }

    public class GivenResult<TSut, TResult> where TSut : class
    {
        public ITestContext<TSut, TResult> TestContext { get; }
        public GivenResult(ITestContext<TSut, TResult> testContext) => TestContext = testContext;

    }

    public class ArrangeResult
    {
        public ITestContext TestContext { get; }
        public ArrangeResult(ITestContext testContext) => TestContext = testContext;
    }

    public class ArrangeResult<TSut, TResult> where TSut : class
    {
        public ITestContext<TSut, TResult> TestContext { get; }
        public ArrangeResult(ITestContext<TSut, TResult> testContext) => TestContext = testContext;
    }

    public class ActResult<TSut, TResult> where TSut : class
    {
        public ITestContext<TSut, TResult> TestContext { get; }
        public ActResult(ITestContext<TSut, TResult> testContext) => TestContext = testContext;
    }
    public class ActResult
    {
        public ITestContext TestContext { get; }
        public ActResult(ITestContext testContext) => TestContext = testContext;
    }

    public class FixtureResult<T>
    {
        public T Result { get; }
        public FixtureResult(T result)
        {
            Result = result;
        }
    }
}
