using System;
using System.Security.Authentication.ExtendedProtection;
using IOC.Demo.Interface;
using IOC.Demo.Service;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 使用 asp.net core 内置容器

            {
                // Nuget 包
                // 1.Microsoft.Extensions.DependencyInjection

                // 1 实例化 容器
                IServiceCollection serviceCollection = new ServiceCollection();

                // 2 注册服务
                serviceCollection.AddTransient<IService1, Service1>();

                // 3 获取服务
                ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                IService1 service1 = serviceProvider.GetService<IService1>();

                //service1.Show();
            }

            #endregion

            #region 构造函数注入

            {
                // 1、实例化容器
                IServiceCollection serviceCollection = new ServiceCollection();

                // 2 注册服务
                serviceCollection.AddTransient<IService1, Service1>();
                serviceCollection.AddTransient<IService2, Service2>();

                // 3 获取服务
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                //IService2 service2 = serviceProvider.GetService<IService2>();
                //service2.Show();
            }

            #endregion

            #region 生命周期

            //瞬时生命周期 AddTrAddTransient
            //每次创建都是新的实例
            {
                //实例化容器
                IServiceCollection serviceCollection = new ServiceCollection();

                //注册服务
                serviceCollection.AddTransient<IService1, Service1>();

                //获取服务
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                IService1 service1 = serviceProvider.GetService<IService1>();
                IService1 service2 = serviceProvider.GetService<IService1>();

                //比较两个实例是否为同一引用
                bool transientResult = object.ReferenceEquals(service1, service2);
                Console.WriteLine($"Transient :{transientResult}");
            }
            // 单例生命周期 AddSingleton
            // 在同一进程里 ，创建出来的都是同一个实例
            {
                //实例化容器
                IServiceCollection serviceCollection = new ServiceCollection();

                //注册服务
                serviceCollection.AddSingleton<IService1, Service1>();

                //获取服务
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                IService1 service1 = serviceProvider.GetService<IService1>();
                IService1 service2 = serviceProvider.GetService<IService1>();

                //比较两个实例的引用
                bool singletonResult = object.ReferenceEquals(service1, service2);
                Console.WriteLine($"Singleton :{singletonResult}");
            }

            // 作用域生命周期 AddScoped
            // 同一个作用域创建出来实例是同一个实例
            {
                //实例化容器
                IServiceCollection serviceCollection = new ServiceCollection();

                //注入服务
                serviceCollection.AddScoped<IService1, Service1>();

                //获取服务
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                IService1 service1 = serviceProvider.GetService<IService1>();
                
               // IServiceProvider serviceProvider1 = serviceCollection.BuildServiceProvider();
                IService1 service2 = serviceProvider.GetService<IService1>();
                
                //比较两个实例的引用
                bool singletonResult = object.ReferenceEquals(service1, service2);
                Console.WriteLine($"Scoped :{singletonResult}");
            }

            #endregion

            Console.WriteLine("Hello World!");
        }
    }
}