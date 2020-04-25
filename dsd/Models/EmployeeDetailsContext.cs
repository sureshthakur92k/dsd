using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dsd.Models
{
    public class EmployeeDetailsContext : DbContext
    {
        public EmployeeDetailsContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDetailsContext, dsd.Migrations.Configuration>());
        }


        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<SubDivision> SubDivisions { get; set; }

        public DbSet<aaa> ABC { get; set; }
        public DbSet<TaskModels> Task { get; set; }
        public DbSet<FileModal> FileModal { get; set; }
        public DbSet<UserAssignedTask> UserAssignedTask { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}