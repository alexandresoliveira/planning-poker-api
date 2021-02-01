using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.V1.Users.Create
{
  public class UsersCreateRequestDto
  {

    [Required(ErrorMessage = "{0} collumn is required")]
    [MaxLength(50, ErrorMessage = "Max value of {0} is {1}")]
    [MinLength(3, ErrorMessage = "Min value of {0} is {1}")]
    public string Name { get; set; }
  }
}