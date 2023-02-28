using FilmCool.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCool.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<Utilisateur>>> GetAll();
        Task<ActionResult<Utilisateur>> GetById(int id);
        Task<ActionResult<Utilisateur>> GetByString(string str);
        void Add(Utilisateur entity);
        void Update(Utilisateur entityToUpdate, Utilisateur entity);
        void Delete(Utilisateur entity);
    }
}
