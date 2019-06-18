using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class MvcMovieCommentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Comments",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Comments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieID",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Comments",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Comments",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                newName: "IX_Comments_MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieID",
                table: "Comments",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
