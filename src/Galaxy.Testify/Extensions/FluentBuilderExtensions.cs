using System;

namespace Galaxy.Testify.Extensions
{
    public static class FluentBuilderExtensions
    {
        public static T Was<T>(this IFluentBuilder<T> @this) where T : class => Copy(@this);
        public static T And<T>(this IFluentBuilder<T> @this) where T : class => Copy(@this);
        public static T With<T>(this IFluentBuilder<T> @this) where T : class => Copy(@this);
        public static T Has<T>(this IFluentBuilder<T> @this) where T : class => Copy(@this);
        public static T Had<T>(this IFluentBuilder<T> @this) where T : class => Copy(@this);

        private static T Copy<T>(this IFluentBuilder<T> @this) where T : class => @this as T;
    }
}
