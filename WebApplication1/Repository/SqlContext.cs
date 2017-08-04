using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Owin.Logging;

namespace WebApplication1.Repository
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("name=SqlContext")
        {
        }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<Rate> Rate { get; set; }
    }
}