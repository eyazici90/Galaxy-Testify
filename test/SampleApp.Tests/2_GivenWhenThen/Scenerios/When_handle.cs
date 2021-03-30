using FluentAssertions;
using SampleApp.Tests._4_GivenWhenThen.Scenerios.Given;
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._4_GivenWhenThen.Scenerios
{
    public class When_handle : Given_dependencies
    {
        public When_handle()
        {
            When(async () =>
            {
                var msg = The<Message>();

                return await Sut.Handle(msg).ConfigureAwait(false);
            });
        }

        [Fact]
        public void Then_it_should_not_be_null()
        {
            Result.Should().NotBeNull();
        }

        [Fact]
        public void Then_it_should_be_upper()
        {
            var msg = The<Message>();
            Result.Should().Be(msg.Name.ToUpper());
        }

    }
}
