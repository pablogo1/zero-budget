using System;

namespace ZeroBudget.Models;

public class Budget
{
    public int Id { get; private set; } = 0;
    public string Name { get; private set; } = string.Empty;
    public int Month { get; private set; } = DateTime.Today.Month + 1;
    public int Year { get; private set; } = DateTime.Today.Year;

    private Budget() { }

    public static Budget Create(string name, int month, int year)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Budget name cannot be empty.", nameof(name));
        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        if (year < 2000 || year > DateTime.Today.Year + 10)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be a valid year.");

        return new Budget
        {
            Name = name,
            Month = month,
            Year = year
        };
    }
}
