using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("users")]
  public class UserEntity : BaseEntity
  {
    [MaxLength(50, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    [Column("name")]
    public string Name { get; set; }
  }
}