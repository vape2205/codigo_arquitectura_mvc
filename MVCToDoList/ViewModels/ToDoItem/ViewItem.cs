using System.ComponentModel.DataAnnotations;

namespace MVCToDoList.DTOs.ToDoItem
{
    public class ViewItem
    {
        [Display(Name = "Id")]
        public Guid GuidItem { get; set; } = Guid.NewGuid();
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "¿Hecho?")]
        public bool Done { get; set; }
    }
}
