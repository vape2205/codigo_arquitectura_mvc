using System.ComponentModel.DataAnnotations;

namespace MVCToDoList.DTOs.ToDoItem
{
    public class EditItem
    {
        [Required]
        [Display(Name = "Id")]
        public Guid GuidItem { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "Debe tener máximo {0} carácteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "¿Hecho?")]
        public bool Done { get; set; }
    }
}
