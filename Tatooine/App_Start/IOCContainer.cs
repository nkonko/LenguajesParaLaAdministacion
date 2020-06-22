﻿namespace Tatooine.App_Start
{
    using Autofac;
    using BLL;
    using BLL.Implementation;
    using BLL.Interfaces;
    using DAL;
    using DAL.Implementation;
    using DAL.Implementation.Helpers;
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
            contBuilder.RegisterType<PatentDao>().As<IPatentDao>().SingleInstance();
            contBuilder.RegisterType<AccountBusiness>().As<IAccountBusiness>().SingleInstance();
            contBuilder.RegisterType<FamilyBusiness>().As<IFamilyBusiness>().SingleInstance();
            contBuilder.RegisterType<PatentBusiness>().As<IPatentBusiness>().SingleInstance();
            contBuilder.RegisterType<DigitVerifier>().As<IDigitVerifier>().SingleInstance();
            contBuilder.RegisterType<RestoreDao>().As<IRestoreDao>().SingleInstance();
            return contBuilder.Build();
        }
    }
}