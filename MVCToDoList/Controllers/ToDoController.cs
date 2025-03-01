using Microsoft.AspNetCore.Mvc;
using MVCToDoList.DTOs.ToDoItem;
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
            var listModel = new List<ViewItem>();
            foreach (var item in list)
            {
                listModel.Add(new ViewItem
                {
                    GuidItem = item.GuidItem,
                    Description = item.Description,
                    Done = item.Done
                });
            }
            return View(listModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateItem model)
        {
            if (ModelState.IsValid)
            {
                var entity = new ToDoItem
                {
                    Description = model.Description,
                    Done = model.Done
                };
                await _repository.Add(entity);
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
            var model = new ViewItem
            {
                GuidItem = item.GuidItem,
                Description = item.Description,
                Done = item.Done
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditItem model)
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

        public async Task<ActionResult> Delete(Guid guid)
        {
            var item = await _repository.FindById(guid);
            var model = new ViewItem
            {
                GuidItem = item.GuidItem,
                Description = item.Description,
                Done = item.Done
            };
            return View(model);
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid guid, IFormCollection formCollection)
        {
            var item = await _repository.FindById(guid);
            await _repository.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
