using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsManager.Data.Migrations
{
    public partial class ContactOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_books_BookId",
                table: "contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_books_BookId",
                table: "contacts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_books_BookId",
                table: "contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_books_BookId",
                table: "contacts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id");
        }
    }
}
