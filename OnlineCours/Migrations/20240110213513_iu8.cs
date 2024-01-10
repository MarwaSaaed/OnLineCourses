using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCours.Migrations
{
    /// <inheritdoc />
    public partial class iu8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniveristyRequest_Students_StudentID",
                table: "UniveristyRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniveristyRequest",
                table: "UniveristyRequest");

            migrationBuilder.RenameTable(
                name: "UniveristyRequest",
                newName: "univeristyRequests");

            migrationBuilder.RenameIndex(
                name: "IX_UniveristyRequest_StudentID",
                table: "univeristyRequests",
                newName: "IX_univeristyRequests_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_univeristyRequests",
                table: "univeristyRequests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tutorials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorSubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutorials_InstructorSubjects_InstructorSubjectId",
                        column: x => x.InstructorSubjectId,
                        principalTable: "InstructorSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tutorials_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ApplicationUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTutorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectTutorial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorialId = table.Column<int>(type: "int", nullable: false),
                    TutorialType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTutorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTutorial_Tutorials_TutorialId",
                        column: x => x.TutorialId,
                        principalTable: "Tutorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTutorial_TutorialId",
                table: "SubjectTutorial",
                column: "TutorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_InstructorSubjectId",
                table: "Tutorials",
                column: "InstructorSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_StudentId",
                table: "Tutorials",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_univeristyRequests_Students_StudentID",
                table: "univeristyRequests",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ApplicationUserID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_univeristyRequests_Students_StudentID",
                table: "univeristyRequests");

            migrationBuilder.DropTable(
                name: "SubjectTutorial");

            migrationBuilder.DropTable(
                name: "Tutorials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_univeristyRequests",
                table: "univeristyRequests");

            migrationBuilder.RenameTable(
                name: "univeristyRequests",
                newName: "UniveristyRequest");

            migrationBuilder.RenameIndex(
                name: "IX_univeristyRequests_StudentID",
                table: "UniveristyRequest",
                newName: "IX_UniveristyRequest_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniveristyRequest",
                table: "UniveristyRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniveristyRequest_Students_StudentID",
                table: "UniveristyRequest",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ApplicationUserID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
