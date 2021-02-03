using Microsoft.Extensions.DependencyInjection;
using Galaxy.Testify.Internal;
using System;
using AutoFixture;

namespace Galaxy.Testify.Extensions
{
    public static class TestContextExtensions
    {
        public static TestContext.Result A<T>(this TestContext.Result @this,
           Action<T> mutator) where T : class
        {
            var @obj = TestFixture.Value.Create<T>();
            mutator(@obj);
            return @this.State.Register(services => services.AddTransient(_ => @obj));
        }
        public static TestContext.Result A<T>(this TestContext.Result @this) where T : class => A<T>(@this, _ => { });
        public static TestContext.Result An<T>(this TestContext.Result @this) where T : class => A<T>(@this);
        public static TestContext.Result An<T>(this TestContext.Result @this, Action<T> mutator) where T : class => A(@this, mutator);
    }
}
