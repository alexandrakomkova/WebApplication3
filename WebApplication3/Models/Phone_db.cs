using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Phone_db
    {
        SortedSet<Phone> phones = null;
        public Phone_db() 
        {
            this.phones = new SortedSet<Phone>
            (
                new Phone[] { 
                    new Phone{lastname="fff", phoneNumber = "67890"},
                    new Phone{lastname="aaa", phoneNumber = "12345" },
                }
            );

        }
    }
}