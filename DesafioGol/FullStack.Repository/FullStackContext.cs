using Microsoft.EntityFrameworkCore;
using FullStack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Model;

namespace FullStackGol.Repository.DataContext
{
    public class FullStackContext : DbContext
    {
        public FullStackContext(DbContextOptions<FullStackContext> options) : base(options) 
        {

        }

        public DbSet<Passagem> Passagens { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Passagem>().HasKey(PK => new { PK.PassagemId});
        //} 
    }
}
