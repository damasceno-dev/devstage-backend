using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevStage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIdentifierToEmailColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Email",
                table: "Subscriptions",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Email",
                table: "Subscriptions");
        }
    }
}
