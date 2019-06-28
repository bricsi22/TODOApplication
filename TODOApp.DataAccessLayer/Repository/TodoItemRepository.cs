using System;
using System.Linq;
using TODOApp.Data;
using TODOApp.DataAccessLayer.DatabaseContext;
using TODOApp.Interface.Repository;

namespace TODOApp.DataAccessLayer.Repository
{
	public class TodoItemRepository : ITodoItemRepository
	{
		private ApplicationDbContext dbContext;
		public TodoItemRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public long Create(TodoItem pEntity)
		{
			var result = dbContext.TodoItem.Add(pEntity);
			dbContext.SaveChanges();
			return result.Entity.Id;
		}

		public bool Delete(long pId)
		{
			var success = false;
			var result = dbContext.TodoItem.FirstOrDefault(x => x.Id == pId);
			if (result != null)
			{
				dbContext.TodoItem.Remove(result);
				dbContext.SaveChanges();
				success = true;
			}

			return success;
		}

		public TodoItem Get(long pId)
		{
			var result = dbContext.TodoItem.FirstOrDefault(x => x.Id == pId);
			return result;
		}

		public IQueryable<TodoItem> GetAll()
		{
			return dbContext.TodoItem;
		}

		public bool Update(TodoItem pEntity)
		{
			var updateSuccess = false;
			var result = dbContext.TodoItem.FirstOrDefault(x => x.Id == pEntity.Id);
			if (result != null)
			{
				result.DeadLine = pEntity.DeadLine;
				result.UserId = pEntity.UserId;
				result.Name = pEntity.Name;
				result.Description = pEntity.Description;
				dbContext.TodoItem.Update(result);
				dbContext.SaveChanges();
				updateSuccess = true;
			}
			return updateSuccess;
		}
	}
}
