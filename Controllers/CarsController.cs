using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarModels.Models;

namespace CarModels.Controllers
{
  public class CarsController : Controller
  {
    // Declares the DbContext class
  
    private ApplicationDbContext dataContext;
    // The instance of DbContext is passed via dependency injection
    public CarsController(ApplicationDbContext context)
    {
      this.dataContext=context;
    }
    // GET: /<controller>/
    // Return the list of cars to the caller view
    public IActionResult Index()
    {
     var displaydata=dataContext.Cars.ToList();
     return View(displaydata);
    }
    public IActionResult Create()
    {
      return View();
    }
    // Add a new object via a POST request
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
      // If the data model is in a valid state ...
      if (ModelState.IsValid)
      {
        // ... add the new object to the collection
        dataContext.Cars.Add(car);
        // Save changes and return to the Index method
        dataContext.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(car);
    }
    [ActionName("Delete")]
    public IActionResult Delete(int? id)
    {
      if (id == null)
      {
        return HttpNotFound();
      }
      Car car = dataContext.Cars.Single(m => m.id == id);
      if (car == null)
      {
        return HttpNotFound();
      }
      return View(car);
    }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // POST: Cars/Delete/5
        // Delete an object via a POST request
        [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      Car car = dataContext.Cars.SingleOrDefault(m => m.id == id);
      // Remove the car from the collection and save changes
      dataContext.Cars.Remove(car);
      dataContext.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}