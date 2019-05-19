using System;
using System.ComponentModel.DataAnnotations;

namespace DemoAuthentication.Application.ViewModels
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
