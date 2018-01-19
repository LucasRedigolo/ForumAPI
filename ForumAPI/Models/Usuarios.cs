using System;

namespace ForumAPI.Models
{
    public class Usuarios
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }  
        public string Senha { get; set; }  
        public DateTime DataCadastro { get; set; }
    }
}