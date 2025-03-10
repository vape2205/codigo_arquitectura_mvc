﻿using System.ComponentModel.DataAnnotations;

namespace MVCToDoList.Models
{
    public class ToDoItem
    {
        [Key]
        public Guid GuidItem { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
