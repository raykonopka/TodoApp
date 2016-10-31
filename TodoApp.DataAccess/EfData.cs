using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataAccess
{
    public class EfData
    {
        private TodoDBEntities db = new TodoDBEntities();

        //Add an item
        public bool InsertItem(TodoItem item)
        {
            db.TodoItems.Add(item);
            return db.SaveChanges() > 0;
        }

        //Delete an item
        public bool RemoveItem(int ItemId)
        {
            List<TodoItem> allItems = GetTodoItems();
            var matchingItems = allItems.Where(i => i.Id.Equals(ItemId));

            db.TodoItems.Remove(matchingItems.First());
            return db.SaveChanges() > 0;
        }

        //Update an item
        public bool UpdateItem(TodoItem item, EntityState state)
        {
            var entry = db.Entry<TodoItem>(item);

            entry.State = state;
            return db.SaveChanges() > 0;
        }


        //Make item as complete or incomplete
        public bool UpdateCompletionStatus(TodoItem item, bool completed)
        {
            if (completed)
            {
                item.Completed = true;
            }
            else
            {
                item.Completed = false;
            }

            return db.SaveChanges() > 0;
        }

        //Get a list of items
        public List<TodoItem> GetTodoItems()
        {
            return db.TodoItems.ToList();
        }

        //Get a list of compelted items
        public List<TodoItem> GetTodoItemsComplete()
        {
            List<TodoItem> AllItems = GetTodoItems();
            List<TodoItem> CompletedItems = new List<TodoItem>();

            foreach (TodoItem item in AllItems)
            {
                if (item.Completed == true)
                {
                    CompletedItems.Add(item);
                }
            }

            return CompletedItems;
        }


        //Get a list of incompelte items
        public List<TodoItem> GetTodoItemsIncomplete()
        {
            List<TodoItem> AllItems = GetTodoItems();
            List<TodoItem> IncompleteItems = new List<TodoItem>();

            foreach (TodoItem item in AllItems)
            {
                if (item.Completed != true)
                {
                    IncompleteItems.Add(item);
                }
            }

            return IncompleteItems;
        }

    }
}
