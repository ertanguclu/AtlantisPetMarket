using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "bdaf0b55-eb93-43cc-841f-2f38a5e2c9de", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee13222d-6cde-4a63-8a5a-a7ddf26891de", "AQAAAAIAAYagAAAAEPJk4BmmscSmAGccwFMDLJ4JiRM1ecJ0EDhrGIUqTEi3YbuvkvijqqnyGp6wfEt5hg==", "7584c557-631f-47d7-b99f-992c7a599719" });

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 12, 22, 712, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 12, 22, 712, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 12, 22, 712, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 12, 22, 712, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 12, 22, 712, DateTimeKind.Local).AddTicks(9746));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468f2537-689f-4afe-b63e-887d82f9ebfb", "AQAAAAIAAYagAAAAENLsGDI3hg3zx0P7G4nIApo6OOteJA8bDZN5ZMf0NttwTvhUYLZudH3KTaRyxFSBrw==", "3eb73fd9-35f3-448e-ab91-d6edccc12e7a" });

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 9, 36, 983, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 9, 36, 983, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 9, 36, 983, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 9, 36, 983, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 9, 36, 983, DateTimeKind.Local).AddTicks(4330));
        }
    }
}
