using Bogus;
using FluentAssertions;
using LivrosApp.DOMAIN.Dtos;
using LivrosApp.DOMAIN.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LivrosApp.Tests
{
    public class CriarLivroTest
    {
        [Fact]
        public async Task Criar_Livro_Com_Sucesso_Test()
        {
            var faker = new Faker("pt_BR");


            var request = new LivroRequestDto
            {
                Titulo = faker.Lorem.Sentence(),
                Autor = faker.Name.FullName(),
                Genero = faker.PickRandom<Genero>(),
                AnoDePublicacao = faker.Date.Past(30).Year,
                Disponibilidade = faker.Random.Bool(),
                DataRetirada = faker.Date.Recent(),
                Ids = new List<Guid> { faker.Random.Guid(), faker.Random.Guid() }
            };

            var json = new StringContent(JsonConvert.SerializeObject
              (request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = await client.PostAsync
           ("/api/livros", json);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
