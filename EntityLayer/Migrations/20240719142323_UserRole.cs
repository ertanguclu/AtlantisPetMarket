using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_MyUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentCategories_AspNetUsers_MyUserId",
                table: "ParentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_MyUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ParentCategories_MyUserId",
                table: "ParentCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MyUserId",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyUserId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "ParentCategories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyUserId1",
                table: "ParentCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "Categories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyUserId1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyUserId1",
                table: "Products",
                column: "MyUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParentCategories_MyUserId1",
                table: "ParentCategories",
                column: "MyUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MyUserId1",
                table: "Categories",
                column: "MyUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_MyUserId1",
                table: "Categories",
                column: "MyUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentCategories_AspNetUsers_MyUserId1",
                table: "ParentCategories",
                column: "MyUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_MyUserId1",
                table: "Products",
                column: "MyUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_MyUserId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentCategories_AspNetUsers_MyUserId1",
                table: "ParentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_MyUserId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyUserId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ParentCategories_MyUserId1",
                table: "ParentCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MyUserId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MyUserId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyUserId1",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "MyUserId1",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "Products",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "ParentCategories",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "Categories",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyUserId",
                table: "Products",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentCategories_MyUserId",
                table: "ParentCategories",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MyUserId",
                table: "Categories",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_MyUserId",
                table: "Categories",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentCategories_AspNetUsers_MyUserId",
                table: "ParentCategories",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_MyUserId",
                table: "Products",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
