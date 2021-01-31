using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.Users.Create
{
  public class UsersCreateRequestDTO
  {

    [MaxLength(50, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    public string Name { get; set; }
  }
}