using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Upcoursework.Context.Entities.Common;
[Microsoft.EntityFrameworkCore.Index("Uid", IsUnique = true)]
public class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; }

    [Required]
    public virtual Guid Uid { get; set; } = Guid.NewGuid();
}
