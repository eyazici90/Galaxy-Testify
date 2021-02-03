using Moq;
using Galaxy.Testify;
using System;
using static SampleApp.Sample;

namespace SampleApp.Tests
{
    public static class ObjectMothers
    {
        public class Dependency1Mother : IObjectMother
        {
            public Type ApplyFor() => typeof(IDependency1);

            public object Create(ITestContextResolver resolver)
            {
                var moq = new Mock<IDependency1>();

                moq.Setup(m => m.DoSomething())
                    .ReturnsAsync("Result1");

                return moq.Object;
            }
        }
        public class Dependency2Mother : IObjectMother
        {
            public Type ApplyFor() => typeof(IDependency2);

            public object Create(ITestContextResolver resolver)
            {
                var moq = new Mock<IDependency2>();

                moq.Setup(m => m.DoSomething())
                    .ReturnsAsync("Result2");

                return moq.Object;
            }
        }
        public class Dependency3Mother : IObjectMother
        {
            public Type ApplyFor() => typeof(IDependency3);

            public object Create(ITestContextResolver resolver)
            {
                var moq = new Mock<IDependency3>();

                moq.Setup(m => m.DoSomething())
                    .ReturnsAsync("Result3");

                return moq.Object;
            }
        }
        public class Dependency4Mother : IObjectMother
        {
            public Type ApplyFor() => typeof(IDependency4);

            public object Create(ITestContextResolver resolver)
            {
                var moq = new Mock<IDependency4>();

                moq.Setup(m => m.DoSomething())
                    .ReturnsAsync("Result4");

                return moq.Object;
            }
        }
    }
}
