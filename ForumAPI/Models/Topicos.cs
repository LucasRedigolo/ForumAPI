using System;

namespace ForumAPI.Models
{
    public class Topicos
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }   
        public DateTime DataCadastro { get; set; }
    }
}