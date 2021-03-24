using ArchiveSearch.Database.DbModel;
using ArchiveSearch.Models;
using Microsoft.EntityFrameworkCore;
using search_from_archive.Database.DbModel;

namespace ArchiveSearch.Database
{
    public class ArchiveContext : DbContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> archiveOptions) : base(archiveOptions)
        {

        }
        public DbSet<OutputDataModel> _OutputDataModels { get; set; }
        public DbSet<FoldersDbModel> folders { get; set; }
        public DbSet<SprDbModel> spr { get; set; }
        public DbSet<ExtProjectsCurProjectsModel> CurProjects { get; set; }
        public DbSet<ExtProjectsPersonalDeveloperModel> Personal_develop { get; set; }
        public DbSet<ExtProjectsPersonalChiefDepartModel> Personal_chiefDepart { get; set; }
        public DbSet<ExtProjectsPersonalChiefGrpModel> Personal_chiefGrp { get; set; }
        public DbSet<ExtProjectsPersonalGipModel> Personal_gip { get; set; }
        public DbSet<ExtProjectsPersonalMainExpertModel> Personal_mainExpert { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutputDataModel>().HasNoKey();
            modelBuilder.Entity<FoldersDbModel>().HasNoKey();
            modelBuilder.Entity<SprDbModel>().HasNoKey();
            modelBuilder.Entity<ExtProjectsCurProjectsModel>(cp =>
            {
                cp.HasNoKey();
                cp.ToView("Projects_objid");
            }
            );
            modelBuilder.Entity<ExtProjectsPersonalDeveloperModel>(p =>
            {
                p.HasNoKey();
                p.ToView("Projects_personal_develop");
            }
            );
            modelBuilder.Entity<ExtProjectsPersonalChiefDepartModel>(p =>
            {
                p.HasNoKey();
                p.ToView("Projects_personal_chiefDepart");
            }
            );
            modelBuilder.Entity<ExtProjectsPersonalChiefGrpModel>(p =>
            {
                p.HasNoKey();
                p.ToView("Projects_personal_chiefGrp");
            }
            );
            modelBuilder.Entity<ExtProjectsPersonalGipModel>(p =>
            {
                p.HasNoKey();
                p.ToView("Projects_personal_gip");
            }
            );
            modelBuilder.Entity<ExtProjectsPersonalMainExpertModel>(p =>
            {
                p.HasNoKey();
                p.ToView("Projects_personal_mainExpert");
            }
            );

        }


    }
}
