using Upcoursework.Context.Entities.Common;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.Context.Entities;
public class Author : BaseEntity
{
    public required string DisplayName { get; set; }
    public string Description { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual ICollection<Skill> Skills { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Feedback> Feedback { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}
