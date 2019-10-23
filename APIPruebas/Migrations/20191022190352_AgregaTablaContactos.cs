using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPruebas.Migrations
{
    public partial class AgregaTablaContactos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 60, nullable: false),
                    Puesto = table.Column<string>(maxLength: 30, nullable: true),
                    Correo = table.Column<string>(maxLength: 30, nullable: true),
                    Celular = table.Column<string>(maxLength: 30, nullable: true),
                    Telefono1 = table.Column<string>(maxLength: 30, nullable: true),
                    Telefono2 = table.Column<string>(maxLength: 30, nullable: true),
                    Observaciones = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}
