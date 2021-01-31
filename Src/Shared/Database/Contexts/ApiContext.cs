using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Entities;

namespace PlanningPokerApi.Src.Shared.Database.Contexts
{
  public class ApiContext : DbContext
  {

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<CardEntity> Cards { get; set; }

    public DbSet<UsersHistoryEntity> UsersHistories { get; set; }

    public DbSet<VoteEntity> Votes { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    { }
  }
}
