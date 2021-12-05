using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public StudentsContext()
            : base(GetOptions("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=StudentsDb"))
        {
            
        }

        public StudentsContext(string connectionString)
            : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return optionsBuilder.Options;
        }
    }
}
