using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Who_wants_to_be_a_Milioner.Models;

namespace Who_wants_to_be_a_Milioner.Repository
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Question1> Question { get; set; }
        public DbSet<Answers> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Milioner;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }


    } 

}
