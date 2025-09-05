using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroBudget.Migrations
{
    /// <inheritdoc />
    public partial class BudgetKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "key",
                table: "budgets",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_budgets_key",
                table: "budgets",
                column: "key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_budgets_key",
                table: "budgets");

            migrationBuilder.DropColumn(
                name: "key",
                table: "budgets");
        }
    }
}
