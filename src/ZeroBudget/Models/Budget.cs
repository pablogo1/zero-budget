using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ZeroBudget.Models;

public class Budget
{
    public int Id { get; private set; }
    public string Key { get; private set; }
    public string Name { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }

    private Budget(string key, string name, int month, int year) 
        : this(0, key, name, month, year)
    {}

    // Used by EF Core
    private Budget(int id, string key, string name, int month, int year)
    {
        Id = id;
        Key = key;
        Name = name;
        Month = month;
        Year = year;
    }

    public static Budget Create(string name, string key, int month, int year)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Budget name cannot be empty.", nameof(name));

        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        if (year < 2000 || year > DateTime.Today.Year + 10)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be a valid year.");

        return new Budget(key, name, month, year);
    }
}
