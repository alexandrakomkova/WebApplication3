using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string lastname { get; set; }
        public string phoneNumber { get; set; }

    }
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext() : base("Phonestore")
        {
        }
        public DbSet<Phone> phones { get; set; }
    }
}