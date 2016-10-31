using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess;
using Xunit;

namespace TodoApp.Tests
{
    public class EfDataTests
    {
        [Fact]
        public void Test_InsertItem()
        {
            var data = new EfData();
            var expected = new TodoItem() { ItemTitle = "Clean Room", ItemDescription = "Pick up clothes and vacuum.", Completed = false };

            var actual = data.InsertItem(expected);

            Assert.True(actual);
        }

        [Fact]
        public void Test_RemoveItem()
        {
            var data = new EfData();
            var idItemToRemove = 1;

            var item = new TodoItem() { ItemTitle = "Clean Room", ItemDescription = "Pick up clothes and vacuum.", Completed = false };
            data.InsertItem(item);

            var actual = data.RemoveItem(item.Id);

            Assert.True(actual);
        }

        [Fact]
        public void Test_UpdateItem()
        {
            var data = new EfData();
            var expected = new TodoItem() { ItemTitle = "Clean Room", ItemDescription = "Pick up clothes and vacuum.", Completed = false };

            var actual = data.UpdateItem(expected, System.Data.Entity.EntityState.Added);

            Assert.True(actual);
        }

        [Fact]
        public void Test_UpdateCompletionStatus()
        {
            var data = new EfData();
            bool completionStatus = true;

            var item = new TodoItem() { ItemTitle = "Clean Room", ItemDescription = "Pick up clothes and vacuum.", Completed = false };
            var updated = data.UpdateCompletionStatus(item, completionStatus);

            Assert.True(item.Completed);
        }

        [Fact]
        public void Test_GetTodoItems()
        {
            var data = new EfData();
            var actual = data.GetTodoItems();
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_GetTodoItemsComplete()
        {
            var data = new EfData();
            var actual = data.GetTodoItemsComplete();
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_GetTodoItemsIncomplete()
        {
            var data = new EfData();
            var actual = data.GetTodoItemsIncomplete();
            Assert.NotNull(actual);
        }

    }
}
