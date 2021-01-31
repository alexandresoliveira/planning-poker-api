using System.ComponentModel.DataAnnotations;

namespace PlanningPokerApi.Src.UseCases.Cards.Create
{
  public class CardsCreateRequestDto
  {

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, 8, ErrorMessage = "For {0} is permitted values between {1} and {2}")]
    public int Value { get; set; }
  }
}