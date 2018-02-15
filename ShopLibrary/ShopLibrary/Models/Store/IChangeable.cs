using System.Collections.Generic;

namespace ShopLibrary.Models.Store
{
    public interface IChangeable<T>
    {
        string Path { get; set; }
        List<T> GetCollection();
        T ConvertItem(string item);
        void WriteToFile(T t);
    }
}