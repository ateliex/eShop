using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CartItem",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Models_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Hering" },
                    { 3, "Colcci" },
                    { 4, "Adidas" },
                    { 5, "Lacoste" },
                    { 6, "Malwee" },
                    { 7, "Levi's" },
                    { 8, "John John" },
                    { 9, "Rovitex" },
                    { 10, "Ralph Lauren" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category A" },
                    { 2, "Category B" },
                    { 3, "Category C" },
                    { 4, "Femininas" },
                    { 5, "Especiais" },
                    { 6, "Esporte" },
                    { 7, "Futebol" },
                    { 8, "Masculinas" },
                    { 9, "Regatas" },
                    { 10, "Camisas" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "CategoryId", "Colors", "Description", "Discount", "Features", "ImageUri", "Name", "Price", "Sizes", "Slogan" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, "Default", null, null, null },
                    { 2, 1, 8, "Azul-celeste,829fd6;Laranja,ef5740;Branco,d8d7de;Preto,1b1b1b;Royal,435498;Turquesa,435498;Verde,316551;Volt,b8f758;Cinza,b1b2b6;Dourado,f6ae35;Carmesim,f51c51;Roxa,4d177a;Vermelho,b62436", "A camiseta Youth Park VII é uma camisa de manga curta Dri-Fit com gola redonda de tecido próprio. Sem costura sob o braço para melhor movimento. Painéis laterais de malha para ventilação máxima.", null, "A tecnologia Dri-FIT ajuda a manter você seco e confortável;Painel traseiro de malha adiciona respirabilidade;Este produto é feito com fibras de poliéster 100% recicladas", null, "Camiseta masculina de futebol Park VII", null, "P;M;G;GG;XG", null },
                    { 3, 1, 8, "Cinza,a1a8ac;Hyper Turq,86d3c9;Royal,0f429d;Vermelho,be2a3a;Val Blue,89a6d2;Volt,adec4c;Carmesim,f31458", "Os shorts de futebol masculinos Nike Dri-FIT Park III são projetados com tecido de poliéster respirável que proporcionam propriedades de secagem rápida, que se traduzem em conforto e foco total durante o treinamento. Estes shorts de corrida Nike oferecem tecnologia Dri-FIT que ajuda a manter você seco ao absorver a umidade da pele. Os shorts de treinamento proporcionam corte ajustado com a costura lateral perfilada que se encaixa perfeitamente no corpo, deixando a máxima amplitude de movimento. Os shorts de ginástica oferecem estabilização é fornecida por uma cintura elástica com um cordão. Shorts esportivos fornecem forro de malha que suporta a respirabilidade dos shorts. Estes shorts masculinos oferecem um logotipo sutil que caberá em qualquer roupa de treino. Material: 100% poliéster reciclado.", null, "A tecnologia Dri-FIT ajuda você a se manter seco, confortável e focado.;A cintura elástica é forrada com malha para respirabilidade e tem um cordão.", null, "Calções de Futebol Park III", null, "P;M;G;GG;XG", null },
                    { 4, 2, 8, "Branco,d9dbde;Mescla Claro,c2c0bd;Preto,1f1c23", "Regata básica masculina, confeccionada em malha ribana de algodão. A malha proporciona um caimento perfeito, ideal para quem deseja aliar conforto e estilo. Possui modelagem slim, ajustada ao corpo e nas cavas, conta com alças largas e decote redondo. Perfeita para compor looks leves e frescos nos dias mais quentes. Aposte em combinações com shorts e bermudas Hering!", null, "100% Algodão;Peça básica;Modelagem Slim;Ajuste ao corpo e nas cavas;Feito no Brasil", null, "Regata em Ribana", null, "P;M;G;GG", null },
                    { 5, 1, 4, "Roxa,5f538f", "A camiseta Dri-FIT Park da Nike tem fibras que absorvem o suor para ajudar a manter você seco e confortável para o jogo. A malha na parte de trás adiciona ventilação. Este produto é feito com fibras de poliéster 100% recicladas.", null, "A tecnologia Dri-FIT ajuda a manter você seco e confortável.;Painel traseiro de malha adiciona respirabilidade.;Este produto é feito com fibras de poliéster 100% recicladas.", null, "Camiseta feminina US SS Park VII", null, "P;M;G;GG", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Color", "Description", "Discount", "ImageUri", "ModelId", "Name", "Price", "Size", "Slogan" },
                values: new object[,]
                {
                    { 1, null, null, "Azul-celeste", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg", 2, null, 237.82m, "P", null },
                    { 2, null, null, "Azul-celeste", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg", 2, null, 246.23m, "M", null },
                    { 3, null, null, "Azul-celeste", null, 53.08m, "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg", 2, null, 299.31m, "G", null },
                    { 4, null, null, "Laranja", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_laranja.jpg", 2, null, 285.22m, "G", null },
                    { 5, null, null, "Laranja", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_laranja.jpg", 2, null, 286.65m, "GG", null },
                    { 6, null, null, "Preto", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_preto.jpg", 2, null, 255.79m, "M", null },
                    { 7, null, null, "Preto", null, null, "https://localhost:44376/img/nike_camiseta_masculina_futebol_preto.jpg", 2, null, 257.89m, "G", null },
                    { 8, null, null, "Vermelho", null, null, "https://localhost:44376/img/nike_calcoes_masculino_futebol_vermelho.jpg", 3, null, 222.82m, "P", null },
                    { 9, null, null, "Cinza", null, null, "https://localhost:44376/img/nike_calcoes_masculino_futebol_cinza.jpg", 3, null, 264.58m, "M", null },
                    { 10, null, null, "Preto", null, null, "https://localhost:44376/img/hering_regata_masculino_ribana_preto.jpg", 4, null, 59.99m, "G", null },
                    { 11, null, null, "Roxa", null, null, "https://localhost:44376/img/nike_camiseta_feminina_roxa.jpg", 5, null, 298.01m, "P", null },
                    { 12, null, null, "Roxa", null, null, "https://localhost:44376/img/nike_camiseta_feminina_roxa.jpg", 5, null, 298.01m, "M", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CategoryId",
                table: "Models",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");
        }

        /// <inheritdoc />
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
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
