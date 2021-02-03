using System;
using System.Collections.Generic;
using System.Reflection;

namespace Galaxy.Testify
{
    public interface ITestContextResolver
    {
        T The<T>();
        IEnumerable<T> TheAll<T>();
    }
    public interface ITestContextRegistrar
    {
        TestContext.Result Use { get; }
        TestContext.Result UseThe<T>(T valueToSet) where T : class;
        TestContext.Result UseThe<T>(Func<T> factory) where T : class;
        TestContext.Result UseTheObjectMothers(params IObjectMother[] objectMothers);
        TestContext.Result UseTheObjectMothers(Assembly assembly);
    }

    public interface ITestContext : ITestContextRegistrar, ITestContextResolver
    {
    }
    public interface ITestContext<TSut> : ITestContext
        where TSut : class
    {
        TSut Sut { get; }
    }

    public interface ITestContext<TSut, TResult> : ITestContext<TSut>
        where TSut : class
    {
        TResult Result { get; set; }
    }

}