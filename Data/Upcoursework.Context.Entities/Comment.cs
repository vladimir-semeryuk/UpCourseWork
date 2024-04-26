using Upcoursework.Context.Entities.Common;

namespace Upcoursework.Context.Entities;
public class Comment : BaseEntity
{
    public required string Text { get; set; }
    //public int? OrderId { get; set; }
    //public virtual Order Order { get; set; }
    public int AuthorId { get; set; }
    public required virtual Author Author { get; set; }
    public int BuyerId { get; set; }
    public required virtual Buyer Buyer { get; set; }
}
