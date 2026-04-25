using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniSchool.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_DB_MG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_archived = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    code = table.Column<string>(type: "char(3)", unicode: false, maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    class_level = table.Column<byte>(type: "tinyint", nullable: false),
                    teacher_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    teacher_surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_archived = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    class_level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_archived = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    exam_date = table.Column<DateTime>(type: "date", nullable: false),
                    grade = table.Column<byte>(type: "tinyint", nullable: false),
                    lesson_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_exams_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exams_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_exam_lesson_id",
                table: "exams",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_student_id",
                table: "exams",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_lesson_code_unique",
                table: "lessons",
                column: "code",
                unique: true,
                filter: "is_archived = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
