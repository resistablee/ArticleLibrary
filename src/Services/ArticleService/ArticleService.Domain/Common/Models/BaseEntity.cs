using System.ComponentModel.DataAnnotations;

namespace ArticleService.Domain.Common.Models
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
