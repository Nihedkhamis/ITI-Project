using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy literature is literature set in an imaginary universe, often but not always without any locations, events, or people from the real world", "Fantasy" },
                    { 2, "Mystery is a fiction genre where the nature of an event, usually a murder or other crime, remains mysterious until the end of the story.", "Mystery" },
                    { 3, "Horror story, a story in which the focus is on creating a feeling of fear.", "Horror" },
                    { 4, "Biography book about a single person's life and work, but probably with a great deal, too, about their family and friends, relations and children, colleagues and acquaintances.", "Biography" },
                    { 5, "Science fiction speculates about alternative ways of life made possible by technological change, and hence has sometimes been called speculative fiction.", "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "West blends her unique magic system with a vivid world and fairy tale elements to create a story that is entirely fascinating.", "https://i.ebayimg.com/images/g/~QkAAOSwU6Vf~nbt/s-l960.webp", 4.52m, 12, "Realm of Ruins" },
                    { 2, 2, "Joanna Blalock's keen mind and incredible insight lead her to become a highly-skilled nurse, one of the few professions that allow her to use her finely-tuned brain.", "https://i.ebayimg.com/images/g/PMEAAOSwuC5f~4Vw/s-l960.webp", 8.23m, 33, "The Daughter of Sherlock Holmes" },
                    { 3, 3, "Aveline loves reading ghost stories, so a dreary half-term becomes much more exciting when she discovers a spooky old book.", "https://i.ebayimg.com/images/g/fmAAAOSwmxNm0Rm3/s-l1600.webp", 13.66m, 5, "The Haunting of Aveline Jones" },
                    { 4, 4, "This biography describes Einstein's early struggle to harness and focus his extraordinary abilities; his relationships with his family and first wife; and, lending depth to the story, his most significant scientific.", "https://i.ebayimg.com/images/g/K3EAAOSwWxNYpJRH/s-l960.webp", 6.90m, 17, "Who Was Albert Einstein?" },
                    { 5, 5, "Trapped in cryo-sleep for two centuries, Auri is a girl out of time and out of her depth. But she could be the catalyst that starts a war millions of years in the making, and Tyler's squad of losers, discipline cases, and misfits might just be the last hope for the entire galaxy.", "https://i.ebayimg.com/images/g/YZsAAOSwyvdmylVw/s-l960.webp", 17.91m, 55, "Aurora Rising" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
