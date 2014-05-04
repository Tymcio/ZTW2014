using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WnioskiOnline.Models
{
    public class WnioskiContext : DbContext
    {
        public WnioskiContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Wniosek> Wnioski { get; set; }
    }
}