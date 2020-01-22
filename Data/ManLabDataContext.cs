using ManLab.Models;
using Microsoft.EntityFrameworkCore;

namespace ManLab.Data
{
    public class ManLabDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public ManLabDataContext(DbContextOptions<ManLabDataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Tetap" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Habis Pakai" });

            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 1, Name = "Kursi", CategoryID = 1, RoomID = 1});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 2, Name = "Meja", CategoryID = 1, RoomID = 2});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 3, Name = "Spidol", CategoryID = 2, RoomID = 4});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 4, Name = "Penghapus", CategoryID = 1, RoomID = 2});

            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 1, Name = "R01" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 2, Name = "R02" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 3, Name = "R03" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 4, Name = "R04" });
        }
    }
}
