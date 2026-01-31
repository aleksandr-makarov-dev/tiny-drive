using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyDrive.Infrastructure.Migrations;

    /// <inheritdoc />
    public partial class Add_Extension_Size_ContentType_UploadStatus_To_Node : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "content_type",
                table: "nodes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extension",
                table: "nodes",
                type: "character varying(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "size",
                table: "nodes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "upload_status",
                table: "nodes",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content_type",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "extension",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "size",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "upload_status",
                table: "nodes");
        }
    }
