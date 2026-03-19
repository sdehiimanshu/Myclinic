using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyClinic.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MyClinic.Infrastructure.Data
{
    public class MyClinicDbContext : IdentityDbContext
    {
        public MyClinicDbContext(DbContextOptions<MyClinicDbContext> options) : base(options)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ContactQuery> ContactQueries { get; set; }
    }
}
