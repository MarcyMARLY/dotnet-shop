using System.Collections.Generic;

namespace ShopConsole
{
    public interface IStore<T>
    {
        string Path { get; set; }
        List<T> GetCollection();
        T ConvertItem(string item);
        void WriteToFile(T t);
    }
}