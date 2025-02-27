using Microsoft.AspNetCore.Mvc;
using MVCToDoList.Interfaces;
using MVCToDoList.Models;

namespace MVCToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemRepository _repository;

        public ToDoController(ITodoItemRepository repository)
        {
            _repository=repository;
        }

        public async Task<ActionResult> Index()
        {
            var list = await _repository.GetAllAsync();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoItem model)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(model);
                var list = await _repository.GetAllAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(Guid guid)
        {
            var item = await _repository.FindById(guid);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoItem model)
        {
            var item = await _repository.FindById(model.GuidItem);
            item.Description = model.Description;
            item.Done = model.Done;
            await _repository.Update(item);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Mark(Guid guidItem)
        {
            var item = await _repository.FindById(guidItem);
            item.Done = !item.Done;
            await _repository.Update(item);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(Guid guid)
        {
            var item = _repository.FindById(guid);
            return View(item);
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid guid, IFormCollection formCollection)
        {
            var item = await _repository.FindById(guid);
            await _repository.Remove(item);
            var list = await _repository.GetAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
