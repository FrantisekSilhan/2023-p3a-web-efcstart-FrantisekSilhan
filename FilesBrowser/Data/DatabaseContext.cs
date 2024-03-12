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

            modelBuilder.Entity<Folder>().HasData(
                new Folder { FolderId = Guid.NewGuid(), Name = "Music", ParentFolderId = rootFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Images", ParentFolderId = rootFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Orchestral", ParentFolderId = musicFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Pop", ParentFolderId = musicFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Rock", ParentFolderId = musicFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Family", ParentFolderId = imagesFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Wallpapers", ParentFolderId = imagesFolderId },
                new Folder { FolderId = Guid.NewGuid(), Name = "Screenshots", ParentFolderId = imagesFolderId }
            );

            Folder musicFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Music", Folders = new List<Folder>
                {
                    new Folder { FolderId = Guid.NewGuid(), Name = "Orchestral" },
                    new Folder { FolderId = Guid.NewGuid(), Name = "Pop" },
                    new Folder { FolderId = Guid.NewGuid(), Name = "Rock" },

                }
            };
            Folder imagesFolder = new Folder { FolderId = Guid.NewGuid(), Name = "Images", Folders = new List<Folder>
                {
                    new Folder { FolderId = Guid.NewGuid(), Name = "Family" },
                    new Folder { FolderId = Guid.NewGuid(), Name = "Wallpapers" },
                    new Folder { FolderId = Guid.NewGuid(), Name = "Screenshots" },
                }
            };

            modelBuilder.Entity<Folder>(g => {
                g.HasData(
                    new Folder { FolderId = Guid.NewGuid(), Name = "Root", Folders = new List<Folder> { musicFolder, imagesFolder } }
                );
            });
        }
    }
}