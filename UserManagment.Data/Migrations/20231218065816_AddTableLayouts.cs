using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableLayouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_layouts",
                columns: table => new
                {
                    user_login = table.Column<string>(type: "TEXT", nullable: false),
                    interface_type = table.Column<string>(type: "TEXT", nullable: false),
                    schema_body = table.Column<string>(type: "TEXT", maxLength: 2550000, nullable: true, comment: "схема в json формате")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_layouts", x => new { x.user_login, x.interface_type });
                },
                comment: "таблица для хранения схем интерфейсов");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_layouts");
        }
    }
}
