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

            Folder rootFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Root" };
            Folder musicFolder =  new Folder { FolderId = Guid.NewGuid(), Name = "Music", ParentFolderId = rootFolder.FolderId };
            Folder imagesFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Images", ParentFolderId = rootFolder.FolderId };
            Folder orchestralFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Orchestral", ParentFolderId = musicFolder.FolderId };
            Folder popFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Pop", ParentFolderId = musicFolder.FolderId };
            Folder rockFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Rock", ParentFolderId = musicFolder.FolderId };
            Folder familyFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Family", ParentFolderId = imagesFolder.FolderId };
            Folder wallpapersFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Wallpapers", ParentFolderId = imagesFolder.FolderId };
            Folder screenshotsFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Screenshots", ParentFolderId = imagesFolder.FolderId };

            /*rootFolder.Folders = new List<Folder> { musicFolder, imagesFolder };
            musicFolder.Folders = new List<Folder> { orchestralFolder, popFolder, rockFolder };
            imagesFolder.Folders = new List<Folder> { familyFolder, wallpapersFolder, screenshotsFolder };
            */
            modelBuilder.Entity<Folder>().HasData(
                rootFolder
            );


            modelBuilder.Entity<Folder>().HasData(
                musicFolder,
                imagesFolder
            );

            modelBuilder.Entity<Folder>().HasData(
                orchestralFolder,
                popFolder,
                rockFolder,
                familyFolder,
                wallpapersFolder,
                screenshotsFolder
            );
        }
    }
}