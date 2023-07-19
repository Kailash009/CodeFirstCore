using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstAvinash.Migrations
{
    /// <inheritdoc />
    public partial class Second_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_Del",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_Del",
                table: "Employees");
        }
    }
}
