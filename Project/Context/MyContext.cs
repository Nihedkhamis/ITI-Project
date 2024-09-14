
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Models;

namespace Project.Context;

public class MyContext : DbContext
{
    //Used to make connection with database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OP9NQR9; Database=AppData; Trusted_Connection=true; Encrypt=false");
    }

    //Used to apply concept of seading data on Category and Product models
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seading data of Category model
        var _Categories = new List<Category>
        {
            new Category{CategoryId = 1, Name="Fantasy", Description = "Fantasy literature is literature set in an imaginary universe, often but not always without any locations, events, or people from the real world"},
            new Category{CategoryId = 2, Name = "Mystery", Description = "Mystery is a fiction genre where the nature of an event, usually a murder or other crime, remains mysterious until the end of the story."},
            new Category{CategoryId = 3, Name = "Horror", Description = "Horror story, a story in which the focus is on creating a feeling of fear."},
            new Category{CategoryId = 4, Name = "Biography", Description = "Biography book about a single person's life and work, but probably with a great deal, too, about their family and friends, relations and children, colleagues and acquaintances."},
            new Category{CategoryId = 5, Name = "Science Fiction", Description = "Science fiction speculates about alternative ways of life made possible by technological change, and hence has sometimes been called speculative fiction."}
        };

        //Seading data of Product model
        var _Products = new List<Product>
        {
            new Product{ProductId = 1, Title = "Realm of Ruins", Price = 4.52M, Description = "West blends her unique magic system with a vivid world and fairy tale elements to create a story that is entirely fascinating.", Quantity = 12, ImagePath = "https://i.ebayimg.com/images/g/~QkAAOSwU6Vf~nbt/s-l960.webp", CategoryId = 1},
            new Product{ProductId = 2, Title = "The Daughter of Sherlock Holmes", Price = 8.23M, Description = "Joanna Blalock's keen mind and incredible insight lead her to become a highly-skilled nurse, one of the few professions that allow her to use her finely-tuned brain.", Quantity = 33, ImagePath = "https://i.ebayimg.com/images/g/PMEAAOSwuC5f~4Vw/s-l960.webp", CategoryId = 2},
            new Product{ProductId = 3, Title = "The Haunting of Aveline Jones", Price = 13.66M, Description = "Aveline loves reading ghost stories, so a dreary half-term becomes much more exciting when she discovers a spooky old book.", Quantity = 5, ImagePath = "https://i.ebayimg.com/images/g/fmAAAOSwmxNm0Rm3/s-l1600.webp", CategoryId = 3},
            new Product{ProductId = 4, Title = "Who Was Albert Einstein?", Price = 6.90M, Description = "This biography describes Einstein's early struggle to harness and focus his extraordinary abilities; his relationships with his family and first wife; and, lending depth to the story, his most significant scientific.", Quantity = 17, ImagePath = "https://i.ebayimg.com/images/g/K3EAAOSwWxNYpJRH/s-l960.webp", CategoryId = 4},
            new Product{ProductId = 5, Title = "Aurora Rising", Price = 17.91M, Description = "Trapped in cryo-sleep for two centuries, Auri is a girl out of time and out of her depth. But she could be the catalyst that starts a war millions of years in the making, and Tyler's squad of losers, discipline cases, and misfits might just be the last hope for the entire galaxy.", Quantity = 55, ImagePath = "https://i.ebayimg.com/images/g/YZsAAOSwyvdmylVw/s-l960.webp", CategoryId = 5}
        };

        //Insert Data into Entities
        modelBuilder.Entity<Category>().HasData(_Categories);
        modelBuilder.Entity<Product>().HasData(_Products);

    }

    public virtual DbSet<User> Users{get; set;}
    public virtual DbSet<Product> Products{get; set;}
    public virtual DbSet<Category> Categories{get; set;}
}
