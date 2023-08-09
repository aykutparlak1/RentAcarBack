using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); // asp.net core icin AddMemoryCache dediğimiz zaman MemoryCacheManagerda ctorumuzdaki IMemoryCache icin injectionumuzu yapıyor


            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//MemoryCache otamatik injectionuu ctor gerek yok
            //sadece microsoft icin
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
