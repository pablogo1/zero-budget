using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZeroBudget.Data;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Create;

public sealed class BudgetDatabaseFixture : IDisposable
{
    private readonly SqliteConnection _connection;

    public BudgetContext Context { get; }

    public BudgetDatabaseFixture()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<BudgetContext>()
            .UseSqlite(_connection)
            .LogTo(str => Debug.WriteLine(str), LogLevel.Information)
            .Options;

        Context = new BudgetContext(options);
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
        _connection.Close();
        _connection.Dispose();
    }
}

[CollectionDefinition("BudgetDatabase")]
public sealed class BudgetDatabaseCollection : ICollectionFixture<BudgetDatabaseFixture>
{}