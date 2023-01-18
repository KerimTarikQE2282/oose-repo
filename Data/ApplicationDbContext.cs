﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)

        {

        }
        public DbSet<Patients> Patients{ get; set; }
        public DbSet<Hospitals> Hospitals { get; set;}
    }
}