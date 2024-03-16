using System.ComponentModel.DataAnnotations;
using oa.Domain.Core.Models;
using oa.Domain.Enums;

namespace oa.Domain.Entities
{
    public class User : BaseEntity, IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        
    }
}
