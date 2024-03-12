using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesBrowser.Models {
    public class Folder {
        public Guid FolderId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Folder>? Folders { get; set; }
        [ForeignKey(nameof(ParentFolderId))]
        public Guid ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; }
    }
}
