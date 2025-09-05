using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZeroBudget.Models;

namespace ZeroBudget.Data.Mappings;

public class BudgetMapping : IEntityTypeConfiguration<Models.Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("budgets");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Key)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("key");
        builder.HasIndex(b => b.Key)
            .IsUnique();
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");
        builder.Property(b => b.Month)
            .IsRequired()
            .HasColumnName("month");
        builder.Property(b => b.Year)
            .IsRequired()
            .HasColumnName("year");
    }
}
