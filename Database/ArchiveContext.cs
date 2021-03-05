using ArchiveSearch.Database.DbModel;
using ArchiveSearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveSearch.Database
{
    public class ArchiveContext : DbContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> archiveOptions) : base(archiveOptions)
        {

        }
        public DbSet<OutputDataModel> _OutputDataModels { get; set; }
        public DbSet<FoldersDbModel> folders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutputDataModel>().HasNoKey();
            modelBuilder.Entity<FoldersDbModel>().HasNoKey();
        }


    }
}
