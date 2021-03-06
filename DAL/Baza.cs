﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Baza:DbContext
    {
        public Baza() : base("ERV")
        {
        }

        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<Dogadjaj> Dogadjaji { get; set; }


        //za onemogucavanje automatskog dodavanja mnozine
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
