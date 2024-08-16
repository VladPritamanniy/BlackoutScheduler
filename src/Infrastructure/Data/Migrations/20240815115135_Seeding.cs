using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[,]
                {
                    { "1", "Перша", "Вимкнення світла до 3 - х годин на добу" },
                    { "2", "Друга", "Підприємства та комерційні заклади" },
                    { "3", "Третя", "Освітні заклади та лікарні" },
                    { "4", "Четверта", "Житлові квартали, багатоквартирні будинки" },
                    { "5", "П’ята", "Приватний сектор" },
                    { "6", "Шоста", "Виробничі підприємства з підвищеним споживанням електроенергії" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Street", "GroupId" },
                values: new object[,]
                {
                    { "Кирилівська 12", 1 },
                    { "Бойченко 30", 1 },
                    { "Дарниця 11", null },
                    { "Хрещатик 12", 3 },
                    { "Бажана 14", null },
                    { "Окружна 1", 5 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "DayOfWeek", "StartTime", "FinishTime", "GroupId" },
                values: new object[,]
                {
                    { "Субота", new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), 1 },
                    { "Субота", new TimeSpan(15, 0, 0), new TimeSpan(16, 0, 0), 2 },
                    { "Понеділок", new TimeSpan(11, 0, 0), new TimeSpan(18, 0, 0), 3 },
                    { "Вівторок", new TimeSpan(13, 0, 0), new TimeSpan(15, 0, 0), 4 },
                    { "Середа", new TimeSpan(20, 0, 0), new TimeSpan(23, 0, 0), 5 },
                    { "Четвер", new TimeSpan(1, 0, 0), new TimeSpan(6, 0, 0), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
