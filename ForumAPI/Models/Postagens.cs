using System;

namespace ForumAPI.Models
{
    public class Postagens
    {
        public int ID { get; set; } 
        public int IDTopico { get; set; }
        public int IDUsuario { get; set; }  
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}