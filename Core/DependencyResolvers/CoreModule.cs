using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //servis bagımlılıklarımızı çözümleyecegimiz yer(paketler)
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//microsoftun  kendisinin rediste bu yok hazır instance oluşturuyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//redisCacheManager
            serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
