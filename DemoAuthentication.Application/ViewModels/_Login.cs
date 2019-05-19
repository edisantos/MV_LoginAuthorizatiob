using System.ComponentModel.DataAnnotations;

namespace DemoAuthentication.Application.ViewModels
{
    public class _Login
    {
        [Required]
        [MaxLength(12),MinLength(6)]
        [Display(Name="Usuário")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(12), MinLength(6)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool PermanecerLogado { get; set; }
        public string ReturUrl { get; set; }
    }
}
