namespace Tatooine.App_Start
{
    using Autofac;

    public static class IOCContainer
    {
        private static IContainer container;

        static IOCContainer()
        {
            container = CreateContainer();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static IContainer CreateContainer()
        {
            var contBuilder = new ContainerBuilder();

            return contBuilder.Build();
        }
    }
}