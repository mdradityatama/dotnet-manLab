using ManLab.Models;
using Microsoft.EntityFrameworkCore;

namespace ManLab.Data
{
    public class ManLabDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public ManLabDataContext(DbContextOptions<ManLabDataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Tetap" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Habis Pakai" });

            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 1, Name = "Kursi"});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 2, Name = "Meja"});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 3, Name = "Spidol"});
            modelBuilder.Entity<Tool>().HasData(new Tool { ToolID = 4, Name = "Penghapus"});

            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 1, Name = "R01" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 2, Name = "R02" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 3, Name = "R03" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomID = 4, Name = "R04" });
            
            modelBuilder.Entity<Collection>().HasData(new Collection { CollectionID = 1, ToolID = 1, CategoryID = 1, RoomID = 1, Total = 10 });
            modelBuilder.Entity<Collection>().HasData(new Collection { CollectionID = 2, ToolID = 2, CategoryID = 2, RoomID = 2, Total = 20 });
            modelBuilder.Entity<Collection>().HasData(new Collection { CollectionID = 3, ToolID = 3, CategoryID = 1, RoomID = 3, Total = 30 });
            modelBuilder.Entity<Collection>().HasData(new Collection { CollectionID = 4, ToolID = 4, CategoryID = 2, RoomID = 4, Total = 40 });
            modelBuilder.Entity<Collection>().HasData(new Collection { CollectionID = 5, ToolID = 2, CategoryID = 1, RoomID = 1, Total = 50 });
        }
    }
}
