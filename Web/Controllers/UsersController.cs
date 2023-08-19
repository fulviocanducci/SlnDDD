using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.DataAccess;

namespace Web.Controllers
{
   public class UsersController : Controller
   {
      public DataContext DataContext { get; }

      public UsersController(DataContext dataContext)
      {
         DataContext = dataContext;
      }
      public ActionResult Index()
      {
         return View(DataContext.User);
      }

      public ActionResult Details(int id)
      {
         return View(DataContext.User.Find(id));
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(User model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               DataContext.User.Add(model);
               DataContext.SaveChanges();
               return RedirectToAction(nameof(Edit), new { model.Id });
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: Users/Edit/5
      public ActionResult Edit(int id)
      {
         return View(DataContext.User.Find(id));
      }

      // POST: Users/Edit/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(int id, User model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               DataContext.User.Update(model);
               DataContext.SaveChanges();
               return RedirectToAction(nameof(Edit), new { model.Id });
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: Users/Delete/5
      public ActionResult Delete(int id)
      {
         return View();
      }

      // POST: Users/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
