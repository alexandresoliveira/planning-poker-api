using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{
  public class BaseEntity
  {
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Timestamp]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Timestamp]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
  }
}