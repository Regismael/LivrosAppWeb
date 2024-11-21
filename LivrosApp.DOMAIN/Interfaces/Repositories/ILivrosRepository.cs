using LivrosApp.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrosApp.DOMAIN.Interfaces.Repositories
{
    public interface ILivrosRepository
    {
        void Add(Livro livro);
        void Update(Livro livro);
        void Delete(Livro livro);
        List<Livro> GetAll();
        Livro GetById(Guid id);

    }
}
