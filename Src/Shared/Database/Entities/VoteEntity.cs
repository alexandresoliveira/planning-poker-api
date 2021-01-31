using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerApi.Src.Shared.Database.Entities
{

  [Table("votes")]
  public class VoteEntity : BaseEntity
  {

    [Required(ErrorMessage = "The {0} is required.")]
    [Column("user_id")]
    public UserEntity user { get; set; }

    [Required(ErrorMessage = "The {0} is required.")]
    [Column("card_id")]
    public CardEntity card { get; set; }

    [Required(ErrorMessage = "The {0} is required.")]
    [Column("users_history_id")]
    public UsersHistoryEntity usersHistory { get; set; }
  }
}