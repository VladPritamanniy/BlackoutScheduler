using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGetTopOutageGroupProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetTopOutageGroup
            AS
            BEGIN
                SELECT TOP 1
                    g.Id AS GroupId,
                    g.Name AS GroupName,
                    SUM(DATEDIFF(HOUR, s.StartTime, s.FinishTime)) AS TotalOutageMinutes
                FROM Groups g
                JOIN Schedules s ON g.Id = s.GroupId
                WHERE s.DayOfWeek IN (N'Понеділок', N'Вівторок', N'Середа')
                GROUP BY g.Id, g.Name
                ORDER BY TotalOutageMinutes DESC;
            END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetTopOutageGroup");
        }

    }
}
