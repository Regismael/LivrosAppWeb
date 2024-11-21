using LivrosApp.DOMAIN.Dtos;
using System;
using System.Collections.Generic;

namespace LivrosApp.DOMAIN.Interfaces.Services
{
    public interface ILivroService
    {
        LivroResponseDto IncluirLivro(LivroRequestDto dto);
        LivroResponseDto AlterarLivro(Guid id, LivroRequestDto dto);
        LivroResponseDto ExcluirLivro(Guid id);
        List<LivroResponseDto> ConsultarTodosOsLivros();
        LivroResponseDto ObterPorId(Guid id);
        List<LivroResponseDto> RetirarLivros(List<Guid> ids);

        LivroResponseDto DevolverLivro(Guid id);
    }
}
