namespace Tatooine.App_Start
{
    using Autofac;
    using BLL;
    using DAL;
    using DAL.Implementation;
    using DAL.Interfaces;

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
            contBuilder.RegisterType<UserBusiness>().As<IUserBusiness>().SingleInstance();
            contBuilder.RegisterType<UserDao>().As<IUserDao>().SingleInstance();
            contBuilder.RegisterType<FamilyDao>().As<IFamilyDao>().SingleInstance();
            return contBuilder.Build();
        }
    }
}