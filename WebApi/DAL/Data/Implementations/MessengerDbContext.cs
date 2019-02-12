using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Data.Contracts;
using WebApi.DAL.Models.DomainModel;
using WebApi.DAL.Models.DomainModel.Auth;

namespace WebApi.DAL.Data.Implementations
{
    public class MessengerDbContext : DbContext, IDbContext
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<ClientMessage> ClientMessages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientGroup>().HasKey(x => new { x.ClientId, x.GroupId });
            modelBuilder.Entity<ClientMessage>().HasKey(x => new { x.ClientId, x.MessageId });
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MessengerDbContext>
    {
        public MessengerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MessengerDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new MessengerDbContext(builder.Options);
        }
    }
}
