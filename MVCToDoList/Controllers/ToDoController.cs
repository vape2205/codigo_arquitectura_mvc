using Microsoft.AspNetCore.Mvc;
using MVCToDoList.Models;

namespace MVCToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDo> _list = new List<ToDo>
        {
            new ToDo{ Description = "Item 1", Done = false },
            new ToDo{ Description = "Item 2", Done = false },
            new ToDo{ Description = "Item 3", Done = false },
            new ToDo{ Description = "Item 4", Done = false },
            new ToDo{ Description = "Item 5", Done = false },
            new ToDo{ Description = "Item 6", Done = false },
            new ToDo{ Description = "Item 7", Done = false },
            new ToDo{ Description = "Item 8", Done = false },
        };

        public ActionResult Index()
        {
            return View(_list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo model)
        {
            if (ModelState.IsValid)
            {
                _list.Add(model);
                return View("Index", _list);
            }
            else
            {
                ModelState.AddModelError("Description", "Modelo no valido");
                return View();
            }

        }

        public ActionResult Edit(Guid guid)
        {
            var item = _list.First(x => x.GuidItem == guid);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDo model)
        {
            var item = _list.First(x => x.GuidItem == model.GuidItem);
            item.Description = model.Description;
            item.Done = model.Done;
            return View("Index", _list);
        }

        public ActionResult Delete(Guid guid)
        {
            var item = _list.First(x => x.GuidItem == guid);
            return View(item);
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid guid, IFormCollection formCollection)
        {
            var item = _list.First(x => x.GuidItem == guid);
            _list.Remove(item);
            return View("Index", _list);
        }
    }
}
