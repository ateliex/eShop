using eShop.Modules.Customers;
using eShop.Modules.ProductCatalog;
using eShop.Modules.ShoppingCart;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eShop.Data;

public class ApplicationDbContext : IdentityDbContext<Customer>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Model>().Property(x => x.Price).HasPrecision(12, 2);

        builder.Entity<Model>().Property(x => x.Discount).HasPrecision(12, 2);

        builder.Entity<Model>().Property(x => x.Sizes).HasConversion<SemicolonSplitStringConverter, SplitStringComparer>();

        builder.Entity<Model>().Property(x => x.Colors).HasConversion<SemicolonSplitColorConverter, SplitColorComparer>();

        builder.Entity<Model>().Property(x => x.Features).HasConversion<SemicolonSplitStringConverter, SplitStringComparer>();

        builder.Entity<Model>().HasData(
            new Model { Id = 1, Name = "Default" },
            new Model { Id = 2, Name = "Camiseta masculina de futebol Park VII", BrandId = 1, CategoryId = 8, Sizes = new[] { "P", "M", "G", "GG", "XG" }, Colors = new Color[] { new Color { Name = "Azul-celeste", RBG = "829fd6" }, new Color { Name = "Laranja", RBG = "ef5740" }, new Color { Name = "Branco", RBG = "d8d7de" }, new Color { Name = "Preto", RBG = "1b1b1b" }, new Color { Name = "Royal", RBG = "435498" }, new Color { Name = "Turquesa", RBG = "435498" }, new Color { Name = "Verde", RBG = "316551" }, new Color { Name = "Volt", RBG = "b8f758" }, new Color { Name = "Cinza", RBG = "b1b2b6" }, new Color { Name = "Dourado", RBG = "f6ae35" }, new Color { Name = "Carmesim", RBG = "f51c51" }, new Color { Name = "Roxa", RBG = "4d177a" }, new Color { Name = "Vermelho", RBG = "b62436" } }, Features = new[] { "A tecnologia Dri-FIT ajuda a manter você seco e confortável", "Painel traseiro de malha adiciona respirabilidade", "Este produto é feito com fibras de poliéster 100% recicladas" }, Description = "A camiseta Youth Park VII é uma camisa de manga curta Dri-Fit com gola redonda de tecido próprio. Sem costura sob o braço para melhor movimento. Painéis laterais de malha para ventilação máxima." },
            new Model { Id = 3, Name = "Calções de Futebol Park III", BrandId = 1, CategoryId = 8, Sizes = new[] { "P", "M", "G", "GG", "XG" }, Colors = new Color[] { new Color { Name = "Cinza", RBG = "a1a8ac" }, new Color { Name = "Hyper Turq", RBG = "86d3c9" }, new Color { Name = "Royal", RBG = "0f429d" }, new Color { Name = "Vermelho", RBG = "be2a3a" }, new Color { Name = "Val Blue", RBG = "89a6d2" }, new Color { Name = "Volt", RBG = "adec4c" }, new Color { Name = "Carmesim", RBG = "f31458" } }, Features = new[] { "A tecnologia Dri-FIT ajuda você a se manter seco, confortável e focado.", "A cintura elástica é forrada com malha para respirabilidade e tem um cordão." }, Description = "Os shorts de futebol masculinos Nike Dri-FIT Park III são projetados com tecido de poliéster respirável que proporcionam propriedades de secagem rápida, que se traduzem em conforto e foco total durante o treinamento. Estes shorts de corrida Nike oferecem tecnologia Dri-FIT que ajuda a manter você seco ao absorver a umidade da pele. Os shorts de treinamento proporcionam corte ajustado com a costura lateral perfilada que se encaixa perfeitamente no corpo, deixando a máxima amplitude de movimento. Os shorts de ginástica oferecem estabilização é fornecida por uma cintura elástica com um cordão. Shorts esportivos fornecem forro de malha que suporta a respirabilidade dos shorts. Estes shorts masculinos oferecem um logotipo sutil que caberá em qualquer roupa de treino. Material: 100% poliéster reciclado." },
            new Model { Id = 4, Name = "Regata em Ribana", BrandId = 2, CategoryId = 8, Sizes = new[] { "P", "M", "G", "GG" }, Colors = new Color[] { new Color { Name = "Branco", RBG = "d9dbde" }, new Color { Name = "Mescla Claro", RBG = "c2c0bd" }, new Color { Name = "Preto", RBG = "1f1c23" } }, Features = new[] { "100% Algodão", "Peça básica", "Modelagem Slim", "Ajuste ao corpo e nas cavas", "Feito no Brasil" }, Description = "Regata básica masculina, confeccionada em malha ribana de algodão. A malha proporciona um caimento perfeito, ideal para quem deseja aliar conforto e estilo. Possui modelagem slim, ajustada ao corpo e nas cavas, conta com alças largas e decote redondo. Perfeita para compor looks leves e frescos nos dias mais quentes. Aposte em combinações com shorts e bermudas Hering!" },
            new Model { Id = 5, Name = "Camiseta feminina US SS Park VII", BrandId = 1, CategoryId = 4, Sizes = new[] { "P", "M", "G", "GG" }, Colors = new Color[] { new Color { Name = "Roxa", RBG = "5f538f" } }, Features = new[] { "A tecnologia Dri-FIT ajuda a manter você seco e confortável.", "Painel traseiro de malha adiciona respirabilidade.", "Este produto é feito com fibras de poliéster 100% recicladas." }, Description = "A camiseta Dri-FIT Park da Nike tem fibras que absorvem o suor para ajudar a manter você seco e confortável para o jogo. A malha na parte de trás adiciona ventilação. Este produto é feito com fibras de poliéster 100% recicladas." }
        );

        builder.Entity<Product>().Property(x => x.Price).HasPrecision(12, 2);

        builder.Entity<Product>().Property(x => x.Discount).HasPrecision(12, 2);

        builder.Entity<Product>().HasData(
            new Product { Id = 1, Price = 237.82m, Size = "P", Color = "Azul-celeste", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg" },
            new Product { Id = 2, Price = 246.23m, Size = "M", Color = "Azul-celeste", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg" },
            new Product { Id = 3, Price = 299.31m, Size = "G", Color = "Azul-celeste", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_azul_celeste.jpg", Discount = 53.08m },
            new Product { Id = 4, Price = 285.22m, Size = "G", Color = "Laranja", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_laranja.jpg" },
            new Product { Id = 5, Price = 286.65m, Size = "GG", Color = "Laranja", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_laranja.jpg" },
            new Product { Id = 6, Price = 255.79m, Size = "M", Color = "Preto", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_preto.jpg" },
            new Product { Id = 7, Price = 257.89m, Size = "G", Color = "Preto", ModelId = 2, ImageUri = "https://localhost:44376/img/nike_camiseta_masculina_futebol_preto.jpg" },
            new Product { Id = 8, Price = 222.82m, Size = "P", Color = "Vermelho", ModelId = 3, ImageUri = "https://localhost:44376/img/nike_calcoes_masculino_futebol_vermelho.jpg" },
            new Product { Id = 9, Price = 264.58m, Size = "M", Color = "Cinza", ModelId = 3, ImageUri = "https://localhost:44376/img/nike_calcoes_masculino_futebol_cinza.jpg" },
            new Product { Id = 10, Price = 59.99m, Size = "G", Color = "Preto", ModelId = 4, ImageUri = "https://localhost:44376/img/hering_regata_masculino_ribana_preto.jpg" },
            new Product { Id = 11, Price = 298.01m, Size = "P", Color = "Roxa", ModelId = 5, ImageUri = "https://localhost:44376/img/nike_camiseta_feminina_roxa.jpg" },
            new Product { Id = 12, Price = 298.01m, Size = "M", Color = "Roxa", ModelId = 5, ImageUri = "https://localhost:44376/img/nike_camiseta_feminina_roxa.jpg" }
        );

        builder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Nike" },
            new Brand { Id = 2, Name = "Hering" },
            new Brand { Id = 3, Name = "Colcci" },
            new Brand { Id = 4, Name = "Adidas" },
            new Brand { Id = 5, Name = "Lacoste" },
            new Brand { Id = 6, Name = "Malwee" },
            new Brand { Id = 7, Name = "Levi's" },
            new Brand { Id = 8, Name = "John John" },
            new Brand { Id = 9, Name = "Rovitex" },
            new Brand { Id = 10, Name = "Ralph Lauren" }
        );

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category A" },
            new Category { Id = 2, Name = "Category B" },
            new Category { Id = 3, Name = "Category C" },
            new Category { Id = 4, Name = "Femininas" },
            new Category { Id = 5, Name = "Especiais" },
            new Category { Id = 6, Name = "Esporte" },
            new Category { Id = 7, Name = "Futebol" },
            new Category { Id = 8, Name = "Masculinas" },
            new Category { Id = 9, Name = "Regatas" },
            new Category { Id = 10, Name = "Camisas" }
        );

        builder.Entity<Cart>().HasMany(a => a.Items).WithOne(b => b.Cart).HasForeignKey(b => b.CartId);

        builder.Entity<CartItem>().HasKey(x => new { x.CartId, x.ProductId });

        builder.Entity<CartItem>().Property(x => x.UnitPrice).HasPrecision(12, 2);
    }

    public DbSet<Model> Models { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Cart> Carts { get; set; }
}

public class SplitStringComparer : ValueComparer<string[]>
{
    public SplitStringComparer() : base(
        (c1, c2) => new HashSet<string>(c1!).SetEquals(new HashSet<string>(c2!)),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())))
    {
    }
}

public abstract class SplitStringConverter : ValueConverter<string[], string>
{
    protected SplitStringConverter(char delimiter) : base(
        v => string.Join(delimiter.ToString(), v),
        v => v.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries))
    {
    }
}

public class SemicolonSplitStringConverter : SplitStringConverter
{
    public SemicolonSplitStringConverter() : base(';')
    {
    }
}




public class SplitColorComparer : ValueComparer<Color[]>
{
    public SplitColorComparer() : base(
        (color1, color2) => new HashSet<Color>(color1!).SetEquals(new HashSet<Color>(color2!)),
        colors => colors.Aggregate(0, (hash, color) => HashCode.Combine(hash, color.GetHashCode())))
    {
    }
}

public abstract class SplitColorConverter : ValueConverter<Color[], string>
{
    protected SplitColorConverter(char delimiter) : base(
        colors => string.Join(delimiter.ToString(), colors.Select(color => $"{color.Name},{color.RBG}").ToArray()),
        value => Split(delimiter, value))
    {
    }

    private static Color[] Split(char delimiter, string value)
    {
        var result = value
            .Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                var y = x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                return new Color { Name = y[0], RBG = y[1] };
            })
            .ToArray();

        return result;
    }
}

public class SemicolonSplitColorConverter : SplitColorConverter
{
    public SemicolonSplitColorConverter() : base(';')
    {
    }
}
