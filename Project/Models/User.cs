using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class User
{
    //Primary key defined automaticaly
    public int UserId { get; set; }

    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 15 char")]
    [Required(ErrorMessage = "The First Name is required.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 15 char")]
    [Required(ErrorMessage = "The Last Name is required.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [EmailAddress]
    [Display(Name = "Email")]
    [Required(ErrorMessage = "The Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

}
