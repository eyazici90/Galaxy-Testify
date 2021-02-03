using FluentAssertions;
using Galaxy.Testify;
using Galaxy.Testify.Extensions;
using System;
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._5_Fluenty.Scenerios
{
    public class When_add : Given_builders<OrderService>
    {
        [Fact]
        public void Should_not_throw()
        {
            Action whenFunc = () => When(async () =>
              {
                  var order = The<Order>();
                  await Sut.Add(order);
              });

            whenFunc.Should().NotThrow();
        }
    }

    public class Given_builders<TSut> : GivenWhenThen<TSut>
        where TSut : class
    {
        public Given_builders()
        {
            var product = A.Product().With().Code("1Eqa").Named("Jacket").Build();

            var order = An.Order().Was().StatedAs("Pending").Had().Product(product).CreatedAt(DateTime.Now).
                By.Customer().Named("Jack").With().AccountNumber("123").LocatedAt(7).Build();

            UseThe(order);
        }

        public BuilderFactory An => A;
        public BuilderFactory A => new BuilderFactory();
    }

    public class BuilderFactory
    {
        public Builders.OrderBuilder Order() => new Builders.OrderBuilder();

        public Builders.ProductBuilder Product() => new Builders.ProductBuilder();
    }
}
