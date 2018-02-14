namespace ShopLibrary.Models.Store
{
    public interface IChangeable
    {
        string GetPathToFile();
        void ReadFromFile();
        void SaveToFile();
    }
}