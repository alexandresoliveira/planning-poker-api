using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  interface IRepository<T>
  {
    Task<List<T>> All();

    Task<T> ById(Guid id);

    Task<T> Create(T entity);

    Task Update(T entity);

    Task Delete(T entity);

    Task Delete(Guid id);
  }
}