using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;
using ShopLibrary.Models.User;

namespace ShopLibrary.Models.Store
{
    public class UserFileStorage: IChangeable<Customer>
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
            var cu =  new Customer(itemList[0],itemList[1]){
                Username = itemList[0],
                password = itemList[1]
            };
            cu.id = int.Parse(itemList[2]);
            return cu;
        }

        public void WriteToFile(Customer t)
        {
            string res = t.Username + ";" + t.password+";"+t.id;
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(res); 
            }
        }
    }
}