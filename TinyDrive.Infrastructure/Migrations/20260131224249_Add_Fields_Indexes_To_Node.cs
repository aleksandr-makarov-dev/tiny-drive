using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyDrive.Infrastructure.Migrations;

    /// <inheritdoc />
    [SuppressMessage("Performance", "CA1861:Avoid constant arrays as arguments")]
    public partial class Add_Fields_Indexes_To_Node : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_nodes_parent_id",
                table: "nodes");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at_utc",
                table: "nodes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "nodes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "materialized_path",
                table: "nodes",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_nodes_materialized_path",
                table: "nodes",
                column: "materialized_path");

            migrationBuilder.CreateIndex(
                name: "ix_nodes_parent_id_name_extension_is_folder",
                table: "nodes",
                columns: new[] { "parent_id", "name", "extension", "is_folder" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_nodes_materialized_path",
                table: "nodes");

            migrationBuilder.DropIndex(
                name: "ix_nodes_parent_id_name_extension_is_folder",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "deleted_at_utc",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "materialized_path",
                table: "nodes");

            migrationBuilder.CreateIndex(
                name: "ix_nodes_parent_id",
                table: "nodes",
                column: "parent_id");
        }
    }
