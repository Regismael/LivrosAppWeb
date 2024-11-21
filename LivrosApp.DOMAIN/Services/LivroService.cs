using LivrosApp.DOMAIN.Dtos;
using LivrosApp.DOMAIN.Entities;
using LivrosApp.DOMAIN.Interfaces.Repositories;
using LivrosApp.DOMAIN.Interfaces.Services;
using LivrosApp.DOMAIN.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;

public class LivroService : ILivroService
{
    private readonly ILivrosRepository _livroRepository;

    public LivroService(ILivrosRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public LivroResponseDto IncluirLivro(LivroRequestDto dto)
    {
        var livro = new Livro
        {
            Id = Guid.NewGuid(),
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Genero = dto.Genero,
            AnoDePublicacao = dto.AnoDePublicacao,
            Disponibilidade = true,
            Ativo = true,
            DataInclusao = DateTime.Now,
            DataRetirada = null,
        };

        var livroValidator = new LivroValidator();
        var result = livroValidator.Validate(livro);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        _livroRepository.Add(livro);

        return new LivroResponseDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            AnoDePublicacao = livro.AnoDePublicacao,
            Disponibilidade = livro.Disponibilidade,
            Mensagem = "Livro incluído com sucesso."
        };
    }

    public LivroResponseDto AlterarLivro(Guid id, LivroRequestDto dto)
    {
        var livro = _livroRepository.GetById(id);

        if (livro == null)
            throw new ApplicationException("Livro não encontrado. Por favor, verifique o ID.");

        livro.Titulo = dto.Titulo;
        livro.Autor = dto.Autor;
        livro.Genero = dto.Genero;
        livro.AnoDePublicacao = dto.AnoDePublicacao;

        var livroValidator = new LivroValidator();
        var result = livroValidator.Validate(livro);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        _livroRepository.Update(livro);

        return new LivroResponseDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            AnoDePublicacao = livro.AnoDePublicacao,
            Disponibilidade = livro.Disponibilidade,
            Mensagem = "Livro alterado com sucesso."
        };
    }

    public LivroResponseDto ExcluirLivro(Guid id)
    {
        var livro = _livroRepository.GetById(id);

        if (livro == null)
            throw new ApplicationException("Livro não encontrado. Por favor, verifique o ID.");

        livro.Ativo = false;
        _livroRepository.Update(livro);

        return new LivroResponseDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            AnoDePublicacao = livro.AnoDePublicacao,
            Disponibilidade = livro.Disponibilidade,
            Mensagem = "Livro excluído logicamente com sucesso."
        };
    }

    public List<LivroResponseDto> ConsultarTodosOsLivros()
    {
        var response = new List<LivroResponseDto>();

        var livros = _livroRepository.GetAll();
        foreach (var item in livros)
        {
            response.Add(new LivroResponseDto
            {
                Id = item.Id,
                Titulo = item.Titulo,
                Autor = item.Autor,
                Genero = item.Genero,
                AnoDePublicacao = item.AnoDePublicacao,
                Disponibilidade = item.Disponibilidade,
                Mensagem = "Consulta de todos os livros realizada com sucesso."
            });
        }
        return response;
    }

    public LivroResponseDto ObterPorId(Guid id)
    {
        var livro = _livroRepository.GetById(id);

        if (livro == null)
            throw new ApplicationException("Livro não encontrado. Por favor, verifique o ID.");

        return new LivroResponseDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            AnoDePublicacao = livro.AnoDePublicacao,
            Disponibilidade = livro.Disponibilidade,
            Mensagem = "Consulta do livro realizada com sucesso."
        };
    }

    public List<LivroResponseDto> RetirarLivros(List<Guid> ids)
    {
        var livrosRetirados = new List<LivroResponseDto>();

        foreach (var id in ids)
        {
            var livro = _livroRepository.GetById(id);

            if (livro == null)
            {
                throw new ApplicationException($"Livro com ID {id} não encontrado.");
            }

            if (!livro.Disponibilidade)
            {
                throw new ApplicationException($"O livro {livro.Titulo} já foi retirado e não está disponível.");
            }

            livro.Disponibilidade = false;
            livro.DataRetirada = DateTime.Now;

            _livroRepository.Update(livro);

            livrosRetirados.Add(new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Genero = livro.Genero,
                AnoDePublicacao = livro.AnoDePublicacao,
                Disponibilidade = livro.Disponibilidade,
                Mensagem = $"Livro {livro.Titulo} retirado com sucesso."
            });
        }

        return livrosRetirados;
    }


    public LivroResponseDto DevolverLivro(Guid id)
    {
        var livro = _livroRepository.GetById(id);

        if (livro == null)
            throw new ApplicationException("Livro não encontrado. Por favor, verifique o ID.");

        if (livro.Disponibilidade)
            throw new ApplicationException("O livro já está disponível e não precisa ser devolvido.");

        livro.Disponibilidade = true;
        livro.DataRetirada = null;

        _livroRepository.Update(livro);

        return new LivroResponseDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            AnoDePublicacao = livro.AnoDePublicacao,
            Disponibilidade = livro.Disponibilidade,
            Mensagem = "Livro devolvido com sucesso."
        };
    }
}
