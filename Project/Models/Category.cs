using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Category
{
    //Primary key defined automaticaly
    public int CategoryId{get; set;}

    [Required(ErrorMessage = "The name is required.")]
    public string Name{get; set;}

    [Required(ErrorMessage = "The description is required.")]
    public string Description{get; set;}

    //Navigation Property
    public virtual HashSet<Product> Products{get; set;} = new HashSet<Product>();
}
