using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamaFi.Retirement.Snapshot.Data.Migrations.Migrations
{
    public partial class add_group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "group",
                table: "retirement_fact",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "group",
                table: "retirement_fact");
        }
    }
}
