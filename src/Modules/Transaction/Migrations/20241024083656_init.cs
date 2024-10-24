using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransactionModule.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentLinkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: true),
                    Authority = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CardPan = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PaymentErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentGateway = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    TransactionFor = table.Column<short>(type: "smallint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "dbo");
        }
    }
}
