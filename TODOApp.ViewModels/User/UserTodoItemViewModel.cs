using System;
using System.Collections.Generic;
using System.Text;

namespace TODOApp.ViewModels.User
{
	public class UserTodoItemViewModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DeadLine { get; set; }
	}
}
