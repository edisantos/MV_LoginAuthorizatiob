using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAuthentication.Application.ViewModels
{
    [Table(nameof(Usuario))]
    public class Usuario:Entity
    {
        [Column(TypeName ="varchar")]
        [Display(Name ="Nome")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "E-mail")]
        [MaxLength(50)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [Column(TypeName = "varchar")]
        [Display(Name = "Usuario")]
        [MaxLength(12), MinLength(6)]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required]
        [StringLength(100)]
        public string Senha { get; set; }
        public bool PermanecerLogado { get; set; }

        
    }
}
