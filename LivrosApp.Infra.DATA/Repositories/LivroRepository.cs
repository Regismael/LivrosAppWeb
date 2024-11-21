using LivrosApp.DOMAIN.Entities;
using LivrosApp.DOMAIN.Interfaces.Repositories;
using LivrosApp.Infra.DATA.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrosApp.Infra.DATA.Repositories
{
    public class LivroRepository : ILivrosRepository
    {
        public void Add(Livro livro)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Add(livro);
                dataContext.SaveChanges();
            }
        }

        public void Update(Livro livro)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Update(livro);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Livro livro)
        {
            using (var dataContext = new DataContext())
            {
                if (livro.Id != Guid.Empty)
                {
                    var consultarLivro = dataContext.Set<Livro>().Find(livro.Id);

                    if (consultarLivro != null)
                    {
                        consultarLivro.Ativo = false;
                        dataContext.SaveChanges();
                    }
                }
            }
        }


        public List<Livro> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Livro>()
                    .Where(livro => livro.Ativo == true)
                    .OrderBy(livro => livro.Titulo)
                    .ToList();
            }
        }

        public Livro GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Livro>()
                    .FirstOrDefault(livro => livro.Id == id && livro.Ativo); 
            }
        }

    }
}
