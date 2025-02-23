﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevStage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefferalIdToSubscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReferredId",
                table: "Subscriptions",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferredId",
                table: "Subscriptions");
        }
    }
}
