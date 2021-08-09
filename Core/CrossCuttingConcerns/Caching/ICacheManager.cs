using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); //generic
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);//cachede var mı yoksa veri tabanından getir cacheye ekle 
        void Remove(string key);//key e göre silme
        void RemoveByPattern(string pattern);//ismi getle vs başlayanı uçur
    }
}
