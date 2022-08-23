
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaNomina.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaNomina.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TaxPercentage> TaxPercentages { get; set; }
        public DbSet<User> UsersModel { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        public DbSet<SistemaNomina.Models.HorasExtras> HorasExtras { get; set; }
    }
}
