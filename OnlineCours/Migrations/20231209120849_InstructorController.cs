using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCours.Migrations
{
    /// <inheritdoc />
    public partial class InstructorController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubjectBridge",
                table: "InstructorSubjectBridge");

            migrationBuilder.RenameTable(
                name: "InstructorSubjectBridge",
                newName: "InstructorSubjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubjects",
                table: "InstructorSubjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Appointments",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Instructors",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Subjects",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_InstructorSubjects_InstructorSubjectBridgeID",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubjects",
                table: "InstructorSubjects");

            migrationBuilder.RenameTable(
                name: "InstructorSubjects",
                newName: "InstructorSubjectBridge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubjectBridge",
                table: "InstructorSubjectBridge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Appointments",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjectBridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Instructors",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjectBridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_InstructorSubjectBridge_InstructorSubjectBridgeID",
                table: "Subjects",
                column: "InstructorSubjectBridgeID",
                principalTable: "InstructorSubjectBridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
