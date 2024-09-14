using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Project.Context;
using Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Controllers;

public class ProductController : Controller
{
    //Create the database
    MyContext db = new MyContext();

    //Return the Home Page of products
    public IActionResult Index()
    {
        var _products = db.Products.Include(p => p.Category);
        return View(_products);
    }

    //Used to return the empty form to insert data of new product
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
        return View();
    }

    //Used to insert new product into database
    [HttpPost]
    public IActionResult Create(Product product)
    {
        ModelState.Remove("Category");
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "All Fields Required");
            ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }

        db.Products.Add(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    //Used to display view which in it display the details of each product
    public IActionResult ViewDetails(int id)
    {
        var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        return View(product);
    }

    //return the view which include the last data of product which i apply update on it
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var oldProduct = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        if (oldProduct == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
        return View(oldProduct);
    }

    //update the product with the updated data of the product in database
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        ModelState.Remove("Category");
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "All Fields Required");
            ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }
        db.Products.Update(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    //Return the delete page 
    [HttpGet]
    //return view which contain data of product want to delete it
    public IActionResult Delete(int id)
    {
        var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        return View(product);
    }

    //Apply deletion of the product in database 
    [HttpPost]
    public IActionResult Delete(Product DelProduct)
    {
        db.Products.Remove(DelProduct);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
