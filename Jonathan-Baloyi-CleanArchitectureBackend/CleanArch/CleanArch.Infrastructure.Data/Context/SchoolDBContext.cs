using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data.Context
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
