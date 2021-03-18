using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key); //generic olmayan

        void Add(string key, object value, int duration);

        bool IsAdd(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);
    }
}
