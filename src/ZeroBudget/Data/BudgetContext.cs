using System;
using Microsoft.EntityFrameworkCore;

namespace ZeroBudget.Data;

public class BudgetContext : DbContext
{
    public DbSet<Models.Budget> Budgets => Set<Models.Budget>();

    public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetContext).Assembly);
    }
}
