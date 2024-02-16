using TaskMan.Models;
using Microsoft.AspNetCore.Mvc;
using Task = TaskMan.Models.Task;

namespace TaskMan.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Tasks.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(task);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There is something wrong with your information.");
                    return View(task);
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";
                return View(task);
            }

        }

        public IActionResult Edit(int Id)
        {
            var task = _context.Tasks.Find(Id);

            if (task == null)
            {
                ModelState.AddModelError(string.Empty, "Expense not found.");
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Task updatedTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var eTask = _context.Tasks.Find(id);
                    eTask.Name = updatedTask.Name;
                    eTask.Description = updatedTask.Description;
                    eTask.Created = updatedTask.Created;
                    eTask.Completed = updatedTask.Completed;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There is something wrong with your information.");
                    return View(updatedTask);
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";
                return View(updatedTask);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError(string.Empty, "Expense not found.");
                return RedirectToAction("Index");
            }
            var expense = _context.Tasks.Find(id);
            if (expense == null)
            {
                ModelState.AddModelError(string.Empty, "Expense not found.");
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
