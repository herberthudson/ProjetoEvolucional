using System.ComponentModel.DataAnnotations;

namespace ProjetoEvolucional.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "Tamanho excedido!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "Tamanho excedido!")]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}
