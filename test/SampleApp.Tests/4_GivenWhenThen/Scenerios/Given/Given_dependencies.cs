using Galaxy.Testify;
using Galaxy.Testify.Extensions;
using static SampleApp.Sample;

namespace SampleApp.Tests._4_GivenWhenThen.Scenerios.Given
{
    public abstract class Given_dependencies : GivenWhenThen<Fake, string>
    {
        public Given_dependencies()
        {
            Use.A<Message>();

            UseTheObjectMothers(typeof(ObjectMothers).Assembly);
        }
    }
}
