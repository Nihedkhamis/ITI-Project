using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Context;
using Project.Models;

namespace Project.Controllers;

public class UserController : Controller
{
    //Create the database
    MyContext db = new MyContext();

    //Return the page contain login and Register buttons
    public IActionResult Index()
    {
        return View();
    }

    //Return the empty registeration page
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    //Used to register the new user into database
    [HttpPost]
    public IActionResult Register(User NewUser)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "All Fields Required");
            return View(NewUser);
        }

        var isEmailAlreadyExists = db.Users.Any(x => x.Email == NewUser.Email);

        if (isEmailAlreadyExists)
        {
            ModelState.AddModelError("Email", "User with this email already exists");
            return View(NewUser);
        }

        db.Users.Add(NewUser);
        db.SaveChanges();
        return RedirectToAction("Login");
    }

    //Return the empty login page
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(User ExistUser)
    {
        var isUserAlreadyExist = db.Users.Any(u => u.Email!.Equals(ExistUser.Email) && u.Password!.Equals(ExistUser.Password));

        if (!isUserAlreadyExist)
        {
            if (!db.Users.Any(u => u.Email!.Equals(ExistUser.Email)))
                ModelState.AddModelError("Email", "This email not exist");

            if (!db.Users.Any(u => u.Password!.Equals(ExistUser.Password)))
                ModelState.AddModelError("Password", "The last written password is not correct");

            return View(ExistUser);
        }

        return RedirectToAction("Index", "Product");
    }
}
