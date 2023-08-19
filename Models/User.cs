using System.ComponentModel.DataAnnotations;
using ValueObjects;

namespace Models
{
   public class User
   {
      [Required()]
      public int Id { get; set; }

      [Required(ErrorMessage = "Digite o nome")]
      public string Name { get; set; } = null!;
      public Email Email { get; set; } = null!;
   }
}