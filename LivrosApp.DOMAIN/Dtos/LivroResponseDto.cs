using LivrosApp.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrosApp.DOMAIN.Dtos
{
    public class LivroResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Genero Genero { get; set; }
        public int AnoDePublicacao { get; set; }
        public bool Disponibilidade { get; set; }
        public string Mensagem { get; set; }
        public List<LivroResponseDto> LivrosDetalhados { get; set; }
    }


}
