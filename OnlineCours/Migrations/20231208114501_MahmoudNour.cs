using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCours.Migrations
{
    /// <inheritdoc />
    public partial class MahmoudNour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Subjects_subjectID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Levels_LevelID",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "InstructorLevels");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_LevelID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_subjectID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "LevelID",
                table: "Subjects",
                newName: "Semester");

            migrationBuilder.RenameColumn(
                name: "stutes",
                table: "Students",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "stutes",
                table: "Instructors",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "subjectID",
                table: "Appointments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "stutes",
                table: "Appointments",
                newName: "InstructorSubjectBridgeID");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorSubjectBridgeID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorSubjectBridgeID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InstructorSubjectBridge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSubjectBridge", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstructorSubjectBridgeID",
                table: "Subjects",
                column: "InstructorSubjectBridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_InstructorSubjectBridgeID",
                table: "Instructors",
                column: "InstructorSubjectBridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InstructorSubjectBridgeID",
                table: "Appointments",
                column: "InstructorSubjectBridgeID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "InstructorSubjectBridge");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_InstructorSubjectBridgeID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_InstructorSubjectBridgeID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_InstructorSubjectBridgeID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InstructorSubjectBridgeID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InstructorSubjectBridgeID",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Subjects",
                newName: "LevelID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Students",
                newName: "stutes");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Instructors",
                newName: "stutes");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Appointments",
                newName: "subjectID");

            migrationBuilder.RenameColumn(
                name: "InstructorSubjectBridgeID",
                table: "Appointments",
                newName: "stutes");

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Semesters_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InstructorLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorLevels_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "applicationUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InstructorLevels_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LevelID",
                table: "Subjects",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_subjectID",
                table: "Appointments",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLevels_InstructorID",
                table: "InstructorLevels",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLevels_LevelID",
                table: "InstructorLevels",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_SemesterID",
                table: "Levels",
                column: "SemesterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Subjects_subjectID",
                table: "Appointments",
                column: "subjectID",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Levels_LevelID",
                table: "Subjects",
                column: "LevelID",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
