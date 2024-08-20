using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "43db8f70-654e-496b-91fc-db7e9811cfff");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40768d59-f3ac-489f-a544-0562ca2d1a33", "AQAAAAIAAYagAAAAEOciR5xBUly0/NRvVuwWWjUa5Z4JbRtGUXiI7UV7wgZZqd2SgM/r6Sc4h76wKQtv1w==", "d8a388bc-83cb-44d2-88d0-f3d5238a59aa" });

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 14, 20, 70, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 14, 20, 70, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 14, 20, 70, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 14, 20, 70, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 8, 20, 14, 14, 20, 70, DateTimeKind.Local).AddTicks(5677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bdaf0b55-eb93-43cc-841f-2f38a5e2c9de");

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
    }
}
