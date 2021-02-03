using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;
using static SampleApp.Sample;

namespace SampleApp.Tests._0_Original
{
    public class Fake_Tests
    {
        [Fact]
        public async Task Should_return_upper_when_handle()
        {
            // explictly creating setup objects
        
            var msg = new Message { Name = "Amsterdam" }; //autofixture, fakeiteasy, bogus?

            // many mocking clutters test to much which does not add any value
            var moq1 = new Mock<IDependency1>();

            moq1.Setup(m => m.DoSomething())
                .ReturnsAsync("Result1");

            var moq2 = new Mock<IDependency2>();

            moq2.Setup(m => m.DoSomething())
                .ReturnsAsync("Result2");

            var moq3 = new Mock<IDependency3>();

            moq3.Setup(m => m.DoSomething())
                .ReturnsAsync("Result3");

            var moq4 = new Mock<IDependency4>();

            moq4.Setup(m => m.DoSomething())
                .ReturnsAsync("Result4"); 

            // explict creating sut. I you wanna add new dependency to sut, prepare ur self to update all tests.
            // naming differs to different authors
            var fake = new Fake(moq1.Object, moq2.Object, moq3.Object, moq4.Object);

            var result = await fake.Handle(msg); 

            // Multiple assertion makes things hard to catch. What exaclty fails?
            result.Should().NotBeNull();
            result.Should().Be(msg.Name.ToUpper());

            // No structure of test suite what exacly is the setup code?
        }
    }
}
