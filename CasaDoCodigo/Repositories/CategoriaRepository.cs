using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{

    public interface ICategoriaRepository
    {
        Task Salvar(string nome);
        Categoria GetCategoriaPorNome(string nome);
    }
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Categoria GetCategoriaPorNome(string nome)
        {
            return
                dbSet
                .Where(c => c.Nome == nome)
                .SingleOrDefault();
        }

        public async Task Salvar(string nome)
        {
            var categoria = dbSet
                                        .Where(c => c.Nome == nome)
                                        .SingleOrDefault();
            if (categoria == null)
            {
                categoria = new Categoria(nome);
                contexto.Add(categoria);
            }
            await contexto.SaveChangesAsync();
        }
    }
}


