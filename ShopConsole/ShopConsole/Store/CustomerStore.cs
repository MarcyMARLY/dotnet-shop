using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShopLibrary.Models.User;

namespace ShopConsole
{
    public class CustomerStore: IStore<Customer>
    {
        private List<Customer> storeCollection;
        public string Path { get; set; }
        public List<Customer> GetCollection()
        {
            if (storeCollection == null)
            {
                var data = File.ReadAllLines(Path);
                storeCollection = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();
            }

            return storeCollection;
        }

        public Customer ConvertItem(string item)
        {
            var itemList = item.Split(';');
            return new Customer(itemList[0],itemList[1]){
                Username = itemList[0],
                password = itemList[1]
            };
        }

        public void WriteToFile(Customer t)
        {
            string res = t.Username + ";" + t.password;
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(res); 
            }
        }
    }
}