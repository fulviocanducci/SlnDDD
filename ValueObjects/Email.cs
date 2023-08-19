using System.ComponentModel.DataAnnotations;

namespace ValueObjects
{
   public record Email([Required(ErrorMessage = "Digite o e-mail"), EmailAddress(ErrorMessage = "E-mail inválido")] string Value);
}
