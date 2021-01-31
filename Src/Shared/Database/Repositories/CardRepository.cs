using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Entities;

using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  public class CardRepository : IRepository<CardEntity>
  {

    private ApiContext _context;

    public CardRepository(ApiContext context)
    {
      _context = context;
    }

    public Task<List<CardEntity>> All()
    {
      throw new NotImplementedException();
    }

    public Task<CardEntity> ById(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<CardEntity> Create(CardEntity entity)
    {
      var result = await _context.Cards.AddAsync(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public Task Delete(CardEntity entity)
    {
      throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(CardEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}