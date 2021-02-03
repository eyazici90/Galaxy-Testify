using Microsoft.Extensions.DependencyInjection;
using Galaxy.Testify.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Galaxy.Testify
{
    public class TestContext : ITestContext, IDisposable
    {
        private IServiceProvider ServiceProvider { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        public TestContext() => ServiceCollection = new ServiceCollection();

        public virtual T The<T>() => GetService<T>();

        public virtual IEnumerable<T> TheAll<T>() => GetServices<T>();

        public virtual Result SetThe<T>() where T : class
        {
            ServiceCollection.AddTransient<T>();
            return ToResult();
        }

        public virtual Result SetThe<T>(Func<T> factory) where T : class
        {
            var @obj = factory();
            ServiceCollection.AddTransient(_ => @obj);
            return ToResult();
        }

        public virtual Result Use => ToResult();

        public virtual Result UseThe<T>(T valueToSet) where T : class => UseTheInternal(valueToSet, ServiceLifetime.Transient);

        public virtual Result UseThe<T>(Func<T> valueToSet) where T : class => UseTheInternal(valueToSet(), ServiceLifetime.Transient);

        public virtual Result UseTheObjectMother(IObjectMother objectMother) =>
          UseThe(services => services.Add(new ServiceDescriptor(
                   objectMother.ApplyFor(),
                   _ => objectMother.Create(this),
                   ServiceLifetime.Transient
              )));

        public virtual Result UseTheObjectMothers(params IObjectMother[] objectMothers)
        {
            foreach (var objectMother in objectMothers)
            {
                UseTheObjectMother(objectMother);
            }
            return ToResult();
        }

        public virtual Result UseTheObjectMothers(Assembly assembly)
        {
            var objectMotherTypes = assembly.GetObjectMothers();

            foreach (var oType in objectMotherTypes)
            {
                var objectMother = ActivatorUtilities.CreateInstance(ServiceProvider, oType) as IObjectMother;

                UseTheObjectMother(objectMother);
            }

            return ToResult();
        }
        public Result UseTheInternal<T>(T valueToSet,
            ServiceLifetime serviceLifetime)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(T),
                _ => valueToSet,
                serviceLifetime);

            ServiceCollection.Add(serviceDescriptor);

            return ToResult();
        }

        public Result UseThe(Action<IServiceCollection> use)
        {
            use(ServiceCollection);
            return ToResult();
        }

        internal Result Register(Action<IServiceCollection> act)
        {
            act(ServiceCollection);
            return ToResult();
        }

        private T GetService<T>()
        {
            EnsureContainerInitialized();
            return ServiceProvider.GetService<T>();
        }

        private IEnumerable<T> GetServices<T>()
        {
            EnsureContainerInitialized();
            return ServiceProvider.GetServices<T>();
        }

        protected virtual void EnsureContainerInitialized()
        {
            if (ServiceProvider == null) InitializeContainer();
        }

        private void InitializeContainer()
        {
            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        public class Result
        {
            public TestContext State { get; }
            public Result(TestContext state) => State = state;
        }

        private Result ToResult() => new Result(this);

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServiceProvider = null;
            }
        }
    }

    public class TestContext<TSut, TResult> : TestContext<TSut>, ITestContext<TSut, TResult>
        where TSut : class
    {
        public TestContext() => SetThe<TSut>();
        public new TResult Result { get; set; }
    }

    public class TestContext<TSut> : TestContext, ITestContext<TSut>
        where TSut : class
    {
        public TestContext() => SetThe<TSut>();

        public TSut Sut => The<TSut>();
    }
}
