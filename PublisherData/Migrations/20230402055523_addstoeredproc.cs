using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    public partial class addstoeredproc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                @"Create procedure dbo.AuthorsBookspriceRange
                                @minPrice int, 
                                @maxPrice int
                                AS
                                SELECT Distinct Authors.* FROM authors
                                Left Join Books ON Authors.Authorid = books.AuthorId
                                WHERE basePrice>= @minPrice AND basePrice<= @maxPrice
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE AuthorsBookspriceRange");
        }
    }
}
