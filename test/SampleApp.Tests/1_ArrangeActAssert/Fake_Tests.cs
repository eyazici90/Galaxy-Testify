using FluentAssertions;
using Galaxy.Testify;
using Galaxy.Testify.Extensions; 
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._1_ArrangeActAssert
{
    public class Fake_Tests : ArrangeActAssert<Fake, string>
    {
        [Fact]
        public void Should_return_upper_when_handle()
        {
            Arrange(() =>
            {
                Use.A<Message>();

                UseTheObjectMothers(typeof(ObjectMothers).Assembly);
            }).
            Act(async () =>
            {
                var msg = The<Message>();

                return await Sut.Handle(msg);
            }).
            Assert(() =>
            {
                var msg = The<Message>();

                Result.Should().NotBeNull();
                Result.Should().Be(msg.Name.ToUpper());
            });
        }

    }
}
