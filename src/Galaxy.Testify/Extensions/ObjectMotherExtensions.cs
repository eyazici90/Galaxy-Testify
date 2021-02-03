using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 

namespace Galaxy.Testify.Extensions
{
    public static class ObjectMotherExtensions
    {
        public static IEnumerable<Type> GetObjectMothers(this Assembly @this) => GetAllTypesFrom<IObjectMother>(@this);
        private static IEnumerable<Type> GetAllTypesFrom<T>(Assembly @this) => @this.GetExportedTypes().Where(t => typeof(T).IsAssignableFrom(t));
    }
}
