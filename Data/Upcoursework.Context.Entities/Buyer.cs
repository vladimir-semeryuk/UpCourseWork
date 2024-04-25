using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities.Common;

namespace Upcoursework.Context.Entities;
public class Buyer : BaseEntity
{
    public required string DisplayName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Feedback> Feedback { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}
