using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todoItems =
            new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }
        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todoItems[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todoItems.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems.Values;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todoItems.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todoItems[item.Key] = item;
        }
    }
}
