using FilesBrowser.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesBrowser.Data {
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
        public DbSet<Folder> Folders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Folder>()
                .HasMany(f => f.Folders)
                .WithOne(f => f.ParentFolder)
                .HasForeignKey(f => f.ParentFolderId);

            Folder rootFolder = new Folder { FolderId = Guid.Parse("CF20E53B-DE2C-4864-AF62-9131FD82E4CB"), Name = "Root", ParentFolderId = Guid.Parse("CF20E53B-DE2C-4864-AF62-9131FD82E4CB") };

            modelBuilder.Entity<Folder>().HasData(
                rootFolder
            );

            Folder musicFolder =  new Folder { FolderId = Guid.NewGuid(), Name = "Music", ParentFolderId = rootFolder.FolderId };
            Folder imagesFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Images", ParentFolderId = rootFolder.FolderId };

            modelBuilder.Entity<Folder>().HasData(
                musicFolder,
                imagesFolder
            );

            modelBuilder.Entity<Folder>().HasData(
                new Folder { FolderId = Guid.NewGuid(), Name = "Orchestral", ParentFolderId = musicFolder.FolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Pop", ParentFolderId = musicFolder.FolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Rock", ParentFolderId = musicFolder.FolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Family", ParentFolderId = imagesFolder.FolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Wallpapers", ParentFolderId = imagesFolder.FolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Screenshots", ParentFolderId = imagesFolder.FolderId }
            );
        }
    }
}