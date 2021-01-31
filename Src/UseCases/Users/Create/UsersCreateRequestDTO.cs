using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.Users.Create
{
  public class UsersCreateRequestDto
  {

    [MaxLength(50, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    [Required(ErrorMessage = "{0} collumn is required")]
    public string Name { get; set; }
  }
}