using DAL.EF.Context.Contracts;
using DAL.Models.DomainModels;
using DAL.Models.DomainModels.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Context.Implementations
{
    class MessengerDbContext : DbContext, IDbContext
    {
        public MessengerDbContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MessengerDb;Trusted_Connection=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<ClientMessage> ClientMessages { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
