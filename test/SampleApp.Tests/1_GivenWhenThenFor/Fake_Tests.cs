using FluentAssertions;
using Galaxy.Testify;
using Galaxy.Testify.Extensions;
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._3_GivenWhenThenFor
{
    public class Fake_Tests : GivenWhenThenFor<Fake, string>
    {
        [Fact]
        public void Should_return_upper_when_handle()
        {
            Given(ctx =>
            {
                ctx.Use.A<Message>();
                ctx.UseTheObjectMothers(typeof(ObjectMothers).Assembly);
            }).
            When(async ctx =>
            {
                var msg = ctx.The<Message>();
                return await ctx.Sut.Handle(msg);
            }).
            Then(ctx =>
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
            GivenWhenThenFor<Fake, string>.New.
            Given(ctx =>
            {
                ctx.Use.A<Message>();
                ctx.UseTheObjectMothers(typeof(ObjectMothers).Assembly);
            }).
            When(async ctx =>
            {
                var msg = ctx.The<Message>();
                return await ctx.Sut.Handle(msg);
            }).
            Then(ctx =>
            {
                var msg = ctx.The<Message>();

                ctx.Result.Should().NotBeNull();
                ctx.Result.Should().Be(msg.Name.ToUpper());
            });
        }
        
    }
}
