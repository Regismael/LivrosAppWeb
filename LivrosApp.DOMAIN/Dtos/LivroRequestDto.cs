using LivrosApp.DOMAIN.Enums;
using System;

namespace LivrosApp.DOMAIN.Dtos
{
    public class LivroRequestDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Genero Genero { get; set; } 
        public int AnoDePublicacao { get; set; }
        public bool? Disponibilidade { get; set; }  
        public DateTime? DataRetirada { get; set; }
        public List<Guid> Ids { get; set; }
    }
}
