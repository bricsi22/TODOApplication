using System;

namespace TODOApp.Interface.ViewModel
{
    public interface IUserTodoItemViewModel
    {
		long Id { get; set; }

		string Name { get; set; }

		string Description { get; set; }

		DateTime DeadLine { get; set; }
	}
}
