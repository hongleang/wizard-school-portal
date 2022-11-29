using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPortalApi.Data.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Quote = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    Motto = table.Column<string>(type: "TEXT", nullable: false),
                    LogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    FounderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02f38c5f-5b90-4958-8420-2b299a9a5a01", "139789a0-75fc-454d-b0b1-fcd2bdbfca21", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "252e59ea-a7d0-4702-96cc-6c7f9943886c", "c3536205-ee63-4414-a7f3-5b3a47e5a767", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Founders",
                columns: new[] { "Id", "Gender", "ImageUrl", "Name", "Quote" },
                values: new object[] { 1, "male", "https://static.wikia.nocookie.net/harrypotter/images/3/31/Founders_gryffindor1.jpg/revision/latest?cb=20180611200439", "Godric Gryffindor", "We'll teach all those with brave deeds to their name." });

            migrationBuilder.InsertData(
                table: "Founders",
                columns: new[] { "Id", "Gender", "ImageUrl", "Name", "Quote" },
                values: new object[] { 2, "female", "https://static.wikia.nocookie.net/harrypotter/images/d/d7/Helga_Hufflepuff.jpg/revision/latest?cb=20140615154415", "Helga Hufflepuff", "I'll teach the lot and treat them just the same." });

            migrationBuilder.InsertData(
                table: "Founders",
                columns: new[] { "Id", "Gender", "ImageUrl", "Name", "Quote" },
                values: new object[] { 3, "female", "https://static.wikia.nocookie.net/harrypotter/images/f/fd/Rowena_Ravenclaw_at_WWHP.jpg/revision/latest?cb=20140615151812", "Rowena Ravenclaw", "Wit beyond measure is man's greatest treasure." });

            migrationBuilder.InsertData(
                table: "Founders",
                columns: new[] { "Id", "Gender", "ImageUrl", "Name", "Quote" },
                values: new object[] { 4, "male", "https://static.wikia.nocookie.net/harrypotter/images/8/86/Salazar_Slytherin_WWHP.jpg/revision/latest?cb=20140615154545", "Salazar Slytherin", "We'll teach just those whose ancestry's purest." });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "FounderId", "LogoUrl", "Motto", "Name", "Value" },
                values: new object[] { 1, 1, "https://static.wikia.nocookie.net/harrypotter/images/9/98/Gryffindor.jpg/revision/latest?cb=20110503103732", "You might belong in Gryffindor,\r\nWhere dwell the brave at heart,\r\nTheir daring, nerve and chivalry\r\nSet Gryffindors apart.", "Gryffindor", "bravery, daring, nerve, and chivalry" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "FounderId", "LogoUrl", "Motto", "Name", "Value" },
                values: new object[] { 2, 2, "https://static.wikia.nocookie.net/harrypotter/images/0/06/Hufflepuff_ClearBG.png/revision/latest?cb=20161020182518", "You might belong in Hufflepuff\r\nWhere they are just and loyal\r\nThose patient Hufflepuffs are true\r\nAnd unafraid of toil", "Hufflepuff", "hard work, dedication, patience, loyalty, and fair play" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "FounderId", "LogoUrl", "Motto", "Name", "Value" },
                values: new object[] { 3, 3, "https://static.wikia.nocookie.net/harrypotter/images/7/71/Ravenclaw_ClearBG.png/revision/latest?cb=20161020182442", "Or yet in wise old Ravenclaw\r\nIf you’ve a ready mind\r\nWhere those of wit and learning\r\nWill always find their kind", "Ravenclaw", "intelligence, knowledge, curiosity, creativity and wit" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "FounderId", "LogoUrl", "Motto", "Name", "Value" },
                values: new object[] { 4, 4, "https://static.wikia.nocookie.net/harrypotter/images/0/00/Slytherin_ClearBG.png/revision/latest?cb=20161020182557", "Or perhaps in Slytherin\r\nYou’ll make your real friends\r\nThose cunning folk use any means\r\nTo achieve their ends", "Slytherin", "ambition, leadership, self-preservation, cunning and resourcefulness" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 1, "male", 1, "http://hp-api.herokuapp.com/images/harry.jpg,Gryffindor", "Harry Potter" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 2, "female", 1, "http://hp-api.herokuapp.com/images/hermione.jpeg,Gryffindor", "Hermione Granger" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 3, "male", 1, "http://hp-api.herokuapp.com/images/ron.jpg,Gryffindor", "Ron Weasley" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 4, "male", 4, "http://hp-api.herokuapp.com/images/draco.jpg,Slytherin", "Draco Malfoy" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 5, "female", 4, "http://hp-api.herokuapp.com/images/bellatrix.jpg,Slytherin", "Bellatrix Lestrange" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 6, "female", 3, "http://hp-api.herokuapp.com/images/cho.jpg,Ravenclaw", "Cho Chang" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 7, "female", 3, "http://hp-api.herokuapp.com/images/luna.jpg,Ravenclaw", "Luna Lovegood" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 8, "male", 2, "http://hp-api.herokuapp.com/images/cedric.png,Hufflepuff", "Cedric Diggory" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Gender", "HouseId", "ImageUrl", "Name" },
                values: new object[] { 9, "female", 2, "https://static.wikia.nocookie.net/harrypotter/images/c/c8/Nymphadora_Tonks_DH_promo_headshot_.jpg/revision/latest?cb=20161119222048,Hufflepuff", "Nymphadora Tonks" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HouseId",
                table: "Characters",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_FounderId",
                table: "Houses",
                column: "FounderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Founders");
        }
    }
}
