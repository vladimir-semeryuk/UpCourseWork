using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities.Common;

namespace Upcoursework.Context.Entities.Tags;
public class Skill : BaseEntity
{
    public required string Title { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
