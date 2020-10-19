using System.Collections.Generic;
using Todo.Models;

namespace Todo.Services
{
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new []
        {
            new TodoItem { Description = "Top-level Statements", IsChecked = true },
            new TodoItem { Description = "Record types", IsChecked = true },
            new TodoItem { Description = "Avalonia Support", IsChecked = true },
            new TodoItem { Description = "Source Generators" }
        };
    };
}