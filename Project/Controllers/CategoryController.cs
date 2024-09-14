using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Project.Context;
using Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Controllers;

public class CategoryController : Controller
{
    //Create the database
    MyContext db = new MyContext();

    //Return the Home Page of Categories
    public IActionResult Index()
    {
        var _categories = db.Categories;
        return View(_categories);
    }

    //Used to return the empty form to insert data of new category
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //Used to insert new category into database
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "All Fields Required");
            return View(category);
        }

        db.Categories.Add(category);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    //Used to display view which in it display the details of each category
    public IActionResult ViewDetails(int id)
    {
        var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        return View(category);
    }

    //return the view which include the last data of category which i apply update on it
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var oldCategory = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (oldCategory == null)
        {
            return RedirectToAction("Index");
        }
        return View(oldCategory);
    }

    //update the category with the updated data of the category in database
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "All Fields Required");
            return View(category);
        }
        db.Categories.Update(category);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    //Return the delete page 
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
        return View(category);
    }

    //Apply deletion of the category in database 
    [HttpPost]
    public IActionResult Delete(Category DelCategory)
    {
        db.Categories.Remove(DelCategory);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
