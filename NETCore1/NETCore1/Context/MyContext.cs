﻿using Microsoft.EntityFrameworkCore;
using NETCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore1.Context
{
    public class MyContext : DbContext  //get away aplikasi dengan database
    {
        public MyContext(DbContextOptions<MyContext>options):base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }       
        public DbSet<Education> Educations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings{ get; set; }
        public DbSet<University> Universities{ get; set; }

        public DbSet<PersonViewModel> PersonViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Person -> Account
            modelBuilder.Entity<Person>()
                .HasOne(a => a.Account)
                .WithOne(p => p.Person)
                .HasForeignKey<Account>(a => a.NIK);

            // Account -> Profiling
            modelBuilder.Entity<Account>()
                .HasOne(pr => pr.Profiling) 
                .WithOne(a => a.Account)
                .HasForeignKey<Profiling>(pr => pr.NIK);

            // Education -> Profiling
            modelBuilder.Entity<Education>()
               .HasMany(pr => pr.Profilings)
               .WithOne(e => e.Education)
               .OnDelete(DeleteBehavior.SetNull);
            //Education -> University
            modelBuilder.Entity<Education>()
               .HasOne(u => u.University)
               .WithMany(e => e.Educations)
               .OnDelete(DeleteBehavior.SetNull);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }





    }
}
