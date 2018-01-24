using System;
using System.ComponentModel.DataAnnotations;

namespace ForumAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage= "Campo obrigatório!")] // DATAANNOTATIONS
        [MinLength(2, ErrorMessage="Insira um nome com pelo menos dois caracteres!!!")]
        [MaxLength(50)]
        public string Nome { get; set; }
        public string Login { get; set; }  
        public string Senha { get; set; }  
        public DateTime DataCadastro { get; set; }
    }
}