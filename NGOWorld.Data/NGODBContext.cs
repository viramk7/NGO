using Microsoft.EntityFrameworkCore;
using NGOWorld.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGOWorld.Data
{
    public class NGODBContext : DbContext
    {
        public NGODBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<tblDoctor> tblDoctor { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
