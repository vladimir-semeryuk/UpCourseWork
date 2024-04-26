using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities.Common;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.Context.Entities;
public class Order : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public byte[]? FileAttachment { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime? CompletedDate { get; set; }
    public OrderCompletionStatus CompletionStatus { get; set; }
    public decimal Budget { get; set; }
    public bool IsBudgetNegotiable { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
    public virtual required ICollection<Skill> SkillsRequired { get; set; }
    public int? AuthorId { get; set; }
    public virtual Author? Author { get; set; }
    public int BuyerId { get; set; }
    public virtual Buyer Buyer { get; set; }
}
