using System.ComponentModel.DataAnnotations;

namespace AuthorService.API.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        // Auditable
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        // SoftDelete
        public bool IsDeleted { get; set; }
    }
}
