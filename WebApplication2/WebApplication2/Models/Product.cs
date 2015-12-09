using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }

    public class myDBContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
    }

    public class MyLogContext : DbContext
    {
        public DbSet<Log> Log { get; set; }
    }

    public class Log
    {
        [Key]
        public int LogID { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
    }
}