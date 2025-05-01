namespace ZeroBudget.Features.Budgets;

public record Month(int Number, string Name)
{
    public static Month January => new(1, "January");
    public static Month February => new(2, "February");
    public static Month March => new(3, "March");
    public static Month April => new(4, "April");
    public static Month May => new(5, "May");
    public static Month June => new(6, "June");
    public static Month July => new(7, "July");
    public static Month August => new(8, "August");
    public static Month September => new(9, "September");
    public static Month October => new(10, "October");
    public static Month November => new(11, "November");
    public static Month December => new(12, "December");
    public static Month[] Months =>
    [
        January, February, March, April, May, June, July, August, September, October, November, December
    ];
}


