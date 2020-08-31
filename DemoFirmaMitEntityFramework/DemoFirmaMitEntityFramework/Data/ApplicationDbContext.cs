using System;
using System.Collections.Generic;
using System.Text;
using DemoFirmaMitEntityFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoFirmaMitEntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Angestellte> Mitarbeiter { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
