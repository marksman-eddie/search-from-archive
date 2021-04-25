using ArchiveSearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace search_from_archive.Database
{
    public class ArchiveContext_gms : DbContext
    {
        public ArchiveContext_gms(DbContextOptions<ArchiveContext_gms> archiveOptions) : base(archiveOptions)
        {

        }
        public DbSet<OutputDataModel> _OutputDataModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutputDataModel>().HasNoKey();
        }
    }
}
