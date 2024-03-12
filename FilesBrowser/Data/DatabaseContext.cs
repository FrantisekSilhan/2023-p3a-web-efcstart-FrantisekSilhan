using FilesBrowser.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesBrowser.Data {
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
        public DbSet<Folder> Folders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}