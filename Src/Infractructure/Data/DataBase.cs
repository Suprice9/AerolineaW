using Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Infractructure.Data
{
    public class DataBase:DbContext
    {
        public DbSet<Airplane> Airplane { get; set; }

        public DbSet<Airport1> Airport1 { get; set; }

        public DbSet<Airport2> Airport2 { get; set; }

        public DbSet<Passenger> Passenger { get; set; }

        public DbSet<Ticket> Ticket { get; set; }



        public DataBase(DbContextOptions<DataBase> context):base(context)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            modelBuilder.Entity<Airport1>().Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            modelBuilder.Entity<Airport2>().Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            modelBuilder.Entity<Passenger>().Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            modelBuilder.Entity<Ticket>().Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
