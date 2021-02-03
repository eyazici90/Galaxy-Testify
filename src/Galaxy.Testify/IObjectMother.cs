using System;

namespace Galaxy.Testify
{
    public interface IObjectMother
    {
        Type ApplyFor();
        object Create(ITestContextResolver resolver);
    }
}
