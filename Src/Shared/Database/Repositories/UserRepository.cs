using System;
using System.Collections.Generic;
using PlanningPokerApi.Src.Shared.Database.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  internal class UserRepository : IRepository<UserEntity>
  {

    private readonly ApiContext _context;

    public UserRepository(ApiContext context)
    {
      _context = context;
    }

    public async Task<List<UserEntity>> All()
    {
      var users = await _context.Users.ToListAsync();
      return users;
    }

    public async Task<UserEntity> ById(Guid id)
    {
      var user = await _context.Users.FindAsync(id);
      return user;
    }

    public async Task<UserEntity> Create(UserEntity entity)
    {
      var result = _context.Users.Add(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public async Task Delete(UserEntity entity)
    {
      _context.Users.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
      var entity = await _context.Users.FindAsync(id);
      if (entity == null) throw new Exception("Entity not found!");
      _context.Users.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(UserEntity entity)
    {
      _context.Users.Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}