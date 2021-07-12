using CRMGuru.TestTask.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTaskWpf.Context
{
    internal class EfDataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public EfDataContext(DbContextOptions<EfDataContext> options) : base (options) { }
    }
}
