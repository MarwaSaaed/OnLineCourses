using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCours.Migrations
{
    /// <inheritdoc />
    public partial class m88 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultingRequest_CoursesRequest_CourseRequestId",
                table: "ConsultingRequest");

            migrationBuilder.DropIndex(
                name: "IX_ConsultingRequest_CourseRequestId",
                table: "ConsultingRequest");

            migrationBuilder.RenameColumn(
                name: "CourseRequestId",
                table: "ConsultingRequest",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ConsultingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ConsultingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "ConsultingRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ConsultingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ConsultingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ConsultingRequest");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ConsultingRequest");

            migrationBuilder.DropColumn(
                name: "File",
                table: "ConsultingRequest");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ConsultingRequest");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ConsultingRequest");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ConsultingRequest",
                newName: "CourseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingRequest_CourseRequestId",
                table: "ConsultingRequest",
                column: "CourseRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultingRequest_CoursesRequest_CourseRequestId",
                table: "ConsultingRequest",
                column: "CourseRequestId",
                principalTable: "CoursesRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
