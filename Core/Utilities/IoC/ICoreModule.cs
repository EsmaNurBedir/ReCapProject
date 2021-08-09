using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Genel bagımlılıkları yükleme
        void Load(IServiceCollection serviceCollection);
    }
}
