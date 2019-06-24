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
			var result = dbContext.TodoItem.FirstOrDefault(x => x.Id == pId);
			if (result != null)
			{
				dbContext.TodoItem.Remove(result);
				return true;
			}
			return false;
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
			var updateSuccess = true;
			try
			{
				var result = dbContext.TodoItem.FirstOrDefault(x => x.Id == pEntity.Id);
				result.DeadLine = pEntity.DeadLine;
				result.UserId = pEntity.UserId;
				result.Name = pEntity.Name;
				result.Description = pEntity.Description;
			}
			catch(Exception)
			{
				updateSuccess = false;
			}
			return updateSuccess;
		}
	}
}
