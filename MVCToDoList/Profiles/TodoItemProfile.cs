using AutoMapper;
using MVCToDoList.DTOs.ToDoItem;
using MVCToDoList.Models;

namespace MVCToDoList.Profiles
{
    public class TodoItemProfile:Profile
    {
        public TodoItemProfile()
        {
            CreateMap<ToDoItem, ViewItem>();
        }
    }
}
