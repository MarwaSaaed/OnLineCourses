using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCours.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultingHoures",
                table: "CoursesRequest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CoursesRequest");

            migrationBuilder.CreateTable(
                name: "ConsultingRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseRequestId = table.Column<int>(type: "int", nullable: false),
                    ConsultingHoures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultingRequest_CoursesRequest_CourseRequestId",
                        column: x => x.CourseRequestId,
                        principalTable: "CoursesRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingRequest_CourseRequestId",
                table: "ConsultingRequest",
                column: "CourseRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultingRequest");

            migrationBuilder.AddColumn<string>(
                name: "ConsultingHoures",
                table: "CoursesRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CoursesRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
