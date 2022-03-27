using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.IO;

namespace WebApplication3.Models
{
    public class PhoneRepository : IRepository<Phone>
    {
        static public List<Phone> Phones { get; set; } = new List<Phone>();
        static public string filePath = @"D:\uni\asp.net\WebApplication3\WebApplication3\Models\PhoneDatabase.json";
        public void Add(Phone item)
        {
            if (item != null)
            {
                Phones.Add(item);
                Serialize();
            }
        }

        public Phone Get(string lastname)
        {
            return Phones.Find(phone => phone.lastname == lastname);
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            Deserialize();
            Phones.OrderBy(phone => phone.lastname);
            return Phones;
        }

        public bool Remove(Phone item)
        {
            if (item == null)
            {
                return false;
            }
            Phones.Remove(item);
            Serialize();
            return true;
        }

        public void Update(Phone item)
        {
            if (item != null)
            {
                var phone = Get(item.lastname);
                Phones.Remove((Phone)phone);
                Phones.Add(item);
                Serialize();
            }
        }

        public void Serialize()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize<List<Phone>>(Phones));
        }

        public void Deserialize()
        {
            Phones = JsonSerializer.Deserialize<List<Phone>>(File.ReadAllText(filePath));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}