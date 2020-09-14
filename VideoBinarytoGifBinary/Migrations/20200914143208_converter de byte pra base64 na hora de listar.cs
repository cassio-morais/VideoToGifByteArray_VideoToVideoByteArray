using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoBinarytoGifBinary.Migrations
{
    public partial class converterdebyteprabase64nahoradelistar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoBase64",
                table: "Videos");

            migrationBuilder.AddColumn<byte[]>(
                name: "VideoByte",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoByte",
                table: "Videos");

            migrationBuilder.AddColumn<string>(
                name: "VideoBase64",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
