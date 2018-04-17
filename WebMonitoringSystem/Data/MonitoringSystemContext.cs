using Microsoft.EntityFrameworkCore;
using WebMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitoringSystem.Data
{
    public class MonitoringSystemContext : DbContext
    {
        public MonitoringSystemContext(DbContextOptions<MonitoringSystemContext> options) : base(options)
        {
        }

        public DbSet<BasicParameter> BasicParameters { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleGroup> VehicleGroups { get; set; }
        public DbSet<VehicleToVehicleGroup> VehicleToVehicleGroups { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserToRole> UserToRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicParameter>().ToTable("BasicParameter");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<VehicleGroup>().ToTable("VehicleGroup");
            modelBuilder.Entity<VehicleToVehicleGroup>().ToTable("VehicleToVehicleGroup");
            modelBuilder.Entity<Parameter>().ToTable("Parameter");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserToRole>().ToTable("UserToRole");
        }
    }
}
