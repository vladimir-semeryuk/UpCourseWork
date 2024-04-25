using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities.Common;

namespace Upcoursework.Context.Entities;
public class Feedback : BaseEntity
{
    public int BuyerId { get; set; }
    public virtual Buyer Buyer { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public FeedbackTypes Type { get; set; }
}
