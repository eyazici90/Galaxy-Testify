using FluentAssertions;
using Galaxy.Testify;
using Galaxy.Testify.Extensions;
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._2_ArrangeActAssertFor
{
    public class Fake_Tests : ArrangeActAssertFor<Fake, string>
    { 
        [Fact]
        public void Should_return_upper_when_handle()
        { 
            Arrange(ctx =>
            {
                ctx.Use.A<Message>();
                ctx.UseTheObjectMothers(typeof(ObjectMothers).Assembly);
            }).
            Act(async ctx =>
            {
                var msg = ctx.The<Message>();
                return await ctx.Sut.Handle(msg);
            }).
            Assert(ctx =>
            {
                var msg = ctx.The<Message>();

                ctx.Result.Should().NotBeNull();
                ctx.Result.Should().Be(msg.Name.ToUpper());
            });
        }
    }

    public class Fake_Tests_2
    {
        [Fact]
        public void Should_return_upper_when_handle()
        {
            ArrangeActAssertFor<Fake, string>.New.
            Arrange(ctx =>
            {
                ctx.Use.A<Message>();
                ctx.UseTheObjectMothers(typeof(ObjectMothers).Assembly);
            }).
            Act(async ctx =>
            {
                var msg = ctx.The<Message>();
                return await ctx.Sut.Handle(msg);
            }).
            Assert(ctx =>
            {
                var msg = ctx.The<Message>();

                ctx.Result.Should().NotBeNull();
                ctx.Result.Should().Be(msg.Name.ToUpper());
            });
        } 
    }

}
