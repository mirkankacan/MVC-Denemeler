using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Futbol.Models
{
    public class db:DbContext
    {
        public DbSet<Futbolcu> Futbolcus { get; set; }
    }
}