using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models;

public class Product
{
    //Primary key defined automaticaly
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The title is required.")]
    public string Title { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Price in $")]
    [Required(ErrorMessage = "The price is required.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The quantity is required.")]
    public int Quantity { get; set; }

    [DataType(DataType.ImageUrl)]
    [Required(ErrorMessage = "The ImagePath is required.")]
    public string ImagePath { get; set; }

    //Foreign key defined automaticaly
    [Required(ErrorMessage = "Category field is required.")]

    //Foreign Key refer to primary key in category model
    public int CategoryId { get; set; }

    //Navigation Property
    public virtual Category? Category { get; set; }
}
