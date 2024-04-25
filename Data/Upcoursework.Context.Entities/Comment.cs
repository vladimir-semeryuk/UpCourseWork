using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities.Common;

namespace Upcoursework.Context.Entities;
public class Comment : BaseEntity
{
    public required string Text { get; set; }
    public int? OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int BuyerId { get; set; }
    public virtual Buyer Buyer { get; set; }
}
