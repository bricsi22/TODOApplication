using System;

namespace TODOApp.ViewModels.User
{
	public class UserTodoItemViewModel
	{
		public long Id { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DeadLine { get; set; }
	}
}
